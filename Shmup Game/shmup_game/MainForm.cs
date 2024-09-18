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
		
		PictureBox spacePic = new PictureBox();
		Random rnd = new Random();
		
		public Hero hero = new Hero();
		public Mob mob = new Mob();
		static public ListBox listPower = new ListBox();
		
		static public bool[] pressedKeys = new bool[]
		{
			false, false, false, false, false
		};
		
		string[] main_btn_text = new string[]
		{
			"start", "----", "leave"
		};
		
		void MainFormLoad(object sender, EventArgs e)
		{
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false; this.BackColor = Color.Black;
			this.BackgroundImage = new Bitmap("space.png");
			this.KeyPreview = true;
			this.KeyDown += MainFormKeyDown;
			this.KeyUp += MainFormKeyUp;
			
			spacePic.Size = new Size(this.Width / 3, this.Height / 3);
			spacePic.Name = "main_pic0";
			spacePic.Location = new Point(this.Width / 3, 50);
			spacePic.BackColor = Color.Transparent;
			spacePic.SizeMode = PictureBoxSizeMode.StretchImage;
			spacePic.Load("battleship.png");
			spacePic.Parent = this;
			
			for (int i = 0; i < 3; i++)
			{
				Button btn = new Button();
				btn.Name = "main_button" + i.ToString();
				btn.Tag = main_btn_text[i];
				btn.Location = new Point(this.Width / 2 - 125, 350 + (80 * i + 1));
				btn.Text = main_btn_text[i].ToUpper(); btn.ForeColor = Color.White;
				btn.Font = new Font(FontFamily.GenericMonospace, 16f);
				btn.BackgroundImage = new Bitmap("space.png");;
				btn.Size = new Size(250, 50);
				btn.Click += MainButtonClick;
				btn.Parent = this;
				
				btn.TabStop = false;
			}
			
			this.DoubleBuffered = true;
   			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    		this.SetStyle(ControlStyles.UserPaint, true);
    		this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
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
					
					hero.Location = new Point(this.Width / 2 - 32, this.Height - 150);
					hero.Parent = this;
					hero.hTimer.Start();
					
					mob.Location = new Point(this.Width / 2 - 32, 50);
					mob.Parent = this;
					mob.mTimer.Start();
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
			e.SuppressKeyPress = true;
			
			if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) 
			{
				pressedKeys[0] = true;
			}
			
			if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) 
			{
				pressedKeys[1] = true;
			}
			
			if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up) 
			{
				pressedKeys[2] = true;
			}
			
			if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down) 
			{
				pressedKeys[3] = true;
			}
			
			if (e.KeyCode == Keys.Space)
			{
				pressedKeys[4] = true;
			}
		}
		
		void MainFormKeyUp(object sender, KeyEventArgs e)
        {		
			if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) 
			{
				pressedKeys[0] = false;
			}
			
			if (e.KeyCode == Keys.A || e.KeyCode == Keys.Up) 
			{
				pressedKeys[1] = false;
			}
			
			if (e.KeyCode == Keys.W || e.KeyCode == Keys.Left) 
			{
				pressedKeys[2] = false;
			}
			
			if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down) 
			{
				pressedKeys[3] = false;
			}
			
			if (e.KeyCode == Keys.Space)
			{
				pressedKeys[4] = false;
			}
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
