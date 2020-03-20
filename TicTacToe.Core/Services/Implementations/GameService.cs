using System.Collections.Generic;
using System.Linq;
using TicTacToe.Core.Domain;
using TicTacToe.Core.Models;
using TicTacToe.Core.Utils;

namespace TicTacToe.Core.Services.Implementations
{
    public class GameService : IGameService
    {
        public HashSet<HashSet<Position>> WinConditions { get; } = new HashSet<HashSet<Position>>
        {
            new HashSet<Position> {Position.BotLeft, Position.BotCenter, Position.BotRight},
            new HashSet<Position> {Position.MidLeft, Position.MidCenter, Position.MidRight},
            new HashSet<Position> {Position.TopLeft, Position.TopCenter, Position.TopRight},

            new HashSet<Position> {Position.BotLeft, Position.MidLeft, Position.TopLeft},
            new HashSet<Position> {Position.BotCenter, Position.MidCenter, Position.TopCenter},
            new HashSet<Position> {Position.BotRight, Position.MidRight, Position.TopRight},

            new HashSet<Position> {Position.BotLeft, Position.MidCenter, Position.TopRight},
            new HashSet<Position> {Position.BotRight, Position.MidCenter, Position.TopLeft}
        };

        public GameStatus CurrentGameStatus { get; private set; }

        private Field _field;
        
        public GameService()
        {
            StartNewGame();
        }

        public GameStatus StartNewGame()
        {
            _field = new Field();
            CurrentGameStatus = new GameStatus {FieldState = GetFieldState()};
            return CurrentGameStatus;
        }

        public GameStatus Move(Position position, Mark mark)
        {
            if (!_field.Cells.ContainsKey(position))
                throw new GameValidityException($"Нарушена целостность поля: не найдено клетки в позиции {position}");

            var cell = _field.Cells[position];

            if (cell.Mark != Mark.Untouched)
                throw new GameValidityException($"Неверный ход: клетка в позиции {position} уже отмечена {cell.Mark}");

            cell.Mark = mark;

            var winner = FindWinner();

            CurrentGameStatus = new GameStatus
            {
                FieldState = GetFieldState(),
                IsGameFinished = winner.HasValue,
                Winner = winner
            };
            return CurrentGameStatus;
        }

        private Mark? FindWinner()
        {
            foreach (var winCondition in WinConditions)
            {
                var marks = winCondition
                    .Select(position => _field.Cells[position])
                    .Select(cell => cell.Mark)
                    .ToList();

                if (marks.All(x => x == Mark.Cross))
                    return Mark.Cross;

                if (marks.All(x => x == Mark.Circle))
                    return Mark.Circle;
            }

            if (_field.Cells.Values.All(x => x.Mark != Mark.Untouched))
                return Mark.Untouched;  // ничья

            return null;
        }

        private Dictionary<Position, Mark> GetFieldState()
        {
            return _field.Cells.ToDictionary(x => x.Key, x => x.Value.Mark);
        }
    }
}