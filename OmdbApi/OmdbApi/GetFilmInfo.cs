using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OmdbApi
{
    class GetFilmInfo
    {
        public void GetTitles()
        {
            int i = 0;
            string path = @".\FilmsData.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Getdata(line);
                        i++;
                        Console.WriteLine(i+ new string('-',70));
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("Data not found to load");
            }
        }


        public  async void Getdata(string filmName)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"http://www.omdbapi.com/?t={filmName}&apikey=b2575208").Result;
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        string s = await response.Content.ReadAsStringAsync();
                        JObject ParsedData = JObject.Parse(s);
                        string title = ParsedData["Title"].ToString();
                        string genre = (string)ParsedData["Genre"];
                        string actors = (string)ParsedData["Actors"];
                        //Console.WriteLine(s);all info
                        Console.WriteLine(title);
                        Console.WriteLine(genre);
                        Console.WriteLine(actors);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("errorrrrrrrrrrrrrrr");
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
           

        }
    }
}
