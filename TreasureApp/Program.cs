using Autofac;
using Serilog;
using TreasureHunt;

namespace TreasureApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Adding logger
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("logs.log")
            .CreateLogger();

            // Resolving dependencies and initilize application loop.
            var appContainer = IoCBuilder.Build();
            using (var application = appContainer.BeginLifetimeScope())
            {
                application.Resolve<GameUI>();
            }
        }
    }
}
