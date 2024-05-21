﻿using System;
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
        public Messaging data2 { get; set; }
        public string currRecipient { get; set; }

        public Form1()
        {
            InitializeComponent();
            
            data2 = new Messaging();
            data = data2.data;
            data.counter = 0;
            data.selected = false;
            currRecipient = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(textBox.Text) )
            {
                msgBox.Items.Add(textBox.Text);
                data.recipients[data.names[currRecipient]].messages.Add(new Messaging.Message() {text=textBox.Text,time= DateTimeOffset.UtcNow.ToUnixTimeSeconds() });
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
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            data2.Save(data);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (currRecipient != listBox1.SelectedItem.ToString())
            {
                foreach (Messaging.Message msg in data.recipients[data.names[currRecipient]].messages)
                {
                    msgBox.Items.Add(msg.text);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
