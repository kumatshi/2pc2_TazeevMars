using System.IO;
using System;
using System.Timers;

namespace PZ_16
{
    internal class Program
    {
        //Данные о карте
        static int mapSize = 25; //размер карты
        static char[,] map = new char[mapSize, mapSize]; //карта

        //Уровни
        static int Level = 1;
        //координаты на карте игрока
        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;

        //Количество интерактивных предметов       
        static int enemies = 10; //количество врагов
        static byte buffs = 5; //количество усилений
        static int OldSteps = 0;//количество шагов для бафов
        static int health = 5;  // количество аптечек   

        //характеристики персонажа
        static int PlayerShot = 10;
        static int PlayerHealth = 50;
        static int steps = 0;

        //Характеристики Босса
        static int BossHealth = 80;
        static int BossShot = 100;
        static int EnemiesBoss = 3;
        static int EnemiesBossHealth = 30;

        //Характеристики врага
        static int EnemyDamage = 5;
        static int EnemyHealth = 30;
        static int EnemiesCount = 10;




        static void Main(string[] args)
        {
            StartDisplay();
            Move();
        }

        /// <summary>
        /// генерация карты с расставлением врагов, аптечек, баффов
        /// </summary>
        static void GenerationMap()
        {
            if (Level == 1)
            {
                Random random = new Random();
                //создание пустой карты
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize - 1; j++)
                    {
                        map[i, j] = '_';

                    }
                }

                //При рестарте игры персонаж ставится в центр
                playerX = mapSize / 2;
                playerY = mapSize / 2;


                map[playerY, playerX] = 'P'; // в середину карты ставится игрок

                //временные координаты для проверки занятости ячейки
                int x;
                int y;

                //добавление врагов
                while (enemies > 0)
                {
                    x = random.Next(0, mapSize);
                    y = random.Next(1, mapSize);

                    //если ячейка пуста  - туда добавляется враг
                    if (map[x, y] == '_')
                    {
                        map[x, y] = 'E';
                        enemies--; //при добавлении врагов уменьшается количество нерасставленных врагов
                    }
                }

                //добавление баффов
                while (buffs > 0)
                {
                    x = random.Next(0, mapSize);
                    y = random.Next(1, mapSize);

                    if (map[x, y] == '_')
                    {
                        map[x, y] = 'B';
                        buffs--;
                    }
                }
                //добавление аптечек
                while (health > 0)
                {
                    x = random.Next(0, mapSize);
                    y = random.Next(1, mapSize);

                    if (map[x, y] == '_')
                    {
                        map[x, y] = 'H';
                        health--;
                    }
                }
                UpdateMap(); //отображение заполненной карты на консоли
            }
            if (Level == 2)
            {
                health = 3;
                buffs = 3;
                if (Level == 2)
                {
                    {
                        Console.Clear();
                        Random random = new Random();
                        //создание пустой карты
                        for (int i = 0; i < mapSize; i++)
                        {
                            for (int j = 0; j < mapSize - 1; j++)
                            {
                                map[i, j] = '_';
                            }
                        }

                        //При рестарте игры персонаж ставится в центр
                        playerX = mapSize / 2;
                        playerY = mapSize / 2;


                        map[playerY, playerX] = 'P'; // в середину карты ставится игрок

                        //временные координаты для проверки занятости ячейки
                        int x;
                        int y;
                        //добавление врагов
                        while (EnemiesBoss > 0)
                        {
                            x = random.Next(0, mapSize);
                            y = random.Next(1, mapSize);

                            //если ячейка пуста  - туда добавляется враг
                            if (map[x, y] == '_')
                            {
                                map[x, y] = 'b';
                                EnemiesBoss--; //при добавлении врагов уменьшается количество нерасставленных врагов
                            }
                        }
                        EnemiesBoss = 3;
                        //добавление баффов
                        while (buffs > 0)
                        {
                            x = random.Next(0, mapSize);
                            y = random.Next(1, mapSize);

                            if (map[x, y] == '_')
                            {
                                map[x, y] = 'B';
                                buffs--;
                            }
                        }
                        //добавление аптечек
                        while (health > 0)
                        {
                            x = random.Next(0, mapSize);
                            y = random.Next(1, mapSize);

                            if (map[x, y] == '_')
                            {
                                map[x, y] = 'H';
                                health--;
                            }
                        }
                        x = random.Next(0, mapSize);
                        y = random.Next(1, mapSize);

                        if (map[x, y] == '_')
                        {
                            map[x, y] = 'Ы';
                            health--;
                        }
                        Level++;
                        UpdateMap(); //отображение заполненной карты на консоли
                    }
                }
            }
        }
        /// <summary>
        /// перемещение персонажа
        /// </summary>
        static void Move()
        {
            //предыдущие координаты игрока
            int playerOldY;
            int playerOldX;

            while (true)
            {
                playerOldX = playerX;
                playerOldY = playerY;

                //MapForBoss();
                //Шаги для бафа
                CheckBuffsStep();


                //Характеристики персонажа
                PlayerSettings();

                //смена координат в зависимости от нажатия клавиш               
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        playerX--;
                        steps++;
                        break;
                    case ConsoleKey.DownArrow:
                        playerX++;
                        steps++;
                        break;
                    case ConsoleKey.LeftArrow:
                        playerY--;
                        steps++;
                        break;
                    case ConsoleKey.RightArrow:
                        playerY++;
                        steps++;
                        break;
                    case ConsoleKey.Q:
                        PauseDisplay();
                        break;
                }
                //Барьеры
                Barrier();

                //Хилл
                Health();

                //Бафы
                Buffs();

                Console.CursorVisible = false; //скрытный курсов

                //предыдущее положение игрока затирается
                map[playerOldX, playerOldY] = '_';
                Console.SetCursorPosition(playerOldY, playerOldX);
                Console.Write('_');

                //Бой с Боссом
                BossFight(playerOldX, playerOldY);

                //Бой
                Fight(playerOldX, playerOldY);

                //Бой с боссом
                FightBossEnemies(playerOldX, playerOldY);

                //обновленное положение игрока
                map[playerX, playerY] = 'P';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write('P');
            }
        }
        /// <summary>
        /// вывод карты на консоль
        /// </summary>
        static void UpdateMap()
        {
            Console.Clear();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {

                    //ЦИКЛ для раскраски врагов бафов и хилок
                    switch (map[i, j])
                    {
                        case 'H':
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'E':
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'B':
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'b':
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'Ы':
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        default:
                            Console.Write(map[i, j]);
                            break;
                    }
                    //Console.WriteLine(map[i, j]);
                }

                Console.WriteLine(map[i, 0]);
            }
        }

        //Харакетеристики персонажа
        static void PlayerSettings()
        {
            Console.SetCursorPosition(0, mapSize + 1);
            Console.Write($"Здоровье игрока: {PlayerHealth}   ");
            Console.SetCursorPosition(0, mapSize + 2);
            Console.Write($"Урон игрока: {PlayerShot}   ");
            Console.SetCursorPosition(0, mapSize + 3);
            if (EnemiesCount > 0)
            {
                Console.Write($"Осталось врагов: {EnemiesCount}   ");
            }
            else if (EnemiesCount == 0)
            {
                Console.Write($"Осталось врагов до снятия щита босса: {EnemiesBoss}   ");
                Console.SetCursorPosition(40, 7);
                Console.Write($"Здоровье босса: {BossHealth}");

            }
            Console.SetCursorPosition(0, mapSize + 4);
            Console.Write($"Пройдено шагов: {steps}    ");
            //Информация об игроке
            Console.SetCursorPosition(40, 2);
            Console.WriteLine("P - Игрок");
            //Информация об аптечке
            Console.SetCursorPosition(40, 3);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("H - Аптечка,которая полностью восстанавливает здороьве");
            //Информация о враге
            Console.SetCursorPosition(40, 4);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("E - Враг. Имеет 30 ХП и 5 Дамага");
            //Информация о бафах
            Console.SetCursorPosition(40, 5);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("B - Бафы,которые увеличивают дамаг героя вдвое");
            Console.ResetColor();
            Console.SetCursorPosition(40, 7);
            Console.Write($"Здоровье врага: {EnemyHealth}");
            //Информация о координатах персонажа
            Console.SetCursorPosition(40, 6);
            Console.Write($"Текущие координаты игрока: X: {playerX}   Y: {playerY} ");
            //Информация о боссе
            if (EnemiesCount == 0)
            {
                Console.SetCursorPosition(40, 13);
                Console.Write($"Здоровье босса: {BossHealth}");
            }
        }

        //Метод для создания невидимых барьеров
        static void Barrier()
        {
            //если координаты игрока выходят за край, то игрок остаётся на прежнем месте 
            if (playerX == -1)
            {
                playerX = 0;
                steps--;
            }
            if (playerY == -1)
            {
                playerY = 0;
                steps--;
            }
            if (playerY == mapSize)
            {
                playerY = mapSize - 1;
                steps--;
            }

            if (playerX == mapSize)
            {
                playerX = mapSize - 1;
                steps--;
            }
        }

        //Метод боя
        static void Fight(int x, int y)
        {
            Random random = new Random();

            if (map[playerX, playerY] == 'E')
            {

                EnemyHealth -= PlayerShot;
                if (EnemyHealth <= 0)
                {
                    PlayerHealth -= EnemyDamage;
                    EnemiesCount--;
                    map[playerX, playerY] = '_';
                    if (EnemiesCount == 0)
                    {
                        //MapForBoss();
                        Level++;
                        GenerationMap();
                    }

                }
                if (EnemyHealth > 0)
                {
                    PlayerHealth -= EnemyDamage;
                    map[x, y] = 'E';

                }
                if (PlayerHealth <= 0)
                {
                    Console.Clear();
                    EnemiesCount = 11;
                    DeathDisplay();
                }
                if (EnemyHealth <= 0)
                {
                    EnemyHealth = 30;
                }

                UpdateMap();
            }
        }

        //Метод для хилла
        static void Health()
        {
            if (map[playerX, playerY] == 'H' && PlayerHealth < 50)
            {
                PlayerHealth = 50;
            }
        }

        //Метод для бафов
        static void Buffs()
        {
            if (map[playerX, playerY] == 'B')
            {
                OldSteps = 21;
                if (PlayerShot < 20)
                {
                    PlayerShot *= 2;
                }
            }
        }

        //Время действия баффа
        static void CheckBuffsStep()
        {
            if (PlayerShot >= 20) //если урон игрока уже увеличен
            {
                OldSteps -= 1;
                Console.SetCursorPosition(40, mapSize + 4);
                Console.Write($"До окончания действия баффа осталось шагов: {OldSteps}   ");
                if (OldSteps <= 0) //если время действия баффа закончилось
                {
                    PlayerShot = 10; //дефолтное значение дамага игрока
                    Console.SetCursorPosition(40, mapSize + 4);
                    Console.Write("                                                   ");
                }
            }
        }

        //Стартовый дисплей
        static void StartDisplay()
        {
            Console.CursorVisible = false; //скрытный курсов
            Console.SetCursorPosition(40, 11);
            Console.Write("N - Начать новую игру");
            Console.SetCursorPosition(40, 12);
            Console.Write("L - Загрузить последнее сохранение");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.L: //запуск последнего сохранения
                    break;
                case ConsoleKey.N: //запуск новой игры
                    EnemiesCount = 10;// EnemiesCount = 10;
                    enemies = 10;
                    buffs = 5;
                    steps = 0;
                    PlayerHealth = 50;
                    EnemyHealth = 30;
                    PlayerShot = 10;
                    health = 5;
                    Level = 1;
                    GenerationMap();
                    break;
                case ConsoleKey.B:
                    EnemiesCount = 0;
                    Level = 2;
                    MapForBoss();
                    break;
                default: //если игрок нажимает на другие клавиши то стартовый экран не пропадает
                    StartDisplay();
                    break;
            }
        }

        //Дисплей при проигрыше
        static void DeathDisplay()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(40, 9);
            Console.Write("Вы проиграли");
            Console.SetCursorPosition(40, 10);
            Console.WriteLine($"Количество пройденных шагов: {steps}");
            StartDisplay();
        }

        //Дисплей при паузе
        static void PauseDisplay()
        {
            Console.Clear();
            Console.CursorVisible = false; //скрытный курсов
            Console.SetCursorPosition(40, 11);
            Console.Write("N - Начать новую игру");
            Console.SetCursorPosition(40, 12);
            Console.Write("L - Загрузить последнее сохранение");
            Console.SetCursorPosition(40, 13);
            Console.Write("F - Сохранить игру");
            Console.SetCursorPosition(40, 14);
            Console.Write("J - Продолжить");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.L: //запуск последнего сохранения
                    break;
                case ConsoleKey.N: //запуск новой игры
                    EnemiesCount = 10;
                    enemies = 10;
                    buffs = 5;
                    steps = 0;
                    PlayerHealth = 50;
                    EnemyHealth = 30;
                    PlayerShot = 10;
                    health = 5;
                    Level = 1;
                    GenerationMap();
                    break;
                case ConsoleKey.J:
                    OldSteps = OldSteps + 1;
                    UpdateMap();
                    break;
                case ConsoleKey.F:
                    PauseDisplay();
                    Console.SetCursorPosition(40, 15);
                    Console.Write("Игра успешно сохранена");
                    //PauseDisplay();
                    break;
                default: //если игрок нажимает на другие клавиши то экран паузы не пропадает
                    PauseDisplay();
                    break;
            }
        }

        //Дисплей при победе
        static void WinDisplay()
        {
            Console.Clear();
            Console.CursorVisible = false; //скрытный курсов
            Console.SetCursorPosition(40, 9);
            Console.Write("Поздравляю,вы прошли игру");
            Console.SetCursorPosition(40, 10);
            Console.Write($"Количество пройденных шагов: {steps}");

        }



        //Спавн карты для босса
        static void MapForBoss()
        {

            health = 3;
            buffs = 3;
            if (Level == 2)
            {
                {
                    Console.Clear();
                    Random random = new Random();
                    //создание пустой карты
                    for (int i = 0; i < mapSize; i++)
                    {
                        for (int j = 0; j < mapSize - 1; j++)
                        {
                            map[i, j] = '_';
                        }
                    }

                    //При рестарте игры персонаж ставится в центр
                    playerX = mapSize / 2;
                    playerY = mapSize / 2;


                    map[playerY, playerX] = 'P'; // в середину карты ставится игрок

                    //временные координаты для проверки занятости ячейки
                    int x;
                    int y;
                    //добавление врагов
                    while (EnemiesBoss > 0)
                    {
                        x = random.Next(0, mapSize);
                        y = random.Next(1, mapSize);

                        //если ячейка пуста  - туда добавляется враг
                        if (map[x, y] == '_')
                        {
                            map[x, y] = 'b';
                            EnemiesBoss--; //при добавлении врагов уменьшается количество нерасставленных врагов
                        }
                    }
                    EnemiesBoss = 3;
                    //добавление баффов
                    while (buffs > 0)
                    {
                        x = random.Next(0, mapSize);
                        y = random.Next(1, mapSize);

                        if (map[x, y] == '_')
                        {
                            map[x, y] = 'B';
                            buffs--;
                        }
                    }
                    //добавление аптечек
                    while (health > 0)
                    {
                        x = random.Next(0, mapSize);
                        y = random.Next(1, mapSize);

                        if (map[x, y] == '_')
                        {
                            map[x, y] = 'H';
                            health--;
                        }
                    }
                    x = random.Next(0, mapSize);
                    y = random.Next(1, mapSize);

                    if (BossHealth > 0)
                    {
                        if (map[x, y] == '_')
                        {
                            map[x, y] = 'Ы';
                            health--;
                        }
                    }
                    Level++;
                    UpdateMap(); //отображение заполненной карты на консоли
                }
            }
        }

        //Бой с боссом
        static void BossFight(int J, int K)
        {
            Random random = new Random();

            if (map[playerX, playerY] == 'Ы')
            {

                BossHealth -= PlayerShot;
                if (BossHealth <= 0)
                {
                    //map[playerX, playerY] = '_';
                    Level--;
                    Console.Clear();
                    WinDisplay();


                }
                PlayerHealth -= BossShot;
                if (PlayerHealth <= 0)
                {
                    Level--;
                    DeathDisplay();

                }

                int x = random.Next(playerX - 3, playerX + 3);
                int y = random.Next(playerY - 3, playerY + 3);

                if (x > 0 && x < 25)
                {
                    if (y > 0 && y < 25)
                    {
                        if (map[x, y] == '_')
                        {
                            map[x, y] = 'Ы';

                        }
                        else
                        {
                            map[J, K] = 'Ы';
                        }
                    }
                }

                UpdateMap();
            }

        }

        //Метод для боя с союзниками Босса
        static void FightBossEnemies(int x, int y)
        {
            Random random = new Random();

            if (map[playerX, playerY] == 'b')
            {

                EnemiesBossHealth -= PlayerShot;
                if (EnemiesBossHealth <= 0)
                {
                    EnemiesBoss--;
                    map[playerX, playerY] = '_';
                    if (EnemiesBoss == 0)
                    {
                        BossShot = 15;
                    }

                }
                if (EnemiesBossHealth > 0)
                {
                    PlayerHealth -= EnemyDamage;
                    map[x, y] = 'b';
                }
                if (PlayerHealth <= 0)
                {
                    Console.Clear();
                    EnemiesCount = 11;
                    DeathDisplay();
                }
                if (EnemiesBossHealth <= 0)
                {
                    EnemiesBossHealth = 30;
                }

                UpdateMap();
            }
        }

    }





}
