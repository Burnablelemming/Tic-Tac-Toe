using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Enums
{
    internal enum State
    {
        X,
        O,
        Undecided
    }
    internal enum Result
    {
        X_Wins,
        O_Wins,
        Cat,        // Draw, no winner
        Undecided
    }
}
