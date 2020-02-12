using System;

namespace WTW_TicTacToe.Models
{
    public class TicTacToe
    {
        // Private variables for use in TicTacToe class
        private char[,] _board;
        private int _boardSize;

        /// <summary>
        /// Created a Tic Tac Tow game board
        /// </summary>
        /// <param name="n">nxn dimension for the game board</param>
        public TicTacToe(int n)
        {
            // initialize our nxn board
            _board = new char[n, n];

            // set our boardSize variable for use in checking for winner
            _boardSize = n;
        }

        /// <summary>
        /// Place a piece on the game board
        /// </summary>
        /// <param name="row">row to place a piece</param>
        /// <param name="col">column to place a piece</param>
        /// <param name="player">the player (1 or 2) the piece is for</param>
        /// <returns>0 = no winner, 1 = player 1 won, 2 = player 2 won</returns>
        public int PlacePiece(int row, int col, int player)
        {
            // storing the current player's character and setting the square with the character
            var character = player == 1 ? 'X' : 'O';
            _board[row, col] = character;

            // calling private method to display tic tac toe board in console
            DisplayBoard();

            // calling private "CheckForWinner" method to see if the game is over
            // if CheckForWinner returns true, our method returns the winning player's number
            // else, returns 0 and the game keeps going
            return CheckForWinner(character) ? player : 0;
        }

        #region Private Methods
        // private method that will check all of the private methods below for a winner.
        // if any of the methods return true, we will return true
        // if not, we will return false, and the game will continue
        private bool CheckForWinner(char character)
        {
            if (HorizontalWinner(character))
                return true;
            else if (VerticalWinner(character))
                return true;
            else if (DiagonalWinner(character))
                return true;
            else
                return false;
        }

        // private method for checking for a diagonal winner
        private bool DiagonalWinner(char character)
        {
            // check first diagonal
            for (int x = 0; x < _boardSize; x++)
            {
                if (_board[x, x] != character)
                    break;

                if (x == (_boardSize - 1))
                    return true;
            }

            // check second diagonal
            for (int row = 0, col = _boardSize - 1; row < _boardSize; row++, col--)
            {
                if (_board[row, col] != character)
                    break;

                if (row == (_boardSize - 1))
                    return true;
            }

            return false;
        }

        // private method for checking vertical columns for a winner
        private bool VerticalWinner(char character)
        {
            for (int col = 0; col < _boardSize; col++)
            {
                var colSum = 0;
                for (int row = 0; row < _boardSize; row++)
                {
                    if (_board[row, col] == character)
                        colSum++;
                    else
                        break;
                }
                if (colSum == _boardSize)
                    return true;
            }

            return false;
        }

        // private method for checking horizontal rows for a winner
        private bool HorizontalWinner(char character)
        {
            for (int row = 0; row < _boardSize; row++)
            {
                var rowSum = 0;
                for (int col = 0; col < _boardSize; col++)
                {
                    if (_board[row, col] == character)
                        rowSum++;
                    else
                        break;
                }
                if (rowSum == _boardSize)
                    return true;
            }

            return false;
        }

        // private method for creating a console representation of our tic tac toe board
        private void DisplayBoard()
        {
            Console.WriteLine();
            for (int row = 0; row < _boardSize; row++)
            {
                Console.Write("| ");
                for (int col = 0; col < _boardSize; col++)
                {
                    Console.Write(_board[row, col]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}