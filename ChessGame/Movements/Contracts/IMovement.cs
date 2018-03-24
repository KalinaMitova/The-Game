namespace ChessGame.Movements.Contracts
{
    using ChessGame.Board.Contracts;
    using ChessGame.Common;
    using ChessGame.Figures.Contracts;

    public interface IMovement
    {
        void ValidateMove(IFigure figure, IBoard board, Move move);
    }
}
