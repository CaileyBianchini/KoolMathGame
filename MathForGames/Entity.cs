using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
<<<<<<< Updated upstream
using Raylib_cs;
=======
>>>>>>> Stashed changes
namespace MathForGames
{
    class Entity
    {
<<<<<<< Updated upstream
        private char _icon = ' ';
        protected Vector2 _position;
        protected Vector2 _velocity;
        protected ConsoleColor _color;
        protected Color _rayColor;
        public bool Started { get; private set; }
=======
        protected char _icon = ' ';
        protected Vector2 _position;
        protected Vector2 _velocity;
        protected ConsoleColor _color;
>>>>>>> Stashed changes

        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public Vector2 Velocity
        {
            get
<<<<<<< Updated upstream
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }


        public Entity(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _rayColor = Color.WHITE;
=======
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }

        public Entity( float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
>>>>>>> Stashed changes
            _icon = icon;
            _position = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
<<<<<<< Updated upstream
=======
        }

        public void Start()
        {
            
        }

        public virtual void Update()
        {
            _position.X += _velocity.X;
            _position.Y += _velocity.Y;
            _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth-1);
            _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight-1);
            
>>>>>>> Stashed changes
        }

        public Entity(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : this(x, y, icon, color)
        {
<<<<<<< Updated upstream
            _rayColor = rayColor;
=======
            Console.ForegroundColor = _color;
            Console.SetCursorPosition((int)_position.X, (int)_position.Y);
            Console.Write(_icon);
            Console.ForegroundColor = Game.DefaultColor;
>>>>>>> Stashed changes
        }

        public virtual void Start()
        {
            Started = true;
        }


        public virtual void Update()
        {
            _position += _velocity;
            _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth - 1);
            _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight - 1);

        }

        public virtual void Draw()
        {
            Raylib.DrawText(_icon.ToString(), (int)(_position.X * 32), (int)(_position.Y * 32), 32, _rayColor);
            Console.ForegroundColor = _color;
            Console.SetCursorPosition((int)_position.X, (int)_position.Y);
            Console.Write(_icon);
            Console.ForegroundColor = Game.DefaultColor;
        }

        public virtual void End()
        {
            Started = false;
        }

    }
}
