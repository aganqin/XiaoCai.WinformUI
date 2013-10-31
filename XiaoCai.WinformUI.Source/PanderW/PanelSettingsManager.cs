using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace XiaoCai.WinformUI.Panels
{
    public static class PanelSettingsManager
    {
        #region MethodsPublic
        /// <summary>
        /// Sets the PanelStyle and PanelColors table in the given control collection.
        /// </summary>
        /// <param name="controls">A collection of child controls.</param>
        /// <param name="panelColors">The PanelColors table</param>
        public static void SetPanelProperties(Control.ControlCollection controls, PanelColors panelColors)
        {
            if (panelColors == null)
            {
                throw new ArgumentNullException("panelColors",
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    XiaoCai.WinformUI.Properties.Resources.IDS_ArgumentException,
                    "panelColors"));
            }

            PanelStyle panelStyle = panelColors.PanelStyle;
            SetPanelProperties(controls, panelStyle, panelColors);
        }
        /// <summary>
        /// Sets the PanelStyle and PanelColors table in the given control collection.
        /// </summary>
        /// <param name="controls">A collection of child controls</param>
        /// <param name="panelStyle">Style of the panel</param>
        /// <param name="panelColors">The PanelColors table</param>
        public static void SetPanelProperties(Control.ControlCollection controls, PanelStyle panelStyle, PanelColors panelColors)
        {
            if (panelColors == null)
            {
                throw new ArgumentNullException("panelColors",
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    XiaoCai.WinformUI.Properties.Resources.IDS_ArgumentException,
                    "panelColors"));
            }

			ArrayList panels = FindPanels(true, controls);
            foreach (BasePanel panel in panels)
            {
                panel.PanelStyle = panelStyle;
                panelColors.Panel = panel;
                panel.SetPanelProperties(panelColors);
            }
            ArrayList PanderPanelListWs = FindPanelLists(true, controls);
            foreach (PanderPanelListW PanderPanelListW in PanderPanelListWs)
            {
                PanderPanelListW.PanelStyle = panelStyle;
                PanderPanelListW.PanelColors = panelColors;
            }
        }
        /// <summary>
        /// Sets the PanelStyle in the given control collection.
        /// </summary>
        /// <param name="controls">a collection of child controls</param>
        /// <param name="panelStyle">Style of the panel</param>
        public static void SetPanelProperties(Control.ControlCollection controls, PanelStyle panelStyle)
        {
            ArrayList panels = FindPanels(true, controls);
            if (panels != null)
            {
                foreach (BasePanel panel in panels)
                {
                    panel.PanelStyle = panelStyle;
                }
            }
        }
        /// <summary>
        /// Find all controls that derived from BasePanel.
        /// </summary>
        /// <param name="searchAllChildren">A value indicating whether the FindPanels method loops through all controls.</param>
        /// <param name="controlsToLookIn">A collection of child controls.</param>
        /// <returns>A arraylist of derived types.</returns>
        public static ArrayList FindPanels(bool searchAllChildren, Control.ControlCollection controlsToLookIn)
        {
            return FindControls(typeof(BasePanel), searchAllChildren, controlsToLookIn, new ArrayList());
        }
        /// <summary>
        /// Find all PanderPanelListWs.
        /// </summary>
        /// <param name="searchAllChildren">A value indicating whether the FindPanels method loops through all controls.</param>
        /// <param name="controlsToLookIn">A collection of child controls.</param>
        /// <returns></returns>
        public static ArrayList FindPanelLists(bool searchAllChildren, Control.ControlCollection controlsToLookIn)
        {
            return FindControls(typeof(PanderPanelListW), searchAllChildren, controlsToLookIn, new ArrayList());
        }
        #endregion

        #region MethodsPrivate

        private static ArrayList FindControls(Type baseType, bool searchAllChildren, Control.ControlCollection controlsToLookIn, ArrayList foundControls)
        {
            if ((controlsToLookIn == null) || (foundControls == null))
            {
                return null;
            }
            try
            {
                for (int i = 0; i < controlsToLookIn.Count; i++)
                {
                    if ((controlsToLookIn[i] != null) && baseType.IsAssignableFrom(controlsToLookIn[i].GetType()))
                    {
                        foundControls.Add(controlsToLookIn[i]);
                    }
                }
                if (searchAllChildren == false)
                {
                    return foundControls;
                }
                for (int j = 0; j < controlsToLookIn.Count; j++)
                {
                    if (((controlsToLookIn[j] != null) && !(controlsToLookIn[j] is Form)) && ((controlsToLookIn[j].Controls != null) && (controlsToLookIn[j].Controls.Count > 0)))
                    {
                        foundControls = FindControls(baseType, searchAllChildren, controlsToLookIn[j].Controls, foundControls);
                    }
                }
            }
            catch (Exception exception)
            {
                if (IsCriticalException(exception))
                {
                    throw;
                }
            }
            return foundControls;
        }

        private static bool IsCriticalException(Exception exception)
        {
            return (((((exception is NullReferenceException) ||
                (exception is StackOverflowException)) ||
                ((exception is OutOfMemoryException) ||
                (exception is System.Threading.ThreadAbortException))) ||
                ((exception is ExecutionEngineException) ||
                (exception is IndexOutOfRangeException))) ||
                (exception is AccessViolationException));
        }

        #endregion
    }
}
