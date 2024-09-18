using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace shmup_game
{
	public class Character : PictureBox
	{
		public Character()
		{
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
			Size = new Size(50, 50);
			cooldown = rnd.Next(60, 71);
			hTimer.Interval = 20;
			hTimer.Tick += HittingTimer;
			hTimer.Start();
		}
				
		Random rnd = new Random();
		Timer hTimer = new Timer();
		
		public int accumulator, cooldown;
		public int lifes = 1;
		public int power = 1;
		public int speed = 4;
		public bool hit, dead;
		
		void HittingTimer(object sender, EventArgs e)
		{
			foreach (Laser laser in MainForm.listPower.Items)
			{
				if (laser.Bounds.IntersectsWith(this.Bounds))
				{
					laser.lTimer.Stop(); laser.Dispose(); 
					hit = true; CharHitting();
					break;
				}
			}
		}
		
		async public void CharHitting()
		{
			if (hit == true && lifes > 1)
			{
				for (int i = 0; i < 5; i++)
				{
					this.Visible = false;
					await Task.Delay(250);
					this.Visible = true;
					await Task.Delay(250);
				}
				
				hit = false;
			}
			else
			{
				this.hTimer.Stop();
				dead = true;
			}
		}
	}
}
