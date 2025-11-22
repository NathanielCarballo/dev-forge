using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks.Sources;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            PlaySnakeGame();

            Console.WriteLine("\nPlay Again? (Y/N)");
            string userDecision = Console.ReadLine().ToUpper();
            playAgain = userDecision == "Y";
            Console.Clear(); //Clear the console for the next game or exit
        }
    }

    static void PlaySnakeGame()
    {
        int boardWidth = 40;
        int boardHeight = 20;
        int gameSpeed = 100; //Initial game speed in milliseconds
        bool gameEnd = false;
        int score = 0;
        List<(int, int)> snake = new List<(int, int)>() { (20, 10) };
        string direction = "UP";
        string nextDirection = "UP";
        Random random = new Random();
        (int, int) food = (random.Next(1, boardWidth - 2), random.Next(1, boardHeight - 2));

        Console.CursorVisible = false;
        DrawBorders(boardWidth, boardHeight);

        while (!gameEnd)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow when direction != "DOWN": nextDirection = "UP"; break;
                    case ConsoleKey.DownArrow when direction != "UP": nextDirection = "DOWN"; break;
                    case ConsoleKey.LeftArrow when direction != "RIGHT": nextDirection = "LEFT"; break;
                    case ConsoleKey.RightArrow when direction != "LEFT": nextDirection = "RIGHT"; break;
                }
            }

            direction = nextDirection;
            var newHead = CalculateNewHeadPosition(snake[0], direction, boardWidth, boardHeight);

            if (newHead.Item1 == 0 || newHead.Item1 == boardWidth - 1 || newHead.Item2 == 0 || newHead.Item2 == boardHeight - 1 || snake.Contains(newHead))
            {
                gameEnd = true;
                break;
            }

            //Draw food
            Console.SetCursorPosition(food.Item1, food.Item2);
            Console.Write("F");
            
            //Move snake
            snake.Insert(0, newHead);

            if (newHead == food)
            {
                score += 10;
                gameSpeed = Math.Max(30, gameSpeed - 2); //Increase speed, cap at 30ms
                snake.Insert(0, newHead); //Grow snake
                food = (random.Next(1, boardWidth - 2), random.Next(1, boardHeight - 2));
            }
            else
            {
                var tail = snake[^1];
                Console.SetCursorPosition(tail.Item1, tail.Item2);
                Console.Write(" ");
                snake.RemoveAt(snake.Count - 1); //Remove tail piece
            }

            

            foreach (var part in snake)
            {
                Console.SetCursorPosition(part.Item1, part.Item2);
                Console.Write("*");
            }

            Console.SetCursorPosition(0, boardHeight);
            Console.Write($"Score:  {score}  ");

            Thread.Sleep(gameSpeed);
        }
        Console.SetCursorPosition(0, boardHeight + 1);
        Console.WriteLine("Game Over! Final Score: " + score);
    }

    static void DrawBorders(int width, int height)
    {
        Console.Clear();

        for (int x = 0; x < width; x++)
        {
            Console.SetCursorPosition(x, 0);
            Console.Write("#");
            Console.SetCursorPosition(x, height - 1);
            Console.Write("#");
        }

        for (int y = 1; y < height; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write("#");
            Console.SetCursorPosition(width - 1, y);
            Console.Write("#");
        }
    }

    static (int, int) CalculateNewHeadPosition((int,int) head, string direction, int boardWidth, int boardHeight)
    {
        return direction switch
        {
            "UP" => (head.Item1, head.Item2 - 1),
            "DOWN" => (head.Item1, head.Item2 + 1),
            "LEFT" => (head.Item1 - 1, head.Item2),
            "RIGHT" => (head.Item1 + 1, head.Item2),
            _ => head
        };
    }
}