using System;

#pragma warning disable CS1718
namespace ElusGoodies.Vectors
{
    public class Vector2 : IEquatable<Vector2>
    {
        public float x, y;

        public Vector2(float _x, float _y) { x = _x; y = _y; }
        public static Vector2 zero => new Vector2(0, 0);
        public static Vector2 up => new Vector2(0, 1);
        public static Vector2 down => new Vector2(0, -1);
        public static Vector2 right => new Vector2(1, 0);
        public static Vector2 left => new Vector2(-1, 0);
        public static float Distance(Vector2 one, Vector2 two)
        {
            float x = (two.x - one.x);
            float y = (two.y - one.y);
            return (float)Math.Sqrt((x * x) + (y * y));
        }

        public bool Equals(Vector2 other)
        {
            float thisX = x * 100, thisY = y * 100, otherX = other.x * 100, otherY = other.y * 100;
            thisX = (float)Math.Round(thisX) / 100f;
            thisY = (float)Math.Round(thisY) / 100f;
            otherX = (float)Math.Round(otherX) / 100f;
            otherY = (float)Math.Round(otherY) / 100f;

            return otherX == thisX && otherY == thisY;
        }

        public void Invert() { float t = x; x = y; y = t; }
        public static Vector2 operator +(Vector2 one, Vector2 two) => new Vector2(one.x + two.x, one.y + two.y);
        public static Vector2 operator +(Vector2 one, Vector3 two) => new Vector2(one.x + two.x, one.y + two.y);
        public static Vector2 operator -(Vector2 one, Vector2 two) => new Vector2(one.x - two.x, one.y - two.y);
        public static Vector2 operator -(Vector2 one, Vector3 two) => new Vector2(one.x - two.x, one.y - two.y);
        public static Vector2 operator *(Vector2 one, Vector2 two) => new Vector2(one.x * two.x, one.y * two.y);
        public static Vector2 operator *(Vector2 one, float two) => new Vector2(one.x * two, one.y * two);
        public static Vector2 operator *(Vector2 two, Vector3 one) => new Vector2(one.x * two.x, one.y * two.y);
        public static Vector2 operator /(Vector2 one, Vector2 two)
        {
            float x = one.x / two.x,
            y = one.y / two.y;

            x = x == float.PositiveInfinity || x == float.NegativeInfinity || x != x ? 0 : x;
            y = y == float.PositiveInfinity || y == float.NegativeInfinity || y != y ? 0 : y;

            return new Vector2(x, y);
        }
        public static Vector2 operator /(Vector2 two, Vector3 one)
        {

            float x = one.x / two.x,
            y = one.y / two.y;

            x = x == float.PositiveInfinity || x == float.NegativeInfinity || x != x ? 0 : x;
            y = y == float.PositiveInfinity || y == float.NegativeInfinity || y != y ? 0 : y;
            return new Vector2(x, y);
        }
        public static Vector2 operator /(Vector2 one, float two)
        {
            if (two == 0) return Vector2.zero;

            float x = one.x / two,
            y = one.y / two;

            x = x == float.PositiveInfinity || x == float.NegativeInfinity || x != x ? 0 : x;
            y = y == float.PositiveInfinity || y == float.NegativeInfinity || y != y ? 0 : y;

            return new Vector2(x, y);
        }
        public static Vector2 Vector3ToVector2(Vector3 temp) => new Vector2(temp.x, temp.y);
        public static bool operator ==(Vector2 one, Vector2 two) => one.Equals(two);
        public static bool operator ==(Vector2 one, Vector3 two) => one.Equals(Vector2.Vector3ToVector2(two));
        public static bool operator !=(Vector2 one, Vector2 two) => !one.Equals(two);
        public static bool operator !=(Vector2 one, Vector3 two) => !one.Equals(Vector2.Vector3ToVector2(two));
        public override string ToString() => "X: " + x + ", Y: " + y;

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode() { return base.GetHashCode(); }
    }
}
