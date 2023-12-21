using System.Collections.Generic;

namespace PZ_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                RunGame();
                Console.WriteLine("Нажмите 'r', чтобы перезапустить игру, или любую другую клавишу для выхода.");
                ConsoleKeyInfo restartKey = Console.ReadKey();
                if (restartKey.Key != ConsoleKey.R)
                {
                    break;
                }
            }
        }
            static void RunGame()
            {
                Console.WindowHeight = 16;
                Console.WindowWidth = 40;
                int screenWidth = Console.WindowWidth;
                int screenHeight = Console.WindowHeight;
                Random random = new Random();
                //int headX = screenWidth / 2;
                //int headY = screenHeight / 2;
                ConsoleColor snakeColor = ConsoleColor.Green;
                string direction = "RIGHT";
                List snakeX = new List() {headX};
                List snakeY = new List() {headY};
                int score = 0;
                int fruitX = random.Next(1, screenWidth - 2);
                int fruitY = random.Next(1, screenHeight - 2);
                ConsoleColor fruitColor = ConsoleColor.Cyan;
                DateTime lastMoveTime = DateTime.Now;
                string buttonPressed = "no";
                int hedgehogX = random.Next(1, screenWidth - 2);
                int hedgehogY = random.Next(1, screenHeight - 2);
                ConsoleColor hedgehogColor = ConsoleColor.Gray;
                int wallX = random.Next(1, screenWidth - 2);
                int wallY = random.Next(1, screenHeight - 2);
                ConsoleColor wallColor = ConsoleColor.Red;

                while (true)
                {
                    Console.Clear();
                    TimeSpan elapsedTime = DateTime.Now - lastMoveTime;
                    buttonPressed = "no";
                    // перемещение змейки
                    if (elapsedTime.TotalMilliseconds > 100)
                    {
                        lastMoveTime = DateTime.Now;
                        switch (direction)
                        {
                            case "RIGHT":
                                headX++;
                                break;
                            case "LEFT":
                                headX--;
                                break;
                            case "UP":
                                headY--;
                                break;
                            case "DOWN":
                                headY++;
                                break;
                        }
                    }
                    //змейка сьедает фрукт
                    if (headX == fruitX && headY == fruitY)
                    {
                        score++;
                        fruitX = random.Next(1, screenWidth - 2);
                        fruitY = random.Next(1, screenHeight - 2);
                        ExtendSnake(snakeX, snakeY, direction);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    //змейка сьедает ежика
                    else if (headX == hedgehogX && headY == hedgehogY)
                    {
                        if (score > 0)
                        {
                            score /= 2;
                        }
                        ExtendSnake(snakeX, snakeY, direction);
                        ShrinkSnake(snakeX, snakeY);
                        hedgehogX = random.Next(1, screenWidth - 2);
                        hedgehogY = random.Next(1, screenHeight - 2);
                    }
                    //змея ударяется об стену
                    else if (headX == wallX && headY == wallY)
                    {
                        // проигрыш
                        Console.Clear();
                        Console.WriteLine("Game Over! ты умергрущу.");
                        Console.WriteLine("Cчет: " + score);
                        break;
                    }
                    // отрисовка границ поля
                    for (int i = 0; i < screenWidth; i++)
                    {
                        Console.SetCursorPosition(i, 0);
                        Console.Write("■");
                        Console.SetCursorPosition(i, screenHeight - 1);
                        Console.Write("■");
                    }
                    for (int i = 0; i < screenHeight; i++)
                    {
                        Console.SetCursorPosition(0, i);
                        Console.Write("■");
                        Console.SetCursorPosition(screenWidth - 1, i);
                        Console.Write("■");
                    }

                    // отрисовка фрукта ежика и стены
                    Console.ForegroundColor = fruitColor;
                    Console.SetCursorPosition(fruitX, fruitY);
                    Console.Write("■");
                    Console.ForegroundColor = hedgehogColor;
                    Console.SetCursorPosition(hedgehogX, hedgehogY);
                    Console.Write("■");
                    Console.ForegroundColor = wallColor;
                    Console.SetCursorPosition(wallX, wallY);
                    Console.Write("■");
                    Console.ForegroundColor = ConsoleColor.White;

                    // отрисовка змейки
                    for (int i = 0; i < snakeX.Count; i++)
                    {
                        //Console.SetCursorPosition(snakeX[i], snakeY[i]);
                        //if (i == 0)
                        {
                            Console.ForegroundColor = snakeColor;
                        }
                else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        //Console.Write("■");
                    }

                    // информация о цветах и счете 
                    Console.SetCursorPosition(screenWidth, 0);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.SetCursorPosition(screenWidth, 1);
                    Console.WriteLine("■ - Обозначения");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(screenWidth, 2);
                    Console.WriteLine("■ - Змеиная голова");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(screenWidth, 3);
                    Console.WriteLine("■ - Змеиное тело");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(screenWidth, 4);
                    Console.WriteLine("■ - Фрукт");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(screenWidth, 5);
                    Console.WriteLine("■ - Ёжик");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(screenWidth, 6);
                    Console.WriteLine("■ - Cтена");

                    Console.SetCursorPosition(screenWidth / 2, screenHeight / 2);
                    Console.Write("Счёт:" + score);

                    // отработка ввода от пользователя для изменения направления змейки
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (direction != "DOWN" && buttonPressed == "no")
                            {
                                direction = "UP";
                                buttonPressed = "yes";
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (direction != "UP" && buttonPressed == "no")
                            {
                                direction = "DOWN";
                                buttonPressed = "yes";
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (direction != "RIGHT" && buttonPressed == "no")
                            {
                                direction = "LEFT";
                                buttonPressed = "yes";
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (direction != "LEFT" && buttonPressed == "no")
                            {
                                direction = "RIGHT";
                                buttonPressed = "yes";
                            }
                            break;
                    }
                    // обновление положения змейки 
                    MoveSnake(snakeX, snakeY, headX, headY, direction);

                    // обработка столкновения змейки с самой собой 
                    for (int i = 1; i < snakeX.Count; i++)
                    {
                        if (headX == snakeX[i] && headY == snakeY[i])
                        {
                            // проигрыш
                            Console.Clear();
                            Console.WriteLine("Game Over! ты умер");
                            Console.WriteLine("Счет:" + score);
                            Console.WriteLine("Нажмите 'R', чтобы перезапустить игру.");
                            ConsoleKeyInfo restartKey = Console.ReadKey();
                            if (restartKey.Key == ConsoleKey.R)
                            {
                                return;
                            }
                            else
                            {
                                Environment.Exit(0);
                            }
                        }
                    }
                    // столкновение змейки с границами поля 
                    if (headX == 0 || headX == screenWidth - 1 || headY == 0 || headY == screenHeight - 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Game Over! ты умер");
                        Console.WriteLine("Счет:" + score);
                        Console.WriteLine("Нажмите 'R', чтобы перезапустить игру.");
                        ConsoleKeyInfo restartKey = Console.ReadKey();
                        if (restartKey.Key == ConsoleKey.R)
                        {
                            return;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                }
            }

            static void MoveSnake(List snakeX, List snakeY, int headX, int headY)
            {
                // добавление новой головы змейки и удаление последнего сегмента 
                snakeX.Insert(0, headX);
                snakeY.Insert(0, headY);
                snakeX.RemoveAt(snakeX.Count - 1);
                snakeY.RemoveAt(snakeY.Count - 1);
            }

            static void ExtendSnake(List snakeX, List snakeY, string direction)
            {
                // добавление нового сегмента в змейку 
                int tailX = snakeX[snakeX.Count - 1];
                int tailY = snakeY[snakeY.Count - 1];

                switch (direction)
                {
                    case "UP":
                        snakeX.Add(tailX);
                        snakeY.Add(tailY - 1);
                        break;
                    case "DOWN":
                        snakeX.Add(tailX);
                        snakeY.Add(tailY + 1);
                        break;
                    case "LEFT":
                        snakeX.Add(tailX + 1);
                        snakeY.Add(tailY);
                        break;
                    case "RIGHT":
                        snakeX.Add(tailX - 1);
                        snakeY.Add(tailY);
                        break;
                }
            }

            static void ShrinkSnake(List snakeX, List snakeY)
            {
                // уменьшение длины змейки
                int newLength = snakeX.Count / 2;
                snakeX.RemoveRange(newLength, snakeX.Count - newLength);
                snakeY.RemoveRange(newLength, snakeY.Count - newLength);
            }
        
    }
}