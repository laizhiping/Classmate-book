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
    public partial class frmClassmateInformation : Form
    {
        public frmClassmateInformation()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {    
            name.Text = ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][0].ToString();
            WeChat.Text = ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][1].ToString();
            qq.Text = ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][2].ToString();
            Telephone.Text = ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][3].ToString();
            mailbox.Text = ConnectExcel.ds.Tables[0].Rows[0][4].ToString();
            HomeAddress.Text = ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][5].ToString();
            Individual_language.Text= ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1][6].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new System.Threading.Thread(() =>{Application.Run(new frmModifyInformation());}).Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1].Delete();
            ConnectExcel.ds.Tables[0].Rows[ConnectExcel.index1].AcceptChanges();
            MessageBox.Show("成功删除！");
            this.Close();

        }
    }
}
