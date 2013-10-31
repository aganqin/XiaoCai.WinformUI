using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace XiaoCai.WinformUI
{
    public class ColorHelper
    {
        //default
        public static Color[] Colors0 = new Color[]
        {
            Color.FromArgb(200,223,237,255),  
            Color.FromArgb(200,211,231,255),
            Color.FromArgb(200,207,228,255),
            Color.FromArgb(200,175,210,255),
            Color.FromArgb(200,101,147,207)
        };
        //hover
        public static Color[] Colors1 = new Color[]
        {
            Color.FromArgb(255,255,253,238),
            Color.FromArgb(255,255,237,172),
            Color.FromArgb(255,255,224,131),
            Color.FromArgb(255,255,229,155),
            Color.FromArgb(255,196,177,118)
        };
        //press
        public static Color[] Colors2 = new Color[]
        {
            Color.FromArgb(255,255,236,212),
            Color.FromArgb(255,255,198,125),
            Color.FromArgb(255,255,182,88),
            Color.FromArgb(255,255,218,114),
            Color.FromArgb(255,128,64,0)
        };
        //sliver
        public static Color[] Colors3 = new Color[]
        {
            Color.FromArgb(200, 234, 237, 249),
            Color.FromArgb(200, 228, 232, 243),
            Color.FromArgb(200, 225, 229, 240),
            Color.FromArgb(200, 213, 217, 227),
            Color.FromArgb(255,111, 112, 116)
        };

        public static Color[] Colors4 = new Color[]
        {
            Color.FromArgb(255,255,255,178),
            Color.FromArgb(255,255,214,108),
            Color.FromArgb(255,255, 189, 105),
            Color.FromArgb(255,255,255,178),
            Color.FromArgb(255,196,177,118)
        };

        //red
        public static Color[] Colors5 = new Color[]
        {
            
            Color.FromArgb(98, 0, 1),
            Color.DarkRed,
            Color.Maroon,
            Color.DarkRed,
            Color.FromArgb(98, 0, 1)
        };

        public static Color[] RedColor = new Color[]
        {
            
            Color.Crimson,
            Color.Red,
            Color.DarkRed,
            Color.Red,
            Color.Crimson
        };

        public static Color[] Colors6 = new Color[]
        {
            Color.Maroon,
            Color.FromArgb(98, 0, 1),
            Color.DarkRed,
            Color.FromArgb(98, 0, 1),
            Color.Maroon           
        };

        public static Color[] Colors7 = new Color[]
        {
            Color.DarkRed,
            Color.Maroon,
            Color.FromArgb(98, 0, 1),
            Color.Maroon,
            Color.DarkRed
        };

        public static Color[] Colors8 = new Color[]
        {
            Color.HotPink,
            Color.Pink,
            Color.HotPink,
            Color.Pink,
            Color.HotPink
        };
        public static Color[] Colors9 = new Color[]
        {
            Color.Pink,
            Color.LightPink,
            Color.HotPink,
            Color.LightPink,
            Color.Pink
        };

        public static Color[] GreenColors = new Color[]
        {
            Color.FromArgb(160, 154, 205, 50),
             //Color.Green,
            Color.FromArgb(120, 154, 205, 50),
             Color.FromArgb(200, 154, 205, 50),
            // Color.GreenYellow,
            Color.FromArgb(120, 154, 205, 50),
            //Color.FromArgb(160, 154, 205, 50)
            Color.Green
        };
        public static Color[] GreenColors1 = new Color[]
        {
            Color.FromArgb(160, 154, 205, 50),
            Color.FromArgb(120, 154, 205, 50),
            Color.GreenYellow,
            Color.FromArgb(120, 154, 205, 50),
            Color.YellowGreen
        };

        public static Color[] ColorFormCaption = new Color[] 
        {
            Color.FromArgb(255,96,177,254),  
            Color.FromArgb(255,125,199,255),
            Color.FromArgb(255,129,202,255),
            Color.FromArgb(255,140,210,255),
            Color.FromArgb(255,101,147,207)
        };

        public static ColorBlend GetBlend3()
        {
            ColorBlend mix = new ColorBlend();
            Color[] colors = null;
            colors = ColorHelper.Colors4;
            mix.Colors = new Color[] { colors[0], colors[2], colors[3] };
            mix.Positions = new float[] { 0.0F, 0.5F, 1.0F };
            return mix;
        }
        public static ColorBlend GetBlend4()
        {
            ColorBlend mix = new ColorBlend();
            Color[] colors = null;
            colors = ColorHelper.Colors1;
            mix.Colors = new Color[] { colors[0], colors[1],colors[2], colors[3] };
            mix.Positions = new float[] { 0.0F, 0.3F,0.35F, 1.0F };
            return mix;
        }

        public static ColorBlend GetBlendSliver()
        {
            ColorBlend mix = new ColorBlend();
            Color[] colors = null;
            colors = ColorHelper.Colors3;
            mix.Colors = new Color[] { colors[0], colors[1], colors[2], colors[3] };
            mix.Positions = new float[] { 0.0F, 0.3F, 0.35F, 1.0F };
            return mix;
        }

        public static ColorBlend GetBlendBlue()
        {
            ColorBlend mix = new ColorBlend();
            Color[] colors = null;
            colors = ColorHelper.Colors0;
            mix.Colors = new Color[] { colors[0], colors[1], colors[2], colors[3] };
            mix.Positions = new float[] { 0.0F, 0.3F, 0.35F, 1.0F };
            return mix;
        }
    }
}
