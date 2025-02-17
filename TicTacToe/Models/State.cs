using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Enums
{
    /// <summary>
    /// Represents the state of each Square
    /// </summary>
    internal enum State
    {
        X,
        O,
        Undecided   // Empty Square
    }
    /// <summary>
    /// Tracks the possible outcomes of the game and flags when it is finished
    /// </summary>
    internal enum Result
    {
        X_Wins,
        O_Wins,
        Cat,        // Draw, no winner
        Undecided   //Default value
    }
}
