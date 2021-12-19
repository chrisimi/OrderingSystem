using System;
using System.Text;

namespace OrderingSystem.Domain
{
    public class WpfInfo
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Shape { get; set; }
        
        
        /// <summary>
        /// Converts a read-only character span that represents a WpfInfo Object to the equivalent WpfInfo Object
        /// </summary>
        /// <param name="input">The Character Span that represents the WpfInfo Object</param>
        /// <returns>The WpfInfo Object</returns>
        public static WpfInfo Parse(string input)
        { 
            string[] splitString = input.Split(",");
            return new WpfInfo()
            { 
                PosX = int.Parse(splitString[0]),
                PosY = int.Parse(splitString[1]),
                Height = int.Parse(splitString[2]),
                Width = int.Parse(splitString[3]),
                Shape = splitString[4]
            };
        }
        
        /// <summary>
        /// Converts a WpfInfo Object to its equivalent string representation.
        /// </summary>
        /// <param name="input">The WpfInfo Object</param>
        /// <returns>The string representation of the WpfInfo Object.</returns>
        public static string ToString(WpfInfo input)
        {
            1.ToString();
            return string.Format($"{input.PosX},{input.PosY},{input.Height},{input.Width},{input.Shape}");
        }
    }
}