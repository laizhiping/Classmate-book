using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace save
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool DataSetToExcel(DataSet dataSet, bool isShowExcle)
        {
            DataTable dataTable = dataSet.Tables[0];
            int rowNumber = dataTable.Rows.Count;//不包括字段名
            int columnNumber = dataTable.Columns.Count;
            int colIndex = 0;

            if (rowNumber == 0)
            {
                return false;
            }

            //建立Excel对象 
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //excel.Application.Workbooks.Add(true);
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            excel.Visible = isShowExcle;
            //Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range;

            //生成字段名称 
            foreach (DataColumn col in dataTable.Columns)
            {
                colIndex++;
                excel.Cells[1, colIndex] = col.ColumnName;
            }

            for (int r = 0; r < rowNumber; r++)
            {
                for (int c = 0; c < columnNumber; c++)
                {
                    excel.Cells[r + 2, c + 1] = dataTable.Rows[r][c];
                }
            }



            return true;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            //DataRow dr = dt.NewRow();
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(System.String));
            dt.Columns.Add("sex", typeof(System.String));
            //然后给datatable增加数据行，类似这样增加多行。
            DataRow dr = dt.NewRow();
            dr["name"] = "王二小";
            dr["sex"] = "男";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            DataSetToExcel(ds, true);
            MessageBox.Show("保存成功");
        }
    }
}
