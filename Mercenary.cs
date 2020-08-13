using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheWinterContingency
{
    class Mercenary
    {
        public int x, y, width, height;//variables for the rectangle
        public Image mercenary;//variable for the spaceship's image

        public Rectangle mercRec;//variable for a rectangle to place our image in

        //Create a constructor (initialises the values of the fields)
        public Mercenary()
        {
            x = 250;
            y = 440;
            width = 40;
            height = 40;
            mercenary = Properties.Resources.Soldier_1;
            mercRec = new Rectangle(x, y, width, height);
        }

        public void drawMercenary(Graphics g)
        {
            g.DrawImage(mercenary, mercRec);
        }

        public void moveMercenary(int mouseX)
        {
            mercRec.X = mouseX - (mercRec.Width / 2);
        }

    }
}
