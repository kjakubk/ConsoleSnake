using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleSnake.Class
{
    class Snake : ISnake
    {

        public int Lenght { get; set; } = 1; //start lenght
        public Direction Direction { get; set; } = Direction.Right;
        public Coordinates SnakeHead { get; set; } = new Coordinates();

        List<Coordinates> Tail { get; set; } = new List<Coordinates>();
        private bool outOfRange = false;

        public bool GameOver
        {
            get
            {
                return (Tail.Where(k => k.X == SnakeHead.X
                        && k.Y == SnakeHead.Y).ToList().Count > 1);
            }
        }
        public void Move()
        {
            switch(Direction)
            {
                case Direction.Left:
                    SnakeHead.X--;
                    break;
                case Direction.Right:
                    SnakeHead.X++;
                    break;
                case Direction.Up:
                    SnakeHead.Y--;
                    break;
                case Direction.Down:
                    SnakeHead.Y++;
                    break;
            }
            try
            {
                Console.SetCursorPosition(SnakeHead.X, SnakeHead.Y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("@");

                Tail.Add(new Coordinates(SnakeHead.X, SnakeHead.Y));
                if(Tail.Count > this.Lenght)
                {
                    var endOfTail = Tail.First();
                    Console.SetCursorPosition(endOfTail.X, endOfTail.Y);
                    Console.Write(" ");
                    Tail.Remove(endOfTail);
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                outOfRange = true;
            }
        }
        public void Eat()
        {
            Lenght++;
        }
    }

    public enum Direction { Left,Right,Up,Down}
   
}
