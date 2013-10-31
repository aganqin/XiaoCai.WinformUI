using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XiaoCai.WinformUI
{
    public class KnownParam
    {
        public static readonly IntPtr TRUE = new IntPtr(1);
        public static readonly IntPtr FALSE = new IntPtr(0);
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        public const int VK_LBUTTON = 0x01;
        public const int VK_RBUTTON = 0x02;
        public const long PRF_CHECKVISIBLE = 0x00000001L;
        public const long PRF_NONCLIENT = 0x00000002L;
        public const long PRF_CLIENT = 0x00000004L;
        public const long PRF_ERASEBKGND = 0x00000008L;
        public const long PRF_CHILDREN = 0x00000010L;
        public const long PRF_OWNED = 0x00000020L;
        public const int WM_HSCROLL = 0x0114;
        public const int WM_VSCROLL = 0x0115;
        public const int EM_GETSEL = 0x00B0;
        public const int EM_LINEINDEX = 0x00BB;
        public const int EM_LINEFROMCHAR = 0x00C9;
        public const int EM_POSFROMCHAR = 0x00D6;
        public const int _srcCopy = 0xCC0020;
        public const int _htClient = 1;
        public const int _htTransparent = -1;

        public const int _TCM_HITTEST = 0x130D;
        public const string TOOLBARCLASSNAME = "ToolbarWindow32";
        public const string REBARCLASSNAME = "ReBarWindow32";
        public const string PROGRESSBARCLASSNAME = "msctls_progress32";
        public const string SCROLLBAR = "SCROLLBAR";
    }
}
