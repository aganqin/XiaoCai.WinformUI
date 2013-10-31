using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XiaoCai.WinformUI.Forms
{
    public class WindowsMessage
    {
        public const int WM_USER = 0x400;
        public const int WM_ReceiveData = WM_USER + 201;
        public const int WM_SendData = WM_USER + 202;
        public static IntPtr WM_Handle;
    }
}
