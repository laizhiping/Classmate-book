using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teamwork1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Path = "g:\\test2.xls";
            ConnectExcel connectexcel = new ConnectExcel();
            DataSet my_ds = new DataSet();
            my_ds = connectexcel.ExcelToDS(Path);
            my_ds.Tables[0].Columns.Add("serialNumber", typeof(System.Int32));
            int i;
            string name = namebox.Text.Trim();

            //string testname1,testname2;
            //testname1=(string)my_ds.Tables[0].Rows[0][2];
            //testname2 = testname1;

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
            int index;
            if (MyDGV.CurrentRow == null)
            {
                MessageBox.Show("未找到此人，请重新输入");
            }
            else
            {
                index = (Int32)MyDGV.CurrentRow.Cells[7].Value;
            }
        }
    }
}
