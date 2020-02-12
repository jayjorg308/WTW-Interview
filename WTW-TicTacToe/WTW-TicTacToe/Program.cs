using System;
using WTW_TicTacToe.Models;

namespace WTW_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt user to enter a single number that will represent the nxn tic tac toe board
            Console.WriteLine("Please enter a single number 'n' that will represent your nxn sized tic tac toe board: ");
            var boardSize = Convert.ToInt32(Console.ReadLine());

            // instantiate a new tic tac toe board using the user input
            var board = new TicTacToe(boardSize);

            // properties for keeping track of game
            var result = 0;
            var player1 = true;
            var totalMoves = 0;

            // do while loop that will run while result is 0 (meaning no winner)
            // AND while total moves is less than the board size
            do
            {
                // Get the current player
                var currentPlayer = player1 ? "Player 1" : "Player 2";

                // prompt current player to enter two numbers representing the row and column repsectively
                Console.WriteLine($"{currentPlayer}, please enter the zero-based row and column (separated by a space) you would like to play: ");
                var response = Console.ReadLine().Split(' ');

                // call the TicTacToe PlacePiece method
                // this will return the result of the piece being placed
                result = board.PlacePiece(Convert.ToInt32(response[0]), Convert.ToInt32(response[1]), player1 ? 1 : 2);

                // if result is greater than 0, then we have a winner
                if (result > 0)
                    Console.WriteLine($"Player {result} wins!");

                // increment the total number of moves
                totalMoves++;

                // check to see if the board is full
                if (result == 0 && totalMoves == (boardSize * boardSize))
                    Console.WriteLine("The game is a tie!");

                // switch players
                player1 = !player1;
            }
            while (result == 0 && totalMoves < boardSize * boardSize);
        }
    }
}
