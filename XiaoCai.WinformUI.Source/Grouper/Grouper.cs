/*
 [PLEASE DO NOT MODIFY THIS HEADER INFORMATION]---------------------
 Title: Grouper
 Description: A rounded groupbox with special painting features. 
 Date Created: December 17, 2005
 Author: Adam Smith
 Author Email: ibulwark@hotmail.com
 Websites: http://www.ebadgeman.com | http://www.codevendor.com
 
 Version History:
 1.0a - Beta Version - Release Date: December 17, 2005 
 -------------------------------------------------------------------
 */

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using XiaoCai.WinformUI;
using XiaoCai.WinformUI.Panels;

namespace Skyray.Controls
{
    /// <summary>A special custom rounding GroupBox with many painting features.</summary>
    //[ToolboxBitmap(typeof(Grouper), "Skyray.AFSControls.Images.Grouper.bmp")] //设置工具栏图标
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public class Grouper : System.Windows.Forms.UserControl,IStyle
    {
        #region Enumerations

        /// <summary>A special gradient enumeration.</summary>
        public enum GroupBoxGradientMode
        {
            /// <summary>Specifies no gradient mode.</summary>
            None = 4,

            /// <summary>Specifies a gradient from upper right to lower left.</summary>
            BackwardDiagonal = 3,

            /// <summary>Specifies a gradient from upper left to lower right.</summary>
            ForwardDiagonal = 2,

            /// <summary>Specifies a gradient from left to right.</summary>
            Horizontal = 0,

            /// <summary>Specifies a gradient from top to bottom.</summary>
            Vertical = 1
        }
        //ADD by WZW 2008-12-16
        public enum GroupBoxAlignMode
        {
            /// <summary>左对齐.</summary>
            Left = 0,

            /// <summary>中间对齐.</summary>
            Center = 1,

            /// <summary>右对齐.</summary>
            Right = 2
        }


        #endregion

        #region Variables

        private Container _components = null;
        private int _vRoundCorners = 4;
        private string _vGroupTitle = "The Grouper";
        private Color _vBorderColor = Color.LightSteelBlue;
        private float _vBorderThickness = 1;
        private bool _vShadowControl = false;
        private Color _vBackgroundColor = Color.Transparent;
        private Color _vBackgroundGradientColor = Color.Transparent;
        private GroupBoxGradientMode _vBackgroundGradientMode = GroupBoxGradientMode.None;
        private Color _vShadowColor = Color.DarkGray;
        private int _vShadowThickness = 3;
        private Image _vGroupImage = null;
        private Color _vCustomGroupBoxColor = Color.Transparent;
        private bool _vPaintGroupBox = false;
        private Color _vBackColor = Color.Transparent;


        private bool _vShowTileRectangle = false;//是否绘制标题边框

        private GroupBoxAlignMode _vGroupBoxAlignMode = GroupBoxAlignMode.Left;//标题边框对齐方式
        private int _vXTrans = 0;//记录平移距离
        private int _vTextLineSpace = 2;//标题框内文本与GroupBox左右上边线距离
        private int _vTitleLeftSpace = 18;//标题框内图片与GroupBox左右上边线距离
        private int _vHeaderRoundCorners = 4;
        private bool _vBorderTopOnly = false;
        #endregion


        #region Properties

        //Add By WZW 2008-12-16 Edit BY WZW 2008-12-17

        /// <summary>标题框内图片与GroupBox左上边线距离</summary>

        [Category("Appearance"), Description("标题框与GroupBox左边线距离")]
        public int TitleLeftSpace
        {
            get { return _vTitleLeftSpace; }
            set
            {
                if (value <= 24 && value >= -24)
                {
                    _vTitleLeftSpace = value;
                }
                else
                {
                    _vTitleLeftSpace = 0;
                }
                this.Invalidate();
            }
        }
        [Category("Appearance"), Description("只显示上边框")]
        public bool BorderTopOnly
        {
            get { return this._vBorderTopOnly; }
            set
            {
                this._vBorderTopOnly = value;
                this.Invalidate();
            }
        }

        /// <summary>标题框内文本与GroupBox左右上边线距离,当不绘制边框时生效</summary>
        [Category("Appearance"), Description("标题框内文本与GroupBox左右上边线距离")]
        public int TextLineSpace
        {
            get { return _vTextLineSpace; }
            set
            {
                if (value >= -8 && value <= 8)
                {
                    _vTextLineSpace = value;
                }
                else
                {
                    _vTextLineSpace = 0;
                }
                this.Invalidate();
            }
        }
        /// <summary>标题框对齐方式</summary>
        [Category("Appearance"), Description("标题框对齐方式")]
        public GroupBoxAlignMode GroupBoxAlign
        {
            get { return _vGroupBoxAlignMode; }
            set { _vGroupBoxAlignMode = value; this.Invalidate(); }
        }

        /// <summary>是否显示标题外框</summary>
        [Category("Appearance"), Description("是否显示标题外框")]
        [DefaultValue(false)]
        public bool ShowTileRectangle { get { return _vShowTileRectangle; } set { _vShowTileRectangle = value; this.Invalidate(); } }

        /// <summary>This feature will paint the background color of the control.</summary>
        [Category("Appearance"), Description("This feature will paint the background color of the control.")]
        public override System.Drawing.Color BackColor { get { return _vBackColor; } set { _vBackColor = value; this.Invalidate(); } }

        /// <summary>This feature will paint the group title background to the specified color if PaintGroupBox is set to true.</summary>
        [Category("Appearance"), Description("This feature will paint the group title background to the specified color if PaintGroupBox is set to true.")]
        public System.Drawing.Color CustomGroupBoxColor { get { return _vCustomGroupBoxColor; } set { _vCustomGroupBoxColor = value; this.Invalidate(); } }

        /// <summary>This feature will paint the group title background to the CustomGroupBoxColor.</summary>
        [Category("Appearance"), Description("This feature will paint the group title background to the CustomGroupBoxColor.")]
        public bool PaintGroupBox { get { return _vPaintGroupBox; } set { _vPaintGroupBox = value; this.Invalidate(); } }

        /// <summary>This feature can add a 16 x 16 image to the group title bar.</summary>
        [Category("Appearance"), Description("This feature can add a 16 x 16 image to the group title bar.")]
        public System.Drawing.Image GroupImage { get { return _vGroupImage; } set { _vGroupImage = value; this.Invalidate(); } }

        /// <summary>This feature will change the control's shadow color.</summary>
        [Category("Appearance"), Description("This feature will change the control's shadow color.")]
        public System.Drawing.Color ShadowColor { get { return _vShadowColor; } set { _vShadowColor = value; this.Invalidate(); } }

        /// <summary>This feature will change the size of the shadow border.</summary>
        [Category("Appearance"), Description("This feature will change the size of the shadow border.")]
        public int ShadowThickness
        {
            get { return _vShadowThickness; }
            set
            {
                if (value > 10)
                {
                    _vShadowThickness = 10;
                }
                else
                {
                    if (value < 1) { _vShadowThickness = 1; }
                    else { _vShadowThickness = value; }
                }

                this.Invalidate();
            }
        }


        /// <summary>This feature will change the group control color. This color can also be used in combination with BackgroundGradientColor for a gradient paint.</summary>
        [Category("Appearance"), Description("This feature will change the group control color. This color can also be used in combination with BackgroundGradientColor for a gradient paint.")]
        public System.Drawing.Color BackgroundColor { get { return _vBackgroundColor; } set { _vBackgroundColor = value; this.Invalidate(); } }

        /// <summary>This feature can be used in combination with BackgroundColor to create a gradient background.</summary>
        [Category("Appearance"), Description("This feature can be used in combination with BackgroundColor to create a gradient background.")]
        public System.Drawing.Color BackgroundGradientColor { get { return _vBackgroundGradientColor; } set { _vBackgroundGradientColor = value; this.Invalidate(); } }

        /// <summary>This feature turns on background gradient painting.</summary>
        [Category("Appearance"), Description("This feature turns on background gradient painting.")]
        public GroupBoxGradientMode BackgroundGradientMode { get { return _vBackgroundGradientMode; } set { _vBackgroundGradientMode = value; this.Invalidate(); } }


        /// <summary>This feature will round the corners of the control.</summary>
        [Category("Appearance"), Description("This feature will round the corners of the control.")]
        public int RoundCorners
        {
            get { return _vRoundCorners; }
            set
            {
                if (value > 20)
                {
                    _vRoundCorners = 20;
                }
                else
                {
                    if (value < 1) { _vRoundCorners = 1; }
                    else { _vRoundCorners = value; }
                }

                this.Invalidate();
            }
        }
        //Add by WZW 2008-12-25
        /// <summary>This feature will round the Header corners of the control.</summary>
        [Category("Appearance"), Description("This feature will round the Header corners of the control.")]
        public int HeaderRoundCorners
        {
            get { return _vHeaderRoundCorners; }
            set
            {
                if (value > 20)
                {
                    _vHeaderRoundCorners = 20;
                }
                else
                {
                    if (value < 1) { _vHeaderRoundCorners = 1; }
                    else { _vHeaderRoundCorners = value; }
                }

                this.Invalidate();
            }
        }
        /// <summary>This feature will add a group title to the control.</summary>
        [Category("Appearance"), Description("This feature will add a group title to the control.")]
        public string GroupTitle { get { return _vGroupTitle; } set { _vGroupTitle = value; this.Invalidate(); } }

        /// <summary>This feature will allow you to change the color of the control's border.</summary>
        [Category("Appearance"), Description("This feature will allow you to change the color of the control's border.")]
        public System.Drawing.Color BorderColor { get { return _vBorderColor; } set { _vBorderColor = value; this.Invalidate(); } }

        /// <summary>This feature will allow you to set the control's border size.</summary>
        [Category("Appearance"), Description("This feature will allow you to set the control's border size.")]
        public float BorderThickness
        {
            get { return _vBorderThickness; }
            set
            {
                if (value > 3)
                {
                    _vBorderThickness = 3;
                }
                else
                {
                    if (value < 1) { _vBorderThickness = 1; }
                    else { _vBorderThickness = value; }
                }
                this.Invalidate();
            }
        }

        /// <summary>This feature will allow you to turn on control shadowing.</summary>
        [Category("Appearance"), Description("This feature will allow you to turn on control shadowing.")]
        public bool ShadowControl { get { return _vShadowControl; } set { _vShadowControl = value; this.Invalidate(); } }

        #endregion

        #region Constructor

        private OfficeColorTable _officeColorTable;
        /// <summary>This method will construct a new GroupBox control.</summary>
        public Grouper()
        {
            InitializeStyles();
            InitializeGroupBox();
            _officeColorTable = StyleBuilderFactory.GetOffice2007ColorTable(_style);
            if (_officeColorTable.GrouperBorderColor.IsEmpty)
            {
                this.BorderColor = Color.Silver;
            }
            else
            {
                this.BorderColor = _officeColorTable.GrouperBorderColor;
            }
           
            this.ForeColor = _officeColorTable.GrouperTextColor;
            this.BackColor = _officeColorTable.GrouperBackColor;
            this.Refresh();
        }


        #endregion

        #region DeConstructor

        /// <summary>This method will dispose of the GroupBox control.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) { if (_components != null) { _components.Dispose(); } }
            base.Dispose(disposing);
        }


        #endregion

        #region Initialization

        /// <summary>This method will initialize the controls custom styles.</summary>
        private void InitializeStyles()
        {
            //Set the control styles----------------------------------
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //--------------------------------------------------------
        }


        /// <summary>This method will initialize the GroupBox control.</summary>
        private void InitializeGroupBox()
        {
            _components = new System.ComponentModel.Container();
            this.Resize += new EventHandler(GroupBox_Resize);
            this.DockPadding.All = 0;
            this.Name = "GroupBox";
            this.GroupBoxAlign = GroupBoxAlignMode.Center;
            this.Size = new System.Drawing.Size(150, 50);

        }

        #endregion

        #region Protected Methods

        /// <summary>Overrides the OnPaint method to paint control.</summary>
        /// <param name="e">The paint event arguments.</param>        
        protected override void OnPaint(PaintEventArgs e)
        {
            PaintGroupText(e.Graphics);
            PaintBack(e.Graphics);
        }

        #endregion

        #region Private Methods
        /// <summary>This method will paint the group title.</summary>
        /// <param name="g">The paint event graphics object.</param>
        private void PaintGroupText(System.Drawing.Graphics g)
        {
            //Check if string has something-------------
            if (this.GroupTitle == string.Empty) { return; }
            //------------------------------------------

            //Set Graphics smoothing mode to Anit-Alias-- 
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //-------------------------------------------

            //Declare Variables------------------
            SizeF stringSize = g.MeasureString(this.GroupTitle, this.Font);
            Size stringSize2 = stringSize.ToSize();


            if (this.GroupImage != null) { stringSize2.Width += 18; }
            //int ArcWidth = this.RoundCorners;
            //int ArcHeight = this.RoundCorners;
            int arcWidth = this.HeaderRoundCorners;
            int arcHeight = this.HeaderRoundCorners;
            //int intX1 = 0;
            //int intX2 = 0;

            //int ArcX1 = 10;
            //int ArcX2 = (StringSize2.Width + 34) - (ArcWidth + 1);
            int ArcX1 = 20;
            int ArcX2 = (stringSize2.Width + 34) - (arcWidth + 1);
            int ArcY1 = 2;
            int ArcY2 = 22 - (arcHeight + 1);

            //Add by WZW 2008-12-16 增加GroupTitleBox对齐方式 ===Start
            int intMidX = this.Size.Width / 2;
            int intMidX1 = (ArcX2 - ArcX1) / 2;
            int CustomStringWidth = (this.GroupImage != null) ? 44 : 28;
            _vXTrans = intMidX - intMidX1 - ArcX1;//X坐标平移距离
            int intTitleTextSpace = CustomStringWidth - ArcX1;
            //中间对齐
            if (this._vGroupBoxAlignMode == GroupBoxAlignMode.Center)
            {
                ArcX1 = intMidX - intMidX1;
                ArcX2 = intMidX + intMidX1;
                CustomStringWidth = ArcX1 + intTitleTextSpace;
            }
            else if (this._vGroupBoxAlignMode == GroupBoxAlignMode.Right)
            {
                ArcX1 = intMidX + intMidX - ArcX2;
                ArcX2 = ArcX1 + intMidX1 + intMidX1;
                CustomStringWidth = ArcX1 + intTitleTextSpace;
            }
            //标题与左边线距离
            ArcX1 -= this.TitleLeftSpace;
            ArcX2 -= this.TitleLeftSpace;

            //Add by WZW 2008-12-16 增加GroupTitleBox对齐方式 ===End
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Brush BorderBrush = new SolidBrush(this.BorderColor);
            System.Drawing.Pen BorderPen = new Pen(BorderBrush, this.BorderThickness);
            System.Drawing.Drawing2D.LinearGradientBrush BackgroundGradientBrush = null;
            System.Drawing.Brush BackgroundBrush = (this.PaintGroupBox) ? new SolidBrush(this.CustomGroupBoxColor) : new SolidBrush(this.BackgroundColor);
            System.Drawing.SolidBrush TextColorBrush = new SolidBrush(this.ForeColor);
            System.Drawing.SolidBrush ShadowBrush = null;
            System.Drawing.Drawing2D.GraphicsPath ShadowPath = null;
            //-----------------------------------

            //Check if shadow is needed----------
            if (this.ShadowControl)
            {
                ShadowBrush = new SolidBrush(this.ShadowColor);
                ShadowPath = new System.Drawing.Drawing2D.GraphicsPath();
                ShadowPath.AddArc(ArcX1 + (this.ShadowThickness - 1), ArcY1 + (this.ShadowThickness - 1), arcWidth, arcHeight, 180, GroupBoxConstants.SweepAngle); // Top Left
                ShadowPath.AddArc(ArcX2 + (this.ShadowThickness - 1), ArcY1 + (this.ShadowThickness - 1), arcWidth, arcHeight, 270, GroupBoxConstants.SweepAngle); //Top Right
                ShadowPath.AddArc(ArcX2 + (this.ShadowThickness - 1), ArcY2 + (this.ShadowThickness - 1), arcWidth, arcHeight, 360, GroupBoxConstants.SweepAngle); //Bottom Right
                ShadowPath.AddArc(ArcX1 + (this.ShadowThickness - 1), ArcY2 + (this.ShadowThickness - 1), arcWidth, arcHeight, 90, GroupBoxConstants.SweepAngle); //Bottom Left
                ShadowPath.CloseAllFigures();

                //Paint Rounded Rectangle------------
                g.FillPath(new SolidBrush(Color.Transparent), ShadowPath);
                //g.FillPath(ShadowBrush, ShadowPath);
                //-----------------------------------
            }
            //-----------------------------------
            //Edit BY WZW 2008-12-16
            //是否显示标题边框------
            if (this._vShowTileRectangle)
            {
                //创建title边框路径
                path.AddArc(ArcX1, ArcY1, arcWidth, arcHeight, 180, GroupBoxConstants.SweepAngle); // Top Left
                path.AddArc(ArcX2, ArcY1, arcWidth, arcHeight, 270, GroupBoxConstants.SweepAngle); //Top Right
                path.AddArc(ArcX2, ArcY2, arcWidth, arcHeight, 360, GroupBoxConstants.SweepAngle); //Bottom Right
                path.AddArc(ArcX1, ArcY2, arcWidth, arcHeight, 90, GroupBoxConstants.SweepAngle); //Bottom Left
                path.CloseAllFigures();
                //画Title边框
                g.DrawPath(BorderPen, path);
            }

            //-----------------------------------

            //Check if Gradient Mode is enabled--
            if (this.PaintGroupBox)
            {
                //Paint Rounded Rectangle------------
                g.FillPath(BackgroundBrush, path);
                //-----------------------------------
            }
            else
            {
                if (this.BackgroundGradientMode == GroupBoxGradientMode.None)
                {
                    //Paint Rounded Rectangle------------
                    g.FillPath(BackgroundBrush, path);
                    //-----------------------------------
                }
                else
                {
                    BackgroundGradientBrush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), this.BackgroundColor, this.BackgroundGradientColor, (LinearGradientMode)this.BackgroundGradientMode);

                    //Paint Rounded Rectangle------------
                    g.FillPath(BackgroundGradientBrush, path);
                    //-----------------------------------
                }
            }
            //-----------------------------------

            //绘制title文字-------------------------
            //int CustomStringWidth = (this.GroupImage != null) ? 44 : 28;
            //if(this.GroupImage!=null)
            //{
            //    CustomStringWidth += 2;
            //}

            //g.DrawString(this.GroupTitle, this.Font, TextColorBrush, CustomStringWidth, 5);

            // g.DrawString(this.GroupTitle, this.Font, TextColorBrush, CustomStringWidth-this.TitleLeftSpace-2, 5);
            g.DrawString(this.GroupTitle, this.Font, TextColorBrush, CustomStringWidth - this.TitleLeftSpace, 5);
            //-----------------------------------

            //Draw GroupImage if there is one----
            if (this.GroupImage != null)
            {
                //因增加了标题对齐功能,需修改X坐标值 By  WZW 2008-12-17
                g.DrawImage(this.GroupImage, ArcX1 + 5, 4, 16, 16);
            }

            //释放资源------------
            if (path != null) { path.Dispose(); }
            if (BorderBrush != null) { BorderBrush.Dispose(); }
            if (BorderPen != null) { BorderPen.Dispose(); }
            if (BackgroundGradientBrush != null) { BackgroundGradientBrush.Dispose(); }
            if (BackgroundBrush != null) { BackgroundBrush.Dispose(); }
            if (TextColorBrush != null) { TextColorBrush.Dispose(); }
            if (ShadowBrush != null) { ShadowBrush.Dispose(); }
            if (ShadowPath != null) { ShadowPath.Dispose(); }
        }


        /// <summary>This method will paint the control.</summary>
        /// <param name="g">The paint event graphics object.</param>
        private void PaintBack(System.Drawing.Graphics g)
        {
            //Set Graphics smoothing mode to Anit-Alias-- 
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //-------------------------------------------

            //Declare Variables------------------
            int ArcWidth = this.RoundCorners * 2;
            int ArcHeight = this.RoundCorners * 2;
            int ArcX1 = 0;
            int ArcX2 = (this.ShadowControl) ? (this.Width - (ArcWidth + 1)) - this.ShadowThickness : this.Width - (ArcWidth + 1);
            int ArcY1 = 10;
            int ArcY2 = (this.ShadowControl) ? (this.Height - (ArcHeight + 1)) - this.ShadowThickness : this.Height - (ArcHeight + 1);

            int intXEnd = 20;

            if (GroupBoxAlignMode.Center == this._vGroupBoxAlignMode)
            {
                intXEnd += _vXTrans;
            }
            else if (GroupBoxAlignMode.Right == this._vGroupBoxAlignMode)
            {
                intXEnd += _vXTrans * 2;
            }
            int intTextLength = g.MeasureString(this.GroupTitle, this.Font).ToSize().Width + 34 - (ArcWidth + 1) - 20;
            int intXStart = intXEnd + intTextLength + ArcWidth;
            int X1 = intXEnd;
            int X2 = intXStart;

            if (this.GroupImage != null)
            {
                if (this.ShowTileRectangle)
                {
                    X2 += 18;
                }
                else
                {
                    X2 += 10;
                }
            }
            else
            {
                if (!this.ShowTileRectangle)
                {
                    X1 += 8 - this.TextLineSpace;
                    X2 -= 8 - this.TextLineSpace;
                }
            }
            X1 -= this.TitleLeftSpace;
            X2 -= this.TitleLeftSpace;

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Brush BorderBrush = new SolidBrush(this.BorderColor);
            System.Drawing.Pen BorderPen = new Pen(BorderBrush, this.BorderThickness);
            System.Drawing.Drawing2D.LinearGradientBrush BackgroundGradientBrush = null;
            System.Drawing.Brush BackgroundBrush = new SolidBrush(this.BackgroundColor);
            System.Drawing.SolidBrush ShadowBrush = null;
            System.Drawing.Drawing2D.GraphicsPath ShadowPath = null;
            //-----------------------------------

            //Check if shadow is needed----------
            if (this.ShadowControl)
            {
                ShadowBrush = new SolidBrush(this.ShadowColor);
                ShadowPath = new System.Drawing.Drawing2D.GraphicsPath();
                ShadowPath.AddArc(ArcX1 + this.ShadowThickness, ArcY1 + this.ShadowThickness, ArcWidth, ArcHeight, 180, GroupBoxConstants.SweepAngle); // Top Left
                ShadowPath.AddArc(ArcX2 + this.ShadowThickness, ArcY1 + this.ShadowThickness, ArcWidth, ArcHeight, 270, GroupBoxConstants.SweepAngle); //Top Right
                ShadowPath.AddArc(ArcX2 + this.ShadowThickness, ArcY2 + this.ShadowThickness, ArcWidth, ArcHeight, 360, GroupBoxConstants.SweepAngle); //Bottom Right
                ShadowPath.AddArc(ArcX1 + this.ShadowThickness, ArcY2 + this.ShadowThickness, ArcWidth, ArcHeight, 90, GroupBoxConstants.SweepAngle); //Bottom Left
                ShadowPath.CloseAllFigures();

                //Paint Rounded Rectangle------------
                g.FillPath(ShadowBrush, ShadowPath);
                //-----------------------------------
            }
            //-----------------------------------
            //Edit BY WZW 2008-12-16
            //Create Rounded Rectangle Path------
            //path.AddArc(ArcX1, ArcY1, ArcWidth, ArcHeight, 180, GroupBoxConstants.SweepAngle); // Top Left
            //path.AddArc(ArcX2, ArcY1, ArcWidth, ArcHeight, 270, GroupBoxConstants.SweepAngle); //Top Right
            //path.AddArc(ArcX2, ArcY2, ArcWidth, ArcHeight, 360, GroupBoxConstants.SweepAngle); //Bottom Right
            //path.AddArc(ArcX1, ArcY2, ArcWidth, ArcHeight, 90, GroupBoxConstants.SweepAngle); //Bottom Left
            //path.CloseAllFigures(); 
            //g.DrawPath(BorderPen, path);
            //-----------------------------------
            //g.DrawArc(ArcX1, ArcY1, ArcWidth, ArcHeight, 180, GroupBoxConstants.SweepAngle);

            //绘制标题外边框-----------------------


            //左上角
            g.DrawArc(BorderPen, ArcX1, ArcY1, ArcWidth, ArcHeight, 180, GroupBoxConstants.SweepAngle);
            //左上至右上分两段画线，两段之间为标题外框
            BorderPen = new Pen(BorderBrush, this.BorderThickness);
            g.DrawLine(BorderPen, new Point(ArcX1 + this.RoundCorners, ArcY1), new Point(X1, ArcY1));//左边一段直线
            BorderPen = new Pen(BorderBrush, this.BorderThickness);
            g.DrawLine(BorderPen, new Point(X2, ArcY1), new Point(ArcX2 + this.RoundCorners, ArcY1));//右边一段直线

            //右上角
            g.DrawArc(BorderPen, ArcX2, ArcY1, ArcWidth, ArcHeight, 270, GroupBoxConstants.SweepAngle);

            if (!_vBorderTopOnly)
            {
                //右上至右下
                g.DrawLine(BorderPen, new Point(ArcX2 + ArcWidth, ArcY1 + this.RoundCorners), new Point(ArcX2 + ArcHeight, ArcY2 + this.RoundCorners));
                //右下角

                g.DrawArc(BorderPen, ArcX2, ArcY2, ArcWidth, ArcHeight, 360, GroupBoxConstants.SweepAngle);
                //右下至左下

                g.DrawLine(BorderPen, new Point(ArcX2 + this.RoundCorners, ArcY2 + ArcWidth), new Point(ArcX1 + this.RoundCorners, ArcY2 + ArcWidth));
                //左下角
                g.DrawArc(BorderPen, ArcX1, ArcY2, ArcWidth, ArcHeight, 90, GroupBoxConstants.SweepAngle);
                //左下只左上
                g.DrawLine(BorderPen, new Point(ArcX1, ArcY2 + this.RoundCorners), new Point(ArcX1, ArcY1 + this.RoundCorners));
                //g.DrawPath(BorderPen, path);
            }

            //Check if Gradient Mode is enabled--
            if (this.BackgroundGradientMode == GroupBoxGradientMode.None)
            {
                //Paint Rounded Rectangle------------
                g.FillPath(BackgroundBrush, path);
                //-----------------------------------
            }
            else
            {
                BackgroundGradientBrush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), this.BackgroundColor, this.BackgroundGradientColor, (LinearGradientMode)this.BackgroundGradientMode);

                //Paint Rounded Rectangle------------
                g.FillPath(BackgroundGradientBrush, path);
                //-----------------------------------
            }
            //-----------------------------------

            //Delete BY WZW 
            //Paint Borded-----------------------
            //g.DrawPath(BorderPen, path);
            //g.DrawLine(SystemPens.Control, 10, 10, 100, 10);
            //-----------------------------------

            //Destroy Graphic Objects------------
            if (path != null) { path.Dispose(); }
            if (BorderBrush != null) { BorderBrush.Dispose(); }
            if (BorderPen != null) { BorderPen.Dispose(); }
            if (BackgroundGradientBrush != null) { BackgroundGradientBrush.Dispose(); }
            if (BackgroundBrush != null) { BackgroundBrush.Dispose(); }
            if (ShadowBrush != null) { ShadowBrush.Dispose(); }
            if (ShadowPath != null) { ShadowPath.Dispose(); }
            //-----------------------------------
        }


        /// <summary>This method fires when the GroupBox resize event occurs.</summary>
        /// <param name="sender">The object the sent the event.</param>
        /// <param name="e">The event arguments.</param>
        private void GroupBox_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }


        #endregion

           #region IStyle 成员
        public void SetStyle(Style style)
        {
            _officeColorTable = StyleBuilderFactory.GetOffice2007ColorTable(style);
            if (_officeColorTable.GrouperBorderColor.IsEmpty)
            {
                this.BorderColor = Color.Silver;
            }
            else
            {
                this.BorderColor = _officeColorTable.GrouperBorderColor;
            }
            
            this.ForeColor = _officeColorTable.GrouperTextColor;
            this.BackColor = _officeColorTable.GrouperBackColor;
            _style = style;
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
            // Grouper
            // 
            this.Name = "Grouper";
            this.ResumeLayout(false);

        }
    }
}
