
namespace ChessGame.Players
{
    using System;
    using System.Collections.Generic;

    using ChessGame.Common;
    using ChessGame.Figures.Contracts;
    using ChessGame.Players.Contracts;

    public class Player : IPlayer
    {
        private readonly ICollection<IFigure> figures;

        public Player(string name, ChessColor color)
        {
            this.Name = name;
            this.figures = new List<IFigure>();
            this.Color = color;
        }

        public ChessColor Color { get; private set; }

        public string Name { get; private set; }

        public void AddFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(GlobalErrorMessages.NullFigureErrorMessage);
            //TODO:Check player and figure color
            this.CheckIfFigureExists(figure);          
            this.figures.Add(figure);
        }

        public void RemoveFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(GlobalErrorMessages.NullFigureErrorMessage);
            //TODO:Check player and figure color
            this.CheckIfFigureDoesNotExest(figure);
            this.figures.Remove(figure);
        }

        private void CheckIfFigureExists(IFigure figure)
        {
            if (this.figures.Contains(figure))
            {
                throw new InvalidOperationException("This player already owns this figure!");
            }
        }

        private void CheckIfFigureDoesNotExest(IFigure figure)
        {
            throw new InvalidOperationException("This player does not own this figure!");
        }
    }
}
