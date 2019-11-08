//Matt Juel's code
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Joust
{
    public class Block
    {

        //private Point position;
        private int x;
        private int y;
        private ConsoleColor color;
        private static int height = 2;
        private static int width = 3;
        private Point[] area;

        //public Point Position { set; get; }

        public ConsoleColor Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public Point[] GetArea()
        {
            return area;
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public static int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public static int Width
        {
            get
            {
                return width;
            }
        }


        public Block(int x, int y, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            area = new Point[height * (height * 2)];

        }




        //instantiates each point contained in the block

        public void Inflate()
        {

            int index = 0;
            int posX = x;
            int posY = y;

            for (int i = 0; i < height; i++)
            {
                posX = x;
                for (int j = 0; j < height * 2; j++)
                {
                    Point current = new Point(posX, posY);
                    area[index] = current;
                    index++;
                    posX++;
                }
                posY++;

            }
        }




        //Renders each point contained in the block

        public void Draw()
        {
            foreach (Point pt in area)
            {
                Console.SetCursorPosition(pt.X, pt.Y);
                Console.BackgroundColor = color;
                Console.Write(" ");
            }
            Console.ResetColor();
        }
    }
    public static class ShapeDictionary
    {
        public static Dictionary<int, int[]> zero = new Dictionary<int, int[]>()
        {
            {
                1, new int[25] {0, 0, 0, 0, 0,
                                0, 1, 1, 0, 0,
                                0, 1, 1, 0, 0,
                                0, 1, 1, 0, 0,
                                0, 0, 0, 0, 0}
            },
        };

        public static Dictionary<int, int[]> one = new Dictionary<int, int[]>()
        {
            {
                1, new int[25] {
                                0, 0, 0, 0, 0,
                                0, 1, 1, 0, 0,
                                0, 1, 1, 0, 0,
                                0, 1, 1, 0, 0,
                                0, 0, 0, 0, 0
                                }
            },
        };
    }
}