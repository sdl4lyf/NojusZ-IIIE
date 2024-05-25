using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Forms;

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
            public bool selected { get; set; }
            public string currRecipient { get; set; }
        }
        
        

        public string path { get; set; }
        public string jsonStr { get; set; }
        public Data data { get; set; }
        public Messaging()
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(strExeFilePath)+"\\data.json";
            data = new Data();
            data.recipients = new List<Recipient>();
            data.names = new Dictionary<string, int>();
        }
        public Data Load()
        {
            Data data;
            jsonStr = File.ReadAllText(path);
            data = JsonSerializer.Deserialize<Data>(jsonStr);
            return data;
            
        }
        public void Save(Data data)
        {
            jsonStr = JsonSerializer.Serialize(data);
            File.WriteAllText(path, jsonStr);
        }

    }
}
