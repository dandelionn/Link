using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomWindow
{
    public class DataManager
    {
        string _jsonFilePath = @"C:\Users\Paul\Documents\Visual Studio 2017\Projects\CustomWindow\CustomWindow\bin\Debug\link.json";
    
        public DataManager()
        {

        }

        public string ReadFile(string filePath)
        {
           return File.ReadAllText(filePath);
        }

        public void SaveToFile(string filePath, string data)
        {
            File.WriteAllText(filePath, data);
        }

        public void Serialize(List<LinkData> items)
        {
            string output = JsonConvert.SerializeObject(items);
            SaveToFile(_jsonFilePath, output);
        }

        public List<LinkData> Deserialize()
        {
            return JsonConvert.DeserializeObject<List<LinkData>>(ReadFile(_jsonFilePath));
        }
    }
}
