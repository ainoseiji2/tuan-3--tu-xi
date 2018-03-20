using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipend = new IPEndPoint(IPAddress.Any, 9050);
            newsock.Bind(ipend);
            EndPoint ep = ipend;
            while (true)
            {
                byte[] receivedata = new byte[20];
                newsock.ReceiveFrom(receivedata, ref ep);
                int result = Convert.ToInt32(Encoding.ASCII.GetString(receivedata));
                {
                    Random r = new Random();
                    int serverresult = r.Next(0, 3);
                    if (serverresult == 0 && result == 1 || serverresult == 1 && result == 2 || serverresult == 2 && result == 1)
                    {
                        byte[] sendData = Encoding.ASCII.GetBytes("Thua");
                        newsock.SendTo(sendData, 0, ep);
                    }
                    else if (serverresult == 0 && result == 2 || serverresult == 1 && result == 0 || serverresult == 2 && result == 1)
                    {
                        byte[] sendData = Encoding.ASCII.GetBytes("Thang");
                        newsock.SendTo(sendData, 0, ep);
                    }
                    else
                    {
                        byte[] sendData = Encoding.ASCII.GetBytes("Hoa");
                        newsock.SendTo(sendData, 0, ep);
                    }
                }
            }
        }
    }
}
