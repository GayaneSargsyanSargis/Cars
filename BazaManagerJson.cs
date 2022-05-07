using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class BazaManagerJson : IBazaSaverReaderCloser
    {
        public void CleanBazaFile(string path)
        {
            File.WriteAllText(path, string.Empty);
        }

        public void ReadBaza(string path)
        {
            if (File.Exists(path))
            {
                string JsonObj = File.ReadAllText(path);
                Console.WriteLine(JsonObj);
                if (JsonObj.Length>0)
                {
                    JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }; 
                    if (path == @"D:\C#HW\Cars\MarketBaza.txt")
                    {
                        Market.DicCars = JsonConvert.DeserializeObject<KeyValuePair<int, Car>[]>(JsonObj, jsonSerializerSettings).ToDictionary(kv => kv.Key, kv => kv.Value);
                    }
                    else
                    {
                        Garaj.DicCars = JsonConvert.DeserializeObject<KeyValuePair<int, Car>[]>(JsonObj, jsonSerializerSettings).ToDictionary(kv => kv.Key, kv => kv.Value);
                    }
                }                
            }

        }

        public void SaveBaza(string @path, Dictionary<int, Car> DicCars)
        {
            if (DicCars.Count > 0)
            {
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string output = JsonConvert.SerializeObject(DicCars.ToArray(), Formatting.Indented, jsonSerializerSettings);
                Console.WriteLine(output);
                File.WriteAllText(@path, output);
                
            }
        }
      
    }
}
