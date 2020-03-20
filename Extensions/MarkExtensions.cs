using System.Collections.Generic;
using TicTacToe.Core.Domain;

namespace TicTacToe.Extensions
{
    public static class MarkExtensions
    {
        private static readonly Dictionary<Mark, string> MarkTextMap = new Dictionary<Mark, string>
        {
            {Mark.Untouched, string.Empty },
            {Mark.Circle, "O"},
            {Mark.Cross, "X"}
        };

        public static string ToText(this Mark mark)
        {
            return MarkTextMap[mark];
        }
    }
}