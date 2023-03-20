using System.Text;

namespace nQueen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = SolveNQueens(4);
            Console.WriteLine($"Ans Count:{result.Count}");
            Console.ReadLine();
        }

        public static IList<IList<string>> SolveNQueens(int n)
        {

            List<IList<string>> result = new List<IList<string>>();
            int[][] board = new int[n][];
            for (int i = 0; i < n; i++)
            {
                board[i] = new int[n];
            }

            RecursionQueens(0, board, result);
            return result;
        }

        // board.Length = 4, n = 0
        // 1, 3, 0, 2
        // 2, 0, 3, 1

        private static void RecursionQueens(int row, int[][] board, List<IList<string>> result)
        {
            // Complete
            if (row == board.Length)
            {
                // Save Ans
                result.Add(PrintBoard(board));
                return;
            }
            else
            {
                for (int col = 0; col < board[0].Length; col++)
                {
                    if (IsValid(row, col, board, board[0].Length))
                    {
                        board[row][col] = 1;
                        RecursionQueens(row + 1, board, result);
                        // forward
                        board[row][col] = 0;
                    }
                }
            }
        }


        private static bool IsValid(int row, int col, int[][] board, int n)
        {
            // 剪枝
            for (int i = 0; i < row; i++)
            {
                if (board[i][col] == 1)
                {
                    return false;
                }
            }

            // 45 度
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i][j] == 1)
                {
                    return false;
                }
            }

            // 135 度
            for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
            {
                if (board[i][j] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        private static List<string> PrintBoard(int[][] grid)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < grid.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 0)
                        sb.Append('.');
                    else
                        sb.Append('Q');
                }
                result.Add(sb.ToString());
            }

            return result;
        }
    }
}