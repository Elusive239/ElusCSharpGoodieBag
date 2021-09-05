using System;

#pragma warning disable CS1718
namespace ElusGoodies.Vectors
{
    public class Vector3Int : IEquatable<Vector3Int>
    {
        public int x, y, z;
        public Vector3Int(int _x, int _y, int _z) { x = _x; y = _y; z = _z; }
        public static Vector3Int zero => new Vector3Int(0, 0, 0);
        public static Vector3Int up => new Vector3Int(0, 1, 0);
        public static Vector3Int down => new Vector3Int(0, -1, 0);
        public static Vector3Int right => new Vector3Int(1, 0, 0);
        public static Vector3Int left => new Vector3Int(-1, 0, 0);

        public static Vector3Int forward => new Vector3Int(0, 0, 1);
        public static Vector3Int back => new Vector3Int(0, 0, -1);

        public int magnitude => (int)Math.Sqrt(x*x + y*y + z*z);
        public Vector3Int normalize => new Vector3Int (
            Math.Clamp( x , -1, 1),
            Math.Clamp( y, -1, 1), 
            Math.Clamp( z, -1, 1)
        );
        public static Vector3Int Direction (Vector3Int startingPos, Vector3Int endPos, bool normalize){
            Vector3Int temp = endPos - startingPos;
            if(normalize){
                temp = temp.normalize;
            }
            
            return temp;
        }
        public static int Distance(Vector3Int one, Vector3Int two)
        {
            int x = (two.x - one.x);
            int y = (two.y - one.y);
            int z = (two.z - one.z);
            return (int)Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        public bool Equals(Vector3Int other)
        {
            int thisX = x * 100, thisY = y * 100, thisZ = z * 100,
            otherX = other.x * 100, otherY = other.y * 100, otherZ = other.z * 100;

            thisX = (int)Math.Round(thisX) / 100f;
            thisY = (int)Math.Round(thisY) / 100f;
            thisZ = (int)Math.Round(thisZ) / 100f;

            otherX = (int)Math.Round(otherX) / 100f;
            otherY = (int)Math.Round(otherY) / 100f;
            otherZ = (int)Math.Round(otherZ) / 100f;

            return otherX == thisX && otherY == thisY && otherZ == thisZ;
        }

        public void Invert() { int t = z; z = x; x = t; }
        public static Vector3Int operator +(Vector3Int one, Vector3Int two) => new Vector3Int(one.x + two.x, one.y + two.y, one.z + two.z);
        public static Vector3Int operator +(Vector3Int one, Vector2Int two) => new Vector3Int(one.x + two.x, one.y + two.y, one.z);
        public static Vector3Int operator -(Vector3Int one, Vector3Int two) => new Vector3Int(one.x - two.x, one.y - two.y, one.z - two.z);
        public static Vector3Int operator -(Vector3Int one, Vector2Int two) => new Vector3Int(one.x - two.x, one.y - two.y, one.z);
        public static Vector3Int operator *(Vector3Int one, Vector3Int two) => new Vector3Int(one.x * two.x, one.y * two.y, one.z * two.z);
        public static Vector3Int operator *(Vector3Int one, Vector2Int two) => new Vector3Int(one.x * two.x, one.y * two.y, one.z);
        public static Vector3Int operator *(Vector3Int one, int two) => new Vector3Int(one.x * two, one.y * two, one.z * two);
        public static Vector3Int operator /(Vector3Int one, Vector3Int two)
        {

            int x = one.x / two.x,
            y = one.y / two.y,
            z = one.z / two.z;

            x = x == int.MaxValue || x == int.MinValue || x != x ? 0 : x;
            y = y == int.MaxValue || y == int.MinValue || y != y ? 0 : y;
            z = z == int.MaxValue || z == int.MinValue || z != z ? 0 : z;
            return new Vector3Int(x, y, z);
        }
        public static Vector3Int operator /(Vector3Int one, Vector2Int two)
        {

            int x = one.x / two.x,
            y = one.y / two.y,
            z = one.z;

            x = x == int.MaxValue || x == int.MinValue || x != x ? 0 : x;
            y = y == int.MaxValue || y == int.MinValue || y != y ? 0 : y;
            z = z == int.MaxValue || z == int.MinValue || z != z ? 0 : z;
            return new Vector3Int(x, y, z);
        }
        public static Vector3Int operator /(Vector3Int one, int two)
        {
            if (two == 0) return Vector3Int.zero;

            int x = one.x / two,
            y = one.y / two,
            z = one.z / two;

            x = x == int.MaxValue || x == int.MinValue || x != x ? 0 : x;
            y = y == int.MaxValue || y == int.MinValue || y != y ? 0 : y;
            z = z == int.MaxValue || z == int.MinValue || z != z ? 0 : z;

            return new Vector3Int(x, y, z);
        }
        public static Vector3Int Vector2IntToVector3Int(Vector2Int temp) => new Vector3Int(temp.x, temp.y, 0);

        public static bool operator ==(Vector3Int one, Vector3Int two) => one.Equals(two);
        public static bool operator ==(Vector3Int one, Vector2Int two) => one.Equals(Vector3Int.Vector2IntToVector3Int(two));
        public static bool operator !=(Vector3Int one, Vector3Int two) => !one.Equals(two);
        public static bool operator !=(Vector3Int one, Vector2Int two) => !one.Equals(Vector3Int.Vector2IntToVector3Int(two));
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