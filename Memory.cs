using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Wirebrain
{
    class MemoryLog
    {
        public string ?Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
    class MemoryLogic
    {
        public void LogMessage(string filePath, string message)
        {
            filePath = "memory.csv";

            using (var writer = new StreamWriter(filePath, append: true))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                if (new FileInfo(filePath).Length == 0)
                {
                    csv.WriteHeader<MemoryLog>();
                    csv.NextRecord();
                }

                MemoryLog log = new MemoryLog
                {
                    Message = message,
                    Timestamp = DateTime.Now
                };

                csv.WriteRecord(log);
                csv.NextRecord();
            }
        }

        // Rough idea
        // We will constantly log the chat - logs.csv?
        // Log ever user input (Console.Readline() -> csv).
        // Log every output (Console.Writeline() -> csv).
        // We will filter by the most common used terms (Total of previous sessions)
        // We will then analyse a response based on this


    }
}
