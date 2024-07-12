using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Path_Maze.DTO
{
    public class Wall : IConstruction
    {
        #region properties
        Color objectColor;
        int width;
        int height;
        string name = "WALL";
        #endregion

        public int X { get; set; }
        public int Y { get; set; }
        public Color ObjectColor { get => objectColor; set => objectColor = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public string Name { get => name; }

        #region constructor
        public Wall()
        {
            ObjectColor = Color.Black;
            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;
        }
        public Wall(Color objecColor, Point location, int width, int height)
        {
            this.X = location.X;
            this.Y = location.Y;
            this.ObjectColor = objecColor;
            this.Width = width;
            this.Height = height;
        }
        #endregion
    }
}
