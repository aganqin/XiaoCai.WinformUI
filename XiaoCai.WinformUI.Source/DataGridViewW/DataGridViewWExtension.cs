using System.Collections.Generic;
using Printing.DataGridViewPrint.Tools;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace XiaoCai.WinformUI
{
    public static class DataGridViewExtension
    {
        public static void Print(this DataGridView dgv,
            PrintDocument printDocument,
            bool printLevelByLevel,
            bool centerPage,
            bool fitColToPage,
            bool showPrintSetDlg,
           bool showPreviewDlg,
            List<int> toPrintCols,
            List<int> toPrintRows
           )
        {
            DataGridView dgvToPrint = dgv.Copy(toPrintCols, toPrintRows);

            var printProvider = PrintingDataGridViewProvider.Create(
                 printDocument,
                 dgvToPrint,
                  printLevelByLevel,
                 centerPage,
                 fitColToPage,
                 new TitlePrintBlock()
                 {
                     ForeColor = Color.DarkBlue,
                     Font = new Font(SystemFonts.CaptionFont.FontFamily, 16),
                     Title = printDocument.DocumentName
                 },
                 null,
                 null);

            bool bContinue = true;
            if (showPrintSetDlg)//显示打印设置对话框
                bContinue = new PrintDialog().ShowDialog() == DialogResult.OK;
            if (bContinue)
            {
                if (showPreviewDlg)//打印预览
                {
                    //printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
                    PrintPreviewDialog previewdlg = new PrintPreviewDialog();
                    previewdlg.ShowIcon = false;
                    previewdlg.Document = printDocument;
                    previewdlg.ShowDialog();
                }
                else
                {
                    printDocument.Print();
                }
            }
        }
        //修改：何晓明 20110722 打印页数
        //static int iPages = 0;
        //static void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    iPages++;
        //    e.Graphics.DrawString("第"+iPages.ToString()+"页", new Font("宋体", 8), new SolidBrush(Color.Black), new PointF(600, 800));
        //}
        //
        /// <summary>
        /// copy data from exist dgv by special rows and cols
        /// </summary>
        /// <param name="dgv1"></param>
        /// <param name="colIndexs"></param>
        /// <param name="rowIndexs"></param>
        /// <returns></returns>
        public static DataGridView Copy(this DataGridView dgv1, List<int> colIndexs, List<int> rowIndexs)
        {
            if (colIndexs == null && rowIndexs == null) return dgv1;

            var indexs = colIndexs == null ? GetNumList(dgv1.Columns.Count) : colIndexs;
            DataGridView dgv = new DataGridView();

            foreach (var j in indexs)
            {
                var col = dgv1.Columns[j];
                dgv.Columns.Add(col.Name, col.HeaderText);
            }
            var indexs2 = rowIndexs == null ? GetNumList(dgv1.Rows.Count) : rowIndexs;

            foreach (int i in indexs2)
            {
                var lst = new List<object>();
                foreach (var j in indexs)
                {
                    lst.Add(dgv1[j, i].Value);
                }
                dgv.Rows.Add(lst.ToArray());
            }
            return dgv;
        }

        public static List<int> GetNumList(this int maxNum, int startNum)
        {
            var lst = new List<int>();
            //int i = 0;
            while (startNum < maxNum)
            {
                lst.Add(startNum++);
            }
            return lst;
        }

        public static List<int> GetNumList(this int maxNum)
        {
            return maxNum.GetNumList(0);
        }

        public static bool IsNum(this string str)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+\b$");
            return regex.IsMatch(str);
        }
    }
}
