using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace TheWinterContingency
{
    public partial class frmHighScores : Form
    {
        string binPath = Application.StartupPath + @"\highscores.txt";
        List<HighScore> highScores = new List<HighScore>();

        public frmHighScores(string PlayerName, string PlayerScore)
        {
            InitializeComponent();
            lblPlayername.Text = PlayerName;
            lblPlayerscore.Text = PlayerScore;
            var reader = new StreamReader(binPath);
            // While the reader still has something to read, this code will execute.
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                // Split into the name and the score.
                var values = line.Split(',');
                highScores.Add(new HighScore(values[0], Int32.Parse(values[1])));

            }
            reader.Close();

        }
        public void DisplayHighScores()
        {
            foreach (HighScore s in highScores)
            {
                lstBoxName.Items.Add(s.Name);
                lstBoxScore.Items.Add(s.Score);

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SaveHighScores();
            frmMenu frmMenu2 = new frmMenu();
            Hide();
            frmMenu2.ShowDialog();
        }

        private void frmHighScores_Load(object sender, EventArgs e)
        {
            int lowest_score = highScores[(highScores.Count - 1)].Score;
            if (int.Parse(lblPlayerscore.Text) > lowest_score)
            {
                lblMessage.Text = "You have made the Top Ten! Well Done!";
            }
            else
            {
                lblMessage.Text = "Keep trying to make the top ten!";
            }
            SortHighScores();
            DisplayHighScores();
        }
        public void SortHighScores()
        {
            highScores = highScores.OrderByDescending(hs => hs.Score).Take(10).ToList();
        }
        public void SaveHighScores()
        {
            StringBuilder builder = new StringBuilder();
            foreach (HighScore score in highScores)
            {
                //{0} is for the Name, {1} is for the Score and {2} is for a new line
                builder.Append(string.Format("{0},{1}{2}", score.Name, score.Score, Environment.NewLine));
            }
            File.WriteAllText(binPath, builder.ToString());
        }


    }
}
