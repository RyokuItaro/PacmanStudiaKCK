using System;
using System.Collections.Generic;
using System.Threading;

namespace PacmanConsoleCSStudia
{
    internal class Program
    {
        static Thread game = new Thread(Game);
        public static Map map = new Map();
        public static Pacman pacman;
        public static List<Ghost> ghosts;
        public static int score = 0;
        public static bool isGameOver = false;
        public static ConsoleKeyInfo menuAgree;
        public static ConsoleKeyInfo menuKey;
        public static List<char> pacmanSkins = new List<char>() {'X', 'O', '@', '>', '<'};
        public static List<char> ghostSkins = new List<char>() {'G', 'W', '!', '.', ' '};
        public static int pacmanSkinChoosen = 0;
        public static int ghostSkinChoosen = 0;
        public static char ghostSkin = pacmanSkins[pacmanSkinChoosen];
        public static char pacmanSkin = ghostSkins[ghostSkinChoosen];

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            while (!(menuAgree.Key == ConsoleKey.Enter && menuKey.Key == ConsoleKey.D1))
            {
                ShowMenu(menuKey);
                var temp = GetMenuOption();
                if(temp.Key == ConsoleKey.Enter
                    || ((temp.Key == ConsoleKey.LeftArrow || temp.Key == ConsoleKey.RightArrow) && (menuKey.Key == ConsoleKey.D3 || menuKey.Key == ConsoleKey.D2)))
                {
                    menuAgree = temp;
                }
                else
                {
                    menuAgree = new ConsoleKeyInfo();
                    menuKey = temp;
                }
                if(menuAgree.Key == ConsoleKey.Enter && menuKey.Key == ConsoleKey.D4)
                {
                    return;
                }
                else if (menuAgree.Key == ConsoleKey.RightArrow)
                {
                    if(menuKey.Key == ConsoleKey.D2)
                    {
                        ghostSkinChoosen++;
                        ghostSkin = ghostSkins[ghostSkinChoosen < 0 ? ghostSkinChoosen % 5 + 5 : ghostSkinChoosen % 5];
                    }
                    else if(menuKey.Key == ConsoleKey.D3)
                    {
                        pacmanSkinChoosen++;
                        pacmanSkin = pacmanSkins[pacmanSkinChoosen % 5 < 0 ? pacmanSkinChoosen % 5 + 5 : pacmanSkinChoosen % 5];
                    }
                }
                else if (menuAgree.Key == ConsoleKey.LeftArrow)
                {
                    if (menuKey.Key == ConsoleKey.D2)
                    {
                        ghostSkinChoosen--;
                        ghostSkin = ghostSkins[ghostSkinChoosen % 5 < 0 ? ghostSkinChoosen % 5 + 5 : ghostSkinChoosen % 5];
                    }
                    else if (menuKey.Key == ConsoleKey.D3)
                    {
                        pacmanSkinChoosen--;
                        pacmanSkin = pacmanSkins[pacmanSkinChoosen % 5 < 0 ? pacmanSkinChoosen % 5 + 5: pacmanSkinChoosen % 5];
                    }
                }
            }
            
            Console.Clear();
            map.RenderMap();

            pacman = new Pacman(13, 23, pacmanSkin);
            ghosts = new List<Ghost>()
            {
                new Ghost(11,11, ghostSkin),
                new Ghost(13,11, ghostSkin),
                new Ghost(15,11, ghostSkin),
                new Ghost(17,11, ghostSkin)
            };

            game.Start();
            game.IsBackground = true;
            pacman.Control(game);
            Console.Clear();
        }

        private static ConsoleKeyInfo GetMenuOption()
        {
            return Console.ReadKey(true);
        }

        private static void ShowMenu(ConsoleKeyInfo menuKey)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(@"__________                  _____                 ");
            Console.WriteLine(@"\______   \_____    ____   /     \ _____    ____  ");
            Console.WriteLine(@" |     ___/\__  \ _/ ___\ /  \ /  \\__  \  /    \ ");
            Console.WriteLine(@" |    |     / __ \\  \___/    Y    \/ __ \|   |  \");
            Console.WriteLine(@" |____|    (____  /\___  >____|__  (____  /___|  /");
            Console.WriteLine(@"                \/     \/        \/     \/     \/ ");
            Console.WriteLine($"{(menuKey.Key == ConsoleKey.D1 ? '→' : ' ')}1. Zagraj");
            Console.WriteLine($"{(menuKey.Key == ConsoleKey.D2 ? '→' : ' ')}2. Ustaw skin duchów | <- {ghostSkin} ->");
            Console.WriteLine($"{(menuKey.Key == ConsoleKey.D3 ? '→' : ' ')}3. Ustaw skin Pacmana | <- {pacmanSkin} ->");
            Console.WriteLine($"{(menuKey.Key == ConsoleKey.D4 ? '→' : ' ')}4. Wyjdz");
        }

        public static void Game()
        {
            while (!Program.isGameOver)
            {
                if(Program.score >= 15)
                {
                    Console.SetCursorPosition(50, 14);
                    Console.Write("Wygrałeś!");
                    Console.SetCursorPosition(50, 15);
                    Console.Write("Naciśnij przycisk dowolny przycisk aby wyjść");
                    Program.isGameOver = true;
                }
                else
                {
                    pacman.Step();
                    Program.isGameOver = checkPacmanCollisionWithGhosts();
                    foreach (Ghost ghost in ghosts)
                    {
                        ghost.Step();
                    }
                    Program.isGameOver = checkPacmanCollisionWithGhosts();
                }
                
                Thread.Sleep(300);
            }
        }

        private static bool checkPacmanCollisionWithGhosts()
        {
            foreach(Ghost ghost in ghosts)
            {
                if(ghost.x == pacman.x && ghost.y == pacman.y)
                {
                    Console.SetCursorPosition(50, 14);
                    Console.Write("Przegrałeś!");
                    Console.SetCursorPosition(50, 15);
                    Console.Write("Naciśnij przycisk dowolny przycisk aby wyjść");
                    return true;
                }
            }
            return false;
        }
    }
}
