namespace Vsite.CSharp.Iznimke
{
    partial class BacačIznimki
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
            this.buttonException = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonException
            // 
            this.buttonException.Location = new System.Drawing.Point(121, 147);
            this.buttonException.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonException.Name = "buttonException";
            this.buttonException.Size = new System.Drawing.Size(88, 27);
            this.buttonException.TabIndex = 0;
            this.buttonException.Text = "&Baci iznimku";
            this.buttonException.UseVisualStyleBackColor = true;
            this.buttonException.Click += new System.EventHandler(this.buttonException_Click);
            // 
            // BacačIznimki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 336);
            this.Controls.Add(this.buttonException);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "BacačIznimki";
            this.Text = "Bacač iznimki";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonException;
    }
}

