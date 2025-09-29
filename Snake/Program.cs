using Snake;

Settings setting = new();

string fliedSize = "small";
string complexity = "easy";

while (true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("1 - Играть \n2 - Настройи \n3 - Выход\n");
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
                Console.WriteLine("Вы введи не верную команду!!!\n\nНажмите любую клавишу, чтобы продолжить\n");
                Console.ReadKey();
                Console.ResetColor();
                break;
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Введите число!");
        Console.ReadKey();
    }
}