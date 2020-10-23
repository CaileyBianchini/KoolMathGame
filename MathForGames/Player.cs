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

        public Player(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {

            
        }

        public Player(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : this(x, y, icon, color)
        {
            _rayColor = rayColor;

        }

        public override void Update(float deltaTime)
        {

            int xVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_A)) +
                Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_D));

            int xVelocity = -Convert.ToInt32(Game.GetKeyDown((int)(KeyboardKey.KEY_A))
                + Convert.ToInt32(Game.GetKeyDown((int)(KeyboardKey.KEY_D));


            int yVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W)) +
                Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));

            Velocity = new Vector2(xVelocity, yVelocity);
            Velocity = Velocity.Normalized * Speed;

            base.Update(deltaTime);
        }


            ConsoleKey keyPressed = Game.GetNextKey();

            switch (keyPressed)
            {
                case ConsoleKey.A:
                    _velocity.X = -2;
                    break;
                case ConsoleKey.D:
                    _velocity.X = 2;
                    break;
                case ConsoleKey.W:
                    _velocity.Y = -2;
                    break;
                case ConsoleKey.S:
                    _velocity.Y = 2;
                    break;
                default:
                    _velocity.X = 0;
                    _velocity.Y = 0;
                    break;
            }
            base.Update();
        }

    }
}
