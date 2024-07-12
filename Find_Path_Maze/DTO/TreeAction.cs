using Find_Path_Maze.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Path_Maze.DTO
{
    public class TreeAction
    {
        public List<Maze.MoveAction> moveActions;
        public Tuple<int, int> indexMove;
        public TreeAction(List<Maze.MoveAction> moveActions, Tuple<int ,int> indexMove)
        {
            this.moveActions = moveActions;
            this.indexMove = new Tuple<int, int>(indexMove.Item1, indexMove.Item2);
        }
        
    }
}
