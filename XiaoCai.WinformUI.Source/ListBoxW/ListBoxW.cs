using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using XiaoCai.WinformUI.Panels;


namespace XiaoCai.WinformUI.ListBoxW
{
    public partial class ListBoxW : ListBox, IStyle
    {
        #region 私有变量
        private Color _rowBackColor1 = Color.White;//颜色1
        private Color _rowBackColor2 = Color.White;//颜色2
        private Color _selectedColor;
        private readonly BorderDrawer _borderDrawer = new BorderDrawer();//边框绘制器
        private OfficeColorTable _officeColorTable;
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public ListBoxW()
            : base()
        {
            this.DoubleBuffered = true;
            base.DrawMode = DrawMode.OwnerDrawFixed;
            base.HorizontalScrollbar = true;
            base.ItemHeight = 17;
        }

        #region properties

        [DefaultValue(typeof(Color), "White")]
        public Color RowBackColor1
        {
            get { return _rowBackColor1; }
            set
            {
                _rowBackColor1 = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "White")]
        public Color RowBackColor2
        {
            get { return _rowBackColor2; }
            set
            {
                _rowBackColor2 = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "255, 218, 114")]
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                base.Invalidate();
            }
        }

        #endregion

        #region method

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (e.Index != -1)
            {
                if ((e.State & DrawItemState.Selected)
                    == DrawItemState.Selected)
                {
                    RenderBackgroundInternal(
                        e.Graphics,
                        e.Bounds,
                        _selectedColor,
                        _selectedColor,
                        Color.FromArgb(200, 255, 255, 255),
                        0.45f,
                        true,
                        LinearGradientMode.Vertical);
                }
                else
                {
                    Color backColor;
                    if (e.Index % 2 == 0)
                    {
                        backColor = _rowBackColor2;
                    }
                    else
                    {
                        backColor = _rowBackColor1;
                    }
                    using (SolidBrush brush = new SolidBrush(backColor))
                    {
                        e.Graphics.FillRectangle(brush, e.Bounds);
                    }
                }
                string text = "";
                if (Items.Count > 0)
                {
                    text = Items[e.Index].ToString();
                }
                //string text = Items[e.Index].ToString();
                TextFormatFlags formatFlags = TextFormatFlags.VerticalCenter;
                if (RightToLeft == RightToLeft.Yes)
                {
                    formatFlags |= TextFormatFlags.RightToLeft;
                }
                else
                {
                    formatFlags |= TextFormatFlags.Left;
                }
                TextRenderer.DrawText(
                    e.Graphics,
                    text,
                    Font,
                    e.Bounds,
                    ForeColor,
                    formatFlags);

                if ((e.State & DrawItemState.Focus) ==
                    DrawItemState.Focus)
                {
                    e.DrawFocusRectangle();
                }

            }
        }

        internal void RenderBackgroundInternal(
          Graphics g,
          Rectangle rect,
          Color baseColor,
          Color borderColor,
          Color innerBorderColor,
          float basePosition,
          bool drawBorder,
          LinearGradientMode mode)
        {
            if (drawBorder)
            {
                rect.Width--;
                rect.Height--;
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(
               rect, Color.Transparent, Color.Transparent, mode))
            {
                Color[] colors = new Color[4];
                colors[0] = GetColor(baseColor, 0, 35, 24, 9);
                colors[1] = GetColor(baseColor, 0, 13, 8, 3);
                colors[2] = baseColor;
                colors[3] = GetColor(baseColor, 0, 68, 69, 54);

                ColorBlend blend = new ColorBlend();
                blend.Positions = new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f };
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

                rect.Inflate(-1, -1);
                using (Pen pen = new Pen(innerBorderColor))
                {
                    g.DrawRectangle(pen, rect);
                }
            }
        }

        private Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;

            if (a + a0 > 255) { a = 255; } else { a = a + a0; }
            if (r + r0 > 255) { r = 255; } else { r = r + r0; }
            if (g + g0 > 255) { g = 255; } else { g = g + g0; }
            if (b + b0 > 255) { b = 255; } else { b = b + b0; }

            return Color.FromArgb(a, r, g, b);
        }

        #endregion

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (SelectedIndex != -1)
            {
                using (Graphics g = base.CreateGraphics())
                    base.HorizontalExtent =
                        (int)g.MeasureString(Items[SelectedIndex].ToString(), Font).Width;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            _borderDrawer.DrawBorder(ref m, BorderColor, base.Width, base.Height);
        }

        /// <summary>
        /// 边框颜色
        /// </summary>
        public Color BorderColor { get; set; }

        #region IStyle 成员
        /// <summary>
        /// 设置控件样式
        /// </summary>
        /// <param name="style"></param>
        public void SetStyle(Style style)
        {
            _officeColorTable = StyleBuilderFactory.GetOffice2007ColorTable(style);
            this.BorderColor = _officeColorTable.ListBoxBorderColor;
            this.SelectedColor = _officeColorTable.ListBoxSelectedColor;
            this.Refresh();
            base.Invalidate(false);
        }

        /// <summary>
        /// 默认样式为Office2007Blue
        /// </summary>
        private Style _style = Style.Office2007Blue;

        /// <summary>
        /// 样式属性
        /// </summary>
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
    }
}
