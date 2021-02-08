using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeKeyboardServer
{
    public class Utils
    {
        public static string getIPList()
        {
            var list = new List<KeyValuePair<int, string>>();
            list = GetConexionTypes(true);
            return JsonConvert.SerializeObject(list, Formatting.None);
        }
        public static int FreeTcpPort()
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            
            return port;
        }
        public static List<KeyValuePair<int, string>> GetConexionTypes(bool avanzado = false)
        {
            var enumerationType = typeof(NetworkInterfaceType);
            var list = new List<KeyValuePair<int, string>>();

            if (avanzado)
            {
                foreach (int value in Enum.GetValues(enumerationType))
                {
                    var name = Enum.GetName(enumerationType, value);
                    list.Add(new KeyValuePair<int, string>(value, name));
                }
                list.Add(new KeyValuePair<int, string>(998, "Sencillo"));
            }
            else
            {
                list.Add(new KeyValuePair<int, string>(6, "Cable de red"));
                list.Add(new KeyValuePair<int, string>(71, "Wifi"));
                list.Add(new KeyValuePair<int, string>(999, "Avanzado"));
            }
            return list;
        }

        public static string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
    }
}
