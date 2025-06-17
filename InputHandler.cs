using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirebrain
{
    class InputHandler
    {
        static Weather weather = new Weather();
        //public Dictionary<string, Func<string>> dict = new Dictionary<string, Func<string>>();
        public Dictionary<string, Func<string>> Dict { get; } = new Dictionary<string, Func<string>>(StringComparer.OrdinalIgnoreCase);

        public InputHandler() {
            Dict.Add("hi", () => "Hi, how are you doing today?");
            Dict.Add("weather", () => weather.GetWeather());
        }
    }
}
