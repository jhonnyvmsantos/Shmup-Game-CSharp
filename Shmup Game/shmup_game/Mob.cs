using System;
using System.Drawing;
using System.Windows.Forms;

namespace shmup_game
{
	public class Mob : Character
	{
		public Mob()
		{
			Load("space_mob.png");
			mTimer.Interval = 20;
			mTimer.Tick += MobTimer;
		}
		
		public Timer mTimer = new Timer();
		bool inverted;
		
		void MobTimer(object sender, EventArgs e)
		{
			if (this.Left <= this.Parent.Width - 100 && inverted == false)
			{
				this.Left += speed;
			} 
			else if (this.Left >= this.Parent.Width - 100)
			{
				inverted = true;
			}
			
			if (this.Left > 20 && inverted == true)
			{
				this.Left -= speed;
			} 
			else if (this.Left <= 20)
			{
				inverted = false;
			}
			
			if (accumulator >= cooldown)
			{
				ComumShoot();
				accumulator = 0;
			}
			else
			{
				accumulator++;
			}
			
			if (dead == true)
			{
				this.mTimer.Stop();
				this.Dispose();
			}
		}
		
		public void ComumShoot()
		{
			Laser laser = new Laser();
			laser.Name = "laser"; laser.Tag = "mob";
			laser.Location = new Point(this.Left, this.Top + 50);
			laser.Load("lasers/mob/laser_comum.png");
			laser.speed = speed;
			laser.Parent = this.Parent;
		}
	}
}
