using System;
using System.Windows.Forms;
using XiaoCai.WinformUI.Panels;

namespace XiaoCai.WinformUI
{
    public class StyleManager
    {
        public static Style Style=Style.Office2007Blue;
        public static void SetStyle(Control control,Style style)
        {
            Style = style;
            FindStyleContainer(control, style);
        }

        private static void FindStyleContainer(Control controlParent, Style style)
        {
            if (controlParent.Controls.Count == 0)
                return;
            foreach (Control control in controlParent.Controls)
            {
                if (control.GetType().GetInterface("IStyle") != null)
                {
                    var myStyle = control as IStyle;
                    if (myStyle != null) myStyle.SetStyle(style);
                }
                if (control.Controls.Count > 0)
                {
                    FindStyleContainer(control, style);
                }
            }
            SetPanelsStyle(controlParent, style);
            
        }

        private static void SetPanelsStyle(Control control,Style style)
        {

            ToolStripRenderer m_currentToolStripRenderer;
            ToolStripProfessionalRenderer toolStripRenderer = new Office2007Renderer();
            Panels.ProfessionalColorTable colorTable = StyleBuilderFactory.GetOffice2007ColorTable(style);

            PanelColors panelColorTable = colorTable.PanelColorTable;
            
            if (panelColorTable != null)
            {
                PanelSettingsManager.SetPanelProperties(
                    control.Controls,
                    panelColorTable);
            }
            m_currentToolStripRenderer = toolStripRenderer;
                object renderer = Activator.CreateInstance(m_currentToolStripRenderer.GetType(), new object[] { colorTable });
                m_currentToolStripRenderer = renderer as ToolStripProfessionalRenderer;
                ToolStripManager.Renderer = m_currentToolStripRenderer;
        }
    }
}
