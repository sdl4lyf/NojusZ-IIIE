using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSimpleTcp;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Client
    {
        SimpleTcpClient client;
        public Client(string ip,int port)
        {
            client = new SimpleTcpClient(ip + ":" + port.ToString());
            client.Events.Connected += Connected;
            client.Connect();
        }
        static void Connected(object sender, ConnectionEventArgs e)
        {

        }
        public void Send(string message)
        {
            client.Send(message);
        }
    }
}
