using System.Windows.Forms;
using System.Drawing;

namespace XiaoCai.WinformUI
{
    public delegate void UpDownButtonPaintEventHandler(
        object sender,
        UpDownButtonPaintEventArgs e);

    public class UpDownButtonPaintEventArgs : PaintEventArgs
    {
        private readonly bool _mouseOver;
        private readonly bool _mousePress;
        private readonly bool _mouseInUpButton;

        public UpDownButtonPaintEventArgs(
            Graphics graphics,
            Rectangle clipRect,
            bool mouseOver,
            bool mousePress,
            bool mouseInUpButton)
            : base(graphics, clipRect)
        {
            _mouseOver = mouseOver;
            _mousePress = mousePress;
            _mouseInUpButton = mouseInUpButton;
        }

        public bool MouseOver
        {
            get { return _mouseOver; }
        }

        public bool MousePress
        {
            get { return _mousePress; }
        }

        public bool MouseInUpButton
        {
            get { return _mouseInUpButton; }
        }
    }
}
