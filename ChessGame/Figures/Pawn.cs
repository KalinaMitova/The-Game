
namespace ChessGame.Figures
{
    using ChessGame.Common;
    using ChessGame.Figures.Contracts;

    public class Pawn : BaseFigure, IFigure
    {

        public Pawn(ChessColor color)
            :base(color)
        {
        }
    }
}
