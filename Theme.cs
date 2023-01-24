using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESATAutomationDevelop
{
    public static class Theme
    {
        private static double themeMultiplier = 0.3;
        //EATON Blue (8, 118, 200)
        private static Color eatonBlue = Color.FromArgb(8, 118, 200);
        //private static Color eatonBlue = Color.FromArgb(243, 202, 64);
        //CESAT Yellow (255, 255, 0)
        private static Color cesatYellow = Color.FromArgb(255, 255, 0);
        //Contrast gray used for panels
        //private static Color contrastGray = Color.FromArgb(145, 133, 120);
        //private static Color contrastGray = Color.FromArgb(79, 71, 64);
        private static Color contrastGray = Color.FromArgb(101, 91, 83);
        //Multipled color used for overlaped like sections
        private static Color buttonColorOn = Color.Green;
        private static Color buttonColorOff = Color.DarkGreen;
        public static Color EatonBlue { get => eatonBlue; }
        public static Color CesatYellow { get => cesatYellow; }
        public static Color ContrastGray { get => contrastGray; }
        public static double ThemeMultiplier { get => themeMultiplier; set => themeMultiplier = value; }

        /// <summary>Blends the specified colors together.</summary>
        /// <param name="color">Color to blend onto the background color.</param>
        /// <param name="backColor">Color to blend the other color onto.</param>
        /// <param name="amount">How much of <paramref name="color"/> to keep,
        /// “on top of” <paramref name="backColor"/>.</param>
        /// <returns>The blended colors.</returns>
        /// https://stackoverflow.com/questions/3722307/is-there-an-easy-way-to-blend-two-system-drawing-color-values
        public static Color Blend(this Color color, Color backColor, double amount)
        {
            byte r = (byte)(color.R * amount + backColor.R * (1 - amount));
            byte g = (byte)(color.G * amount + backColor.G * (1 - amount));
            byte b = (byte)(color.B * amount + backColor.B * (1 - amount));
            return Color.FromArgb(r, g, b);
        }
    }
}
