using CSVFileProcessor_ConsoleApp.Services;

namespace CSVFileProcessor_ConsoleApp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();

        }
    }
}
