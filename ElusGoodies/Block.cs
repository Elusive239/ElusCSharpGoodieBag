using System;
using ElusGoodies.Vectors;

namespace ElusGoodies{
    //Designed for implementing things like grids in unity. should work without the namespace ElusGoodies.Vectors in unity without any extra work.
    public class Block{
        Vector2Int coords{get; set;}
        public int x {get{return coords.x;}}
        public int y {get{return coords.y;}}
        bool isWall {get; set;} 
        public Block(int x, int y, bool _isWall){
            Init(x,y,_isWall);
        }

        public void Init(int x, int y, bool _isWall){
            coords = new Vector2(x,y);
            isWall = _isWall;
        }
    }
}