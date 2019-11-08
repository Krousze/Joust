using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace Joust
{
    public class Render
    {
        public void DrawScreen(CellState[,] gameState, int height, int width)
        {
            StringBuilder borders = new StringBuilder("", height * width); //builds the 2d array takes in the method creating the bounds and the floor and the ceiling and the platform.
            char character = Convert.ToChar(32);
            for (int y = 0; y < 62; y++)
            {
                character = NewMethod(gameState, height, width, borders, character, y);
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(borders);
        }

        public static char NewMethod(CellState[,] gameState, int height, int width, StringBuilder borders, char character, int y)//method to pass in all the play area parameters
        {
            for (int x = 0; x < 238; x++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (y <= 3)
                    character = '█'; //creates the ceiling
                if (y >= 51 && y < 62)
                    character = '█'; //creates the floor
                if (y == 27)
                {
                    for (int i = 80; i < 152; i++)
                    {
                        Game.state[27, i] = CellState.Landing; //Creates the Platform
                        Game.state[28, i] = CellState.Landing; //Creates the Platform
                    }
                }
                if (y >= 3 && y < 62 - 10)      //sets usable space from the ground up and from the ceiling down
                {
                    switch (gameState[y, x])
                    {
                        case (CellState.Empty):
                            character = Convert.ToChar(32);
                            break;
                        case (CellState.Landing):
                            character = '█';
                            break;
                        case (CellState.Impaler):
                            character = 'X';
                            break;
                        case (CellState.Enemy):
                            character = 'O';
                            break;
                    }
                }
                borders.Append(new char[] { character });
            }
            return character;
        }
    }
}