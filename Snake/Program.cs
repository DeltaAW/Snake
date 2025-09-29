using Snake;

Settings setting = new();

string fliedSize = "klein";
string complexity = "einfach";

while (true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("1 - Spielen \n2 - Einstellungen \n3 - Beenden\n");
    Console.ResetColor();

    if (int.TryParse(Console.ReadLine(), out int number) && number < 4)
    {
        switch (number)
        {
            case 1:
                Game games = new(ref fliedSize, ref complexity);
                games.Management();
                break;
            case 2:
                setting.SettingsMenu(ref fliedSize, ref complexity);
                break;
            case 3:
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ungültiger Befehl!\n\nDrücken Sie eine beliebige Taste, um fortzufahren\n");
                Console.ReadKey();
                Console.ResetColor();
                break;
        }
    }
    else
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Bitte geben Sie eine Zahl ein!");
        Console.ReadKey();
        Console.ResetColor();
    }
}
