using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Sender
    {


        NetworkStream stream;
        BinaryFormatter formatter;
        Socket socket;

        public Sender(Socket socket)
        {
            this.socket = socket;
            formatter = new BinaryFormatter();
            stream = new NetworkStream(socket);
        }

        public void Send(object argument)
        {
            formatter.Serialize(stream, argument);
        }

    }

}
