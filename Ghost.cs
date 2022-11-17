using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanConsoleCSStudia
{
    public class Ghost
    {
        public Random random = new Random();
        public char skin = 'G';
        public direction dir;
        public char field = Map.empty;
        public int x, y;
        public bool standingOnPoint = false;
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

        public Ghost(int x, int y, char skinChar)
        {
            this.X = x;
            this.Y = y;
            this.skin = skinChar;
            field = Map.empty;
            dir = random.Next(0,1) == 1 ? direction.left : direction.right;
            Program.map.RenderChar(x, y, skin);
        }

        public void Move(direction Direction)
        {
            if (x > 27) x = 0;
            else if (x < 0) x = 27;

            Program.map.RenderChar(x, y, standingOnPoint ? Map.powerUp : field);
            standingOnPoint = false;
            if (Direction == direction.left)
            {
                x--;
            }
            else if (Direction == direction.right)
            {
                x++;
            }
            else if (Direction == direction.up)
            {
                y--;
            }
            else if (Direction == direction.down)
            {
                y++;
            }
            Program.map.RenderChar(x, y, skin);
        }

        public void Step()
        {
            var rendered = RenderAheadGhost(dir);
            if (rendered != Map.wall && rendered != Program.ghostSkin)
            {
                Move(dir);
                if (rendered == Map.powerUp)
                {
                    standingOnPoint = true;
                }
            }
            else
            {
                dir = (direction)random.Next(0, 4);
            }
        }

        public char RenderAheadGhost(direction Direction)
        {
            if (Direction == direction.left) return Program.map[x - 1, y];
            if (Direction == direction.right) return Program.map[x + 1, y];
            if (Direction == direction.up) return Program.map[x, y - 1];
            return Program.map[x, y + 1];
        }
    }
}