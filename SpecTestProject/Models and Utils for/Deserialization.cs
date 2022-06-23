using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace SpecTestProject.Models_and_Utils_for
{
    public static class Deserialization
    {
        public static T GetModelFromFile<T>(string path) 
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }
        public static List<T> GetModelListFromFile<T>(string path)
        {
            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
        }
        public static void WriteModelToFile<T>(T model, string path)
        {
            using (System.IO.StreamWriter writer = new StreamWriter(path, false))
            {
                writer.Write(JsonConvert.SerializeObject(model));
                writer.Close();    
            }
        }
    }
}
