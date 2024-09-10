using System;
using System.Windows.Forms;

namespace shmup_game
{
	public class Mob : Character
	{
		public Mob()
		{
			Load("space_mob.png");
			mtimer.Interval = 20;
			mtimer.Tick += MobTimer;
		}
		
		public Timer mtimer = new Timer();
		
		void MobTimer(object sender, EventArgs e)
		{
			
		}
	}
}
