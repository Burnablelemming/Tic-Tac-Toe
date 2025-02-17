using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Enums;

namespace TicTacToe.Models
{
    internal class Player
    {
        internal String Name { get; set; }
        internal State PlayerChoice { get; set; }

        internal Player() 
        {
            this.Name = "Undefined";
            this.PlayerChoice = Enums.State.Undecided;

        }

        internal Player(string name, State playerChoice)
        {
            Name = name;
            PlayerChoice = playerChoice;
        }

        /// <summary>
        /// Validates the players move and passes it to the MakeMove method
        /// </summary>
        /// <param name="gameBoard">The board being used for the game</param>
        /// <returns>Position to be played on the board</returns>
        internal static int GetPlayerMove(Board gameBoard)
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
                    else if (GameManager.UsedPositions.Contains(position))
                    {
                        Console.WriteLine("Invalid Input. Position already filled on board.");
                        continue;
                    }

                    validInput = true;  // Valid input
                }
                catch (Exception)  // Catches any invalid inputs
                {
                    Console.WriteLine("Invalid input. Enter an integer between 1-9.");
                }

            }
            return position;
        }
    }
}
