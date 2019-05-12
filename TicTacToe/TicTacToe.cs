using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        // Variables
        static string curPlayer = "";
        static bool play = true;
        static bool Winner = false;
        static bool Draw = false;

        // The currentBoard
        static char[,] currentBoard =
        {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };

        public static void ResetBoard()
        {
            char[,] newBoard =
            {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };
            currentBoard = newBoard;
            Winner = false;
            Draw = false;
            curPlayer = "";
        }

        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", currentBoard[2, 0], currentBoard[2, 1], currentBoard[2, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", currentBoard[1, 0], currentBoard[1, 1], currentBoard[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", currentBoard[0, 0], currentBoard[0, 1], currentBoard[0, 2]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("");
        }

        public static void EnterXorO(char playerSign, int input)
        {
            int x = ((input - 1) / 3);
            int y = ((input - 1) % 3);

            if (currentBoard[x, y] != 'X' && currentBoard[x, y] != 'x' && currentBoard[x, y] != 'Y' && currentBoard[x, y] != 'y')
            {
                currentBoard[x, y] = playerSign;
                CheckWinner(playerSign);
                SetField();
            }
            else
            {
                Console.WriteLine("Player {0}, that option is already chosen, please make another selection.", playerSign);
                int selection = Convert.ToInt32(Console.ReadLine());
                EnterXorO(playerSign, selection);
            }
        }

        public static void CheckWinner(char playerSign)
        {
            if (((currentBoard[0, 0] == playerSign) && (currentBoard[0, 1] == playerSign) && (currentBoard[0, 2] == playerSign))
                        || ((currentBoard[1, 0] == playerSign) && (currentBoard[1, 1] == playerSign) && (currentBoard[1, 2] == playerSign))
                        || ((currentBoard[2, 0] == playerSign) && (currentBoard[2, 1] == playerSign) && (currentBoard[2, 2] == playerSign))
                        || ((currentBoard[0, 0] == playerSign) && (currentBoard[1, 0] == playerSign) && (currentBoard[2, 0] == playerSign))
                        || ((currentBoard[0, 1] == playerSign) && (currentBoard[1, 1] == playerSign) && (currentBoard[2, 1] == playerSign))
                        || ((currentBoard[0, 2] == playerSign) && (currentBoard[1, 2] == playerSign) && (currentBoard[2, 2] == playerSign))
                        || ((currentBoard[0, 0] == playerSign) && (currentBoard[1, 1] == playerSign) && (currentBoard[2, 2] == playerSign))
                        || ((currentBoard[0, 2] == playerSign) && (currentBoard[1, 1] == playerSign) && (currentBoard[2, 0] == playerSign)))
            {
                Winner = true;
            }
        }

        public static void GameTime()
        {
            string playAgain = " ";

            while (play == true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Would you like to play Tic Tac Toe? (type Y or N)");
                playAgain = Console.ReadLine().ToString().ToUpper();
                if (playAgain == "Y")
                {
                    ResetBoard();
                    PlayGame();
                }
                else if (playAgain == "N")
                {
                    play = false;
                }
            }
        }

        public static void PlayGame()
        {
            int p = 0;
            for (p = 0; p < 9; p++)
            {
                if (p >= 8) { Draw = true; }
                if (p % 2 == 0)
                { curPlayer = "X"; }
                else
                { curPlayer = "Y"; }
                SetField();
                bool selectionInt = false;
                while (selectionInt == false)
                {
                    Console.WriteLine("Player {0}, Make your selection on the board", curPlayer);
                    var selection = Console.ReadLine();
                    if (int.TryParse(selection, out int selectionInput))
                    {
                        if (selectionInput > 0 && selectionInput < 10)
                        {
                            selectionInt = true;
                            EnterXorO(Convert.ToChar(curPlayer), selectionInput);
                        }
                    }
                }

                if (Draw == true && Winner == false)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("DRAW!, hit enter to continue");
                    Console.ReadKey(true);
                }

                if (Winner == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Player {0} is the WINNER!, hit enter to continue", curPlayer);
                    Console.ReadKey(true);
                    p = 11;
                }
            }
        }

        static void Main(string[] args)
        {
            GameTime();
        }
    }
}
