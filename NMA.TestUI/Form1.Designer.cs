namespace NMA.TestUI
{
    partial class MessageTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.TextBox();
            this.retrieveInput = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.body = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.prioritybox = new System.Windows.Forms.ListBox();
            this.urltext = new System.Windows.Forms.TextBox();
            this.OutputTextBlock = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter a title:";
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(2, 22);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(150, 20);
            this.title.TabIndex = 1;
            this.title.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // retrieveInput
            // 
            this.retrieveInput.Location = new System.Drawing.Point(102, 138);
            this.retrieveInput.Name = "retrieveInput";
            this.retrieveInput.Size = new System.Drawing.Size(75, 23);
            this.retrieveInput.TabIndex = 2;
            this.retrieveInput.Text = "Send";
            this.retrieveInput.UseVisualStyleBackColor = true;
            this.retrieveInput.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-2, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Please enter the body text:";
            // 
            // body
            // 
            this.body.Location = new System.Drawing.Point(2, 68);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(150, 20);
            this.body.TabIndex = 4;
            this.body.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(202, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Priority";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-2, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Enter a URL:  (Optional)";
            // 
            // prioritybox
            // 
            this.prioritybox.FormattingEnabled = true;
            this.prioritybox.Items.AddRange(new object[] {
            "Very Low",
            "Moderate",
            "Normal",
            "High",
            "Emergency"});
            this.prioritybox.Location = new System.Drawing.Point(183, 84);
            this.prioritybox.Name = "prioritybox";
            this.prioritybox.Size = new System.Drawing.Size(82, 69);
            this.prioritybox.TabIndex = 7;
            this.prioritybox.SelectedIndexChanged += new System.EventHandler(this.prioritybox_SelectedIndexChanged);
            // 
            // urltext
            // 
            this.urltext.Location = new System.Drawing.Point(2, 112);
            this.urltext.Name = "urltext";
            this.urltext.Size = new System.Drawing.Size(150, 20);
            this.urltext.TabIndex = 8;
            this.urltext.TextChanged += new System.EventHandler(this.textBox1_TextChanged_2);
            // 
            // OutputTextBlock
            // 
            this.OutputTextBlock.Location = new System.Drawing.Point(2, 167);
            this.OutputTextBlock.Name = "OutputTextBlock";
            this.OutputTextBlock.ReadOnly = true;
            this.OutputTextBlock.Size = new System.Drawing.Size(263, 37);
            this.OutputTextBlock.TabIndex = 9;
            this.OutputTextBlock.Text = "";
            this.OutputTextBlock.TextChanged += new System.EventHandler(this.OutputTextBlock_TextChanged);
            // 
            // MessageTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 211);
            this.Controls.Add(this.OutputTextBlock);
            this.Controls.Add(this.urltext);
            this.Controls.Add(this.prioritybox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.body);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.retrieveInput);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label1);
            this.Name = "MessageTest";
            this.Text = "MessageTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox title;
        public System.Windows.Forms.Button retrieveInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox body;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox prioritybox;
        private System.Windows.Forms.TextBox urltext;
        private System.Windows.Forms.RichTextBox OutputTextBlock;
    }
}

