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

        private List<int> _usedPositions = new List<int> { }; //Keeps track of used positions on the board using a list.
        public GameManager()
        {
            _moves = 0;
            _gameResult = Enums.Result.Undecided;
        }

        // Starts the Tic-Tac-Toe game and runs until someone wins or the game is a tie
        public void StartGame(Player player1, Player player2)
        {
            Board gameBoard = new Board();

            Console.WriteLine("Empty Board: ");
            DisplayBoard(gameBoard);

            while (this._gameResult == Enums.Result.Undecided && _moves < 9)
            {
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
                            Console.WriteLine("It's a Draw!");
                        case Enums.Result.Cat:  // No winner
                            break;
                        default:
                            Console.WriteLine("Game Over!");  // _gameResult has not been set properly somewhere. Sooo not good. 
                            break;
                    }

                    break;  // Exit the game loop
                }

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
                            Console.WriteLine("X Wins!");
                            break;
                        case Enums.Result.O_Wins:
                            Console.WriteLine("O Wins!");
                            break;
                        case Enums.Result.Cat:  // No winner
                            Console.WriteLine("It's a Draw!");
                            break;
                        default:
                            Console.WriteLine("Game Over!");  // Just in case something unexpected happens
                            break;
                    }

                    break;  // Exit the game loop
                }

            }

        }

        // Switch case is mapped to each position on the board
        private void MakeMove(Player player, Board gameBoard)
        {
            int position = getPlayerMove(gameBoard); // Valid user input returned

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

        // Validates user position before returning to MakeMove
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
