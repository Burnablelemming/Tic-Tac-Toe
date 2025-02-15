using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    internal class Board
    {
        public Square[][] board = new Square[3][]; // Making each row a separate array

        public Board()  // Constructor initializes the board with empty square objects
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
