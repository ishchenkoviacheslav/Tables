namespace Tables
{
    partial class MainForm
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
            this.ContactView = new System.Windows.Forms.DataGridView();
            this.contact = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ContactView)).BeginInit();
            this.SuspendLayout();
            // 
            // ContactView
            // 
            this.ContactView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContactView.Location = new System.Drawing.Point(13, 13);
            this.ContactView.Name = "ContactView";
            this.ContactView.Size = new System.Drawing.Size(634, 300);
            this.ContactView.TabIndex = 0;
            // 
            // contact
            // 
            this.contact.Location = new System.Drawing.Point(676, 13);
            this.contact.Name = "contact";
            this.contact.Size = new System.Drawing.Size(83, 300);
            this.contact.TabIndex = 1;
            this.contact.Text = "contact";
            this.contact.UseVisualStyleBackColor = true;
            this.contact.Click += new System.EventHandler(this.contact_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 371);
            this.Controls.Add(this.contact);
            this.Controls.Add(this.ContactView);
            this.Name = "MainForm";
            this.Text = "Table";
            ((System.ComponentModel.ISupportInitialize)(this.ContactView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ContactView;
        private System.Windows.Forms.Button contact;
    }
}

