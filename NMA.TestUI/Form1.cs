﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using NMALib;

namespace NMA.TestUI
{
    public partial class MessageTest : Form
    {
        public NMALib.NMANotificationPriority PriorityLevel = NMANotificationPriority.Normal;

        public MessageTest()
        {
            InitializeComponent();
        }
        private void MessageTest_Load(object sender, EventArgs e)
        {
            OutputTextBlock.Text = "Enter your message and click send";
            OutputTextBlock.Update();

        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            OutputTextBlock.Clear();
            OutputTextBlock.Update();

            if (String.IsNullOrEmpty(title.Text))
            {
                MessageBox.Show("Error: Please enter a title!");
            }
            else if (String.IsNullOrEmpty(body.Text))
            {
                MessageBox.Show("Error: Please enter a message!");
            }
            else if (prioritybox.SelectedItem == null)
            {
                MessageBox.Show("Error: Please select a priority!");
            }
            else
            {
                OutputTextBlock.Text = "Sending.....";
                OutputTextBlock.Update();
                string theURL = "";
                if (urltext.Text != "" && !urltext.Text.Contains("http://")) theURL = String.Concat("http://", urltext.Text);
     
                var notificationMsg =
                    new NMANotification
                        {
                            Description = body.Text,
                            Event = title.Text,
                            Priority = PriorityLevel,
                            Url = theURL
                        };

                NMAClient messageClient = new NMAClient();
                // Post the notification.
                OutputTextBlock.Clear();
                OutputTextBlock.Text = messageClient.PostNotification(notificationMsg);
                OutputTextBlock.Update();
             
            }
        }

        private void prioritybox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (prioritybox.SelectedItem.ToString())
            {
                case "Very Low":
                    PriorityLevel = NMANotificationPriority.VeryLow;
                    break;
                case "Moderate":
                    PriorityLevel = NMANotificationPriority.Moderate;
                    break;
                case "Normal":
                    PriorityLevel = NMANotificationPriority.Normal;
                    break;
                case "High":
                    PriorityLevel = NMANotificationPriority.High;
                    break;
                default:
                    PriorityLevel = NMANotificationPriority.Emergency;
                    break;
            }
        }
       

     

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
        }

        private void OutputTextBlock_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
