namespace ChessGame.InputProviders.Contracts
{
    using System.Collections.Generic;
    using ChessGame.Common;
    using ChessGame.Players.Contracts;

    public interface IInputProvider
    {
        IList<IPlayer> GetPlayers(int numberOfPlayers);

        Move GetNextPlayerMove(IPlayer player);
    }
}
