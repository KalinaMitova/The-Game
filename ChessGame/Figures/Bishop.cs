namespace ChessGame.Figures
{
    using System.Collections.Generic;

    using ChessGame.Common;
    using ChessGame.Figures.Contracts;
    using ChessGame.Movements.Contracts;

    public class Bishop : BaseFigure, IFigure
    {
        public Bishop(ChessColor color) 
            : base(color)
        {
        }

        public override ICollection<IMovement> Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
