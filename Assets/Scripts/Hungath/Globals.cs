using UnityEngine;

namespace Hungath
{
    public static class Globals
    {
        //GameObjects
        public static int MapDimensionMin = 3;
        public static int MapDimensionMax = 8;

        //Audio
        public static float MasterVolume = -20f;
        public static float MusicVolume = -20f;
        public static float SfxVolume = -20f;
        public static float VoicesVolume = -20f;

        //Colors
        /// <summary>
        /// Value for 80% transparency
        /// </summary>
        public static int Translucent4 = 204;
        /// <summary>
        /// Value for 60% transparency
        /// </summary>
        public static int Translucent3 = 153;
        /// <summary>
        /// Value for 40% transparency
        /// </summary>
        public static int Translucent2 = 102;
        /// <summary>
        /// Value for 20% transparency
        /// </summary>
        public static int Translucent1 = 51;
        public static Color32 HunterColor = new Color32(248, 138, 74, 255);
        public static Color32 GathererColor = new Color32(95, 209, 238, 255);
        /// <summary>
        /// Color32(24, 24, 24, 255)
        /// </summary>
        public static Color32 ThemeDarkBackground = new Color32(24, 24, 24, 255);

        /// <summary>
        /// Change the alpha of a static Color32 in Globals
        /// </summary>
        /// <param name="color">The color that will have its alpha channel altered</param>
        /// <param name="alpha">The desired alpha value, 0 - 255</param>
        /// <returns></returns>
        public static Color32 ChangeAlpha32(Color32 color, int alpha)
        {
            var value = new Color32(color.r, color.g, color.b, (byte)alpha);
            return value;
        }
    }
}
