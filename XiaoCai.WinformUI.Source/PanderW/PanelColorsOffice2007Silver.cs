using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace XiaoCai.WinformUI.Panels
{
    public class PanelColorsOffice2007Silver : PanelColorsOffice
    {
        #region MethodsPublic
        /// <summary>
        /// Initialize a new instance of the PanelColorsOffice2007Silver class.
        /// </summary>
        public PanelColorsOffice2007Silver()
			: base()
		{
		}
        /// <summary>
        /// Initialize a new instance of the PanelColorsOffice2007Silver class.
        /// </summary>
        /// <param name="basePanel">Base class for the panel or PanderPanelW control.</param>
        public PanelColorsOffice2007Silver(BasePanel basePanel)
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
            rgbTable[KnownColors.BorderColor] = Color.FromArgb(111, 112, 116);
            rgbTable[KnownColors.InnerBorderColor] = Color.White;
            rgbTable[KnownColors.PanelCaptionCloseIcon] = Color.FromArgb(75, 79, 85);
            rgbTable[KnownColors.PanelCaptionExpandIcon] = Color.FromArgb(101, 104, 112);
            rgbTable[KnownColors.PanelCaptionGradientBegin] = Color.FromArgb(248, 248, 248);
            rgbTable[KnownColors.PanelCaptionGradientEnd] = Color.FromArgb(199, 203, 209);
            rgbTable[KnownColors.PanelCaptionGradientMiddle] = Color.FromArgb(218, 219, 231);
            rgbTable[KnownColors.PanelContentGradientBegin] = Color.FromArgb(240, 241, 242);
            rgbTable[KnownColors.PanelContentGradientEnd] = Color.FromArgb(240, 241, 242);
            rgbTable[KnownColors.PanelCaptionText] = Color.Black;//Color.FromArgb(21, 66, 139);
            rgbTable[KnownColors.PanelCollapsedCaptionText] = Color.Black;//Color.FromArgb(21, 66, 139);
            rgbTable[KnownColors.PanderPanelWBackColor] = Color.Transparent;
            rgbTable[KnownColors.PanderPanelWCaptionCloseIcon] = Color.FromArgb(75, 79, 85);
            rgbTable[KnownColors.PanderPanelWCaptionExpandIcon] = Color.FromArgb(101, 104, 112);
            rgbTable[KnownColors.PanderPanelWCaptionText] = Color.FromArgb(76, 83, 92);
            rgbTable[KnownColors.PanderPanelWCaptionGradientBegin] = Color.FromArgb(235, 238, 250);
            rgbTable[KnownColors.PanderPanelWCaptionGradientEnd] = Color.FromArgb(212, 216, 226);
            rgbTable[KnownColors.PanderPanelWCaptionGradientMiddle] = Color.FromArgb(197, 199, 209);
            rgbTable[KnownColors.PanderPanelWFlatCaptionGradientBegin] = Color.FromArgb(213, 219, 231);
            rgbTable[KnownColors.PanderPanelWFlatCaptionGradientEnd] = Color.FromArgb(253, 253, 254);
        }
        #endregion
    }
}
