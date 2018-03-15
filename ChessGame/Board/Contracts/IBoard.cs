

namespace ChessGame.Board.Contracts
{
    using ChessGame.Common;
    using ChessGame.Figures.Contracts;

    public interface IBoard
    {
        int TotalRows { get; }

        int TotalCols { get;}

        void AddFigure(IFigure figure, Position position);

        void RemoveFigure(Position position);
    }
}
