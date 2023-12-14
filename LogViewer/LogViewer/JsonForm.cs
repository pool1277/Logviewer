using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace LogViewer
{
    public partial class JsonForm : Form
    {
        private string indentJsonText { get; set; }

        public JsonForm(string jsonText)
        {
            InitializeComponent();

            //Show the jsontext (indent-format)
            var Jsonobject = new object();
            Jsonobject = JsonConvert.DeserializeObject(jsonText);
            // Handle some case need two times deserialize
            if (Jsonobject.GetType().Name == "String")
            {
                Jsonobject = JsonConvert.DeserializeObject((string)Jsonobject);
            }
            indentJsonText = JsonConvert.SerializeObject(Jsonobject, Formatting.Indented);
            contentLabel.Text = indentJsonText;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (nameTextBox.Text != "")
                {
                    string resultText = "";
                    JsonUtility.JsonSearch(indentJsonText, nameTextBox.Text, ref resultText);
                    contentLabel.Text = resultText;
                }
                else
                {
                    contentLabel.Text = indentJsonText;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("not found!");
                contentLabel.Text = indentJsonText; 
            }

        }
    }
}
