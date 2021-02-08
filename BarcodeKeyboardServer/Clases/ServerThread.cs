using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeKeyboardServer.Clases
{
    public class Server
    {
        static Thread thread;
        static UdpClient udpClient;

        static int port;
        public static int option { get; set; } = 0;
        public static bool isRunning { get; private set; }
        public static void Start(int port)
        {
            Server.port = port;
            Server.isRunning = true;
            Server.thread = new Thread(new ThreadStart(Server.ServerThread));
            Server.thread.Name = "BarcodeKeyboadServerSocket";
            Server.thread.Start();
        }
        public static void Stop()
        {
            Server.isRunning = false;
            Server.udpClient?.Close();
            Server.thread?.Abort();
        }
        public static void ServerThread()
        {
            try
            {
                while (Server.isRunning)
                {
                    string sufijo = Server.option == 1 ? "" : Server.option == 2 ? "{TAB}" : "{ENTER}";
                    Server.udpClient = new UdpClient(Server.port);
                    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    Byte[] receiveBytes = Server.udpClient.Receive(ref RemoteIpEndPoint);
                    string returnData = Encoding.ASCII.GetString(receiveBytes);
                    SendKeys.SendWait(returnData + sufijo);
                    Server.udpClient.Close();
                }
            }
            catch( Exception ex) {}
        }
    }
}
