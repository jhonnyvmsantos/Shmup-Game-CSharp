using System;
using System.Windows.Forms;

namespace shmup_game
{
	public class Hero : Character
	{
		public Hero()
		{
			Load("space.png");
			speed = 20;
			life_points = 3;
			power = 2;
			cooldown = 75;
		}
	}
}
