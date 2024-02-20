using Microsoft.Extensions.Configuration;

namespace IS_1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
             IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            ApplicationConfiguration.Initialize();
            Application.Run(new Main(config));
        }
    }
}