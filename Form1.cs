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

namespace PacMan
{
    public partial class Form1 : Form
    {

        static Map map;
        private Bitmap bmp;
        static Graphics g;
        static System.Drawing.Brush negro, amarillo, blanco, rojo, azul;
        Sound sounds = new Sound();
        char c;

        public List<PointF> coins = new List<PointF>();


        int GhostSpeed = 10;
        int ghostMoveStep = 130;
        int currentGhostStep;
        int score = 0;


        String currentDirection = "None";


        public Form1()
        {
            InitializeComponent();
            
            Init();
            gameInitialize();
        }

        private void Init()
        {

            map = new Map("mtx.mx");
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
          
            await Task.Delay(1000);

            timer1.Enabled = true;
            currentGhostStep = ghostMoveStep;

            DrawCharacters();
            await Task.Delay(5000);
            sounds.playEatingSound();

        }

        private void DrawCharacters()
        {
            pictureBox1.Image = Resource1.pacman_right;
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

        private void pacManMovement_Tick(object sender, EventArgs e)
        {
            switch (currentDirection)
            {
                case "left":
                    if((pictureBox1.Left - 8) > 0) pictureBox1.Left -= 8;
                    break;
                case "right":
                    if ((pictureBox1.Left + 8) < (this.Width - pictureBox1.Width)) pictureBox1.Left += 8;
                    break;
                case "up":
                    if ((pictureBox1.Top - 8) > 0) pictureBox1.Top -= 8;
                    break;
                case "down":
                    if ((pictureBox1.Top + 8) < (this.Height - pictureBox1.Height)) pictureBox1.Top += 8;
                    break;
            }
        }

        private void gameOver(string message)
        {
            timer1.Enabled = false;
            sounds.playDeathSound();
            MessageBox.Show(message, "PacMan UDLAP");
        }


        private void checkCollision()
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Score_Label.Text = "Score: " + score;
        }

    }
}
