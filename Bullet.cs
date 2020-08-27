using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TheWinterContingency
{
    class Bullet
    {
        public int x, y, width, height;
        public int bulletRotated;
        public double xSpeed, ySpeed;
        public Image bullet;//variable for the missile's image
        public Rectangle bulletRec;//variable for a rectangle to place our image in
        public Matrix matrixBullet;//matrix to enable us to rotate missile in the same angle as the spaceship
        Point centreBullet;//centre of missile
        // in the following constructor we pass in the values of spaceRec and the rotation angle of the spaceship
        // this gives us the position of the spaceship which we can then use to place the
        // missile where the spaceship is located and at the correct angle
        public Bullet(Rectangle mercRec, int bulletRotate)
        {
            width = 5;
            height = 10;
            bullet = Properties.Resources.Bullet_1;
            bulletRec = new Rectangle(x, y, width, height);
            //this code works out the speed of the missile to be used in the moveMissile method
            xSpeed = 30 * (Math.Cos((bulletRotate - 90) * Math.PI / 180));
            ySpeed = 30 * (Math.Sin((bulletRotate + 90) * Math.PI / 180));
            //calculate x,y to move missile to middle of spaceship in drawMissile method
            x = mercRec.X + mercRec.Width / 2;
            y = mercRec.Y + mercRec.Height / 2;
            //pass missileRotate angle to missileRotated so that it can be used in the drawMissile method
            bulletRotated = bulletRotate;

        }

        public void drawBullet(Graphics g)
        {
            //centre missile 
            centreBullet = new Point(x, y);
            //instantiate a Matrix object called matrixMissile
            matrixBullet = new Matrix();
            //rotate the matrix (in this case missileRec) about its centre
            matrixBullet.RotateAt(bulletRotated, centreBullet);
            //Set the current draw location to the rotated matrix point i.e. where missileRec is now
            g.Transform = matrixBullet;
            //Draw the missile
            g.DrawImage(bullet, bulletRec);

        }
        public void moveBullet(Graphics g)
        {
            x += (int)xSpeed;//cast double to an integer value
            y -= (int)ySpeed;
            bulletRec.Location = new Point(x, y);//missiles new location

        }


    }
}
