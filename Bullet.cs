using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheWinterContingency
{
    class Bullet
    {
        public int x, y, width, height;

        public Image bullet;//variable for the missile's image

        public Rectangle bulletRec;//variable for a rectangle to place our image in

        // in the following constructor we pass in the values of spaceRec which
        // gives us the position of the spaceship which we can then use to place the
        // missile where the spaceship is located
        public Bullet(Rectangle mercRec)
        {
            x = mercRec.X + 18; // move missile to middle of spaceship
            y = mercRec.Y;
            width = 5;
            height = 10;
            bullet = Properties.Resources.Bullet_1;
            bulletRec = new Rectangle(x, y, width, height);
        }

        public void draw(Graphics g)
        {
            y -= 30;//speed of missile
            bulletRec = new Rectangle(x, y, width, height);
            g.DrawImage(bullet, bulletRec);
        }

    }
}
