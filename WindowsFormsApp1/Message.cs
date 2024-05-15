using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace WindowsFormsApp1
{
    public class Messaging
    {
        public class Message
        {
            public string text { get; set; }
            public long time { get; set; }

        }
        public class Recipient 
        {
            public List<Message> messages { get; set; }
            public string name { get; set; }

        }
        public class Data
        {
            public List<Recipient> recipients { get; set; }
            public string lastRecipient { get; set; }
            public Dictionary<string, int> names { get; set; }
            public int counter { get; set; }
        }
        
        

        public string path { get; set; }
        public Messaging()
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(strExeFilePath);
            Load();
        }
        public void Load()
        {
            
        }

    }
}
