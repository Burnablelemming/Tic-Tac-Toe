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

        private List<int> __usedPositions = new List<int>; //Keeps track of positions filled by storing them in the array.
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

        public void StartGame(Player player1, Player player2)
        {
            Board gameBoard = new Board();
            while (this._moves < 9 && this._gameResult == Enums.Result.Undecided) 
            {
                Console.WriteLine("Player 1 Makes move");
                MakeMove(player1, gameBoard);
                MakeMove(player2 , gameBoard);
            }
            
        }

        public void MakeMove(Player player, Board gameBoard)
        {
            int position = getPlayerMove(gameBoard);

            switch (position)
            {
                case 1:
                    gameBoard.board[0][0].SquareState = player.PlayerChoice;
                    _usedPositions[0] = position;
                    _moves++;
                    break;
                case 2:
                    gameBoard.board[0][1].SquareState = player.PlayerChoice;
                    __usedPositions[1] = position;
                    _moves++;
                    break;
                case 3:
                    gameBoard.board[0][2].SquareState = player.PlayerChoice;
                    __usedPositions[2] = position;
                    _moves++;
                    break;
                case 4:
                    gameBoard.board[1][0].SquareState = player.PlayerChoice;
                    _usedPositions[3] = position;
                    _moves++;
                    break;
                case 5:
                    gameBoard.board[1][1].SquareState = player.PlayerChoice;
                    _usedPositions[4] = position;
                    _moves++;
                    break;
                case 6:
                    gameBoard.board[1][2].SquareState = player.PlayerChoice;
                    _usedPositions[5] = position;
                    _moves++;
                    break;
                case 7:
                    gameBoard.board[2][0].SquareState = player.PlayerChoice;
                    _usedPositions[6] = position;
                    _moves++;
                    break;
                case 8:
                    gameBoard.board[2][1].SquareState = player.PlayerChoice;
                    _usedPositions[7] = position;
                    _moves++;
                    break;
                case 9:
                    gameBoard.board[2][2].SquareState = player.PlayerChoice;
                    _usedPositions[8] = position;
                    _moves++;
                    break;
            }
        }

        public int getPlayerMove(Board gameBoard)
        {
            int position = -1; //Before user input
            bool validInput = false;

            while (!validInput)
            {
                try
                {
                    Console.Write("Enter a number between 1 and 9: ");
                    position = int.Parse(Console.ReadLine());

                    if (position < 1 || position > 9) // Input out of range
                    {
                        throw new Exception();  
                    }
                    else if (this._usedPositions.Contains(position)) 
                    {
                        Console.WriteLine("Invalid Input. Position already filled on board.");
                    }

                    validInput = true;  // Valid input
                }
                catch (Exception)  // Catches any invalid inputs
                {
                    Console.WriteLine("Invalid input. Enter a number between 1-9.");
                }

            }
            return position;
        }
    }
}
