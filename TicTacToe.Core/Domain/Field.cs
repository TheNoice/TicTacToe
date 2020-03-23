using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Core.Domain
{
    public class Field
    {
        public Field()
        {
            Cells = Enum.GetValues(typeof(Position))
                .Cast<Position>()
                .Select(pos => new Cell(pos))
                .ToDictionary(x => x.Position, x => x);
        }

        public Dictionary<Position, Cell> Cells { get; }
    }
}