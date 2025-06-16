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
            // check for csv
            filePath = "memory.csv";
            if(!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            // log it (timestamp + message)
            MemoryLog log = new MemoryLog();
            log.Message = message;
            log.Timestamp = DateTime.Now;

            StreamWriter writer = new StreamWriter(filePath, append: true);
            CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteRecord(log);
            csv.NextRecord();

            writer.Close();
        }
        // Rough idea
        // We will constantly log the chat - logs.csv?
        // Log ever user input (Console.Readline() -> csv).
        // Log every output (Console.Writeline() -> csv).
        // We will filter by the most common used terms (Total of previous sessions)
        // We will then analyse a response based on this


    }
}
