using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Enemy : Entity
    {
        private Entity _target;

        public Entity Target
        {
            get{ return _target; }
            set{ _target = value; }
        }

        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {

        }

        public Enemy(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {

        }

        public bool GetTargetInSight( Entity entity)
        {
            if (Target == null)
                return false;

            return false;
        }
    }
}
