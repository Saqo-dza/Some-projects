using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OmdbApi
{
    class Program
    {
        static List<OmDB> moveData = new List<OmDB>();
        static  void Main()
        {
           
            Graph<string> actorsGraph = new Graph<string>();
            GetTitles();
            AddActorsAndTitles(actorsGraph);
            MakeActorsConnection(actorsGraph);
            Console.WriteLine(actorsGraph.IsConectionExist("Joseph Cotten","Ruth Warrick")); //true
            Console.WriteLine(actorsGraph.IsConectionExist("Kim Novak","Ruth Warrick"));//false
            //Console.WriteLine(actorsGraph.IsConectionExist("Kim Novak", "Tom Helmore"));//true
            //Console.WriteLine(actorsGraph.IsConectionExist("Joseph Cotten", "Tom Helmore"));//false
            foreach (var item in BFS(actorsGraph, actorsGraph.Find("Tom Helmore")))
            {
                Console.WriteLine(item);
            }
           
        }
        static List<T> BFS<T>(Graph<T> graph, GraphNode<T> start)
        {
            Console.WriteLine("Search type is BFS");
            List<T> result = new List<T>();
            Queue<GraphNode<T>> queue = new Queue<GraphNode<T>>();
            start.visited = true;
            queue.Enqueue(start);
            GraphNode<T> n;
            while (queue.Count != 0)
            {
                n = queue.Dequeue();
                result.Add(n.Value);
                foreach (var node in n.Neighbors)
                {
                    if (!node.visited)
                    {
                        node.visited = true;
                        queue.Enqueue(node);
                    }
                }
            }
            return result;
        }
        public static void GetTitles()
        {
            string path = @".\FilmsData.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Getdata(line);
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("Data not found to load");
            }
        }

        public static async void Getdata(string filmName)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"http://www.omdbapi.com/?t={filmName}&apikey=b2575208").Result;
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        string s = await response.Content.ReadAsStringAsync();
                        moveData.Add(JsonConvert.DeserializeObject<OmDB>(s));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Response read error: " + e);
                    }
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }
        public static void AddActorsAndTitles(Graph<string> actorsGraph)
        {
            foreach (var item in moveData)
            {
                string[] s = { ", " };
                string[] tmpActorArr = item.Actors.Split(s, StringSplitOptions.None);
                foreach (var actorName in tmpActorArr)
                {
                    if (actorsGraph.Find(actorName) == null)
                    {
                        actorsGraph.AddNode(actorName);
                        actorsGraph.AddMovieForActor(actorName, item.Title);
                    }
                    else
                    {
                        actorsGraph.AddMovieForActor(actorName, item.Title);
                    }
                }
            }
        }
        public static void MakeActorsConnection(Graph<string> actorsGraph)
        {
            foreach (var node1Actor in actorsGraph.Nodes)
            {
                foreach (var node2Actor in actorsGraph.Nodes)
                {
                    if (node1Actor != node2Actor)
                    {
                        foreach (var node1Movie in node1Actor.playedMovieList)
                        {
                            if (node2Actor.playedMovieList.Contains(node1Movie))
                            {
                                actorsGraph.AddEdge(node1Actor.Value, node2Actor.Value);
                            }
                        }
                    }
                }
            }
        }


    }
}
