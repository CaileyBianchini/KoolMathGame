using System;
using System.Collections.Generic;
using System.Text;
<<<<<<< Updated upstream
using Raylib_cs;
using MathLibrary;
=======
>>>>>>> Stashed changes

namespace MathForGames
{
    class Player : Entity
    {
        public Player(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {
<<<<<<< Updated upstream
            
        }

        public Player(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : this(x, y, icon, color)
        {
            _rayColor = rayColor;
=======

>>>>>>> Stashed changes
        }

        public override void Update()
        {
<<<<<<< Updated upstream
            int xVelocity = -Convert.ToInt32(Game.GetKeyDown((int)(KeyboardKey.KEY_A))
                + Convert.ToInt32(Game.GetKeyDown((int)(KeyboardKey.KEY_D));

            int yVelocity = -Convert.ToInt32(Game.GetKeyDown((int)(KeyboardKey.KEY_W))
                + Convert.ToInt32(Game.GetKeyDown((int)(KeyboardKey.KEY_S));

            Velocity = new Vector2(xVelocity, yVelocity);
            Velocity.X /= Velocity.GetMagnitude();
            Velocity.Y /= Velocity.GetMagnitude();

            //ConsoleKey keyPressed = Game.GetNextKey();

            //switch (keyPressed)
            //{
            //    case ConsoleKey.A:
            //        _velocity.X = -1;
            //        break;
            //    case ConsoleKey.D:
            //        _velocity.X = 1;
            //        break;
            //    case ConsoleKey.W:
            //        _velocity.Y = -1;
            //        break;
            //    case ConsoleKey.S:
            //        _velocity.Y = 1;
            //        break;
            //    default:
            //        _velocity.X = 0;
            //        _velocity.Y = 0;
            //        break;
            //}
            base.Update();
        }

=======
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
>>>>>>> Stashed changes
    }
}
