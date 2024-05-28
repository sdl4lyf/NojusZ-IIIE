using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using SuperSimpleTcp;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Server
    {
        SimpleTcpServer server;
        Messaging.Data data;
        ListBox list;
        public Server(string ip,int port,Messaging.Data Data,ListBox lst)
        {
            data = Data;
            list = lst;
            server = new SimpleTcpServer(ip+":"+port.ToString());
            server.Events.DataReceived += DataReceived;
            server.Start();
        }
        private void DataReceived(object sender, DataReceivedEventArgs e)
        { 
            foreach (var x in data.recipients)
            {
                char[] sep = { ':' };
                if (e.IpPort.Split(sep)[0] == x.ip)
                {
                    var msg = new Messaging.Message { text = Encoding.UTF8.GetString(e.Data.Array, 0, e.Data.Count), sender = x.name + "(" + x.ip + ":" + x.port + ")" };
                    x.messages.Add(msg);
                    list.Items.Add(x.name+"("+x.ip+":"+x.port+")" + ": "+ msg.text);
                    list.TopIndex = list.Items.Count - 1;
                }
            }
        } 
    }
}
