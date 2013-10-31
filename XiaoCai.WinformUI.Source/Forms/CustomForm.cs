using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace XiaoCai.WinformUI.Forms
{
    public partial class CustomForm : Form, IStyle
    {
        //private IntPtr HandWnd;
        private Color color1;
        private Color color2;
        int beginX = 130;
        int widX = 36;
        int widFull = 113;
        Rectangle title_rect;
        Rectangle Button_rect;
        Rectangle Close_rect;
        Rectangle Max_rect;
        Rectangle Min_rect;
        Pen Pen_rect;
        Color MoveOnColor1;
        Color MoveOnColor2;
        Color MouseDownColor1;
        Color MouseDownColor2;
        Font font;
        int Radius = 4;

        public CustomForm()
        {
            InitializeComponent();
            RegistryKey rk;
            rk = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");
            string s = rk.GetValue("ProductName").ToString();
            //if (s.Trim().Equals("Microsoft Windows XP"))
            //{
            //    this.ControlBox = false;
            //}
            //else
            //{
            //    this.ControlBox = true;
            //}
            this.ControlBox = false;
            //HandWnd = this.Handle;//窗体句柄不能随便赋值，将释放当前指针地址，造成继承的Form属性赋值错误

            color1 = Color.SkyBlue;
            color2 = Color.RoyalBlue;
            Pen_rect = Pens.SteelBlue;
            MoveOnColor1 = Color.Silver;
            MoveOnColor2 = Color.DarkGray;
            MouseDownColor1 = Color.Silver;
            MouseDownColor2 = Color.Black;
            font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
            //Button_rect = new Rectangle(this.Bounds.Width - beginX, -9, widFull, 30);
  
        }

        [DllImport("User32.dll ")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        [DllImport("User32.dll ")]
        private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);
        [DllImport("Kernel32.dll ")]
        private static extern int GetLastError();
        [DllImport("User32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();//放开鼠标

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (this.ControlBox) return;
            if (this.FormBorderStyle != FormBorderStyle.None)
            {
                switch (m.Msg)
                {
                    case 0x86://WM_NCACTIVATE 
                        goto case 0x85;
                    case 0x85://WM_NCPAINT 
                        {
                            IntPtr hDC = GetWindowDC(m.HWnd);
                            Graphics gs = Graphics.FromHdc(hDC);

                            #region 标题框
                            Rectangle rBackground = new Rectangle(0, 0, this.Width, SystemInformation.CaptionHeight + 4);
                            System.Drawing.Drawing2D.LinearGradientBrush bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground, color1, color2, LinearGradientMode.Vertical);
                            gs.FillRectangle(bBackground, rBackground);
                            //rBackground = new Rectangle(0, SystemInformation.CaptionHeight, this.Width, 4);
                            //bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground, color2, color1, LinearGradientMode.Vertical);
                            //gs.FillRectangle(bBackground, rBackground);
                            #endregion

                            //Image imgpm = Image.FromFile(Application.StartupPath + @"\blue.jpg");
                            //gs.DrawImage(imgpm, 0, 0, this.Width, SystemInformation.CaptionHeight + 2);    //显示背景图片

                            #region 左边框
                            rBackground = new Rectangle(0, 0, 4, SystemInformation.CaptionHeight + 4);
                            bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground, color1, color2, LinearGradientMode.Vertical);
                            gs.FillRectangle(bBackground, rBackground);
                            rBackground = new Rectangle(0, SystemInformation.CaptionHeight + 4, 4, this.Height - SystemInformation.CaptionHeight - 4);
                            bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground, color2, color2, LinearGradientMode.Vertical);
                            gs.FillRectangle(bBackground, rBackground);
                            #endregion

                            #region 右边框
                            rBackground = new Rectangle(this.Bounds.Width - 4, 0, 4, SystemInformation.CaptionHeight + 4);
                            bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground, color1, color2, LinearGradientMode.Vertical);
                            gs.FillRectangle(bBackground, rBackground);
                            rBackground = new Rectangle(this.Bounds.Width - 4, SystemInformation.CaptionHeight + 4, 4, this.Height - SystemInformation.CaptionHeight - 4);
                            bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground, color2, color2, LinearGradientMode.Vertical);
                            gs.FillRectangle(bBackground, rBackground);
                            #endregion

                            #region 下边框
                            rBackground = new Rectangle(0, this.Bounds.Height - 4, this.Bounds.Width, 4);
                            bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground, color2, color2, LinearGradientMode.Vertical);
                            gs.FillRectangle(bBackground, rBackground);
                            #endregion


                            #region 图标与标题
                            if (this.ShowIcon)
                                gs.DrawImage(this.Icon.ToBitmap(), 5, 5, 24, 20);//画标题栏小小图标
                            StringFormat strFmt = new StringFormat();
                            strFmt.Alignment = StringAlignment.Near;
                            strFmt.LineAlignment = StringAlignment.Center;
                            int textX = this.ShowIcon ? 32 : 4;
                            title_rect = new Rectangle(textX, 5, 600, 20);
                            gs.DrawString(this.Text, this.Font, Brushes.BlanchedAlmond, title_rect, strFmt);
                            #endregion

                            #region  控制区域

                            strFmt.Alignment = StringAlignment.Center;

                            if (!this.MinimizeBox && !this.MaximizeBox)
                            {
                                Button_rect = new Rectangle(this.Bounds.Width - beginX + widX * 2, -9, widFull - widX * 2, 30);
                                gs.DrawPath(Pen_rect, CreateRoundedRectanglePath(Button_rect, RoundDirect.All, Radius));
                            }
                            else if (!this.MinimizeBox && this.MaximizeBox)
                            {
                                Button_rect = new Rectangle(this.Bounds.Width - beginX + widX, -9, widFull - widX, 30);
                                gs.DrawPath(Pen_rect, CreateRoundedRectanglePath(Button_rect, RoundDirect.All, Radius));
                                gs.DrawLine(Pen_rect, this.Bounds.Width - beginX + widX, 0, this.Bounds.Width - beginX + widX, 21);
                                gs.DrawLine(Pen_rect, this.Bounds.Width - beginX + widX * 2, 0, this.Bounds.Width - beginX + widX * 2, 21);
                            }
                            else
                            {
                                Button_rect = new Rectangle(this.Bounds.Width - beginX, -9, widFull, 30);
                                gs.DrawPath(Pen_rect, CreateRoundedRectanglePath(Button_rect, RoundDirect.All, Radius));
                                gs.DrawLine(Pen_rect, this.Bounds.Width - beginX + widX, 0, this.Bounds.Width - beginX + widX, 21);
                                gs.DrawLine(Pen_rect, this.Bounds.Width - beginX + widX * 2, 0, this.Bounds.Width - beginX + widX * 2, 21);
                            }

                            if (this.MinimizeBox && this.MaximizeBox)
                            {
                                Min_rect = new Rectangle(this.Bounds.Width - beginX + 1, 2, widX - 1, 21);
                                gs.DrawString("—", font, Brushes.BlanchedAlmond, Min_rect, strFmt);

                                Max_rect = new Rectangle(this.Bounds.Width - beginX + widX + 1, 2, widX - 1, 21);
                                gs.DrawString("□", font, Brushes.BlanchedAlmond, Max_rect, strFmt);
                            }

                            if (!this.MinimizeBox && this.MaximizeBox)
                            {
                                Max_rect = new Rectangle(this.Bounds.Width - beginX + widX + 1, 2, widX - 1, 21);
                                gs.DrawString("□", font, Brushes.BlanchedAlmond, Max_rect, strFmt);
                            }
                            else if (this.MinimizeBox &&! this.MaximizeBox)
                            {
                                Min_rect = new Rectangle(this.Bounds.Width - beginX + 1, 2, widX - 1, 21);
                                gs.DrawString("—", font, Brushes.BlanchedAlmond, Min_rect, strFmt);
                            }

                            Close_rect = new Rectangle(this.Bounds.Width - beginX + widX * 2 + 1, 2, widFull - widX * 2 - 1, 21);
                            gs.DrawString("×", font, Brushes.BlanchedAlmond, Close_rect, strFmt);

                            gs.Dispose();
                            ReleaseDC(m.HWnd, hDC);
                            break;

                            #endregion 
                        }
                    case 0xA1://WM_NCLBUTTONDOWN 
                        {
                            #region

                            Point mousePoint = new Point((int)m.LParam);
                            mousePoint.Offset(-this.Left, -this.Top);
                            if (Close_rect.Contains(mousePoint))
                            {
                                PostMessage(this.Handle, 0x0112, 0xF060, 0);
                            }
                            else if (Max_rect.Contains(mousePoint))
                            {
                                if (this.WindowState == FormWindowState.Maximized)
                                    PostMessage(this.Handle, 0x0112, 0xF120, 0);
                                else
                                    PostMessage(this.Handle, 0x0112, 0xF030, 0);
                            }
                            else if (Min_rect.Contains(mousePoint))
                            {
                                PostMessage(this.Handle, 0x0112, 0xF020, 0);
                            }
                            ReleaseCapture();
                            break;

                            #endregion 
                        }
                    case 0x00A0:
                        {

                            #region
                            //ColorBlend mix = new ColorBlend();
                            //Color[] colors = ColorHelper.colors1;
                            //mix.Colors = new Color[] { colors[0], colors[1], colors[2], colors[3] };
                            //mix.Positions = new float[] { 0.0F, 0.3F, 0.35F, 1.0F };

                            ////col = new Rectangle(Max_rect.X, 0, Max_rect.Width, Max_rect.Height);
                            //bBackground = new LinearGradientBrush(col, Color.Transparent, Color.Transparent, LinearGradientMode.Vertical);
                            //bBackground.InterpolationColors = mix;
                            //gs.FillRectangle(bBackground, col);
                            //gs.DrawString("□", font, Brushes.BlanchedAlmond, Max_rect, strFmt);
                            #endregion 

                            #region 

                            Point mousePoint = new Point((int)m.LParam);
                            mousePoint.Offset(-this.Left, -this.Top);
                            //if (!Button_rect.Contains(mousePoint)) 
                            //{
                            //    return;
                            //}
                            Rectangle col;
                            IntPtr hDC = GetWindowDC(m.HWnd);
                            Graphics gs = Graphics.FromHdc(hDC);
                            LinearGradientBrush bBackground;
                            StringFormat strFmt = new StringFormat();
                            strFmt.Alignment = StringAlignment.Center;
                            strFmt.LineAlignment = StringAlignment.Center;

                            col = new Rectangle(Close_rect.X, 0, Close_rect.Width, Close_rect.Height);
                            if (Close_rect.Contains(mousePoint))
                            {
                                bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(col, Color.Red, Color.Red, LinearGradientMode.Vertical);
                                //bBackground = new LinearGradientBrush(col, Color.Transparent, Color.Transparent, LinearGradientMode.Vertical);
                                //bBackground.InterpolationColors = mix;
                            }
                            else
                            {
                                bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(col, color1, color2, LinearGradientMode.Vertical);
                            }
                            gs.FillPath(bBackground, CreateRoundedRectanglePath(col, RoundDirect.RightDown, Radius));
                            gs.DrawString("×", font, Brushes.BlanchedAlmond, Close_rect, strFmt);

                            if (this.MaximizeBox)
                            {
                                col = new Rectangle(Max_rect.X, 0, Max_rect.Width, Max_rect.Height);
                                if (Max_rect.Contains(mousePoint))
                                {
                                    bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(col, MoveOnColor1, MoveOnColor2, LinearGradientMode.Vertical);
                                }
                                else
                                {
                                    bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(col, color1, color2, LinearGradientMode.Vertical);
                                }
                                gs.FillRectangle(bBackground, col);
                                gs.DrawString("□", font, Brushes.BlanchedAlmond, Max_rect, strFmt);
                            }

                            if (this.MinimizeBox)
                            {
                                col = new Rectangle(Min_rect.X, 0, Min_rect.Width, Min_rect.Height);
                                if (Min_rect.Contains(mousePoint))
                                {
                                    bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(col, MoveOnColor1, MoveOnColor2, LinearGradientMode.Vertical);
                                }
                                else
                                {
                                    bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(col, color1, color2, LinearGradientMode.Vertical);
                                }
                                gs.FillPath(bBackground, CreateRoundedRectanglePath(col, RoundDirect.LeftDown, Radius));
                                gs.DrawString("—", font, Brushes.BlanchedAlmond, Min_rect, strFmt);
                            }

                            gs.Dispose();
                            ReleaseDC(m.HWnd, hDC);
                            //PostMessage(HandWnd, 0x86, 1, (int)m.LParam);
                            break;

                            #endregion 
                        }
                }
            }
        }

        public GraphicsPath CreateRoundedRectanglePath(Rectangle rect, RoundDirect direct, int cornerRadius)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            switch (direct)
            {
                case RoundDirect.LeftDown:
                    roundedRect.AddLine(rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                    roundedRect.AddLine(rect.X + rect.Width, rect.Y, rect.X + rect.Width, rect.Bottom);
                    roundedRect.AddLine(rect.X + rect.Width, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
                    roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                    roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y);
                    roundedRect.CloseFigure();
                    break;
                case RoundDirect.RightDown:
                    roundedRect.AddLine(rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                    roundedRect.AddLine(rect.X + rect.Width, rect.Y, rect.X + rect.Width, rect.Bottom - cornerRadius * 2);
                    roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
                    roundedRect.AddLine(rect.X + rect.Width - cornerRadius * 2, rect.Bottom, rect.X, rect.Bottom);
                    roundedRect.AddLine(rect.X, rect.Bottom, rect.X, rect.Y);
                    roundedRect.CloseFigure();
                    break;
                case RoundDirect.All:
                    roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
                    roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
                    roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
                    roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
                    roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
                    roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
                    roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                    roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
                    roundedRect.CloseFigure();
                    break;
                default: break;
            }
            return roundedRect;
        }

        public enum RoundDirect
        {
            LeftUp,
            LeftDown,
            RightUp,
            RightDown,
            All
        }


        #region 新增鼠标按下时标题栏颜色变化
        protected override void DefWndProc(ref Message m)
        {
            if (this.FormBorderStyle != FormBorderStyle.None)
            {
                switch (m.Msg)
                {
                    case 0xA1://WM_NCLBUTTONDOWN 当用户释放鼠标左键同时光标某个窗口在非客户区发送信息
                        {
                            Point mousePoint = new Point((int)m.LParam);
                            mousePoint.Offset(-this.Left, -this.Top);
                            if (Close_rect.Contains(mousePoint))
                            {
                                this.MouseDownColor(MouseDownStyle.Close, m);
                            }
                            else if (Max_rect.Contains(mousePoint) && this.MaximizeBox)
                            {
                                this.MouseDownColor(MouseDownStyle.Max, m);
                            }
                            else if (Min_rect.Contains(mousePoint) && this.MinimizeBox)
                            {
                                this.MouseDownColor(MouseDownStyle.Min, m);
                            }
                            ReleaseCapture();
                            break;
                        }
                }
            }
            base.DefWndProc(ref m);
        }

        public void MouseDownColor(MouseDownStyle ms, Message m)
        {
            Point mousePoint = new Point((int)m.LParam);
            mousePoint.Offset(-this.Left, -this.Top);
            Rectangle col;
            IntPtr hDC = GetWindowDC(m.HWnd);
            Graphics gs = Graphics.FromHdc(hDC);
            LinearGradientBrush bBackground;
            StringFormat strFmt = new StringFormat();
            strFmt.Alignment = StringAlignment.Center;
            strFmt.LineAlignment = StringAlignment.Center;
            switch (ms)
            {
                case MouseDownStyle.Max:
                    {
                        col = new Rectangle(Max_rect.X, 0, Max_rect.Width, Max_rect.Height);
                        bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(col, MouseDownColor1, MouseDownColor2, LinearGradientMode.Vertical);
                        gs.FillRectangle(bBackground, col);
                        gs.DrawString("□", font, Brushes.BlanchedAlmond, Max_rect, strFmt);
                        gs.Dispose();
                        ReleaseDC(m.HWnd, hDC);
                        break;
                    }
                case MouseDownStyle.Min:
                    {
                        col = new Rectangle(Min_rect.X, 0, Min_rect.Width, Min_rect.Height);
                        bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(col, MouseDownColor1, MouseDownColor2, LinearGradientMode.Vertical);
                        gs.FillPath(bBackground, CreateRoundedRectanglePath(col, RoundDirect.LeftDown, Radius));
                        gs.DrawString("—", font, Brushes.BlanchedAlmond, Min_rect, strFmt);
                        gs.Dispose();
                        ReleaseDC(m.HWnd, hDC);
                        break;
                    }
                case MouseDownStyle.Close:
                    {
                        col = new Rectangle(Close_rect.X, 0, Close_rect.Width, Close_rect.Height);
                        bBackground = new System.Drawing.Drawing2D.LinearGradientBrush(col, Color.Red, Color.Black, LinearGradientMode.Vertical);
                        gs.FillPath(bBackground, CreateRoundedRectanglePath(col, RoundDirect.RightDown, Radius));
                        gs.DrawString("×", font, Brushes.BlanchedAlmond, Close_rect, strFmt);
                        gs.Dispose();
                        ReleaseDC(m.HWnd, hDC);
                        break;
                    }

            }
        }

        public enum MouseDownStyle
        {
            Max,
            Min,
            Close
        }
        #endregion

        #region ISkyrayStyle 成员

        public void SetStyle(Style style)
        {
            switch (style)
            {
                case Style.Office2007Blue:
                    color1 = Color.SkyBlue;
                    color2 = Color.RoyalBlue;
                    Pen_rect = Pens.SteelBlue;
                    PostMessage(this.Handle, 134, 0, 1);
                    break;
                case Style.Office2007Silver:
                    color1 = Color.DarkGray;
                    color2 = Color.Black;
                    Pen_rect = Pens.Black;
                    PostMessage(this.Handle, 134, 0, 1);
                    break;
                case Style.Office2007Black:
                    color2 = Color.FromArgb(98, 0, 1);
                    color1 = Color.Black;
                    Pen_rect = new Pen(Color.FromArgb(99, 67, 65));
                    MoveOnColor1 = Color.Gold;
                    MoveOnColor2 = Color.Orange;
                    PostMessage(this.Handle, 134, 0, 1);
                    break;
                default: break;
            }
        }

        private Style _Style = Style.Office2007Blue;

        public Style Style
        {
            get
            {
                return _Style;
            }
            set
            {
                _Style = value;
                SetStyle(_Style);
            }
        }

        #endregion
         
 
         
    }
}

