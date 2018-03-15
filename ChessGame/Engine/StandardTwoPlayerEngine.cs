namespace ChessGame.Engine
{
    using System.Collections.Generic;

    using ChessGame.Engine.Contracts;
    using ChessGame.Players.Contracts;
    using ChessGame.Renderers.Contracts;

    public class StandardTwoPlayerEngine : IEngine
    {
        private readonly IEnumerable<IPlayer> players;
        private readonly IRenderer renderer;


        public IEnumerable<IPlayer> Players => new List<IPlayer>(players) ;

        public void Initialize(IGameInitializationStrategy gameInitializationStratagy)
        {
            throw new System.NotImplementedException();
        }

        public void StartGame()
        {
            throw new System.NotImplementedException();
        }

        public void WinningConditions()
        {
            throw new System.NotImplementedException();
        }
    }
}
