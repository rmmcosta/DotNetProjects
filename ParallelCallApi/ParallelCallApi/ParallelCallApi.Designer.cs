namespace ParallelCallApi
{
    partial class ParallelCallApi
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
            this.getUrlTextBox = new System.Windows.Forms.TextBox();
            this.postUrlTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.guidTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // getUrlTextBox
            // 
            this.getUrlTextBox.Location = new System.Drawing.Point(12, 12);
            this.getUrlTextBox.Name = "getUrlTextBox";
            this.getUrlTextBox.Size = new System.Drawing.Size(776, 20);
            this.getUrlTextBox.TabIndex = 0;
            this.getUrlTextBox.Text = "https://ricardocosta85.outsystemscloud.com/ServiceTest_Api/rest/Calculations/Divi" +
    "de?In1=10&In2=2";
            // 
            // postUrlTextBox
            // 
            this.postUrlTextBox.Location = new System.Drawing.Point(12, 173);
            this.postUrlTextBox.Name = "postUrlTextBox";
            this.postUrlTextBox.Size = new System.Drawing.Size(776, 20);
            this.postUrlTextBox.TabIndex = 1;
            this.postUrlTextBox.Text = "https://ricardocosta85.outsystemscloud.com/Parallel_Api/rest/SaveResult/";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(775, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Call";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // guidTextBox
            // 
            this.guidTextBox.Location = new System.Drawing.Point(13, 199);
            this.guidTextBox.Name = "guidTextBox";
            this.guidTextBox.Size = new System.Drawing.Size(775, 20);
            this.guidTextBox.TabIndex = 3;
            this.guidTextBox.Text = ".Net call";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(776, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "https://ricardocosta85.outsystemscloud.com/ServiceTest_Api/rest/Calculations/Sub?" +
    "In1=10&In2=2";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(13, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(776, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "https://ricardocosta85.outsystemscloud.com/ServiceTest_Api/rest/Calculations/Sum?" +
    "In1=10&In2=2";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(13, 90);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(776, 20);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "https://ricardocosta85.outsystemscloud.com/ServiceTest_Api/rest/Calculations/Mult" +
    "iply?In1=10&In2=2";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 264);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(775, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Call Task Factory";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ParallelCallApi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.guidTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.postUrlTextBox);
            this.Controls.Add(this.getUrlTextBox);
            this.Name = "ParallelCallApi";
            this.Text = "Parallel Call Apis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox getUrlTextBox;
        private System.Windows.Forms.TextBox postUrlTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox guidTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
    }
}

