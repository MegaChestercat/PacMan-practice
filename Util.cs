

using System;
using System.Drawing;

namespace PacMan
{
    public class Util
    {
        static Util instance;
        float t;

        public static Util Instance
        {
            get
            {
                if (instance == null)
                    instance = new Util();
                return Util.instance;
            }
        }

        public float distance(PointF a, PointF b)
        {
            float x, y;
            x = a.X - b.X;
            y = a.Y - b.Y;

            return (float)Math.Sqrt((x * x) + (y * y));
        }

        public PointF NextStep(PointF position, PointF direction, float alpha)
        {
            PointF res;

            res = new PointF();
            res.X = ((1 - alpha) * position.X) + ((alpha) * direction.X);
            res.Y = ((1 - alpha) * position.Y) + ((alpha) * direction.Y);

            return res;
        }

        public PointF Rotate(PointF a, PointF b, float angle)
        {
            if (angle > 360)
                angle = 360;

            if (angle < -360)
                angle = 0;

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