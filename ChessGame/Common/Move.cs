namespace ChessGame.Common
{
    public struct Move
    {
        public Position From { get; private set; }
        public Position To { get; private set; }

        public Move(Position from, Position to)
        {
            this.From = from;
            this.To = to;
        }
    }
}
