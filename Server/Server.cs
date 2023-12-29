using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        Socket osluskujuciSoket;
        public static List<ClientHandler> Clients = new List<ClientHandler>();

        public Server()
        {
            osluskujuciSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }


        public void Start()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            osluskujuciSoket.Bind(endPoint);
            osluskujuciSoket.Listen(5);

            Thread thread = new Thread(AcceptClient);
            thread.Start();


        }

        public void AcceptClient()
        {
            try
            {
                while (true)
                {
                    Socket klijentskiSoket = osluskujuciSoket.Accept();
                    ClientHandler handler = new ClientHandler(klijentskiSoket);
                    Clients.Add(handler);
                    Thread thread = new Thread(handler.HandleRequest);
                    thread.Start();
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(">>>"+ex.Message);
              
            }
        }

        internal void Stop()
        {
            osluskujuciSoket.Close();
            foreach(ClientHandler client in Clients)
            {
                client.Stop();
            }
            Clients.Clear();
        }
    }
}
