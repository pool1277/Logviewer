namespace LogViewer
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TypeLabel = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.keywordTextBox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.readFileButton = new System.Windows.Forms.Button();
            this.dataFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.LogDataGridView = new System.Windows.Forms.DataGridView();
            this.beginDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.dataFilterTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.dataFilterPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataFilterTimePanel = new System.Windows.Forms.Panel();
            this.endLabel = new System.Windows.Forms.Label();
            this.Startlabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.LogDataGridView)).BeginInit();
            this.dataFilterPanel.SuspendLayout();
            this.dataFilterTimePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(7, 15);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(35, 12);
            this.TypeLabel.TabIndex = 0;
            this.TypeLabel.Text = "Type: ";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "Level",
            "Time",
            "Catagory",
            "Message"});
            this.TypeComboBox.Location = new System.Drawing.Point(46, 12);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(69, 20);
            this.TypeComboBox.TabIndex = 1;
            // 
            // keywordTextBox
            // 
            this.keywordTextBox.Location = new System.Drawing.Point(179, 10);
            this.keywordTextBox.Name = "keywordTextBox";
            this.keywordTextBox.Size = new System.Drawing.Size(81, 22);
            this.keywordTextBox.TabIndex = 2;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(463, 15);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // readFileButton
            // 
            this.readFileButton.Location = new System.Drawing.Point(555, 15);
            this.readFileButton.Name = "readFileButton";
            this.readFileButton.Size = new System.Drawing.Size(75, 23);
            this.readFileButton.TabIndex = 3;
            this.readFileButton.Text = "Read File";
            this.readFileButton.UseVisualStyleBackColor = true;
            this.readFileButton.Click += new System.EventHandler(this.readFileButton_Click);
            // 
            // dataFilterCheckBox
            // 
            this.dataFilterCheckBox.AutoSize = true;
            this.dataFilterCheckBox.Location = new System.Drawing.Point(12, 29);
            this.dataFilterCheckBox.Name = "dataFilterCheckBox";
            this.dataFilterCheckBox.Size = new System.Drawing.Size(72, 16);
            this.dataFilterCheckBox.TabIndex = 4;
            this.dataFilterCheckBox.Text = "Data Filter";
            this.dataFilterCheckBox.UseVisualStyleBackColor = true;
            this.dataFilterCheckBox.CheckedChanged += new System.EventHandler(this.dataFilterCheckBox_CheckedChanged);
            // 
            // LogDataGridView
            // 
            this.LogDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogDataGridView.Location = new System.Drawing.Point(0, 0);
            this.LogDataGridView.Name = "LogDataGridView";
            this.LogDataGridView.RowTemplate.Height = 24;
            this.LogDataGridView.Size = new System.Drawing.Size(701, 308);
            this.LogDataGridView.TabIndex = 5;
            // 
            // beginDateTimePicker
            // 
            this.beginDateTimePicker.Location = new System.Drawing.Point(50, 8);
            this.beginDateTimePicker.Name = "beginDateTimePicker";
            this.beginDateTimePicker.Size = new System.Drawing.Size(124, 22);
            this.beginDateTimePicker.TabIndex = 6;
            this.beginDateTimePicker.Value = new System.DateTime(2023, 9, 4, 0, 0, 0, 0);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(210, 6);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(121, 22);
            this.endDateTimePicker.TabIndex = 6;
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(555, 80);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(75, 23);
            this.saveFileButton.TabIndex = 3;
            this.saveFileButton.Text = "Save File";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // dataFilterTimeCheckBox
            // 
            this.dataFilterTimeCheckBox.AutoSize = true;
            this.dataFilterTimeCheckBox.Location = new System.Drawing.Point(12, 94);
            this.dataFilterTimeCheckBox.Name = "dataFilterTimeCheckBox";
            this.dataFilterTimeCheckBox.Size = new System.Drawing.Size(107, 16);
            this.dataFilterTimeCheckBox.TabIndex = 4;
            this.dataFilterTimeCheckBox.Text = "Data Filter (Time)";
            this.dataFilterTimeCheckBox.UseVisualStyleBackColor = true;
            this.dataFilterTimeCheckBox.CheckedChanged += new System.EventHandler(this.dataFilterTimeCheckBox_CheckedChanged);
            // 
            // dataFilterPanel
            // 
            this.dataFilterPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataFilterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataFilterPanel.Controls.Add(this.label1);
            this.dataFilterPanel.Controls.Add(this.TypeLabel);
            this.dataFilterPanel.Controls.Add(this.TypeComboBox);
            this.dataFilterPanel.Controls.Add(this.keywordTextBox);
            this.dataFilterPanel.Enabled = false;
            this.dataFilterPanel.Location = new System.Drawing.Point(125, 15);
            this.dataFilterPanel.Name = "dataFilterPanel";
            this.dataFilterPanel.Size = new System.Drawing.Size(276, 41);
            this.dataFilterPanel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Keyword:";
            // 
            // dataFilterTimePanel
            // 
            this.dataFilterTimePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataFilterTimePanel.Controls.Add(this.endLabel);
            this.dataFilterTimePanel.Controls.Add(this.beginDateTimePicker);
            this.dataFilterTimePanel.Controls.Add(this.Startlabel);
            this.dataFilterTimePanel.Controls.Add(this.endDateTimePicker);
            this.dataFilterTimePanel.Enabled = false;
            this.dataFilterTimePanel.Location = new System.Drawing.Point(125, 80);
            this.dataFilterTimePanel.Name = "dataFilterTimePanel";
            this.dataFilterTimePanel.Size = new System.Drawing.Size(349, 41);
            this.dataFilterTimePanel.TabIndex = 8;
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Location = new System.Drawing.Point(180, 13);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(30, 12);
            this.endLabel.TabIndex = 0;
            this.endLabel.Text = "End: ";
            // 
            // Startlabel
            // 
            this.Startlabel.AutoSize = true;
            this.Startlabel.Location = new System.Drawing.Point(12, 12);
            this.Startlabel.Name = "Startlabel";
            this.Startlabel.Size = new System.Drawing.Size(32, 12);
            this.Startlabel.TabIndex = 0;
            this.Startlabel.Text = "Start: ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataFilterPanel);
            this.splitContainer1.Panel1.Controls.Add(this.dataFilterTimePanel);
            this.splitContainer1.Panel1.Controls.Add(this.confirmButton);
            this.splitContainer1.Panel1.Controls.Add(this.readFileButton);
            this.splitContainer1.Panel1.Controls.Add(this.dataFilterCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.dataFilterTimeCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.saveFileButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LogDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(701, 450);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form";
            ((System.ComponentModel.ISupportInitialize)(this.LogDataGridView)).EndInit();
            this.dataFilterPanel.ResumeLayout(false);
            this.dataFilterPanel.PerformLayout();
            this.dataFilterTimePanel.ResumeLayout(false);
            this.dataFilterTimePanel.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.TextBox keywordTextBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button readFileButton;
        private System.Windows.Forms.CheckBox dataFilterCheckBox;
        private System.Windows.Forms.DataGridView LogDataGridView;
        private System.Windows.Forms.DateTimePicker beginDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.CheckBox dataFilterTimeCheckBox;
        private System.Windows.Forms.Panel dataFilterPanel;
        private System.Windows.Forms.Panel dataFilterTimePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Label Startlabel;
    }
}

