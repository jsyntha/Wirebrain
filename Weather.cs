using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Wirebrain
{

    public class Weather
    {
        HttpClient client = new HttpClient();
        public string GetWeather()
        {
            string url = "https://api.open-meteo.com/v1/forecast?latitude=53.33&longitude=-6.25&current=temperature_2m";
            HttpResponseMessage resposne = client.GetAsync(url).Result;
            string json = resposne.Content.ReadAsStringAsync().Result;

            JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;
            JsonElement current = root.GetProperty("current");
            double temp = current.GetProperty("temperature_2m").GetDouble();
            // Come back to and replacing with reverse geocoding
            string country = "Ireland";

            return "Current temperature: " + temp + "°C" + "\nCountry: " + country;
        }
    }
}
