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
            this.postUrlTextBox.Location = new System.Drawing.Point(12, 38);
            this.postUrlTextBox.Name = "postUrlTextBox";
            this.postUrlTextBox.Size = new System.Drawing.Size(776, 20);
            this.postUrlTextBox.TabIndex = 1;
            this.postUrlTextBox.Text = "https://ricardocosta85.outsystemscloud.com/Parallel_Api/rest/SaveResult/Divide?Re" +
    "sult={Result}";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(775, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Call";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // guidTextBox
            // 
            this.guidTextBox.Location = new System.Drawing.Point(13, 65);
            this.guidTextBox.Name = "guidTextBox";
            this.guidTextBox.Size = new System.Drawing.Size(775, 20);
            this.guidTextBox.TabIndex = 3;
            this.guidTextBox.Text = ".Net call";
            // 
            // ParallelCallApi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

