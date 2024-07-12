using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Find_Path_Maze.DTO;
using System.Drawing;
using Find_Path_Maze.DataProvider;
using System.Windows.Forms;

namespace Find_Path_Maze.DAO
{
    public class Maze
    {
        public enum MoveAction
        {
           UP, RIGHT, DOWN, LEFT
        }
        private static Maze instance;
        public static Maze Instance
        {
            get
            {
                if(instance == null) instance = new Maze();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private Tuple<int, int> indexMove;
        private Tuple<int, int> indexDes;

        List<List<IConstruction>> mazeUI;
       
        public List<List<IConstruction>> MazeUI { get => mazeUI; set => mazeUI = value; }
        public Tuple<int, int> IndexMove { get => indexMove; set => indexMove = value; }
        public Tuple<int, int> IndexDes { get => indexDes; set => indexDes = value; }


        #region constructor
        private Maze()
        {
            this.MazeUI = new List<List<IConstruction>>();
            IndexMove = new Tuple<int, int>(0, 0);
        }
        #endregion

        #region Load
        /// <summary>
        /// Load ma trận của mê cung
        /// </summary>
        /// <returns>ma trận của mê cung</returns>
        public List<List<IConstruction>> Load()
        {
            mazeUI = MatrixMaze();
            indexMove = FindLocationPlayer();
            return mazeUI;
        }
        #endregion

        public List<List<IConstruction>> MatrixMaze()
        {
            string maze = ReadFile("Test.txt");
            maze = maze.Trim();

            int indexRow = 0;
            int indexColumn = 0;

            int LocationLoadX = DataMaze.LocationLoadX;
            int LocationLoadY = DataMaze.LocationLoadY;

            List<List<IConstruction>> listConstructions = new List<List<IConstruction>>();

            List<IConstruction> listConstruction = new List<IConstruction>();
            foreach (var item in maze)
            {
                if (item.ToString() == "\n")
                    continue;
                if (item.ToString() == "\r")
                {
                    ++indexRow;
                    indexColumn = 0;

                    listConstructions.Add(listConstruction);

                    LocationLoadX = DataMaze.LocationLoadX;
                    LocationLoadY += listConstruction[0].Height;

                    listConstruction = new List<IConstruction>();
                    continue;
                }
                else
                {
                    IConstruction construction = default;
                    if (item.ToString() == "0")
                    {
                        construction = new Way(DataMaze.ColorWay, 
                            new Point(LocationLoadX, LocationLoadY), 
                            DataMaze.WidthWay, DataMaze.HeightWay
                            );
                        LocationLoadX += DataMaze.WidthWay;
                    }
                    else if (item.ToString() == "1")
                    {
                        construction = new Wall(DataMaze.ColorWall,
                            new Point(LocationLoadX, LocationLoadY),
                            DataMaze.WidthWall, DataMaze.HeightWall
                            );
                        LocationLoadX += DataMaze.WidthWall;
                    }
                    else if (item.ToString() == "2")
                    {
                        construction = new Player(new Point(LocationLoadX, LocationLoadY),
                            DataMaze.WidthPlayer, DataMaze.HeighPlayer, DataMaze.PlayerUI
                            );
                        LocationLoadX += DataMaze.WidthPlayer;
                        //indexMove = new Tuple<int, int>(1, 1); // Edit
                    }
                    else if (item.ToString() == "3")
                    {
                        construction = new Destination(DataMaze.ColorDes,
                            new Point(LocationLoadX, LocationLoadY),
                            DataMaze.WidthDes, DataMaze.HeightDes
                            );
                        LocationLoadX += DataMaze.WidthDes;
                        indexDes = new Tuple<int, int>(indexRow, indexColumn);
                    }

                    listConstruction.Add(construction);
                }
                ++indexColumn;
            }

            listConstructions.Add(listConstruction);

            return listConstructions;
        }

        public Tuple<int, int> FindLocationPlayer()
        {
            Tuple<int, int> indexPlayer = null;
            if (MazeUI != null)
            {
                for (int i = 0; i < MazeUI.Count; ++i)
                {
                    for(int j = 0; j < MazeUI[i].Count; ++j)
                    {
                        if (MazeUI[i][j].Name == "PLAYER")
                        {
                            indexPlayer = new Tuple<int, int>(i, j);
                        }
                    }
                }
            }
            return indexPlayer;
        }

        #region ReadFile
        /// <summary>
        /// Đọc dữ liệu từ file
        /// </summary>
        /// <param name="fileName">Tên file</param>
        /// <returns>Chuỗi dữ liệu đọc được</returns>
        public string ReadFile(string fileName)
        {
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                return streamReader.ReadToEnd();
            }
        }
        #endregion

        #region CreateImageBackground
        /// <summary>
        /// Tạo ra ảnh với màu nền chỉ định
        /// </summary>
        /// <param name="width">chiều rộng của ảnh</param>
        /// <param name="heigth">chiều cao của ảnh</param>
        /// <param name="color">Màu của ảnh</param>
        /// <returns>Ảnh sau khi được chỉnh sửa màu nền</returns>
        public Image CreateImageBackground(int width, int heigth, Color color)
        {
            Bitmap bitmap = new Bitmap(width, heigth);

            for (int i = 0; i < bitmap.Height; ++i)
            {
                for (int j = 0; j < bitmap.Width; ++j)
                {
                    bitmap.SetPixel(j, i, color);
                }
            }

            return bitmap;
        }
        #endregion

        public void AI()
        {

        }

        public bool Action(MoveAction moveAction)
        {
            switch (moveAction)
            {
                case MoveAction.UP:
                    {
                        return MoveUp();
                    }
                case MoveAction.RIGHT:
                    {
                        return MoveRight();
                    }
                case MoveAction.DOWN:
                    {
                        return MoveDown();
                    }
                case MoveAction.LEFT:
                    {
                        return MoveLeft();
                    }
                default:
                    {
                        return false;
                    }
            }
        }
        bool MoveRight()
        {
            int indexMoveRightColumn = indexMove.Item2 + 1;
            if (IsMoveRight())
            {

                mazeUI[indexMove.Item1][indexMove.Item2].X += DataMaze.WidthWall;
                mazeUI[indexMove.Item1][indexMoveRightColumn].X -= DataMaze.WidthWall;

                Swap<IConstruction>(mazeUI, indexMove.Item1, indexMove.Item2,
                    indexMove.Item1, indexMoveRightColumn);

                indexMove = new Tuple<int, int>(indexMove.Item1, indexMoveRightColumn);
                return true;
            }
            return false;
        }
        public bool IsMoveRight()
        {
            int indexMoveRightColumn = indexMove.Item2 + 1;
            if (indexMoveRightColumn < mazeUI[indexMove.Item1].Count && GoPath(mazeUI[IndexMove.Item1][indexMoveRightColumn]))
            {
                return true;
            }
            return false;
        }

        bool MoveLeft()
        {
            int indexMoveLeftColumn = indexMove.Item2 - 1;
            if (IsMoveLeft())
            {

                mazeUI[indexMove.Item1][indexMove.Item2].X -= DataMaze.WidthWall;
                mazeUI[indexMove.Item1][indexMoveLeftColumn].X += DataMaze.WidthWall;

                Swap<IConstruction>(mazeUI, indexMove.Item1, indexMove.Item2,
                    indexMove.Item1, indexMoveLeftColumn);

                indexMove = new Tuple<int, int>(indexMove.Item1, indexMoveLeftColumn);
                return true;
            }
            return false;
        }
        public bool IsMoveLeft()
        {
            int indexMoveLeftColumn = indexMove.Item2 - 1;
            if (indexMoveLeftColumn >= 0 && GoPath(mazeUI[IndexMove.Item1][indexMoveLeftColumn]))
            {
                return true;
            }
            return false;
        }

        bool MoveUp()
        {
            int indexMoveUpRow = indexMove.Item1 - 1;
            if (IsMoveUp())
            {
                mazeUI[indexMove.Item1][indexMove.Item2].Y -= DataMaze.HeightWall;
                mazeUI[indexMoveUpRow][indexMove.Item2].Y += DataMaze.HeightWall;

                Swap<IConstruction>(mazeUI, IndexMove.Item1, IndexMove.Item2,
                    indexMoveUpRow, IndexMove.Item2);

                IndexMove = new Tuple<int, int>(indexMoveUpRow, IndexMove.Item2);
                return true;
            }
            return false;
        }
        public bool IsMoveUp()
        {
            int indexMoveUpRow = indexMove.Item1 - 1;
            if (indexMoveUpRow < mazeUI.Count && GoPath(mazeUI[indexMoveUpRow][IndexMove.Item2]))
            {
                return true;
            }
            return false;
        }

        bool MoveDown()
        {
            int indexMoveDownRow = indexMove.Item1 + 1;
            if (IsMoveDown())
            {

                mazeUI[indexMove.Item1][indexMove.Item2].Y += DataMaze.HeightWall;
                mazeUI[indexMoveDownRow][indexMove.Item2].Y -= DataMaze.HeightWall;

                Swap<IConstruction>(mazeUI, IndexMove.Item1, IndexMove.Item2,
                    indexMoveDownRow, IndexMove.Item2);

                IndexMove = new Tuple<int, int>(indexMoveDownRow, IndexMove.Item2);
                return true;
            }
            return false;

        }
        public bool IsMoveDown()
        {
            int indexMoveDownRow = indexMove.Item1 + 1;
            if (indexMoveDownRow < mazeUI.Count && GoPath(mazeUI[indexMoveDownRow][IndexMove.Item2]))
            {
                return true;
            }
            return false;
        }
        bool GoPath(IConstruction construction)
        {
            return construction.Name == "WAY" || construction.Name == "DESTINATION";
        }
        private void Swap<T>(List<List<T>> list, int row1, int column1, int row2, int column2) where T : class
        {
            T tmp = list[row1][column1];
            list[row1][column1] = list[row2][column2];
            list[row2][column2] = tmp;
        }
    }
}
