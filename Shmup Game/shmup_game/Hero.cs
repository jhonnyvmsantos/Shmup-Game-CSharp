using System;
using System.Windows.Forms;
using System.Drawing;

namespace shmup_game
{
	public class Hero : Character
	{
		public Hero()
		{
			Load("battleship.png");
			Size = new Size(40, 40);
			speed = 5;
			lifes = 3;
			power = 2;
			cooldown = 40;
			accumulator = 40;
			hTimer.Interval = 20;
			hTimer.Tick += HeroTimer;
		}
		
		public Timer hTimer = new Timer();
		
		void HeroTimer(object sender, EventArgs e)
		{		
			if (MainForm.pressedKeys[0] == true && this.Left <= this.Parent.Width - 100)
			{
				RightDir();
			}
			
			if (MainForm.pressedKeys[1] == true && this.Left >= 20)
			{
				LeftDir();
			}
			
			if (MainForm.pressedKeys[2] == true && this.Top >= this.Parent.Height / 2 - 100)
			{
				UpDir();
			}
			
			if (MainForm.pressedKeys[3] == true && this.Top <= this.Parent.Height - 150)
			{
				DownDir();
			}
			
			if (MainForm.pressedKeys[4] == true && accumulator >= cooldown)
			{
				ComumShoot();
				accumulator = 0;
			}
			else if (accumulator < cooldown)
			{
				accumulator++;
			}
			
			if (dead == true)
			{
				this.hTimer.Stop();
				this.Dispose();
			}
		}
		
		public void RightDir() 
		{
			Left += speed;
		}
		
		public void LeftDir() 
		{
			Left -= speed;
		}
		
		public void UpDir()
		{
			Top -= speed;
		}
		
		public void DownDir() 
		{
			Top += speed;
		}
		
		public void ComumShoot()
		{
			Laser laser = new Laser();
			laser.Name = "laser"; laser.Tag = "player";
			laser.Location = new Point(this.Left + 5, this.Top - 50);
			laser.Load("lasers/player/laser_comum.png");
			laser.speed = speed;
			laser.Parent = this.Parent;
		}
	}
}
