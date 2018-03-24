namespace ChessGame.Common
{
    using System;

    public struct Position
    {
        public static Position GetPositionFromArrayCoordinates(int arrRow, int arrCol, int totalBoardRows)
        {
            return new Position(
                        totalBoardRows- arrRow,
                        (char)(arrCol + 'a')
                        );
        }

        private int row;
        private char col;

        public Position(int row, char col)
            :this()
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row {
            get { return this.row; }

            private set
            { 
                if (value < GlobalConstants.MinRowValueOnBoard
               | value > GlobalConstants.MaxRowValueOnBoard)
                {
                    throw new IndexOutOfRangeException("Selected row position on the board is not valid!");
                }
                this.row = value;
            }
        }

        public char Col {
            get { return this.col; }

            set
            {
                if (value < GlobalConstants.MinColValueOnBoard
                    | value > Convert.ToChar(GlobalConstants.MaxColValueOnBoard))
                {
                    throw new IndexOutOfRangeException("Selected column position on the board is not valid!");
                }

                this.col = value;
            }
        }
    }
}
