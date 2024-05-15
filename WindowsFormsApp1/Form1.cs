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
    public partial class Form1 : Form
    {
        public Messaging.Data data { get; set; }
        public Form1()
        {
            InitializeComponent();
            
            data = new Messaging.Data();
            data.counter = 0;
            string currRecipient = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(textBox.Text) )
            {
                msgBox.Items.Add(textBox.Text);
                textBox.Clear();
                //data.names
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddRecipient frm = new AddRecipient(listBox1,data);
            frm.ShowDialog();
        }
    }
}
