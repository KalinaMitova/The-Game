
namespace ChessGame.Movements
{
    using System;

    using ChessGame.Board.Contracts;
    using ChessGame.Common;
    using ChessGame.Figures.Contracts;
    using ChessGame.Movements.Contracts;

    public class NormalPawnMovement : IMovement
    {
        public const string PawnBackwardsErrorMessage = "Pawn cannot move backwards!";
        public const string PawnAvoidMoveErrorMessage = "Pawn cannot move that way!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            ChessColor color = figure.Color;
            Position from = move.From;
            Position to = move.To;

            if (color == ChessColor.White && to.Row <= from.Row)
            {
                throw new InvalidOperationException(PawnBackwardsErrorMessage);
            }

            if(color == ChessColor.Black && to.Row >= from.Row)
            {
                throw new InvalidOperationException(PawnBackwardsErrorMessage);
            }

            if(from.Row == 2 && color == ChessColor.White && this.CheckIfFigureExistAtPosition(board, to, color))
            {
                if (to.Row == from.Row + 2)
                {
                    return;
                }
            }

            if (from.Row == 7 && color == ChessColor.Black && this.CheckIfFigureExistAtPosition(board, to, color))
            {
                if (to.Row == from.Row - 2)
                {
                    return;
                }
            }

            if (color == ChessColor.White)
            {
                if (to.Row == from.Row + 1 &&
                    this.CheckDiagonalMove(from, to) &&
                    !CheckIfFigureExistAtPosition(board, to, ChessColor.Black))
                {
                    return;
                }
            }
            else if (color == ChessColor.Black)
            {
                if (to.Row == from.Row - 1 &&
                    this.CheckDiagonalMove(from, to) &&
                    !CheckIfFigureExistAtPosition(board, to, ChessColor.White))
                {
                    return;
                }
            }

           throw new InvalidOperationException(PawnAvoidMoveErrorMessage);
        }

        private bool CheckDiagonalMove(Position from, Position to)
        {
            return to.Col == from.Col - 1 || to.Col == from.Col + 1;
        }

        private bool CheckIfFigureExistAtPosition(IBoard board, Position to, ChessColor figureColor)
        {
            IFigure otherFigure = board.GetFigureAtPosition(to);

            if (otherFigure == null)
            {
                return true;
            }
            return false;
        }
    }
}
