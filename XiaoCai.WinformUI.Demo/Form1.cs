using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XiaoCai.WinformUI.Forms;

namespace XiaoCai.WinformUI.Demo
{
    public partial class Form1 : CustomForm
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(Style.Office2007Blue);
        }
    }
}
