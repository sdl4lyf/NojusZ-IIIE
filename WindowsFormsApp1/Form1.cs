﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Messaging.Data data { get; set; }
        public Messaging data2 { get; set; }
        public string currRecipient { get; set; }

        public Form1()
        {
            InitializeComponent();
            
            data2 = new Messaging();
            data = data2.data;
            data.counter = 0;
            data.selected = false;
            data.currRecipient = "";
            label1.Text = data.currName +':'+ local_ip();
        }
        public string local_ip()
        {
            return Dns.GetHostAddresses(Dns.GetHostName())[1].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(textBox.Text) )
            {
                msgBox.Items.Add(textBox.Text);
                data.recipients[data.names[data.currRecipient]].messages.Add(new Messaging.Message() {text=textBox.Text,time= DateTimeOffset.UtcNow.ToUnixTimeSeconds() });
                msgBox.TopIndex = msgBox.Items.Count - 1;
                textBox.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddRecipient frm = new AddRecipient(listBox1,data);
            frm.ShowDialog();
            if (data.selected)
            {
                textBox.Enabled = true;
                var curr = data.recipients[data.names[data.currRecipient]];
                label2.Text = curr.name + ":" + curr.ip + ":" + curr.port.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            data2.Save(data);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem == null)
            {
                return;
            }
            var curr = data.recipients[data.names[data.currRecipient]];
            label2.Text = curr.name+":"+curr.ip+":"+curr.port.ToString();
            msgBox.Items.Clear();
            data.currRecipient = listBox1.SelectedItem.ToString();
            foreach (Messaging.Message msg in data.recipients[data.names[data.currRecipient]].messages)
            {
                msgBox.Items.Add(msg.text);
            }
            if (data.currRecipient != "") { data.selected = true; textBox.Enabled = true; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            data = data2.Load();
            foreach(Messaging.Recipient recipient in data.recipients)
            {
                listBox1.Items.Add(recipient.name);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new NickChange(data).ShowDialog();
            label1.Text = data.currName + ':' + local_ip();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listBox1.SelectedIndex = listBox1.IndexFromPoint(e.Location);
            if (listBox1.SelectedIndex != -1)
            {
               contextMenuStrip1.Show();
            }
        }

        private void changeInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
