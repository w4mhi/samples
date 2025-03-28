namespace Minitechnicus.Edu
{
    using System;

    /// <summary>
    /// This code is written for demo purposes.
    /// </summary>
    internal class Program
    {
        private static char[,] board;
        private static int rows, cols, boardDimension;
        private static char boardToken = '-';
        private static char xToken = 'X';
        private static char oToken = '0';

        static void Main(string[] args)
        {
            // for refactoring the following can be used
            // int rows = board.GetLength(0);
            // int cols = board.GetLength(1);

            rows = cols = boardDimension = 3;
            board = new char[rows, cols];

            bool isManualInput = false;
            char currentPlayer = xToken;
            bool winner = false;

            // user input
            int row, col;
            InitializeBoard();

            while (!winner)
            {
                PrintBoard();

                // # available moves
                IEnumerable<(int, int)> availableMoves = GetAvailableMoves();

                if (availableMoves.Any())
                {
                    Console.WriteLine($"Player {currentPlayer}, it's your turn. You have {availableMoves.Count()} spots available.");

                    // manual
                    if (isManualInput)
                    {
                        GetPlayerMove(out row, out col);
                    }
                    else
                    {
                        // automated
                        (row, col) = GetRandomPosition(availableMoves);
                    }

                    Console.WriteLine($"Player {currentPlayer} moves to ({row},{col}).");
                    winner = PlayMove(currentPlayer, row, col);

                    if (winner)
                    {
                        PrintBoard();
                        Console.WriteLine($"Player {currentPlayer} wins!");
                    }
                    else
                    {
                        currentPlayer = (currentPlayer == xToken) ? oToken : xToken;
                    }
                }
                else
                {
                    Console.WriteLine("No more open spots!");
                    break;
                }
            }

            if (!winner)
            {
                Console.WriteLine("It's a draw!");
            }

            Console.WriteLine();
        }

        private static void InitializeBoard()
        {
            char[,] array = Enumerable.Range(0, board.GetLength(1))
                            .SelectMany(rows => Enumerable.Range(0, board.GetLength(0))
                                .Select(cols => new { rows, cols }))
                                    .Aggregate(board, (array, rc) =>
                                    {
                                        array[rc.rows, rc.cols] = boardToken;
                                        return array;
                                    });
        }

        private static void PrintBoard()
        {
            IEnumerable<char> values = GetboardValues();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static IEnumerable<char> GetboardValues()
        {
            return Enumerable.Range(0, rows)
                    .SelectMany(row => Enumerable.Range(0, cols)
                        .Select(col => board[row, col]));
        }

        private static void GetPlayerMove(out int row, out int col)
        {
            while (true)
            {
                Console.Write("Enter row (0 to {0}): ", rows - 1);
                row = int.Parse(Console.ReadLine());

                Console.Write("Enter column (0 to {0}): ", cols - 1);
                col = int.Parse(Console.ReadLine());

                if (row >= 0 && row < rows && col >= 0 && col < cols && board[row, col] == boardToken)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
            }
        }

        private static IEnumerable<(int, int)> GetAvailableMoves()
        {
            return Enumerable.Range(0, rows)
                    .SelectMany(row => Enumerable.Range(0, cols)
                        .Where(col => board[row, col] == boardToken)
                            .Select(col => (row, col)));
        }


        private static (int, int) GetRandomPosition(IEnumerable<(int, int)> positions)
        {
            Random random = new Random();
            List<(int, int)> positionList = positions.ToList();
            return positionList[random.Next(positionList.Count)];
        }

        private static bool PlayMove(char currentPlayer, int rowIndex, int colIndex)
        {
            // update the board
            board[rowIndex, colIndex] = currentPlayer;
            return CheckWinner(currentPlayer, rowIndex, colIndex);
        }

        private static bool CheckWinner(char currentPlayer, int rowIndex, int colIndex)
        {
            // check possibilities and return quick if win
            char[] row = GetRow(rowIndex);
            if (row.Count(c => c == currentPlayer) == boardDimension)
            {
                return true;
            }

            char[] col = GetColumn(colIndex);
            if (col.Count(c => c == currentPlayer) == boardDimension)
            {
                return true;
            }

            if (rowIndex == colIndex)
            {
                char[] diagLR = GetDiagLR();
                if (diagLR.Count(c => c == currentPlayer) == boardDimension)
                {
                    return true;
                }
            }

            if (rowIndex + colIndex == boardDimension - 1)
            {
                char[] diagRL = GetDiagRL();
                if (diagRL.Count(c => c == currentPlayer) == boardDimension)
                {
                    return true;
                }
            }

            return false;
        }

        private static char[] GetColumn(int colIndex)
        {
            return Enumerable.Range(0, board.GetLength(0))
                    .Select(row => board[row, colIndex])
                        .ToArray();
        }

        private static char[] GetRow(int rowIndex)
        {
            return Enumerable.Range(0, board.GetLength(1))
                    .Select(col => board[rowIndex, col])
                        .ToArray();
        }

        private static char[] GetDiagLR()
        {
            return Enumerable.Range(0, boardDimension)
                    .Select(i => board[i, i])
                        .ToArray();
        }

        private static char[] GetDiagRL()
        {
            return Enumerable.Range(0, cols)
                    .Select(i => board[i, boardDimension - 1 - i])
                        .ToArray();
        }
    }
}
