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
       

        public String Name { get; set; }
        public State PlayerChoice { get; set; }
        public Result GameResult { get; set; }

        public Player() 
        {
            this.Name = "Undefined";
            this.PlayerChoice = Enums.State.Undecided;
            this.GameResult = Enums.Result.Undecided;

        }

        public Player(string name, State playerChoice)
        {
            Name = name;
            PlayerChoice = playerChoice;
            GameResult = Enums.Result.Undecided;
        }
    }
}
