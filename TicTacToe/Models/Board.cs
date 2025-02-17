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

        /// <summary>
        /// Displays the board in the Tic-Tac-Toe format
        /// </summary>
        /// <param name="gameBoard">The board being used for the game</param>
        internal static void DisplayBoard(Board gameBoard)
        {
            for (int i = 0; i < gameBoard.board.Length; i++)
            {
                for (int j = 0; j < gameBoard.board[i].Length; j++)
                {
                    string displayChar;

                    if (gameBoard.board[i][j].SquareState == Enums.State.Undecided)
                    {
                        displayChar = " ";  // If Undecided, print blank
                    }
                    else
                    {
                        displayChar = gameBoard.board[i][j].SquareState.ToString();
                    }

                    Console.Write($" {displayChar} "); // Print X, O, or blank

                    if (j < gameBoard.board[i].Length - 1)
                        Console.Write("|");  // Add column separator
                }

                Console.WriteLine(); // Move to a new row

                if (i < gameBoard.board.Length - 1)
                    Console.WriteLine("---+---+---");
            }
            Console.WriteLine();
        }
    }
}
