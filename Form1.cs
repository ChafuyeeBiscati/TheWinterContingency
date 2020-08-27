using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheWinterContingency
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            frmGame frmGame2 = new frmGame(txtName.Text);

            frmGame2.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnHighscore_Click_1(object sender, EventArgs e)
        {
            frmHighScores frmHighScore2 = new frmHighScores(txtName.Text, txtScore.Text);

            frmHighScore2.ShowDialog();
        }
    }
}
