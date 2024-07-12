using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Path_Maze.DTO
{
    public class Destination : IConstruction
    {
        #region properties
        Color objectColor;
        public int X { get; set; }
        public int Y { get; set; }
        int width;
        int height;
        string name = "DESTINATION";
        #endregion
        public Color ObjectColor { get => objectColor; set => objectColor = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public string Name { get => name; }

        #region constructor
        public Destination()
        {
            ObjectColor = Color.Red;
            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;
        }
        public Destination(Color objecColor, Point location, int width, int height)
        {
            this.ObjectColor = objecColor;
            this.X = location.X;
            this.Y = location.Y;
            this.Width = width;
            this.Height = height;
        }
        #endregion
    }
}
