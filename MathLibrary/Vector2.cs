﻿using System;

namespace MathLibrary
{
    public class Vector2
    {
        private float _x;
        private float _y;

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y);
            }
        }

        
        public Vector2()
        {
            _x = 0;
            _y = 0;
        }

        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public Vector2 Normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        public static Vector2 Normalize(Vector2 vector)
        {
            //if its zero then we need a new vector
            if (vector.Magnitude == 0)
                return new Vector2();
            //this will work as long as the number is more than zero
            return vector / vector.Magnitude;
        }

        public static float DotProduct(Vector2 lhs, Vector2 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y);
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        public static Vector2 operator *(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.X * scalar, lhs.Y * scalar);
        }

        public static Vector2 operator /(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.X / scalar, lhs.Y / scalar);
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public Vector2()
        {
            _x = 0;
            _y = 0;
        }

        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }

    }
}
