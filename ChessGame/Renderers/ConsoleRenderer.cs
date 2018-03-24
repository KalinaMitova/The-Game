
namespace ChessGame.Renderers
{
    using System;
    using System.Threading;
    using ChessGame.Board.Contracts;
    using ChessGame.Common;
    using ChessGame.Common.Console;
    using ChessGame.Renderers.Contracts;

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "Welcome to the Chess Game!";
        private const ConsoleColor DarkSquerConsoleColor = ConsoleColor.DarkYellow;
        private const ConsoleColor LightSquerConsoleColor = ConsoleColor.Yellow;

        public ConsoleRenderer()
        {
            Console.SetWindowSize((GlobalConstants.StandardGameTotalBoardCols + 2) * ConsoleConstants.CharactersPerColPerBoardSquer,
                                  (GlobalConstants.StandardGameTotalBoardCols + 1) * ConsoleConstants.CharactersPerRowPerBoardSquer);

            Console.SetBufferSize((GlobalConstants.StandardGameTotalBoardCols + 2) * ConsoleConstants.CharactersPerColPerBoardSquer,
                                  (GlobalConstants.StandardGameTotalBoardCols + 1) * ConsoleConstants.CharactersPerRowPerBoardSquer);

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }

        public void RenderMainMenu()
        {
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);

            //TODO: add main menu
            Thread.Sleep(1000);
            Console.WriteLine(Logo);
            Thread.Sleep(1000);
        }

        public void RenderBoard(IBoard board)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            var backgroundColor = Console.BackgroundColor;

            var startRowPrint = Console.WindowHeight / 2 - board.TotalRows / 2 * ConsoleConstants.CharactersPerRowPerBoardSquer;
            var startColPrint = Console.WindowWidth / 2 - board.TotalCols / 2 * ConsoleConstants.CharactersPerColPerBoardSquer;

            var currentRowPrint = startRowPrint;
            var currentColPrint = startColPrint;         

            PrintBorder(startRowPrint, startColPrint, board.TotalRows, board.TotalCols);

            int counter = 1;

            for (int top = 0; top < board.TotalRows; top++)
            {
                for (int left = 0; left < board.TotalCols; left++)
                {
                    currentRowPrint = startRowPrint + top * ConsoleConstants.CharactersPerColPerBoardSquer;
                    currentColPrint = startColPrint + left * ConsoleConstants.CharactersPerRowPerBoardSquer;

                    if (counter % 2 == 0)
                    {
                        backgroundColor = DarkSquerConsoleColor;
                    }
                    else
                    {
                        backgroundColor = LightSquerConsoleColor;
                    }

                    var currentPosition = Position.GetPositionFromArrayCoordinates(top, left, board.TotalRows);
                    var figure = board.GetFigureAtPosition(currentPosition);

                    ConsoleHelpers.PrintFigure(figure, backgroundColor, currentRowPrint, currentColPrint);
                    counter++;
                }

                counter++;
            }
        }

        public void PrintErrorMessage(string message)
        {
            int centerCol = Console.WindowWidth / 2 - message.Length / 2;
            Console.SetCursorPosition(centerCol, ConsoleConstants.ConsoleRowForCommandsAndMessages);
            Console.Write(message);
            Thread.Sleep(2500);
            ConsoleHelpers.ClearRow(centerCol);
        }

        private static void PrintBorder(int startRowPrint, int startColPrint, int boardTotalRow, int boardTotalCol )
        {
            int horizontalBorderStartColPrint = startColPrint - 2;
            int horizontalBorderEndColPrint = startColPrint + boardTotalCol * ConsoleConstants.CharactersPerColPerBoardSquer - 5;
            int upperHorizontalStartBorderRowPrint = startRowPrint - 2;
            int lowerHorizontalStartBorderRowPrint = startRowPrint + boardTotalRow * ConsoleConstants.CharactersPerRowPerBoardSquer + 1;

            //Print upper border
            PrintHorizontalBorder(upperHorizontalStartBorderRowPrint, horizontalBorderStartColPrint, horizontalBorderEndColPrint);
            //Print lower border  
            PrintHorizontalBorder(lowerHorizontalStartBorderRowPrint, horizontalBorderStartColPrint, horizontalBorderEndColPrint);

            int verticalBorderStartRowPrint = startRowPrint - 1;
            int verticalBorderEndRowPrint = startRowPrint + boardTotalRow * ConsoleConstants.CharactersPerRowPerBoardSquer - 2;
            int leftVerticalBorderColPrint = startColPrint - 2;
            int rightVerticalBorderColPrint = startColPrint + boardTotalCol * ConsoleConstants.CharactersPerRowPerBoardSquer + 1;

            //Print left border
            PrintVerticalBorder(verticalBorderStartRowPrint, verticalBorderEndRowPrint, leftVerticalBorderColPrint);
            //Print right border
            PrintVerticalBorder(verticalBorderStartRowPrint, verticalBorderEndRowPrint, rightVerticalBorderColPrint);

            int upperHorizontalCharacterRowPrint = startRowPrint - 1;
            int lowerHorizontalCharacterRowPrint = startRowPrint + boardTotalRow * ConsoleConstants.CharactersPerRowPerBoardSquer;
            int horizontalCharacterColStartPrint = startColPrint + ConsoleConstants.CharactersPerColPerBoardSquer / 2;

            //Print upper character row
            PrintCharacterRow(boardTotalCol, upperHorizontalCharacterRowPrint, horizontalCharacterColStartPrint);
            //Print lower character row 
            PrintCharacterRow(boardTotalCol, lowerHorizontalCharacterRowPrint, horizontalCharacterColStartPrint);

            int leftNumColPrint = startColPrint - 1;
            int rightNumColPrint = startColPrint + boardTotalCol * ConsoleConstants.CharactersPerColPerBoardSquer;
            int numColRowStartPrint = startRowPrint + boardTotalRow / 2;

            //Print left character column
            PrintNumberColumn(boardTotalRow, leftNumColPrint, numColRowStartPrint);
            //Print right character column
            PrintNumberColumn(boardTotalRow, rightNumColPrint, numColRowStartPrint);
        }

        private static void PrintNumberColumn(int boardTotalRow, int numColPrint, int numColRowStartPrint)
        {
            for (int row = 0; row < boardTotalRow; row++)
            {
                Console.SetCursorPosition(numColPrint, numColRowStartPrint + row * ConsoleConstants.CharactersPerRowPerBoardSquer);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(boardTotalRow - row);
            }
        }

        private static void PrintCharacterRow(int boardTotalCol, int horizontalCharacterRowPrint, int horizontalCharacterColStartPrint)
        {
            for (int col = 0; col < boardTotalCol; col++)
            {
                Console.SetCursorPosition(horizontalCharacterColStartPrint +
                                          (col) * (ConsoleConstants.CharactersPerColPerBoardSquer),
                                          horizontalCharacterRowPrint);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write((char)('A' + col));
            }
        }

        private static void PrintHorizontalBorder(int horizontalBorderStartRowPrint, int horizontalBorderStartColPrint, int horizontalBorderEndColPrint)
        {
            for (int col = 0; col < horizontalBorderEndColPrint; col++)
            {
                Console.SetCursorPosition(horizontalBorderStartColPrint + col, horizontalBorderStartRowPrint);
                Console.BackgroundColor = DarkSquerConsoleColor;
                Console.Write(" ");
            }
        }

        private static void PrintVerticalBorder(int verticalBorderStartRowPrint, int verticalBorderEndRowPrint, int verticalBoardColPrint)
        {
            for (int row = 0; row < verticalBorderEndRowPrint; row++)
            {
                Console.SetCursorPosition(verticalBoardColPrint, verticalBorderStartRowPrint + row);
                Console.BackgroundColor = DarkSquerConsoleColor;
                Console.Write(" ");
            }
        }


    }
}
