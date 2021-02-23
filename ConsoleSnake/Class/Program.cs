using ConsoleSnake.Class;
using System;

namespace ConsoleSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 50;
            Console.CursorVisible = false;
            bool exitGame = false;

            double fps = 1000 / 5.0; //Fraps per second
            DateTime lastDate = DateTime.Now;
            Food food = new Food();
            Snake snake = new Snake();

            //gameloop

            while(!exitGame)
            {
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey();

                    switch(input.Key)
                    {
                        case ConsoleKey.Escape:
                            exitGame = true;
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.Direction = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = Direction.Right;
                            break;
                        case ConsoleKey.UpArrow:
                            snake.Direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = Direction.Down;
                            break;
                    }
                }

                if((DateTime.Now - lastDate).TotalMilliseconds>=fps)
                {
                    snake.Move();

                    if(food.FoodPlacement.X == snake.SnakeHead.X 
                        && food.FoodPlacement.Y == snake.SnakeHead.Y)
                    {
                        snake.Eat();
                        food = new Food();
                        fps /= 1.1;
                    }

                    if(snake.GameOver)
                    {
                        Console.Clear();
                        Console.WriteLine($"GAME OVER!!! Your score:{snake.Lenght}");
                        exitGame = true;
                        Console.ReadLine();
                    }
                    lastDate = DateTime.Now;
                }
            }
        }
    }
}
