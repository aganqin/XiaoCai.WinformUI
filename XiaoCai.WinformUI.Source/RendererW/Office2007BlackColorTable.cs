using System.Drawing;
using System.Collections.Generic;

namespace XiaoCai.WinformUI.Panels
{
    /// <summary>
    /// Provides colors used for Microsoft Office 2007 black display elements.
    /// </summary>
    public class Office2007BlackColorTable : XiaoCai.WinformUI.Panels.OfficeColorTable
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
                    this.m_panelColorTable = new PanelColorsOffice2007Black();
                }
                return this.m_panelColorTable;
            }
        }
		#endregion

        #region MethodsProtected
        /// <summary>
        /// Initializes a color dictionary with defined colors.
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
            rgbTable[KnownColors.GripDark] = Color.FromArgb(145, 153, 164);
            rgbTable[KnownColors.GripLight] = Color.FromArgb(221, 224, 227);
            rgbTable[KnownColors.ImageMarginGradientBegin] = Color.FromArgb(239, 239, 239);
            rgbTable[KnownColors.MenuBorder] = Color.FromArgb(145, 153, 164);
            rgbTable[KnownColors.MenuItemBorder] = Color.FromArgb(255, 189, 105);
            rgbTable[KnownColors.MenuItemPressedGradientBegin] = Color.FromArgb(145, 153, 164);
            rgbTable[KnownColors.MenuItemPressedGradientEnd] = Color.FromArgb(108, 117, 128);
            rgbTable[KnownColors.MenuItemPressedGradientMiddle] = Color.FromArgb(126, 135, 146);
			rgbTable[KnownColors.MenuItemSelected] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.MenuItemSelectedGradientBegin] = Color.FromArgb(255, 245, 204);
            rgbTable[KnownColors.MenuItemSelectedGradientEnd] = Color.FromArgb(255, 223, 132);
            rgbTable[KnownColors.MenuItemText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.MenuStripGradientBegin] = Color.FromArgb(83, 83, 83);
            rgbTable[KnownColors.MenuStripGradientEnd] = Color.FromArgb(83, 83, 83);
            rgbTable[KnownColors.OverflowButtonGradientBegin] = Color.FromArgb(178, 183, 191);
            rgbTable[KnownColors.OverflowButtonGradientEnd] = Color.FromArgb(81, 88, 98);
            rgbTable[KnownColors.OverflowButtonGradientMiddle] = Color.FromArgb(145, 153, 164);
            rgbTable[KnownColors.RaftingContainerGradientBegin] = Color.FromArgb(83, 83, 83);
            rgbTable[KnownColors.RaftingContainerGradientEnd] = Color.FromArgb(83, 83, 83);
            rgbTable[KnownColors.SeparatorDark] = Color.FromArgb(145, 153, 164);
            rgbTable[KnownColors.SeparatorLight] = Color.FromArgb(221, 224, 227);
            rgbTable[KnownColors.StatusStripGradientBegin] = Color.FromArgb(76, 83, 92);
            rgbTable[KnownColors.StatusStripGradientEnd] = Color.FromArgb(35, 38, 42);
			rgbTable[KnownColors.StatusStripText] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.ToolStripBorder] = Color.FromArgb(76, 83, 92);
            rgbTable[KnownColors.ToolStripContentPanelGradientBegin] = Color.FromArgb(82, 82, 82);
            rgbTable[KnownColors.ToolStripContentPanelGradientEnd] = Color.FromArgb(10, 10, 10);
            rgbTable[KnownColors.ToolStripDropDownBackground] = Color.FromArgb(250, 250, 250);
            rgbTable[KnownColors.ToolStripGradientBegin] = Color.FromArgb(205, 208, 213);
            rgbTable[KnownColors.ToolStripGradientEnd] = Color.FromArgb(148, 156, 166);
            rgbTable[KnownColors.ToolStripGradientMiddle] = Color.FromArgb(188, 193, 200);
            rgbTable[KnownColors.ToolStripPanelGradientBegin] = Color.FromArgb(83, 83, 83);
            rgbTable[KnownColors.ToolStripPanelGradientEnd] = Color.FromArgb(83, 83, 83);
            rgbTable[KnownColors.ToolStripText] = Color.FromArgb(0, 0, 0);

            #region 扩展控件样式
            rgbTable[KnownColors.TextBoxBorderColor] = Color.FromArgb(111, 112, 116);
            rgbTable[KnownColors.ButtonTextColor] = Color.Black;
            rgbTable[KnownColors.ButtonBorderColor] = Color.FromArgb(111, 112, 116);
            //Button Nomal BackColor
            rgbTable[KnownColors.ButtonNormalBorder] = Color.FromArgb(255, 111, 112, 116);
            rgbTable[KnownColors.ButtonNormalGradientBegin] = Color.FromArgb(209, 209, 223);
            rgbTable[KnownColors.ButtonNormalGradientEnd] = Color.FromArgb(200, 213, 217, 227);
            rgbTable[KnownColors.ButtonNormalGradientMiddle] = Color.FromArgb(215, 215, 229);
            //CheckBox
            rgbTable[KnownColors.CheckBoxBaseColor] = Color.FromArgb(111, 112, 116);
            rgbTable[KnownColors.CheckBoxBorderColor] = Color.FromArgb(111, 112, 116);
            rgbTable[KnownColors.CheckBoxTextColor] = Color.Black;
            rgbTable[KnownColors.CheckBoxInnerBorderColor] = Color.FromArgb(255, 255, 218, 114);
            //ComboBox
            rgbTable[KnownColors.ComboBoxBaseColor] = Color.FromArgb(199, 203, 209);
            rgbTable[KnownColors.ComboBoxBorderColor] = Color.FromArgb(111, 112, 116);
            rgbTable[KnownColors.ComboBoxArrowColor] = Color.FromArgb(111, 112, 116);
            rgbTable[KnownColors.ComboBoxBorderHoverColor] = Color.FromArgb(255, 255, 200, 138);
            rgbTable[KnownColors.ComboBoxHoverColor] = Color.FromArgb(255, 214, 108);
            rgbTable[KnownColors.ComboBoxPressColor] = Color.FromArgb(255, 189, 105);
            rgbTable[KnownColors.ComboBoxBorderPressColor] = Color.FromArgb(255, 255, 200, 138);
            //GridView
            rgbTable[KnownColors.GridViewColumnHeaderUpColor] = Color.FromArgb(240, 240, 240);
            rgbTable[KnownColors.GridViewColumnHeaderDownColor] = Color.LightGray;
            rgbTable[KnownColors.GridViewBackColor] = Color.Silver;
            rgbTable[KnownColors.GridViewGridColor] = Color.Silver;
            rgbTable[KnownColors.GridViewTextColor] = Color.Black;
            //Form
            rgbTable[KnownColors.FormBackColor] = Color.FromArgb(83, 83, 83);
            rgbTable[KnownColors.FormHeaderUpColor] = Color.DarkGray;
            rgbTable[KnownColors.FormHeaderDownColor] = Color.Black;
            rgbTable[KnownColors.FormDrawPenColor] = Color.Black;
            rgbTable[KnownColors.FormMouseHoverColor] = Color.DarkRed;
            rgbTable[KnownColors.FormMousePressColor] = Color.Firebrick;
            //Grouper
            rgbTable[KnownColors.GrouperBorderColor] = Color.FromArgb(111, 112, 116);
            rgbTable[KnownColors.GrouperTextColor] = Color.Black;
            rgbTable[KnownColors.GrouperBackColor] = Color.Transparent;
            //Label 
            rgbTable[KnownColors.LabelTextColor] = Color.Black;
            //ListBox 
            rgbTable[KnownColors.ListBoxBorderColor] = Color.FromArgb(111, 112, 116);
            rgbTable[KnownColors.ListBoxSelectedColor] = Color.FromArgb(255, 218, 114);

            //RadioButton
            rgbTable[KnownColors.RadioButtonBaseColor] = Color.FromArgb(111, 112, 116);
            rgbTable[KnownColors.RadioButtonTextColor] = Color.Black;

            //TabControl
            rgbTable[KnownColors.TabControlBackColor] = Color.Transparent;
            rgbTable[KnownColors.TabControlBorderColor] = Color.FromArgb(111, 112, 116);
            rgbTable[KnownColors.TabControlPageTextColor] = Color.Black;
            rgbTable[KnownColors.TabControlPageBackColor] = Color.Transparent;
            rgbTable[KnownColors.TabControlPageNormalBackColor1] = Color.FromArgb(200, 234, 237, 249);
            rgbTable[KnownColors.TabControlPageNormalBackColor2] = Color.FromArgb(200, 228, 232, 243);
            rgbTable[KnownColors.TabControlPageNormalBackColor3] = Color.FromArgb(200, 225, 229, 240);
            rgbTable[KnownColors.TabControlPageNormalBackColor4] = Color.FromArgb(200, 213, 217, 227);
            rgbTable[KnownColors.TabControlPageNormalBackColor5] = Color.FromArgb(255, 111, 112, 116);

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
            rgbTable[KnownColors.TreeViewBackColor] = SystemColors.Control;

            rgbTable[KnownColors.DateTimePickerBorder] = Color.FromArgb(111, 112, 116);
            #endregion
        }

        #endregion
    }
}
