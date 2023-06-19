using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masking_Effects_Application_MOO_ICT
{
    internal class Circle
    {
        public Rectangle circle = new Rectangle();
        public int positionX = 0;
        public int positionY = 0;
        public int speedX = 0;
        public int speedY = 0;
        Random rand = new Random();

        public Circle()
        {
            circle.Width = 100;
            circle.Height = 100;

            speedX = rand.Next(-5, 5);
            speedY = rand.Next(1, 5);
        }

    }
}
