using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace XiaoCai.WinformUI.Panels
{
	public class PanelColorsOffice : PanelColors
    {
        #region Properties
        /// <summary>
        /// Gets the associated PanelStyle for the XPanderControls
        /// </summary>
        public override PanelStyle PanelStyle
        {
            get { return PanelStyle.Office2007; }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
		/// Initialize a new instance of the PanelColorsOffice class.
        /// </summary>
        public PanelColorsOffice()
			: base()
		{
		}
        /// <summary>
		/// Initialize a new instance of the PanelColorsOffice class.
        /// </summary>
        /// <param name="basePanel">Base class for the panel or PanderPanelW control.</param>
		public PanelColorsOffice(BasePanel basePanel)
            : base(basePanel)
        {
        }
        #endregion
		
		#region MethodsProtected
		/// <summary>
		/// Initialize a color Dictionary with defined Office2007 colors
		/// </summary>
		/// <param name="rgbTable">Dictionary with defined colors</param>
		protected override void InitColors(Dictionary<KnownColors, System.Drawing.Color> rgbTable)
		{
			base.InitColors(rgbTable);
            rgbTable[KnownColors.PanelCaptionSelectedGradientBegin] = Color.FromArgb(255, 255, 220);
            rgbTable[KnownColors.PanelCaptionSelectedGradientEnd] = Color.FromArgb(247, 193, 94);
            rgbTable[KnownColors.PanderPanelWCheckedCaptionBegin] = Color.FromArgb(255, 217, 170);
            rgbTable[KnownColors.PanderPanelWCheckedCaptionEnd] = Color.FromArgb(254, 225, 122);
            rgbTable[KnownColors.PanderPanelWCheckedCaptionMiddle] = Color.FromArgb(255, 171, 63);
            rgbTable[KnownColors.PanderPanelWPressedCaptionBegin] = Color.FromArgb(255, 189, 105);
            rgbTable[KnownColors.PanderPanelWPressedCaptionEnd] = Color.FromArgb(254, 211, 100);
            rgbTable[KnownColors.PanderPanelWPressedCaptionMiddle] = Color.FromArgb(251, 140, 60);
            rgbTable[KnownColors.PanderPanelWSelectedCaptionBegin] = Color.FromArgb(255, 252, 222);
			rgbTable[KnownColors.PanderPanelWSelectedCaptionEnd] = Color.FromArgb(255, 230, 158);
			rgbTable[KnownColors.PanderPanelWSelectedCaptionMiddle] = Color.FromArgb(255, 215, 103);
			rgbTable[KnownColors.PanderPanelWSelectedCaptionText] = Color.Black;
		}
		#endregion
	}
}
