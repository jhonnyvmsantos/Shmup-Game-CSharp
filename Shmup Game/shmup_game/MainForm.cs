using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace shmup_game
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		Bitmap space_background = new Bitmap("space.png");
		PictureBox space_pic = new PictureBox();
		Random rnd = new Random();
		
		void MainFormLoad(object sender, EventArgs e)
		{
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false; this.BackColor = Color.Black;
			this.BackgroundImage = space_background;
			
			space_pic.Size = new Size(this.Width / 3, this.Height / 3);
			space_pic.Location = new Point(this.Width / 3, 50);
			space_pic.BackColor = Color.Transparent;
			space_pic.SizeMode = PictureBoxSizeMode.StretchImage;
			space_pic.Load("battleship.png");
			space_pic.Parent = this;
			
			for (int i = 0; i < 2; i++)
			{
				Button btn = new Button();
				btn.Name = "main_button" + i.ToString();
				btn.Tag = (i == 0) ? "start" : "leave";
				btn.Location = new Point(this.Width / 2 - 125, 350 + (100 * i + 1));
				btn.Text = (i == 0) ? "START" : "LEAVE"; btn.ForeColor = Color.White;
				btn.Font = new Font(FontFamily.GenericMonospace, 16f);
				btn.BackgroundImage = space_background;
				btn.Size = new Size(250, 50);
				btn.Click += MainButtonClick;
				btn.Parent = this;
				
				btn.TabStop = false;
			}
		}
		
		void MainButtonClick(object sender, EventArgs e)
		{
			Button btn = sender as Button;
			
			switch (btn.Tag.ToString())
			{
				case "start":
					break;
					
				case "leave":
					break;
			}
		}
	}
}
