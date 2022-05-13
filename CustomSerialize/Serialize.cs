using Newtonsoft.Json;
using System.IO;

namespace CustomSerializeTools
{
    public static class CustomSerialize
    {
        static JsonSerializerSettings jsonSettings = 
            new JsonSerializerSettings { DateFormatString = "yyyy/MM/dd HH:mm:ss" };

        public static void WriteToFile(string fullPath, object obj)
        {
            string jsonString = JsonConvert.SerializeObject(obj, jsonSettings);
            File.WriteAllText(fullPath, jsonString);
        }

        public static T ReadFromFile<T>(string fullPath)
        {
            string jsonString = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<T>(jsonString, jsonSettings);
        }
    }
}
