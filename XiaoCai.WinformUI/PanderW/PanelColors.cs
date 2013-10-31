using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace XiaoCai.WinformUI.Panels
{
    public class PanelColors
    {
		#region Enums
		/// <summary>
		/// Gets or sets the KnownColors appearance of the ProfessionalColorTable.
		/// </summary>
		public enum KnownColors
		{
			/// <summary>
			/// The border color of the panel.
			/// </summary>
			BorderColor,
			/// <summary>
			/// The forecolor of a close icon in a Panel.
			/// </summary>
            PanelCaptionCloseIcon,
            /// <summary>
			/// The forecolor of a expand icon in a Panel.
            /// </summary>
			PanelCaptionExpandIcon,
			/// <summary>
			/// The starting color of the gradient of the Panel.
			/// </summary>
            PanelCaptionGradientBegin,
			/// <summary>
			/// The end color of the gradient of the Panel.
			/// </summary>
			PanelCaptionGradientEnd,
			/// <summary>
			/// The middle color of the gradient of the Panel.
			/// </summary>
			PanelCaptionGradientMiddle,
            /// <summary>
            /// The starting color of the gradient used when the hover icon in the captionbar on the Panel is selected.
            /// </summary>
            PanelCaptionSelectedGradientBegin,
            /// <summary>
            /// The end color of the gradient used when the hover icon in the captionbar on the Panel is selected.
            /// </summary>
            PanelCaptionSelectedGradientEnd,
			/// <summary>
			/// The starting color of the gradient used in the Panel.
			/// </summary>
			PanelContentGradientBegin,
			/// <summary>
			/// The end color of the gradient used in the Panel.
			/// </summary>
			PanelContentGradientEnd,
			/// <summary>
			/// The text color of a Panel.
			/// </summary>
			PanelCaptionText,
			/// <summary>
			/// The text color of a Panel when it's collapsed.
			/// </summary>
            PanelCollapsedCaptionText,
			/// <summary>
			/// The inner border color of a Panel.
			/// </summary>
			InnerBorderColor,
			/// <summary>
			/// The backcolor of a PanderPanelW.
			/// </summary>
            PanderPanelWBackColor,
			/// <summary>
			/// The forecolor of a close icon in a PanderPanelW.
			/// </summary>
			PanderPanelWCaptionCloseIcon,
			/// <summary>
			/// The forecolor of a expand icon in a PanderPanelW.
			/// </summary>
			PanderPanelWCaptionExpandIcon,
			/// <summary>
			/// The text color of a PanderPanelW.
			/// </summary>
			PanderPanelWCaptionText,
			/// <summary>
			/// The starting color of the gradient of the PanderPanelW.
			/// </summary>
			PanderPanelWCaptionGradientBegin,
			/// <summary>
			/// The end color of the gradient of the PanderPanelW.
			/// </summary>
			PanderPanelWCaptionGradientEnd,
			/// <summary>
			/// The middle color of the gradient of the PanderPanelW.
			/// </summary>
			PanderPanelWCaptionGradientMiddle,
            /// <summary>
            /// The starting color of the gradient of a flat PanderPanelW.
            /// </summary>
            PanderPanelWFlatCaptionGradientBegin,
            /// <summary>
            /// The end color of the gradient of a flat PanderPanelW.
            /// </summary>
            PanderPanelWFlatCaptionGradientEnd,
            /// <summary>
            /// The starting color of the gradient used when the PanderPanelW is pressed down.
            /// </summary>
            PanderPanelWPressedCaptionBegin,
            /// <summary>
            /// The end color of the gradient used when the PanderPanelW is pressed down.
            /// </summary>
            PanderPanelWPressedCaptionEnd,
            /// <summary>
            /// The middle color of the gradient used when the PanderPanelW is pressed down.
            /// </summary>
            PanderPanelWPressedCaptionMiddle,
            /// <summary>
            /// The starting color of the gradient used when the PanderPanelW is checked.
            /// </summary>
            PanderPanelWCheckedCaptionBegin,
            /// <summary>
            /// The end color of the gradient used when the PanderPanelW is checked.
            /// </summary>
            PanderPanelWCheckedCaptionEnd,
            /// <summary>
            /// The middle color of the gradient used when the PanderPanelW is checked.
            /// </summary>
            PanderPanelWCheckedCaptionMiddle,
            /// <summary>
			/// The starting color of the gradient used when the PanderPanelW is selected.
			/// </summary>
			PanderPanelWSelectedCaptionBegin,
			/// <summary>
			/// The end color of the gradient used when the PanderPanelW is selected.
			/// </summary>
			PanderPanelWSelectedCaptionEnd,
			/// <summary>
			/// The middle color of the gradient used when the PanderPanelW is selected.
			/// </summary>
			PanderPanelWSelectedCaptionMiddle,
			/// <summary>
			/// The text color used when the PanderPanelW is selected.
			/// </summary>
			PanderPanelWSelectedCaptionText
		}
		#endregion

        #region FieldsPrivate

        private BasePanel m_basePanel;
		private System.Windows.Forms.ProfessionalColorTable m_professionalColorTable;
		private Dictionary<KnownColors, Color> m_dictionaryRGBTable;
		private bool m_bUseSystemColors;

        #endregion

        #region Properties
        /// <summary>
        /// Gets the border color of a Panel or PanderPanelW.
        /// </summary>
        public virtual Color BorderColor
        {
			get { return this.FromKnownColor(KnownColors.BorderColor); }
        }
        /// <summary>
        /// Gets the forecolor of a close icon in a Panel.
        /// </summary>
        public virtual Color PanelCaptionCloseIcon
        {
            get { return this.FromKnownColor(KnownColors.PanelCaptionCloseIcon); }
        }
        /// <summary>
        /// Gets the forecolor of an expand icon in a Panel.
        /// </summary>
        public virtual Color PanelCaptionExpandIcon
        {
            get { return this.FromKnownColor(KnownColors.PanelCaptionExpandIcon); }
        }
        /// <summary>
        /// Gets the starting color of the gradient of the Panel.
        /// </summary>
        public virtual Color PanelCaptionGradientBegin
        {
			get { return this.FromKnownColor(KnownColors.PanelCaptionGradientBegin); }
        }
		/// <summary>
        /// Gets the end color of the gradient of the Panel.
        /// </summary>
        public virtual Color PanelCaptionGradientEnd
        {
            get { return this.FromKnownColor(KnownColors.PanelCaptionGradientEnd); }
        }
		/// <summary>
        /// Gets the middle color of the gradient of the Panel.
        /// </summary>
        public virtual Color PanelCaptionGradientMiddle
        {
			get { return this.FromKnownColor(KnownColors.PanelCaptionGradientMiddle); }
        }
        /// <summary>
        /// Gets the starting color of the gradient used when the hover icon in the captionbar on the Panel is selected.
        /// </summary>
        public virtual Color PanelCaptionSelectedGradientBegin
        {
            get { return this.FromKnownColor(KnownColors.PanelCaptionSelectedGradientBegin); }
        }
        /// <summary>
        /// Gets the end color of the gradient used when the hover icon in the captionbar on the Panel is selected.
        /// </summary>
        public virtual Color PanelCaptionSelectedGradientEnd
        {
            get { return this.FromKnownColor(KnownColors.PanelCaptionSelectedGradientEnd); }
        }
        /// <summary>
        /// Gets the text color of a Panel.
        /// </summary>
        public virtual Color PanelCaptionText
		{
			get { return this.FromKnownColor(KnownColors.PanelCaptionText); }
		}
        /// <summary>
        /// Gets the text color of a Panel when it's collapsed.
        /// </summary>
        public virtual Color PanelCollapsedCaptionText
        {
            get { return this.FromKnownColor(KnownColors.PanelCollapsedCaptionText); }
        }
        /// <summary>
        /// Gets the starting color of the gradient used in the Panel.
        /// </summary>
        public virtual Color PanelContentGradientBegin
        {
			get { return this.FromKnownColor(KnownColors.PanelContentGradientBegin); }
        }
		/// <summary>
        /// Gets the end color of the gradient used in the Panel.
        /// </summary>
        public virtual Color PanelContentGradientEnd
        {
			get { return this.FromKnownColor(KnownColors.PanelContentGradientEnd); }
        }
        /// <summary>
        /// Gets the inner border color of a Panel.
        /// </summary>
        public virtual Color InnerBorderColor
        {
            get { return this.FromKnownColor(KnownColors.InnerBorderColor); }
        }
		/// <summary>
		/// Gets the backcolor of a PanderPanelW.
		/// </summary>
        public virtual Color PanderPanelWBackColor
		{
			get { return this.FromKnownColor(KnownColors.PanderPanelWBackColor); }
		}
        /// <summary>
		/// Gets the forecolor of a close icon in a PanderPanelW.
		/// </summary>
        public virtual Color PanderPanelWCaptionCloseIcon
		{
			get { return this.FromKnownColor(KnownColors.PanderPanelWCaptionCloseIcon); }
		}
        /// <summary>
		/// Gets the forecolor of an expand icon in a PanderPanelW.
		/// </summary>
        public virtual Color PanderPanelWCaptionExpandIcon
		{
			get { return this.FromKnownColor(KnownColors.PanderPanelWCaptionExpandIcon); }
		}
        /// <summary>
        /// Gets the starting color of the gradient of the PanderPanelW.
        /// </summary>
        public virtual Color PanderPanelWCaptionGradientBegin
        {
            get { return this.FromKnownColor(KnownColors.PanderPanelWCaptionGradientBegin); }
        }
        /// <summary>
        /// Gets the end color of the gradient of the PanderPanelW.
        /// </summary>
        public virtual Color PanderPanelWCaptionGradientEnd
        {
            get { return this.FromKnownColor(KnownColors.PanderPanelWCaptionGradientEnd); }
        }
        /// <summary>
        /// Gets the middle color of the gradient on the PanderPanelW captionbar.
        /// </summary>
        public virtual Color PanderPanelWCaptionGradientMiddle
        {
            get { return this.FromKnownColor(KnownColors.PanderPanelWCaptionGradientMiddle); }
        }
        /// <summary>
        /// Gets the text color of a PanderPanelW.
        /// </summary>
        public virtual Color PanderPanelWCaptionText
        {
			get { return this.FromKnownColor(KnownColors.PanderPanelWCaptionText); }
        }
        /// <summary>
        /// Gets the starting color of the gradient on a flat PanderPanelW captionbar.
        /// </summary>
        public virtual Color PanderPanelWFlatCaptionGradientBegin
        {
            get { return this.FromKnownColor(KnownColors.PanderPanelWFlatCaptionGradientBegin); }
        }
        /// <summary>
        /// Gets the end color of the gradient on a flat PanderPanelW captionbar.
        /// </summary>
        public virtual Color PanderPanelWFlatCaptionGradientEnd
        {
            get { return this.FromKnownColor(KnownColors.PanderPanelWFlatCaptionGradientEnd); }
        }
        /// <summary>
        /// Gets the starting color of the gradient used when the PanderPanelW is pressed down.
        /// </summary>
        public virtual Color PanderPanelWPressedCaptionBegin
        {
            get { return this.FromKnownColor(KnownColors.PanderPanelWPressedCaptionBegin); }
        }
        /// <summary>
        /// Gets the end color of the gradient used when the PanderPanelW is pressed down.
        /// </summary>
        public virtual Color PanderPanelWPressedCaptionEnd
        {
            get { return this.FromKnownColor(KnownColors.PanderPanelWPressedCaptionEnd); }
        }
        /// <summary>
        /// Gets the middle color of the gradient used when the PanderPanelW is pressed down.
        /// </summary>
        public virtual Color PanderPanelWPressedCaptionMiddle
        {
            get { return this.FromKnownColor(KnownColors.PanderPanelWPressedCaptionMiddle); }
        }
        /// <summary>
        /// Gets the starting color of the gradient used when the PanderPanelW is checked.
        /// </summary>
        public virtual Color PanderPanelWCheckedCaptionBegin
        {
            get { return this.FromKnownColor(KnownColors.PanderPanelWCheckedCaptionBegin); }
        }
        /// <summary>
        /// Gets the end color of the gradient used when the PanderPanelW is checked.
        /// </summary>
        public virtual Color PanderPanelWCheckedCaptionEnd
        {
            get { return this.FromKnownColor(KnownColors.PanderPanelWCheckedCaptionEnd); }
        }
        /// <summary>
        /// Gets the middle color of the gradient used when the PanderPanelW is checked.
        /// </summary>
        public virtual Color PanderPanelWCheckedCaptionMiddle
        {
            get { return this.FromKnownColor(KnownColors.PanderPanelWCheckedCaptionMiddle); }
        }
        /// <summary>
        /// Gets the starting color of the gradient used when the PanderPanelW is selected.
        /// </summary>
        public virtual Color PanderPanelWSelectedCaptionBegin
        {
			get { return this.FromKnownColor(KnownColors.PanderPanelWSelectedCaptionBegin); }
        }
        /// <summary>
        /// Gets the end color of the gradient used when the PanderPanelW is selected.
        /// </summary>
        public virtual Color PanderPanelWSelectedCaptionEnd
        {
			get { return this.FromKnownColor(KnownColors.PanderPanelWSelectedCaptionEnd); }
        }
        /// <summary>
        /// Gets the middle color of the gradient used when the PanderPanelW is selected.
        /// </summary>
        public virtual Color PanderPanelWSelectedCaptionMiddle
        {
			get { return this.FromKnownColor(KnownColors.PanderPanelWSelectedCaptionMiddle); }
        }
        /// <summary>
        /// Gets the text color used when the PanderPanelW is selected.
        /// </summary>
        public virtual Color PanderPanelWSelectedCaptionText
        {
			get { return this.FromKnownColor(KnownColors.PanderPanelWSelectedCaptionText); }
        }
        /// <summary>
        /// Gets the associated PanelStyle for the XPanderControls
        /// </summary>
        public virtual PanelStyle PanelStyle
        {
            get { return PanelStyle.Default; }
        }
		/// <summary>
		/// Gets or sets a value indicating whether to use System.Drawing.SystemColors rather than colors that match the current visual style.
		/// </summary>
        public bool UseSystemColors
		{
			get { return this.m_bUseSystemColors; }
			set
			{
				if (value.Equals(this.m_bUseSystemColors) == false)
				{
					this.m_bUseSystemColors = value;
					this.m_professionalColorTable.UseSystemColors = this.m_bUseSystemColors;
                    Clear();
				}
			}
		}
        /// <summary>
        /// Gets or sets the panel or PanderPanelW
        /// </summary>
        public BasePanel Panel
		{
			get { return this.m_basePanel; }
			set { this.m_basePanel = value; }
		}
		internal Color FromKnownColor(KnownColors color)
		{
			return (Color)this.ColorTable[color];
		}
        private Dictionary<KnownColors, Color> ColorTable
        {
            get
            {
                if (this.m_dictionaryRGBTable == null)
                {
                    this.m_dictionaryRGBTable = new Dictionary<KnownColors, Color>(0xd4);
                    if ((this.m_basePanel != null) && (this.m_basePanel.ColorScheme == ColorScheme.Professional))
                    {
                        if ((this.m_bUseSystemColors == true) || (ToolStripManager.VisualStylesEnabled == false))
                        {
                            InitBaseColors(this.m_dictionaryRGBTable);
                        }
                        else
                        {
                            InitColors(this.m_dictionaryRGBTable);
                        }
                    }
                    else
                    {
                        InitCustomColors(this.m_dictionaryRGBTable);
                    }
                }
                return this.m_dictionaryRGBTable;
            }
        }

        #endregion

        #region MethodsPublic
		/// <summary>
		/// Initializes a new instance of the PanelColors class.
		/// </summary>
		public PanelColors()
		{
			this.m_professionalColorTable = new System.Windows.Forms.ProfessionalColorTable();
		}
		/// <summary>
        /// Initialize a new instance of the PanelColors class.
        /// </summary>
        /// <param name="basePanel">Base class for the panel or PanderPanelW control.</param>
        public PanelColors(BasePanel basePanel) : this()
        {
            this.m_basePanel = basePanel;
        }
        /// <summary>
        /// Clears the current color table
        /// </summary>
		public void Clear()
        {
            ResetRGBTable();
        }
        #endregion

		#region MethodsProtected
		/// <summary>
		/// Initialize a color Dictionary with defined colors
		/// </summary>
		/// <param name="rgbTable">Dictionary with defined colors</param>
		protected virtual void InitColors(Dictionary<KnownColors, Color> rgbTable)
		{
			InitBaseColors(rgbTable);
		}
		#endregion

        #region MethodsPrivate

		private void InitBaseColors(Dictionary<KnownColors, Color> rgbTable)
		{
            rgbTable[KnownColors.BorderColor] = this.m_professionalColorTable.GripDark;
            rgbTable[KnownColors.InnerBorderColor] = this.m_professionalColorTable.GripLight;
            rgbTable[KnownColors.PanelCaptionCloseIcon] = SystemColors.ControlText;
            rgbTable[KnownColors.PanelCaptionExpandIcon] = SystemColors.ControlText;
            rgbTable[KnownColors.PanelCaptionGradientBegin] = this.m_professionalColorTable.ToolStripGradientBegin;
            rgbTable[KnownColors.PanelCaptionGradientEnd] = this.m_professionalColorTable.ToolStripGradientEnd;
            rgbTable[KnownColors.PanelCaptionGradientMiddle] = this.m_professionalColorTable.ToolStripGradientMiddle;
            rgbTable[KnownColors.PanelCaptionSelectedGradientBegin] = this.m_professionalColorTable.ButtonSelectedGradientBegin;
            rgbTable[KnownColors.PanelCaptionSelectedGradientEnd] = this.m_professionalColorTable.ButtonSelectedGradientEnd;
            rgbTable[KnownColors.PanelContentGradientBegin] = this.m_professionalColorTable.ToolStripContentPanelGradientBegin;
			rgbTable[KnownColors.PanelContentGradientEnd] = this.m_professionalColorTable.ToolStripContentPanelGradientEnd;
			rgbTable[KnownColors.PanelCaptionText] = SystemColors.ControlText;
            rgbTable[KnownColors.PanelCollapsedCaptionText] = SystemColors.ControlText;
			rgbTable[KnownColors.PanderPanelWBackColor] = this.m_professionalColorTable.ToolStripContentPanelGradientBegin;
			rgbTable[KnownColors.PanderPanelWCaptionCloseIcon] = SystemColors.ControlText;
			rgbTable[KnownColors.PanderPanelWCaptionExpandIcon] = SystemColors.ControlText;
			rgbTable[KnownColors.PanderPanelWCaptionText] = SystemColors.ControlText;
			rgbTable[KnownColors.PanderPanelWCaptionGradientBegin] = this.m_professionalColorTable.ToolStripGradientBegin;
			rgbTable[KnownColors.PanderPanelWCaptionGradientEnd] = this.m_professionalColorTable.ToolStripGradientEnd;
			rgbTable[KnownColors.PanderPanelWCaptionGradientMiddle] = this.m_professionalColorTable.ToolStripGradientMiddle;
            rgbTable[KnownColors.PanderPanelWFlatCaptionGradientBegin] = this.m_professionalColorTable.ToolStripGradientMiddle;
            rgbTable[KnownColors.PanderPanelWFlatCaptionGradientEnd] = this.m_professionalColorTable.ToolStripGradientBegin;
            rgbTable[KnownColors.PanderPanelWPressedCaptionBegin] = this.m_professionalColorTable.ButtonPressedGradientBegin;
            rgbTable[KnownColors.PanderPanelWPressedCaptionEnd] = this.m_professionalColorTable.ButtonPressedGradientEnd;
            rgbTable[KnownColors.PanderPanelWPressedCaptionMiddle] = this.m_professionalColorTable.ButtonPressedGradientMiddle;
            rgbTable[KnownColors.PanderPanelWCheckedCaptionBegin] = this.m_professionalColorTable.ButtonCheckedGradientBegin;
            rgbTable[KnownColors.PanderPanelWCheckedCaptionEnd] = this.m_professionalColorTable.ButtonCheckedGradientEnd;
            rgbTable[KnownColors.PanderPanelWCheckedCaptionMiddle] = this.m_professionalColorTable.ButtonCheckedGradientMiddle;
            rgbTable[KnownColors.PanderPanelWSelectedCaptionBegin] = this.m_professionalColorTable.ButtonSelectedGradientBegin;
            rgbTable[KnownColors.PanderPanelWSelectedCaptionEnd] = this.m_professionalColorTable.ButtonSelectedGradientEnd;
            rgbTable[KnownColors.PanderPanelWSelectedCaptionMiddle] = this.m_professionalColorTable.ButtonSelectedGradientMiddle;
			rgbTable[KnownColors.PanderPanelWSelectedCaptionText] = SystemColors.ControlText;
		}

		private void InitCustomColors(Dictionary<KnownColors, Color> rgbTable)
		{
            PanelW panel = this.m_basePanel as PanelW;
            if (panel != null)
            {
                rgbTable[KnownColors.BorderColor] = panel.CustomColors.BorderColor;
                rgbTable[KnownColors.InnerBorderColor] = panel.CustomColors.InnerBorderColor;
                rgbTable[KnownColors.PanelCaptionCloseIcon] = panel.CustomColors.CaptionCloseIcon;
                rgbTable[KnownColors.PanelCaptionExpandIcon] = panel.CustomColors.CaptionExpandIcon;
                rgbTable[KnownColors.PanelCaptionGradientBegin] = panel.CustomColors.CaptionGradientBegin;
                rgbTable[KnownColors.PanelCaptionGradientEnd] = panel.CustomColors.CaptionGradientEnd;
                rgbTable[KnownColors.PanelCaptionGradientMiddle] = panel.CustomColors.CaptionGradientMiddle;
                rgbTable[KnownColors.PanelCaptionSelectedGradientBegin] = panel.CustomColors.CaptionSelectedGradientBegin;
                rgbTable[KnownColors.PanelCaptionSelectedGradientEnd] = panel.CustomColors.CaptionSelectedGradientEnd;
                rgbTable[KnownColors.PanelContentGradientBegin] = panel.CustomColors.ContentGradientBegin;
                rgbTable[KnownColors.PanelContentGradientEnd] = panel.CustomColors.ContentGradientEnd;
                rgbTable[KnownColors.PanelCaptionText] = panel.CustomColors.CaptionText;
                rgbTable[KnownColors.PanelCollapsedCaptionText] = panel.CustomColors.CollapsedCaptionText;
            }

			PanderPanelW PanderPanelW = this.m_basePanel as PanderPanelW;
			if (PanderPanelW != null)
			{
                rgbTable[KnownColors.BorderColor] = PanderPanelW.CustomColors.BorderColor;
                rgbTable[KnownColors.InnerBorderColor] = PanderPanelW.CustomColors.InnerBorderColor;
                rgbTable[KnownColors.PanderPanelWBackColor] = PanderPanelW.CustomColors.BackColor;
                rgbTable[KnownColors.PanderPanelWCaptionCloseIcon] = PanderPanelW.CustomColors.CaptionCloseIcon;
                rgbTable[KnownColors.PanderPanelWCaptionExpandIcon] = PanderPanelW.CustomColors.CaptionExpandIcon;
				rgbTable[KnownColors.PanderPanelWCaptionText] = PanderPanelW.CustomColors.CaptionText;
				rgbTable[KnownColors.PanderPanelWCaptionGradientBegin] = PanderPanelW.CustomColors.CaptionGradientBegin;
				rgbTable[KnownColors.PanderPanelWCaptionGradientEnd] = PanderPanelW.CustomColors.CaptionGradientEnd;
				rgbTable[KnownColors.PanderPanelWCaptionGradientMiddle] = PanderPanelW.CustomColors.CaptionGradientMiddle;
                rgbTable[KnownColors.PanderPanelWFlatCaptionGradientBegin] = PanderPanelW.CustomColors.FlatCaptionGradientBegin;
                rgbTable[KnownColors.PanderPanelWFlatCaptionGradientEnd] = PanderPanelW.CustomColors.FlatCaptionGradientEnd;
                rgbTable[KnownColors.PanderPanelWPressedCaptionBegin] = PanderPanelW.CustomColors.CaptionPressedGradientBegin;
                rgbTable[KnownColors.PanderPanelWPressedCaptionEnd] = PanderPanelW.CustomColors.CaptionPressedGradientEnd;
                rgbTable[KnownColors.PanderPanelWPressedCaptionMiddle] = PanderPanelW.CustomColors.CaptionPressedGradientMiddle;
                rgbTable[KnownColors.PanderPanelWCheckedCaptionBegin] = PanderPanelW.CustomColors.CaptionCheckedGradientBegin;
                rgbTable[KnownColors.PanderPanelWCheckedCaptionEnd] = PanderPanelW.CustomColors.CaptionCheckedGradientEnd;
                rgbTable[KnownColors.PanderPanelWCheckedCaptionMiddle] = PanderPanelW.CustomColors.CaptionCheckedGradientMiddle;
                rgbTable[KnownColors.PanderPanelWSelectedCaptionBegin] = PanderPanelW.CustomColors.CaptionSelectedGradientBegin;
				rgbTable[KnownColors.PanderPanelWSelectedCaptionEnd] = PanderPanelW.CustomColors.CaptionSelectedGradientEnd;
				rgbTable[KnownColors.PanderPanelWSelectedCaptionMiddle] = PanderPanelW.CustomColors.CaptionSelectedGradientMiddle;
				rgbTable[KnownColors.PanderPanelWSelectedCaptionText] = PanderPanelW.CustomColors.CaptionSelectedText;
			}
		}

        private void ResetRGBTable()
        {
            if (this.m_dictionaryRGBTable != null)
            {
                this.m_dictionaryRGBTable.Clear();
            }
            this.m_dictionaryRGBTable = null;
        }

        #endregion
    }
}
