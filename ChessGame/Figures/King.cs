namespace ChessGame.Figures
{
    using ChessGame.Common;
    using ChessGame.Figures.Contracts;

    public class King : BaseFigure, IFigure
    {
        public King(ChessColor color)
            :base(color)
        {

        }
    }
}
