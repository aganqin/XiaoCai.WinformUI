namespace XiaoCai.WinformUI.Demo
{
    partial class Form1
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
            this.comboBoxW1 = new XiaoCai.WinformUI.ComboBoxW();
            this.buttonW1 = new XiaoCai.WinformUI.ButtonW();
            this.listBoxW1 = new XiaoCai.WinformUI.ListBoxW.ListBoxW();
            this.checkBoxW1 = new XiaoCai.WinformUI.CheckBoxW();
            this.SuspendLayout();
            // 
            // comboBoxW1
            // 
            this.comboBoxW1.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.comboBoxW1.AutoComplete = false;
            this.comboBoxW1.AutoDropdown = false;
            this.comboBoxW1.BackColorEven = System.Drawing.Color.White;
            this.comboBoxW1.BackColorOdd = System.Drawing.Color.White;
            this.comboBoxW1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.comboBoxW1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.comboBoxW1.ColumnNames = "";
            this.comboBoxW1.ColumnWidthDefault = 75;
            this.comboBoxW1.ColumnWidths = "";
            this.comboBoxW1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxW1.FormattingEnabled = true;
            this.comboBoxW1.LinkedColumnIndex = 0;
            this.comboBoxW1.LinkedTextBox = null;
            this.comboBoxW1.Location = new System.Drawing.Point(12, 12);
            this.comboBoxW1.Name = "comboBoxW1";
            this.comboBoxW1.Size = new System.Drawing.Size(121, 22);
            this.comboBoxW1.TabIndex = 0;
            // 
            // buttonW1
            // 
            this.buttonW1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.buttonW1.ForeColor = System.Drawing.Color.Black;
            this.buttonW1.IsSilver = false;
            this.buttonW1.Location = new System.Drawing.Point(139, 12);
            this.buttonW1.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonW1.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonW1.Name = "buttonW1";
            this.buttonW1.Size = new System.Drawing.Size(75, 23);
            this.buttonW1.Style = XiaoCai.WinformUI.Style.Office2007Blue;
            this.buttonW1.TabIndex = 1;
            this.buttonW1.Text = "buttonW1";
            this.buttonW1.ToFocused = false;
            this.buttonW1.UseVisualStyleBackColor = true;
            // 
            // listBoxW1
            // 
            this.listBoxW1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.listBoxW1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxW1.FormattingEnabled = true;
            this.listBoxW1.HorizontalScrollbar = true;
            this.listBoxW1.ItemHeight = 17;
            this.listBoxW1.Items.AddRange(new object[] {
            "test1",
            "test2",
            "test3",
            "test4"});
            this.listBoxW1.Location = new System.Drawing.Point(17, 74);
            this.listBoxW1.Name = "listBoxW1";
            this.listBoxW1.Size = new System.Drawing.Size(120, 89);
            this.listBoxW1.Style = XiaoCai.WinformUI.Style.Office2007Blue;
            this.listBoxW1.TabIndex = 2;
            // 
            // checkBoxW1
            // 
            this.checkBoxW1.AutoSize = true;
            this.checkBoxW1.BaseColor = System.Drawing.Color.Empty;
            this.checkBoxW1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(153)))), ((int)(((byte)(194)))));
            this.checkBoxW1.Location = new System.Drawing.Point(139, 53);
            this.checkBoxW1.Name = "checkBoxW1";
            this.checkBoxW1.Size = new System.Drawing.Size(84, 16);
            this.checkBoxW1.Style = XiaoCai.WinformUI.Style.Office2007Blue;
            this.checkBoxW1.TabIndex = 3;
            this.checkBoxW1.Text = "checkBoxW1";
            this.checkBoxW1.UseStyle = false;
            this.checkBoxW1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.checkBoxW1);
            this.Controls.Add(this.listBoxW1);
            this.Controls.Add(this.buttonW1);
            this.Controls.Add(this.comboBoxW1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBoxW comboBoxW1;
        private ButtonW buttonW1;
        private ListBoxW.ListBoxW listBoxW1;
        private CheckBoxW checkBoxW1;
    }
}

