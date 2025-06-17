using System.Text.Json;

namespace Wirebrain
{
    internal class Program
    {
        static InputHandler InputHandler = new InputHandler();
        static void Main(string[] args)
        {
            MemoryLogic logger = new MemoryLogic();

            Console.WriteLine("Wirebrain TM");
            Console.WriteLine("What can I do for you today?");
            Console.WriteLine("Type 'exit' to quit the program.");
            Console.WriteLine();

            while (true)
            {
                Console.Write("> ");
                string? input = Console.ReadLine();
                logger.LogMessage("memory.csv", input);

                if (input == "exit")
                    break;

                LogAnalyser analyser = new LogAnalyser();
                analyser.Analyse();

                if (InputHandler.Dict.ContainsKey(input))
                {
                    string response = InputHandler.Dict[input]();
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
        }
    }
}
