namespace XiaoCai.WinformUI
{
    partial class Pager
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLastPage = new XiaoCai.WinformUI.ButtonW();
            this.btnFirstPage = new XiaoCai.WinformUI.ButtonW();
            this.lblPagerMessage = new XiaoCai.WinformUI.LabelW();
            this.btnGo = new XiaoCai.WinformUI.ButtonW();
            this.cmbPage = new XiaoCai.WinformUI.ComboBoxW();
            this.btnNextPage = new XiaoCai.WinformUI.ButtonW();
            this.btnPrePage = new XiaoCai.WinformUI.ButtonW();
            this.btnNextGroup = new XiaoCai.WinformUI.ButtonW();
            this.btnPreGroup = new XiaoCai.WinformUI.ButtonW();
            this.SuspendLayout();
            // 
            // btnLastPage
            // 
            this.btnLastPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastPage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.btnLastPage.ForeColor = System.Drawing.Color.Black;
            this.btnLastPage.IsSilver = false;
            this.btnLastPage.Location = new System.Drawing.Point(441, 3);
            this.btnLastPage.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnLastPage.MenuPos = new System.Drawing.Point(0, 0);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(30, 23);
            this.btnLastPage.Style = XiaoCai.WinformUI.Style.Office2007Blue;
            this.btnLastPage.TabIndex = 9;
            this.btnLastPage.Text = ">|";
            this.btnLastPage.ToFocused = false;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFirstPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirstPage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.btnFirstPage.ForeColor = System.Drawing.Color.Black;
            this.btnFirstPage.IsSilver = false;
            this.btnFirstPage.Location = new System.Drawing.Point(337, 3);
            this.btnFirstPage.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnFirstPage.MenuPos = new System.Drawing.Point(0, 0);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(30, 23);
            this.btnFirstPage.Style = XiaoCai.WinformUI.Style.Office2007Blue;
            this.btnFirstPage.TabIndex = 8;
            this.btnFirstPage.Text = "|<";
            this.btnFirstPage.ToFocused = false;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // lblPagerMessage
            // 
            this.lblPagerMessage.AutoSize = true;
            this.lblPagerMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblPagerMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPagerMessage.Location = new System.Drawing.Point(9, 8);
            this.lblPagerMessage.Name = "lblPagerMessage";
            this.lblPagerMessage.Size = new System.Drawing.Size(215, 12);
            //this.lblPagerMessage.Style = XiaoCai.WinformUI.Style.Office2007Red;
            this.lblPagerMessage.TabIndex = 7;
            this.lblPagerMessage.Text = "共{0}条记录，每页 {1} 条，共 {2} 页";
            this.lblPagerMessage.UseStyle = true;
            // 
            // btnGo
            // 
            this.btnGo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.btnGo.ForeColor = System.Drawing.Color.Black;
            this.btnGo.IsSilver = false;
            this.btnGo.Location = new System.Drawing.Point(518, 3);
            this.btnGo.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnGo.MenuPos = new System.Drawing.Point(0, 0);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(30, 23);
            this.btnGo.Style = XiaoCai.WinformUI.Style.Office2007Blue;
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "GO";
            this.btnGo.ToFocused = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // cmbPage
            // 
            this.cmbPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPage.ArrowColor = System.Drawing.Color.Empty;
            this.cmbPage.AutoComplete = false;
            this.cmbPage.AutoDropdown = false;
            this.cmbPage.BackColorEven = System.Drawing.Color.White;
            this.cmbPage.BackColorOdd = System.Drawing.Color.White;
            this.cmbPage.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.cmbPage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.cmbPage.ColumnNames = "";
            this.cmbPage.ColumnWidthDefault = 75;
            this.cmbPage.ColumnWidths = "";
            this.cmbPage.DisplayMember = "Text";
            this.cmbPage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbPage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPage.ItemHeight = 14;
            this.cmbPage.LinkedColumnIndex = 0;
            this.cmbPage.LinkedTextBox = null;
            this.cmbPage.Location = new System.Drawing.Point(474, 4);
            this.cmbPage.Name = "cmbPage";
            this.cmbPage.Size = new System.Drawing.Size(40, 20);
            this.cmbPage.TabIndex = 4;
            this.cmbPage.SelectedIndexChanged += new System.EventHandler(this.cmbPage_SelectedIndexChanged);
            // 
            // btnNextPage
            // 
            this.btnNextPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.btnNextPage.ForeColor = System.Drawing.Color.Black;
            this.btnNextPage.IsSilver = false;
            this.btnNextPage.Location = new System.Drawing.Point(407, 3);
            this.btnNextPage.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnNextPage.MenuPos = new System.Drawing.Point(0, 0);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(30, 23);
            this.btnNextPage.Style = XiaoCai.WinformUI.Style.Office2007Blue;
            this.btnNextPage.TabIndex = 3;
            this.btnNextPage.Text = ">";
            this.btnNextPage.ToFocused = false;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPrePage
            // 
            this.btnPrePage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrePage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.btnPrePage.ForeColor = System.Drawing.Color.Black;
            this.btnPrePage.IsSilver = false;
            this.btnPrePage.Location = new System.Drawing.Point(372, 3);
            this.btnPrePage.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnPrePage.MenuPos = new System.Drawing.Point(0, 0);
            this.btnPrePage.Name = "btnPrePage";
            this.btnPrePage.Size = new System.Drawing.Size(30, 23);
            this.btnPrePage.Style = XiaoCai.WinformUI.Style.Office2007Blue;
            this.btnPrePage.TabIndex = 2;
            this.btnPrePage.Text = "<";
            this.btnPrePage.ToFocused = false;
            this.btnPrePage.Click += new System.EventHandler(this.btnPrePage_Click);
            // 
            // btnNextGroup
            // 
            this.btnNextGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNextGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextGroup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.btnNextGroup.ForeColor = System.Drawing.Color.Black;
            this.btnNextGroup.IsSilver = false;
            this.btnNextGroup.Location = new System.Drawing.Point(302, 3);
            this.btnNextGroup.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnNextGroup.MenuPos = new System.Drawing.Point(0, 0);
            this.btnNextGroup.Name = "btnNextGroup";
            this.btnNextGroup.Size = new System.Drawing.Size(30, 23);
            this.btnNextGroup.Style = XiaoCai.WinformUI.Style.Office2007Blue;
            this.btnNextGroup.TabIndex = 1;
            this.btnNextGroup.Text = ">>";
            this.btnNextGroup.ToFocused = false;
            this.btnNextGroup.Click += new System.EventHandler(this.btnNextGroup_Click);
            // 
            // btnPreGroup
            // 
            this.btnPreGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPreGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreGroup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.btnPreGroup.ForeColor = System.Drawing.Color.Black;
            this.btnPreGroup.IsSilver = false;
            this.btnPreGroup.Location = new System.Drawing.Point(267, 3);
            this.btnPreGroup.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnPreGroup.MenuPos = new System.Drawing.Point(0, 0);
            this.btnPreGroup.Name = "btnPreGroup";
            this.btnPreGroup.Size = new System.Drawing.Size(30, 23);
            this.btnPreGroup.Style = XiaoCai.WinformUI.Style.Office2007Blue;
            this.btnPreGroup.TabIndex = 0;
            this.btnPreGroup.Text = "<<";
            this.btnPreGroup.ToFocused = false;
            this.btnPreGroup.Click += new System.EventHandler(this.btnPreGroup_Click);
            // 
            // Pager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnLastPage);
            this.Controls.Add(this.btnFirstPage);
            this.Controls.Add(this.lblPagerMessage);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.cmbPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPrePage);
            this.Controls.Add(this.btnNextGroup);
            this.Controls.Add(this.btnPreGroup);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Pager";
            this.Size = new System.Drawing.Size(571, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ButtonW btnPreGroup;
        private ButtonW btnNextGroup;
        private ButtonW btnPrePage;
        private ButtonW btnNextPage;
        private ComboBoxW cmbPage;
        private ButtonW btnGo;
        private LabelW lblPagerMessage;
        private ButtonW btnFirstPage;
        private ButtonW btnLastPage;


    }
}
