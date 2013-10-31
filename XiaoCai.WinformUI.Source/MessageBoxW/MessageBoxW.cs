using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XiaoCai.WinformUI.Docking;
using XiaoCai.WinformUI.Properties;

namespace XiaoCai.WinformUI
{
    public enum MessageBoxStyle
    {
        info=0,
        question=1,
        error=2
    };

    public partial class MessageBoxW : Form,IStyle
    {
        public MessageBoxW(MessageBoxStyle messageBoxStyle, string msg)
        {
            InitializeComponent();
            Style style = StyleManager.Style;
            StyleManager.SetStyle(this, style);
            btnClose.BackColor = Color.Transparent;
            if (messageBoxStyle == MessageBoxStyle.info)
            {
                picICO.Image = Resources.info3;
                prgMessage.Text = "提示";
                panel1.Visible = true;
                panel2.Visible = false;
                this.AcceptButton = btnOk;
            }
            else if (messageBoxStyle == MessageBoxStyle.question)
            {
                picICO.Image = Resources.question3;
                prgMessage.Text = "询问";
                panel1.Visible = false;
                panel2.Visible = true;
                this.AcceptButton = btnYes;
            }
            else if (messageBoxStyle == MessageBoxStyle.error)
            {
                picICO.Image =Resources.error3;
                prgMessage.Text = "错误";
                prgMessage.ForeColor = Color.Red;
                panel1.Visible = true;
                panel2.Visible = false;
                this.AcceptButton = btnOk;
            }

            this.labInfo.Text = msg;

            SizeF size = TextRenderer.MeasureText(msg, new Font("宋体", 9, FontStyle.Regular));
            
            int TempWidth = (int)size.Width;
            if (TempWidth <= 250) { return; }

            this.Width = (int)size.Width;
            this.panel1.Width = TempWidth - 20;
            this.panel2.Width = TempWidth - 20;
            btnYes.Width = TempWidth / 2 - 20;
            btnNo.Width = TempWidth / 2 - 20;
    
            
        }

        private void OnMouseHover(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Firebrick;
            button.ForeColor = Color.White;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Transparent;
            button.ForeColor = Color.Gray;
        }

        #region IStyle 成员
        /// <summary>
        /// 设置控件样式
        /// </summary>
        /// <param name="style"></param>
        public void SetStyle(Style style)
        {
            StyleManager.SetStyle(this, style);
            this.Refresh();
            base.Invalidate(false);
        }

        /// <summary>
        /// 默认样式为Office2007Blue
        /// </summary>
        private Style _style = Style.Office2007Blue;

        /// <summary>
        /// 样式属性
        /// </summary>
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
