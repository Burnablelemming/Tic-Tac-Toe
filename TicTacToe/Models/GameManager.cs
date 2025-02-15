using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Enums;

namespace TicTacToe.Models
{
    internal class GameManager
    {
        private int _moves;

        private Result _gameResult;
        public GameManager() 
        {
            _moves = 0;
            _gameResult = Enums.Result.Undecided;
        }

        //public GameManager(int moves, Enums.Result result)
        //{
        //    _moves = moves;
        //    _gameResult = result;
        //} 


    }
}
