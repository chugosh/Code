using System;
using Aspose.Cells;
using Excel = Aspose.Cells;
using System.IO;
using System.Data;

namespace Aspose_Demo
{
    public class ExcelGenerator
    {
        #region 文件变量
        /// <summary>
        /// Aspose - Workbook
        /// </summary>
        private Workbook CurrentWorkbook;
        private Worksheet DetailSheet;
        private Cells cells;
        #endregion

        #region 构造函数
        /// <summary>
        /// 引入破解证书
        /// </summary>
        public ExcelGenerator()
        {
            try
            {
                Excel.License l = new Excel.License();
                l.SetLicense("Aid/License.lic");
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 生成 Excel 主方法
        /// </summary>
        public void Start()
        {
            //  第一步：打开模板
            OpenTemp();

            //  第二步：获取数据，并写入数据

            //  2.1 填写数据到单元格
            InsertValue();

            //  2.2 填写DataTable到Excel
           // InsertTable();

            //  第三步：保存文件
            SaveReprotFile();
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 打开模板
        /// </summary>
        private void OpenTemp()
        {
            //模板文件路径
            string Template_File_Path = @"C:\Users\14439\Desktop\yingpanhao\excel测试\test.xlsx";


            //  打开 Excel 模板
            CurrentWorkbook = File.Exists(Template_File_Path) ? new Workbook(Template_File_Path) : new Workbook();
            //CurrentWorkbook = new Workbook();

            //  打开第一个sheet
            DetailSheet = CurrentWorkbook.Worksheets[0];


            //cells = DetailSheet.Cells;
            //cells.Merge(0,0,2,8);
            //cells[0, 0].PutValue("表格题目");
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <returns></returns>
        private void SaveReprotFile()
        {
            // if (!Directory.Exists(@".\Excel"))
            //Directory.CreateDirectory(@".\Excel");

            if (!Directory.Exists(@"C:\Users\14439\Desktop\yingpanhao\excel测试"))
                Directory.CreateDirectory(@"C:\Users\14439\Desktop\yingpanhao\excel测试");

            //  设置执行公式计算 - 如果代码中用到公式，需要设置计算公式，导出的报表中，公式才会自动计算
            CurrentWorkbook.CalculateFormula(true);

            //  生成的文件名称
            string ReportFileName = string.Format("Excel_{0}.xlsx", DateTime.Now.ToString("yyyy-MM-dd"));

            //  保存文件
            CurrentWorkbook.Save(@"C:\Users\14439\Desktop\yingpanhao\excel测试\" + ReportFileName, SaveFormat.Xlsx);

        }

        /// <summary>
        /// 把一个数值写入到Excel
        /// </summary>
        private void InsertValue()
        {
            // 比如要在 A1 位置写入 Demo这个值

            DetailSheet.AutoFitColumns();
            DetailSheet.AutoFitRows();

            Cell itemCell = DetailSheet.Cells["B3"];

            itemCell.PutValue("lidong");

            Cell itemCell2 = DetailSheet.Cells["B4"];

            itemCell2.PutValue("111111");


        }

        /// <summary>
        /// 把Table数据写入到Excel
        /// </summary>
        private void InsertTable()
        {
            //  获取 Table 数据
            DataTable dt = GetData();

            //  写入数据的起始位置
            string cell_start_region = "B3";
            //  获得开始位置的行号
            int startRow = DetailSheet.Cells[cell_start_region].Row;
            //  获得开始位置的列号  
            int startColumn = DetailSheet.Cells[cell_start_region].Column;

            //  写入Excel。参数说明，直接查阅文档
            DetailSheet.Cells.ImportDataTable(dt, false, startRow, startColumn, true, true);
        }

        /// <summary>
        /// 获取Table数据源，这里只是举例，实际可能是数据库中获得数据，以实际情况为准
        /// </summary>
        /// <returns></returns>
        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("名字", typeof(string)));
            

            DataRow dr1 = dt.NewRow();
            dr1["成绩"] = 1;
            dr1["名字"] = "Jack";
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["成绩"] = 2;
            dr2["名字"] = "Tom";
            dt.Rows.Add(dr2);

            return dt;
        }
        #endregion
    }
}
