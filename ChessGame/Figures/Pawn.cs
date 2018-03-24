
namespace ChessGame.Figures
{
    using System.Collections.Generic;

    using ChessGame.Common;
    using ChessGame.Figures.Contracts;
    using ChessGame.Movements;
    using ChessGame.Movements.Contracts;

    public class Pawn : BaseFigure, IFigure
    {
        public Pawn(ChessColor color)
            : base(color)
        {
        }

        public override ICollection<IMovement> Move()
        {
            return new List<IMovement>
            {
                new NormalPawnMovement()
            };
        }
    }
}
