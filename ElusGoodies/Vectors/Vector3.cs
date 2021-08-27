using System;

#pragma warning disable CS1718
namespace ElusGoodies.Vectors
{
    public class Vector3 : IEquatable<Vector3>
    {
        public float x, y, z;
        public Vector3(float _x, float _y, float _z) { x = _x; y = _y; z = _z; }
        public static Vector3 zero => new Vector3(0, 0, 0);
        public static Vector3 up => new Vector3(0, 1, 0);
        public static Vector3 down => new Vector3(0, -1, 0);
        public static Vector3 right => new Vector3(1, 0, 0);
        public static Vector3 left => new Vector3(-1, 0, 0);
        public static float Distance(Vector3 one, Vector3 two)
        {
            float x = (two.x - one.x);
            float y = (two.y - one.y);
            float z = (two.z - one.z);
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        public bool Equals(Vector3 other)
        {
            float thisX = x * 100, thisY = y * 100, thisZ = z * 100,
            otherX = other.x * 100, otherY = other.y * 100, otherZ = other.z * 100;

            thisX = (float)Math.Round(thisX) / 100f;
            thisY = (float)Math.Round(thisY) / 100f;
            thisZ = (float)Math.Round(thisZ) / 100f;

            otherX = (float)Math.Round(otherX) / 100f;
            otherY = (float)Math.Round(otherY) / 100f;
            otherZ = (float)Math.Round(otherZ) / 100f;

            return otherX == thisX && otherY == thisY && otherZ == thisZ;
        }

        public void Invert() { float t = z; z = x; x = t; }
        public static Vector3 operator +(Vector3 one, Vector3 two) => new Vector3(one.x + two.x, one.y + two.y, one.z + two.z);
        public static Vector3 operator +(Vector3 one, Vector2 two) => new Vector3(one.x + two.x, one.y + two.y, one.z);
        public static Vector3 operator -(Vector3 one, Vector3 two) => new Vector3(one.x - two.x, one.y - two.y, one.z - two.z);
        public static Vector3 operator -(Vector3 one, Vector2 two) => new Vector3(one.x - two.x, one.y - two.y, one.z);
        public static Vector3 operator *(Vector3 one, Vector3 two) => new Vector3(one.x * two.x, one.y * two.y, one.z * two.z);
        public static Vector3 operator *(Vector3 one, Vector2 two) => new Vector3(one.x * two.x, one.y * two.y, one.z);
        public static Vector3 operator *(Vector3 one, float two) => new Vector3(one.x * two, one.y * two, one.z * two);
        public static Vector3 operator /(Vector3 one, Vector3 two)
        {

            float x = one.x / two.x,
            y = one.y / two.y,
            z = one.z / two.z;

            x = x == float.PositiveInfinity || x == float.NegativeInfinity || x != x ? 0 : x;
            y = y == float.PositiveInfinity || y == float.NegativeInfinity || y != y ? 0 : y;
            z = z == float.PositiveInfinity || z == float.NegativeInfinity || z != z ? 0 : z;
            return new Vector3(x, y, z);
        }
        public static Vector3 operator /(Vector3 one, Vector2 two)
        {

            float x = one.x / two.x,
            y = one.y / two.y,
            z = one.z;

            x = x == float.PositiveInfinity || x == float.NegativeInfinity || x != x ? 0 : x;
            y = y == float.PositiveInfinity || y == float.NegativeInfinity || y != y ? 0 : y;
            z = z == float.PositiveInfinity || z == float.NegativeInfinity || z != z ? 0 : z;
            return new Vector3(x, y, z);
        }
        public static Vector3 operator /(Vector3 one, float two)
        {
            if (two == 0) return Vector3.zero;

            float x = one.x / two,
            y = one.y / two,
            z = one.z / two;

            x = x == float.PositiveInfinity || x == float.NegativeInfinity || x != x ? 0 : x;
            y = y == float.PositiveInfinity || y == float.NegativeInfinity || y != y ? 0 : y;
            z = z == float.PositiveInfinity || z == float.NegativeInfinity || z != z ? 0 : z;

            return new Vector3(x, y, z);
        }
        public static Vector3 Vector2ToVector3(Vector2 temp) => new Vector3(temp.x, temp.y, 0);

        public static bool operator ==(Vector3 one, Vector3 two) => one.Equals(two);
        public static bool operator ==(Vector3 one, Vector2 two) => one.Equals(Vector3.Vector2ToVector3(two));
        public static bool operator !=(Vector3 one, Vector3 two) => !one.Equals(two);
        public static bool operator !=(Vector3 one, Vector2 two) => !one.Equals(Vector3.Vector2ToVector3(two));
        public override string ToString() => "X: " + x + ", Y: " + y + ", Z: " + z;

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