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
    }
}
