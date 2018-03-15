
namespace ChessGame.Figures
{
    using ChessGame.Common;
    using ChessGame.Figures.Contracts;

    public class Queen : BaseFigure, IFigure
    {
        protected Queen(ChessColor color) 
            : base(color)
        {
        }
    }
}
