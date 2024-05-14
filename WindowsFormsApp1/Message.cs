using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace WindowsFormsApp1
{
    internal class Messaging
    {
        class Message
        {
            public string text { get; set; }
            public long time { get; set; }
            public Message(string Text,long Time)
            {
                this.text = Text;
                this.time = Time;
            }

        }
        class Recipient 
        {
            public List<Message> messages { get; set; }
            public string name { get; set; }

        }
        class Data
        {
            public List<Recipient> recipients { get; set; }
        }

        public string path { get; set; }
        public Messaging()
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(strExeFilePath);
            Open();
        }
        public void Open()
        {
            
        }
    }
}
