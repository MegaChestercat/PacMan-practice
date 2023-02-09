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

namespace PacMan
{
    public partial class Form1 : Form
    {

        static Map map;
        private Bitmap bmp;
        static Graphics g;
        static System.Drawing.Brush negro, amarillo, blanco, rojo, azul;
        Player p = new Player();
        SoundPlayer sgame = new SoundPlayer(Resource1.startSound);
        SoundPlayer sgame2 = new SoundPlayer(Resource1.deathSound);
        bool goLeft, goRight, goDown, goUp, noLeft, noRight, noDown, noUp;
        char c;



        int speed = 8;
        Rect pacmanHitBox;
        PointF pacman;
        PointF[] ghosts = new PointF[4];
        PointF pacPivot, rotLoc;
        public List<PointF> coins = new List<PointF>();


        int GhostSpeed = 10;
        int ghostMoveStep = 130;
        int currentGhostStep;
        int score = 0;

        

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
            //g.DrawRectangle(Pens.Gray, x * 10, y * 10, 10, 10);
            PCT_CANVAS.Invalidate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if(keyData == Keys.Left && noLeft == false)
            {
                goDown = goUp = goRight = false;
                noRight = noUp = noDown = false;

                goLeft = true;
                clear();
                
                //rotLoc = p.Rotation(pacman, pacPivot, 180);
                //g.DrawImage(Resource1.pacman, rotLoc.X, rotLoc.Y);

            }
            else if(keyData == Keys.Right && noRight == false)
            {
                noLeft = noUp = noDown = false;
                goDown = goUp = goLeft = false;

                goRight = true;

                //rotLoc = p.Rotation(pacman, pacPivot, 0); //or change it to 360 or -180

                clear();
                //g.DrawImage(Resource1.pacman, rotLoc.X, rotLoc.Y);
            }
            else if (keyData == Keys.Up && noUp == false)
            {
                noLeft = noRight = noDown = false;
                goDown = goRight = goLeft = false;

                goUp = true;

                //rotLoc = p.Rotation(pacman, pacPivot, 90);

                clear();
                //g.DrawImage(Resource1.pacman, rotLoc.X, rotLoc.Y);
            }

            else if (keyData == Keys.Down && noDown == false)
            {
                noLeft = noRight = noUp = false;
                goUp = goRight = goLeft = false;

                goDown = true;

                //rotLoc = p.Rotation(pacman, pacPivot, 270);

                clear();
                //g.DrawImage(Resource1.pacman, rotLoc.X, rotLoc.Y);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

         async private void gameInitialize()
        {
            sgame.Play();
          
            await Task.Delay(1000);

            timer1.Enabled = true;
            currentGhostStep = ghostMoveStep;

            DrawCharacters(); 
        }

        private void DrawCharacters()
        {
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

        private void clear()
        {
           
            PCT_CANVAS.Invalidate();
        }
    }
}
