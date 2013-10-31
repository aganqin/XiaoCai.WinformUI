using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace XiaoCai.WinformUI.Panels
{
    public class PanelColorsOffice2007Blue : PanelColorsOffice
    {
		#region FieldsPrivate
		#endregion

		#region Properties
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initialize a new instance of the Office2007Colors class.
        /// </summary>
        public PanelColorsOffice2007Blue()
			: base()
		{
		}
        /// <summary>
        /// Initialize a new instance of the Office2007Colors class.
        /// </summary>
        /// <param name="basePanel">Base class for the panel or PanderPanelW control.</param>
        public PanelColorsOffice2007Blue(BasePanel basePanel)
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
            rgbTable[KnownColors.BorderColor] = Color.FromArgb(101, 147, 207);
            rgbTable[KnownColors.InnerBorderColor] = Color.White;
            rgbTable[KnownColors.PanelCaptionCloseIcon] = Color.Black;
            rgbTable[KnownColors.PanelCaptionExpandIcon] = Color.FromArgb(21, 66, 139);
            rgbTable[KnownColors.PanelCaptionGradientBegin] = Color.FromArgb(227, 239, 255);
            rgbTable[KnownColors.PanelCaptionGradientEnd] = Color.FromArgb(173, 209, 255);
            rgbTable[KnownColors.PanelCaptionGradientMiddle] = Color.FromArgb(199, 224, 255);
            rgbTable[KnownColors.PanelContentGradientBegin] = Color.FromArgb(227, 239, 255);
            rgbTable[KnownColors.PanelContentGradientEnd] = Color.FromArgb(227, 239, 255);
            rgbTable[KnownColors.PanelCaptionText] = Color.Black;//Color.FromArgb(22, 65, 139);
            rgbTable[KnownColors.PanelCollapsedCaptionText] = Color.Black;//Color.FromArgb(21, 66, 139);
            rgbTable[KnownColors.PanderPanelWBackColor] = Color.Transparent;
            rgbTable[KnownColors.PanderPanelWCaptionCloseIcon] = Color.Black;
            rgbTable[KnownColors.PanderPanelWCaptionExpandIcon] = Color.FromArgb(21, 66, 139);
            rgbTable[KnownColors.PanderPanelWCaptionText] = Color.Black;//Color.FromArgb(21, 66, 139);
            rgbTable[KnownColors.PanderPanelWCaptionGradientBegin] = Color.FromArgb(227, 239, 255);
            rgbTable[KnownColors.PanderPanelWCaptionGradientEnd] = Color.FromArgb(199, 224, 255);
            rgbTable[KnownColors.PanderPanelWCaptionGradientMiddle] = Color.FromArgb(173, 209, 255);
            rgbTable[KnownColors.PanderPanelWFlatCaptionGradientBegin] = Color.FromArgb(214, 232, 255);
            rgbTable[KnownColors.PanderPanelWFlatCaptionGradientEnd] = Color.FromArgb(253, 253, 254);
        }

        #endregion

        #region MethodsPrivate
        #endregion
    }
}
