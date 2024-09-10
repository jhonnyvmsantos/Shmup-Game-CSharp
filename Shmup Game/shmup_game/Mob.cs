using System;
using System.Windows.Forms;

namespace shmup_game
{
	public class Mob : Character
	{
		public Mob()
		{
			Load("space_mob.png");
			mtimer.Interval = 60;
			mtimer.Tick += MobTimer;
		}
		
		public Timer mtimer = new Timer();
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
		}
	}
}
