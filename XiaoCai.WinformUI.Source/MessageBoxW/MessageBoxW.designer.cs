namespace XiaoCai.WinformUI
{
    partial class MessageBoxW
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
            this.prgMessage = new XiaoCai.WinformUI.Panels.PanelW();
            this.btnClose = new System.Windows.Forms.Button();
            this.labInfo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNo = new XiaoCai.WinformUI.ButtonW();
            this.btnYes = new XiaoCai.WinformUI.ButtonW();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new XiaoCai.WinformUI.ButtonW();
            this.panel4 = new System.Windows.Forms.Panel();
            this.picICO = new System.Windows.Forms.PictureBox();
            this.prgMessage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picICO)).BeginInit();
            this.SuspendLayout();
            // 
            // prgMessage
            // 
            this.prgMessage.AssociatedSplitter = null;
            this.prgMessage.BackColor = System.Drawing.Color.Transparent;
            this.prgMessage.CaptionFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prgMessage.CaptionHeight = 27;
            this.prgMessage.Controls.Add(this.btnClose);
            this.prgMessage.Controls.Add(this.labInfo);
            this.prgMessage.Controls.Add(this.panel2);
            this.prgMessage.Controls.Add(this.panel1);
            this.prgMessage.Controls.Add(this.panel4);
            this.prgMessage.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.prgMessage.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.prgMessage.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.prgMessage.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.prgMessage.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.prgMessage.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.prgMessage.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.prgMessage.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.prgMessage.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.prgMessage.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.prgMessage.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.prgMessage.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.prgMessage.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.prgMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.prgMessage.Image = null;
            this.prgMessage.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.prgMessage.Location = new System.Drawing.Point(0, 0);
            this.prgMessage.MinimumSize = new System.Drawing.Size(27, 27);
            this.prgMessage.Name = "prgMessage";
            this.prgMessage.PanelStyle = XiaoCai.WinformUI.Panels.PanelStyle.Office2007;
            this.prgMessage.ShowCloseIcon = true;
            this.prgMessage.ShowTransparentBackground = false;
            this.prgMessage.Size = new System.Drawing.Size(238, 105);
            this.prgMessage.TabIndex = 0;
            this.prgMessage.Text = "提示";
            this.prgMessage.ToolTipTextCloseIcon = null;
            this.prgMessage.ToolTipTextExpandIconPanelCollapsed = null;
            this.prgMessage.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.Gray;
            this.btnClose.Location = new System.Drawing.Point(214, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(22, 22);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // labInfo
            // 
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labInfo.Location = new System.Drawing.Point(51, 1);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(186, 53);
            this.labInfo.TabIndex = 15;
            this.labInfo.Text = "Message";
            this.labInfo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNo);
            this.panel2.Controls.Add(this.btnYes);
            this.panel2.Location = new System.Drawing.Point(53, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 23);
            this.panel2.TabIndex = 14;
            // 
            // btnNo
            // 
            this.btnNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNo.ForeColor = System.Drawing.Color.Black;
            this.btnNo.IsSilver = false;
            this.btnNo.Location = new System.Drawing.Point(90, 0);
            this.btnNo.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnNo.MenuPos = new System.Drawing.Point(0, 0);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(80, 23);
            this.btnNo.Style = XiaoCai.WinformUI.Style.Office2007Blue;
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "取消(N)";
            this.btnNo.ToFocused = false;
            this.btnNo.UseVisualStyleBackColor = true;
            // 
            // btnYes
            // 
            this.btnYes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnYes.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYes.ForeColor = System.Drawing.Color.Black;
            this.btnYes.IsSilver = false;
            this.btnYes.Location = new System.Drawing.Point(0, 0);
            this.btnYes.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnYes.MenuPos = new System.Drawing.Point(0, 0);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(80, 23);
            this.btnYes.Style = XiaoCai.WinformUI.Style.Office2007Blue;
            this.btnYes.TabIndex = 3;
            this.btnYes.Text = "确定(Y)";
            this.btnYes.ToFocused = false;
            this.btnYes.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Location = new System.Drawing.Point(53, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 23);
            this.panel1.TabIndex = 14;
            // 
            // btnOk
            // 
            this.btnOk.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.IsSilver = false;
            this.btnOk.Location = new System.Drawing.Point(0, 0);
            this.btnOk.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnOk.MenuPos = new System.Drawing.Point(0, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 23);
            this.btnOk.Style = XiaoCai.WinformUI.Style.Office2007Blue;
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定(Y)";
            this.btnOk.ToFocused = false;
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.picICO);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(50, 103);
            this.panel4.TabIndex = 10;
            // 
            // picICO
            // 
            this.picICO.Location = new System.Drawing.Point(5, 47);
            this.picICO.Name = "picICO";
            this.picICO.Size = new System.Drawing.Size(40, 40);
            this.picICO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picICO.TabIndex = 6;
            this.picICO.TabStop = false;
            // 
            // MessageBoxW
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 105);
            this.Controls.Add(this.prgMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageBoxW";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提示";
            this.prgMessage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picICO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panels.PanelW prgMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ButtonW btnNo;
        private ButtonW btnYes;
        private ButtonW btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labInfo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox picICO;

    }
}