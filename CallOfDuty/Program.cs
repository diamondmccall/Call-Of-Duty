using System;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using Newtonsoft.Json;
using static CallOfDuty.CODinfo;

namespace CallOfDuty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new RestClient("https://call-of-duty-modern-warfare.p.rapidapi.com/warzone/Amartin743/psn");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", "f975150e0fmsh1e0a3b55e990929p1d7524jsn28e695554593");
            request.AddHeader("X-RapidAPI-Host", "call-of-duty-modern-warfare.p.rapidapi.com");
            var response = client.Execute(request).Content;



            var root = JsonConvert.DeserializeObject<Root>(response);

            Console.WriteLine($"Player Kills:{root.data.lifetime.mode.gun.properties.kills}");
            Console.WriteLine($"Player Deaths:{root.data.lifetime.mode.gun.properties.deaths}");
        }


    }
}