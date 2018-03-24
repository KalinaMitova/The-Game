namespace ChessGame.Board
{
    using ChessGame.Board.Contracts;
    using ChessGame.Common;
    using ChessGame.Figures.Contracts;

    public class Board : IBoard
    {
        private IFigure[,] board;

        public Board(int rows = GlobalConstants.StandardGameTotalBoardRows, 
                     int cols = GlobalConstants.StandardGameTotalBoardCols)
        {
            this.TotalRows = rows;
            this.TotalCols = cols;
            this.board = new IFigure[rows, cols];
        }

        public int TotalRows { get; private set; }

        public int TotalCols { get; private set; }

        public void AddFigure(IFigure figure, Position position)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);
            
            this.board[this.GetArrayRow(position.Row), this.GetArrayCol(position.Col)] = figure;

        }

        public void RemoveFigure(Position position)
        {
            this.board[this.GetArrayRow(position.Row), this.GetArrayCol(position.Col)] = null;
        }

        public IFigure GetFigureAtPosition(Position position)
        {
            return this.board[this.GetArrayRow(position.Row), this.GetArrayCol(position.Col)];
        }

        public void MoveFigureAtPositon(Position from, Position to, IFigure figure)
        {
            this.RemoveFigure(to);
            this.RemoveFigure(from);
            this.AddFigure(figure, to);
        }

        private int GetArrayRow(int chessBoardRow) 
        {
            return this.TotalRows - chessBoardRow;
        }

        private int GetArrayCol(char chessBoardCol)
        {
            return chessBoardCol - 'a';
        }
    }
}
