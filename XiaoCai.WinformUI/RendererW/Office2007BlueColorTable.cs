using System.Drawing;
using System.Collections.Generic;

namespace XiaoCai.WinformUI.Panels
{
    /// <summary>
    /// Provides colors used for Microsoft Office 2007 blue display elements.
    /// </summary>
    public class Office2007BlueColorTable : XiaoCai.WinformUI.Panels.OfficeColorTable
	{
		#region FieldsPrivate
        private PanelColors m_panelColorTable;
        #endregion

		#region Properties
        /// <summary>
        /// Gets the associated ColorTable for the XPanderControls
        /// </summary>
        public override PanelColors PanelColorTable
        {
            get
            {
                if (this.m_panelColorTable == null)
                {
                    this.m_panelColorTable = new PanelColorsOffice2007Blue();
                }
                return this.m_panelColorTable;
            }
        }
		#endregion

        #region MethodsProtected
        /// <summary>
        /// Unitializes a color dictionary with defined colors
        /// </summary>
        /// <param name="rgbTable">Dictionary with defined colors</param>
        protected override void InitColors(Dictionary<ProfessionalColorTable.KnownColors, Color> rgbTable)
        {
            rgbTable[KnownColors.ButtonPressedBorder] = Color.FromArgb(255, 189, 105);
            rgbTable[KnownColors.ButtonPressedGradientBegin] = Color.FromArgb(248, 181, 106);
            rgbTable[KnownColors.ButtonPressedGradientEnd] = Color.FromArgb(255, 208, 134);
            rgbTable[KnownColors.ButtonPressedGradientMiddle] = Color.FromArgb(251, 140, 60);

            rgbTable[KnownColors.ButtonSelectedBorder] = Color.FromArgb(255, 189, 105);
            rgbTable[KnownColors.ButtonSelectedGradientBegin] = Color.FromArgb(255, 245, 204);
            rgbTable[KnownColors.ButtonSelectedGradientEnd] = Color.FromArgb(255, 219, 117);
            rgbTable[KnownColors.ButtonSelectedGradientMiddle] = Color.FromArgb(255, 231, 162);
			rgbTable[KnownColors.ButtonSelectedHighlightBorder] = Color.FromArgb(255, 189, 105);
            rgbTable[KnownColors.CheckBackground] = Color.FromArgb(255, 227, 149);
			rgbTable[KnownColors.CheckSelectedBackground] = Color.FromArgb(254, 128, 62);
            rgbTable[KnownColors.GripDark] = Color.FromArgb(111, 157, 217);
            rgbTable[KnownColors.GripLight] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.ImageMarginGradientBegin] = Color.FromArgb(233, 238, 238);
            rgbTable[KnownColors.MenuBorder] = Color.FromArgb(134, 134, 134);
            rgbTable[KnownColors.MenuItemBorder] = Color.FromArgb(255, 189, 105);
            rgbTable[KnownColors.MenuItemPressedGradientBegin] = Color.FromArgb(227, 239, 255);
            rgbTable[KnownColors.MenuItemPressedGradientEnd] = Color.FromArgb(152, 186, 230);
            rgbTable[KnownColors.MenuItemPressedGradientMiddle] = Color.FromArgb(222, 236, 255);
			rgbTable[KnownColors.MenuItemSelected] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.MenuItemSelectedGradientBegin] = Color.FromArgb(255, 245, 204);
            rgbTable[KnownColors.MenuItemSelectedGradientEnd] = Color.FromArgb(255, 223, 132);
			rgbTable[KnownColors.MenuItemText] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.MenuStripGradientBegin] = Color.FromArgb(191, 219, 255);
            rgbTable[KnownColors.MenuStripGradientEnd] = Color.FromArgb(191, 219, 255);
            rgbTable[KnownColors.OverflowButtonGradientBegin] = Color.FromArgb(167, 204, 251);
            rgbTable[KnownColors.OverflowButtonGradientEnd] = Color.FromArgb(101, 147, 207);
            rgbTable[KnownColors.OverflowButtonGradientMiddle] = Color.FromArgb(167, 204, 251);
            rgbTable[KnownColors.RaftingContainerGradientBegin] = Color.FromArgb(191, 219, 255);
            rgbTable[KnownColors.RaftingContainerGradientEnd] = Color.FromArgb(191, 219, 255);
            rgbTable[KnownColors.SeparatorDark] = Color.FromArgb(173, 209, 255);
            rgbTable[KnownColors.SeparatorLight] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.StatusStripGradientBegin] = Color.FromArgb(227, 239, 255);
            rgbTable[KnownColors.StatusStripGradientEnd] = Color.FromArgb(173, 209, 255);
			rgbTable[KnownColors.StatusStripText] = Color.FromArgb(21, 66, 139);
            rgbTable[KnownColors.ToolStripBorder] = Color.FromArgb(111, 157, 217);
            rgbTable[KnownColors.ToolStripContentPanelGradientBegin] = Color.FromArgb(191, 219, 255);
            rgbTable[KnownColors.ToolStripContentPanelGradientEnd] = Color.FromArgb(101, 145, 205);
            rgbTable[KnownColors.ToolStripDropDownBackground] = Color.FromArgb(250, 250, 250);
            rgbTable[KnownColors.ToolStripGradientBegin] = Color.FromArgb(227, 239, 255);
            rgbTable[KnownColors.ToolStripGradientEnd] = Color.FromArgb(152, 186, 230);
            rgbTable[KnownColors.ToolStripGradientMiddle] = Color.FromArgb(222, 236, 255);
            rgbTable[KnownColors.ToolStripPanelGradientBegin] = Color.FromArgb(191, 219, 255);
            rgbTable[KnownColors.ToolStripPanelGradientEnd] = Color.FromArgb(191, 219, 255);
            rgbTable[KnownColors.ToolStripText] = Color.FromArgb(0, 0, 0);
            #region 扩展控件样式
            rgbTable[KnownColors.TextBoxBorderColor] = Color.FromArgb(121, 153, 194);
            rgbTable[KnownColors.ButtonTextColor] = Color.Black;
            rgbTable[KnownColors.ButtonBorderColor] = Color.FromArgb(121, 153, 194);

            //Button Nomal BackColor
            rgbTable[KnownColors.ButtonNormalBorder] = Color.FromArgb(200, 101, 147, 207);
            rgbTable[KnownColors.ButtonNormalGradientBegin] = Color.FromArgb(200, 223, 237, 255);
            rgbTable[KnownColors.ButtonNormalGradientEnd] = Color.FromArgb(200, 207, 228, 255);
            rgbTable[KnownColors.ButtonNormalGradientMiddle] = Color.FromArgb(200, 175, 210, 255);
            //CheckBox
            rgbTable[KnownColors.CheckBoxBaseColor] = Color.FromArgb(121, 153, 194);
            rgbTable[KnownColors.CheckBoxBorderColor] = Color.FromArgb(121, 153, 194);
            rgbTable[KnownColors.CheckBoxTextColor] = Color.Black;
            rgbTable[KnownColors.CheckBoxInnerBorderColor] = Color.FromArgb(255, 255, 218, 114);
            //ComboBox
            rgbTable[KnownColors.ComboBoxBaseColor] = Color.FromArgb(175, 210, 255);
            rgbTable[KnownColors.ComboBoxBorderColor] = Color.FromArgb(121, 153, 194);
            rgbTable[KnownColors.ComboBoxArrowColor] = Color.FromArgb(121, 153, 194);
            rgbTable[KnownColors.ComboBoxBorderHoverColor] = Color.FromArgb(255, 255, 200, 138);
            rgbTable[KnownColors.ComboBoxHoverColor] = Color.FromArgb(255, 214, 108);
            rgbTable[KnownColors.ComboBoxPressColor] = Color.FromArgb(255, 189, 105);
            rgbTable[KnownColors.ComboBoxBorderPressColor] = Color.FromArgb(255, 255, 200, 138);
            //GridView
            rgbTable[KnownColors.GridViewColumnHeaderUpColor] = Color.FromArgb(227, 239, 255);
            rgbTable[KnownColors.GridViewColumnHeaderDownColor] = Color.FromArgb(175, 210, 255);
            rgbTable[KnownColors.GridViewBackColor] = Color.FromArgb(234, 247, 254);
            rgbTable[KnownColors.GridViewGridColor] = Color.FromArgb(175, 210, 255);
            rgbTable[KnownColors.GridViewTextColor] = Color.Black;
            //Form
            rgbTable[KnownColors.FormBackColor] = Color.FromArgb(191, 219, 255);
            rgbTable[KnownColors.FormHeaderUpColor] = Color.DarkTurquoise;
            rgbTable[KnownColors.FormHeaderDownColor] = Color.RoyalBlue;
            rgbTable[KnownColors.FormDrawPenColor] = Color.CornflowerBlue;
            rgbTable[KnownColors.FormMouseHoverColor] = Color.DarkRed;
            rgbTable[KnownColors.FormMousePressColor] = Color.Firebrick;
            //Grouper
            rgbTable[KnownColors.GrouperBorderColor] = Color.FromArgb(121, 153, 194);
            rgbTable[KnownColors.GrouperTextColor] = Color.Black;
            rgbTable[KnownColors.GrouperBackColor] = Color.Transparent;
            //Label 
            rgbTable[KnownColors.LabelTextColor] = Color.Black;
            //ListBox 
            rgbTable[KnownColors.ListBoxBorderColor] = Color.FromArgb(121, 153, 194);
            rgbTable[KnownColors.ListBoxSelectedColor] = Color.FromArgb(255, 218, 114);

            //RadioButton
            rgbTable[KnownColors.RadioButtonBaseColor] = Color.FromArgb(121, 153, 194);
            rgbTable[KnownColors.RadioButtonTextColor] = Color.Black;
            //TabControl
            rgbTable[KnownColors.TabControlBackColor] = Color.Transparent;
            rgbTable[KnownColors.TabControlBorderColor] = Color.FromArgb(121, 153, 194);
            rgbTable[KnownColors.TabControlPageTextColor] = Color.Black;
            rgbTable[KnownColors.TabControlPageBackColor] =Color.Transparent;//Color.FromArgb(255, 234, 247, 254);
            rgbTable[KnownColors.TabControlPageNormalBackColor1] = Color.FromArgb(200, 223, 237, 255);
            rgbTable[KnownColors.TabControlPageNormalBackColor2] = Color.FromArgb(200, 211, 231, 255);
            rgbTable[KnownColors.TabControlPageNormalBackColor3] = Color.FromArgb(200, 207, 228, 255);
            rgbTable[KnownColors.TabControlPageNormalBackColor4] = Color.FromArgb(200, 175, 210, 255);
            rgbTable[KnownColors.TabControlPageNormalBackColor5] = Color.FromArgb(200, 101, 147, 207);

            rgbTable[KnownColors.TabControlPageHoverColor1] = Color.FromArgb(255, 255, 253, 238);
            rgbTable[KnownColors.TabControlPageHoverColor2] = Color.FromArgb(255, 255, 237, 172);
            rgbTable[KnownColors.TabControlPageHoverColor3] = Color.FromArgb(255, 255, 224, 131);
            rgbTable[KnownColors.TabControlPageHoverColor4] = Color.FromArgb(255, 255, 229, 155);
            rgbTable[KnownColors.TabControlPageHoverColor5] = Color.FromArgb(255, 255, 200, 138);

            rgbTable[KnownColors.TabControlPageSelectColor1] = Color.FromArgb(255, 255, 236, 212);
            rgbTable[KnownColors.TabControlPageSelectColor2] = Color.FromArgb(255, 255, 198, 125);
            rgbTable[KnownColors.TabControlPageSelectColor3] = Color.FromArgb(255, 255, 182, 88);
            rgbTable[KnownColors.TabControlPageSelectColor4] = Color.FromArgb(255, 255, 218, 114);
            rgbTable[KnownColors.TabControlPageSelectColor5] = Color.FromArgb(255, 245, 200, 158);
            rgbTable[KnownColors.TreeViewBackColor] = Color.FromArgb(234, 247, 254);

            rgbTable[KnownColors.DateTimePickerBorder] = Color.FromArgb(121, 153, 194);
            #endregion
        }

        #endregion
    }
}
