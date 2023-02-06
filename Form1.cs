using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
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
        Player p;
        SoundPlayer sgame = new SoundPlayer(Resource1.startSound);
        SoundPlayer sgame2 = new SoundPlayer(Resource1.deathSound);
        bool goLeft, goRight, goDown, goUp, noLeft, noRight, noDown, noUp;
        char c;

     

        int speed = 8;
        Rect pacmanHitBox;
        Rect pacMan;
        Rect redGhost;
        

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

            if (c == '0')
                g.FillRectangle(brushN, x * 10, y * 10, 10, 10);
            else if (c == 'w')
                g.FillRectangle(brushW, x * 10, y * 10, 10, 10);
            else if (c == 'c')
                g.FillRectangle(brushC, x * 10, y * 10, 10, 10);
            else if (c == 'p')
            {
                g.DrawImage(Resource1.pacman, x * 10, y * 10);
                pacMan = new Rect(x * 10, y * 10, 10, 10);
            }
            else if (c == 'r')
                g.FillRectangle(brushR, x * 10, y * 10, 10, 10);
            else
                g.FillRectangle(brushN, x * 10, y * 10, 10, 10);
            
            //g.DrawRectangle(Pens.Gray, x * 10, y * 10, 10, 10);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if(keyData == Keys.Left && noLeft == false)
            {
                goDown = goUp = goRight = false;
                noRight = noUp = noDown = false;

                goLeft = true;
                
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

         async private void gameInitialize()
        {
            sgame.Play();
          
            await Task.Delay(1000);

            timer1.Enabled = true;
            currentGhostStep = ghostMoveStep;

           
           
        }

        private void DrawPlayer()
        {
            g.FillEllipse(System.Drawing.Brushes.Red, p.Pos.X - 3, p.Pos.Y - 3, 6, 6);
            for (int i = 0; i < p.looks.Count; i++)
            {
                g.DrawLine(Pens.Yellow, p.Pos, p.looks[i]);
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

        }
    }
}
