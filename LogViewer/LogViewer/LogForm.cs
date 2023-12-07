using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


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

        private async void readFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = @"C:\Users\chshih\Desktop\ks新人訓練\LogViewer\cx_vis.log";
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                currentLog = new Log();

                //read file(avoid lock UI using a new task when load file)
                bool result = await Task.Run(() => currentLog.LogReader(path));

                if (!result)
                {
                    MessageBox.Show("LogRead Eror");
                    return;
                }

                DisplayLogDataGridView(currentLog.Items);
                FilterLogView = currentLog.Items;
            }
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

        private async void saveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "純文字檔(*.txt) | *.txt | .csv(*.csv) | *.csv| .json(*.json) | *.json";
            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                Log filterLog = new Log(FilterLogView);

                //Save file(avoid lock UI using a new task when save file)
                bool result = await Task.Run(() => currentLog.LogWriter(path));

                if (!result)
                {
                    MessageBox.Show("LogSave Eror");
                    return;
                }

                MessageBox.Show("Save to\n "+ saveFileDialog.FileName);
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
            DataGridView dgv = sender as DataGridView;
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

        private void LogDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            string columnBindingName = dgv.Columns[e.ColumnIndex].DataPropertyName;

            switch (dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection)
            {
                case System.Windows.Forms.SortOrder.None:
                case System.Windows.Forms.SortOrder.Ascending:
                    FilterLogViewSort(columnBindingName, System.Windows.Forms.SortOrder.Descending);
                    LogDataGridView.DataSource = FilterLogView;
                    //After asign DataSource , SortGlyphDirection will be SortOrder.None
                    dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;
                    break;

                case System.Windows.Forms.SortOrder.Descending:
                    FilterLogViewSort(columnBindingName, System.Windows.Forms.SortOrder.Ascending);
                    LogDataGridView.DataSource = FilterLogView;
                    //After asign DataSource , SortGlyphDirection will be SortOrder.None
                    dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;

                    break;
            }
        }

        private void FilterLogViewSort(string columnBindingName, System.Windows.Forms.SortOrder sortOrder)
        {
            if (sortOrder == System.Windows.Forms.SortOrder.Descending)
            {
                switch (columnBindingName)
                {
                    case "Level":
                        FilterLogView = FilterLogView.OrderByDescending(item => item.Level?.First())
                                                     .ToList();
                        break;

                    case "Category":
                        FilterLogView = FilterLogView.OrderByDescending(item => item.Category?.First())
                                                     .ToList();
                        break;

                    case "Message":
                        FilterLogView = FilterLogView.OrderByDescending(item => item.Message?.First())
                                                     .ToList();
                        break;

                    case "Time":
                        FilterLogView = FilterLogView.OrderByDescending(item => item.Time)
                                                     .ToList();
                        break;

                    case "Tags":
                        FilterLogView = FilterLogView.OrderByDescending(item => item.Tags?.First())
                                                     .ToList();
                        break;
                }
            }

            else if (sortOrder == System.Windows.Forms.SortOrder.Ascending)
            {
                switch (columnBindingName)
                {
                    case "Level":
                        FilterLogView = FilterLogView.OrderBy(item => item.Level?.First())
                                                     .ToList();
                        break;

                    case "Category":
                        FilterLogView = FilterLogView.OrderBy(item => item.Category?.First())
                                                     .ToList();
                        break;

                    case "Message":
                        FilterLogView = FilterLogView.OrderBy(item => item.Message?.First())
                                                     .ToList();
                        break;

                    case "Time":
                        FilterLogView = FilterLogView.OrderBy(item => item?.Time)
                                                     .ToList();
                        break;

                    case "Tags":
                        FilterLogView = FilterLogView.OrderBy(item => item.Tags?.First())
                                                     .ToList();
                        break;
                }
            }
        }

        private void filterLog(Log original, Logtype filterType, string keyword)
        {
            FilterLogView = original.Items.Where(item => item.ToArray()[(int)filterType].Contains(keyword))
                                                        .ToList();
            DisplayLogDataGridView(FilterLogView);
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

            // Make sorting work when click column header
            foreach (DataGridViewColumn column in LogDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }

            LogDataGridView.ResumeLayout();
            LogDataGridView.Refresh();
        }
    }
    



}
