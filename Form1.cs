using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shoot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        PictureBox[] bullets1 = new PictureBox[10];
        PictureBox[] bullets2 = new PictureBox[10];
        private void Form1_Load(object sender, EventArgs e)
        {
            create();
            player.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            player2.BackgroundImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
        }

        private int i = 0;
        private void create()
        {
            PictureBox bullet = new PictureBox()
            {
                Name = "bullet",
                Size = new Size(10, 5),
                BackColor = Color.Red,
                Location = new Point(player.Location.X + 30, player.Location.Y + 30),
            };
            PictureBox bullet2 = new PictureBox()
            {
                Name = "bullet",
                Size = new Size(10, 5),
                BackColor = Color.Blue,
                Location = new Point(player2.Location.X - 25, player2.Location.Y + 30),
                Visible = true,
            };
            bullets1[i] = bullet;
            bullets2[i] = bullet2;
            this.Controls.Add(bullets1[i]);
            this.Controls.Add(bullets2[i]);
            i++;
            if(i == 3)
            {
                i = 0;
            }
        }
        private int c = 0;
        private bool down = false, up = false,left = false, right = false,down2 = false, up2 = false, right2 = false, left2 = false;

        private void timer2_Tick(object sender, EventArgs e)
        {
            create();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                up2 = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                down2 = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                left2 = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                right2 = true;
            }
            //////////////////////////////////////////
            else if (e.KeyCode == Keys.W)
            {
                up = true;
            }
            else if (e.KeyCode == Keys.S)
            {
                down = true;
            }
            else if (e.KeyCode == Keys.A)
            {
                left = true;
            }
            else if (e.KeyCode == Keys.D)
            {
                right = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                up2 = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                down2 = false;
            }
            else if (e.KeyCode == Keys.Left)
            {
                left2 = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                right2 = false;
            }
            /////////////
            else if (e.KeyCode == Keys.W)
            {
                up = false ;
            }
            else if (e.KeyCode == Keys.S)
            {
                down = false;
            }
            else if (e.KeyCode == Keys.A)
            {
                left = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                right = false;
            }

        }
        Random r = new Random();
        int x1 = 0, x2 = 0;
        bool ok = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            ok = true;
            for(int i = 0; i < bullets1.Length; i++)
            {
                if (bullets1[i]!=null)
                {
                    if(bullets1[i].Left + 10 > player2.Left&&bullets1[i].Top+5>player2.Top&&bullets1[i].Top<player2.Top+player2.Height&&bullets1[i].Left + 10<player2.Left + 8 )
                    {
                        this.Controls.Remove(bullets1[i]);
                        bullets1[i].Dispose();
                        bullets2[i].Visible = false;
                        x1++;
                        label1.Text = x1.ToString();
                        ok = false;
                    }
                    bullets1[i].Left += 7;
                    if (bullets1[i].Left > 600)
                    {
                        this.Controls.Remove(bullets1[i]);
                        bullets1[i].Dispose();
                        bullets2[i].Visible = false;

                    }
                }
                if (bullets2[i] != null)
                {
                    if (bullets2[i].Left < player.Left +125 && bullets1[i].Top + 5 > player2.Top && bullets1[i].Top < player2.Top + player2.Height && bullets2[i].Left>player.Left + 117)
                    {
                        this.Controls.Remove(bullets2[i]);
                        bullets2[i].Dispose();
                        bullets2[i].Visible = false;
                        x2++;
                        label2.Text = x2.ToString();
                    }
                    bullets2[i].Left -= 7;
                    if (bullets2[i].Left <5)
                    {
                        bullets2[i].Visible = false;
                        this.Controls.Remove(bullets2[i]);
                        bullets2[i].Dispose();
                          
                    }
                }

            }
            if(up == true)
            {
                player.Top -= 5;
            }else if(down == true)
            {
                player.Top += 5;
            }
            else if (left == true)
            {
                player.Left -= 5;
            }
            else if (right == true)
            {
                player.Left += 5;
            }


            if (up2 == true)
            {
                player2.Top -= 5;
            }
            else if (down2 == true)
            {
                player2.Top += 5;
            }
            else if (left2 == true)
            {
                player2.Left -= 5;
            }
            else if (right2 == true)
            {
                player2.Left += 5;
            }
        }
    }
}
