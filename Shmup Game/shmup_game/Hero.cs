using System;
using System.Windows.Forms;

namespace shmup_game
{
	public class Hero : Character
	{
		public Hero()
		{
			Load("battleship.png");
			speed = 20;
			life_points = 3;
			power = 2;
			cooldown = 75;
			Height = 75;
			Width = 75;
		}
		
		public void right() {
			Left += speed + 10;
		}
		
		public void left() {
			Left -= speed + 10;
		}
		
		public void down() {
			Top += speed + 5;
		}
		
		public void top() {
			Top -= speed + 5;
		}
	}
}
