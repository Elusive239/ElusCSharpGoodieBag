using System;
using System.Drawing;
using System.Collections.Generic;

namespace ElusGoodies.BitmapStuffs
{
    public static class BitMapStorage{
        static List<Bitmap> maps = new List<Bitmap>();

        public static bool Add(string item){
            try{
                maps.Add(new Bitmap(item));
                return true;
            }catch{
                return false;
            }
            
        }

        public static bool Remove(string item){
            Bitmap temp = new Bitmap(item);
            return maps.Remove(temp);
        }

        public static bool Contains(string item){
            Bitmap temp = new Bitmap(item);
            return maps.Contains(temp);
        }

        public static Bitmap B(int index){
            return maps[index];
        }
    }
}