using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LogViewer
{
    public class LogItem
    {
        public string Level { get;  set; }
        public string Category { get;  set; }
        public DateTime Time { get;  set; }
        public string Tags { get;  set; }
        public string Message { get;  set; }


        public LogItem()
        {

        }

        public LogItem (string [] separerateLog)
        {
            Level = separerateLog[(int)Logtype.Level];
            Category = separerateLog[(int)Logtype.Category];
            Time = Convert.ToDateTime(separerateLog[(int)Logtype.Time]);
            //Tags = separerateLog[3];
            Message = separerateLog[(int)Logtype.Message];
        }

        public string[] ToArray ()
        {
            string[] logTextArray = new string[4];
            logTextArray[(int)Logtype.Level] = Level;
            logTextArray[(int)Logtype.Category] = Category;
            logTextArray[(int)Logtype.Time] = Time.ToString();
            logTextArray[(int)Logtype.Message] = Message;

            return logTextArray;
        }

    }

    public class Log
    {
        public List<LogItem> Items { get; private set; }


        public Log()
        {

        }

        public Log(List<LogItem> items)
        {
            Items = items.ToList();
        }

        public bool LogReader(string path)
        {

            if (!File.Exists(path))
                return false;

            //read file 
            Items = readLogFile(path);


            return true;
        }

        public bool LogWriter(string path)
        {
            return WriteLogFile(path, Items);
        }

        private List<LogItem> readLogFile(string path)
        {
            string format = Path.GetExtension(path).ToLower();
            List<LogItem> logList = new List<LogItem>();

            switch (format)
            {
                case ".json":

                    JsonUtility.ReadObject(path, ref logList);
                    //Serilizer.Json.ReadObject(path, ref logList);
                    break;

                default:

                    StreamReader logstreamReader = File.OpenText(path);
                    while (!logstreamReader.EndOfStream)
                    {
                        string lineMessage = logstreamReader.ReadLine();
                        string[] separerateLog = lineMessage.Split(new char[] { ',' }, 4, StringSplitOptions.None);

                        LogItem Item = new LogItem(separerateLog);

                        logList.Add(Item);
                    }

                    logstreamReader.Close();
                    logstreamReader.Dispose();
                    break;
            }

            return logList;
        }

        private bool WriteLogFile(string path, List<LogItem> logItems)
        {
            string format = Path.GetExtension(path).ToLower();
            bool result = false;
            switch (format)
            {
                case ".json":

                    result = JsonUtility.WriteObject(logItems, path);
                    //Serilizer.Json.WriteObject(logItems, path);

                    break;

                default:
                    StreamWriter streamWriter = new StreamWriter(path);


                    for (int i = 0; i < logItems.Count; i++)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(logItems[i].Level);
                        sb.Append(",");
                        sb.Append(logItems[i].Category);
                        sb.Append(",");
                        sb.Append(logItems[i].Time);
                        sb.Append(",");
                        sb.Append(logItems[i].Message);

                        streamWriter.WriteLine(sb.ToString());
                    }

                    streamWriter.Close();
                    streamWriter.Dispose();
                    result = true;
                    break;
            }
            return result;
        }
    }

    public　enum Logtype
    {
        Level = 0,
        Category = 1,
        Time = 2,
        Message = 3,
    }




}


