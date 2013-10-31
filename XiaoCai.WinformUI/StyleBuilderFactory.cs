using System;
using XiaoCai.WinformUI.Panels;

namespace XiaoCai.WinformUI
{
    class StyleBuilderFactory
    {
        public static OfficeColorTable GetOffice2007ColorTable(Style style)
        {
            string className = "XiaoCai.WinformUI.Panels." + style.ToString() + "ColorTable";
            Type type = Type.GetType(className);
            if (type != null)
            {
                return (OfficeColorTable)Activator.CreateInstance(type);
            }
            return null;
        }
        public static PanelColorsOffice GetPanelOffice2007ColorTable(Style style)
        {
            string className = "XiaoCai.WinformUI.Panels.PanelColors" + style.ToString();
            Type type = Type.GetType(className);
            if (type != null)
            {
                return (PanelColorsOffice)Activator.CreateInstance(type);
            }
            return null;
        }


    }
}
