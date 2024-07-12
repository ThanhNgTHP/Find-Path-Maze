using Find_Path_Maze.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Find_Path_Maze.DAO
{
    public class PlayerAI
    {
        private static PlayerAI instance;
        public static PlayerAI Instance
        {
            get
            {
                if (instance == null) instance = new PlayerAI();
                return instance;
            }
            set
            {
                instance = value;
            }
        }


        List<Tuple<int, int>> listOversee;
        public List<Tuple<int, int>> ListOversee { get => listOversee; set => listOversee = value; }

        private PlayerAI()
        {
        }
      
        public void MoveAI()
        {
            //List<Tuple<int, int>> listOversee = new List<Tuple<int, int>>();
            //Point(ListMoveAction(), listOversee);

            listOversee = new List<Tuple<int, int>>();
            List<List<IConstruction>> constructions = InitCloneMaze();

            bool isFind = false;
            DFS(constructions, Maze.Instance.IndexMove.Item1, Maze.Instance.IndexMove.Item2, Maze.Instance.IndexDes, listOversee, ref isFind);
            //foreach(var tupple in this.listOversee)
        }

        public Maze.MoveAction? ConvertMoveAction(Tuple<int, int> indexMove, Tuple<int, int> nextMove)
        {
            if (indexMove.Item1 == nextMove.Item1 - 1 && indexMove.Item2 == nextMove.Item2)
            {
                return Maze.MoveAction.DOWN;
            }
            else if (indexMove.Item1 == nextMove.Item1 + 1 && indexMove.Item2 == nextMove.Item2)
            {
                return Maze.MoveAction.UP;
            }
            else if (indexMove.Item1 == nextMove.Item1 && indexMove.Item2 == nextMove.Item2 - 1)
            {
                return Maze.MoveAction.RIGHT;
            }
            else if (indexMove.Item1 == nextMove.Item1 && indexMove.Item2 == nextMove.Item2 + 1)
            {
                return Maze.MoveAction.LEFT;
            }
            return null;
        }

        List<List<IConstruction>> InitCloneMaze()
        {
            List<List<IConstruction>> constructions = new List<List<IConstruction>>(); 
            for (int i = 0; i < Maze.Instance.MazeUI.Count; ++i)
            {
                List<IConstruction> listConstruction = new List<IConstruction>();
                for (int j = 0; j < Maze.Instance.MazeUI[i].Count; ++j)
                {
                    listConstruction.Add(Maze.Instance.MazeUI[i][j]);
                }
                constructions.Add(listConstruction);
            }
            return constructions;
        }

        void DFS(List<List<IConstruction>> constructions, int row, int column, Tuple<int, int> destination, List<Tuple<int, int>> listOversee, ref bool isFind)
        {
            if (isFind) return;

            Tuple<int, int> indexMoveCurrent = new Tuple<int, int>(row, column);
            if (ContainListTuple(indexMoveCurrent, listOversee))
            {
                return;
            }
            if (row < 0 || row >= constructions.Count || column < 0 || column >= constructions[row].Count ||
                constructions[row][column].Name == "WALL"
                )
            {
                return;
            }

            Tuple<int, int> tuple = new Tuple<int, int>(row, column);
            listOversee.Add(tuple);

            if (destination.Item1 == row && destination.Item2 == column)
            {
                this.listOversee = new List<Tuple<int, int>>();
                foreach (var item in listOversee)
                {
                    this.listOversee.Add((Tuple<int, int>)item);
                }
                isFind = true;
                return;
            }

            DFS(constructions, row + 1, column, destination, listOversee, ref isFind);
            DFS(constructions, row, column + 1, destination, listOversee, ref isFind);
            DFS(constructions, row - 1, column, destination, listOversee, ref isFind);
            DFS(constructions, row, column - 1, destination, listOversee, ref isFind);

            for (int i = 0; i < listOversee.Count; ++i)
            {
                if (listOversee[i].Item1 == row && listOversee[i].Item2 == column)
                {
                    listOversee.RemoveRange(i, listOversee.Count - i);
                }
            }
        }

        void Point(List<Maze.MoveAction> listMoveAction, List<Tuple<int, int>> listOversee)
        {
            if (Maze.Instance.IndexMove.Item1 == Maze.Instance.IndexDes.Item1 &&
                Maze.Instance.IndexMove.Item2 == Maze.Instance.IndexDes.Item2
                )
            {
                MessageBox.Show("OK");
                return;
            }
            //foreach (Maze.MoveAction moveAction in listMoveAction)
            //{
            //    Maze.Instance.Action(moveAction);

            //    Tuple<int, int> indexMove = new Tuple<int, int>(Maze.Instance.IndexMove.Item1, Maze.Instance.IndexMove.Item2);
            //    if (ContainListTuple(indexMove, listOversee))
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        listOversee.Add(indexMove);
            //    }
            //    List<Maze.MoveAction> moveActions = ListMoveAction();
            //    moveActions.Remove(PreviousAction(moveAction));
            //    Point(moveActions, listOversee);
            //    //MessageBox.Show("123");
            //}
        }

        Maze.MoveAction PreviousAction(Maze.MoveAction moveAction)
        {
            if (moveAction.ToString() == "LEFT")
            {
                return Maze.MoveAction.RIGHT;
            }
            else if (moveAction.ToString() == "RIGHT")
            {
                return Maze.MoveAction.LEFT;
            }
            else if (moveAction.ToString() == "UP")
            {
                return Maze.MoveAction.DOWN;
            }
            else
            {
                return Maze.MoveAction.UP;
            }
        }

        bool ContainListTuple(Tuple<int, int> tuple, List<Tuple<int, int>> tuples)
        {
            foreach (Tuple<int, int> item in tuples)
            {
                if (CompareListTuple(tuple, item))
                {
                    return true;
                }
            }
            return false;
        }
        bool CompareListTuple(Tuple<int, int> tuple1, Tuple<int, int> tuple2)
        {
            if (tuple1.Item1 == tuple2.Item1 && tuple1.Item2 == tuple2.Item2)
            {
                return true;
            }
            return false;
        }

        List<Maze.MoveAction> ListMoveAction()
        {
            List<Maze.MoveAction> listMoveAction = new List<Maze.MoveAction>();
            if (Maze.Instance.IsMoveRight())
            {
                listMoveAction.Add(Maze.MoveAction.RIGHT);
            }
            if (Maze.Instance.IsMoveLeft())
            {
                listMoveAction.Add(Maze.MoveAction.LEFT);
            }
            if (Maze.Instance.IsMoveUp())
            {
                listMoveAction.Add(Maze.MoveAction.UP);
            }
            if (Maze.Instance.IsMoveDown())
            {
                listMoveAction.Add(Maze.MoveAction.DOWN);
            }
            return listMoveAction;
        }
    }
}
