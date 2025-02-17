// See https://aka.ms/new-console-template for more information
using TicTacToe.Models;

//****************************** Game Instructions ***************************
Console.WriteLine("\t\t\t************** This is a Tic-Tac-Toe Game! **************\n");
Console.WriteLine("\t The Tic-Tac-Toe position is labeled 1-9. 1 being the top left and 9 being the bottom right.");
Console.WriteLine("\t You will play by entering an integer 1-9 to play in the corresponding position on the board.");
Console.WriteLine("\t Player 1 will be 'X' and go first.\n");
//****************************************************************************


GameManager manager = new GameManager();

// Create Players
Player player1 = manager.CreatePlayer(1);
Player player2 = manager.CreatePlayer(2);

// Run TicTacToe game
manager.StartGame(player1, player2);

// Exit
Console.Write("\nPress any key and enter to quit: ");
Console.ReadLine();
