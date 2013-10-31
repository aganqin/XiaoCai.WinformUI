using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XiaoCai.WinformUI.Panels;

namespace XiaoCai.WinformUI.TreeViewW
{
     [ToolboxItem(true)] 
    public partial class TreeViewW : TreeView,IStyle
    {
        private OfficeColorTable _officeColorTable;
        public TreeViewW()
        {
            InitializeComponent();
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor |
            //  ControlStyles.UserPaint |
            //  ControlStyles.ResizeRedraw |
            //  ControlStyles.DoubleBuffer, true);
            //this.SetStyle(ControlStyles.Opaque, false);

            _officeColorTable = StyleBuilderFactory.GetOffice2007ColorTable(_style);
            this.LineColor = _officeColorTable.TabControlBorderColor;
            this.BackColor = _officeColorTable.TreeViewBackColor;
            base.Invalidate(false);
        }

         public TreeViewW(IContainer container)
        {
            container.Add(this);
            this.DoubleBuffered = true;
            InitializeComponent();
            this.DrawMode = System.Windows.Forms.TreeViewDrawMode.Normal;
            this.DrawNode += new DrawTreeNodeEventHandler(treeView1_DrawNode);
        }

        private Color _selectedColor1 = Color.Khaki;
        private Color _focusedColor1 = Color.FromArgb(255, 208, 134);
        private Color _selectedColor2 = Color.Gold;

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            TreeNode treeNode = e.Node;
            if (treeNode.IsSelected)
            {

                RenderBackgroundInternal(
                e.Graphics,
                new Rectangle(e.Bounds.Location,
                              new Size(this.Width - e.Bounds.X - 10, e.Bounds.Height)),
                _selectedColor1,
                _selectedColor2,
                Color.FromArgb(200, 255, 255, 255),
                0.45f,
                true,
                LinearGradientMode.Vertical);

            }
            else if (e.State==TreeNodeStates.Focused)
            {
                RenderBackgroundInternal(
                e.Graphics,
                e.Bounds,
                _focusedColor1,
                _selectedColor2,
                Color.FromArgb(200, 255, 255, 255),
                0.45f,
                true,
                LinearGradientMode.Vertical);
            }
            //e.Graphics.DrawString(e.Node.Text, this.Font, new SolidBrush(Color.Black), e.Bounds);
            e.Graphics.DrawString(e.Node.Text, this.Font, new SolidBrush(Color.Black), e.Bounds);
            //this.Invalidate();


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

        #region IStyle 成员
        /// <summary>
        /// 设置控件样式
        /// </summary>
        /// <param name="style"></param>
        public void SetStyle(Style style)
        {
            _officeColorTable = StyleBuilderFactory.GetOffice2007ColorTable(style);
            this.LineColor = _officeColorTable.TabControlBorderColor;
            this.BackColor = _officeColorTable.TreeViewBackColor;
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
