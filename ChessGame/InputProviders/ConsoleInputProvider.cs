namespace ChessGame.InputProviders
{
    using System;
    using System.Collections.Generic;
    using ChessGame.Common;
    using ChessGame.Common.Console;
    using ChessGame.InputProviders.Contracts;
    using ChessGame.Players;
    using ChessGame.Players.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        private const string PlayerNameText = "Write Player {0} name: ";    

        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
           
        IList<IPlayer> players = new List<IPlayer>();
            
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.Clear();
                ConsoleHelpers.SetCursorAtCenter(PlayerNameText.Length);
                string name = String.Empty;
                do
                {
                    Console.Clear();
                    ConsoleHelpers.SetCursorAtCenter(PlayerNameText.Length);
                    Console.Write(PlayerNameText, i);
                    name = Console.ReadLine();                 

                } while (String.IsNullOrEmpty(name) && String.IsNullOrWhiteSpace(name)) ;

                ChessColor playerColor = (ChessColor)(i - 1);

                var player = new Player(name, playerColor);
                players.Add(player);
            }

            return players;
        }

        /// <summary>
        ///   Comand is in  format: a5-c5
        /// </summary>

        public Move GetNextPlayerMove(IPlayer player)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            string playerMessage = "{0} is next: ";

            int centerCol = Console.WindowWidth / 2 - playerMessage.Length / 2;
            Console.SetCursorPosition(centerCol, ConsoleConstants.ConsoleRowForCommandsAndMessages);

            Console.Write(playerMessage, player.Name);
            var positionAsString = Console.ReadLine().Trim().ToLower();

            ConsoleHelpers.ClearRow(centerCol);
            return ConsoleHelpers.CreateMoveFromCommand(positionAsString);
        }
        
    }
}
