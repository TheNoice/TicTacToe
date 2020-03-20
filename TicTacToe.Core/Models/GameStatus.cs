using System.Collections.Generic;
using TicTacToe.Core.Domain;

namespace TicTacToe.Core.Models
{
    public class GameStatus
    {
        public bool IsGameFinished { get; set; }

        public Mark? Winner { get; set; }

        public IDictionary<Position, Mark> FieldState { get; set; }
    }
}