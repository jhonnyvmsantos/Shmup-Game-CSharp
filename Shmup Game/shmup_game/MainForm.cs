using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace shmup_game
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		PictureBox space_pic = new PictureBox();
		Random rnd = new Random();
		
		void MainFormLoad(object sender, EventArgs e)
		{
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false; this.BackColor = Color.Black;
			this.BackgroundImage = new Bitmap("space.gif");
			
			space_pic.Size = new Size(this.Width / 3, this.Height / 3);
			space_pic.Location = new Point(this.Width / 3, 50);
			space_pic.BackColor = Color.Transparent;
			space_pic.SizeMode = PictureBoxSizeMode.StretchImage;
			space_pic.Load("battleship.png");
			space_pic.Parent = this;
		}
	}
}
