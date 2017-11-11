using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace classmate
{
    public partial class Formadd : Form
    {
        public Formadd()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public DataSet ExcelToDS(string Path)
        {
            string strConn = @"Provider = Microsoft.ACE.OLEDB.12.0;Data Source="+Path+";Extended Properties='Excel 12.0;HDR=yes;IMEX=1';";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "select * from [sheet1$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "Table1");
            conn.Close();
            return ds;
        }
        public void DSToExcel(string Path, DataSet oldds)
        {
            //先得到汇总EXCEL的DataSet 主要目的是获得EXCEL在DataSet中的结构 
            string strCon = @"Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties='Excel 12.0;HDR=no;IMEX=0';";
            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = "select * from [Sheet1$]";
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
            System.Data.OleDb.OleDbCommandBuilder builder = new OleDbCommandBuilder(myCommand);
            //QuotePrefix和QuoteSuffix主要是对builder生成InsertComment命令时使用。 
            builder.QuotePrefix = "[";     //获取insert语句中保留字符（起始位置） 
            builder.QuoteSuffix = "]"; //获取insert语句中保留字符（结束位置） 
            DataSet newds = new DataSet();
            myCommand.Fill(newds, "Table1");
            DataRow nrow = newds.Tables["Table1"].NewRow();
            for (int j = 0; j < newds.Tables[0].Columns.Count; j++)
            {
                nrow[j] = oldds.Tables[0].Rows[oldds.Tables[0].Rows.Count - 1][j];
            }
            newds.Tables["Table1"].Rows.Add(nrow);
            myCommand.Update(newds, "Table1");
            myConn.Close();       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = ExcelToDS(@"D:\1.xlsx");
            DataRow mydr = ds.Tables["Table1"].NewRow();
            if (tbname.Text.Trim() != "")
            {
                mydr[0] = tbname.Text.Trim();
                mydr[1] = tbaddress.Text.Trim();
                mydr[2] = tbphone.Text.Trim();
                mydr[3] = tbWeChat.Text.Trim();
                mydr[4] = tbmail.Text.Trim();
                mydr[5] = tbQQ.Text.Trim();
                mydr[6] = tbperson.Text.Trim();
            }
            else MessageBox.Show("姓名不能为空");
            ds.Tables["Table1"].Rows.Add(mydr);
            DSToExcel(@"D:\1.xlsx", ds);        
            MessageBox.Show("添加成功");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
