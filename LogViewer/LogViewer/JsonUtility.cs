using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


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

        public static void JsonSearch(string jsonText, string searchPattern, ref string searchResult)
        {
            try
            {
                if (!string.IsNullOrEmpty(jsonText))
                {
                    JToken node = JContainer.Parse(jsonText);

                    //Find in this node (Object)
                    if (node.Type == JTokenType.Object)
                    {
                        JObject jnode = (JObject)node;
                        if (jnode.ContainsKey(searchPattern))
                        {
                            JToken jToken = jnode.GetValue(searchPattern);
                            searchPattern = jToken.ToString();
                            return;
                        }

                        //Find in subtree
                        foreach (var jToken in jnode)
                        {
                            JsonSearch(jToken.Value.ToString(), searchPattern, ref searchPattern);
                            if (searchPattern != "")
                                return;
                        }
                    }

                    //Find in this node (array)
                    else if (node.Type == JTokenType.Array)
                    {
                        JArray jnode = (JArray)node;
                        //Find in subtree
                        foreach (var jToken in jnode)
                        {
                            JsonSearch(jToken.ToString(), searchPattern, ref searchPattern);
                            if (searchPattern != "")
                                return;
                        }
                    }
                }
                return;
            }

            catch (Exception ex)
            {
                return; 
            }
        }


    }
}
