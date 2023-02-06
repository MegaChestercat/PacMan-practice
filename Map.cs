using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PacMan
{
    public class Map
    {
        public char[,] map = new char[,] { };

        public Map(string str)
        {
            string[] lines = File.ReadAllLines(str);
            int xL = int.Parse(lines[0]);
            //int y = int.Parse(lines[1]);

            map = new char[120, 60];

            for (int y = 2; y < lines.Length; y++)
            {
                string res = lines[y].Replace(",", "");
                char[] l = res.ToCharArray();
                for (int x = 0; x < l.Length; x++)
                {
                    map[x, y - 2] = l[x];
                }
            }
        }
    }
}