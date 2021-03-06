﻿namespace ChessGame.Engine.Contracts
{
    using System.Collections.Generic;
    using ChessGame.Engine.Contracts;
    using ChessGame.Players.Contracts;

    public interface  IEngine
    {
        IEnumerable<IPlayer> Players { get; }

        void Initialize(IGameInitializationStrategy gameInitializationStratagy);

        void StartGame();

        void WinningConditions();
    }
}
