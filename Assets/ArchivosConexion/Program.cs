using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

//namespace HttpClientStatus;

namespace ReadATextFile
{
    class Program
    {
        // Default folder    
        static readonly string rootFolder = @"C:";
        //static string ingles = "en_us";
        static string ingles = "es_co";
        //Default file. MAKE SURE TO CHANGE THIS LOCATION AND FILE PATH TO YOUR FILE   
        static readonly string textFile = @"C:\mission_" + ingles + ".txt";


        static async Task Main(string[] args)
        {

            var culture = System.Globalization.CultureInfo.CurrentCulture;
            Console.WriteLine(culture);
            string languaje = culture.ToString().ToLower().Replace("-", "_");
            Console.WriteLine(languaje);
            Dictionary<string, string> myData = new Dictionary<string, string>();
            List<string> missions = new List<string>();
            if (File.Exists(textFile))
            {
                // Read a text file line by line.  
                string[] lines = File.ReadAllLines(textFile);

                foreach (string line in lines)
                {
                    //Console.WriteLine(line);
                    int p = line.IndexOf("=");
                    string key = line.Substring(0, p);
                    string value = line.Substring(p + 1);
                    key = key.Trim();
                    value = value.Trim();
                    //Console.WriteLine(p);
                    //Console.WriteLine(key);
                    //Console.WriteLine(value);
                    myData.Add(key, value);
                    missions.Add(value);

                }
                string[] terms = missions.ToArray();
                Console.WriteLine(terms[1]);
                Console.WriteLine(myData["mision1"]);

                using var client = new HttpClient();

                var puntaje = new { 
                    usuario = 2,
                    score = 20.2
                    };

                var json = JsonConvert.SerializeObject(puntaje);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = "http://localhost:5000/puntaje";
                //using var client = new HttpClient();

                var response = await client.PostAsync(url, data);

                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);

                //record Person(string Name, string Occupation);

                var resulto = await client.GetStringAsync("http://localhost:5000/list");
                Console.WriteLine(resulto);
            }
        }
    }
}
