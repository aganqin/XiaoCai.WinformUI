using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Collections;
using XiaoCai.WinformUI.Panels;
using XiaoCai.WinformUI.Properties;

namespace XiaoCai.WinformUI
{
    public partial class TabControlW : TabControl, IStyle
    {
        #region Fields

        private UpDownButtonNativeWindow _upDownButtonNativeWindow;
        private Color _baseColor = Color.FromArgb(166, 222, 255);
        private Color _backColor = Color.FromArgb(234, 247, 254);
        private Color _borderColor = Color.FromArgb(101, 147, 207);
        private Color _arrowColor = Color.FromArgb(0, 79, 125);
        private Color _pageForeColor = Color.FromArgb(255, 255, 51);
        private const string UpDownButtonClassName = "msctls_updown32";
        private bool _isShowClose;
        private const int Radius = 8;
        private Rectangle myTabRect;
        private static readonly object EventPaintUpDownButton = new object();

        private OfficeColorTable _officeColorTable;

        #endregion



        #region Constructors
        const int CloseSize = 12;
        public TabControlW()
            : base()
        {
            SetStyles();
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            #region
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.Padding = new Point(CloseSize - 2, CloseSize - 5);
            this.MouseDown += OnMouseDown;
            #endregion
            //DefaultBaseColor = Color.FromArgb(175, 210, 255);
            _officeColorTable = StyleBuilderFactory.GetOffice2007ColorTable(_style);
            this.BackColor = _officeColorTable.TabControlBackColor;
            this.BorderColor = _officeColorTable.TabControlBorderColor;
            this._pageForeColor = _officeColorTable.TabControlPageTextColor;
            this.DrawPageColor();
            this.Refresh();
        }

        #endregion

        #region
        public void DrawRoundRectangle(Graphics g, Pen pen, Rectangle rect, int cornerRadius)
        {
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                g.DrawPath(pen, path);
            }
        }
        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }
        public void FillRoundRectangle(Graphics g, Brush brush, Rectangle rect, int cornerRadius)
        {
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                g.FillPath(brush, path);
            }
        }

        private bool isClose;
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X, y = e.Y;
                isClose = x > myTabRect.X && x < myTabRect.Right
                               && y > myTabRect.Y && y < myTabRect.Bottom;

                if (isClose)
                {
                    this.TabPages.Remove(this.SelectedTab);
                    isClose = false;
                }
            }
            else if(e.Button==MouseButtons.Right)
            {
                if (IsShowClose)
                {
                    TabPage page = this.SelectedTab;
                    Point point = new Point(MousePosition.X, MousePosition.Y + 15);
                    page.ContextMenuStrip.Show(point);
                }
            }
            #endregion

        }

  

        #region Events

        public event UpDownButtonPaintEventHandler PaintUpDownButton
        {
            add { base.Events.AddHandler(EventPaintUpDownButton, value); }
            remove { base.Events.RemoveHandler(EventPaintUpDownButton, value); }
        }

        #endregion

        #region Properties
        [DefaultValue(typeof(Color), "175, 210, 255")]
        public Color DefaultBaseColor { get; set; }

        [DefaultValue(typeof(Color), "166, 222, 255")]
        public Color BaseColor
        {
            get { return _baseColor; }
            set
            {
                _baseColor = value;
                base.Invalidate(true);
            }
        }


        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(typeof(Color), "234, 247, 254")]
        public override Color BackColor
        {
            get { return _backColor; }
            set
            {
                _backColor = value;
                base.Invalidate(true);
            }
        }

        [DefaultValue(typeof(Color), "101, 147, 207")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                base.Invalidate(true);
            }
        }
        public bool IsShowClose
        {
            get { return _isShowClose; }
            set
            {
                _isShowClose = value;
                base.Invalidate(true);
            }
        }

        [DefaultValue(typeof(Color), "0, 95, 152")]
        public Color ArrowColor
        {
            get { return _arrowColor; }
            set
            {
                _arrowColor = value;
                base.Invalidate(true);
            }
        }

        internal IntPtr UpDownButtonHandle
        {
            get { return FindUpDownButton(); }
        }

        #endregion

        #region Protected Methods

        protected virtual void OnPaintUpDownButton(
            UpDownButtonPaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.ClipRectangle;

            Color upButtonBaseColor = _baseColor;
            Color upButtonBorderColor = _borderColor;
            Color upButtonArrowColor = _arrowColor;

            Color downButtonBaseColor = _baseColor;
            Color downButtonBorderColor = _borderColor;
            Color downButtonArrowColor = _arrowColor;

            Rectangle upButtonRect = rect;
            upButtonRect.X += 4;
            upButtonRect.Y += 4;
            upButtonRect.Width = rect.Width / 2 - 8;
            upButtonRect.Height -= 8;

            Rectangle downButtonRect = rect;
            downButtonRect.X = upButtonRect.Right + 2;
            downButtonRect.Y += 4;
            downButtonRect.Width = rect.Width / 2 - 8;
            downButtonRect.Height -= 8;

            if (Enabled)
            {
                if (e.MouseOver)
                {
                    if (e.MousePress)
                    {
                        if (e.MouseInUpButton)
                        {
                            upButtonBaseColor = GetColor(_baseColor, 0, -35, -24, -9);
                        }
                        else
                        {
                            downButtonBaseColor = GetColor(_baseColor, 0, -35, -24, -9);
                        }
                    }
                    else
                    {
                        if (e.MouseInUpButton)
                        {
                            upButtonBaseColor = GetColor(_baseColor, 0, 35, 24, 9);
                        }
                        else
                        {
                            downButtonBaseColor = GetColor(_baseColor, 0, 35, 24, 9);
                        }
                    }
                }
            }
            else
            {
                upButtonBaseColor = SystemColors.Control;
                upButtonBorderColor = SystemColors.ControlDark;
                upButtonArrowColor = SystemColors.ControlDark;

                downButtonBaseColor = SystemColors.Control;
                downButtonBorderColor = SystemColors.ControlDark;
                downButtonArrowColor = SystemColors.ControlDark;
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color backColor = Enabled ? _backColor : SystemColors.Control;

            using (SolidBrush brush = new SolidBrush(_backColor))
            {
                rect.Inflate(1, 1);
                g.FillRectangle(brush, rect);
            }

            RenderButton(
                g,
                upButtonRect,
                upButtonBaseColor,
                upButtonBorderColor,
                upButtonArrowColor,
                ArrowDirection.Left);
            RenderButton(
                g,
                downButtonRect,
                downButtonBaseColor,
                downButtonBorderColor,
                downButtonArrowColor,
                ArrowDirection.Right);

            UpDownButtonPaintEventHandler handler =
                base.Events[EventPaintUpDownButton] as UpDownButtonPaintEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        private readonly Image _tabClose = Resources.tabclose;
       private Dictionary<string,TabPage> tabPages=new Dictionary<string, TabPage>();
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            foreach (TabPage page in this.TabPages)
            {
                if (!tabPages.ContainsKey(page.TabIndex.ToString()))
                {
                    tabPages.Add(page.TabIndex.ToString(),page);
                    if (IsShowClose)
                    {
                        ContextMenuStrip menuStrip = new ContextMenuStrip();
                        menuStrip.Items.Add("关闭");
                        menuStrip.Items.Add("除此之外全部关闭");
                        menuStrip.Items.Add("Close All");
                        page.ContextMenuStrip = menuStrip;
                        menuStrip.ItemClicked += OnMenuStripItemClicked;
                    }
                    page.MouseHover += new EventHandler(OnPageMouseHover);
                }
            }
           
            bool isClose=false;
            if (IsShowClose)
            {
                int x = e.X, y = e.Y;
                isClose = x > myTabRect.X && x < myTabRect.Right
                          && y > myTabRect.Y && y < myTabRect.Bottom;

                if (isClose)
                {

                    if (this.SelectedIndex >= 0)
                    {

                        Graphics g = this.CreateGraphics(); //((TabControl)sender).CreateGraphics();
                        g.DrawImage(this._tabClose, myTabRect.X, myTabRect.Y, 12, 12);

                    }

                }
            }
            //if (!isClose)
            //{
            //    this.Refresh();
            //}        
        }

        void OnMenuStripItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
             ContextMenuStrip strip = (ContextMenuStrip) sender;
            for (int i = 0; i < strip.Items.Count; i++)
            {
                if (strip.Items[i].Selected)
                {
                    switch (strip.Items[i].Text)
                    {
                        case "关闭":
                            this.TabPages.Remove(this.SelectedTab);
                            break;
                        case "除此之外全部关闭":
                            foreach (TabPage tabPage in this.TabPages)
                            {
                                if (this.SelectedTab != tabPage)
                                {
                                    this.TabPages.Remove(tabPage);
                                }
                               
                            } 
                                break;
                        case "Close All":
                                foreach (TabPage tabPage in this.TabPages)
                                {
                                    this.TabPages.Remove(tabPage);
                                } 
                            
                            break;
                    }
                }
            }
        }

        void OnPageMouseHover(object sender, EventArgs e)
        {
            base.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            base.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawTabContrl(e.Graphics);
            if (IsShowClose)
            {
                if (this.SelectedIndex >= 0)
                {
                    Graphics g = e.Graphics;
                    const int closeSize = 11;
                    using (Pen p = new Pen(Color.Transparent))
                    {
                        myTabRect = this.GetTabRect(this.SelectedIndex);
                        myTabRect.Offset(myTabRect.Width - 17, 3);
                        myTabRect.Width = closeSize;
                        myTabRect.Height = closeSize;
                        DrawRoundRectangle(g, p, myTabRect, 3);
                        FillRoundRectangle(g, new SolidBrush(Color.Transparent), myTabRect, 2);
                    }
                    using (Pen objpen = new Pen(Color.Black))
                    {
                        Point p1, p2, p3, p4;
                        //"/"线
                        p1 = new Point(myTabRect.X + 3, myTabRect.Y + 3);
                        p2 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + myTabRect.Height - 3);
                        g.DrawLine(objpen, p1, p2);

                        //"\"线
                        p3 = new Point(myTabRect.X + 3, myTabRect.Y + myTabRect.Height - 3);
                        p4 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + 3);
                        g.DrawLine(objpen, p3, p4);
                    }
                } 
            }
           
 
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (UpDownButtonHandle != IntPtr.Zero)
            {
                if (_upDownButtonNativeWindow == null)
                {
                    _upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
                }
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (UpDownButtonHandle != IntPtr.Zero)
            {
                if (_upDownButtonNativeWindow == null)
                {
                    _upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
                }
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            if (_upDownButtonNativeWindow != null)
            {
                _upDownButtonNativeWindow.Dispose();
                _upDownButtonNativeWindow = null;
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            if (UpDownButtonHandle != IntPtr.Zero)
            {
                if (_upDownButtonNativeWindow == null)
                {
                    _upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (UpDownButtonHandle != IntPtr.Zero)
            {
                if (_upDownButtonNativeWindow == null)
                {
                    _upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
                }
            }
            else
            {
                this.Refresh();
            }
        }

        #endregion

        #region Help Methods

        private IntPtr FindUpDownButton()
        {
            return WinMethod.FindWindowEx(
                base.Handle,
                IntPtr.Zero,
                UpDownButtonClassName,
                null);
        }

        private void SetStyles()
        {
            base.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
            base.UpdateStyles();
        }

        private void DrawTabContrl(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            if (showTabs)
            {
                DrawDrawBackgroundAndHeader(g);
                DrawTabPages(g);
                DrawBorder(g);

            }
        }

        private void DrawDrawBackgroundAndHeader(Graphics g)
        {
            int x = 0;
            int y = 0;
            int width = 0;
            int height = 0;

            switch (Alignment)
            {
                case TabAlignment.Top:
                    x = 0;
                    y = 0;
                    width = ClientRectangle.Width;
                    height = ClientRectangle.Height - DisplayRectangle.Height;
                    break;
                case TabAlignment.Bottom:
                    x = 0;
                    y = DisplayRectangle.Height;
                    width = ClientRectangle.Width;
                    height = ClientRectangle.Height - DisplayRectangle.Height;
                    break;
                case TabAlignment.Left:
                    x = 0;
                    y = 0;
                    width = ClientRectangle.Width - DisplayRectangle.Width;
                    height = ClientRectangle.Height;
                    break;
                case TabAlignment.Right:
                    x = DisplayRectangle.Width;
                    y = 0;
                    width = ClientRectangle.Width - DisplayRectangle.Width;
                    height = ClientRectangle.Height;
                    break;
            }

            Rectangle headerRect = new Rectangle(x, y, width, height);
            Color backColor = Enabled ? _backColor : SystemColors.ControlDarkDark;
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                g.FillRectangle(brush, ClientRectangle);
                g.FillRectangle(brush, headerRect);
            }
        }

        private void DrawTabPages(Graphics g)
        {
            Rectangle tabRect;
            Point cusorPoint = PointToClient(MousePosition);
            bool hover;
            bool selected;
            bool hasSetClip = false;
            bool alignHorizontal =
                (Alignment == TabAlignment.Top ||
                Alignment == TabAlignment.Bottom);
            LinearGradientMode mode = alignHorizontal ?
                LinearGradientMode.Vertical : LinearGradientMode.Horizontal;

            if (alignHorizontal)
            {
                IntPtr upDownButtonHandle = UpDownButtonHandle;
                bool hasUpDown = upDownButtonHandle != IntPtr.Zero;
                if (hasUpDown)
                {
                    if (WinMethod.IsWindowVisible(upDownButtonHandle))
                    {
                        RECT upDownButtonRect;
                        WinMethod.GetWindowRect(upDownButtonHandle, out upDownButtonRect);
                        Rectangle upDownRect = Rectangle.FromLTRB(
                            upDownButtonRect.Left,
                            upDownButtonRect.Top,
                            upDownButtonRect.Right,
                            upDownButtonRect.Bottom);
                        upDownRect = RectangleToClient(upDownRect);

                        switch (Alignment)
                        {
                            case TabAlignment.Top:
                                upDownRect.Y = 0;
                                break;
                            case TabAlignment.Bottom:
                                upDownRect.Y =
                                    ClientRectangle.Height - DisplayRectangle.Height;
                                break;
                        }
                        upDownRect.Height = ClientRectangle.Height;
                        g.SetClip(upDownRect, CombineMode.Exclude);
                        hasSetClip = true;
                    }
                }
            }

            for (int index = 0; index < base.TabCount; index++)
            {
                TabPage page = TabPages[index];

                tabRect = GetTabRect(index);
                tabRect.X -= 2;
                tabRect.Y -= 2;
                hover = tabRect.Contains(cusorPoint);
                selected = SelectedIndex == index;

                Color baseColor = _baseColor;
                Color borderColor = _borderColor;
                if (_officeColorTable == null)
                {
                    _officeColorTable = StyleBuilderFactory.GetOffice2007ColorTable(_style);
                }
                //Color[] colors = new[] { Color.Black, Color.BlanchedAlmond, Color.Khaki, Color.Brown, Color.Brown };
                Color[] colors = new[]
                    {
                    _officeColorTable.TabControlPageNormalBackColor1,
                    _officeColorTable.TabControlPageNormalBackColor2,
                    _officeColorTable.TabControlPageNormalBackColor3, 
                    _officeColorTable.TabControlPageNormalBackColor4,
                    _officeColorTable.TabControlPageNormalBackColor5
                    };
                if (selected)
                {
                    colors = new[]
                     {
                         _officeColorTable.TabControlPageSelectColor1, 
                          _officeColorTable.TabControlPageSelectColor2,
                        _officeColorTable.TabControlPageSelectColor3,
                        _officeColorTable.TabControlPageSelectColor4, 
                        _officeColorTable.TabControlPageSelectColor5
                    };
                }
                else if (hover)
                {
                    colors = new[]
                     {
                    _officeColorTable.TabControlPageHoverColor1, 
                     _officeColorTable.TabControlPageHoverColor2,
                    _officeColorTable.TabControlPageHoverColor3,
                    _officeColorTable.TabControlPageHoverColor4, 
                    _officeColorTable.TabControlPageHoverColor5
                    };
                }
                else//自定义
                {
                    colors = new[]
                    {
                    _officeColorTable.TabControlPageNormalBackColor1,
                    _officeColorTable.TabControlPageNormalBackColor2,
                    _officeColorTable.TabControlPageNormalBackColor3, 
                    _officeColorTable.TabControlPageNormalBackColor4,
                    _officeColorTable.TabControlPageNormalBackColor5
                    };

                }

                RenderTabBackgroundInternal(
                    g,
                    tabRect,
                    baseColor,
                    borderColor,
                    .3F,
                    mode, colors);

                bool hasImage = DrawTabImage(g, page, tabRect);

                DrawtabText(g, page, tabRect, hasImage);
              
            }
            if (hasSetClip)
            {
                g.ResetClip();
            }
            
        }

        private void DrawtabText(
            Graphics g, TabPage page, Rectangle tabRect, bool hasImage)
        {
            Rectangle textRect = tabRect;
            RectangleF newTextRect;
            StringFormat sf;

            switch (Alignment)
            {
                case TabAlignment.Top:
                case TabAlignment.Bottom:
                    if (hasImage)
                    {
                        textRect.X = tabRect.X + Radius / 2 + tabRect.Height - 2;
                        textRect.Width = tabRect.Width - Radius - tabRect.Height;
                    }

                    TextRenderer.DrawText(
                        g,
                        page.Text,
                        page.Font,
                        textRect,
                        _pageForeColor);
                    break;
                case TabAlignment.Left:
                    if (hasImage)
                    {
                        textRect.Height = tabRect.Height - tabRect.Width + 2;
                    }
                    g.TranslateTransform(textRect.X, textRect.Bottom);
                    g.RotateTransform(270F);
                    sf = new StringFormat(StringFormatFlags.NoWrap);
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Trimming = StringTrimming.Character;
                    newTextRect = textRect;
                    newTextRect.X = 0;
                    newTextRect.Y = 0;
                    newTextRect.Width = textRect.Height;
                    newTextRect.Height = textRect.Width;
                    using (Brush brush = new SolidBrush(_pageForeColor))
                    {
                        g.DrawString(
                            page.Text,
                            page.Font,
                            brush,
                            newTextRect,
                            sf);
                    }
                    g.ResetTransform();
                    break;
                case TabAlignment.Right:
                    if (hasImage)
                    {
                        textRect.Y = tabRect.Y + Radius / 2 + tabRect.Width - 2;
                        textRect.Height = tabRect.Height - Radius - tabRect.Width;
                    }
                    g.TranslateTransform(textRect.Right, textRect.Y);
                    g.RotateTransform(90F);
                    sf = new StringFormat(StringFormatFlags.NoWrap);
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Trimming = StringTrimming.Character;
                    newTextRect = textRect;
                    newTextRect.X = 0;
                    newTextRect.Y = 0;
                    newTextRect.Width = textRect.Height;
                    newTextRect.Height = textRect.Width;
                    using (Brush brush = new SolidBrush(_pageForeColor))
                    {
                        g.DrawString(
                            page.Text,
                            page.Font,
                            brush,
                            newTextRect,
                            sf);
                    }
                    g.ResetTransform();
                    break;
            }
        }

        private void DrawBorder(Graphics g)
        {
            if (SelectedIndex != -1)
            {
                Rectangle tabRect = GetTabRect(SelectedIndex);
                Rectangle clipRect = ClientRectangle;
                Point[] points = new Point[6];

                IntPtr upDownButtonHandle = UpDownButtonHandle;
                bool hasUpDown = upDownButtonHandle != IntPtr.Zero;
                if (hasUpDown)
                {
                    if (WinMethod.IsWindowVisible(upDownButtonHandle))
                    {
                        RECT upDownButtonRect;
                        WinMethod.GetWindowRect(upDownButtonHandle, out upDownButtonRect);
                        Rectangle upDownRect = Rectangle.FromLTRB(
                            upDownButtonRect.Left,
                            upDownButtonRect.Top,
                            upDownButtonRect.Right,
                            upDownButtonRect.Bottom);
                        upDownRect = RectangleToClient(upDownRect);

                        tabRect.X = tabRect.X > upDownRect.X ?
                            upDownRect.X : tabRect.X;
                        tabRect.Width = tabRect.Right > upDownRect.X ?
                            upDownRect.X - tabRect.X : tabRect.Width;
                    }
                }

                switch (Alignment)
                {
                    case TabAlignment.Top:
                        points[0] = new Point(
                            tabRect.X,
                            tabRect.Bottom);
                        points[1] = new Point(
                            clipRect.X,
                            tabRect.Bottom);
                        points[2] = new Point(
                            clipRect.X,
                            clipRect.Bottom - 1);
                        points[3] = new Point(
                            clipRect.Right - 1,
                            clipRect.Bottom - 1);
                        points[4] = new Point(
                            clipRect.Right - 1,
                            tabRect.Bottom);
                        points[5] = new Point(
                            tabRect.Right,
                            tabRect.Bottom);
                        break;
                    case TabAlignment.Bottom:
                        points[0] = new Point(
                            tabRect.X,
                            tabRect.Y);
                        points[1] = new Point(
                            clipRect.X,
                            tabRect.Y);
                        points[2] = new Point(
                            clipRect.X,
                            clipRect.Y);
                        points[3] = new Point(
                            clipRect.Right - 1,
                            clipRect.Y);
                        points[4] = new Point(
                            clipRect.Right - 1,
                            tabRect.Y);
                        points[5] = new Point(
                            tabRect.Right,
                            tabRect.Y);
                        break;
                    case TabAlignment.Left:
                        points[0] = new Point(
                            tabRect.Right,
                            tabRect.Y);
                        points[1] = new Point(
                            tabRect.Right,
                            clipRect.Y);
                        points[2] = new Point(
                            clipRect.Right - 1,
                            clipRect.Y);
                        points[3] = new Point(
                            clipRect.Right - 1,
                            clipRect.Bottom - 1);
                        points[4] = new Point(
                            tabRect.Right,
                            clipRect.Bottom - 1);
                        points[5] = new Point(
                            tabRect.Right,
                            tabRect.Bottom);
                        break;
                    case TabAlignment.Right:
                        points[0] = new Point(
                            tabRect.X,
                            tabRect.Y);
                        points[1] = new Point(
                            tabRect.X,
                            clipRect.Y);
                        points[2] = new Point(
                            clipRect.X,
                            clipRect.Y);
                        points[3] = new Point(
                            clipRect.X,
                            clipRect.Bottom - 1);
                        points[4] = new Point(
                            tabRect.X,
                            clipRect.Bottom - 1);
                        points[5] = new Point(
                            tabRect.X,
                            tabRect.Bottom);
                        break;
                }
                using (Pen pen = new Pen(_borderColor))
                {
                    g.DrawLines(pen, points);
                }
            }
        }

        private void DrawPageColor()
        {

            if (_officeColorTable == null)
            {
                _officeColorTable = StyleBuilderFactory.GetOffice2007ColorTable(_style); 
            }
           
            for (int index = 0; index < base.TabCount; index++)
            {
                TabPage page = TabPages[index];
                page.BackColor = _officeColorTable.TabControlPageBackColor;
                this.Refresh();

            }
        }

        internal void RenderArrowInternal(
             Graphics g,
             Rectangle dropDownRect,
             ArrowDirection direction,
             Brush brush)
        {
            Point point = new Point(
                dropDownRect.Left + (dropDownRect.Width / 2),
                dropDownRect.Top + (dropDownRect.Height / 2));
            Point[] points = null;
            switch (direction)
            {
                case ArrowDirection.Left:
                    points = new Point[] { 
                        new Point(point.X + 1, point.Y - 4), 
                        new Point(point.X + 1, point.Y + 4), 
                        new Point(point.X - 2, point.Y) };
                    break;

                case ArrowDirection.Up:
                    points = new Point[] { 
                        new Point(point.X - 3, point.Y + 1), 
                        new Point(point.X + 3, point.Y + 1), 
                        new Point(point.X, point.Y - 1) };
                    break;

                case ArrowDirection.Right:
                    points = new Point[] {
                        new Point(point.X - 1, point.Y - 4), 
                        new Point(point.X - 1, point.Y + 4), 
                        new Point(point.X + 2, point.Y) };
                    break;

                default:
                    points = new Point[] {
                        new Point(point.X - 3, point.Y - 1), 
                        new Point(point.X + 3, point.Y - 1), 
                        new Point(point.X, point.Y + 1) };
                    break;
            }
            g.FillPolygon(brush, points);
        }

        internal void RenderButton(
            Graphics g,
            Rectangle rect,
            Color baseColor,
            Color borderColor,
            Color arrowColor,
            ArrowDirection direction)
        {
            RenderBackgroundInternal(
                g,
                rect,
                baseColor,
                borderColor,
                0.45f,
                true,
                LinearGradientMode.Vertical);
            using (SolidBrush brush = new SolidBrush(arrowColor))
            {
                RenderArrowInternal(
                    g,
                    rect,
                    direction,
                    brush);
            }
        }

        internal void RenderBackgroundInternal(
          Graphics g,
          Rectangle rect,
          Color baseColor,
          Color borderColor,
          float basePosition,
          bool drawBorder,
          LinearGradientMode mode)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
               rect, Color.Transparent, Color.Transparent, mode))
            {
                Color[] colors = new Color[4];
                colors[0] = GetColor(baseColor, 0, 35, 24, 9);
                colors[1] = GetColor(baseColor, 0, 13, 8, 3);
                colors[2] = baseColor;
                colors[3] = GetColor(baseColor, 0, 68, 69, 54);

                ColorBlend blend = new ColorBlend();
                blend.Positions =
                    new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f };
                blend.Colors = colors;
                brush.InterpolationColors = blend;
                g.FillRectangle(brush, rect);
            }
            if (baseColor.A > 80)
            {
                Rectangle rectTop = rect;
                if (mode == LinearGradientMode.Vertical)
                {
                    rectTop.Height = (int)(rectTop.Height * basePosition);
                }
                else
                {
                    rectTop.Width = (int)(rect.Width * basePosition);
                }
                using (SolidBrush brushAlpha =
                    new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
                {
                    g.FillRectangle(brushAlpha, rectTop);
                }
            }

            if (drawBorder)
            {
                using (Pen pen = new Pen(borderColor))
                {
                    g.DrawRectangle(pen, rect);
                }
            }
        }

        internal void RenderTabBackgroundInternal(
          Graphics g,
          Rectangle rect,
          Color baseColor,
          Color borderColor,
          float basePosition,
          LinearGradientMode mode, Color[] colors0)
        {
            using (GraphicsPath path = CreateTabPath(rect))
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                   rect, Color.Transparent, Color.Transparent, mode))
                {
                    Color[] colors = new Color[4];
                    colors[0] = colors0[0];
                    colors[1] = colors0[1];
                    colors[2] = colors0[2];
                    colors[3] = colors0[3];

                    ColorBlend blend = new ColorBlend();
                    blend.Positions = new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f };
                    blend.Colors = colors;
                    brush.InterpolationColors = blend;
                    g.FillPath(brush, path);
                }

                if (baseColor.A > 80)
                {
                    Rectangle rectTop = rect;
                    if (mode == LinearGradientMode.Vertical)
                    {
                        rectTop.Height = (int)(rectTop.Height * basePosition);
                    }
                    else
                    {
                        rectTop.Width = (int)(rect.Width * basePosition);
                    }
                    using (SolidBrush brushAlpha =
                        new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
                    {
                        g.FillRectangle(brushAlpha, rectTop);
                    }
                }

                rect.Inflate(-1, -1);
                using (GraphicsPath path1 = CreateTabPath(rect))
                {
                    using (Pen pen = new Pen(Color.FromArgb(255, 255, 255)))
                    {
                        if (Multiline)
                        {
                            g.DrawPath(pen, path1);
                        }
                        else
                        {
                            g.DrawLines(pen, path1.PathPoints);
                        }
                    }
                }

                using (Pen pen = new Pen(borderColor))
                {
                    if (Multiline)
                    {
                        g.DrawPath(pen, path);
                    }
                    {
                        g.DrawLines(pen, path.PathPoints);
                    }
                }
            }
        }

        private bool DrawTabImage(Graphics g, TabPage page, Rectangle rect)
        {
            bool hasImage = false;
            if (ImageList != null)
            {
                Image image = null;
                if (page.ImageIndex != -1)
                {
                    image = ImageList.Images[page.ImageIndex];
                }
                else if (page.ImageKey != null)
                {
                    image = ImageList.Images[page.ImageKey];
                }

                if (image != null)
                {
                    hasImage = true;
                    Rectangle destRect = Rectangle.Empty;
                    Rectangle srcRect = new Rectangle(Point.Empty, image.Size);
                    switch (Alignment)
                    {
                        case TabAlignment.Top:
                        case TabAlignment.Bottom:
                            destRect = new Rectangle(
                                 rect.X + Radius / 2 + 2,
                                 rect.Y + 2,
                                 rect.Height - 4,
                                 rect.Height - 4);
                            break;
                        case TabAlignment.Left:
                            destRect = new Rectangle(
                                rect.X + 2,
                                rect.Bottom - (rect.Width - 4) - Radius / 2 - 2,
                                rect.Width - 4,
                                rect.Width - 4);
                            break;
                        case TabAlignment.Right:
                            destRect = new Rectangle(
                                rect.X + 2,
                                rect.Y + Radius / 2 + 2,
                                rect.Width - 4,
                                rect.Width - 4);
                            break;
                    }

                    g.DrawImage(
                        image,
                        destRect,
                        srcRect,
                        GraphicsUnit.Pixel);
                }
            }
            return hasImage;
        }

        private GraphicsPath CreateTabPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();
            switch (Alignment)
            {
                case TabAlignment.Top:
                    rect.X++;
                    rect.Width -= 2;
                    path.AddLine(
                        rect.X,
                        rect.Bottom,
                        rect.X,
                        rect.Y + Radius / 2);
                    path.AddArc(
                        rect.X,
                        rect.Y,
                        Radius,
                        Radius,
                        180F,
                        90F);
                    path.AddArc(
                        rect.Right - Radius,
                        rect.Y,
                        Radius,
                        Radius,
                        270F,
                        90F);
                    path.AddLine(
                        rect.Right,
                        rect.Y + Radius / 2,
                        rect.Right,
                        rect.Bottom);
                    break;
                case TabAlignment.Bottom:
                    rect.X++;
                    rect.Width -= 2;
                    path.AddLine(
                        rect.X,
                        rect.Y,
                        rect.X,
                        rect.Bottom - Radius / 2);
                    path.AddArc(
                        rect.X,
                        rect.Bottom - Radius,
                        Radius,
                        Radius,
                        180,
                        -90);
                    path.AddArc(
                        rect.Right - Radius,
                        rect.Bottom - Radius,
                        Radius,
                        Radius,
                        90,
                        -90);
                    path.AddLine(
                        rect.Right,
                        rect.Bottom - Radius / 2,
                        rect.Right,
                        rect.Y);

                    break;
                case TabAlignment.Left:
                    rect.Y++;
                    rect.Height -= 2;
                    path.AddLine(
                        rect.Right,
                        rect.Y,
                        rect.X + Radius / 2,
                        rect.Y);
                    path.AddArc(
                        rect.X,
                        rect.Y,
                        Radius,
                        Radius,
                        270F,
                        -90F);
                    path.AddArc(
                        rect.X,
                        rect.Bottom - Radius,
                        Radius,
                        Radius,
                        180F,
                        -90F);
                    path.AddLine(
                        rect.X + Radius / 2,
                        rect.Bottom,
                        rect.Right,
                        rect.Bottom);
                    break;
                case TabAlignment.Right:
                    rect.Y++;
                    rect.Height -= 2;
                    path.AddLine(
                        rect.X,
                        rect.Y,
                        rect.Right - Radius / 2,
                        rect.Y);
                    path.AddArc(
                        rect.Right - Radius,
                        rect.Y,
                        Radius,
                        Radius,
                        270F,
                        90F);
                    path.AddArc(
                        rect.Right - Radius,
                        rect.Bottom - Radius,
                        Radius,
                        Radius,
                        0F,
                        90F);
                    path.AddLine(
                        rect.Right - Radius / 2,
                        rect.Bottom,
                        rect.X,
                        rect.Bottom);
                    break;
            }
            path.CloseFigure();
            return path;
        }

        private Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;

            if (a + a0 > 255) { a = 255; } else { a = Math.Max(a + a0, 0); }
            if (r + r0 > 255) { r = 255; } else { r = Math.Max(r + r0, 0); }
            if (g + g0 > 255) { g = 255; } else { g = Math.Max(g + g0, 0); }
            if (b + b0 > 255) { b = 255; } else { b = Math.Max(b + b0, 0); }

            return Color.FromArgb(a, r, g, b);
        }

        #endregion

        #region UpDownButtonNativeWindow

        private class UpDownButtonNativeWindow : NativeWindow, IDisposable
        {
            private TabControlW _owner;
            private bool _bPainting;

            public UpDownButtonNativeWindow(TabControlW owner)
                : base()
            {
                _owner = owner;
                base.AssignHandle(owner.UpDownButtonHandle);
            }

            private bool LeftKeyPressed()
            {
                if (SystemInformation.MouseButtonsSwapped)
                {
                    return (WinMethod.GetKeyState(KnownParam.VK_RBUTTON) < 0);
                }
                else
                {
                    return (WinMethod.GetKeyState(KnownParam.VK_LBUTTON) < 0);
                }
            }

            private void DrawUpDownButton()
            {
                bool mouseOver = false;
                bool mousePress = LeftKeyPressed();
                bool mouseInUpButton = false;

                RECT rect = new RECT();

                WinMethod.GetClientRect(base.Handle, out rect);

                Rectangle clipRect = Rectangle.FromLTRB(
                    rect.Top, rect.Left, rect.Right, rect.Bottom);

                Point cursorPoint = new Point();
                WinMethod.GetCursorPos(ref cursorPoint);
                WinMethod.GetWindowRect(base.Handle, out rect);

                mouseOver = WinMethod.PtInRect(ref rect, cursorPoint);

                cursorPoint.X -= rect.Left;
                cursorPoint.Y -= rect.Top;

                mouseInUpButton = cursorPoint.X < clipRect.Width / 2;

                using (Graphics g = Graphics.FromHwnd(base.Handle))
                {
                    UpDownButtonPaintEventArgs e =
                        new UpDownButtonPaintEventArgs(
                        g,
                        clipRect,
                        mouseOver,
                        mousePress,
                        mouseInUpButton);
                    _owner.OnPaintUpDownButton(e);
                }
            }

            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case WinMsgs.WM_PAINT:
                        if (!_bPainting)
                        {
                            PAINTSTRUCT ps =
                                new PAINTSTRUCT();
                            _bPainting = true;
                            WinMethod.BeginPaint(m.HWnd, ref ps);
                            DrawUpDownButton();
                            WinMethod.EndPaint(m.HWnd, ref ps);
                            _bPainting = false;
                            m.Result = KnownParam.TRUE;
                        }
                        else
                        {
                            base.WndProc(ref m);
                        }
                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
            }

            #region IDisposable 成员

            public void Dispose()
            {
                _owner = null;
                base.ReleaseHandle();
            }

            #endregion
        }

        #endregion

        #region IStyle 成员
        public void SetStyle(Style style)
        {
            _officeColorTable = StyleBuilderFactory.GetOffice2007ColorTable(style);
            this.BackColor = _officeColorTable.TabControlBackColor;
            this.BorderColor = _officeColorTable.TabControlBorderColor;
            this._pageForeColor = _officeColorTable.TabControlPageTextColor;
            _style = style;
            this.DrawPageColor();
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

        public override Rectangle DisplayRectangle
        {
            get
            {
                if (showTabs)
                {
                    return base.DisplayRectangle;
                }
                else
                {
                    return new Rectangle(0, 0, Width, Height);
                }
            }
        }
        private bool showTabs = true;

        public bool ShowTabs
        {
            get { return showTabs; }
            set
            {
                showTabs = value;
                RecreateHandle();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

    }
}
