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

            if (SelectValidate(prioritybox, prioritybox.Name))
            {

                OutputTextBlock.Text = "Sending.....";
                OutputTextBlock.Update();
                string theURL = "";
                if (urltext.Text != "" && !urltext.Text.Contains("http://"))
                    theURL = String.Concat("http://", urltext.Text);

                var notificationMsg =
                    new NMANotification
                        {
                            Description = body.Text,
                            Event = title.Text,
                            Priority = PriorityLevel,
                            Url = theURL
                        };

                NMAClient messageClient = new NMAClient();

                OutputTextBlock.Clear();
                OutputTextBlock.Text = messageClient.PostNotification(notificationMsg);
                    // Post the notification and update the textbox
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


      

        /* *********************** Field Validation *************************** */

        public bool ValidField(string field, out string errorMessage)
        {
            if (field.Length == 0)
            {
                errorMessage = field + " is required.";
                return false;
            }
            errorMessage = "";
            return true;
        }

        private bool SelectValidate(ListBox thebox, string selectName)
        {
            String errorMsg = selectName + " is required";
            if (thebox.SelectedItem == null)
            {
                errorProvider3.SetError(thebox, errorMsg); 
                MessageBox.Show("Error: Please select a "+ selectName);
                
                return false;
            }
            errorProvider3.SetError(thebox,"");    
            return true;
                
        }
        
        public bool ValidSelect( object selectedobj, out string errorMessage)
        {
            if (selectedobj.Equals(null))
            {
                errorMessage = selectedobj + " is required.";
                return false;
            }
            errorMessage = "";
            return true;
        }

        //Title Field Validation

        private void title_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidField(title.Text, out errorMsg))
            {
                e.Cancel = true;
                title.Select(0, title.Text.Length);
                errorProvider1.SetError(title, errorMsg);
            }
        }

 

        private void title_Validated_1(object sender, EventArgs e)
        {
            errorProvider1.SetError(title, "");
        }


        
        //Body Field Validation
        private void body_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidField(body.Text, out errorMsg))
            {
                e.Cancel = true;
                body.Select(0, body.Text.Length);

                errorProvider2.SetError(body, errorMsg);
            }
        }



        //Extra
        private void body_Validated(object sender, EventArgs e)
        {
            errorProvider2.SetError(body, "");
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
