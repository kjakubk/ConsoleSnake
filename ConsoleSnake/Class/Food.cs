using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake.Class
{
    public class Food
    {
        public Food()
        {
            Random randomFood = new Random();
            var x = randomFood.Next(1, 20);
            var y = randomFood.Next(1, 20);

            FoodPlacement = new Coordinates(x, y);
            Draw();
        }

        public Coordinates FoodPlacement { get; set; }

        void Draw()
        {
            Console.SetCursorPosition(FoodPlacement.X, FoodPlacement.Y);//Random food placement
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("#");
        }
    }
}
