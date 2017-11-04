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

namespace Tongxuelu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string strConn = @"Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\111.xlsx" + ";" + "Extended Properties='Excel 12.0;HDR=no;IMEX=1';";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "select * from [sheet1$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            conn.Close();

            name.Text = ds.Tables[0].Rows[0][0].ToString();
            WeChat.Text = ds.Tables[0].Rows[0][1].ToString();
            qq.Text = ds.Tables[0].Rows[0][2].ToString();
            Telephone.Text = ds.Tables[0].Rows[0][3].ToString();
            mailbox.Text = ds.Tables[0].Rows[0][4].ToString();
            HomeAddress.Text = ds.Tables[0].Rows[0][5].ToString();
            Individual_language.Text= ds.Tables[0].Rows[0][6].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new System.Threading.Thread(() =>{Application.Run(new frmModifyInformation());}).Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strConn = @"Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\111.xlsx" + ";" + "Extended Properties='Excel 12.0;HDR=no;IMEX=1';";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "select * from [sheet1$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            conn.Close();

            ds.Tables[0].Rows[0].Delete();
            ds.Tables[0].Rows[0].AcceptChanges();
            MessageBox.Show("成功删除！");
            this.Close();
            new System.Threading.Thread(() => { Application.Run(new Form1()); }).Start();

        }
    }
}
