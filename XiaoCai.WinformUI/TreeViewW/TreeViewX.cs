using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

// RightToCopy & PublishAndPerish: OrlandoCurioso 2006

namespace XiaoCai.WinformUI
{
    //[DesignTimeVisible(false)]
    //[DesignTimeVisibleAttribute(false)]
    [ToolboxItem(false)] 
    public class TreeViewX : TreeView
    {
        public const int NOIMAGE = -1;

        public TreeViewX() : base()
        {
            // .NET Bug: Unless LineColor is set, Win32 treeview returns -1 (default), .NET returns Color.Black!
            base.LineColor = Color.Red;
            base.DrawMode = TreeViewDrawMode.OwnerDrawText;
        }
        private Color _selectedColor1 = Color.Khaki;
        private Color _selectedColor2 = Color.Gold;

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            const int SPACE_IL = 3;  // space between Image and Label

            // we only do additional drawing
            //e.DrawDefault = true;

            base.OnDrawNode(e);

            if (base.ShowLines && base.ImageList != null && e.Node.ImageIndex == NOIMAGE
                // exclude root nodes, if root lines are disabled
                //&& (base.ShowRootLines || e.Node.Level > 0))
                )
            {
                // Using lines & images, but this node has none: fill up missing treelines

                // Image size
                int imgW = base.ImageList.ImageSize.Width;
                int imgH = base.ImageList.ImageSize.Height;

                // Image center
                int xPos = e.Node.Bounds.Left - SPACE_IL - imgW / 2;
                int yPos = (e.Node.Bounds.Top + e.Node.Bounds.Bottom) / 2;

                // Image rect
                Rectangle imgRect = new Rectangle(xPos, yPos, 0, 0);
                imgRect.Inflate(imgW / 2, imgH / 2);

                using (Pen p = new Pen(base.LineColor, 1))
                {
                    p.DashStyle = DashStyle.Custom;

                    // account uneven Indent for both lines
                    p.DashOffset = base.Indent % 2;

                    // Horizontal treeline across width of image
                    // account uneven half of delta ItemHeight & ImageHeight
                    int yHor = yPos + ((base.ItemHeight - imgRect.Height) / 2) % 2;

                    e.Graphics.DrawLine(p, 
                        (base.ShowRootLines || e.Node.Level > 0) ? imgRect.Left : xPos - (int)p.DashOffset,
                        yHor, imgRect.Right, yHor);

                    
                    if (!base.CheckBoxes && e.Node.IsExpanded)
                    {
                        // Vertical treeline , offspring from NodeImage center to e.Node.Bounds.Bottom
                        // yStartPos: account uneven Indent and uneven half of delta ItemHeight & ImageHeight
 
                        int yVer = yHor + (int)p.DashOffset;
                        e.Graphics.DrawLine(p, xPos, yVer, xPos, e.Node.Bounds.Bottom);
                    }
                }
            }
        }

        protected override void OnAfterCollapse(TreeViewEventArgs e)
        {
            base.OnAfterCollapse(e);

            if (!base.CheckBoxes && base.ImageList != null && e.Node.ImageIndex == NOIMAGE)
            {
                // DrawNode event not raised: redraw node with collapsed treeline
                base.Invalidate(e.Node.Bounds);
            }
        }

        private Color _rowBackColor1 = Color.White;//ÑÕÉ«1
        private Color _rowBackColor2 = Color.White;//ÑÕÉ«2
        private Color _selectedColor;



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

    }
}
