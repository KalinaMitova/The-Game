namespace ChessGame.Engine.Contracts
    {
    using System.Collections.Generic;

    using ChessGame.Board.Contracts;
    using ChessGame.Players.Contracts;

    public interface IGameInitializationStrategy
    {
        void Initialization(IList<IPlayer> players, IBoard board);

    }
}
