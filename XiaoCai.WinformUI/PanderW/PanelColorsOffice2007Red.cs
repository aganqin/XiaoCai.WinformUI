using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace XiaoCai.WinformUI.Panels
{
    public class PanelColorsOffice2007Red : PanelColorsOffice
    {
		#region FieldsPrivate
		#endregion

		#region Properties
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initialize a new instance of the Office2007Colors class.
        /// </summary>
        public PanelColorsOffice2007Red()
			: base()
		{
		}
        /// <summary>
        /// Initialize a new instance of the Office2007Colors class.
        /// </summary>
        /// <param name="basePanel">Base class for the panel or PanderPanelW control.</param>
        public PanelColorsOffice2007Red(BasePanel basePanel)
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
            rgbTable[KnownColors.BorderColor] = Color.Maroon;
            rgbTable[KnownColors.InnerBorderColor] = Color.White;
            rgbTable[KnownColors.PanelCaptionCloseIcon] = Color.Black;
            rgbTable[KnownColors.PanelCaptionExpandIcon] = Color.Maroon;

            rgbTable[KnownColors.PanelCaptionGradientBegin] = Color.Pink;
            rgbTable[KnownColors.PanelCaptionGradientEnd] = Color.LightCoral;
            rgbTable[KnownColors.PanelCaptionGradientMiddle] = Color.Salmon;
            rgbTable[KnownColors.PanelContentGradientBegin] = Color.Pink;
            rgbTable[KnownColors.PanelContentGradientEnd] = Color.LightPink;

            rgbTable[KnownColors.PanelCaptionText] = Color.Black;
            rgbTable[KnownColors.PanelCollapsedCaptionText] = Color.Black;
            rgbTable[KnownColors.PanderPanelWBackColor] = Color.Transparent;
            rgbTable[KnownColors.PanderPanelWCaptionCloseIcon] = Color.Black;
            rgbTable[KnownColors.PanderPanelWCaptionExpandIcon] = Color.Maroon;
            rgbTable[KnownColors.PanderPanelWCaptionText] = Color.Black;
            rgbTable[KnownColors.PanderPanelWCaptionGradientBegin] = Color.LightPink;
            rgbTable[KnownColors.PanderPanelWCaptionGradientEnd] = Color.Pink;
            rgbTable[KnownColors.PanderPanelWCaptionGradientMiddle] = Color.PaleVioletRed;
            rgbTable[KnownColors.PanderPanelWFlatCaptionGradientBegin] = Color.LightPink;
            rgbTable[KnownColors.PanderPanelWFlatCaptionGradientEnd] = Color.Pink;
        }

        #endregion

        #region MethodsPrivate
        #endregion
    }
}
