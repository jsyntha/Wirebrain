using System.Text.Json;

namespace Wirebrain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MemoryLogic logger = new MemoryLogic();

            Console.WriteLine("Wirebrain TM");
            Console.WriteLine("What can I do for you today?");
            Console.WriteLine("Type 'exit' to quit the program.");
            Console.WriteLine();

            Dictionary<string, Func<string>> dict = new Dictionary<string, Func<string>>();
            dict.Add("hi", () => "Hi, how are you doing today?");
            //dict.Add("weather", "The weather is rainy today.");
            dict.Add("weather", () => GetWeather());

            while (true)
            {
                Console.Write("> ");
                string? input = Console.ReadLine();
                logger.LogMessage("memory.csv", input);

                if (input == "exit")
                    break;

                if (dict.ContainsKey(input))
                {
                    string response = dict[input]();
                    Console.WriteLine(response);
                    logger.LogMessage("memory.csv", response);
                }
                else
                {
                    string response = "I don't understand. Press any key to continue.";
                    Console.WriteLine(response);
                    logger.LogMessage("memory.csv", response);
                    Console.ReadKey(true);
                    Console.WriteLine();
                }
            }
            string GetWeather()
            {
                string url = "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current=temperature_2m";

                HttpClient client = new HttpClient();
                HttpResponseMessage resposne = client.GetAsync(url).Result;
                string json = resposne.Content.ReadAsStringAsync().Result;

                JsonDocument doc = JsonDocument.Parse(json);
                JsonElement root = doc.RootElement;
                JsonElement current = root.GetProperty("current");
                double temp = current.GetProperty("temperature_2m").GetDouble();

                return "Current temperature: " + temp + "°C";
                return "Test";

            }
        }
    }
}
