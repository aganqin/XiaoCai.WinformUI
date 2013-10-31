using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace XiaoCai.WinformUI.Panels
{
	public class PanelColorsBse : PanelColors
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
		/// Initialize a new instance of the PanelColorsBse class.
        /// </summary>
        public PanelColorsBse()
			: base()
		{
		}
        /// <summary>
		/// Initialize a new instance of the PanelColorsBse class.
        /// </summary>
        /// <param name="basePanel">Base class for the panel or PanderPanelW control.</param>
        public PanelColorsBse(BasePanel basePanel)
            : base(basePanel)
        {
        }
        #endregion
		
		#region MethodsProtected
		/// <summary>
		/// Initialize a color Dictionary with defined Bse colors
		/// </summary>
		/// <param name="rgbTable">Dictionary with defined colors</param>
		protected override void InitColors(Dictionary<KnownColors, System.Drawing.Color> rgbTable)
		{
			base.InitColors(rgbTable);
            rgbTable[KnownColors.PanelCaptionSelectedGradientBegin] = Color.FromArgb(156, 163, 254);
            rgbTable[KnownColors.PanelCaptionSelectedGradientEnd] = Color.FromArgb(90, 98, 254);
            rgbTable[KnownColors.PanderPanelWCheckedCaptionBegin] = Color.FromArgb(136, 144, 254);
            rgbTable[KnownColors.PanderPanelWCheckedCaptionEnd] = Color.FromArgb(111, 145, 255);
            rgbTable[KnownColors.PanderPanelWCheckedCaptionMiddle] = Color.FromArgb(42, 52, 254);
            rgbTable[KnownColors.PanderPanelWPressedCaptionBegin] = Color.FromArgb(106, 109, 228);
            rgbTable[KnownColors.PanderPanelWPressedCaptionEnd] = Color.FromArgb(88, 111, 226);
            rgbTable[KnownColors.PanderPanelWPressedCaptionMiddle] = Color.FromArgb(39, 39, 217);
            rgbTable[KnownColors.PanderPanelWSelectedCaptionBegin] = Color.FromArgb(156, 163, 254);
            rgbTable[KnownColors.PanderPanelWSelectedCaptionEnd] = Color.FromArgb(139, 164, 255);
            rgbTable[KnownColors.PanderPanelWSelectedCaptionMiddle] = Color.FromArgb(90, 98, 254);
            rgbTable[KnownColors.PanderPanelWSelectedCaptionText] = Color.White;
		}
		#endregion
	}
}
