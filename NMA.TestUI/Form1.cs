using System;
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
        public NMALib.NMANotificationPriority PriorityLevel = NMANotificationPriority.VeryLow;
        public MessageTest()
        {
            InitializeComponent();
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


        private void button1_Click(object sender, EventArgs e)
        {
            OutputTextBlock.Clear();
            OutputTextBlock.Update();
          
            if (title.Text == "" )
            {
                MessageBox.Show("Error: Please enter a title!");  
            }
            else if( body.Text == "")
            {
                MessageBox.Show("Error: Please enter a message!");  
            }
            else if(prioritybox.SelectedItem  == null)
            {
                MessageBox.Show("Error: Please select a priority!");  
            }
        else
            {
                string theURL = "";
                if (urltext.Text != "")
                {
                    if (!urltext.Text.Contains("http://"))
                    {
                        theURL = String.Concat("http://", urltext.Text);
                    }
                }

                var notificationMsg =
                    new NMANotification
                        {
                            Description = body.Text,
                            Event = title.Text,
                            Priority = PriorityLevel,
                            Url = theURL
                        };

                var messageClient = new NMAClient();
                // Post the notification.
                var status = messageClient.PostNotification(notificationMsg);
                OutputTextBlock.Text = status;

            }
        }

        private void OutputTextBlock_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
