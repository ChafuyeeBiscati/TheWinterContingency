namespace TheWinterContingency
{
    partial class frmGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.tmrBullet = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pnlGame
            // 
            this.pnlGame.BackColor = System.Drawing.Color.Transparent;
            this.pnlGame.Location = new System.Drawing.Point(0, 0);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(785, 537);
            this.pnlGame.TabIndex = 0;
            this.pnlGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGame_Paint);
            this.pnlGame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlGame_MouseDown);
            this.pnlGame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlGame_MouseMove);
            // 
            // tmrBullet
            // 
            this.tmrBullet.Enabled = true;
            this.tmrBullet.Interval = 30;
            this.tmrBullet.Tick += new System.EventHandler(this.tmrBullet_Tick);
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(784, 536);
            this.Controls.Add(this.pnlGame);
            this.Name = "frmGame";
            this.Text = "frmGame";
            this.Load += new System.EventHandler(this.frmGame_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmGame_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Timer tmrBullet;
    }
}