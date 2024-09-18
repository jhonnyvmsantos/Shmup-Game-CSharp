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
			Size = new Size(35, 35);
			lTimer.Interval = 20;
			lTimer.Tick += LaserTimer;
			lTimer.Start();
			MainForm.listPower.Items.Add(this);
		}
		
		public int power, speed;
		public Timer lTimer = new Timer();
			
		void LaserTimer(object sender, EventArgs e)
		{
			if (this.Tag.ToString() == "player")
			{
				this.Top -= speed * 3;
			} 
			
			if (this.Tag.ToString() == "mob")
			{
				this.Top += speed * 2;
			}
			
			if (this.Top <= 0 || this.Top >= this.Parent.Height)
			{
				lTimer.Stop();
				this.Dispose();
				MainForm.listPower.Items.Remove(this);
			}
		}
	}
}
