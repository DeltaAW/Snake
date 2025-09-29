namespace Snake
{
    public class Settings
    {
        public void SettingsMenu(ref string fliedSize, ref string complexity)
        {
            int number;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Выберите размер игрового поля\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t1 - маленькое\n");
                Console.WriteLine("\t2 - среднее\n");
                Console.WriteLine("\t3 - большое\n");
                Console.ResetColor();


                Console.WriteLine("Выберите сложность\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t4 - легкий\n");
                Console.ResetColor();
                Console.WriteLine("\t5 - средний\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t6 - сложный\n");


                Console.ResetColor();

                Console.Write("размер игрового поля: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(fliedSize);
                Console.ResetColor();

                Console.Write("сложность игры ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(complexity);
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t7 - назад\n");
                Console.ResetColor();

                if (int.TryParse(Console.ReadLine(), out number) && number == 1)
                {
                    fliedSize = "small";
                }
                else if (number == 2)
                {
                    fliedSize = "average";
                }
                else if (number == 3)
                {
                    fliedSize = "big";
                }
                else if (number == 4)
                {
                    complexity = "easy";
                }
                else if (number == 5)
                {
                    complexity = "average";
                }
                else if (number == 6)
                {
                    complexity = "difficult";
                }
                else if (number == 7)
                {
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Вы ввели не верное значение, попробуйте еще раз");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Нажмите ENTER, чтобы продолжить");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
            }
        }
    }
}
