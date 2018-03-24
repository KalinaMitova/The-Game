namespace ChessGame
{
    using System;

    using ChessGame.Engine;
    using ChessGame.Engine.Contracts;
    using ChessGame.Engine.Initializations;
    using ChessGame.InputProviders;
    using ChessGame.InputProviders.Contracts;
    using ChessGame.Renderers;
    using ChessGame.Renderers.Contracts;
   

    public static class ChessFacade
    {
        public static void Start()
        {

              IRenderer consoleRenderer = new ConsoleRenderer();
              //consoleRenderer.RenderMainMenu();

              IInputProvider inputProvider = new ConsoleInputProvider();
              IEngine chessEngine = new StandardTwoPlayerEngine(consoleRenderer, inputProvider);
              var strategy = new StandardGameInitializationStrategy();

              chessEngine.Initialize(strategy);
              chessEngine.StartGame();

        }
      
    }
}
