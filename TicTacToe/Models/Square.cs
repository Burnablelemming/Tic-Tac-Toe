using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Enums;

namespace TicTacToe.Models
{
    internal class Square
    {
        public int BoardPosition { get; set; }
        public State SquareState { get; set; }
    }
}
