using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Communication
    {

        private static Communication instance;
        public static Communication Instance
        {
            get
            {
                if (instance == null) instance = new Communication();
                return instance;
            }
        }
        private Communication()
        {

        }

        private Sender sender;
        private Receiver receiver;
        private Socket socket;

        public bool Connection()
        {
            try
            {
                if (socket == null || !socket.Connected)
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect("127.0.0.1", 9999);
                    sender = new Sender(socket);
                    receiver = new Receiver(socket);
                }
                return true;
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(ex.Message);
                socket = null;
                return false;
            }
        }

        public void Send(Common.Message msg)
        {
            sender.Send(msg);
        }

        public Common.Message Receive()
        {
            return receiver.Receive<Common.Message>();
        }

        internal void CloseConnection()
        {
            socket.Close();
            socket= null;
        }
    }
}
