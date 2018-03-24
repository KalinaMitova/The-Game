
namespace ChessGame.Figures.Contracts
{
    using System.Collections.Generic;

    using ChessGame.Common;
    using ChessGame.Movements.Contracts;

    public interface IFigure
    {
        ChessColor Color { get; }

        ICollection<IMovement> Move();
    }
}
