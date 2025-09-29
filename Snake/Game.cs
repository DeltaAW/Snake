namespace Snake
{
    public class Game
    {
        private List<(int X, int Y)> snake = new List<(int X, int Y)>(); // Position des ganzen Schlangenkörpers

        private string FieldSize { get; set; }
        private string Complexity { get; set; }

        private byte width;
        private byte height;

        private int foodX = -1, foodY = -1; // aktuelle Essenskoordinaten

        private short speed;

        public Game(ref string fliedSize, ref string complexity)
        {
            FieldSize = fliedSize;
            Complexity = complexity;

            // Bestimmen der Spielfeldgröße einmalig
            if (FieldSize == "mittel")
            {
                width = 35;
                height = 30;
            }
            else if (FieldSize == "groß")
            {
                width = 40;
                height = 35;
            }
            else
            {
                width = 25;
                height = 20;
            }

            if (Complexity == "mittel")
            {
                speed = 200;
            }
            else if (Complexity == "schwer")
            {
                speed = 150;
            }
            else
            {
                speed = 250;
            }
        }

        public void Management()
        {
            int x = 5, y = 5; // Startkoordinaten der Schlange
            string direction = "RECHTS"; // Start-Richtung

            snake.Clear();
            snake.Add((x, y)); // Startposition der Schlange

            // Essen erzeugen
            (foodX, foodY) = SpawnFood();

            while (true)
            {
                // Tasteneingabe prüfen
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.W && direction != "UNTEN")
                        direction = "OBEN";
                    else if (key == ConsoleKey.S && direction != "OBEN")
                        direction = "UNTEN";
                    else if (key == ConsoleKey.A && direction != "RECHTS")
                        direction = "LINKS";
                    else if (key == ConsoleKey.D && direction != "LINKS")
                        direction = "RECHTS";
                    else if (key == ConsoleKey.Escape)
                        Environment.Exit(0);
                    else if (key == ConsoleKey.M)
                        return;
                }

                // aktuelle Kopfkoordinaten
                var head = snake[0];
                int newX = head.X;
                int newY = head.Y;

                // Kopf bewegen
                switch (direction)
                {
                    case "OBEN": newY--; break;
                    case "UNTEN": newY++; break;
                    case "LINKS": newX--; break;
                    case "RECHTS": newX++; break;
                }

                // Bildschirmränder behandeln (Teleport)
                if (newX >= width - 1) newX = 1;
                else if (newX <= 0) newX = width - 2;

                if (newY >= height - 1) newY = 1;
                else if (newY <= 0) newY = height - 2;

                // Überprüfung auf Selbstkollision
                if (snake.Any(s => s.X == newX && s.Y == newY))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sie haben sich selbst getroffen! Spiel vorbei.");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    return;
                }

                // Neue Kopfposition hinzufügen
                snake.Insert(0, (newX, newY));

                // Prüfen, ob Essen gefressen wurde
                if (foodX == newX && foodY == newY)
                {
                    foodX = -1;
                    foodY = -1; // Essen gefressen → Schwanz bleibt (Wachstum)
                }
                else
                {
                    snake.RemoveAt(snake.Count - 1); // nicht gefressen → Schwanz entfernen
                }

                // Neue Essenskoordinaten, falls nötig
                SpawnFoodIfNeeded();

                // Spielfeld zeichnen
                FieldRendering();
            }
        }

        public (sbyte X, sbyte Y) SpawnFood()
        {
            CoordinatesFood food = new CoordinatesFood(width, height);
            return (food.X, food.Y); // zurückgeben
        }

        private void SpawnFoodIfNeeded()
        {
            if (foodX == -1 && foodY == -1)
            {
                (foodX, foodY) = SpawnFood();
            }
        }

        public void FieldRendering()
        {
            Thread.Sleep(speed); // Verzögerung für Sichtbarkeit der Schlange
            Console.Clear();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    // Essen
                    if (i == foodY && j == foodX)
                        Console.Write("*");
                    // Rand
                    else if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                        Console.Write("#");
                    // Kopf der Schlange
                    else if (snake.Count > 0 && snake[0].X == j && snake[0].Y == i)
                        Console.Write("O");
                    // Körper der Schlange
                    else if (snake.Skip(1).Any(s => s.X == j && s.Y == i))
                        Console.Write("o");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
