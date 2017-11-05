using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using classmate;
using teamwork1;

namespace 吴伟根
{
    public partial class WGform : Form
    {
        
        
        public WGform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.xls";
            string strPath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    strPath = dialog.FileName;
                    ConnectExcel.path = strPath;
                    string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + ";" + "Extended Properties='Excel 8.0;HDR=NO;IMEX=1';";
                    OleDbConnection Con = new OleDbConnection(strCon);//建立连接
                    string strSql = "select * from [Sheet1$]";//表名的写法也应注意不同，对应的excel表为sheet1，在这里要在其后加美元符号$，并用中括号
                    OleDbCommand Cmd = new OleDbCommand(strSql, Con);//建立要执行的命令
                    OleDbDataAdapter da = new OleDbDataAdapter(Cmd);//建立数据适配器
                    DataSet ds = new DataSet();//新建数据集
                    da.Fill(ds, "shyman");//把数据适配器中的数据读到数据集中的一个表中（此处表名为shyman，可以任取表名）
                                          //指定datagridview1的数据源为数据集ds的第一张表（也就是shyman表），也可以写ds.Table["shyman"]

                    dataGridView1.DataSource = ds.Tables[0];
                    ConnectExcel.ds = ds;
                    添加同学ToolStripMenuItem.Enabled = true;
                    搜索ToolStripMenuItem.Enabled = true;
                    导出ToolStripMenuItem.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);//捕捉异常
                }
            }

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

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strPath=Application.StartupPath + "\\Default.xls";
            ConnectExcel.path = strPath;
            string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + ";" + "Extended Properties='Excel 8.0;HDR=NO;IMEX=1';";
            OleDbConnection Con = new OleDbConnection(strCon);//建立连接
            string strSql = "select * from [Sheet1$]";//表名的写法也应注意不同，对应的excel表为sheet1，在这里要在其后加美元符号$，并用中括号
            OleDbCommand Cmd = new OleDbCommand(strSql, Con);//建立要执行的命令
            OleDbDataAdapter da = new OleDbDataAdapter(Cmd);//建立数据适配器
            DataSet ds = new DataSet();//新建数据集
            da.Fill(ds, "shyman");//把数据适配器中的数据读到数据集中的一个表中（此处表名为shyman，可以任取表名）
                                  //指定datagridview1的数据源为数据集ds的第一张表（也就是shyman表），也可以写ds.Table["shyman"]

            dataGridView1.DataSource = ds.Tables[0];
            ConnectExcel.ds = ds;
        }

        private void 添加同学ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formadd fadd = new Formadd();
            fadd.ShowDialog();
        }

        private void 搜索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearch fsea = new frmSearch();
            fsea.ShowDialog();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSetToExcel(ConnectExcel.ds, true);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
