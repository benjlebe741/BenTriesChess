namespace BenTriesChess
{
    partial class Form1
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
            this.updateDisplayTestButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // updateDisplayTestButton
            // 
            this.updateDisplayTestButton.Location = new System.Drawing.Point(889, 108);
            this.updateDisplayTestButton.Name = "updateDisplayTestButton";
            this.updateDisplayTestButton.Size = new System.Drawing.Size(226, 277);
            this.updateDisplayTestButton.TabIndex = 86;
            this.updateDisplayTestButton.Text = "button1";
            this.updateDisplayTestButton.UseVisualStyleBackColor = true;
            this.updateDisplayTestButton.Click += new System.EventHandler(this.updateDisplayTestButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(886, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 75);
            this.label1.TabIndex = 87;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1127, 744);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateDisplayTestButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button updateDisplayTestButton;
        private System.Windows.Forms.Label label1;
    }
}

