using Common;
using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;

namespace Server
{
    public class ClientHandler
    {

        private Socket socket;
        private Sender sender;
        private Receiver receiver;

        public string Username { get; private set; }

        public ClientHandler(Socket klijentskiSoket)
        {

            socket = klijentskiSoket;
            sender = new Sender(socket);
            receiver = new Receiver(socket);

        }

        public void HandleRequest()
        {
            try
            {
                bool kraj = false;
                while (!kraj)
                {
                    Common.Message message = receiver.Receive<Common.Message>();

                    switch (message.Operation)
                    {
                        case Operation.Login:
                            Login(message);
                            Message osveziKlijente = new Common.Message();
                            osveziKlijente.Operation = Operation.GetAll;
                            osveziKlijente.Clients = Server.Clients.Select(ch => ch.Username).ToList();
                            SendToAll(osveziKlijente);
                            break;
                        case Operation.SendToAll:
                            message.Username = Username;
                            SendToAll(message);
                            break;
                        case Operation.GetAll:
                            message.Operation = Operation.GetAll;
                            message.Clients = Server.Clients.Select(ch => ch.Username).ToList();
                            sender.Send(message);
                            break;
                        case Operation.End:
                            message.Operation = Operation.End;
                            foreach (ClientHandler client in Server.Clients)
                            {
                                if (client.Username == message.Username)
                                {
                                    client.sender.Send(message);
                                }
                            }
                            break;
                        case Operation.Finalize:
                            //Shutdown sockets???
                            Server.Clients.Remove(this);
                            kraj = true;
                            message.Operation = Operation.GetAll;
                            message.Clients = Server.Clients.Select(ch => ch.Username).ToList();
                            SendToAll(message);
                            break;
                    }

                }
            }
            catch (IOException ex)
            {
                Server.Clients.Remove(this);
                Message osveziKlijente = new Common.Message();
                osveziKlijente.Operation = Operation.GetAll;
                osveziKlijente.Clients = Server.Clients.Select(ch => ch.Username).ToList();
                SendToAll(osveziKlijente);
                Console.WriteLine(ex.Message);
            }
        }

        private void SendToAll(Common.Message message)
        {
            foreach (ClientHandler client in Server.Clients)
            {
                client.sender.Send(message);
            }
        }

        private void Login(Common.Message message)
        {
            bool postoji = false;
            foreach (ClientHandler client in Server.Clients)
            {
                if (message.Username == client.Username)
                {
                    postoji = true;
                }
            }
            if (postoji)
            {
                Common.Message msg = new Common.Message
                {
                    Operation = Operation.Login,
                    IsSuccessful = false,
                    ErrorText = "Korisnik sa zadatim imenom vec postoji"
                };
                sender.Send(msg);
            }
            else
            {
                Common.Message msg = new Message
                {
                    Operation = Operation.Login,
                    IsSuccessful = true
                };
                Username = message.Username;
                sender.Send(msg);
            }
        }

        internal void Stop()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
