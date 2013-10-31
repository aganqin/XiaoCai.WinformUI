using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoCai.WinformUI.Panels
{
    public class ColorSchemeChangeEventArgs : EventArgs
    {
        #region FieldsPrivate

        private ColorScheme m_eColorSchema;

        #endregion

        #region Properties
        /// <summary>
        /// Gets the color schema which is used for the panel.
        /// </summary>
        public ColorScheme ColorSchema
        {
            get { return this.m_eColorSchema; }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Arguments used when a ColorSchemeChange event occurs.
        /// </summary>
        /// <param name="eColorSchema">The color schema which is used for the panel.</param>
        public ColorSchemeChangeEventArgs(ColorScheme eColorSchema)
        {
            this.m_eColorSchema = eColorSchema;
        }

        #endregion
    }
}
