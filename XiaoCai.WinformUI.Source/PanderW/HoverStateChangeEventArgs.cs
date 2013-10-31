using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoCai.WinformUI.Panels
{
    public class HoverStateChangeEventArgs : EventArgs
    {
        #region FieldsPrivate
        private HoverState m_hoverState;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the HoverState.
        /// </summary>
        public HoverState HoverState
        {
            get { return this.m_hoverState; }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the HoverStateChangeEventArgs class.
        /// </summary>
        /// <param name="hoverState">The <see cref="HoverState"/> values.</param>
        public HoverStateChangeEventArgs(HoverState hoverState)
        {
            this.m_hoverState = hoverState;
        }
        #endregion
    }
}
