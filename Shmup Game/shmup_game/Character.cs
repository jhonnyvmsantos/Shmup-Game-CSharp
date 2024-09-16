using System;
using System.Drawing;
using System.Windows.Forms;

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
		}
				
		Random rnd = new Random();
		
		public int life_points = 1;
		public int power = 1;
		public int speed = 4;
		public int accumulator, cooldown;
	}
}
