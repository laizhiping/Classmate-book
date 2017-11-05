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
using 吴伟根;
using teamwork1;

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
            name_M.Text = ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][0].ToString();
            WeChat.Text = ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][1].ToString();
            qq.Text = ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][2].ToString();
            Telephone.Text = ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][3].ToString();
            mailbox.Text = ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][4].ToString();
            HomeAddress.Text = ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][5].ToString();
            textBox4.Text = ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][6].ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][0] = name_M.Text;
            ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][1] = WeChat.Text;
            ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][2] = qq.Text;
            ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][3] = Telephone.Text;
            ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][4] = mailbox.Text;
            ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][5] = HomeAddress.Text;
            ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][6] = textBox4.Text;
            MessageBox.Show("成功修改!");
            this.Close();
        }
        private void frmModifyInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            new System.Threading.Thread(() => { Application.Run(new frmClassmateInformation()); }).Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
