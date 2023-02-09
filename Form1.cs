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
        Player p;
        SoundPlayer sgame = new SoundPlayer(Resource1.startSound);
        SoundPlayer sgame2 = new SoundPlayer(Resource1.deathSound);
        char c;
        static int verticalMove, horizontalMove;
        int step;

        Rect pacmanHitBox;
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    pictureBox1.Left += 20;
                    break;

                case Keys.Right:

                    break;

                case Keys.Up:
                    break;

                case Keys.Down:
                    break;
                case Keys.Space:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }

         async private void gameInitialize()
        {
            step = 8;
            sgame.Play();
          
            await Task.Delay(1000);

            timer1.Enabled = true;
            currentGhostStep = ghostMoveStep;

            DrawCharacters(); 
        }

        private void DrawCharacters()
        {
            pictureBox1.Image = Resource1.pacman;
            p = new Player(new PointF(pictureBox1.Location.X +10, pictureBox1.Location.Y + 10), new PointF(pictureBox1.Location.X + 10, pictureBox1.Location.Y - 80));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    currentDirection = "left";
                    break;

                case Keys.Right:
                    currentDirection = "right";
                    break;

                case Keys.Up:
                    currentDirection = "up";
                    break;

                case Keys.Down:
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
                    pictureBox1.Left -= 3;
                    break;
                case "right":
                    pictureBox1.Left += 3;
                    break;
                case "up":
                    pictureBox1.Top -= 3;
                    break;
                case "down":
                    pictureBox1.Top += 3;
                    break;
            }
        }

        private void checkCollision()
        {

        }

        private void gameOver(string message)
        {
            timer1.Enabled = false;
            sgame2.Play();
            MessageBox.Show(message, "PacMan UDLAP");
           
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Score_Label.Text = "Score: " + score;

          

            

        }

        private void UpdateVertPosition()
        {
            float f = (float)verticalMove / 50;
            p.Pos = Util.Instance.NextStep(p.Pos, p.LookAt, f);// update position of entity
            p.LookAt = Util.Instance.NextStep(p.LookAt, p.Pos, -f);// update position of entity

            if (Util.Instance.distance(p.Pos, p.LookAt) < 15) // it compensates the float error
            {
                if (f > 0)
                    p.LookAt = Util.Instance.NextStep(p.LookAt, p.Pos, -f);
                else
                    p.LookAt = Util.Instance.NextStep(p.LookAt, p.Pos, f);
            }
            p.UpdateRotations();
            verticalMove = 0;
        }

        
        private void UpdateHorPosition()
        {
            float h = (float)horizontalMove / 50;
            p.Pos = Util.Instance.NextStep(p.Pos, p.LookAt, h);// update position of entity
            p.LookAt = Util.Instance.NextStep(p.LookAt, p.Pos, -h);// update position of entity

            if (Util.Instance.distance(p.Pos, p.LookAt) < 15) // it compensates the float error
            {
                if (h > 0)
                    p.LookAt = Util.Instance.NextStep(p.LookAt, p.Pos, -h);
                else
                    p.LookAt = Util.Instance.NextStep(p.LookAt, p.Pos, h);
            }
            p.UpdateRotations();
            horizontalMove = 0;
        }
    }
}
