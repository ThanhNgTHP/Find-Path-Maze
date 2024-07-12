using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Find_Path_Maze.CustomControls
{
    public class PictureBoxCustom : PictureBox, INotifyPropertyChanged
    {
        #region properties
        int x;
        int y;
        bool activateBinding;
        #endregion
        public int X
        {
            get
            {
                x = Location.X;
                return x;
            }
            set
            {
                x = value;
                Location = new Point(x, Location.Y);
                OnPropertyChanged("x");
            }
        }
        public int Y
        {
            get
            {
                x = Location.Y;
                return x;
            }
            set
            {
                y = value;
                Location = new Point(Location.X, y);
                OnPropertyChanged("y");
            }
        }
        public bool ActivateBinding { get => activateBinding; set => activateBinding = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            if (ActivateBinding)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
