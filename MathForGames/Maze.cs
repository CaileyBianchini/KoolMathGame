using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Maze : Entity
    {
        private Entity _target;
        private Color _alertColor;

        public Entity Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public Maze(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {

        }

        public Maze(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {
            _alertColor = Color.RED;
        }

        public bool CheckTargetInSight()
        {
            if (Target == null)
                return false;

            Vector2 direction = Position - Target.Position;

            if (Vector2.DotProduct(Forward, direction) < 0)
                return true;
            else if (Vector2.DotProduct(Forward, direction) > 0.1)
                return false;

            return false;
        }

        public override void Update(float deltaTime)
        {
            if (CheckTargetInSight() == true)
            {
                _rayColor = Color.RED;
            }
            else if (CheckTargetInSight() == false)
            {
                _rayColor = Color.BLUE;
            }
            base.Update(deltaTime);
        }
    }
}
