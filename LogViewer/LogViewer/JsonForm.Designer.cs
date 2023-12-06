namespace LogViewer
{
    partial class JsonForm
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
            this.contentLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.jsonLabel = new System.Windows.Forms.Label();
            this.Contentpanel = new System.Windows.Forms.Panel();
            this.Contentpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentLabel
            // 
            this.contentLabel.AutoSize = true;
            this.contentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentLabel.Location = new System.Drawing.Point(0, 0);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(65, 12);
            this.contentLabel.TabIndex = 0;
            this.contentLabel.Text = "contentLabel";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(4, 30);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 12);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(45, 27);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(81, 22);
            this.nameTextBox.TabIndex = 4;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(147, 26);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // jsonLabel
            // 
            this.jsonLabel.AutoSize = true;
            this.jsonLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jsonLabel.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.jsonLabel.Location = new System.Drawing.Point(12, 87);
            this.jsonLabel.Name = "jsonLabel";
            this.jsonLabel.Size = new System.Drawing.Size(39, 14);
            this.jsonLabel.TabIndex = 0;
            this.jsonLabel.Text = "Json: ";
            // 
            // Contentpanel
            // 
            this.Contentpanel.AutoScroll = true;
            this.Contentpanel.AutoSize = true;
            this.Contentpanel.Controls.Add(this.contentLabel);
            this.Contentpanel.Location = new System.Drawing.Point(6, 114);
            this.Contentpanel.Name = "Contentpanel";
            this.Contentpanel.Size = new System.Drawing.Size(316, 194);
            this.Contentpanel.TabIndex = 6;
            // 
            // JsonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 313);
            this.Controls.Add(this.Contentpanel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.jsonLabel);
            this.Name = "JsonForm";
            this.Text = "JsonForm";
            this.Contentpanel.ResumeLayout(false);
            this.Contentpanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label jsonLabel;
        private System.Windows.Forms.Panel Contentpanel;
    }
}