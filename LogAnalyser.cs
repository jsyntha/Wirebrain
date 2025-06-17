using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Drawing;

namespace Wirebrain
{
    class LogAnalyser
    {
        private readonly InputHandler inputHandler = new InputHandler();
        public void Analyse()
        {
            //InputHandler inputHandler = new InputHandler();
            using (var reader = new StreamReader("memory.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                List<MemoryLog> logs = csv.GetRecords<MemoryLog>().ToList();
                char[] delimiters = new char[] { ' ', '\r', '\n' };
                foreach (MemoryLog log in logs)
                {
                    string message = log.Message;
                    string[] words = message.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in words)
                    {
                        if (inputHandler.Dict.ContainsKey(word))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"DEBUG: Match found: {word}");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }
        }
    }
}
