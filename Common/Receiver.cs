using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Receiver
    {


        NetworkStream stream;
        BinaryFormatter formatter;
        Socket socket;

        public Receiver(Socket socket)
        {
            this.socket = socket;
            formatter = new BinaryFormatter();
            stream = new NetworkStream(socket);
        }

        public T Receive<T>() where T : class
        {
            return (T)formatter.Deserialize(stream);
        }

    }
}
