using System;
using System.Windows.Forms;

namespace shmup_game
{
	public class Hero : Character
	{
		public Hero()
		{
			Load("battleship.png");
			speed = 7;
			life_points = 3;
			power = 2;
			cooldown = 75;
			htimer.Interval = 20;
			htimer.Tick += HeroTimer;
		}
		
		public Timer htimer = new Timer();
		
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
		}
		
		public void RightDir() {
			Left += speed;
		}
		
		public void LeftDir() {
			Left -= speed;
		}
		
		public void UpDir() {
			Top -= speed;
		}
		
		public void DownDir() {
			Top += speed;
		}
	}
}
