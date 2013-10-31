using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace XiaoCai.WinformUI
{

    internal class BorderDrawer
    {
        private const int WM_ERASEBKGND = 20;
        private static int WM_NCPAINT = 0x85;
        private static int WM_PAINT = 15;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, int flags);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);

        public void DrawBorder(ref Message message, Color borderColor, int width, int height)
        {
            if (((message.Msg == WM_NCPAINT) || (message.Msg == WM_ERASEBKGND)) || (message.Msg == WM_PAINT))
            {
                IntPtr wParam = message.WParam;
                IntPtr hdc = GetDCEx(message.HWnd, wParam, 0x21);
                if (hdc != IntPtr.Zero)
                {
                    Graphics graphics = Graphics.FromHdc(hdc);
                    Rectangle bounds = new Rectangle(0, 0, width, height);
                    ControlPaint.DrawBorder(graphics, bounds, borderColor, ButtonBorderStyle.Solid);
                    message.Result = (IntPtr)1;
                    ReleaseDC(message.HWnd, hdc);
                }
            }
        }
    }
}

