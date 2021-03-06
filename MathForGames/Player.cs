using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;


namespace MathForGames
{
    class Player : Entity
    {
        private float _speed = 1;

        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        /// <param name="x">Position on the x axis</param>
        /// <param name="y">Position on the y axis</param>
        /// <param name="icon">The symbol that will appear when drawn</param>
        /// <param name="color">The color of the symbol that will appear when drawn</param>
        public Player(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {

        }

        /// <param name="x">Position on the x axis</param>
        /// <param name="y">Position on the y axis</param>
        /// <param name="rayColor">The color of the symbol that will appear when drawn to raylib</param>
        /// <param name="icon">The symbol that will appear when drawn</param>
        /// <param name="color">The color of the symbol that will appear when drawn to the console</param>
        public Player(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {

        }

        public override void Update(float deltaTime)
        {

            int xDirection = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_A)) +
                Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_D));

            int yDirection = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W)) +
                Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));

            Velocity = new Vector2(xDirection, yDirection);
            Velocity = Velocity.Normalized * Speed;

            base.Update(deltaTime);
        }


            //ConsoleKey keyPressed = Game.GetNextKey();

            //switch (keyPressed)
            //{
            //    case ConsoleKey.A:
            //        _velocity.X = -2;
            //        break;
            //    case ConsoleKey.D:
            //        _velocity.X = 2;
            //        break;
            //    case ConsoleKey.W:
            //        _velocity.Y = -2;
            //        break;
            //    case ConsoleKey.S:
            //        _velocity.Y = 2;
            //        break;
            //    default:
            //        _velocity.X = 0;
            //        _velocity.Y = 0;
            //        break;
            //}

    }
}
