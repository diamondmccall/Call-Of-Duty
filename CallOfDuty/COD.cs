using System;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace CallOfDuty
{
    public class COD
    {
        public static RestResponse CallofDuty()
        {
            var client = new RestClient("https://call-of-duty-modern-warfare.p.rapidapi.com/warzone/Amartin743/psn");
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", "f975150e0fmsh1e0a3b55e990929p1d7524jsn28e695554593");
            request.AddHeader("X-RapidAPI-Host", "call-of-duty-modern-warfare.p.rapidapi.com");
            var response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response;
        }

        public static DutyCode BRCodParse(RestResponse response)
        {
            var broOj = JObject.Parse(response.Content).GetValue("br");

            var gamerWins = broOj["wins"];

            var gamer = new DutyCode()
            {
                wins = (double)gamerWins
            };
            return gamer;
        }
    }
}