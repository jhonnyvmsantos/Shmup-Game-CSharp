using System;
using System.Drawing;
using System.Windows.Forms;

namespace shmup_game
{
	public class Laser : PictureBox
	{
		public Laser()
		{
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
			Height = 35;
			Width = 35;
			lTimer.Interval = 20;
			lTimer.Tick += LaserTimer;
			lTimer.Start();
		}
		
		public int power, speed;
		public bool player;
		public Timer lTimer = new Timer();
			
		void LaserTimer(object sender, EventArgs e)
		{
			if (player == true)
			{
				this.Top -= speed;
			}
			
			if (player == false)
			{
				this.Top += speed;
			}
			
			if (this.Top <= 0 || this.Top >= this.Parent.Height)
			{
				lTimer.Stop();
				this.Dispose();
			}
		}
	}
}
