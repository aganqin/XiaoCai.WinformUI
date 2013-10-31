using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace XiaoCai.WinformUI
{
    public class StyleHelp
    {
        public static void DrawArc(Rectangle re, GraphicsPath pa, int radius, EGroupPos _grouppos)
        {
            int radiusX0Y0 = radius,
                radiusXfy0 = radius,
                radiusX0Yf = radius,
                radiusXfyf = radius;

            switch (_grouppos)
            {
                case EGroupPos.Left:
                    radiusXfy0 = 1; radiusXfyf = 1;
                    break;
                case EGroupPos.Center:
                    radiusX0Y0 = 1; radiusX0Yf = 1; radiusXfy0 = 1; radiusXfyf = 1;
                    break;
                case EGroupPos.Right:
                    radiusX0Y0 = 1; radiusX0Yf = 1;
                    break;
                case EGroupPos.Top:
                    radiusX0Yf = 1; radiusXfyf = 1;
                    break;
                case EGroupPos.Bottom:
                    radiusX0Y0 = 1; radiusXfy0 = 1;
                    break;
            }
            pa.AddArc(re.X, re.Y, radiusX0Y0, radiusX0Y0, 180, 90);
            pa.AddArc(re.Width - radiusXfy0, re.Y, radiusXfy0, radiusXfy0, 270, 90);
            pa.AddArc(re.Width - radiusXfyf, re.Height - radiusXfyf, radiusXfyf, radiusXfyf, 0, 90);
            pa.AddArc(re.X, re.Height - radiusX0Yf, radiusX0Yf, radiusX0Yf, 90, 90);
            pa.CloseFigure();
        }
    }

    public enum EGroupPos
    {
        None, Left, Center, Right, Top, Bottom
    }
}
