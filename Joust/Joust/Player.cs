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
    public class Player
    {
        public int gravity = 1;
        public int currentX;
        public int currentY;
        private Timer timer = new Timer(100);
        public Player(int startingX, int startingY)
        {
            currentX = startingX;
            currentY = startingY;
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;
        }
        public int getX()
        {
            return currentX;
        }
        public int getY()
        {
            return currentY;
        }
        public void MoveUp(int d)
        {
            if ((getY() == 26 || getY() == 27) && (getX() >= 80 && getX() <= 152))
            {
                currentY = 28;
            }
            else
                currentY -= d;
        }
        public void MoveDown()
        {
            if ((getY() == 26 ||getY() == 27) && (getX() >= 80 && getX() <= 152))
            {
                currentY = 25;
            }
            else
                currentY += 1;
        }
        public void MoveLeft()
        {
            currentX -= 2;
        }
        public void MoveRight()
        {
            currentX += 2;
        }
        public void Drop()
        {
            if ((getY() == 26 || getY() == 27) && (getX() >= 80 && getX() <= 152))
                currentY = 25;
            if (currentY < 2)
                currentY = 2;
            if (currentY + gravity > 52 - 1)
                currentY = 51;
            else
            {
                currentY += gravity;
            }
        }
        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Drop();
        }
    }
}