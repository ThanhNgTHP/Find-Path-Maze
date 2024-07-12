using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Find_Path_Maze
{
    public partial class StartGame : Form
    {
        public StartGame()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
        }

        private void bttStart_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCharacterName.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên nhân vật", "Thông báo");
                return;
            }
            if (txtCharacterName.Text.Length > 30)
            {
                MessageBox.Show("Không được nhập quá 30 kí tự");
                return ;
            }
            Game game = new Game();
            this.Hide();
            game.label1.Text = txtCharacterName.Text;
            game.ShowDialog();
            this.Show();
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK != MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel))
            {
                e.Cancel = true;
            }
        }

        private void txtCharacterName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}
