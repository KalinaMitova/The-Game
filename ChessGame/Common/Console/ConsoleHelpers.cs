namespace ChessGame.Common.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ChessGame.Figures;
    using ChessGame.Figures.Contracts;

    public static class ConsoleHelpers
    {
        private static IDictionary<Type, bool[,]> figuresPatterns = new Dictionary<Type, bool[,]>
        {
            { typeof(Pawn) , new bool[,]
                {
                    { false, false, false, false, false, false, false, false, false},
                    { false, false, false, false, false, false, false, false, false},
                    { false, false, false, false, true, false, false, false, false},
                    { false, false, false, true, true, true, false, false, false},
                    { false, false, false, true, true, true, false, false, false},
                    { false, false, false, false, true, false, false, false, false},
                    { false, false, false, true, true, true, false, false, false},
                    { false, false, true, true, true, true, true, false, false},
                    { false, false, false, false, false, false, false, false, false}
                }},
             { typeof(Rook) , new bool[,]
                {
                    { false, false, false, false, false, false, false, false, false},
                    { false, false, true, false, true, false, true, false, false},
                    { false, false, false, true, true, true, false, false, false},
                    { false, false, false, true, true, true, false, false, false},
                    { false, false, false, true, true, true, false, false, false},
                    { false, false, false, true, true, true, false, false, false},
                    { false, false, true, true, true, true, true, false, false},
                    { false, false, true, true, true, true, true, false, false},
                    { false, false, false, false, false, false, false, false, false}
                }},
            { typeof(Knight) , new bool[,]
                {
                    { false, false, false, false, false, false, false, false, false},
                    { false, false, false, false, true, false, false, false, false},
                    { false, false, false, true, true, true, false, false, false},
                    { false, false, true, true, false, true, true, false, false},
                    { false, false, true, false, false, false, true, false, false},
                    { false, false, false, true, false, true, false, false, false},
                    { false, false, false, false, true, false, false, false, false},
                    { false, true, true, true, false, true, true, true, false},
                    { false, false, false, false, false, false, false, false, false}
                }},
            { typeof(Bishop) , new bool[,]
                {
                    { false, false, false, false, false, false, false, false, false},
                    { false, false, false, false, true, true, false, false, false},
                    { false, false, false, true, true, true, true, false, false},
                    { false, false, true, true, true, false, true, false, false},
                    { false, false, false, true, false, true, true, false, false},
                    { false, false, false, false, true, true, true, false, false},
                    { false, false, false, true, true, true, false, false, false},
                    { false, false, true, true, true, true, true, false, false},
                    { false, false, false, false, false, false, false, false, false}
                }},
            { typeof(Queen) , new bool[,]
                {
                    { false, false, false, false, false, false, false, false, false},
                    { false, false, false, false, true, false, false, false, false},
                    { false, false, true, false, true, false, true, false, false},
                    { false, false, false, true, false, true, false, false, false},
                    { false, true, false, true, true, true, false, true, false},
                    { false, false, true, false, true, false, true, false, false},
                    { false, false, true, true, false, true, true, false, false},
                    { false, false, true, true, true, true, true, false, false},
                    { false, false, false, false, false, false, false, false, false}
                }},
            { typeof(King) , new bool[,]
                {
                    { false, false, false, false, false, false, false, false, false},
                    { false, false, false, false, true, false, false, false, false},
                    { false, false, false, true, true, true, false, false, false},
                    { false, true, true, false, true, false, true, true, false},
                    { false, true, true, true, true, true, true, true, false},
                    { false, true, true, true, true, true, true, true, false},
                    { false, false, true, true, true, true, true, false, false},
                    { false, false, true, true, true, true, true, false, false},
                    { false, false, false, false, false, false, false, false, false}
                }},

        };

        public static ConsoleColor ToConsoleColor(this ChessColor chessColor)
        {
            switch (chessColor)
            {
                case ChessColor.White: return ConsoleColor.Gray;
                case ChessColor.Black: return ConsoleColor.Black;
                case ChessColor.Brown: return ConsoleColor.DarkYellow;
                default: throw new InvalidOperationException("Cannot convert Chess Color!");
            }
        }

        public static void SetCursorAtCenter(int messageLength)
        {
            int centerRow = Console.WindowHeight / 2;
            int centerCol = Console.WindowWidth / 2 - messageLength / 2;
            try
            {
                Console.SetCursorPosition(centerCol, centerRow);
            }
            catch { }
        }

        public static void PrintFigure(IFigure figure, ConsoleColor backgroundColor, int top, int left)
        {
            if (figure == null)
            {
                PrintEmptySquire(backgroundColor, top, left);
            }
            else
            {
                if (!figuresPatterns.ContainsKey(figure.GetType()))
                {
                    return;
                }
                figure.Color.ToConsoleColor();
                var figurePattern = figuresPatterns[figure.GetType()];

                for (int row = 0; row < figurePattern.GetLength(0); row++)
                {
                    for (int col = 0; col < figurePattern.GetLength(1); col++)
                    {
                        Console.SetCursorPosition(left + col, top + row);
                        if (figurePattern[row, col])
                        {
                            Console.BackgroundColor = figure.Color.ToConsoleColor();
                        }
                        else
                        {
                            Console.BackgroundColor = backgroundColor;
                        }

                        Console.WriteLine(" ");
                    }
                }
            }
        }

        public static void PrintEmptySquire(ConsoleColor backgroundColor, int top, int left)
        {
            Console.BackgroundColor = backgroundColor;
            for (int i = 0; i < ConsoleConstants.CharactersPerRowPerBoardSquer; i++)
            {
                for (int j = 0; j < ConsoleConstants.CharactersPerColPerBoardSquer; j++)
                {
                    Console.SetCursorPosition(left + j, top + i);
                    Console.Write(" ");
                }
            }
        }

        public static Move CreateMoveFromCommand(string command)
        {
            var positionAsStringParts = command
                                       .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            ValidateMoveInputStringAsArray(positionAsStringParts);

            string fromAsString = positionAsStringParts[0];
            string toAsString = positionAsStringParts[1];

            //TODO: fix validation string aa-aa, a10-b10, spaces between simbols
            ValidatePositionInputString(fromAsString);
            ValidatePositionInputString(toAsString);

            Position fromPosition = new Position(fromAsString[1] - '0', (char)fromAsString[0]);
            Position toPosition = new Position(toAsString[1] - '0', (char)toAsString[0]);

            return new Move(fromPosition, toPosition);
        }

        public static void ValidateMoveInputStringAsArray(Array moveInputStringAsArray)
        {
            if (moveInputStringAsArray.Length != 2)
            {
                throw new InvalidOperationException("Invalid command! Please type your move in format 'a5-c6'!");
            }
        }

        public static void ValidatePositionInputString(string positionInputString)
        {
            if (positionInputString.Length > 2 ||
               positionInputString.Length < 2 ||
               !Char.IsLetter(positionInputString[0]) ||
               !Char.IsDigit(positionInputString[1]))
            {
                throw new ArgumentOutOfRangeException("Invalid command! Please type your move in format 'a5-c6'!");
            }
        }

        public static void ClearRow(int col)
        {
            Console.SetCursorPosition(col, ConsoleConstants.ConsoleRowForCommandsAndMessages);
            Console.Write(new string(' ', Console.WindowWidth));
        }
    }
}