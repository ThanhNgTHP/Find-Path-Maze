using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Path_Maze.DataProvider
{
    public class DataMaze
    {
        public const int WidthWall = 20;
        public const int HeightWall = 20;
        public static Color ColorWall = Color.Silver;

        public const int WidthWay = 20;
        public const int HeightWay = 20;
        public static Color ColorWay = Color.Black;

        public const int WidthDes = 20;
        public const int HeightDes = 20;
        public static Color ColorDes = Color.Red;

        public const int WidthPlayer = 20;
        public const int HeighPlayer = 20;

        public const int LocationLoadX = 0;
        public const int LocationLoadY = 0;

        public static Image PlayerUI = Image.FromFile("Images/player.gif");

        public static string PathMusicBackground = @"Videos/Music_Background.wav";
        public static bool RepeateMusicBackground = true;

        public static Image DestinationUI = Image.FromFile("Images/bank.jpg");
        public static Image WallUI = Image.FromFile("Images/wall.jpg");

    }
}
