using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XiaoCai.WinformUI.Forms
{
    public partial class DialogFormW : Form
    {
        public DialogFormW()
        {
            InitializeComponent();
        }

        private void DialogFormW_Load(object sender, EventArgs e)
        {
            Style style = StyleManager.Style;
            StyleManager.SetStyle(this, style);
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
    }
}
