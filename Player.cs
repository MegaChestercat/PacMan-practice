using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PacMan
{
    public class Player
    {

        public PointF Pos, LookAt;//main lookAt
        public List<PointF> looks;

        public Player(PointF pos, PointF lookAt)
        {
            this.Pos = pos;
            this.LookAt = lookAt;
        }
    }
}