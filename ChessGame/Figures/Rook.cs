namespace ChessGame.Figures
{
    using ChessGame.Common;
    using ChessGame.Figures.Contracts;

    public class Rook : BaseFigure, IFigure
    {
        public Rook(ChessColor color) 
            : base(color)
        {
        }
    }
}
