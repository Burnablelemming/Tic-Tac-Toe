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

        public void StartGame(Player player1, Player player2)
        {
            //Board board = new Board();
            // while (moves < 9 and gameResult == Undecided)
            //makeMove(player, board)
        }

        public int MakeMove(Player player)
        {
            
        }

        public int getPlayerMove()
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
