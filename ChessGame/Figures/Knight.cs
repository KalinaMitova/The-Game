namespace ChessGame.Figures
{
    using ChessGame.Common;
    using ChessGame.Figures.Contracts;

    public class Knight : BaseFigure, IFigure
    {
        public Knight(ChessColor color) 
            : base(color)
        {
        }
    }
}
