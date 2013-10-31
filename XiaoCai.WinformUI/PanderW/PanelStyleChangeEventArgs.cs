using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoCai.WinformUI.Panels
{

    public class PanelStyleChangeEventArgs : EventArgs
    {
        #region FieldsPrivate

        private PanelStyle m_ePanelStyle;

        #endregion

        #region Properties
        /// <summary>
        /// Gets the style of the panel.
        /// </summary>
        public PanelStyle PanelStyle
        {
            get { return this.m_ePanelStyle; }
        }

        #endregion

        #region MethodsPublic
        /// <summary>
        /// Arguments used when a PanelStyleChange event occurs.
        /// </summary>
        /// <param name="ePanelStyle">the style of the panel.</param>
        public PanelStyleChangeEventArgs(PanelStyle ePanelStyle)
        {
            this.m_ePanelStyle = ePanelStyle;
        }

        #endregion
    }
}
