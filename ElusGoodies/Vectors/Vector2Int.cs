using System;

#pragma warning disable CS1718
namespace ElusGoodies.Vectors
{
    public class Vector2Int : IEquatable<Vector2Int>
    {
        public int x, y;

        public Vector2Int(int _x, int _y) { x = _x; y = _y; }
        public static Vector2Int zero => new Vector2Int(0, 0);
        public static Vector2Int up => new Vector2Int(0, 1);
        public static Vector2Int down => new Vector2Int(0, -1);
        public static Vector2Int right => new Vector2Int(1, 0);
        public static Vector2Int left => new Vector2Int(-1, 0);
        public int magnitude => (int) Math.Sqrt(x*x + y*y);
        public Vector2Int normalize => new Vector2Int (
            Math.Clamp( x , -1, 1),
            Math.Clamp( y, -1, 1)
        );
        public static Vector2Int Direction (Vector2Int startingPos, Vector2Int endPos, bool normalize){
            Vector2Int temp = endPos-startingPos;
            if(normalize){
                temp = temp.normalize;
            }
            
            return temp;
        }
        public static int Distance(Vector2Int one, Vector2Int two){
            int x = (two.x - one.x);
            int y = (two.y - one.y);
            return (int)Math.Sqrt((x * x) + (y * y));
        }

        public bool Equals(Vector2Int other){
            int thisX = x * 100, thisY = y * 100, otherX = other.x * 100, otherY = other.y * 100;
            thisX = (int)Math.Round(thisX) / 100;
            thisY = (int)Math.Round(thisY) / 100;
            otherX = (int)Math.Round(otherX) / 100;
            otherY = (int)Math.Round(otherY) / 100;

            return otherX == thisX && otherY == thisY;
        }

        public void Invert() { int t = x; x = y; y = t; }
        public static Vector2Int operator +(Vector2Int one, Vector2Int two) => new Vector2Int(one.x + two.x, one.y + two.y);
        public static Vector2Int operator +(Vector2Int one, Vector3Int two) => new Vector2Int(one.x + two.x, one.y + two.y);
        public static Vector2Int operator -(Vector2Int one, Vector2Int two) => new Vector2Int(one.x - two.x, one.y - two.y);
        public static Vector2Int operator -(Vector2Int one, Vector3Int two) => new Vector2Int(one.x - two.x, one.y - two.y);
        public static Vector2Int operator *(Vector2Int one, Vector2Int two) => new Vector2Int(one.x * two.x, one.y * two.y);
        public static Vector2Int operator *(Vector2Int one, int two) => new Vector2Int(one.x * two, one.y * two);
        public static Vector2Int operator *(Vector2Int two, Vector3Int one) => new Vector2Int(one.x * two.x, one.y * two.y);
        public static Vector2Int operator /(Vector2Int one, Vector2Int two){
            int x = one.x / two.x,
            y = one.y / two.y;

            x = x == int.MaxValue || x == int.MinValue || x != x ? 0 : x;
            y = y == int.MaxValue || y == int.MinValue || y != y ? 0 : y;

            return new Vector2Int(x, y);
        }
        public static Vector2Int operator /(Vector2Int two, Vector3Int one){
            int x = one.x / two.x,
            y = one.y / two.y;

            x = x == int.MaxValue || x == int.MinValue || x != x ? 0 : x;
            y = y == int.MaxValue || y == int.MinValue || y != y ? 0 : y;
            return new Vector2Int(x, y);
        }
        public static Vector2Int operator /(Vector2Int one, int two)
        {
            if (two == 0) return Vector2Int.zero;

            int x = one.x / two,
            y = one.y / two;

            x = x == int.MaxValue || x == int.MinValue || x != x ? 0 : x;
            y = y == int.MaxValue || y == int.MinValue || y != y ? 0 : y;

            return new Vector2Int(x, y);
        }
        public static Vector2Int Vector3IntToVector2Int(Vector3Int temp) => new Vector2Int(temp.x, temp.y);
        public static bool operator ==(Vector2Int one, Vector2Int two) => one.Equals(two);
        public static bool operator ==(Vector2Int one, Vector3Int two) => one.Equals(Vector2Int.Vector3IntToVector2Int(two));
        public static bool operator !=(Vector2Int one, Vector2Int two) => !one.Equals(two);
        public static bool operator !=(Vector2Int one, Vector3Int two) => !one.Equals(Vector2Int.Vector3IntToVector2Int(two));
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
