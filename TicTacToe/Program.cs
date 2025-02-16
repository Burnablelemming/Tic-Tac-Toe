// See https://aka.ms/new-console-template for more information
using TicTacToe.Models;

Player player1 = new Player("Carl", TicTacToe.Enums.State.X);
Player player2 = new Player("Kimber", TicTacToe.Enums.State.O);

GameManager manager = new GameManager();

manager.StartGame(player1, player2);
