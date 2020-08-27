using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TheWinterContingency
{
    class Mercenary
    {
        public int x, y, width, height;//variables for the rectangle
        public Image mercenary;//variable for the spaceship's image
        public int rotationAngle;
        public Matrix matrix;
        public Point centre;

        public Rectangle mercRec;//variable for a rectangle to place our image in

        //Create a constructor (initialises the values of the fields)
        public Mercenary()
        {
            x = 250;
            y = 440;
            width = 40;
            height = 40;
            rotationAngle = 0;
            mercenary = Properties.Resources.Soldier_1;
            mercRec = new Rectangle(x, y, width, height);
        }

        public void drawMercenary(Graphics g)
        {
            //find the centre point of spaceRec
            centre = new Point(mercRec.X + width / 2, mercRec.Y + width / 2);
            //instantiate a Matrix object called matrix
            matrix = new Matrix();
            //rotate the matrix (spaceRec) about its centre
            matrix.RotateAt(rotationAngle, centre);
            //Set the current draw location to the rotated matrix point
            g.Transform = matrix;
            //draw the spaceship
            g.DrawImage(mercenary, mercRec);
        }

        public void moveMercenary(int mouseX, int mouseY)
        {
            mercRec.X = mouseX - (mercRec.Width / 2);
            mercRec.Y = mouseY - (mercRec.Height / 2);

        }


    }
}
