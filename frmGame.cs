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
        Alien[] alien = new Alien[11];
        int score, lives;




        public frmGame()
        {
            InitializeComponent();
            for (int i = 0; i < 11; i++)
            {
                int x = 10 + (i * 75);
                alien[i] = new Alien(x);

            }

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlGame, new object[] { true });
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            tmrAlien.Enabled = true;
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
            foreach (Alien p in alien)
            {
                p.draw(g);//Draw the planet
                p.MoveAlien(g);//move the planet
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
          
                foreach (Alien p in alien)
                {

                    foreach (Bullet m in bullets)
                    {
                        if (p.alienRec.IntersectsWith(m.bulletRec))
                        {
                        p.y = -20;// relocate planet to the top of the form
                        score += 1;//update the score
                        lblScore.Text = score.ToString();// display score

                        bullets.Remove(m);
                            break;
                        }

                    }

                }
                 

            pnlGame.Invalidate();

        }

        private void tmrAlien_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 11; i++)
            {
                if (mercenary.mercRec.IntersectsWith(alien[i].alienRec))
                {
                    //reset planet[i] back to top of panel
                    alien[i].y = 30; // set  y value of planetRec
                    lives -= 1;// lose a life
                    lblLives.Text = lives.ToString();// display number of lives
                    CheckLives();
                }
                //if a planet reaches the bottom of the Game Area reposition it at the top
                if (alien[i].y >= pnlGame.Height)
                {
                    alien[i].y = 30;
                }

            }
            pnlGame.Invalidate();//makes the paint event fire to redraw the panel
        }

        private void CheckLives()
        {
            if (lives == 0)
            {
                
                MessageBox.Show("Game Over");

            }
        }




        }
    }
