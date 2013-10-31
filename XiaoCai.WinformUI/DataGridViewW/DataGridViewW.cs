using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using Aspose.Cells;
using XiaoCai.WinformUI.Panels;
using System.Drawing.Printing;


namespace XiaoCai.WinformUI
{
   // [ToolboxBitmap(typeof(DataGridViewW), "Bitmap.GridViewControl.bmp")] //定义在工具箱里显示图标,可以去掉
    /**/
    /// <summary>
    /// GridViewControl是一个可定义部分外观的DataGridView
    /// 注意要想使得自画的背景有效,得把DataGridViewa相应的颜色属性设为Color.Transparent,这个在代码里没处理
    /// </summary>
    public class DataGridViewW : DataGridView, IStyle
    {
        /// <summary>
        /// 需要打印的列索引集合
        /// </summary>
        public List<int> ToPrintCols { get; set; }

        /// <summary>
        /// 需要打印的行索引集合
        /// </summary>
        public List<int> ToPrintRows { get; set; }

        /// <summary>
        /// 打印文档对象
        /// </summary>
        public PrintDocument PDC { get; set; }

        #region Fields

        private Color _columnHeaderUpColor = Color.FromArgb(227, 239, 255);
        private Color _columnHeaderDownColor = Color.FromArgb(175, 210, 255);
        private Color _selectedRowColor1 = Color.White;
        private Color _selectedRowColor2 = Color.FromArgb(220, 237, 206);
        private Color _primaryRowColor1 = Color.White;
        private Color _primaryRowColor2 = Color.FromArgb(255, 249, 232);
        private Color _secondaryRowColor1 = Color.White;
        private Color _secondaryRowColor2 = Color.Black;
        private ContextMenuStrip _cmsExport;
        private IContainer components;
        private ToolStripMenuItem _tsmiExprotToExcel;
        private int _secondaryLength = 1;
        private OfficeColorTable _officeColorTable;
        #endregion

        private ToolStripMenuItem _tsmiPrintPreview;
        private ToolStripMenuItem _tsmiPrint;

        #region Properties

        public ContextMenuStrip CMenu
        {
            get
            {
                return this._cmsExport;
            }
        }

        public bool ShowEportContextMenu { get; set; }

        public Color ColumnHeaderUpColor //表头起始颜色
        {
            get { return _columnHeaderUpColor; }
            set { _columnHeaderUpColor = value; this.Invalidate(); }
        }

        public bool showColumnHeaderCheckBox;

        public bool ShowColumnHeaderCheckBox
        {
            get
            {
                return showColumnHeaderCheckBox;
            }
            set { showColumnHeaderCheckBox = value; }
        }

        public Color ColumnHeaderDownColor //表头终止颜色
        {
            get { return _columnHeaderDownColor; }
            set
            {
                _columnHeaderDownColor = value;
                this.Invalidate();
            }
        }

        public Color PrimaryRowcolor1 //奇行起始颜色
        {
            get { return _primaryRowColor1; }
            set
            {
                if (value.IsEmpty || value == Color.Transparent)
                    _primaryRowColor1 = Color.White;
                else
                    _primaryRowColor1 = value;
            }
        }

        public Color PrimaryRowcolor2//奇行终止颜色
        {
            get { return _primaryRowColor2; }
            set
            {
                if (value.IsEmpty || value == Color.Transparent)
                    _primaryRowColor2 = Color.White;
                else
                    _primaryRowColor2 = value;
            }
        }

        public Color SecondaryRowColor1//偶行起始颜色
        {
            get { return _secondaryRowColor1; }
            set
            {
                if (value.IsEmpty || value == Color.Transparent)
                    _secondaryRowColor1 = Color.White;
                else
                    _secondaryRowColor1 = value;
            }
        }

        public Color SecondaryRowColor2//偶行起始颜色
        {
            get { return _secondaryRowColor2; }
            set
            {
                if (value.IsEmpty || value == Color.Transparent)
                    _secondaryRowColor2 = Color.White;
                else
                    _secondaryRowColor2 = value;
            }
        }

        public int SecondaryLength //这个长度现在是指导隔多少个行出现一个偶行
        {
            get { return _secondaryLength; }
            set { _secondaryLength = value; }
        }
        [Browsable(false)]
        public Color SelectedRowColor1 //选中行起始颜色
        {
            get { return _selectedRowColor1; }
            set { _selectedRowColor1 = value; }
        }
        [Browsable(false)]
        public Color SelectedRowColor2 //选中行终止颜色
        {
            get { return _selectedRowColor2; }
            set { _selectedRowColor2 = value; }
        }


        public new int ColumnHeadersHeight
        {
            get { return base.ColumnHeadersHeight; }
            set
            {
                if (value > 24)
                {
                    base.ColumnHeadersHeight = value;
                }
                else
                {
                    base.ColumnHeadersHeight = 24;
                }
            }

        }



        /// <summary>
        /// 属性重载
        /// </summary>
        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                // this.BackgroundColor = this.RowTemplate.DefaultCellStyle.BackColor = value ? Color.White : Color.LightGray;
                //this.Style = value ? Style.Office2007Blue : Style.Office2007Sliver;

            }
        }
        #endregion


        private void Init()
        {
            this.RowHeadersVisible = false;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AllowUserToResizeRows = false;
            this.ShowColumnHeaderCheckBox = false;
            this.BorderStyle = BorderStyle.None;
            this.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            this.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.BackgroundColor = Color.FromArgb(234, 247, 254);
            this.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.GridView_RowPrePaint);
            this.CellPainting += new DataGridViewCellPaintingEventHandler(this.GridView_CellPainting);
            PDC = new PrintDocument();
            this._cmsExport.Items[0].Visible = this._cmsExport.Items[1].Visible = this._cmsExport.Items[2].Visible = false;
        }

        public DataGridViewW()
        {
            ShowEportContextMenu = false;
            SetStyle(
            ControlStyles.SupportsTransparentBackColor
                 | ControlStyles.OptimizedDoubleBuffer
                 | ControlStyles.UserPaint
                 | ControlStyles.AllPaintingInWmPaint
                 | ControlStyles.ResizeRedraw, true);
            InitializeComponent();
            Init();
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.BorderStyle = BorderStyle.None;
        }

        private static void DrawLinearGradient(Rectangle Rec, Graphics Grp, Color Color1, Color Color2)
        {
            if (Color1 == Color2)
            {
                Brush backbrush = new SolidBrush(Color1);
                Grp.FillRectangle(backbrush, Rec);
            }
            else
            {
                using (Brush backbrush = new LinearGradientBrush(Rec, Color1, Color2, LinearGradientMode.Vertical))
                {
                    Grp.FillRectangle(backbrush, Rec);
                }
            }
        }
        private void GridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex == -1)
            {
                if (!(_columnHeaderUpColor == Color.Transparent) && !(_columnHeaderDownColor == Color.Transparent) &&
                    !_columnHeaderUpColor.IsEmpty && !_columnHeaderDownColor.IsEmpty)
                {
                    DrawLinearGradient(e.CellBounds, e.Graphics, _columnHeaderUpColor, _columnHeaderDownColor);
                    if (ShowColumnHeaderCheckBox)
                    {
                        e.Paint(e.ClipBounds, (DataGridViewPaintParts.All & ~DataGridViewPaintParts.Background));
                    }
                    else
                    {
                        DrawText(e); 
                    }
                    e.Handled = true;
                }
            }
            else if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
            {
                if (this.RowTemplate.DefaultCellStyle.SelectionBackColor == Color.Transparent)
                {
                    GraphHelper.FillRect(e.CellBounds, e.Graphics, _style);
                }
            }
        }

        private void DrawText(DataGridViewCellPaintingEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            Rectangle textRect = e.CellBounds;
            textRect.X += 2;
            textRect.Y += 2;
            //TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString(), this.Font, e.CellBounds, Color.Yellow);
            using (Brush brush = new SolidBrush(_ForeColor))
            {
                e.Graphics.DrawString(
                    e.FormattedValue.ToString(),
                    this.Font,
                    brush,
                    textRect,
                    sf);
            }
            e.Graphics.ResetTransform();
        }

        private void RenderButtonBackground(Graphics graphics, Rectangle bounds, Color colorGradientBegin, Color colorGradientMiddle, Color colorGradientEnd)
        {
            RectangleF upperRectangle = bounds;
            upperRectangle.Height = bounds.Height * 0.4f;

            using (LinearGradientBrush upperLinearGradientBrush = new LinearGradientBrush(
                    upperRectangle,
                    colorGradientBegin,
                    colorGradientMiddle,
                    LinearGradientMode.Vertical))
            {

                Blend blend = new Blend();
                blend.Positions = new float[] { 0.0F, 1.0F };
                blend.Factors = new float[] { 0.0F, 0.6F };
                upperLinearGradientBrush.Blend = blend;
                graphics.FillRectangle(upperLinearGradientBrush, upperRectangle);
            }

            RectangleF lowerRectangle = bounds;
            lowerRectangle.Y = upperRectangle.Height;
            lowerRectangle.Height = bounds.Height - upperRectangle.Height;

            using (LinearGradientBrush lowerLinearGradientBrush = new LinearGradientBrush(
                    lowerRectangle,
                    colorGradientMiddle,
                    colorGradientEnd,
                    LinearGradientMode.Vertical))
            {
                graphics.FillRectangle(lowerLinearGradientBrush, lowerRectangle);
            }
            RectangleF correctionRectangle = lowerRectangle;
            correctionRectangle.Y -= 1;
            correctionRectangle.Height = 2;
            using (SolidBrush solidBrush = new SolidBrush(colorGradientMiddle))
            {
                graphics.FillRectangle(solidBrush, correctionRectangle);
            }
        }

        private void GridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Rectangle rowBounds = new Rectangle(0, e.RowBounds.Top, this.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) -
                                                  this.HorizontalScrollingOffset + 1, e.RowBounds.Height + 1);

            e.PaintParts &= ~DataGridViewPaintParts.Focus;
            if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
            {
                if (this.RowTemplate.DefaultCellStyle.SelectionBackColor == Color.Transparent)
                {
                    //DrawLinearGradient(rowBounds, e.Graphics, _SelectedRowColor1, _SelectedRowColor2);
                    //DrawSelectRow(rowBounds, e.Graphics);
                    GraphHelper.FillRect(rowBounds, e.Graphics, _style);
                }
            }
            else
            {
                if (this.RowTemplate.DefaultCellStyle.BackColor == Color.Transparent)
                {
                    if (e.RowIndex % _secondaryLength == 1)
                    {
                        DrawLinearGradient(rowBounds, e.Graphics, _primaryRowColor1, _primaryRowColor2);
                    }
                    else
                    {
                        DrawLinearGradient(rowBounds, e.Graphics, _secondaryRowColor1, _secondaryRowColor2);
                    }
                }
            }
        }

        #region IStyle Members

        private Style _style = Style.Office2007Blue;

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

        public void SetStyle(Style style)
        {
            _officeColorTable = StyleBuilderFactory.GetOffice2007ColorTable(style);
            _columnHeaderUpColor = _officeColorTable.GridViewColumnHeaderUpColor;
            _columnHeaderDownColor = _officeColorTable.GridViewColumnHeaderDownColor;
            this.BackgroundColor = _officeColorTable.GridViewBackColor;
            this.GridColor = _officeColorTable.GridViewGridColor;
            _ForeColor = _officeColorTable.GridViewTextColor;
        }

        private Color _ForeColor = System.Drawing.SystemColors.ControlText;
        #endregion

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._cmsExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._tsmiExprotToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiPrint = new System.Windows.Forms.ToolStripMenuItem();
            this._cmsExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsExport
            // 
            this._cmsExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmiExprotToExcel,
            this._tsmiPrintPreview,
            this._tsmiPrint});
            this._cmsExport.Name = "_cmsExport";
            this._cmsExport.Size = new System.Drawing.Size(125, 70);
            // 
            // tsmiExprotToExcel
            // 
            this._tsmiExprotToExcel.Name = "tsmiExprotToExcel";
            this._tsmiExprotToExcel.Size = new System.Drawing.Size(124, 22);
            this._tsmiExprotToExcel.Text = "导出Excel";
            this._tsmiExprotToExcel.Click += new System.EventHandler(this.tsmiExprotToExcel_Click);
            // 
            // tsmiPrintPreview
            // 
            this._tsmiPrintPreview.Name = "tsmiPrintPreview";
            this._tsmiPrintPreview.Size = new System.Drawing.Size(124, 22);
            this._tsmiPrintPreview.Text = "打印预览";
            this._tsmiPrintPreview.Click += new System.EventHandler(this.tsmiPrintPreview_Click);
            // 
            // tsmiPrint
            // 
            this._tsmiPrint.Name = "tsmiPrint";
            this._tsmiPrint.Size = new System.Drawing.Size(124, 22);
            this._tsmiPrint.Text = "打印";
            this._tsmiPrint.Click += new System.EventHandler(this.tsmiPrint_Click);
            // 
            // DataGridViewW
            // 
            this.RowTemplate.Height = 23;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewW_MouseClick);
            this._cmsExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }


        public string ExportExcel_Public_SpecialRow(out bool hasRecord)
        {
            Workbook workbook = new Workbook();
            Cells cells = workbook.Worksheets[0].Cells;
            string savePath = string.Empty;
            hasRecord = false;
            int k = 0;
            for (int j = 1; j < this.Columns.Count; j++)
            {
                var col = this.Columns[j];
                if (col.Visible)
                {
                    var cell = cells[0, k];
                    cell.PutValue(col.HeaderText);
                    int row = 0;
                    for (int i = 0; i < this.Rows.Count; i++)
                    {
                        var obj = this[0, i].Value;
                        if (obj == null || !bool.Parse(obj.ToString()))
                            continue;
                        if (obj is bool && bool.Parse(obj.ToString()))
                        {
                            cell = cells[row + 1, k];
                            cell.Style.Font.Color = this[j, i].Style.ForeColor;
                            obj = this[j, i].Value;
                            if (obj != null)
                            {
                                var typ = obj.GetType();
                                if (typ == typeof(DateTime))
                                {
                                    cell.Style.Custom = "yyyy-mm-dd hh:mm:ss";
                                    cell.PutValue(obj.ToString());
                                }
                                else if (typ == typeof(string))
                                {
                                    var str = obj.ToString();
                                    if (str.IsNum())
                                        cell.PutValue(double.Parse(str));
                                    else
                                        cell.PutValue(str);
                                }
                                else
                                {
                                    cell.PutValue(obj);
                                }
                                hasRecord = true;
                            }
                        }
                        row++;
                    }
                    k++;
                }
            }
            if (hasRecord)
            {
                SaveFileDialog sdlg = new SaveFileDialog();
                sdlg.Filter = "Excel File(*.xls)|*.xls";
                if (sdlg.ShowDialog() == DialogResult.OK)
                {

                    workbook.Save(sdlg.FileName);

                    savePath = sdlg.FileName;
                }
            }
            return savePath;
        }

        /// <summary>
        /// datagridview导出到Excel
        /// </summary>
        /// <param name="ischeckcolumn">当前datagridView是否存在勾选列</param>
        /// <param name="hasRecord">判断当前是否存在导出的记录</param>
        /// <param name="outWorkbook">返回生成的excel对象</param>
        /// <returns></returns>
        public string ExportExcel_Public_SpecialRow(bool ischeckcolumn, out bool hasRecord, out Workbook outWorkbook)
        {
            Workbook workbook = new Workbook();
            Cells cells = workbook.Worksheets[0].Cells;
            string savePath = string.Empty;
            hasRecord = false;
            int k = 0;
            for (int j = (ischeckcolumn) ? 1 : 0; j < this.Columns.Count; j++)
            {
                var col = this.Columns[j];
                if (col.Visible)
                {
                    var cell = cells[0, k];
                    cell.PutValue(col.HeaderText);
                    int row = 0;
                    for (int i = 0; i < this.Rows.Count; i++)
                    {
                        var obj = this[0, i].Value;
                        if (ischeckcolumn)
                        {
                            if (obj == null || !bool.Parse(obj.ToString()))
                                continue;
                            if (obj is bool && bool.Parse(obj.ToString()))
                            {
                                cell = cells[row + 1, k];
                                cell.Style.Font.Color = this[j, i].Style.ForeColor;
                                obj = this[j, i].Value;
                                if (obj != null)
                                {
                                    var typ = obj.GetType();
                                    if (typ == typeof(DateTime))
                                    {
                                        cell.Style.Custom = "yyyy-mm-dd hh:mm:ss";
                                        cell.PutValue(obj.ToString());
                                    }
                                    else if (typ == typeof(string))
                                    {
                                        var str = obj.ToString();
                                        if (str.IsNum())
                                            cell.PutValue(double.Parse(str));
                                        else
                                            cell.PutValue(str);
                                    }
                                    else
                                    {
                                        cell.PutValue(obj);
                                    }
                                    hasRecord = true;
                                }
                            }
                        }
                        else
                        {
                            if (obj == null)
                                continue;
                            cell = cells[row + 1, k];
                            cell.Style.Font.Color = this[j, i].Style.ForeColor;
                            obj = this[j, i].Value;
                            if (obj != null)
                            {
                                var typ = obj.GetType();
                                if (typ == typeof(DateTime))
                                {
                                    cell.Style.Custom = "yyyy-mm-dd hh:mm:ss";
                                    cell.PutValue(obj.ToString());
                                }
                                else if (typ == typeof(string))
                                {
                                    var str = obj.ToString();
                                    if (str.IsNum())
                                        cell.PutValue(double.Parse(str));
                                    else
                                        cell.PutValue(str);
                                }
                                else
                                {
                                    cell.PutValue(obj);
                                }
                                hasRecord = true;
                            }
                        }
                        row++;
                    }
                    k++;
                }
            }

            outWorkbook = workbook;
            return savePath;
        }

        public string ExportExcel_Public_SpecialRowNew(bool ischeckcolumn, out bool hasRecord, out Workbook outWorkbook, List<string> otherInfo, List<string> redFieldInfo)
        {
            Workbook workbook = new Workbook();
            Cells cells = workbook.Worksheets[0].Cells;

            string savePath = string.Empty;
            hasRecord = false;
            int k = 0;
            int rowmun = this.Rows.Count;
            Worksheet sheet = workbook.Worksheets[0];

            for (int j = (ischeckcolumn) ? 1 : 0; j < this.Columns.Count; j++)
            {
                var col = this.Columns[j];
                if (col.Visible)
                {
                    var cell = cells[0, k];
                    cell.PutValue(col.HeaderText);
                    Aspose.Cells.Style styple = cell.GetStyle();
                    styple.IsTextWrapped = true;
                    cell.SetStyle(styple);
                    if (redFieldInfo.Count > 0)
                    {
                        foreach (string strRedInfo in redFieldInfo)
                            if (col.HeaderText.IndexOf(strRedInfo, System.StringComparison.Ordinal) != -1) cell.Style.Font.Color = Color.Red;
                    }



                    int row = 0;
                    for (int i = 0; i < this.Rows.Count; i++)
                    {
                        var obj = this[0, i].Value;

                        if (ischeckcolumn)
                        {
                            if (obj == null || !bool.Parse(obj.ToString()))
                                continue;
                            if (obj is bool && bool.Parse(obj.ToString()))
                            {
                                cell = cells[row + 1, k];
                                cell.Style.Font.Color = this[j, i].Style.ForeColor;

                                obj = this[j, i].Value;
                                if (obj != null)
                                {
                                    var typ = obj.GetType();
                                    if (typ == typeof(DateTime))
                                    {
                                        cell.Style.Custom = "yyyy-mm-dd hh:mm:ss";
                                        cell.PutValue(obj.ToString());
                                    }
                                    else if (typ == typeof(string))
                                    {
                                        var str = obj.ToString();
                                        if (str.IsNum())
                                            cell.PutValue(double.Parse(str));
                                        else
                                            cell.PutValue(str);
                                    }
                                    else
                                    {
                                        cell.PutValue(obj);
                                    }
                                    hasRecord = true;
                                }
                            }
                        }
                        else
                        {
                            if (obj == null)
                                continue;
                            sheet.AutoFitRow(row + 1);
                            cell = cells[row + 1, k];
                            cell.Style.Font.Color = this[j, i].Style.ForeColor;
                            //cell.Style.Font.Color = Color.Yellow;
                            obj = this[j, i].Value;
                            if (obj != null)
                            {
                                var typ = obj.GetType();
                                if (typ == typeof(DateTime))
                                {
                                    cell.Style.Custom = "yyyy-mm-dd hh:mm:ss";
                                    cell.PutValue(obj.ToString());
                                }
                                else if (typ == typeof(string))
                                {
                                    var str = obj.ToString();
                                    if (str.IsNum())
                                        cell.PutValue(double.Parse(str));
                                    else
                                        cell.PutValue(str);
                                }
                                else
                                {
                                    cell.PutValue(obj);
                                }
                                hasRecord = true;
                            }
                        }
                        row++;
                    }
                    k++;
                }
            }
            if (otherInfo != null)
            {
                int irow = rowmun + 2;
                foreach (string strinfo in otherInfo)
                {
                    irow++;
                    var cell1 = cells[irow, 0];
                    var obj1 = strinfo;
                    cell1.PutValue(obj1);
                }
            }

            sheet.AutoFitRow(0);
            outWorkbook = workbook;
            return savePath;
        }

        public void ExportExcel_Public()
        {
            Workbook workbook = new Workbook();
            Cells cells = workbook.Worksheets[0].Cells;

            int k = 0;
            bool hasRecord = false;
            for (int j = k; j < this.ColumnCount; j++)
            {
                var col = this.Columns[j];
                if (col.Visible)
                {
                    var cell = cells[0, k];
                    cell.PutValue(col.HeaderText);
                    for (int i = 0; i < this.RowCount; i++)
                    {
                        cell = cells[i + 1, k];
                        var obj = this[j, i].Value;
                        if (obj != null)
                        {
                            var typ = obj.GetType();
                            if (typ == typeof(DateTime))
                            {
                                cell.Style.Custom = "yyyy-mm-dd hh:mm:ss";
                                cell.PutValue(obj.ToString());
                            }
                            else if (typ == typeof(string))
                            {
                                var str = obj.ToString();
                                if (str.IsNum())
                                    cell.PutValue(double.Parse(str));
                                else
                                    cell.PutValue(str);
                            }
                            else
                            {
                                cell.PutValue(obj);
                            }
                            hasRecord = true;
                        }
                    }
                    k++;
                }
            }
            if (hasRecord)
            {
                SaveFileDialog sdlg = new SaveFileDialog();
                sdlg.Filter = "Excel File(*.xls)|*.xls";
                if (sdlg.ShowDialog() == DialogResult.OK)
                {
                    workbook.Save(sdlg.FileName);
                }
            }
        }


        private void tsmiExprotToExcel_Click(object sender, EventArgs e)
        {
            ExportExcel_Public();
        }

        private void DataGridViewW_MouseClick(object sender, MouseEventArgs e)
        {
            if (ShowEportContextMenu && e.Button == MouseButtons.Right
                && this.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.Cell)
            {
                _cmsExport.Show(this.PointToScreen(e.Location));
            }
        }

        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            Print(false);
        }

        private void tsmiPrintPreview_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        public void Print(bool isPreview)
        {
            if (PDC != null && this.Rows.Count > 0)
            {
                var dgv = (this as DataGridView);
                dgv.Print(PDC, true, false, false,
                    false, isPreview, ToPrintCols, ToPrintRows);
            }
        }

        public void Add(DataGridViewTextBoxColumnW columnW)
        {
            this.Columns.Add(columnW);
        }

        public override void Refresh()
        {
            base.Refresh();
            HeaderTextRefresh();
        }

        public void HeaderTextRefresh()
        {
            foreach (var column in this.Columns)
            {
                if (column is DataGridViewTextBoxColumnW)
                    ((DataGridViewTextBoxColumnW)column).HeaderTextRefresh();
            }
        }
    }

    public class DataGridViewTextBoxColumnW : DataGridViewTextBoxColumn
    {
        public DataGridViewTextBoxColumnW(DataGridViewColumnHeaderCellW headerCell)
        {
            this.HeaderCell = headerCell;
            HeaderTextRefresh();
        }

        public void HeaderTextRefresh()
        {
            if (HeaderCell is DataGridViewColumnHeaderCellW)
            {
                try
                {
                    var cell = ((DataGridViewColumnHeaderCellW)HeaderCell);
                    var value = cell.DataSourceType.InvokeMember(cell.FieldName, System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.GetProperty, null, cell.HeaderTextDataSource, null);
                    this.HeaderText = cell.Prefix + (value == null ? "" : value.ToString()) + cell.Suffix;
                }
                catch { }
            }
        }
    }


    public delegate void datagridviewcheckboxHeaderEventHander(object sender, datagridviewCheckboxHeaderEventArgs e);

    //定义包含列头checkbox选择状态的参数类 
    public class datagridviewCheckboxHeaderEventArgs : EventArgs
    {
        private bool checkedState = false;

        public bool CheckedState
        {
            get { return checkedState; }
            set { checkedState = value; }
        }
    }
    public class DataGridViewColumnHeaderCellW : DataGridViewColumnHeaderCell
    {
        public object HeaderTextDataSource { get; set; }
        private Type _dataSourceType = null;
        public Type DataSourceType
        {
            get
            {
                if (HeaderTextDataSource != null && _dataSourceType == null)
                    _dataSourceType = HeaderTextDataSource.GetType();
                return _dataSourceType;
            }
            set { _dataSourceType = value; }
        }
        public string FieldName { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }


        Point checkBoxLocation;
        Size checkBoxSize;
        bool _checked = false;
        Point _cellLocation = new Point();
        System.Windows.Forms.VisualStyles.CheckBoxState _cbState =
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
        public event datagridviewcheckboxHeaderEventHander OnCheckBoxClicked; 
        //绘制列头checkbox 
        protected override void Paint(System.Drawing.Graphics graphics,
                                      System.Drawing.Rectangle clipBounds,
                                      System.Drawing.Rectangle cellBounds,
                                      int rowIndex,
                                      DataGridViewElementStates dataGridViewElementState,
                                      object value,
                                      object formattedValue,
                                      string errorText,
                                      DataGridViewCellStyle cellStyle,
                                      DataGridViewAdvancedBorderStyle advancedBorderStyle,
                                      DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                       dataGridViewElementState, value,
                       formattedValue, errorText, cellStyle,
                       advancedBorderStyle, paintParts);
            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics,
                                                   System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            p.X = cellBounds.Location.X +
                  (cellBounds.Width / 2) - (s.Width / 2) - 1; //列头checkbox的X坐标 
            p.Y = cellBounds.Location.Y +
                  (cellBounds.Height / 2) - (s.Height / 2); //列头checkbox的Y坐标 
            _cellLocation = cellBounds.Location;
            checkBoxLocation = p;
            checkBoxSize = s;
            if (_checked)
                _cbState = System.Windows.Forms.VisualStyles.
                                  CheckBoxState.CheckedNormal;
            else
                _cbState = System.Windows.Forms.VisualStyles.
                                  CheckBoxState.UncheckedNormal;
            CheckBoxRenderer.DrawCheckBox
                (graphics, checkBoxLocation, _cbState);
        }

        /// <summary> 
        /// 点击列头checkbox单击事件 
        /// </summary> 
        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {

            Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
            if (p.X >= checkBoxLocation.X && p.X <=
                checkBoxLocation.X + checkBoxSize.Width
            && p.Y >= checkBoxLocation.Y && p.Y <=
                checkBoxLocation.Y + checkBoxSize.Height)
            {
                _checked = !_checked;


                //获取列头checkbox的选择状态 
                datagridviewCheckboxHeaderEventArgs ex = new datagridviewCheckboxHeaderEventArgs();
                ex.CheckedState = _checked;

                object sender = new object();//此处不代表选择的列头checkbox，只是作为参数传递。应该列头checkbox是绘制出来的，无法获得它的实例 

                if (OnCheckBoxClicked != null)
                {
                    OnCheckBoxClicked(sender, ex);//触发单击事件 
                    this.DataGridView.InvalidateCell(this);

                }

            }
            base.OnMouseClick(e);
        } 
    }
}
