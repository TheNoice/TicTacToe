namespace TicTacToe.Core.Domain
{
    public class Cell
    {
        public Cell(Position position)
        {
            Position = position;
        }

        public Position Position { get; }

        public Mark Mark { get; set; } = Mark.Untouched;
    }
}