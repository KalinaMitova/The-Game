namespace ChessGame.Board
{
    using System;

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
            this.CheckIfPositionIsValid(position);
            
            this.board[this.GetArrayRow(position.Row), this.GetArrayCol(position.Col)] = figure;

        }

        public void RemoveFigure(Position position)
        {
            this.CheckIfPositionIsValid(position);

            this.board[this.GetArrayRow(position.Row), this.GetArrayCol(position.Col)] = null;
        }

        private int GetArrayRow(int chessBoardRow) 
        {
            return this.TotalRows - chessBoardRow;
        }

        private int GetArrayCol(char chessBoardCol)
        {
            return chessBoardCol - 'a';
        }

        private void CheckIfPositionIsValid(Position position)
        {
            if(position.Row < GlobalConstants.MinRowValueOnBoard 
                | position.Row > this.TotalRows )
            {
                throw new IndexOutOfRangeException("Selected row position on the row is not valid!");
            }

            if (position.Col < GlobalConstants.MinColValueOnBoard
                | position.Col > Convert.ToChar(this.TotalCols + GlobalConstants.MinColValueOnBoard))
            {
                throw new IndexOutOfRangeException("Selected column position on the row is not valid!");
            }
        }
    }
}
