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
using System.Media;

namespace TheWinterContingency
{
    public partial class frmGame : Form
    {
        int ammo = 5;
        Graphics g; //declare a graphics object called g
        Mercenary mercenary = new Mercenary();//create object called spaceship 
        //declare a list  missiles from the missile class
        List<Bullet> bullets = new List<Bullet>();
        Alien[] alien = new Alien[11];
        int score;
        int time = 120;
        bool turnRight, turnLeft;


        public frmGame(string playerName)
        {
            // get name and score from frmGame and show in lblPlayerName and lblPlayerScore         

            InitializeComponent();
            for (int i = 0; i < 11; i++)
            {
                int x = 10 + (i * 75);
                alien[i] = new Alien(x);

            }
            lblPlayername.Text = playerName;
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlGame, new object[] { true });
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            SoundPlayer player2 = new SoundPlayer(@"h:\301 Computer Science\AS91906 - Programming\WC Design\GameOST1.wav");
            player2.Play();
            lblAmmo.Text = ammo.ToString();// display score
            tmrBullet.Enabled = true;
            tmrMercenary.Enabled = true;
            tmrTime.Enabled = true;
            tmrAlien.Enabled = true;
            Cursor.Hide();
        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            mercenary.drawMercenary(g);
            foreach (Bullet m in bullets)
            {
                m.drawBullet(g);
                m.moveBullet(g);

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
            mercenary.moveMercenary(e.X, e.Y);
        }

        private void pnlGame_MouseDown(object sender, MouseEventArgs e)
        {
            if (ammo > 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    SoundPlayer player = new SoundPlayer(@"h:\301 Computer Science\AS91906 - Programming\WC Design\GunSound_1.wav");
                    player.Play();
                    bullets.Add(new Bullet(mercenary.mercRec, mercenary.rotationAngle));
                    ammo -= 1;
                    lblAmmo.Text = ammo.ToString();// display score
                }

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
                    score -= 5;// lose a life
                    lblScore.Text = score.ToString();// display number of lives
                    Checkscore();
                }
                //if a planet reaches the bottom of the Game Area reposition it at the top
                if (alien[i].y >= pnlGame.Height)
                {
                    alien[i].y = 30;
                }

            }
            pnlGame.Invalidate();//makes the paint event fire to redraw the panel
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            time -= 1;
            lblTime.Text = time.ToString();
            Checkscore();
        }

        private void Checkscore()
        {
            if (score < 0)
            {
                tmrAlien.Enabled = false;
                tmrBullet.Enabled = false;
                tmrTime.Enabled = false;
                tmrMercenary.Enabled = false;
                MessageBox.Show("Game Over");

                Hide();
                Cursor.Show();

            }
            if (time == 0)
            {
                tmrAlien.Enabled = false;
                tmrBullet.Enabled = false;
                tmrTime.Enabled = false;
                tmrMercenary.Enabled = false;
                MessageBox.Show("Game Over");

                Hide();
                Cursor.Show();

            }
            if (ammo == 0)
            {
                lblAmmo.Text = "Reloading";
                tmrAmmo.Enabled = true;

            }
        }

        private void tmrMercenary_Tick(object sender, EventArgs e)
        {
            Invalidate();
            if (turnRight)
            {
                mercenary.rotationAngle += 20;
            }
            if (turnLeft)
                mercenary.rotationAngle -= 20;
            {
            }

        }

        private void frmGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { turnLeft = false; }
            if (e.KeyData == Keys.Right) { turnRight = false; }

        }

        private void tmrAmmo_Tick(object sender, EventArgs e)
        {
            ammo = 5;
            tmrAmmo.Enabled = false;
        }

        private void frmGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { turnLeft = true; }
            if (e.KeyData == Keys.Right) { turnRight = true; }

        }
    }
}
