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
		
		string[] main_btn_text = new string[]
		{
			"start", "----", "leave"
		};
		
		void MainFormLoad(object sender, EventArgs e)
		{
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false; this.BackColor = Color.Black;
			this.BackgroundImage = space_background;
			this.KeyDown += MainFormKeyDown;
			
			space_pic.Size = new Size(this.Width / 3, this.Height / 3);
			space_pic.Name = "main_pic0";
			space_pic.Location = new Point(this.Width / 3, 50);
			space_pic.BackColor = Color.Transparent;
			space_pic.SizeMode = PictureBoxSizeMode.StretchImage;
			space_pic.Load("battleship.png");
			space_pic.Parent = this;
			
			for (int i = 0; i < 3; i++)
			{
				Button btn = new Button();
				btn.Name = "main_button" + i.ToString();
				btn.Tag = main_btn_text[i];
				btn.Location = new Point(this.Width / 2 - 125, 350 + (80 * i + 1));
				btn.Text = main_btn_text[i].ToUpper(); btn.ForeColor = Color.White;
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
					for (int i = 0; i < 4; i++)
					{
						if (i < 3)
						{
							Button control = ObjectSearch("main_button" + i.ToString()) as Button;
							control.Visible = false; control.Enabled = false;
						}
						else
						{
							PictureBox control = ObjectSearch("main_pic0") as PictureBox;
							control.Visible = false; control.Enabled = false;
						}
					}
					break;
					
				case "----":
					break;
					
				case "leave":
					Application.Exit();
					break;
			}
		}
		
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			
		}
		
		object ObjectSearch(string name)
		{
			foreach (Control control in this.Controls)
			{
				if (control.Name.Contains(name))
				{
					return control;
				}
			}
			
			return null;
		}
	}
}
