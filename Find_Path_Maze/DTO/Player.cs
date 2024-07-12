using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Path_Maze.DTO
{
    public class Player : IConstruction, INotifyPropertyChanged
    {
        #region properties
        Color objectColor;
        bool activateBinding;
        int width;
        int height;
        int x;
        int y;
        string name = "PLAYER";
        Image playerUI;
        #endregion
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                OnPropertyChanged("x");
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                OnPropertyChanged("y");
            }
        }
        public Color ObjectColor { get => objectColor; set => objectColor = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public string Name { get => name; }
        public bool ActivateBinding { get => activateBinding; set => activateBinding = value; }
        public Image PlayerUI { get => playerUI; set => playerUI = value; }

        #region constructor
        public Player()
        {
            ObjectColor = Color.Transparent;
            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;
            ActivateBinding = false;
        }
        public Player(Point location, int width, int height, Image playerUI)
        {
            this.X = location.X;
            this.Y = location.Y;
            this.Width = width;
            this.Height = height;
            PlayerUI = playerUI;
        }
        #endregion

        #region event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region OnPropertyChanged
        /// <summary>
        /// Thông báo sự thay đổi thuộc tính để binding
        /// </summary>
        /// <param name="propertyName">Tên thuộc tính thông báo sự thay đổi</param>
        void OnPropertyChanged(string propertyName)
        {
            if (ActivateBinding)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
