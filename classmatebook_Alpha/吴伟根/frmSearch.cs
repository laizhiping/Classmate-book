using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 吴伟根;
using Tongxuelu;

namespace teamwork1
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string Path = "g:\\test2.xls";
            //ConnectExcel connectexcel = new ConnectExcel();
            DataSet my_ds = new DataSet();
            my_ds = ConnectExcel.ds.Copy();
            my_ds.Tables[0].Columns.Add("serialNumber", typeof(System.Int32));
            int i;
            string name = namebox.Text.Trim();


            for (i = 0; i < (Int32)my_ds.Tables[0].Rows.Count; i++)
            {
                my_ds.Tables[0].Rows[i][7] = i;
            }

            for (i = 0; i < (Int32)my_ds.Tables[0].Rows.Count; i++)
            {
                if (name != (string)my_ds.Tables[0].Rows[i][0])
                {
                    my_ds.Tables[0].Rows[i].Delete();
                }
            }

            MyDGV.DataSource = my_ds.Tables[0];
            MyDGV.ReadOnly = true;
            MyDGV.AllowUserToAddRows = false;

            for (i = 3; i < (Int32)my_ds.Tables[0].Columns.Count; i++)
            {
                MyDGV.Columns[i].Visible = false;
            }
            if (MyDGV.CurrentRow == null)
            {
                MessageBox.Show("未找到此人，请重新输入");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MyDGV.CurrentRow == null)
            {
                MessageBox.Show("未找到此人，请重新输入");
            }
            else
            {
                ConnectExcel.index1 = (Int32)MyDGV.CurrentRow.Cells[7].Value;
                this.Close();
                new System.Threading.Thread(() => { Application.Run(new frmClassmateInformation()); }).Start();
            }
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {

        }

        private void namebox_MouseClick(object sender, MouseEventArgs e)
        {
            namebox.Text = "";
        }
    }
}
