using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Joust
{
    public enum CellState { Empty, Landing, Impaler, Enemy };

    public class Game
    {
        public Block playerBlock = new Block(69, 21, Console.ForegroundColor);
        public Block player2Block = new Block(169, 21, Console.ForegroundColor);
        //public static object Sync = new Object();
        //public static Rectangle jouster = new Rectangle(120, 21, width: 2, height: 3);
        public static CellState[,] state;
        public int HighScore { get; private set; }
        public bool PlayAgain { get; private set; }
        bool gameOver;
        int height;
        int width;
        Render render = new Render();
        Player player;
        Player player2;
        Timer gameTimer = new Timer(100);
        public Game()
        {
            player = new Player(69, 21);
            player2 = new Player(169, 21);
            gameTimer.Elapsed += new ElapsedEventHandler(GameLoop);
        }
        public void PlayGame(int height, int width)
        {
            gameTimer.Start();
            this.height = height;
            this.width = width;
            Console.CursorVisible = false;
            gameOver = false;
            do
            {
                //lock (Sync)
                //{
                    if (gameOver != true)
                    {
                        while (Console.KeyAvailable) Console.ReadKey(true);//empty's the input buffer
                        if (Console.KeyAvailable != true)
                        {
                            ConsoleKey action = Console.ReadKey().Key;//player Key input to move avatar
                            if (action == ConsoleKey.UpArrow)
                            {
                                player.MoveUp(2);
                            }
                            if (action == ConsoleKey.DownArrow)
                            {
                                player.MoveDown();
                            }
                            if (action == ConsoleKey.LeftArrow)
                            {
                                player.MoveLeft();
                            }
                            if (action == ConsoleKey.RightArrow)
                            {
                                player.MoveRight();
                            }
                            if (action == ConsoleKey.W)
                            {
                                player2.MoveUp(2);
                            }
                            if (action == ConsoleKey.S)
                            {
                                player2.MoveDown();
                            }
                            if (action == ConsoleKey.A)
                            {
                                player2.MoveLeft();
                            }
                            if (action == ConsoleKey.D)
                            {
                                player2.MoveRight();
                            }
                        }
                    }
                //}
                //            player2.Drop();
                //            player.Drop();
                //            Step();
                //            render.DrawScreen(state, height, width);
            }
            while (gameOver != true);
            Console.Clear();
            Console.SetCursorPosition(27, 27);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Game Over!");
            Console.ReadKey();
        }
        void Step()
        {
            state = new CellState[height, width];
            int PlayerX = player.getX();
            int PlayerY = player.getY();
            state[PlayerY, PlayerX] = CellState.Impaler;
            int Player2X = player2.getX();
            int Player2Y = player2.getY();
            state[Player2Y, Player2X] = CellState.Enemy;
            CheckCollision();
        }
        void CheckCollision()
        {
            //if (player.currentY  == Game.state || currrentY == /*platform - 1*/)
            //    currentY = /*platform + 1*/
            if (player.getX() == 236)
            {
                player.currentX -= 235;
            }
            if (player.getX() == 0)
            {
                player.currentX += 236;
            }
            if (player2.getX() >= 236)
            {
                player2.currentX -= 235;
            }
            if (player2.getX() == 0)
            {
                player2.currentX += 236;
            }
            if (player2.getY() > 28)
                player2.MoveUp(6);
        }
        public void GameLoop(Object source, ElapsedEventArgs e)
        {
            //lock (Sync)
            //{
                Step();
                render.DrawScreen(state, height, width);
            //}
        }
    }
}