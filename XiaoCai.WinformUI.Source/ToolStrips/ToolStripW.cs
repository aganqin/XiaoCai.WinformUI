using System;
using System.ComponentModel;
using System.Windows.Forms;
using XiaoCai.WinformUI.Panels;

namespace XiaoCai.WinformUI.ToolStrips
{
    public partial class ToolStripW : ToolStrip,IStyle
    {
        private ToolStripRenderer m_currentToolStripRenderer;
        private Panels.ProfessionalColorTable m_currentProfessionalColorTable;
        public ToolStripW()
        {
            InitializeComponent();
        }

        public ToolStripW(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            ToolStripProfessionalRenderer toolStripRenderer = new Office2007Renderer();
            Panels.ProfessionalColorTable colorTable = new Office2007BlueColorTable();
            PanelColors panelColorTable = colorTable.PanelColorTable;
            if (panelColorTable != null)
            {
                
                PanelSettingsManager.SetPanelProperties(
                    this.Controls,
                    panelColorTable);
            }
            this.m_currentToolStripRenderer = toolStripRenderer;
            if (colorTable.Equals(this.m_currentProfessionalColorTable) == false)
            {
                this.m_currentProfessionalColorTable = colorTable;
                object renderer = Activator.CreateInstance(this.m_currentToolStripRenderer.GetType(), new object[] { colorTable });
                this.m_currentToolStripRenderer = renderer as ToolStripProfessionalRenderer;
                ToolStripManager.Renderer = this.m_currentToolStripRenderer;
            }
        }

        #region IStyle 成员
        public void SetStyle(Style style)
        {
            ToolStripProfessionalRenderer toolStripRenderer = new Office2007Renderer();
            Panels.ProfessionalColorTable colorTable = StyleBuilderFactory.GetOffice2007ColorTable(style);

            PanelColors panelColorTable = colorTable.PanelColorTable;
            if (panelColorTable != null)
            {
                ControlCollection controls = new ControlCollection(this);
                PanelSettingsManager.SetPanelProperties(
                    //this.Controls,
                    controls,
                    panelColorTable);
            }
            this.m_currentToolStripRenderer = toolStripRenderer;
            if (colorTable.Equals(this.m_currentProfessionalColorTable) == false)
            {
                this.m_currentProfessionalColorTable = colorTable;
                object renderer = Activator.CreateInstance(this.m_currentToolStripRenderer.GetType(), new object[] { colorTable });
                this.m_currentToolStripRenderer = renderer as ToolStripProfessionalRenderer;
                ToolStripManager.Renderer = this.m_currentToolStripRenderer;
            }
            this.Refresh();
        }

        private Style _style = Style.Office2007Blue;
        public Style Style
        {
            get
            {
                return _style;
            }
            set
            {
                _style = value;
                SetStyle(_style);
            }
        }

        #endregion
    }
}
