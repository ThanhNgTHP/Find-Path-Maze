using Find_Path_Maze.CustomControls;
using Find_Path_Maze.DAO;
using Find_Path_Maze.DataProvider;
using Find_Path_Maze.DTO;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Find_Path_Maze
{
    public partial class Game : Form
    {
        List<List<IConstruction>> mazeUI;

        bool isEnableMoveBoard;
        public Game()
        {
            InitializeComponent();

            //BackgroudMusic();
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;

            isEnableMoveBoard = true;
            mazeUI = Maze.Instance.Load();
            bttAI.KeyDown += Form1_KeyDown;

            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < mazeUI.Count; i++)
            {
                for (int j = 0; j < mazeUI[i].Count; j++)
                {
                    PictureBoxCustom pictureBoxCustom = new PictureBoxCustom();

                    Binding locationBindingX = new Binding("X", mazeUI[i][j], "X");
                    Binding locationBindingY = new Binding("Y", mazeUI[i][j], "Y");

                    if (mazeUI[i][j].Name == "PLAYER")
                    {
                        Player player = (mazeUI[i][j] as Player);
                        pictureBoxCustom.Image = player.PlayerUI;
                        player.ActivateBinding = true;
                    }
                    else if (mazeUI[i][j].Name == "WAY")
                    {
                        Way way = (mazeUI[i][j] as Way);
                        way.ActivateBinding = true;
                    }
                    else if (mazeUI[i][j].Name == "DESTINATION")
                    {
                        pictureBoxCustom.Image = DataMaze.DestinationUI;
                    }
                    else
                    {
                        if (DataMaze.WallUI != null)
                        {
                            pictureBoxCustom.Image = DataMaze.WallUI;
                        }
                        else
                        {
                            pictureBoxCustom.Image = Maze.Instance.CreateImageBackground(
                            mazeUI[i][j].Width, mazeUI[i][j].Height, mazeUI[i][j].ObjectColor);
                        }

                    }

                    pictureBoxCustom.Size = new Size(mazeUI[i][j].Width, mazeUI[i][j].Height);
                    pictureBoxCustom.Location = new Point(mazeUI[i][j].X, mazeUI[i][j].Y);
                    pictureBoxCustom.SizeMode = PictureBoxSizeMode.StretchImage;

                    pictureBoxCustom.DataBindings.Add(locationBindingX);
                    pictureBoxCustom.DataBindings.Add(locationBindingY);

                    panel1.Controls.Add(pictureBoxCustom);
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isEnableMoveBoard == false)
            {
                return;
            }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                Maze.Instance.Action(Maze.MoveAction.LEFT);
                EndGame();
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                Maze.Instance.Action(Maze.MoveAction.RIGHT);
                EndGame();
            }
            else if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                Maze.Instance.Action(Maze.MoveAction.UP);
                EndGame();
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                Maze.Instance.Action(Maze.MoveAction.DOWN);
                EndGame();
            }
        }
        void EndGame()
        {
            if (Maze.Instance.IndexMove.Item1 == Maze.Instance.IndexDes.Item1 &&
                Maze.Instance.IndexMove.Item2 == Maze.Instance.IndexDes.Item2)
            {
                if(waveOut != null)
                {
                    waveOut.Pause();
                    waveOut.Dispose();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            MoveAI();
            BackgroudMusic();
            EndGame();
        }

        void MoveAI()
        {
            PlayerAI.Instance.MoveAI();

            DateTime dateTimeCurrent = DateTime.Now;

            ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
            {
                isEnableMoveBoard = false;
                foreach (Tuple<int, int> oversee in PlayerAI.Instance.ListOversee)
                {
                    Maze.MoveAction? moveAction = PlayerAI.Instance.ConvertMoveAction(Maze.Instance.IndexMove, oversee);
                    if (moveAction != null)
                    {
                        Maze.Instance.Action(moveAction.Value);

                        TimeSpan timeSpan = DateTime.Now - dateTimeCurrent;

                        if (timeSpan.TotalSeconds >= 13f)
                        {
                            Thread.Sleep(200);
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }
                }
                isEnableMoveBoard = true;
                EndGame();
            }));
        }

        WaveOut waveOut;
        void BackgroudMusic()
        {
            WaveFileReader waveFileReader = new WaveFileReader(DataMaze.PathMusicBackground);

            waveOut = new WaveOut();
            waveOut.Init(waveFileReader);
            waveOut.Volume = 0.5f;
            
            waveOut.PlaybackStopped += WaveOut_PlaybackStopped;

            waveOut.Play();
        }
        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            //WaveOut waveOut = sender as WaveOut;
            //waveOut.Dispose();

            //if (DataMaze.RepeateMusicBackground)
            //{
            //    BackgroudMusic();
            //}
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Pause();
                waveOut.Dispose();
            }
        }
    }
}
