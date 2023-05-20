namespace FindPairForm;

using FindPairLibrary;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        var game = new Game(2);
        ApplicationConfiguration.Initialize();
        Application.Run(new GameForm(int.Parse(args[0])));

    }
}