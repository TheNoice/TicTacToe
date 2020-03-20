using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Core.Domain;
using TicTacToe.Core.Models;

namespace TicTacToe.Core.Services.Implementations
{
    public class RandomAiPlayerService : IAiPlayerService
    {
        private readonly HashSet<HashSet<Position>> _winConditions;
        private readonly Random _rng = new Random();

        public RandomAiPlayerService(HashSet<HashSet<Position>> winConditions)
        {
            _winConditions = winConditions;
        }

        public Position MakeTurn(Mark aiMark, GameStatus currentGameStatus)
        {
            var possibleTurns = currentGameStatus.FieldState
                .Where(x => x.Value == Mark.Untouched)
                .Select(x => x.Key)
                .ToList();

            return possibleTurns[_rng.Next(0, possibleTurns.Count)];
        }
    }
}