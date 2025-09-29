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

                Console.WriteLine("Wählen Sie die Größe des Spielfeldes\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t1 - klein\n");
                Console.WriteLine("\t2 - mittel\n");
                Console.WriteLine("\t3 - groß\n");
                Console.ResetColor();

                Console.WriteLine("Wählen Sie den Schwierigkeitsgrad\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t4 - einfach\n");
                Console.ResetColor();
                Console.WriteLine("\t5 - mittel\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t6 - schwer\n");
                Console.ResetColor();

                Console.Write("Spielfeldgröße: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(fliedSize);
                Console.ResetColor();

                Console.Write("Schwierigkeitsgrad: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(complexity);
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t7 - zurück\n");
                Console.ResetColor();

                if (int.TryParse(Console.ReadLine(), out number) && number == 1)
                {
                    fliedSize = "klein";
                }
                else if (number == 2)
                {
                    fliedSize = "mittel";
                }
                else if (number == 3)
                {
                    fliedSize = "groß";
                }
                else if (number == 4)
                {
                    complexity = "einfach";
                }
                else if (number == 5)
                {
                    complexity = "mittel";
                }
                else if (number == 6)
                {
                    complexity = "schwer";
                }
                else if (number == 7)
                {
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ungültige Eingabe, bitte erneut versuchen.");
                    Console.WriteLine("Drücken Sie ENTER, um fortzufahren");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
            }
        }
    }
}

