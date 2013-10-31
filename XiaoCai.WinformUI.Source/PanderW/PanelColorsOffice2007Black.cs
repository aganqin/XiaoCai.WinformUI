using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace XiaoCai.WinformUI.Panels
{
    public class PanelColorsOffice2007Black : PanelColorsOffice
    {
        #region MethodsPublic
        /// <summary>
        /// Initialize a new instance of the PanelColorsOffice2007Black class.
        /// </summary>
        public PanelColorsOffice2007Black()
			: base()
		{
		}
        /// <summary>
        /// Initialize a new instance of the PanelColorsOffice2007Black class.
        /// </summary>
        /// <param name="basePanel">Base class for the panel or PanderPanelW control.</param>
        public PanelColorsOffice2007Black(BasePanel basePanel)
            : base(basePanel)
        {
        }

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Initialize a color Dictionary with defined colors
        /// </summary>
        /// <param name="rgbTable">Dictionary with defined colors</param>
        protected override void InitColors(Dictionary<PanelColors.KnownColors, Color> rgbTable)
        {
            base.InitColors(rgbTable);
            rgbTable[KnownColors.BorderColor] = Color.FromArgb(76, 83, 92);
            rgbTable[KnownColors.InnerBorderColor] = Color.White;
            rgbTable[KnownColors.PanelCaptionCloseIcon] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.PanelCaptionExpandIcon] = Color.FromArgb(101, 104, 112);
            rgbTable[KnownColors.PanelCaptionGradientBegin] = Color.FromArgb(240, 241, 242);
            rgbTable[KnownColors.PanelCaptionGradientEnd] = Color.FromArgb(189, 193, 200);
            rgbTable[KnownColors.PanelCaptionGradientMiddle] = Color.FromArgb(216, 219, 223);
            rgbTable[KnownColors.PanelContentGradientBegin] = Color.FromArgb(240, 241, 242);
            rgbTable[KnownColors.PanelContentGradientEnd] = Color.FromArgb(240, 241, 242);
            rgbTable[KnownColors.PanelCaptionText] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.PanelCollapsedCaptionText] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.PanderPanelWBackColor] = Color.Transparent;
            rgbTable[KnownColors.PanderPanelWCaptionCloseIcon] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.PanderPanelWCaptionExpandIcon] = Color.FromArgb(101, 104, 112);
            rgbTable[KnownColors.PanderPanelWCaptionText] = Color.FromArgb(55, 60, 67);
            rgbTable[KnownColors.PanderPanelWCaptionGradientBegin] = Color.FromArgb(248, 248, 249);
            rgbTable[KnownColors.PanderPanelWCaptionGradientEnd] = Color.FromArgb(219, 222, 226);
            rgbTable[KnownColors.PanderPanelWCaptionGradientMiddle] = Color.FromArgb(200, 204, 209);
            rgbTable[KnownColors.PanderPanelWFlatCaptionGradientBegin] = Color.FromArgb(212, 215, 219);
            rgbTable[KnownColors.PanderPanelWFlatCaptionGradientEnd] = Color.FromArgb(253, 253, 254);
        }

        #endregion
    }
}
