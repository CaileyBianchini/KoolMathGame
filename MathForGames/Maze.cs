using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Maze : Entity
    {
        public Maze(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {

        }


        public override void Update()
        {
            _position += _velocity * 0;
            _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth - 1);
            _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight - 1);

        }
    }
}
