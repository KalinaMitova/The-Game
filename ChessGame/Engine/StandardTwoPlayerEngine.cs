namespace ChessGame.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ChessGame.Board;
    using ChessGame.Board.Contracts;
    using ChessGame.Common;
    using ChessGame.Common.Console;
    using ChessGame.Engine.Contracts;
    using ChessGame.Figures.Contracts;
    using ChessGame.InputProviders.Contracts;
    using ChessGame.Players;
    using ChessGame.Players.Contracts;
    using ChessGame.Renderers.Contracts;

    public class StandardTwoPlayerEngine : IEngine
    {
        private IList<IPlayer> players;
        private readonly IBoard board;
        private readonly IRenderer renderer;
        private readonly IInputProvider inputProvider;

        private int currentPlayerIndex;

        public StandardTwoPlayerEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.inputProvider = inputProvider;
            this.players = new List<IPlayer>();
            this.board = new Board();
        }

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            //TODO: Remove using ChessGame.Players and use input for players
            this.players = new List<IPlayer>
            {
                new Player("Pepi", ChessColor.White),
                new Player("Niki", ChessColor.Black)
            };//this.inputProvider.GetPlayers(GlobalConstants.StandardNumberOfPlayers);

            this.SetFirstPlayerIndex();
            gameInitializationStrategy.Initialization(this.players, this.board);
            this.renderer.RenderBoard(this.board);
        }

        public void StartGame()
        {          
            while (true)
            {
                try
                {
                    IPlayer player = this.GetNextPlayer();
                    IPlayer otherPlayer = this.GetNextPlayer();
                    this.currentPlayerIndex--;

                    Move move = this.inputProvider.GetNextPlayerMove(player);
                    Position from = move.From;
                    Position to = move.To;
                    IFigure figure = this.board.GetFigureAtPosition(from);
                    IFigure figureAtToPosition = this.board.GetFigureAtPosition(to);

                    this.CheckIfPlayerOwnsFigure(player, figure, from);
                    this.CheckIfToPositionIsEmpty(figure, figureAtToPosition, to);

                    var availableMovements = figure.Move();
                    foreach (var movement in availableMovements)
                    {
                        movement.ValidateMove(figure, this.board, move);
                    }

                    if (figureAtToPosition != null)
                    {
                        otherPlayer.RemoveFigure(figureAtToPosition);
                    }

                    this.board.MoveFigureAtPositon(from, to, figure);
                    this.renderer.RenderBoard(this.board);
                    //Check pawn on last row
                    //TODO: On every move check if we are in check
                    //TODO: Chack castle - check if castle is valid
                    //TODO: If not castle valid - move Figure( Check pawn for Ann-Pasan)
                    //TODO: Check check
                    //TODO: If check in check - check checkmate
                    //TODO: If not checkmate - check draw
                    //TODO: Continue
                    //TODO: If in checkmate - game over

                }
                catch (Exception ex)
                {
                    this.currentPlayerIndex --;
                    this.renderer.PrintErrorMessage(ex.Message);
                }

            }
        }       

        private void SetFirstPlayerIndex()
        {
            for (int i = 0; i < this.players.Count; i++)
            {

                if (players[i].Color == ChessColor.White)
                {
                    this.currentPlayerIndex = i;
                    break;
                }
            }
        }

        private IPlayer GetNextPlayer()
        {
            if (this.currentPlayerIndex >= this.players.Count)
            {
                this.currentPlayerIndex = 0;
            }

            var player = this.players[currentPlayerIndex];

            this.currentPlayerIndex++;

            return player;
        }

        public void WinningConditions()
        {
            throw new System.NotImplementedException();
        }

        private void CheckIfPlayerOwnsFigure(IPlayer player, IFigure figure, Position position)
        {
       
            if (figure == null)
            {
                throw new InvalidOperationException($"POSITION {position.Col.ToString().ToUpper()}{position.Row} IS EMPTY!");
            }

            if (figure.Color != player.Color)
            {
                throw new InvalidOperationException($"FIGURE AT {position.Col.ToString().ToUpper()}{position.Row} IS NOT YOURS!");
            }
        }


        private void CheckIfToPositionIsEmpty(IFigure figure, IFigure figureAtToPosition, Position to)
        {
            if (figureAtToPosition != null && figureAtToPosition.Color == figure.Color)
            {
                throw new InvalidOperationException($"YOU ALREADY HAVE A FIGURE AT POSITION {to.Col.ToString().ToUpper()}{to.Row}!");
            }
        }
    }
}
