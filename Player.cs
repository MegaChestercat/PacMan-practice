using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PacMan
{
    public class Player
    {

        public PointF Rotation(PointF a, PointF b, double angle)
        {
            b.X -= a.X;
            b.Y -= a.Y;

            PointF c = new PointF();
            angle = angle / 57.2958f;

            c.X = (float)((b.X * Math.Cos(angle)) - (b.Y * Math.Sin(angle)));
            c.Y = (float)((b.X * Math.Sin(angle)) + (b.Y * Math.Cos(angle)));

            c.X += a.X;
            c.Y += a.Y;

            return c;
        }
    }
}