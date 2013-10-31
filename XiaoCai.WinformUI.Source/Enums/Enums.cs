using System;

namespace XiaoCai.WinformUI
{
    [Flags]
    public enum TabControlHitTest
    {
        /// <summary>
        /// The position is not over a tab.
        /// </summary>
        TCHT_NOWHERE = 1,

        /// <summary>
        /// The position is over a tab's icon.
        /// </summary>
        TCHT_ONITEMICON = 2,

        /// <summary>
        /// The position is over a tab's text.
        /// </summary>
        TCHT_ONITEMLABEL = 4,

        /// <summary>
        /// The position is over a tab but not over its icon or its text. For owner-drawn tab controls, this value is specified if the position is anywhere over a tab.
        /// TCHT_ONITEM is a bitwise-OR operation on TCHT_ONITEMICON and TCHT_ONITEMLABEL.
        /// </summary>
        TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL
    }

    public enum SetWindowPosFlags : uint
    {
        SWP_NOSIZE = 0x0001,
        SWP_NOMOVE = 0x0002,
        SWP_NOZORDER = 0x0004,
        SWP_NOREDRAW = 0x0008,
        SWP_NOACTIVATE = 0x0010,
        SWP_FRAMECHANGED = 0x0020,
        SWP_SHOWWINDOW = 0x0040,
        SWP_HIDEWINDOW = 0x0080,
        SWP_NOCOPYBITS = 0x0100,
        SWP_NOOWNERZORDER = 0x0200,
        SWP_NOSENDCHANGING = 0x0400,
        SWP_DRAWFRAME = 0x0020,
        SWP_NOREPOSITION = 0x0200,
        SWP_DEFERERASE = 0x2000,
        SWP_ASYNCWINDOWPOS = 0x4000
    }

    /// <summary>
    /// 控件的状态。
    /// </summary>
    public enum ControlState
    {
        /// <summary>
        ///  正常。
        /// </summary>
        Normal,
        /// <summary>
        /// 鼠标进入。
        /// </summary>
        Hover,
        /// <summary>
        /// 鼠标按下。
        /// </summary>
        Pressed,
        /// <summary>
        /// 获得焦点。
        /// </summary>
        Focused,
    }

   
}
