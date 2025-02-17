using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    internal class Board
    {
        /// <summary>
        /// The 3x3 2D array used to represent the board
        /// </summary>
        internal Square[][] board = new Square[3][]; // Making each row a separate array

        /// <summary>
        /// Constructor creates an array of arrays of Square objects for easier manipulation
        /// </summary>
        internal Board()
        {
            board[0] = new Square[3];
            board[1] = new Square[3];
            board[2] = new Square[3];

            int count = 1;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    board[i][j] =  new Square(count, Enums.State.Undecided);
                    count++;
                }
            }
        }
    }
}
