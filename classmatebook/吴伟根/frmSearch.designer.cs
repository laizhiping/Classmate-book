namespace teamwork1
{
    partial class frmSearch
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MyDGV = new System.Windows.Forms.DataGridView();
            this.namebox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MyDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // MyDGV
            // 
            this.MyDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MyDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MyDGV.Location = new System.Drawing.Point(74, 131);
            this.MyDGV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MyDGV.Name = "MyDGV";
            this.MyDGV.RowTemplate.Height = 27;
            this.MyDGV.Size = new System.Drawing.Size(432, 172);
            this.MyDGV.TabIndex = 0;
            // 
            // namebox
            // 
            this.namebox.Location = new System.Drawing.Point(224, 76);
            this.namebox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(104, 21);
            this.namebox.TabIndex = 1;
            this.namebox.Text = "请输入姓名";
            this.namebox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.namebox_MouseClick);
            this.namebox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(370, 76);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(240, 345);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "查看详情";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 406);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.namebox);
            this.Controls.Add(this.MyDGV);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MyDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MyDGV;
        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

