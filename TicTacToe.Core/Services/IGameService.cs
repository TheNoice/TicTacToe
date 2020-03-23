using System.Collections.Generic;
using TicTacToe.Core.Domain;
using TicTacToe.Core.Models;

namespace TicTacToe.Core.Services
{
    public interface IGameService
    {
        GameStatus CurrentGameStatus { get; }

        HashSet<HashSet<Position>> WinConditions { get; }

        GameStatus StartNewGame();

        GameStatus Move(Position position, Mark mark);
    }
}