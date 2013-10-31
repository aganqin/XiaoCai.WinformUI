using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel.Design;
using XiaoCai.WinformUI.Properties;

namespace XiaoCai.WinformUI.Panels
{
    #region Class PanderPanelW
    [Designer(typeof(PanderPanelWDesigner))]
    //[DesignTimeVisible(false)]
    //[DesignTimeVisibleAttribute(false)]
    [ToolboxItem(false)] 
	public partial class PanderPanelW : BasePanel
	{
		#region EventsPublic
        /// <summary>
        /// The CaptionStyleChanged event occurs when CaptionStyle flags have been changed.
        /// </summary>
        [Description("The CaptionStyleChanged event occurs when CaptionStyle flags have been changed.")]
        public event EventHandler<EventArgs> CaptionStyleChanged;
        #endregion
		
		#region Constants
		#endregion

		#region FieldsPrivate
		
		private System.Drawing.Image m_imageChevron;
        private System.Drawing.Image m_imageChevronUp;
        private System.Drawing.Image m_imageChevronDown;
        private CustomPanderPanelWColors m_customColors;
        private System.Drawing.Image m_imageClosePanel;
        private bool m_bIsClosable = true;
        private CaptionStyle m_captionStyle;

		#endregion

		#region Properties
		/// <summary>
        /// Gets or sets a value indicating whether the expand icon in a PanderPanelW is visible.
        /// </summary>
		[Description("Gets or sets a value indicating whether the expand icon in a PanderPanelW is visible.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(false)]
		[Browsable(false)]
		[Category("Appearance")]
		public override bool ShowExpandIcon
		{
			get
			{
				return base.ShowExpandIcon;
			}
			set
			{
				base.ShowExpandIcon = value;
			}
		}
        /// <summary>
        /// Gets or sets a value indicating whether the close icon in a PanderPanelW is visible.
        /// </summary>
        [Description("Gets or sets a value indicating whether the close icon in a PanderPanelW is visible.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(false)]
        [Browsable(false)]
        [Category("Appearance")]
        public override bool ShowCloseIcon
        {
            get
            {
                return base.ShowCloseIcon;
            }
            set
            {
                base.ShowCloseIcon = value;
            }
        }
        /// <summary>
        /// Gets the custom colors which are used for the PanderPanelW.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("The custom colors which are used for the PanderPanelW.")]
        [Category("Appearance")]
        public CustomPanderPanelWColors CustomColors
        {
            get { return this.m_customColors; }
        }
        /// <summary>
        /// Gets or sets the style of the caption (not for PanelStyle.Aqua).
        /// </summary>
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public CaptionStyle CaptionStyle
        {
            get { return this.m_captionStyle; }
            set
            {
                if (value.Equals(this.m_captionStyle) == false)
                {
                    this.m_captionStyle = value;
                    OnCaptionStyleChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this PanderPanelW is closable.
        /// </summary>
        [Description("Gets or sets a value indicating whether this PanderPanelW is closable.")]
        [DefaultValue(true)]
        [Category("Appearance")]
        public bool IsClosable
        {
            get { return this.m_bIsClosable; }
            set
            {
                if (value.Equals(this.m_bIsClosable) == false)
                {
                    this.m_bIsClosable = value;
                    this.Invalidate(false);
                }
            }
        }
        /// <summary>
        /// Gets or sets the height and width of the PanderPanelW.
        /// </summary>
        [Browsable(false)]
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = value; }
        }
		#endregion

		#region MethodsPublic
		/// <summary>
		/// Initializes a new instance of the PanderPanelW class.
		/// </summary>
        public PanderPanelW()
		{
			InitializeComponent();

            this.BackColor = Color.Transparent;
            this.CaptionStyle = CaptionStyle.Normal;
            this.ForeColor = SystemColors.ControlText;
			this.Height = this.CaptionHeight;
			this.ShowBorder = true;
            this.m_customColors = new CustomPanderPanelWColors();
            this.m_customColors.CustomColorsChanged += OnCustomColorsChanged;

		}
        /// <summary>
        /// Gets the rectangle that represents the display area of the PanderPanelW.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Rectangle DisplayRectangle
        {
            get
            {
                Padding padding = this.Padding;

                Rectangle displayRectangle = new Rectangle(
                    padding.Left + Constants.BorderThickness,
                    padding.Top + this.CaptionHeight,
                    this.ClientRectangle.Width - padding.Left - padding.Right - (2 * Constants.BorderThickness),
                    this.ClientRectangle.Height - this.CaptionHeight - padding.Top - padding.Bottom);

                if (this.Controls.Count > 0)
                {
                    PanderPanelListW PanderPanelListW = this.Controls[0] as PanderPanelListW;
                    if ((PanderPanelListW != null) && (PanderPanelListW.Dock == DockStyle.Fill))
                    {
                        displayRectangle = new Rectangle(
                            padding.Left,
                            padding.Top + this.CaptionHeight,
                            this.ClientRectangle.Width - padding.Left - padding.Right,
                            this.ClientRectangle.Height - this.CaptionHeight - padding.Top - padding.Bottom - Constants.BorderThickness);
                    }
                }
                return displayRectangle;
            }
        }
		#endregion

		#region MethodsProtected
		/// <summary>
		/// Paints the background of the control.
		/// </summary>
		/// <param name="pevent">A PaintEventArgs that contains information about the control to paint.</param>
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);
            base.BackColor = Color.Transparent;
            Color backColor = this.PanelColors.PanderPanelWBackColor;
            if ((backColor != Color.Empty) && backColor != Color.Transparent)
            {
                Rectangle rectangle = new Rectangle(
                    0,
                    this.CaptionHeight,
                    this.ClientRectangle.Width,
                    this.ClientRectangle.Height - this.CaptionHeight);

                using (SolidBrush backgroundBrush = new SolidBrush(backColor))
                {
                    pevent.Graphics.FillRectangle(backgroundBrush, rectangle);
                }
            }
		}
		/// <summary>
		/// Raises the Paint event.
		/// </summary>
		/// <param name="e">A PaintEventArgs that contains the event data.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
            if (IsZeroWidthOrHeight(this.CaptionRectangle) == true)
            {
                return;
            }
            
            using (UseAntiAlias antiAlias = new UseAntiAlias(e.Graphics))
            {
                Graphics graphics = e.Graphics;
                using (UseClearTypeGridFit clearTypeGridFit = new UseClearTypeGridFit(graphics))
                {
                    bool bExpand = this.Expand;
                    bool bShowBorder = this.ShowBorder;
                    Color borderColor = this.PanelColors.BorderColor;
                    Rectangle borderRectangle = this.ClientRectangle;
                    
                    switch (this.PanelStyle)
                    {
                        case PanelStyle.Default:
                        case PanelStyle.Office2007:
                            DrawCaptionbar(graphics, bExpand, bShowBorder, this.PanelStyle);
                            CalculatePanelHeights();
                            DrawBorders(graphics, this);
                            break;
                    }
                }
            }
		}
		/// <summary>
        /// Raises the PanelExpanding event.
		/// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A PanderStateChangeEventArgs that contains the event data.</param>
        protected override void OnPanelExpanding(object sender, PanderStateChangeEventArgs e)
		{
			bool bExpand = e.Expand;
			if (bExpand == true)
			{
				this.Expand = bExpand;
                this.Invalidate(false);
			}
			base.OnPanelExpanding(sender, e);
		}
        /// <summary>
        /// Raises the CaptionStyleChanged event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected virtual void OnCaptionStyleChanged(object sender, EventArgs e)
        {
            this.Invalidate(this.CaptionRectangle);
            if (this.CaptionStyleChanged != null)
            {
                this.CaptionStyleChanged(sender, e);
            }
        }
        /// <summary>
        /// Raises the MouseUp event.
        /// </summary>
        /// <param name="e">A MouseEventArgs that contains data about the OnMouseUp event.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this.CaptionRectangle.Contains(e.X, e.Y) == true)
            {
                if ((this.ShowCloseIcon == false) && (this.ShowExpandIcon == false))
                {
                    OnExpandClick(this, EventArgs.Empty);
                }
                else if ((this.ShowCloseIcon == true) && (this.ShowExpandIcon == false))
                {
                    if (this.RectangleCloseIcon.Contains(e.X, e.Y) == false)
                    {
                        OnExpandClick(this, EventArgs.Empty);
                    }
                }
                if (this.ShowExpandIcon == true)
                {
                    if (this.RectangleExpandIcon.Contains(e.X, e.Y) == true)
                    {
                        OnExpandClick(this, EventArgs.Empty);
                    }
                }
                if ((this.ShowCloseIcon == true) && (this.m_bIsClosable == true))
                {
                    if (this.RectangleCloseIcon.Contains(e.X, e.Y) == true)
                    {
                        OnCloseClick(this, EventArgs.Empty);
                    }
                }
            }
        }
		/// <summary>
		/// Raises the VisibleChanged event.
		/// </summary>
		/// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.DesignMode == true)
            {
                return;
            }
            if (this.Visible == false)
            {
                if (this.Expand == true)
                {
                    this.Expand = false;
                    foreach (Control control in this.Parent.Controls)
                    {
                        XiaoCai.WinformUI.Panels.PanderPanelW PanderPanelW =
                            control as XiaoCai.WinformUI.Panels.PanderPanelW;

                        if (PanderPanelW != null)
                        {
                            if (PanderPanelW.Visible == true)
                            {
                                PanderPanelW.Expand = true;
                                return;
                            }
                        }
                    }
                }
            }
#if DEBUG
            //System.Diagnostics.Trace.WriteLine("Visibility: " + this.Name + this.Visible);
#endif
            CalculatePanelHeights();
        }

		#endregion

		#region MethodsPrivate
        
        private void DrawCaptionbar(Graphics graphics, bool bExpand, bool bShowBorder, PanelStyle panelStyle)
        {
            Rectangle captionRectangle = this.CaptionRectangle;
            Color colorGradientBegin = this.PanelColors.PanderPanelWCaptionGradientBegin;
            Color colorGradientEnd = this.PanelColors.PanderPanelWCaptionGradientEnd;
            Color colorGradientMiddle = this.PanelColors.PanderPanelWCaptionGradientMiddle;
            Color colorText = this.PanelColors.PanderPanelWCaptionText;
            Color foreColorCloseIcon = this.PanelColors.PanderPanelWCaptionCloseIcon;
            Color foreColorExpandIcon = this.PanelColors.PanderPanelWCaptionExpandIcon;
            bool bHover = this.HoverStateCaptionBar == HoverState.Hover ? true : false;

            if (this.m_imageClosePanel == null)
            {
                this.m_imageClosePanel = Resources.closePanel;
            }
            if (this.m_imageChevronUp == null)
            {
                this.m_imageChevronUp = Resources.ChevronUp;
            }
            if (this.m_imageChevronDown == null)
            {
                this.m_imageChevronDown = Resources.ChevronDown;
            }
            
            this.m_imageChevron = this.m_imageChevronDown;
            if (bExpand == true)
            {
                this.m_imageChevron = this.m_imageChevronUp;
            }

            if (this.m_captionStyle == CaptionStyle.Normal)
            {
                if (bHover == true)
                {
                    colorGradientBegin = this.PanelColors.PanderPanelWSelectedCaptionBegin;
                    colorGradientEnd = this.PanelColors.PanderPanelWSelectedCaptionEnd;
                    colorGradientMiddle = this.PanelColors.PanderPanelWSelectedCaptionMiddle;
                    if (bExpand == true)
                    {
                        colorGradientBegin = this.PanelColors.PanderPanelWPressedCaptionBegin;
                        colorGradientEnd = this.PanelColors.PanderPanelWPressedCaptionEnd;
                        colorGradientMiddle = this.PanelColors.PanderPanelWPressedCaptionMiddle;
                    }
                    colorText = this.PanelColors.PanderPanelWSelectedCaptionText;
                    foreColorCloseIcon = colorText;
                    foreColorExpandIcon = colorText;
                }
                else
                {
                    if (bExpand == true)
                    {
                        colorGradientBegin = this.PanelColors.PanderPanelWCheckedCaptionBegin;
                        colorGradientEnd = this.PanelColors.PanderPanelWCheckedCaptionEnd;
                        colorGradientMiddle = this.PanelColors.PanderPanelWCheckedCaptionMiddle;
                        colorText = this.PanelColors.PanderPanelWSelectedCaptionText;
                        foreColorCloseIcon = colorText;
                        foreColorExpandIcon = colorText;
                    }
                }
                if (panelStyle != PanelStyle.Office2007)
                {
                    RenderDoubleBackgroundGradient(
                    graphics,
                    captionRectangle,
                    colorGradientBegin,
                    colorGradientMiddle,
                    colorGradientEnd,
                    LinearGradientMode.Vertical,
                    false);
                }
                else
                {
                    RenderButtonBackground(
                        graphics,
                        captionRectangle,
                        colorGradientBegin,
                        colorGradientMiddle,
                        colorGradientEnd);
                }
            }
            else
            {
                Color colorFlatGradientBegin = this.PanelColors.PanderPanelWFlatCaptionGradientBegin;
                Color colorFlatGradientEnd = this.PanelColors.PanderPanelWFlatCaptionGradientEnd;
                Color colorInnerBorder = this.PanelColors.InnerBorderColor;
                colorText = this.PanelColors.PanderPanelWCaptionText;
                foreColorExpandIcon = colorText;

                RenderFlatButtonBackground(graphics, captionRectangle, colorFlatGradientBegin, colorFlatGradientEnd, bHover);
                DrawInnerBorders(graphics, this);
            }

            DrawImagesAndText(
                graphics,
                captionRectangle,
                CaptionSpacing,
                this.ImageRectangle,
                this.Image,
                this.RightToLeft,
                this.m_bIsClosable,
                this.ShowCloseIcon,
                this.m_imageClosePanel,
                foreColorCloseIcon,
                ref this.RectangleCloseIcon,
                this.ShowExpandIcon,
                this.m_imageChevron,
                foreColorExpandIcon,
                ref this.RectangleExpandIcon,
                this.CaptionFont,
                colorText,
                this.Text);
        }

        private static void DrawBorders(Graphics graphics, PanderPanelW PanderPanelW)
        {
            if (PanderPanelW.ShowBorder == true)
            {
                using (GraphicsPath graphicsPath = new GraphicsPath())
                {
                    using (Pen borderPen = new Pen(PanderPanelW.PanelColors.BorderColor, Constants.BorderThickness))
                    {
                        Rectangle captionRectangle = PanderPanelW.CaptionRectangle;
                        Rectangle borderRectangle = captionRectangle;

                        if (PanderPanelW.Expand == true)
                        {
                            borderRectangle = PanderPanelW.ClientRectangle;

                            graphics.DrawLine(
                                borderPen,
                                captionRectangle.Left,
                                captionRectangle.Top + captionRectangle.Height - Constants.BorderThickness,
                                captionRectangle.Left + captionRectangle.Width,
                                captionRectangle.Top + captionRectangle.Height - Constants.BorderThickness);
                        }

                        PanderPanelListW PanderPanelListW = PanderPanelW.Parent as PanderPanelListW;
                        if ((PanderPanelListW != null) && (PanderPanelListW.Dock == DockStyle.Fill))
                        {
                            XiaoCai.WinformUI.Panels.PanelW panel = PanderPanelListW.Parent as XiaoCai.WinformUI.Panels.PanelW;
                            PanderPanelW parentPanderPanelW = PanderPanelListW.Parent as PanderPanelW;
                            if (((panel != null) && (panel.Padding == new Padding(0))) ||
                                ((parentPanderPanelW != null) && (parentPanderPanelW.Padding == new Padding(0))))
                            {
                                if (PanderPanelW.Top != 0)
                                {
                                    graphicsPath.AddLine(
                                        borderRectangle.Left,
                                        borderRectangle.Top,
                                        borderRectangle.Left + captionRectangle.Width,
                                        borderRectangle.Top);
                                }

                                // Left vertical borderline
                                graphics.DrawLine(borderPen,
                                    borderRectangle.Left,
                                    borderRectangle.Top,
                                    borderRectangle.Left,
                                    borderRectangle.Top + borderRectangle.Height);

                                // Right vertical borderline
                                graphics.DrawLine(borderPen,
                                    borderRectangle.Left + borderRectangle.Width - Constants.BorderThickness,
                                    borderRectangle.Top,
                                    borderRectangle.Left + borderRectangle.Width - Constants.BorderThickness,
                                    borderRectangle.Top + borderRectangle.Height);
                            }
                            else
                            {
                                // Upper horizontal borderline only at the top PanderPanelW
                                if (PanderPanelW.Top == 0)
                                {
                                    graphicsPath.AddLine(
                                        borderRectangle.Left,
                                        borderRectangle.Top,
                                        borderRectangle.Left + borderRectangle.Width,
                                        borderRectangle.Top);
                                }

                                // Left vertical borderline
                                graphicsPath.AddLine(
                                    borderRectangle.Left,
                                    borderRectangle.Top,
                                    borderRectangle.Left,
                                    borderRectangle.Top + borderRectangle.Height);

                                //Lower horizontal borderline
                                graphicsPath.AddLine(
                                    borderRectangle.Left,
                                    borderRectangle.Top + borderRectangle.Height - Constants.BorderThickness,
                                    borderRectangle.Left + borderRectangle.Width - Constants.BorderThickness,
                                    borderRectangle.Top + borderRectangle.Height - Constants.BorderThickness);

                                // Right vertical borderline
                                graphicsPath.AddLine(
                                    borderRectangle.Left + borderRectangle.Width - Constants.BorderThickness,
                                    borderRectangle.Top,
                                    borderRectangle.Left + borderRectangle.Width - Constants.BorderThickness,
                                    borderRectangle.Top + borderRectangle.Height);
                            }
                        }
                        else
                        {
                            // Upper horizontal borderline only at the top PanderPanelW
                            if (PanderPanelW.Top == 0)
                            {
                                graphicsPath.AddLine(
                                    borderRectangle.Left,
                                    borderRectangle.Top,
                                    borderRectangle.Left + borderRectangle.Width,
                                    borderRectangle.Top);
                            }

                            // Left vertical borderline
                            graphicsPath.AddLine(
                                borderRectangle.Left,
                                borderRectangle.Top,
                                borderRectangle.Left,
                                borderRectangle.Top + borderRectangle.Height);

                            //Lower horizontal borderline
                            graphicsPath.AddLine(
                                borderRectangle.Left,
                                borderRectangle.Top + borderRectangle.Height - Constants.BorderThickness,
                                borderRectangle.Left + borderRectangle.Width - Constants.BorderThickness,
                                borderRectangle.Top + borderRectangle.Height - Constants.BorderThickness);

                            // Right vertical borderline
                            graphicsPath.AddLine(
                                borderRectangle.Left + borderRectangle.Width - Constants.BorderThickness,
                                borderRectangle.Top,
                                borderRectangle.Left + borderRectangle.Width - Constants.BorderThickness,
                                borderRectangle.Top + borderRectangle.Height);
                        }
                    }
                    using (Pen borderPen = new Pen(PanderPanelW.PanelColors.BorderColor, Constants.BorderThickness))
                    {
                        graphics.DrawPath(borderPen, graphicsPath);
                    }
                }
            }
        }


        private static void DrawInnerBorders(Graphics graphics, PanderPanelW PanderPanelW)
        {
            if (PanderPanelW.ShowBorder == true)
            {
                using (GraphicsPath graphicsPath = new GraphicsPath())
                {
                    Rectangle captionRectangle = PanderPanelW.CaptionRectangle;
                    PanderPanelListW PanderPanelListW = PanderPanelW.Parent as PanderPanelListW;
                    if ((PanderPanelListW != null) && (PanderPanelListW.Dock == DockStyle.Fill))
                    {
                        XiaoCai.WinformUI.Panels.PanelW panel = PanderPanelListW.Parent as XiaoCai.WinformUI.Panels.PanelW;
                        PanderPanelW parentPanderPanelW = PanderPanelListW.Parent as PanderPanelW;
                        if (((panel != null) && (panel.Padding == new Padding(0))) ||
                            ((parentPanderPanelW != null) && (parentPanderPanelW.Padding == new Padding(0))))
                        {
                            //Left vertical borderline
                            graphicsPath.AddLine(captionRectangle.X, captionRectangle.Y + captionRectangle.Height, captionRectangle.X, captionRectangle.Y + Constants.BorderThickness);
                            if (PanderPanelW.Top == 0)
                            {
                                //Upper horizontal borderline
                                graphicsPath.AddLine(captionRectangle.X, captionRectangle.Y, captionRectangle.X + captionRectangle.Width, captionRectangle.Y);
                            }
                            else
                            {
                                //Upper horizontal borderline
                                graphicsPath.AddLine(captionRectangle.X, captionRectangle.Y + Constants.BorderThickness, captionRectangle.X + captionRectangle.Width, captionRectangle.Y + Constants.BorderThickness);
                            }
                        }
                    }
                    else
                    {
                        //Left vertical borderline
                        graphicsPath.AddLine(captionRectangle.X + Constants.BorderThickness, captionRectangle.Y + captionRectangle.Height, captionRectangle.X + Constants.BorderThickness, captionRectangle.Y);
                        if (PanderPanelW.Top == 0)
                        {
                            //Upper horizontal borderline
                            graphicsPath.AddLine(captionRectangle.X + Constants.BorderThickness, captionRectangle.Y + Constants.BorderThickness, captionRectangle.X + captionRectangle.Width - Constants.BorderThickness, captionRectangle.Y + Constants.BorderThickness);
                        }
                        else
                        {
                            //Upper horizontal borderline
                            graphicsPath.AddLine(captionRectangle.X + Constants.BorderThickness, captionRectangle.Y, captionRectangle.X + captionRectangle.Width - Constants.BorderThickness, captionRectangle.Y);
                        }
                    }

                    using (Pen borderPen = new Pen(PanderPanelW.PanelColors.InnerBorderColor))
                    {
                        graphics.DrawPath(borderPen, graphicsPath);
                    }
                }
            }
        }

		private void CalculatePanelHeights()
		{
			if (this.Parent == null)
			{
				return;
			}

            int iPanelHeight = this.Parent.Padding.Top;

            foreach (Control control in this.Parent.Controls)
            {
				XiaoCai.WinformUI.Panels.PanderPanelW PanderPanelW =
					control as XiaoCai.WinformUI.Panels.PanderPanelW;

                if ((PanderPanelW != null) && (PanderPanelW.Visible == true))
                {
                    iPanelHeight += PanderPanelW.CaptionHeight;
                }
            }

			iPanelHeight += this.Parent.Padding.Bottom;

            foreach (Control control in this.Parent.Controls)
			{
				XiaoCai.WinformUI.Panels.PanderPanelW PanderPanelW =
					control as XiaoCai.WinformUI.Panels.PanderPanelW;

                if (PanderPanelW != null)
                {
                    if (PanderPanelW.Expand == true)
                    {
                        PanderPanelW.Height = this.Parent.Height
                            + PanderPanelW.CaptionHeight
                            - iPanelHeight;
                    }
                    else
                    {
                        PanderPanelW.Height = PanderPanelW.CaptionHeight;
                    }
                }
			}

			int iTop = this.Parent.Padding.Top;
			foreach (Control control in this.Parent.Controls)
			{
				XiaoCai.WinformUI.Panels.PanderPanelW PanderPanelW =
					control as XiaoCai.WinformUI.Panels.PanderPanelW;

                if ((PanderPanelW != null) && (PanderPanelW.Visible == true))
                {
                    PanderPanelW.Top = iTop;
                    iTop += PanderPanelW.Height;
                }
			}
		}

		#endregion
    }

    #endregion

    #region Class PanderPanelWDesigner
    /// <summary>
    /// Designer class for extending the design mode behavior of a PanderPanelW control
    /// </summary>
	internal class PanderPanelWDesigner : System.Windows.Forms.Design.ScrollableControlDesigner
	{
		#region FieldsPrivate

		private Pen m_borderPen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark));
        private System.Windows.Forms.Design.Behavior.Adorner m_adorner;

		#endregion

		#region MethodsPublic
		/// <summary>
        /// Initializes a new instance of the PanderPanelWDesigner class.
		/// </summary>
		public PanderPanelWDesigner()
		{
			this.m_borderPen.DashStyle = DashStyle.Dash;
		}
		/// <summary>
		/// Initializes the designer with the specified component.
		/// </summary>
		/// <param name="component">The IComponent to associate with the designer.</param>
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
            PanderPanelW PanderPanelW = Control as PanderPanelW;
            if (PanderPanelW != null)
            {
                this.m_adorner = new System.Windows.Forms.Design.Behavior.Adorner();
                BehaviorService.Adorners.Add(this.m_adorner);
                this.m_adorner.Glyphs.Add(new PanderPanelWCaptionGlyph(BehaviorService, PanderPanelW));
            }
		}
		#endregion

		#region MethodsProtected
        /// <summary>
        /// Releases the unmanaged resources used by the PanderPanelWDesigner,
        /// and optionally releases the managed resources. 
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources;
        /// false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
			try
			{
				if (disposing)
				{
					if (this.m_borderPen != null)
					{
						this.m_borderPen.Dispose();
					}
					if (this.m_adorner != null)
					{
						if (BehaviorService != null)
						{
							BehaviorService.Adorners.Remove(this.m_adorner);
						}
					}
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
        }
		/// <summary>
		/// Receives a call when the control that the designer is managing has painted its surface so the designer can
		/// paint any additional adornments on top of the PanderPanelW.
		/// </summary>
		/// <param name="e">A PaintEventArgs the designer can use to draw on the PanderPanelW.</param>
		protected override void OnPaintAdornments(PaintEventArgs e)
		{
			base.OnPaintAdornments(e);
			e.Graphics.DrawRectangle(
				this.m_borderPen,
				0,
				0,
				this.Control.Width - 2,
				this.Control.Height - 2);
		}
		/// <summary>
		/// Allows a designer to change or remove items from the set of properties that it exposes through a <see cref="TypeDescriptor">TypeDescriptor</see>. 
		/// </summary>
		/// <param name="properties">The properties for the class of the component.</param>
		protected override void PostFilterProperties(IDictionary properties)
		{
			base.PostFilterProperties(properties);
			properties.Remove("AccessibilityObject");
			properties.Remove("AccessibleDefaultActionDescription");
			properties.Remove("AccessibleDescription");
			properties.Remove("AccessibleName");
			properties.Remove("AccessibleRole");
			properties.Remove("AllowDrop");
            properties.Remove("Anchor");
            properties.Remove("AntiAliasing");
			properties.Remove("AutoScroll");
			properties.Remove("AutoScrollMargin");
			properties.Remove("AutoScrollMinSize");
            properties.Remove("BackColor");
            properties.Remove("BackgroundImage");
			properties.Remove("BackgroundImageLayout");
			properties.Remove("CausesValidation");
			properties.Remove("ContextMenuStrip");
			properties.Remove("Dock");
			properties.Remove("GenerateMember");
			properties.Remove("ImeMode");
            properties.Remove("Location");
			properties.Remove("MaximumSize");
			properties.Remove("MinimumSize");
		}

		#endregion
    }
    #endregion

    #region Class PanderPanelWCaptionGlyph
    /// <summary>
    /// Represents a single user interface (UI) entity managed by an Adorner.
    /// </summary>
    internal class PanderPanelWCaptionGlyph : System.Windows.Forms.Design.Behavior.Glyph
    {
        #region FieldsPrivate

        private PanderPanelW m_PanderPanelW;
        private System.Windows.Forms.Design.Behavior.BehaviorService m_behaviorService;

        #endregion

        #region Properties
        /// <summary>
        /// Gets the bounds of the Glyph.
        /// </summary>
        public override Rectangle Bounds
        {
            get
            {
                Point edge = this.m_behaviorService.ControlToAdornerWindow(this.m_PanderPanelW);
                Rectangle bounds = new Rectangle(
                    edge.X,
                    edge.Y,
                    this.m_PanderPanelW.Width,
                    this.m_PanderPanelW.CaptionHeight);

                return bounds;
            }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the CaptionGlyph class.
        /// </summary>
        /// <param name="behaviorService"></param>
        /// <param name="PanderPanelW"></param>
        public PanderPanelWCaptionGlyph(System.Windows.Forms.Design.Behavior.BehaviorService behaviorService, PanderPanelW PanderPanelW)
            :
            base(new PanderPanelWCaptionClickBehavior(PanderPanelW))
        {
            this.m_behaviorService = behaviorService;
            this.m_PanderPanelW = PanderPanelW;
        }
        /// <summary>
        /// Provides hit test logic.
        /// </summary>
        /// <param name="p">A point to hit-test.</param>
        /// <returns>A Cursor if the Glyph is associated with p; otherwise, a null reference</returns>
        public override Cursor GetHitTest(Point p)
        {
            // GetHitTest is called to see if the point is
            // within this glyph.  This gives us a chance to decide
            // what cursor to show.  Returning null from here means
            // the mouse pointer is not currently inside of the glyph.
            // Returning a valid cursor here indicates the pointer is
            // inside the glyph, and also enables our Behavior property
            // as the active behavior.
            if ((this.m_PanderPanelW != null) && (this.m_PanderPanelW.Expand == false) && (Bounds.Contains(p)))
            {
                return Cursors.Hand;
            }

            return null;
        }
        /// <summary>
        /// Provides paint logic.
        /// </summary>
        /// <param name="pe">A PaintEventArgs that contains the event data.</param>
        public override void Paint(PaintEventArgs pe)
        {
        }

        #endregion
    }

    #endregion

    #region Class PanderPanelWCaptionClickBehavior
    /// <summary>
    /// Designer behaviour when the user clicks in the glyph on the PanderPanelW caption
    /// </summary>
    internal class PanderPanelWCaptionClickBehavior : System.Windows.Forms.Design.Behavior.Behavior
    {
        #region FieldsPrivate
        private PanderPanelW m_PanderPanelW;
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the Behavior class.
        /// </summary>
        /// <param name="PanderPanelW">PanderPanelW for this behaviour</param>
        public PanderPanelWCaptionClickBehavior(PanderPanelW PanderPanelW)
        {
            this.m_PanderPanelW = PanderPanelW;
        }
        /// <summary>
        /// Called when any mouse-down message enters the adorner window of the BehaviorService. 
        /// </summary>
        /// <param name="g">A Glyph.</param>
        /// <param name="button">A MouseButtons value indicating which button was clicked.</param>
        /// <param name="mouseLoc">The location at which the click occurred.</param>
        /// <returns>true if the message was handled; otherwise, false. </returns>
		public override bool OnMouseDown(System.Windows.Forms.Design.Behavior.Glyph g, MouseButtons button, Point mouseLoc)
		{
			if ((this.m_PanderPanelW != null) && (this.m_PanderPanelW.Expand == false))
			{
				PanderPanelListW PanderPanelListW = this.m_PanderPanelW.Parent as PanderPanelListW;
				if (PanderPanelListW != null)
				{
					PanderPanelListW.Expand(this.m_PanderPanelW);
					this.m_PanderPanelW.Invalidate(false);
				}
			}
			return true; // indicating we processed this event.
		}
        #endregion
    }

    #endregion
}
