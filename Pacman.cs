using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PacmanConsoleCSStudia
{
    public class Pacman
    {
        public char skin = 'X';
        public direction dir;
        public direction prevDir;
        public char field = Map.empty;
        public int x, y;
        public int X
        {
            set
            {
                x = value;
            }
            get
            {
                return x;
            }
        }
        public int Y
        {
            set
            {
                y = value;
            }
            get
            {
                return y;
            }
        }

        public Pacman(int x, int y, char skinChar)
        {
            this.X = x;
            this.Y = y;
            skin = skinChar;
            field = Map.empty;
            dir = direction.left;
            Program.map.RenderChar(x, y, skin);
        }

        public void Control(Thread background)
        {
            while (background.IsAlive)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    dir = direction.left;
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    dir = direction.right;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    dir = direction.up;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    dir = direction.down;
                }
            }
        }

        public void Move(direction Direction)
        {
            if (x > 27) x = 0;
            else if (x < 0) x = 27;
            Program.map.RenderChar(x, y, field);
            if (Direction == direction.left) x--;
            if (Direction == direction.right) x++;
            if (Direction == direction.up) y--;
            if (Direction == direction.down) y++;
            AddPointsIfPowerUp();
            Program.map.RenderChar(x, y, skin);
        }

        private void AddPointsIfPowerUp()
        {
            if (Program.map[x,y] == Map.powerUp)
            {
                Program.score += 1;
            }
            Console.SetCursorPosition(50, 16);
            Console.Write("Punkty: ");
            Console.SetCursorPosition(50, 17);
            Console.Write(Program.score);
        }

        public void Step()
        {
            if (RenderAheadPacman(dir) != Map.wall)
            {
                Move(dir);
                prevDir = dir;
            }
            else
            {
                if(RenderAheadPacman(prevDir) != Map.wall)
                {
                    Move(prevDir);
                }
            }
        }

        public char RenderAheadPacman(direction Direction)
        {
            if (Direction == direction.left) return Program.map[x - 1, y];
            if (Direction == direction.right) return Program.map[x + 1, y];
            if (Direction == direction.up) return Program.map[x, y - 1];
            return Program.map[x, y + 1];
        }
    }
}
