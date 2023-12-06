using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace LogViewer
{
    public static class JsonUtility
    {
        public static bool WriteObject<T>(T obj, string path)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj,Formatting.Indented);
                File.WriteAllText(path, json);

                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public static bool ReadObject<T>(string path, ref T obj)
        {
            try
            {
                //Check path exist
                if (!File.Exists(path))
                    return false;

                //Read file
                string json = File.ReadAllText(path);
                obj = JsonConvert.DeserializeObject<T>(json);

                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


    }

}
