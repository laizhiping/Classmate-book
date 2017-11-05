﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 吴伟根
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);//捕捉异常
                }
            }

        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
