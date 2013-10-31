using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace XiaoCai.WinformUI
{
    public class GraphHelper
    {
        public static void FillRect(Rectangle Rec, Graphics Grp)
        {
            ColorBlend mix = new ColorBlend();
            Color[] colors = ColorHelper.Colors1;

            mix.Colors = new Color[] { colors[0], colors[1], colors[2], colors[3] };

            mix.Positions = new float[] { 0.0F, 0.3F, 0.35F, 1.0F };

            var lgbrush =
                new LinearGradientBrush(Rec,
                    Color.Transparent,
                    Color.Transparent,
                    LinearGradientMode.Vertical);

            lgbrush.InterpolationColors = mix;
            Grp.FillRectangle(lgbrush, Rec);

        }

        public static void FillRect(Rectangle Rec, Graphics Grp, Style style)
        {
            ColorBlend mix = new ColorBlend();
            Color[] colors = ColorHelper.Colors1;
            //if (style == Style.Office2007Red)
            //{
            //    colors = ColorHelper.Colors7;
            //}

            mix.Colors = new Color[] { colors[0], colors[1], colors[2], colors[3] };

            mix.Positions = new float[] { 0.0F, 0.3F, 0.35F, 1.0F };

            var lgbrush =
                new LinearGradientBrush(Rec,
                    Color.Transparent,
                    Color.Transparent,
                    LinearGradientMode.Vertical);

            lgbrush.InterpolationColors = mix;
            Grp.FillRectangle(lgbrush, Rec);

        }
    }
}
