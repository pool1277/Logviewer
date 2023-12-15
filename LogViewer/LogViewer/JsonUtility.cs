using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
                string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
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
                            searchResult = jToken.ToString();
                            return;
                        }

                        //Find in subtree
                        foreach (var jToken in jnode)
                        {
                            JsonSearch(jToken.Value.ToString(), searchPattern, ref searchResult);
                            if (searchResult != "")
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
                            JsonSearch(jToken.ToString(), searchPattern, ref searchResult);
                            if (searchResult != "")
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


        public static bool JsonPathSearch(string jsonText, string searchPattern, ref string searchResult)
        {
            try
            {
                if (!string.IsNullOrEmpty(jsonText))
                {
                    JToken node = JToken.Parse(jsonText);
                    string jsonPath = @"$.." + searchPattern; //JsonPath expression 
                    List<JToken> results = node.SelectTokens(jsonPath).ToList();

                    for (int i =0; i < results.Count; i++)
                    {
                        searchResult += (results[i].ToString() + "\n");
                    }
                }
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
