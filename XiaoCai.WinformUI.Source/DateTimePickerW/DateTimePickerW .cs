using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using XiaoCai.WinformUI.Panels;

namespace XiaoCai.WinformUI
{
    public partial class DateTimePickerW : DateTimePicker, IStyle
    {
        public DateTimePickerW()
        {
            InitializeComponent();
        }

            public DateTimePickerW(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
       // private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, object lParam);
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, int lParam);
        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        //[DllImport("ht32dll.dll")]

        [DllImport("user32")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        const int WM_ERASEBKGND = 0x14;
        const int WM_NC_PAINT = 0x85;
        const int WM_PAINT = 0xF;
        const int WM_PRINTCLIENT = 0x318;

        //边框颜色
        private Pen BorderPen = new Pen(Color.DimGray, 2);

        /// <summary>
        /// 定义背景色私有变量
        /// </summary>
        private Color _backColor = Color.Transparent;
        /// <summary>
        /// 定义背景色属性
        /// </summary>
        public override Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
            }
        }
 
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            IntPtr hDC = IntPtr.Zero;
            Graphics gdc = null;
            switch (m.Msg)
            {
                //画背景色
                case WM_ERASEBKGND:
                    gdc = Graphics.FromHdc(m.WParam);
                    gdc.FillRectangle(new SolidBrush(_backColor), new Rectangle(0, 0, this.Width, this.Height));
                    gdc.Dispose();
                    break;

                case WM_NC_PAINT:
                    hDC = GetWindowDC(m.HWnd);
                    gdc = Graphics.FromHdc(hDC);
                    SendMessage(this.Handle, WM_ERASEBKGND, hDC, 0);
                    SendPrintClientMsg();
                    SendMessage(this.Handle, WM_PAINT, IntPtr.Zero, 0);
                    m.Result = (IntPtr)1;
                    ReleaseDC(m.HWnd, hDC);
                    gdc.Dispose();
                    break;

                //画边框
                case WM_PAINT:
                    base.WndProc(ref m);
         
                    hDC = GetWindowDC(m.HWnd);
                    gdc = Graphics.FromHdc(hDC);
                    OverrideControlBorder(gdc);
                    ReleaseDC(m.HWnd, hDC);
                    gdc.Dispose();
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        private void SendPrintClientMsg()
        {
            // We send this message for the control to redraw the client area
            Graphics gClient = this.CreateGraphics();
            IntPtr ptrClientDC = gClient.GetHdc();
            SendMessage(this.Handle, WM_PRINTCLIENT, ptrClientDC, 0);
            gClient.ReleaseHdc(ptrClientDC);
            gClient.Dispose();
        }

        private void OverrideControlBorder(Graphics g)
        {
            g.DrawRectangle(BorderPen, new Rectangle(0, 0, this.Width, this.Height));
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
        private OfficeColorTable _officeColorTable;
        public void SetStyle(Style style)
        {
            _officeColorTable = StyleBuilderFactory.GetOffice2007ColorTable(style);
            BorderPen = new Pen(_officeColorTable.DateTimePickerBorder, 2);
            this.Refresh();
        }
    }
}
