// File: GameLogic.cs
namespace O_Neillo_Game
{
    public class GameLogic
    {
        private int[,] board;
        private int currentPlayer;

        public GameLogic()
        {
            // Initialize starting positions on the game board
            board = new int[8, 8];
            board[3, 3] = 2;
            board[4, 4] = 2;
            board[3, 4] = 1;
            board[4, 3] = 1;

            currentPlayer = 1;
        }
        public int[,] Board => board;

        public int CurrentPlayer => currentPlayer;

        public bool IsValidMove(int row, int col)
        {
            if (board[row, col] != 0)
            {
                return false;
            }

            for (int rowIncrement = -1; rowIncrement <= 1; rowIncrement++)
            {
                for (int colIncrement = -1; colIncrement <= 1; colIncrement++)
                {
                    if (rowIncrement == 0 && colIncrement == 0)
                        continue;

                    if (CanFlipInDirection(row, col, rowIncrement, colIncrement))
                    {
                        int newRow = row + rowIncrement;
                        int newCol = col + colIncrement;

                        if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8 && board[newRow, newCol] != currentPlayer)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public void MakeMove(int row, int col)
        {
            if (IsValidMove(row, col))
            {
                board[row, col] = currentPlayer;
                FlipOpponentPieces(row, col);

                currentPlayer = (currentPlayer == 1) ? 2 : 1;
            }
        }

        public bool HasValidMoves()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col] == 0 && IsValidMove(row, col))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsGameOver()
        {
            // Check if there are valid moves left for the current player
            if (!HasValidMoves())
                return true;

            // Check if the board is completely filled
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col] == 0)
                        return false; // There is an empty cell, the game is not over
                }
            }

            return true; // The board is completely filled, the game is over
        }

        public int GetWinner()
        {
            int player1TokenCount = CountTokens(1);
            int player2TokenCount = CountTokens(2);

            if (player1TokenCount > player2TokenCount)
                return 1;
            else if (player2TokenCount > player1TokenCount)
                return 2;
            else
                return 0; // It's a draw
        }

        private bool CanFlipInDirection(int startRow, int startCol, int rowIncrement, int colIncrement)
        {
            int currentPlayer = board[startRow, startCol];
            int opponentPlayer = (currentPlayer == 1) ? 2 : 1;

            int row = startRow + rowIncrement;
            int col = startCol + colIncrement;

            while (row >= 0 && row < 8 && col >= 0 && col < 8)
            {
                if (board[row, col] == opponentPlayer)
                {
                    while (row >= 0 && row < 8 && col >= 0 && col < 8)
                    {
                        if (board[row, col] == currentPlayer)
                        {
                            return true;
                        }
                        else if (board[row, col] == 0)
                        {
                            break;
                        }

                        row += rowIncrement;
                        col += colIncrement;
                    }
                }
                else if (board[row, col] == currentPlayer)
                {
                    break;
                }

                row += rowIncrement;
                col += colIncrement;
            }

            return false;
        }

        public void FlipOpponentPieces(int row, int col)
        {
            FlipInDirection(row, col, 0, 1);
            FlipInDirection(row, col, 1, 0);
            FlipInDirection(row, col, 1, 1);
            FlipInDirection(row, col, 1, -1);
            FlipInDirection(row, col, 0, -1);
            FlipInDirection(row, col, -1, 0);
            FlipInDirection(row, col, -1, -1);
            FlipInDirection(row, col, -1, 1);
        }

        private void FlipInDirection(int startRow, int startCol, int rowIncrement, int colIncrement)
        {
            int currentPlayer = board[startRow, startCol];
            int opponentPlayer = (currentPlayer == 1) ? 2 : 1;

            int row = startRow + rowIncrement;
            int col = startCol + colIncrement;

            bool validMove = false;

            while (row >= 0 && row < 8 && col >= 0 && col < 8)
            {
                if (board[row, col] == opponentPlayer)
                {
                    row += rowIncrement;
                    col += colIncrement;
                }
                else if (board[row, col] == currentPlayer)
                {
                    validMove = true;
                    break;
                }
                else if (board[row, col] == 0)
                {
                    break;
                }
                else
                {
                    // If none of the conditions are met, break the loop to prevent an infinite loop
                    break;
                }
            }

            if (validMove)
            {
                row = startRow + rowIncrement;
                col = startCol + colIncrement;

                while (row >= 0 && row < 8 && col >= 0 && col < 8 && board[row, col] == opponentPlayer)
                {
                    board[row, col] = currentPlayer;
                    row += rowIncrement;
                    col += colIncrement;
                }
            }
        }


        public int CountTokens(int player)
        {
            int count = 0;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col] == player)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}