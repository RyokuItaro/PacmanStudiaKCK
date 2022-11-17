using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanConsoleCSStudia
{
    public class Map
    {
        public static char wall= '#';
        public static char empty = ' ';
        public static char powerUp = '*';
        public char[,] map = new char[31, 28];

        public char this[int x, int y]
        {
            get
            {
                if (x < 0) return map[y, 27];
                else if (x > 27) return map[y, 0];
                else return map[y, x];
            }
            set
            {
                map[y, x] = value;
                Console.SetCursorPosition(x + 1, y + 1);
                Console.Write(value);
            }
        }

        public void RenderChar(int x, int y, char symbol)
        {
            if (x < 0) x = 27;
            else if (x > 27) x = 0;

            Console.SetCursorPosition(x + 1, y + 1);
            if(symbol == Program.ghostSkin)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if(symbol == Program.pacmanSkin)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.Write(symbol);
            Console.ResetColor();
            map[y, x] = symbol;
        }

        public void RenderEmptySpace(int x, int y)
        {
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write(empty);
            map[y, x] = empty;
        }

        public void RenderMap()
        {
            Console.SetCursorPosition(1, 1);
            for (int width = 0; width < 28; width++)
            {
                Console.Write(wall);
                map[0, width] = wall;
            }

            Console.SetCursorPosition(1, 2);
            for (int width = 0; width < 28; width++)
            {
                if(width == 0 || width == 13 || width == 14 || width == 27)
                {
                    Console.Write(wall);
                    map[1, width] = wall;
                }
                else
                {
                    Console.Write(powerUp);
                    map[1, width] = powerUp;
                }
            }

            for(int i = 3; i < 6; i++)
            {
                Console.SetCursorPosition(1, i);
                for (int width = 0; width < 28; width++)
                {
                    if (width == 1 || width == 6 || width == 12 || width == 15 || width == 15 || width == 21 || width == 26)
                    {
                        Console.Write(powerUp);
                        map[i - 1, width] = powerUp;
                    }
                    else
                    {
                        Console.Write(wall);
                        map[i - 1, width] = wall;
                    }
                }
            }

            Console.SetCursorPosition(1, 6);
            for (int width = 0; width < 28; width++)
            {
                if (width == 0 || width == 27)
                {
                    Console.Write(wall);
                    map[5, width] = wall;
                }
                else
                {
                    Console.Write(powerUp);
                    map[5, width] = powerUp;
                }
            }

            for (int i = 7; i < 9; i++)
            {
                Console.SetCursorPosition(1, i);
                for (int width = 0; width < 28; width++)
                {
                    if (width == 1 || width == 6 || width == 9 || width == 17 || width == 21 || width == 26)
                    {
                        Console.Write(powerUp);
                        map[i - 1, width] = powerUp;
                    }
                    else
                    {
                        Console.Write(wall);
                        map[i - 1, width] = wall;
                    }
                }
            }

            Console.SetCursorPosition(1, 9);
            for (int width = 0; width < 28; width++)
            {
                if (width == 0 || width == 7 || width == 8 || width == 13 || width == 14 || width == 19 || width == 20 || width == 27)
                {
                    Console.Write(wall);
                    map[8, width] = wall;
                }
                else
                {
                    Console.Write(powerUp);
                    map[8, width] = powerUp;
                }
            }

            for (int i = 10; i < 12; i++)
            {
                Console.SetCursorPosition(1, i);
                for (int width = 0; width < 28; width++)
                {
                    if (width == 7 || width == 21)
                    {
                        Console.Write(powerUp);
                        map[i - 1, width] = powerUp;
                    }
                    else if(width == 12 || width == 15)
                    {
                        Console.Write(empty);
                        map[i - 1, width] = empty;
                    }
                    else
                    {
                        Console.Write(wall);
                        map[i - 1, width] = wall;
                    }
                }
            }

            Console.SetCursorPosition(1, 12);
            for (int width = 0; width < 28; width++)
            {
                if (width == 7 || width == 21)
                {
                    Console.Write(powerUp);
                    map[11, width] = powerUp;
                }
                else if (width >= 9 && width <= 18)
                {
                    Console.Write(empty);
                    map[11, width] = empty;
                }
                else
                {
                    Console.Write(wall);
                    map[11, width] = wall;
                }
            }

            for (int i = 13; i < 15; i++)
            {
                Console.SetCursorPosition(1, i);
                for (int width = 0; width < 28; width++)
                {
                    if (width == 7 || width == 21)
                    {
                        Console.Write(powerUp);
                        map[i - 1, width] = powerUp;
                    }
                    else if (width == 9 || width == 18)
                    {
                        Console.Write(empty);
                        map[i - 1, width] = empty;
                    }
                    else
                    {
                        Console.Write(wall);
                        map[i - 1, width] = wall;
                    }
                }
            }

            Console.SetCursorPosition(1, 15);
            for (int width = 0; width < 28; width++)
            {
                if (width == 7 || width == 21)
                {
                    Console.Write(powerUp);
                    map[14, width] = powerUp;
                }
                else if (width >= 10 && width <= 17)
                {
                    Console.Write(wall);
                    map[14, width] = wall;
                }
                else
                {
                    Console.Write(empty);
                    map[14, width] = empty;
                }
            }

            for (int i = 16; i < 18; i++)
            {
                Console.SetCursorPosition(1, i);
                for (int width = 0; width < 28; width++)
                {
                    if (width == 7 || width == 21)
                    {
                        Console.Write(powerUp);
                        map[i - 1, width] = powerUp;
                    }
                    else if (width == 9 || width == 18)
                    {
                        Console.Write(empty);
                        map[i - 1, width] = empty;
                    }
                    else
                    {
                        Console.Write(wall);
                        map[i - 1, width] = wall;
                    }
                }
            }

            Console.SetCursorPosition(1, 18);
            for (int width = 0; width < 28; width++)
            {
                if (width == 7 || width == 21)
                {
                    Console.Write(powerUp);
                    map[17, width] = powerUp;
                }
                else if (width >= 9 && width <= 18)
                {
                    Console.Write(empty);
                    map[17, width] = empty;
                }
                else
                {
                    Console.Write(wall);
                    map[17, width] = wall;
                }
            }

            for (int i = 19; i < 21; i++)
            {
                Console.SetCursorPosition(1, i);
                for (int width = 0; width < 28; width++)
                {
                    if (width == 7 || width == 21)
                    {
                        Console.Write(powerUp);
                        map[i - 1, width] = powerUp;
                    }
                    else if (width == 9 || width == 18)
                    {
                        Console.Write(empty);
                        map[i - 1, width] = empty;
                    }
                    else
                    {
                        Console.Write(wall);
                        map[i - 1, width] = wall;
                    }
                }
            }

            Console.SetCursorPosition(1, 21);
            for (int width = 0; width < 28; width++)
            {
                if (width == 0 || width == 13 || width == 14 || width == 27)
                {
                    Console.Write(wall);
                    map[20, width] = wall;
                }
                else
                {
                    Console.Write(powerUp);
                    map[20, width] = powerUp;
                    
                }
            }

            for (int i = 22; i < 24; i++)
            {
                Console.SetCursorPosition(1, i);
                for (int width = 0; width < 28; width++)
                {
                    if (width == 1 || width == 6 || width == 12 || width == 15 || width == 21 || width == 26)
                    {
                        Console.Write(powerUp);
                        map[i - 1, width] = powerUp;
                    }
                    else
                    {
                        Console.Write(wall);
                        map[i - 1, width] = wall;
                    }
                }
            }

            Console.SetCursorPosition(1, 24);
            for (int width = 0; width < 28; width++)
            {
                if (width == 0 || width == 4 || width == 5 || width == 23 || width == 22 || width == 27)
                {
                    Console.Write(wall);
                    map[23, width] = wall;
                }
                else
                {
                    Console.Write(powerUp);
                    map[23, width] = powerUp;
                }
            }

            for (int i = 25; i < 27; i++)
            {
                Console.SetCursorPosition(1, i);
                for (int width = 0; width < 28; width++)
                {
                    if (width == 3 || width == 6 || width == 9 || width == 18 || width == 21 || width == 24)
                    {
                        Console.Write(powerUp);
                        map[i - 1, width] = powerUp;
                    }
                    else
                    {
                        Console.Write(wall);
                        map[i - 1, width] = wall;
                    }
                }
            }

            Console.SetCursorPosition(1, 27);
            for (int width = 0; width < 28; width++)
            {
                if (width == 0 || width == 7 || width == 8 || width == 13 || width == 14 || width == 19 || width == 20 || width == 27)
                {
                    Console.Write(wall);
                    map[26, width] = wall;
                }
                else
                {
                    Console.Write(powerUp);
                    map[26, width] = powerUp;
                }
            }

            for (int i = 28; i < 30; i++)
            {
                Console.SetCursorPosition(1, i);
                for (int width = 0; width < 28; width++)
                {
                    if (width == 1 || width == 12 || width == 15 || width == 26)
                    {
                        Console.Write(powerUp);
                        map[i - 1, width] = powerUp;
                    }
                    else
                    {
                        Console.Write(wall);
                        map[i - 1, width] = wall;
                    }
                }
            }

            Console.SetCursorPosition(1, 30);
            for (int width = 0; width < 28; width++)
            {
                if (width == 0 || width == 27)
                {
                    Console.Write(wall);
                    map[29, width] = wall;
                }
                else
                {
                    Console.Write(powerUp);
                    map[29, width] = powerUp;
                }
            }

            Console.SetCursorPosition(1, 31);
            for (int width = 0; width < 28; width++)
            {
                Console.Write(wall);
                map[30, width] = wall;
            }
        }
    }
}
