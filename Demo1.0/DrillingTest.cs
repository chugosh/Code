using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class DrillingTest
    {
        string constr = "server=.;database=UPRESSURE;uid=sa;pwd=sdkjdx";
        private Workbook workBook;
        private Worksheet workSheet;
        private Workbook workBook_excel;
        private Worksheet workSheet_excel;
        string excelFilePath = CreateExcelTest.GetCreateExcelTest().ExcelFilePath();
        //得出煤粉量最大值
        double[] max = new double[] { 2.31, 2.42, 2.37, 2.47, 2.45 };
        //得出最大深度
        int[] maxDeep = new int[] { 8, 7, 7, 8, 7 };
        //得出最大平均
        double[] singleAverage = new double[] { 2.08, 2.19, 2.17, 2.15, 2.16 };
        //孔的数量
        int number = 6;
        //相对工作面位置
        int[] working_face_position = new int[] { 10, 30, 50, 70, 90 };

        internal void Start()
        {
            OpenExcel();
            ConnectSQL(constr);
            InsertValue();
            SaveReportFile();
        }

        private void ConnectSQL(string constr)
        {
            SqlConnection sqlConnection = new SqlConnection(constr);
            string str = "SELECT 单孔最大值,最大孔深,距工作面距离 FROM 钻屑法数据表 WHERE 日期 = '2018-3-21' ORDER BY 单孔最大值 DESC";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str,sqlConnection);
            DataSet ds = new DataSet();
            DataTable datatable = new DataTable();
            sqlDataAdapter.Fill(ds);
            datatable = ds.Tables[0];
            int i = 0;

        }

        private void OpenExcel()
        {
            string FilePath = @"C:\Users\14439\Desktop\yingpanhao\钻屑法模板.xlsx";
            
            workBook = File.Exists(FilePath) ? new Workbook(FilePath) : new Workbook();
            workSheet = workBook.Worksheets[0];

            workBook_excel = CreateExcelTest.GetCreateExcelTest().GetWorkBookExcel();
            workSheet_excel = workBook_excel.Worksheets[0];
            //将模板拷贝到报表excel
            workSheet_excel.Copy(workSheet);
            workBook_excel.Save(excelFilePath, SaveFormat.Xlsx);
        }

        private void InsertValue()
        {
            InsertValue_fuyun(number, max, maxDeep, singleAverage, working_face_position);
            InsertValue_jiaoyun(number+1, max, maxDeep, singleAverage, working_face_position);
        }

        //辅运通道
        private void InsertValue_fuyun(int number, double[] max, int[] maxDeep, double[] singleAverage, int[] working_face_position)
        {
            int location = 0;
            double maxAverage = singleAverage[0];
            double maxValue = max[0];

            Cell cellItem_number = workSheet_excel.Cells["E3"];
            cellItem_number.PutValue(number);
            //singAverage[]
            for (int i = 1; i < singleAverage.Length; i++)
            {
                if (singleAverage[i] > maxAverage)
                    maxAverage = singleAverage[i];
            }
            Cell cellItem1 = workSheet_excel.Cells["F3"];
            cellItem1.PutValue(maxAverage);

            //max[]
            for (int i = 1; i < max.Length; i++)
            {
                if (max[i] > maxValue)
                {
                    maxValue = max[i];
                    location = i;
                }
            }
            //
            Cell cellItem2 = workSheet_excel.Cells["J3"];
            cellItem2.PutValue(maxValue);
            Cell cellItem3 = workSheet_excel.Cells["M3"];
            cellItem3.PutValue(maxDeep[location]);
            Cell cellItem6 = workSheet_excel.Cells["H3"];
            cellItem6.PutValue("距工作面" + working_face_position[location] + "米aaa");

            if (maxDeep[location] <= 10 && maxDeep[location] >= 1)
            {
                Cell cellItem4 = workSheet_excel.Cells["O3"];
                if (maxValue > 3.5)
                {
                    cellItem4.PutValue("是");
                    Cell cellItem5 = workSheet_excel.Cells["R3"];
                    cellItem5.PutValue("有冲击危险");
                }
                else
                {
                    cellItem4.PutValue("否");
                    Cell cellItem5 = workSheet_excel.Cells["R3"];
                    cellItem5.PutValue("无冲击危险");
                }

            }

        }
        //胶运通道
        private void InsertValue_jiaoyun(int number, double[] max, int[] maxDeep, double[] singleAverage, int[] working_face_position)
        {
            int location = 0;
            double maxAverage = 0;
            double maxValue = 0;
            Cell cellItem_number = workSheet_excel.Cells["E4"];
            cellItem_number.PutValue(number);
            //singAverage[]
            for (int i = 1; i < singleAverage.Length; i++)
            {
                maxAverage = singleAverage[0];
                if (singleAverage[i] > maxAverage)
                    maxAverage = singleAverage[i];
            }
            Cell cellItem1 = workSheet_excel.Cells["F4"];
            cellItem1.PutValue(maxAverage);

            //max[]
            for (int i = 1; i < max.Length; i++)
            {
                maxValue = max[0];
                if (maxValue < max[i])
                {
                    maxValue = max[i];
                    location = i;
                }
            }
            //
            Cell cellItem2 = workSheet_excel.Cells["J4"];
            cellItem2.PutValue(maxValue);
            Cell cellItem3 = workSheet_excel.Cells["M4"];
            cellItem3.PutValue(maxDeep[location]);
            Cell cellItem6 = workSheet_excel.Cells["H4"];
            cellItem6.PutValue("距工作面" + working_face_position[location] + "米aaa");

            if (maxDeep[location] <= 10 && maxDeep[location] >= 1)
            {
                Cell cellItem4 = workSheet_excel.Cells["O4"];
                if (maxValue > 3.5)
                {
                    cellItem4.PutValue("是");
                    Cell cellItem5 = workSheet_excel.Cells["R4"];
                    cellItem5.PutValue("有冲击危险");
                }
                else
                {
                    cellItem4.PutValue("否");
                    Cell cellItem5 = workSheet_excel.Cells["R4"];
                    cellItem5.PutValue("无冲击危险");
                }

            }

        }

        private void SaveReportFile()
        {
            if (!Directory.Exists(@"C:\Users\14439\Desktop\yingpanhao\报表"))
                Directory.CreateDirectory(@"C:\Users\14439\Desktop\yingpanhao\报表");
            //  设置执行公式计算 - 如果代码中用到公式，需要设置计算公式，导出的报表中，公式才会自动计算
            workBook_excel.CalculateFormula(true);
            //  保存文件
            workBook_excel.Save(excelFilePath, SaveFormat.Xlsx);
        }

    }
}
