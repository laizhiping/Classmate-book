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
    public partial class frmModifyInformation : Form
    {
        public frmModifyInformation()
        {
            InitializeComponent();
        }
        private void frmModifyInformation_Load(object sender, EventArgs e)
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

            name_M.Text = ds.Tables[0].Rows[0][0].ToString();
            WeChat.Text = ds.Tables[0].Rows[0][1].ToString();
            qq.Text = ds.Tables[0].Rows[0][2].ToString();
            Telephone.Text = ds.Tables[0].Rows[0][3].ToString();
            mailbox.Text = ds.Tables[0].Rows[0][4].ToString();
            HomeAddress.Text = ds.Tables[0].Rows[0][5].ToString();
            textBox4.Text = ds.Tables[0].Rows[0][6].ToString();
        }
        private void button1_Click(object sender, EventArgs e)
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

            ds.Tables[0].Rows[0][0] = name_M.Text;
            ds.Tables[0].Rows[0][1] = WeChat.Text;
            ds.Tables[0].Rows[0][2] = qq.Text;
            ds.Tables[0].Rows[0][3] = Telephone.Text;
            ds.Tables[0].Rows[0][4] = mailbox.Text;
            ds.Tables[0].Rows[0][5] = HomeAddress.Text;
            ds.Tables[0].Rows[0][6] = textBox4.Text;
            MessageBox.Show("成功修改!");
            this.Close();
            new System.Threading.Thread(() => { Application.Run(new Form1()); }).Start();

        }
        private void frmModifyInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            new System.Threading.Thread(() => { Application.Run(new Form1()); }).Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
