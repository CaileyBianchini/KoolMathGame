using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Entity
    {
        private char _icon = ' ';
        private int _x = 0;
        private int _y = 0;

        public void Start()
        {
            
        }

        public void Update()
        {
            if(Game.CheckKey(ConsoleKey.D))
            {
                _x++;
            }
            if (Game.CheckKey(ConsoleKey.S))
            {
                _y++;
            }
            if (Game.CheckKey(ConsoleKey.A))
            {
                _x--;
            }
            if (Game.CheckKey(ConsoleKey.W))
            {
                _y--;
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(_icon);
        }

        public void End()
        {

        }
    }
}
