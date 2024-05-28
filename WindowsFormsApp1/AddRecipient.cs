using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class AddRecipient : Form
    {
        ListBox recipients;
        Messaging.Data data;
        public AddRecipient(ListBox input, Messaging.Data input2)
        {
            recipients = input;
            data = input2;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                if (data.activatedToChangeInfo)
                {
                    recipients.Items.RemoveAt(recipients.SelectedIndex);
                    recipients.Items.Insert(recipients.SelectedIndex, textBox1.Text);


                }
                recipients.Items.Add(textBox1.Text);
                char[] separator = new char[] { ':' };  
                data.recipients.Add(new Messaging.Recipient { name = textBox1.Text, messages = new List<Messaging.Message> { },ip = textBox2.Text.Split(separator)[0],port = Convert.ToInt32(textBox2.Text.Split(separator)[1]) });
                data.lastRecipient = textBox1.Text;
                data.names.Add(textBox1.Text, data.counter++);
                data.selected = true;
                data.currRecipient = textBox1.Text;
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddRecipient_Load(object sender, EventArgs e)
        {

        }
    }
}
