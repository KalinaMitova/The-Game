namespace ChessGame.Engine.Initializations
{
    using System;
    using System.Collections.Generic;

    using ChessGame.Board.Contracts;
    using ChessGame.Common;
    using ChessGame.Engine.Contracts;
    using ChessGame.Figures;
    using ChessGame.Figures.Contracts;
    using ChessGame.Players.Contracts;

    public class StandardGameInitializationStrategy : IGameInitializationStrategy
    {

        private IList<Type> figureTypes;

        public StandardGameInitializationStrategy()
        {
            this.figureTypes = new List<Type>
            {
                typeof(Rook),
                typeof(Bishop),
                typeof(Knight),
                typeof(Queen),
                typeof(King),
                typeof(Knight),
                typeof(Bishop),
                typeof(Rook)
            };
        }

        public void Initialization(IList<IPlayer> players, IBoard board)
        {
            ValidateStratagy(players, board);

            IPlayer firstPlayer = players[0];
            IPlayer secondPlayer = players[1];

            //First player pawns row (2) and First player main figure row (1)
            AddPawnsToBoardRow(firstPlayer, board, GlobalConstants.StandardFirstPlayerPawnChessRow);
            AddPlayerMainFiguresRowToBoard(firstPlayer, board, GlobalConstants.StandardFirstPlayerMainFigureChessRow);

            //Second player pawns row (7) and Second player main figure row (8)
            AddPawnsToBoardRow(secondPlayer, board, GlobalConstants.StandardSecondPlayerPawnChessRow);
            AddPlayerMainFiguresRowToBoard(secondPlayer, board, GlobalConstants.StandardSecondPlayerMainFigureChessRow);
        }

        private void AddPawnsToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < GlobalConstants.StandardGameTotalBoardCols; i++)
            {
                IFigure pawn = new Pawn(player.Color);
                Position position = new Position(chessRow, (char)(i + 'a'));

                player.AddFigure(pawn);
                board.AddFigure(pawn, position);
            }
        }

        private void AddPlayerMainFiguresRowToBoard(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < GlobalConstants.StandardGameTotalBoardCols; i++)
            {
                var figureType = this.figureTypes[i];
                var figureInstance = (IFigure)Activator.CreateInstance(figureType, player.Color);
                Position position = new Position(chessRow, (char)(i + 'a'));

                player.AddFigure(figureInstance);
                board.AddFigure(figureInstance, position);
            }
        }

        private void ValidateStratagy(IList<IPlayer> players, IBoard board)
        {
            if (players.Count != GlobalConstants.StandardNumberOfPlayers)
            {
                throw new InvalidOperationException("Standard Game Initialization Strategy needs exactly two players!");
            }

            if (board.TotalRows != GlobalConstants.StandardGameTotalBoardRows
                || board.TotalCols != GlobalConstants.StandardGameTotalBoardCols)
            {
                throw new InvalidOperationException("Standard Game Initialization Strategy needs 8x8 board!");
            }
        }
    }
}
