public class Game
{
    static void Main(string[] args)
    {
        Console.Title = "Pong in C#";

        Game game = new();
        game.RunGame();
    }

    public void RunGame()
    {
        //Ball Data
        int horizontalMovementBall = Console.WindowWidth / 2;
        int verticalMovementBall = Console.WindowHeight / 2;
        bool moveBallRight = true;
        int moveBallUpp = 2; //1 Move Up, 0 Move Down, 2 Move right or left
        string Ball = "o";

        //Player Data
        int horizontalPositionPlayer1 = 2;
        int verticalMovementPlayer1 = Console.WindowHeight / 2;
        string player1 = "|";
        int horizontalPositionPlayer2 = Console.WindowWidth - 2;
        int verticalMovementPlayer2 = Console.WindowHeight / 2;
        string player2 = "|";

        int player1Score = 0;
        int player2Score = 0;

        Random randomNumber = new();

        try
        {
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;

                if (moveBallRight)
                {
                    horizontalMovementBall++;

                    if (horizontalMovementBall == Console.WindowWidth - 1)
                    {
                        player1Score++;
                        horizontalMovementBall = Console.WindowWidth / 2;
                        verticalMovementBall = Console.WindowHeight / 2;
                        moveBallUpp = 2;
                    }
                    else if (horizontalMovementBall == horizontalPositionPlayer2 && verticalMovementBall == verticalMovementPlayer2)
                    {
                        moveBallRight = false;
                        moveBallUpp = randomNumber.Next(0, 2);
                    }
                }
                else
                {
                    horizontalMovementBall--;

                    if (horizontalMovementBall == 2 && verticalMovementBall == verticalMovementPlayer1)
                    {
                        moveBallRight = true;
                        moveBallUpp = randomNumber.Next(0, 2);
                    }
                    else if (horizontalMovementBall == 0)
                    {
                        player2Score++;
                        horizontalMovementBall = Console.WindowWidth / 2;
                        verticalMovementBall = Console.WindowHeight / 2;
                        moveBallUpp = 2;
                    }
                }
                if (moveBallUpp == 1)
                {
                    verticalMovementBall--;

                    if (verticalMovementBall == 0)
                    {
                        moveBallUpp = 0;
                    }
                }
                else if (moveBallUpp == 0)
                {
                    verticalMovementBall++;

                    if (verticalMovementBall == Console.WindowHeight - 1)
                    {
                        moveBallUpp = 1;
                    }
                }

                while (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            verticalMovementPlayer2--;
                            break;
                        case ConsoleKey.DownArrow:
                            verticalMovementPlayer2++;
                            break;
                        case ConsoleKey.W:
                            verticalMovementPlayer1--;
                            break;
                        case ConsoleKey.S:
                            verticalMovementPlayer1++;
                            break;
                    }
                }

                Console.SetCursorPosition(horizontalMovementBall, verticalMovementBall);
                Console.Write(Ball);

                if (verticalMovementPlayer1 <= 0)
                {
                    verticalMovementPlayer1 = 0;
                }
                if (verticalMovementPlayer2 <= 0)
                {
                    verticalMovementPlayer2 = 0;
                }
                else if (verticalMovementPlayer1 >= Console.WindowHeight)
                {
                    verticalMovementPlayer1 = Console.WindowHeight - 1;
                }
                else if (verticalMovementPlayer2 >= Console.WindowHeight)
                {
                    verticalMovementPlayer2 = Console.WindowHeight - 1;
                }

                Console.SetCursorPosition(10, 1);
                Console.Write($"Points: {player1Score}");
                Console.SetCursorPosition(Console.WindowWidth - 20, 1);
                Console.Write($"Points: {player2Score}");

                Console.SetCursorPosition(horizontalPositionPlayer1, verticalMovementPlayer1);
                Console.Write(player1);
                Console.SetCursorPosition(horizontalPositionPlayer2, verticalMovementPlayer2);
                Console.Write(player2);

                Thread.Sleep(100);
            }
        }
        catch (System.ArgumentOutOfRangeException)
        {
            for (int i = 10; i > -1; i--)
            {
                Console.Clear();

                Console.SetCursorPosition(Console.WindowWidth / 2 - 27, Console.WindowHeight / 2);
                Console.WriteLine("End of Game (The ball or the player went off the map)");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 13, Console.WindowHeight / 2 + 1);
                Console.WriteLine($"The game will restart in {i}");
                Thread.Sleep(1000);
            }
            RunGame();
        }
    }
}