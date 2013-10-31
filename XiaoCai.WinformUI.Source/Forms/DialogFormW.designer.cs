namespace XiaoCai.WinformUI.Forms
{
    partial class DialogFormW
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.prgTitle = new XiaoCai.WinformUI.Panels.PanelW();
            this.btnClose = new System.Windows.Forms.Button();
            this.prgTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // prgTitle
            // 
            this.prgTitle.AssociatedSplitter = null;
            this.prgTitle.BackColor = System.Drawing.Color.Transparent;
            this.prgTitle.CaptionFont = new System.Drawing.Font("微软雅黑", 11.75F, System.Drawing.FontStyle.Bold);
            this.prgTitle.CaptionHeight = 27;
            this.prgTitle.Controls.Add(this.btnClose);
            this.prgTitle.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.prgTitle.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.prgTitle.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.prgTitle.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.prgTitle.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.prgTitle.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.prgTitle.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.prgTitle.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.prgTitle.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.prgTitle.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.prgTitle.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.prgTitle.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.prgTitle.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.prgTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.prgTitle.Image = null;
            this.prgTitle.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.prgTitle.Location = new System.Drawing.Point(0, 0);
            this.prgTitle.MinimumSize = new System.Drawing.Size(27, 27);
            this.prgTitle.Name = "prgTitle";
            this.prgTitle.PanelStyle = XiaoCai.WinformUI.Panels.PanelStyle.Office2007;
            this.prgTitle.ShowTransparentBackground = false;
            this.prgTitle.Size = new System.Drawing.Size(425, 335);
            this.prgTitle.TabIndex = 0;
            this.prgTitle.ToolTipTextCloseIcon = null;
            this.prgTitle.ToolTipTextExpandIconPanelCollapsed = null;
            this.prgTitle.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Gray;
            this.btnClose.Location = new System.Drawing.Point(397, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.MouseEnter += new System.EventHandler(this.OnMouseHover);
            this.btnClose.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // DialogFormW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 335);
            this.Controls.Add(this.prgTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DialogFormW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserRoleMapForm";
            this.Load += new System.EventHandler(this.DialogFormW_Load);
            this.prgTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public XiaoCai.WinformUI.Panels.PanelW prgTitle;
        public System.Windows.Forms.Button btnClose;
    }
}