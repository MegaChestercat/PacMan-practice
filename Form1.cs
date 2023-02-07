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
        static System.Drawing.Brush brushN, brushW, brushC, brushP, brushR;
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
            brushN = new SolidBrush(System.Drawing.Color.FromArgb(0, 0, 0));
            brushW = new SolidBrush(System.Drawing.Color.FromArgb(0, 0, 255));
            brushC = new SolidBrush(System.Drawing.Color.FromArgb(239, 184, 16));
            brushP = new SolidBrush(System.Drawing.Color.FromArgb(248, 243, 43));
            brushR = new SolidBrush(System.Drawing.Color.FromArgb(255, 0, 0));

            for (int x = 0; x < 120; x++)
                for (int y = 0; y < 60; y++)
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
                case '0':
                    g.FillRectangle(brushN, x * 10, y * 10, 10, 10);
                    break;
                case 'w':
                    g.FillRectangle(brushW, x * 10, y * 10, 10, 10);
                    break;
                case 'c':
                    g.FillRectangle(brushC, x * 10, y * 10, 10, 10);
                    coins.Add(new PointF(x*10, y*10));
                    break;
                case 'p':
                    pacman = new PointF(x * 10, y * 10);
             
                    break;
                case 'r':
                    ghosts[0] = new PointF(x * 10, y * 10);
                    break;
                case 'o':
                    ghosts[1] = new PointF(x * 10, y * 10);
                    break;
                case 'b':
                    ghosts[2] = new PointF(x * 10, y * 10);
                    break;
                case 'q':
                    ghosts[3] = new PointF(x * 10, y * 10);
                    break;
                default:
                    g.FillRectangle(brushN, x * 10, y * 10, 10, 10);
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
                
                rotLoc = p.Rotation(pacman, pacPivot, 180);
                g.DrawImage(Resource1.pacman, rotLoc.X, rotLoc.Y);

            }
            else if(keyData == Keys.Right && noRight == false)
            {
                noLeft = noUp = noDown = false;
                goDown = goUp = goLeft = false;

                goRight = true;

                rotLoc = p.Rotation(pacman, pacPivot, 0); //or change it to 360 or -180

                clear();
                g.DrawImage(Resource1.pacman, rotLoc.X, rotLoc.Y);
            }
            else if (keyData == Keys.Up && noUp == false)
            {
                noLeft = noRight = noDown = false;
                goDown = goRight = goLeft = false;

                goUp = true;

                rotLoc = p.Rotation(pacman, pacPivot, 90);

                clear();
                g.DrawImage(Resource1.pacman, rotLoc.X, rotLoc.Y);
            }

            else if (keyData == Keys.Down && noDown == false)
            {
                noLeft = noRight = noUp = false;
                goUp = goRight = goLeft = false;

                goDown = true;

                rotLoc = p.Rotation(pacman, pacPivot, 270);

                clear();
                g.DrawImage(Resource1.pacman, rotLoc.X, rotLoc.Y);
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
            g.DrawImage(Resource1.pacman, pacman.X, pacman.Y);
            pacPivot = new PointF(pacman.X - 5, pacman.Y - 5);

            g.FillRectangle(brushR, pacman.X, pacman.Y, 10, 10);


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

            if (goRight)
            {

            }

            if (goLeft)
            {

            }

            if (goUp)
            {

            }

            if (goDown)
            {

            }

            if(goDown && (pacman.Y + 90)  > PCT_CANVAS.Height)
            {
                noDown = true;
                goDown = false;

            }

            if (goUp && pacman.Y  < 1)
            {
                noUp = true;
                goUp = false;

            }

        }

        private void clear()
        {
            g.FillRectangle(brushN, pacman.X, pacman.Y, 10, 10);
            g.FillRectangle(brushN, rotLoc.X, rotLoc.Y, 10, 10);
            PCT_CANVAS.Invalidate();
        }
    }
}
