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
    class Program
    {
        static void Main()
        {
            int width = 238;
            int height = 62;
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(width, height + 1);
            Console.SetWindowSize(width, height + 1);
            Console.SetCursorPosition(0, 0);

            WelcomeStartGame(); // Runs method to start the game
            Game game = new Game();
            do
            {
                game.PlayGame(height, width);
            } while (game.PlayAgain);
        }
        private static void WelcomeStartGame() //Takes in input to start the game
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Press Y then Enter to start the game.");

            char theKey = (char)Console.Read();


            if (theKey == 'y' || theKey == 'Y')
            {
                Console.Clear();
                Console.Write("Welcome To Console Joust");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
                Console.Write("Error");
        }
    }
}