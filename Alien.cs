﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TheWinterContingency
{
    class Alien
    {
        // declare fields to use in the class

        public int x, y, width, height;//variables for the rectangle
        public Matrix matrixalien;
        public Image alienImage;//variable for the planet's image
        public Rectangle alienRec;//variable for a rectangle to place our image in

        //Create a constructor (initialises the values of the fields)
        public Alien(int displacement)
        {
            x = displacement;
            y = 10;
            width = 30;
            height = 30;
            alienImage = Properties.Resources.Alien_1;
            alienRec = new Rectangle(x, y, width, height);
        }

        // Methods for the Planet class
        public void draw(Graphics g)
        {
            alienRec = new Rectangle(x, y, width, height);
            matrixalien = new Matrix();
            g.Transform = matrixalien;
            g.DrawImage(alienImage, alienRec);
        }
        public void MoveAlien(Graphics g)
        {
            y += 5;
            alienRec.Location = new Point(x, y);

        }

    }
}
