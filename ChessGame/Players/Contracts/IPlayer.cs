namespace ChessGame.Players.Contracts
{
    using System.Collections;
    using ChessGame.Common;
    using ChessGame.Figures.Contracts;

    public interface IPlayer
    {
        ChessColor Color { get; }

        string Name { get; }

        void AddFigure(IFigure figure);

        void RemoveFigure(IFigure figure);
    }
}
