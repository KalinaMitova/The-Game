namespace ChessGame.Figures
{
    using ChessGame.Common;
    using ChessGame.Figures.Contracts;

    public class Bishop : BaseFigure, IFigure
    {
        public Bishop(ChessColor color) 
            : base(color)
        {
        }
    }
}
