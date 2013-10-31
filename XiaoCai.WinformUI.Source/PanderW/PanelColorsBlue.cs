using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace XiaoCai.WinformUI.Panels
{

    public class PanelColorsBlue : PanelColorsBse
    {
		#region FieldsPrivate
		#endregion

		#region Properties
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initialize a new instance of the PanelColorsBlack class.
        /// </summary>
        public PanelColorsBlue()
			: base()
		{
		}
        /// <summary>
        /// Initialize a new instance of the PanelColorsBlack class.
        /// </summary>
        /// <param name="basePanel">Base class for the panel or PanderPanelW control.</param>
        public PanelColorsBlue(BasePanel basePanel)
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
            rgbTable[KnownColors.BorderColor] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.PanelCaptionCloseIcon] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.PanelCaptionExpandIcon] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.PanelCaptionGradientBegin] = Color.FromArgb(128, 128, 255);
            rgbTable[KnownColors.PanelCaptionGradientEnd] = Color.FromArgb(0, 0, 128);
            rgbTable[KnownColors.PanelCaptionGradientMiddle] = Color.FromArgb(0, 0, 139);
            rgbTable[KnownColors.PanelContentGradientBegin] = Color.FromArgb(240, 241, 242);
            rgbTable[KnownColors.PanelContentGradientEnd] = Color.FromArgb(240, 241, 242);
            rgbTable[KnownColors.PanelCaptionText] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.PanelCollapsedCaptionText] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.InnerBorderColor] = Color.FromArgb(185, 185, 185);
            rgbTable[KnownColors.PanderPanelWBackColor] = Color.FromArgb(240, 241, 242);
            rgbTable[KnownColors.PanderPanelWCaptionCloseIcon] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.PanderPanelWCaptionExpandIcon] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.PanderPanelWCaptionText] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.PanderPanelWCaptionGradientBegin] = Color.FromArgb(128, 128, 255);
            rgbTable[KnownColors.PanderPanelWCaptionGradientEnd] = Color.FromArgb(98, 98, 205);
            rgbTable[KnownColors.PanderPanelWCaptionGradientMiddle] = Color.FromArgb(0, 0, 139);
            rgbTable[KnownColors.PanderPanelWFlatCaptionGradientBegin] = Color.FromArgb(111, 145, 255);
            rgbTable[KnownColors.PanderPanelWFlatCaptionGradientEnd] = Color.FromArgb(188, 205, 254);
        }

        #endregion

        #region MethodsPrivate
        #endregion
    }
}
