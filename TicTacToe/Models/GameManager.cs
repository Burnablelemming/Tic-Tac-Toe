using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Enums;

namespace TicTacToe.Models
{
    /// <summary>
    /// Manages the Tic-Tac-Toe game logic
    /// </summary>
    internal class GameManager
    {
        /// <summary>
        /// Holds the number of moves made during the game 
        /// </summary>
        private int _moves;

        /// <summary>
        /// An enum that controls the state of the game. Either X wins, O wins, or tie
        /// </summary>
        private Result _gameResult;

        /// <summary>
        /// A list that holds filled positions on the board
        /// </summary>
        private List<int> _usedPositions = new List<int> { }; //Keeps track of used positions on the board using a list.

        /// <summary>
        /// Initializes a new instance of the class with default values
        /// </summary>
        ///  
        public GameManager()
        {
            _moves = 0;
            _gameResult = Enums.Result.Undecided;
        }

        /// <summary>
        /// Starts Tic-Tac-Toe game and calls MakeMove for each player until the game is finished
        /// </summary>
        /// <param name="player1">The first player</param>
        /// <param name="player2">The second player</param>
        public void StartGame(Player player1, Player player2)
        {
            Board gameBoard = new Board();

            Console.WriteLine("Empty Board: ");
            DisplayBoard(gameBoard);

            while (this._gameResult == Enums.Result.Undecided && _moves < 9)
            {
                // Player 1's move
                Console.WriteLine($"{player1.Name}'s Turn");
                MakeMove(player1, gameBoard);
                _gameResult = CheckBoardState(gameBoard);  // Check for a winner if moves >= 5
                DisplayBoard(gameBoard);

                if (_gameResult != Enums.Result.Undecided || _moves == 9)
                {
                    DisplayBoard(gameBoard);

                    switch (_gameResult)
                    {
                        case Enums.Result.X_Wins:
                            Console.WriteLine($"{player1.Name} Wins!");
                            break;
                        case Enums.Result.O_Wins:
                            Console.WriteLine($"{player2.Name} Wins!");
                            break;
                        case Enums.Result.Cat:
                            Console.WriteLine("It's a Draw!"); // No winner
                            break;
                        default:
                            Console.WriteLine("Game Over!");  // _gameResult has not been set properly somewhere. Sooo not good. 
                            break;
                    }

                    break;  // Exit the game loop
                } // End player 1's move

                // Player 2's move
                Console.WriteLine($"{player2.Name}'s Turn");
                MakeMove(player2, gameBoard);
                _gameResult = CheckBoardState(gameBoard);  // Check again
                DisplayBoard(gameBoard);

                if (_gameResult != Enums.Result.Undecided || _moves == 9)
                {
                    DisplayBoard(gameBoard);

                    switch (_gameResult)
                    {
                        case Enums.Result.X_Wins:
                            Console.WriteLine($"{player1.Name} Wins!");
                            break;
                        case Enums.Result.O_Wins:
                            Console.WriteLine($"{player2.Name} Wins!");
                            break;
                        case Enums.Result.Cat:
                            Console.WriteLine("It's a Draw!"); // No winner
                            break;
                        default:
                            Console.WriteLine("Game Over!");  // _gameResult has not been set properly somewhere. Sooo not good. 
                            break;
                    }

                    break;  // Exit the game loop
                } // End player 2's move

            }

        }

        /// <summary>
        /// Take a players move and maps it to a position on the board
        /// </summary>
        /// <param name="player">The player making the move</param>
        /// <param name="gameBoard">The board being used for the game</param>
        private void MakeMove(Player player, Board gameBoard)
        {
            int position = getPlayerMove(gameBoard); // Valid user input returned

            // Switch case is mapped to each position on the board
            switch (position)
            {
                case 1:
                    gameBoard.board[0][0].SquareState = player.PlayerChoice;
                    _usedPositions.Add(position);
                    _moves++;
                    break;
                case 2:
                    gameBoard.board[0][1].SquareState = player.PlayerChoice;
                    _usedPositions.Add(position);
                    _moves++;
                    break;
                case 3:
                    gameBoard.board[0][2].SquareState = player.PlayerChoice;
                    _usedPositions.Add(position);
                    _moves++;
                    break;
                case 4:
                    gameBoard.board[1][0].SquareState = player.PlayerChoice;
                    _usedPositions.Add(position);
                    _moves++;
                    break;
                case 5:
                    gameBoard.board[1][1].SquareState = player.PlayerChoice;
                    _usedPositions.Add(position);
                    _moves++;
                    break;
                case 6:
                    gameBoard.board[1][2].SquareState = player.PlayerChoice;
                    _usedPositions.Add(position);
                    _moves++;
                    break;
                case 7:
                    gameBoard.board[2][0].SquareState = player.PlayerChoice;
                    _usedPositions.Add(position);
                    _moves++;
                    break;
                case 8:
                    gameBoard.board[2][1].SquareState = player.PlayerChoice;
                    _usedPositions.Add(position);
                    _moves++;
                    break;
                case 9:
                    gameBoard.board[2][2].SquareState = player.PlayerChoice;
                    _usedPositions.Add(position);
                    _moves++;
                    break;
            }
        }

        /// <summary>
        /// Validates the players move and passes it to the MakeMove method
        /// </summary>
        /// <param name="gameBoard">The board being used for the game</param>
        /// <returns>Position to be played on the board</returns>
        private int getPlayerMove(Board gameBoard)
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
                    else if (_usedPositions.Contains(position))
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

        /// <summary>
        /// Check the board to see if a player has won the game
        /// </summary>
        /// <param name="gameBoard">The board being used for the game</param>
        /// <returns>An enum that indicates the game state</returns>
        private Enums.Result CheckBoardState(Board gameBoard)
        {
            if (_moves < 5)
            {
                return _gameResult; // _gameResult is set to undecided by default
            }


            for (int i = 0; i < 3; i++)
            {
                // Check rows
                if (gameBoard.board[i][0].SquareState == gameBoard.board[i][1].SquareState &&
                    gameBoard.board[i][1].SquareState == gameBoard.board[i][2].SquareState &&
                    gameBoard.board[i][0].SquareState != Enums.State.Undecided)
                {
                    return gameBoard.board[i][0].SquareState == Enums.State.X ? Enums.Result.X_Wins : Enums.Result.O_Wins;
                }
                //Check columns
                if (gameBoard.board[0][i].SquareState == gameBoard.board[1][i].SquareState &&
                    gameBoard.board[1][i].SquareState == gameBoard.board[2][i].SquareState &&
                    gameBoard.board[0][i].SquareState != Enums.State.Undecided)
                {
                    return gameBoard.board[0][i].SquareState == Enums.State.X ? Enums.Result.X_Wins : Enums.Result.O_Wins;
                }
            }
            //Check Diagonals
            if (gameBoard.board[0][0].SquareState == gameBoard.board[1][1].SquareState &&
                gameBoard.board[1][1].SquareState == gameBoard.board[2][2].SquareState &&
                gameBoard.board[0][0].SquareState != Enums.State.Undecided)
            {
                return gameBoard.board[0][0].SquareState == Enums.State.X ? Enums.Result.X_Wins : Enums.Result.O_Wins;
            }

            if (gameBoard.board[0][2].SquareState == gameBoard.board[1][1].SquareState &&
                gameBoard.board[1][1].SquareState == gameBoard.board[2][0].SquareState &&
                gameBoard.board[0][2].SquareState != Enums.State.Undecided)
            {
                return gameBoard.board[0][2].SquareState == Enums.State.X ? Enums.Result.X_Wins : Enums.Result.O_Wins;
            }

            // If all moves are made and no winner, it's a draw
            if (_moves == 9)
                return Enums.Result.Cat;

            return Enums.Result.Undecided;

        }

        /// <summary>
        /// Gets the players name and and creates a player with it
        /// </summary>
        /// <param name="playerNumber"></param>
        /// <returns>An instantiated player with name and state assigned</returns>
        public Player CreatePlayer(int playerNumber)
        {
            Console.Write($"Enter name for Player {playerNumber}: ");
            string name = Console.ReadLine()?.Trim(); // Ignore null exception and continue

            while (string.IsNullOrWhiteSpace(name))  // Ensure the name is not empty
            {
                Console.Write("Invalid input. Please enter a valid name: ");
                name = Console.ReadLine()?.Trim();
            }
            if (playerNumber == 1)
            {
                return new Player { Name = name, PlayerChoice = State.X };
            }
            return new Player { Name = name, PlayerChoice = State.O };
        }

        /// <summary>
        /// Displays the board in the Tic-Tac-Toe format
        /// </summary>
        /// <param name="gameBoard">The board being used for the game</param>
        private void DisplayBoard(Board gameBoard)
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
