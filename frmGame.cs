using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace TheWinterContingency
{
    public partial class frmGame : Form
    {
        Graphics g; //declare a graphics object called g
        Mercenary mercenary = new Mercenary();//create object called spaceship 
        //declare a list  missiles from the missile class
        List<Bullet> bullets = new List<Bullet>();
        List<Alien> aliens = new List<Alien>();



        public frmGame()
        {
            InitializeComponent();
            for (int i = 0; i < 11; i++)
            {
                int displacement = 10 + (i * 70);
                aliens.Add(new Alien(displacement));
            }

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlGame, new object[] { true });
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            mercenary.drawMercenary(g);
            foreach (Bullet m in bullets)
            {
                m.draw(g);
            }
            foreach (Alien p in aliens)
            {
                p.draw(g);//Draw the planet
                p.moveAlien(g);//move the planet
                               //if the planet reaches the bottom of the form relocate it back to the top
                if (p.y >= ClientSize.Height)
                {
                    p.y = -20;
                }

            }



        }

        private void frmGame_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void pnlGame_MouseMove(object sender, MouseEventArgs e)
        {
            mercenary.moveMercenary(e.X);
        }

        private void pnlGame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bullets.Add(new Bullet(mercenary.mercRec));
            }

        }

        private void tmrBullet_Tick(object sender, EventArgs e)
        {
          
                foreach (Alien p in aliens)
                {

                    foreach (Bullet m in bullets)
                    {
                        if (p.alienRec.IntersectsWith(m.bulletRec))
                        {
                        p.y = -20;// relocate planet to the top of the form

                        bullets.Remove(m);
                            break;
                        }
                    }

                }
            
            pnlGame.Invalidate();

        }
    }
}
