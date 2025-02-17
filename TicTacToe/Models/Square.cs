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
        /// <summary>
        /// Tracks the position based on 1-9 indexing
        /// </summary>
        public int BoardPosition { get; set; }

        /// <summary>
        /// State of the square: X, O, Undecided
        /// </summary>
        public State SquareState { get; set; }

        public Square() { }

        public Square(int boardPosition, State squareState)
        {
            this.BoardPosition = boardPosition;
            this.SquareState = squareState;
        }
    }
}
