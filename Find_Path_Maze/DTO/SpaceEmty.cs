using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Path_Maze.DTO
{
    public class SpaceEmty
    {
        #region properties
        Color objectColor;
        Point location;
        int width;
        int height;
        string name = "PATH";
        #endregion
        public Color ObjectColor { get => objectColor; set => objectColor = value; }
        public Point Location { get => location; set => location = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public string Name { get => name; }

        #region constructor
        public SpaceEmty()
        {
            ObjectColor = Color.Black;
            Location = new Point(0, 0);
            Width = 0;
            Height = 0;
        }
        public SpaceEmty(Color objecColor, Point location, int width, int height)
        {
            this.ObjectColor = objecColor;
            this.Location = location;
            this.Width = width;
            this.Height = height;
        }
        #endregion
    }
}
