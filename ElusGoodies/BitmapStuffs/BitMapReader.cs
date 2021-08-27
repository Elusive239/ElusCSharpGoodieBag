using System;
using System.Drawing;
using System.Collections.Generic;
using ElusGoodies.Vectors;

namespace ElusGoodies.BitmapStuffs
{   
    public static class BitMapReader{
        /// <summary>
        /// Returns a Dictionary of colors pulled from a bitmap stored with Vector2s as keys.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Dictionary<Vector2, Color> ReadColors(string filePath){
            Bitmap img = new Bitmap(filePath);
            Dictionary<Vector2, Color> colors = new Dictionary<Vector2, Color>();
            for(int x = 0; x < img.Width; x++){
                for(int y = 0; y < img.Height; y++){
                    Color colorToAdd = img.GetPixel(x,y);
                    colors.Add(new Vector2(x,y), colorToAdd);
                }
            }
            return colors;
        }

        /// <summary>
        ///  Returns a dictionary of all the colors in the bitmap, the values being
        ///  numbered instead of the whole color value.
        ///  0 is always equal to a pixel with no color.
        ///  this is intended for things like map building, where you wish to build things like mazes out of colors.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Dictionary<Vector2, Int32> ReadColorsAsIntegers(string filePath){
            Bitmap img = new Bitmap(filePath);
            Dictionary<Vector2, Int32> colors = new Dictionary<Vector2, Int32>();
            Color none = Color.FromArgb(0,0,0,0);
            List<Color> colorsAdded = new List<Color>();

            for(int x = 0; x < img.Width; x++){
                for(int y = 0; y < img.Height; y++){
                    Color colorToAdd = img.GetPixel(x,y);
                    if(colorToAdd == none)
                        colors.Add(new Vector2(x,y), 0);
                    else if(colorsAdded.Count <= 0 || !colorsAdded.Contains(colorToAdd)){
                        colors.Add(new Vector2(x,y), colorsAdded.Count);
                    }else{
                        colors.Add(new Vector2(x,y), GetIndex(colorToAdd, colorsAdded));
                    }
                }
            }

            return colors;
        }

        static int GetIndex(Color target, List<Color> colors){
            for(int i = 0; i < colors.Count; i++){
                if(target == colors[i]) return i;
            }
            return -1;
        }

        /// <summary>
        /// Returns a dictionary of colors in a bitmap stored as their ToString method.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Dictionary<Vector2, string> ReadColorsAsStrings(string filePath){
            Bitmap img = new Bitmap(filePath);
            Dictionary<Vector2, string> colors = new Dictionary<Vector2, string>();
            Color none = Color.FromArgb(0,0,0,0);
            List<Color> colorsAdded = new List<Color>();
            
            for(int x = 0; x < img.Width; x++){
                for(int y = 0; y < img.Height; y++){
                    Color colorToAdd = img.GetPixel(x,y);
                    colors.Add(new Vector2(x,y), colorToAdd.ToString());
                }
            }

            return colors;
        }
        
        /// <summary>
        /// Finds out what different colors are in the bitmap at the provided file path. returns that value.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int DifferentColors(string filePath){
            Bitmap img = new Bitmap(filePath);
            List<Color> colorsAdded = new List<Color>();
            for(int x = 0; x < img.Width; x++){
                for(int y = 0; y < img.Height; y++){
                    Color colorToAdd = img.GetPixel(x,y);
                    if(!colorsAdded.Contains(colorToAdd)){
                        colorsAdded.Add(colorToAdd);
                    }
                }
            }
            return colorsAdded.Count;
        }
    }
}