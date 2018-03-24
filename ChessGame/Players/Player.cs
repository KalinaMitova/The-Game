
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

        private string name;

        public Player(string name, ChessColor color)
        {
            this.Name = name;
            this.figures = new List<IFigure>();
            this.Color = color;
        }

        public ChessColor Color { get; private set; }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (value.Length > 20)
                {
                    throw new ArgumentException("The player name can not be longer than 20 characters!");
                }
                this.name = value;
            }
        }

        public void AddFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(GlobalErrorMessages.NullFigureErrorMessage);
            this.CheckIfFigureExists(figure);          
            this.figures.Add(figure);
        }

        public void RemoveFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(GlobalErrorMessages.NullFigureErrorMessage);
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
            if (!this.figures.Contains(figure))
            {
                throw new InvalidOperationException("This player does not own this figure!");
            }
        }

        private void CheckIfFigureColorPlayerColorAreAlike(IFigure figure)
        {
            if (figure.Color != this.Color)
            {
                throw new InvalidOperationException("This player does not own this figure!");
            }
        }
    }
}
