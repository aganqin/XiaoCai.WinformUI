using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;


namespace XiaoCai.WinformUI
{
    public partial class Pager : UserControl, IStyle
    {
        private System.Drawing.Color _backColor = Color.Transparent;
        private bool _isShowGroup = true;

        [Description("是否显示组页数"), Category("分页设置")]
        public bool IsShowGroup
        {
            get { return _isShowGroup; }
            set
            {
                _isShowGroup = value;
                BuildPageControl();
            }
        }
        int _currentPage = 1;//当前页 
        /// <summary>
        /// 当前页 
        /// </summary>
        [Description("当前页"), Category("分页设置")]
        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; }
        }

        /// <summary>
        /// 每页显示条数
        /// </summary>
        [Description("每页显示条数"), Category("分页设置")]
        public int PageSize { get; set; }

        /// <summary>
        /// 总共多少页 
        /// </summary>
        [Description("总共多少页"), Category("分页设置")]
        private int PageTotal { get; set; }

        /// <summary>
        /// 当前组
        /// </summary>
        [Description("当前组"), Category("分页设置")]
        private int CurrentGroup { get; set; }

        /// <summary>
        /// 每组显示页数
        /// </summary>
        [Description("每组显示页数"), Category("分页设置")]
        public int GroupSize { get; set; }


        /// <summary>
        /// 总共多少组
        /// </summary>
        [Description("总共多少组"), Category("分页设置")]
        private int GroupTotal { get; set; }

        /// <summary>
        /// 总的记录数
        /// </summary>
        private int _recordCount;//总的记录数
        [Description("总的记录数"), Category("分页设置")]
        public int RecordCount
        {
            get { return _recordCount; }
            set
            {
                _recordCount = value;
                InitData();// 初始化数据
                BuildPageControl();
                PageChanged();//当前页改变事件
            }
        }

        /// <summary>
        /// 按钮宽度
        /// </summary>
        [Description("按钮宽度"), Category("分页设置")]
        private int ButtonWidth { get; set; }
        [Description("按钮宽度"), Category("分页设置")]
        private int ButtonWidth3 { get; set; }
        private int _buttonHeight = 20;//按钮高度
        /// <summary>
        /// 按钮高度
        /// </summary>
        [Description("按钮高度"), Category("分页设置")]
        private int ButtonHeight
        {
            get { return _buttonHeight; }
            set { _buttonHeight = value; }
        }

        /// <summary>
        /// 按钮间距离
        /// </summary>
        [Description("按钮间距离"), Category("分页设置")]
        private int ButtonDistance { get; set; }



        List<Control> _listControl = new List<Control>();//分页的按钮集合

        public delegate void PageChangeDelegate();
        /// <summary>
        /// 当前页改变时发生的事件
        /// </summary>

        public event PageChangeDelegate PageChanged;
        [Description("当前页改变时发生的事件"), Category("分页设置")]
        public Pager()
        {
            ButtonDistance = 0;
            ButtonWidth = 20;
            GroupTotal = 0;
            GroupSize = 0;
            CurrentGroup = 1;
            PageTotal = 0;
            PageSize = 0;
            //Style = Style.Office2007Blue;
            InitializeComponent();
            this.Width = btnGo.Location.X + btnGo.Width;
            this.Width = btnGo.Location.X + btnGo.Width;
            this.Height = ButtonHeight;
            btnPreGroup.Height = ButtonHeight;
            btnNextGroup.Height = ButtonHeight;
            btnFirstPage.Height = ButtonHeight;
            btnPrePage.Height = ButtonHeight;
            btnNextPage.Height = ButtonHeight;
            btnLastPage.Height = ButtonHeight;
            cmbPage.Height = ButtonHeight;
            btnGo.Height = ButtonHeight;
            lblPagerMessage.Height = ButtonHeight;
            PageChanged = SetBtnPrePageAndBtnNextPage;
            CurrentPage = 1;
            PageChanged();
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            if (PageSize > 0 && GroupSize > 0)
            {
                PageTotal = RecordCount / PageSize;//总共多少页            
                if (RecordCount % PageSize != 0)
                {
                    PageTotal++;
                }

                GroupTotal = PageTotal / GroupSize;//总共多少组
                if (PageTotal % GroupSize != 0)
                {
                    GroupTotal++;
                }
                for (int i = 0; i < PageTotal; i++)
                {
                    cmbPage.Items.Add((i + 1));//添加下拉框值
                }
                BuildPageControl();//创建分页数字按钮   
            }



        }
        /// <summary>
        /// 创建分页数字按钮
        /// </summary>
        private void BuildPageControl()
        {
            int x = 0;//按钮横坐标
            int num = 0;//按钮数
            for (int i = GroupSize * (CurrentGroup - 1); i < GroupSize * CurrentGroup; i++)
            {
                if (i + 1 > PageTotal)
                {
                    break;
                }
                num++;
            }

            //循环遍历移除控件
            foreach (Control c in _listControl)
            {
                this.Controls.Remove(c);
            }
            _listControl = new List<Control>();
            ButtonW button = null;
            //循环创建控件
            if (IsShowGroup)
            {

                for (int i = GroupSize * (CurrentGroup - 1); i < GroupSize * CurrentGroup; i++)
                {
                    if (i + 1 > PageTotal || i + 1 <= 0)
                    {
                        break;
                    }

                    button = new ButtonW();
                    button.Style = Style;

                    button.Text = Convert.ToString(i + 1);
                    button.Width = ButtonWidth;
                    button.Height = ButtonHeight;
                    //button.Location = new Point(250 + x, y);//btnPreGroup.Location
                    button.Location = new Point(btnPreGroup.Location.X - x - ButtonDistance - 25,
                                                btnPreGroup.Location.Y); //btnPreGroup.Location
                    ButtonDistance = 2;
                    button.Anchor =
                        AnchorStyles.Top | AnchorStyles.Right;
                    button.Click += new EventHandler(OnClick);
                    this.Controls.Add(button);
                    button.BringToFront();
                    _listControl.Add(button); //添加进分页按钮的集合
                    x += ButtonWidth + ButtonDistance;
                }
                if (!IsShowGroup)
                {
                    btnPreGroup.Visible = false;
                    btnNextGroup.Visible = false;
                }
                else
                {
                    btnPreGroup.Visible = true;
                    btnNextGroup.Visible = true;
                    //上一组是否可用
                    if (CurrentGroup == 1)
                    {
                        btnPreGroup.Enabled = false;
                    }
                    else
                    {
                        btnPreGroup.Enabled = true;
                    }
                    //下一组是否可用
                    if (CurrentGroup == GroupTotal)
                    {
                        btnNextGroup.Enabled = false;
                    }
                    else
                    {
                        btnNextGroup.Enabled = true;
                    }
                }

            }

        }
        /// <summary>
        /// 数字按钮分页
        /// </summary>
        private void OnClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null) CurrentPage = int.Parse(button.Text);
            PageChanged();
        }

        /// <summary>
        /// 设置上一页、下一页是否可用以及当前页按钮字体颜色
        /// </summary>
        private void SetBtnPrePageAndBtnNextPage()
        {
            //上一页是否可用
            if (CurrentPage == 1)
            {
                btnPrePage.Enabled = false;
            }
            else
            {
                btnPrePage.Enabled = true;
            }
            //下一页是否可用
            if (CurrentPage == PageTotal)
            {
                btnNextPage.Enabled = false;
            }
            else
            {
                btnNextPage.Enabled = true;
            }
            //首页是否可用
            if (CurrentPage == 1)
            {
                btnFirstPage.Enabled = false;
            }
            else
            {
                btnFirstPage.Enabled = true;
            }
            //首页是否可用
            if (CurrentPage == PageTotal)
            {
                btnLastPage.Enabled = false;
            }
            else
            {
                btnLastPage.Enabled = true;
            }
            if (!IsShowGroup)
            {
                btnPreGroup.Visible = false;
                btnNextGroup.Visible = false;
            }
            else
            {
                btnPreGroup.Visible = true;
                btnNextGroup.Visible = true;
            }
            //设置数字分页按钮文本颜色
            foreach (Control c in this.Controls)
            {
                //当前页字体为红色
                if (c.Text == Convert.ToString(CurrentPage) && c is ButtonW)
                {
                    c.ForeColor = Color.Red;
                }
                //else
                //{

                //    if (_style == Style.Office2007Red&&!(c is LabelW))
                //    {
                //        c.ForeColor = Color.FromArgb(255, 255, 51);
                //    }
                //    else if (!(_style == Style.Office2007Red && c is LabelW))
                //    {
                //        c.ForeColor = Color.Black;
                //    }
                //}
            }
            lblPagerMessage.Text = string.Format("共 {0} 条记录，每页 {1} 条，共 {2} 页", RecordCount, PageSize, PageTotal);
            cmbPage.Text = Convert.ToString(CurrentPage);

        }
        /// <summary>
        /// 上一组
        /// </summary>
        private void btnPreGroup_Click(object sender, EventArgs e)
        {
            CurrentGroup--;
            BuildPageControl();
            CurrentPage = GroupSize * (CurrentGroup - 1) + 1;
            PageChanged();
        }
        /// <summary>
        /// 下一组
        /// </summary>
        private void btnNextGroup_Click(object sender, EventArgs e)
        {
            CurrentGroup++;
            BuildPageControl();
            CurrentPage = GroupSize * (CurrentGroup - 1) + 1;
            PageChanged();
        }
        /// <summary>
        /// 上一页
        /// </summary>
        private void btnPrePage_Click(object sender, EventArgs e)
        {
            //如果是当前组的第一页，直接上一组
            if (CurrentPage == GroupSize * (CurrentGroup - 1) + 1)
            {
                CurrentGroup--;
                BuildPageControl();
                CurrentPage--;
                PageChanged();
                return;
            }
            CurrentPage--;
            PageChanged();
        }
        /// <summary>
        /// 下一页
        /// </summary>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            //如果是当前组的最后一页，直接下一组
            if (CurrentPage == GroupSize * (CurrentGroup - 1) + GroupSize)
            {
                btnNextGroup_Click(null, null);
                return;
            }
            CurrentPage++;
            PageChanged();
        }
        /// <summary>
        /// 转到第几页
        /// </summary>
        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentPage = int.Parse(cmbPage.Text);
                PageChanged();
            }
            catch
            {
                MessageBox.Show("请输入数字");
            }
        }

        public DataTable GetViewData(int currentPage, DataTable dt)
        {
            int beginNumber = PageSize * (currentPage - 1);

            return SplitDs(beginNumber, PageSize, dt);
        }

        private DataTable SplitDs(int begin, int limit, DataTable dt)
        {

            DataTable vdt = new DataTable();
            vdt = dt.Clone();
            for (int i = begin; i < (begin + limit); i++)
            {
                if (i >= (dt.Rows.Count)) //到达这一行，退出
                    break;
                vdt.ImportRow(dt.Rows[i]);
            }
            dt.Dispose();
            return vdt;

        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            CurrentGroup = 1;
            BuildPageControl();
            CurrentPage = 1;
            PageChanged();
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (PageTotal % GroupSize != 0)
            {
                CurrentGroup = Convert.ToInt32(PageTotal / GroupSize) + 1;
            }
            else
            {
                CurrentGroup = Convert.ToInt32(PageTotal / GroupSize);
            }
            BuildPageControl();
            CurrentPage = PageTotal;
            PageChanged();
        }

        private void cmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CurrentPage = int.Parse(cmbPage.Text);
                PageChanged();
            }
            catch
            {
                MessageBox.Show("请输入数字");
            }
        }

        private Style _style = Style.Office2007Blue;

        /// <summary>This feature will paint the background color of the control.</summary>
        [Category("Appearance"), Description("This feature will paint the background color of the control.")]
        public override System.Drawing.Color BackColor
        {
            get { return _backColor; }
            set { _backColor = value; 
                this.Invalidate(); }
        }

        [Description("皮肤样式"), Category("皮肤样式")]
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
            btnPreGroup.Style = style;
            btnFirstPage.Style = style;
            btnGo.Style = style;
            cmbPage.Style = style;
            btnLastPage.Style = style;
            btnNextGroup.Style = style;
            btnNextPage.Style = style;
            btnPreGroup.Style = style;
            btnPrePage.Style = style;
            BackColor = Color.Transparent;
            _style = style;

            Refresh();
        }
    }
}
