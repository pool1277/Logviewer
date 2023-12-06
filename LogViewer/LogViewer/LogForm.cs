using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace LogViewer
{
    public partial class LogForm : Form
    {
        private Log currentLog;
        private List<LogItem> FilterLogView;


        public LogForm()
        {
            InitializeComponent();
        }

        private void readFileButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = @"C:\Users\chshih\Desktop\ks新人訓練\LogViewer\cx_vis.log";
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                currentLog = new Log();
                if (!currentLog.LogReader(path))
                {
                    MessageBox.Show("LogRead Eror");
                }

                DisplayLogDataGridView(currentLog.Items);
                FilterLogView = currentLog.Items;
            }

        }



        private void filterLog(Log original, Logtype filterType, string keyword)
        {

            FilterLogView = original.Items.Where(item => item.ToArray()[(int)filterType].Contains(keyword))
                                                        .ToList();

            DisplayLogDataGridView(FilterLogView);
            LogDataGridView.Refresh();


        }

        private void filterLog(Log original, DateTime beginTime, DateTime endTime)
        {

           FilterLogView = original.Items.Where(item => item.Time >= beginTime && item.Time <= endTime)
                                                        .ToList();

            DisplayLogDataGridView(FilterLogView);

        }

        private void filterLog(Log original, Logtype filterType, string keyword, DateTime beginTime, DateTime endTime)
        {
        

            FilterLogView = original.Items.Where(item => item.Time >= beginTime && item.Time <= endTime)
                                                        .Where(item => item.ToArray()[(int)filterType].Contains(keyword))
                                                        .ToList();

            DisplayLogDataGridView(FilterLogView);
        }

        void DisplayLogDataGridView(List<LogItem> items)
        {
            LogDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            LogDataGridView.SuspendLayout();
            LogDataGridView.DataSource = items;
            LogDataGridView.ResumeLayout();
            LogDataGridView.Refresh();
        }


        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (dataFilterCheckBox.Checked && dataFilterTimeCheckBox.Checked)
            {
                filterLog(currentLog, (Logtype)(TypeComboBox.SelectedIndex), keywordTextBox.Text, beginDateTimePicker.Value, endDateTimePicker.Value);
            }
            else if (dataFilterTimeCheckBox.Checked)
            {
                filterLog(currentLog, beginDateTimePicker.Value, endDateTimePicker.Value);
            }

            else if (dataFilterCheckBox.Checked)
            {
                filterLog(currentLog, (Logtype)(TypeComboBox.SelectedIndex), keywordTextBox.Text);
            }
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "純文字檔(*.txt) | *.txt | .csv(*.csv) | *.csv| .json(*.json) | *.json";
            DialogResult dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                Log filterLog = new Log(FilterLogView);
                filterLog.LogWriter(path);
            }
            saveFileDialog.Dispose();
        }

        private void dataFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dataFilterPanel.Enabled = dataFilterCheckBox.Checked;
        }

        private void dataFilterTimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dataFilterTimePanel.Enabled = dataFilterTimeCheckBox.Enabled;
        }



        private void LogDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;

            // Check if the text contain "#Json", show up the JsonForm.
            DataGridView dgv = (DataGridView)sender;
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            string cellText = row.Cells[e.ColumnIndex].Value?.ToString();

            string[] seperator = new string[]
            {
                "#json"
            };

            if (cellText != null && cellText.Contains("#json"))
            {
                //MessageBox.Show("Contain Message!");
                string jsonText = cellText.Split(seperator, StringSplitOptions.None).Last();
                JsonForm jsonForm = new JsonForm(jsonText);

                jsonForm.Show();
            }
        }
    }



}
