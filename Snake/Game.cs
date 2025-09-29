namespace Snake
{
    public class Game
    {
        private List<(int X, int Y)> snake = new List<(int X, int Y)>(); // положение всего тела змейки

        private string FieldSize { get; set; }
        private string Complexity { get; set; }

        private byte width;
        private byte height;

        private int foodX = -1, foodY = -1; // текущие координаты еды

        private short speed;

        public Game(ref string fliedSize, ref string complexity)
        {
            FieldSize = fliedSize;
            Complexity = complexity;

            // Определяем размеры поля один раз
            if (FieldSize == "average")
            {
                width = 35;
                height = 30;
            }
            else if (FieldSize == "big")
            {
                width = 40;
                height = 35;
            }
            else
            {
                width = 25;
                height = 20;
            }

            if (Complexity == "average")
            {
                speed = 200;
            }
            else if (Complexity == "difficult")
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
            int x = 5, y = 5; // стартовые координаты змейки
            string direction = "RIGHT"; // начальное направление

            snake.Clear();
            snake.Add((x, y)); // стартовая позиция змейки

            // создаём еду
            (foodX, foodY) = SpawnFood();

            while (true)
            {
                // читаем клавишу, если есть
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.W && direction != "DOWN")
                        direction = "UP";
                    else if (key == ConsoleKey.S && direction != "UP")
                        direction = "DOWN";
                    else if (key == ConsoleKey.A && direction != "RIGHT")
                        direction = "LEFT";
                    else if (key == ConsoleKey.D && direction != "LEFT")
                        direction = "RIGHT";
                    else if (key == ConsoleKey.Escape)
                        Environment.Exit(0);
                    else if (key == ConsoleKey.M)
                        return;
                }

                // координаты текущей головы
                var head = snake[0];
                int newX = head.X;
                int newY = head.Y;

                // движение головы
                switch (direction)
                {
                    case "UP": newY--; break;
                    case "DOWN": newY++; break;
                    case "LEFT": newX--; break;
                    case "RIGHT": newX++; break;
                }

                // обработка выхода за границы
                if (newX >= width - 1) newX = 1;
                else if (newX <= 0) newX = width - 2;

                if (newY >= height - 1) newY = 1;
                else if (newY <= 0) newY = height - 2;

                // проверка на самопересечение
                if (snake.Any(s => s.X == newX && s.Y == newY))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы врезались в себя! Игра окончена.");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    return;
                }

                // добавляем новую голову
                snake.Insert(0, (newX, newY));

                // проверка наличия еды
                if (foodX == newX && foodY == newY)
                {
                    foodX = -1;
                    foodY = -1; // съели еду → оставляем хвост (рост)
                }
                else
                {
                    snake.RemoveAt(snake.Count - 1); // не съели → удаляем хвост
                }

                // получаем новые коодринаты еды
                SpawnFoodIfNeeded();

                // отрисовка
                FieldRendering();
            }
        }

        public (sbyte X, sbyte Y) SpawnFood()
        {
            CoordinatesFood food = new CoordinatesFood(width, height);
            return (food.X, food.Y); // возвращаем
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
            Thread.Sleep(speed); // задержка для видимости движения змейки
            Console.Clear();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    // еда
                    if (i == foodY && j == foodX)
                        Console.Write("*");
                    // границы
                    else if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                        Console.Write("#");
                    // голова змейки
                    else if (snake.Count > 0 && snake[0].X == j && snake[0].Y == i)
                        Console.Write("O");
                    // тело змейки
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
