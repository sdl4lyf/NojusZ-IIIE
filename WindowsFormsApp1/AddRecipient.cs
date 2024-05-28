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
        char[] separator;
        public AddRecipient(ListBox input, Messaging.Data input2)
        {
            recipients = input;
            data = input2;
            separator = new char[] { ':' };
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                if (data.activatedToChangeInfo)
                {
                    int ind = recipients.SelectedIndex;
                    int temp = data.names[recipients.Items[ind].ToString()];
                    data.names.Remove(recipients.Items[ind].ToString());
                    data.names.Add(textBox1.Text, temp);
                    recipients.Items.RemoveAt(ind);
                    recipients.Items.Insert(ind, textBox1.Text);
                    data.recipients[ind].name = textBox1.Text;
                    data.recipients[ind].ip = textBox2.Text.Split(separator)[0];
                    data.recipients[ind].port = Convert.ToInt32(textBox2.Text.Split(separator)[1]);
                    Close();
                    return;
                }
                recipients.Items.Add(textBox1.Text);
                 
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
