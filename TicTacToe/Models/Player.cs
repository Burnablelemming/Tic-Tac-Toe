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
        public State playerState { get; set; }
    }
}
