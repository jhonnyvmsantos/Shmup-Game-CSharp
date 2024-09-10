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
			
		}
		
		public void RightDir() {
			Left += speed;
		}
		
		public void LeftDir() {
			Left -= speed;
		}
		
		public void DownDir() {
			Top += speed;
		}
		
		public void TopDir() {
			Top -= speed;
		}
	}
}
