using System;

namespace TicTacToe.Core.Utils
{
    public class GameValidityException : Exception
    {
        public GameValidityException(string message) : base(message)
        {
        }
    }
}