using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using XiaoCai.WinformUI.Panels;

namespace XiaoCai.WinformUI
{
    public partial class TextBoxW : TextBox, IStyle
    {
        private OfficeColorTable _officeColorTable;

        public TextBoxW()
        {
           // this.DoubleBuffered = true;
            _officeColorTable = StyleBuilderFactory.GetOffice2007ColorTable(_style);
            this.BorderColor = _officeColorTable.TextBoxBorderColor;
            this.Refresh();
        }
        /// <summary>
        /// 重绘文本款Border颜色
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (((m.Msg == WinMsgs.WM_NCPAINT) || (m.Msg == WinMsgs.WM_ERASEBKGND))
                || (m.Msg == WinMsgs.WM_PAINT) )
            {
                IntPtr wParam = m.WParam;
                IntPtr hdc = WinMethod.GetDCEx(m.HWnd, wParam, 0x21);
                if (hdc != IntPtr.Zero)
                {
                    Graphics graphics = Graphics.FromHdc(hdc);
                    Rectangle bounds = new Rectangle(0, 0, base.Width, base.Height);
                    ControlPaint.DrawBorder(graphics, bounds, this._borderColor, ButtonBorderStyle.Solid);
                    m.Result = (IntPtr)1;
                    WinMethod.ReleaseDC(m.HWnd, hdc);
                }
            }
        }

        private Color _borderColor;

        [DefaultValue(typeof(Color), "121, 153, 194")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                if (_borderColor != value)
                {
                    _borderColor = value;
                    base.Invalidate();
                }
            }
        }

        #region IStyle 成员
        public void SetStyle(Style style)
        {
            _officeColorTable = StyleBuilderFactory.GetOffice2007ColorTable(style);
            this.BorderColor=_officeColorTable.TextBoxBorderColor;
            //_startPaint = true;
            this.Refresh();
        }

        private Style _style = Style.Office2007Blue;
        public Style Style
        {
            get
            {
                return _style;
            }
            set
            {
                _style = value;
                SetStyle(_style);
            }
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TextBoxW
            // 
            this.ResumeLayout(false);

        }
    }
}
