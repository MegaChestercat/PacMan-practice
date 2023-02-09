using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using WiimoteLib;

namespace PacMan
{
    public partial class Level2 : Form
    {

        static Map map;
        private Bitmap bmp;
        static Graphics g;
        static System.Drawing.Brush negro, amarillo, blanco, rojo, azul;
        Sound sounds = new Sound();
        char c;

        public List<System.Drawing.PointF> coins = new List<System.Drawing.PointF>();

        int score = 0;
        int lives = 3;
        System.Drawing.Point spawnPoint;

        String currentDirection = "None";

        Wiimote wm = new Wiimote();

        public Level2()
        {
            InitializeComponent();
            
            Init();
            gameInitialize();
        }

        private void Init()
        {

            map = new Map("mtx2.mx");
            bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            PCT_CANVAS.Image = bmp;
            g = Graphics.FromImage(bmp);

            negro = new SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0));
            azul = new SolidBrush(System.Drawing.Color.FromArgb(0, 0, 255));
            amarillo = new SolidBrush(System.Drawing.Color.FromArgb(239, 184, 16));
            rojo = new SolidBrush(System.Drawing.Color.FromArgb(255, 0, 0));
            blanco = new SolidBrush(System.Drawing.Color.FromArgb(255, 255, 255));

            for (int x = 0; x < 59; x++)
                for (int y = 0; y < 65; y++)
                {
                    InitRectangle(x, y);
                }

            g.DrawRectangle(Pens.Gray, 0, 0, bmp.Width - 1, bmp.Height - 1);

            spawnPoint = pictureBox1.Location;


        }

        private void InitRectangle(int x, int y)
        {
            c = map.map[x, y];


            switch (c)
            {
                case 'N':
                    g.FillRectangle(negro, x * 10, y * 10, 10, 10);
                    break;
                case 'B':
                    g.FillRectangle(blanco, x * 10, y * 10, 10, 10);
                    break;
                case 'A':
                    g.FillRectangle(amarillo, x * 10, y * 10, 10, 10);
                    coins.Add(new System.Drawing.PointF(x * 10, y * 10));
                    break;
                case 'a':
                    g.FillRectangle(azul, x * 10, y * 10, 10, 10);
                    break;
                case 'R':
                    g.FillRectangle(rojo, x * 10, y * 10, 10, 10);
                    break;
                default:
                    g.FillRectangle(negro, x * 10, y * 10, 10, 10);
                    break;
            }
            PCT_CANVAS.Invalidate();
        }

         async private void gameInitialize()
        {
            sounds.playStartSound();
          
            await Task.Delay(500);

            DrawCharacters();
            await Task.Delay(4500);
            sounds.playEatingSound();

        }

        private void DrawCharacters()
        {
            pictureBox1.Image = Resource1.pacman_right;
            blueGhost.Image = Resource1.blue;
            redGhost.Image = Resource1.red;
            pinkGhost.Image = Resource1.pink;
            orangeGhost.Image = Resource1.orange;
        }

        private void CheckForCoins()
        {
            System.Drawing.PointF currentPos = new System.Drawing.PointF(pictureBox1.Left + (pictureBox1.Width / 2), pictureBox1.Top + (pictureBox1.Height / 2));

            for (int i = coins.Count - 1; i >= 0; i--)
            {
                System.Drawing.PointF coinPos = coins[i];
                if (Math.Abs(currentPos.X - coinPos.X) < (pictureBox1.Width / 2) && Math.Abs(currentPos.Y - coinPos.Y) < (pictureBox1.Height / 2))
                {
                    g.FillRectangle(negro, (int)coinPos.X, (int)coinPos.Y, 10, 10);
                    coins.RemoveAt(i);
                    score++;
                    Score_Label.Text = "Score: " + score;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    pictureBox1.Image = Resource1.pacman_left;
                    currentDirection = "left";
                    break;

                case Keys.Right:
                    pictureBox1.Image = Resource1.pacman_right;
                    currentDirection = "right";
                    break;

                case Keys.Up:
                    pictureBox1.Image = Resource1.pacman_up;
                    currentDirection = "up";
                    break;

                case Keys.Down:
                    pictureBox1.Image = Resource1.pacman_down;
                    currentDirection = "down";
                    break;
                case Keys.Space:
                    break;
            }
        }

        private void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs args)
        {
            if (wm.WiimoteState.ButtonState.Right == true)
            {
                pictureBox1.Image = Resource1.pacman_up;
                currentDirection = "up";
            }
            else if (wm.WiimoteState.ButtonState.Left == true)
            {
                pictureBox1.Image = Resource1.pacman_down;
                currentDirection = "down";
            }
            else if (wm.WiimoteState.ButtonState.Up == true)
            {
                pictureBox1.Image = Resource1.pacman_left;
                currentDirection = "left";
            }
            else if (wm.WiimoteState.ButtonState.Down == true)
            {
                pictureBox1.Image = Resource1.pacman_right;
                currentDirection = "right";
            }
        }

        private void pacManMovement_Tick(object sender, EventArgs e)
        {
            CheckForCoins();
            label1.Text = "Lives: " + lives;
            if (lives == 0) gameOver();
            if (score == 254) win();


            switch (currentDirection)
            {
                case "left":
                    if (pictureBox1.Left - 8 > 0)
                    {
                        int newX = pictureBox1.Left - 8;
                        int newY = pictureBox1.Top;
                        if (!IsCharBAt(newX, newY)) pictureBox1.Left -= 8;
                        else {
                            pictureBox1.Left += 4;
                            currentDirection = "None";
                        }
                        if (pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds)) pictureBox1.Location = pictureBox2.Location;
                        ghostCollision();
                    }
                    break;
                case "right":
                    if (pictureBox1.Left + 8 < (this.Width - pictureBox1.Width))
                    {
                        int newX = pictureBox1.Left + 8;
                        int newY = pictureBox1.Top;
                        if (!IsCharBAt(newX, newY)) pictureBox1.Left += 8;
                        else 
                        {
                            pictureBox1.Left -= 4;
                            currentDirection = "None";
                        }
                        if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds)) pictureBox1.Location = pictureBox3.Location;

                        ghostCollision();
                    }
                    break;
                case "up":
                    if (pictureBox1.Top - 8 > 0)
                    {
                        int newX = pictureBox1.Left;
                        int newY = pictureBox1.Top - 8;
                        if (!IsCharBAt(newX, newY)) pictureBox1.Top -= 8;
                        else
                        {
                            pictureBox1.Top += 4;
                            currentDirection = "None";
                        }
                        ghostCollision();
                    }
                    break;
                case "down":
                    if (pictureBox1.Top + 8 < (this.Height - pictureBox1.Height))
                    {
                        int newX = pictureBox1.Left;
                        int newY = pictureBox1.Top + 8;
                        if (!IsCharBAt(newX, newY)) pictureBox1.Top += 8;
                        else
                        {
                            pictureBox1.Top -= 4;
                            currentDirection = "None";
                        }
                        ghostCollision();
                    }
                    break;
            }
            
        }

        private void Level2_Load(object sender, EventArgs e)
        {
            wm.WiimoteChanged += wm_WiimoteChanged;
            wm.Connect();
        }

        private void ghostCollision()
        {
            if (pictureBox1.Bounds.IntersectsWith(redGhost.Bounds) || pictureBox1.Bounds.IntersectsWith(blueGhost.Bounds) || pictureBox1.Bounds.IntersectsWith(pinkGhost.Bounds) || pictureBox1.Bounds.IntersectsWith(orangeGhost.Bounds))
            {
                lives--;
                pictureBox1.Visible = false;
                pictureBox1.Location = spawnPoint;
                currentDirection = "None";
                pictureBox1.Visible = true;
                sounds.playEatingSound();
            }
        }

        private bool IsCharBAt(int x, int y)
        {
            int mapX = x / 10;
            int mapY = y / 10;

            return map.map[mapX, mapY] == 'B';
        }

        private void gameOver()
        {
            pacManMovement.Enabled = false;
            sounds.playDeathSound();
            MessageBox.Show("You have no more lives left, you died.", "Game Over");
        }

        private void win()
        {
            if(lives == 3)
            {
                sounds.flawlessVictory();
                MessageBox.Show("Congratulations! You passed this level.", "You Win");
            }
            else
            {
                sounds.win();
                MessageBox.Show("Congratulations! You passed this level.", "You Win");
            }

            Level3 l3 = new Level3();
            l3.Show();
            this.Close();
        }

        

    }
}
