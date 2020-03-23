using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Core.Domain;
using TicTacToe.Core.Models;

namespace TicTacToe.Core.Services.Implementations
{
    public class SmartAiPlayerService : IAiPlayerService
    {
        private readonly HashSet<HashSet<Position>> _winConditions;

        public SmartAiPlayerService(HashSet<HashSet<Position>> winConditions)
        {
            _winConditions = winConditions;
        }

        public Position MakeTurn(GameStatus currentGameStatus)
        {
            List<Position> occupiedPositions = currentGameStatus.FieldState
                .Where(x => x.Value != Mark.Untouched)
                .Select(x => x.Key)
                .ToList();

            List<Position> freePositions = currentGameStatus.FieldState
                .Where(x => x.Value == Mark.Untouched)
                .Select(x => x.Key)
                .ToList();

            if (occupiedPositions.Count < 2)
            {
                Random computerChoice = new Random();
                return freePositions[computerChoice.Next(0, freePositions.Count)];
            }
            else
            {
                return ComputerFindsBestPosition(currentGameStatus, freePositions);
            }
        }

        private Position ComputerFindsBestPosition(GameStatus currentGameStatus, List<Position> freePositions)
        {
            Position? choosedPosition = ComputerFirstOptionTurn(currentGameStatus);
            if (choosedPosition != null)
            {
                return (Position)choosedPosition;
            }
            choosedPosition = ComputerSecondOptionTurn(currentGameStatus);
            if (choosedPosition != null)
            {
                return (Position)choosedPosition;
            }
            Random computerChoice = new Random();
            return freePositions[computerChoice.Next(0, freePositions.Count)];
        }

        /// <summary>
        /// Пытается найти позицию для победы. Если невозможно - пытается законтрить оппонента. Если невозможно, вернет null.
        /// </summary>
        /// <param name="currentGameStatus"></param>
        /// <param name="occupiedPositions"></param>
        /// <param name="freePositions"></param>
        /// <returns></returns>
        private Position? ComputerFirstOptionTurn(GameStatus currentGameStatus)
        {
            Position? firstOptionPos = null;
            firstOptionPos = ComputerTryWinOrCounter(currentGameStatus, Mark.Circle);
            if (firstOptionPos != null)
            {
                return firstOptionPos;
            }
            firstOptionPos = ComputerTryWinOrCounter(currentGameStatus, Mark.Cross);
            if (firstOptionPos != null)
            {
                return firstOptionPos;
            }
            return firstOptionPos;
        }

        private Position? ComputerTryWinOrCounter(GameStatus currentGameStatus, Mark playerMark) //Circle - win, Cross - counter
        {
            foreach (HashSet<Position> winCondition in _winConditions)
            {
                int playersMarks = 0;
                int untouchedMarks = 0;
                Position tmpPosition = new Position();
                foreach (Position pos in winCondition)
                {
                    if (currentGameStatus.FieldState[pos] == playerMark)
                    {
                        playersMarks++;
                    }
                    if (currentGameStatus.FieldState[pos] == Mark.Untouched)
                    {
                        untouchedMarks++;
                        tmpPosition = pos;
                    }
                }
                if (playersMarks == 2 && untouchedMarks == 1)
                {
                    return tmpPosition;
                }
            }
            return null;
        }

        /// <summary>
        /// Пытается найти такую строку, столбец или диагональ, где есть один <see cref="Mark.Circle"/> и две пустых клетки.
        /// Если нашел, вернет позицию одну из пустых клеток в этой строке/столбце/диагонали
        /// </summary>
        /// <param name="currentGameStatus"></param>
        /// <returns></returns>
        private Position? ComputerSecondOptionTurn(GameStatus currentGameStatus)
        {
            foreach (HashSet<Position> winCondition in _winConditions)
            {
                int playersMarks = 0;
                int untouchedMarks = 0;
                Position tmpPosition = new Position();
                foreach (Position pos in winCondition)
                {
                    if (currentGameStatus.FieldState[pos] == Mark.Circle)
                    {
                        playersMarks++;
                    }
                    if (currentGameStatus.FieldState[pos] == Mark.Untouched)
                    {
                        untouchedMarks++;
                        tmpPosition = pos;
                    }
                }
                if (playersMarks == 1 && untouchedMarks == 2)
                {
                    return tmpPosition;
                }
            }
            return null;
        }

    }
}
