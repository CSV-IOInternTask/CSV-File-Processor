using CSVFileProcessor_ConsoleApp.Core;
using CSVFileProcessor_ConsoleApp.Core.Contracts;

namespace CSVFileProcessor_ConsoleApp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
