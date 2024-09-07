using System;
using System.Windows.Forms;

namespace shmup_game
{
	public class Character : PictureBox
	{
		public Character()
		{
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
			Height = 100;
			Width = 100;
		}
		
		public int life_points = 1;
		public int power = 1;
		public int speed = 10;
		public int cooldown = 50;
	}
}
