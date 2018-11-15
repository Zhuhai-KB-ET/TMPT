using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMPT.PerForm
{
    public partial class F_AddressList : Form
    {
        public F_AddressList()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new TMPT.DataClass.MyMeans();
        ModuleClass.MyModule MyMC = new TMPT.ModuleClass.MyModule();
        public static DataSet MyDS_Grid;
        public static string AllSql = "Select ID,Name as 性名,Sex as 性别,Phone as 电话,WordPhone as 工作电话,Handset as 手机, QQ as QQ号,E_Mail as 邮箱地址,Note as 备注 from tb_AddressBook";
        public static string Find_Field = "";
        
        public void ShowAll()
        {
            
            ModuleClass.MyModule.Address_ID = "";
            //用dataGridView1控件显示职工的名称
            MyDS_Grid = MyDataClass.getDataSet(AllSql, "tb_AddressBook");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.AutoGenerateColumns = true;  //是否自动创建列
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 150;
            dataGridView1.Columns[8].Width = 300;
            if (dataGridView1.RowCount > 1)
            {
                Address_Amend.Enabled = true;
                Address_Delete.Enabled = true;
            }
            else
            {
                Address_Amend.Enabled = false;
                Address_Delete.Enabled = false;
            }
        }
        
        private void F_AddressList_Load(object sender, EventArgs e)
        {
            ShowAll();
        }

        //人性化 键盘

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                button5.Focus();      
        }

        private void F_Login_Activated(object sender, EventArgs e)
        {
            comboBox1.Focus();

        }

        private void Address_Add_Click(object sender, EventArgs e)
        {
            InfoAddForm.F_Address FrmAddress = new TMPT.InfoAddForm.F_Address();
            FrmAddress.Text = "通讯录添加操作";
            FrmAddress.Tag = 1;
            FrmAddress.ShowDialog(this);
            ShowAll();
        }

        private void Address_Amend_Click(object sender, EventArgs e)
        {
            InfoAddForm.F_Address FrmAddress = new TMPT.InfoAddForm.F_Address();
            FrmAddress.Text = "通讯录修改操作";
            FrmAddress.Tag = 2;
            FrmAddress.ShowDialog(this);
            ShowAll();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 1)
            {
                ModuleClass.MyModule.Address_ID = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                Address_Amend.Enabled = true;
                Address_Delete.Enabled = true;

            }
            else
            {
                Address_Amend.Enabled = false;
                Address_Delete.Enabled = false;
            }





        }

        private void Address_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除该条信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MyDataClass.getsqlcom("Delete tb_AddressBook where ID='" + ModuleClass.MyModule.Address_ID + "'");
                ShowAll();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            switch (((ComboBox)sender).SelectedIndex)
            {
                case 0:
                    {
                        Find_Field = "Name";
                        break;
                    }
                case 1:
                    {
                        Find_Field = "Sex";
                        break;
                    }
                case 2:
                    {
                        Find_Field = "QQ";
                        break;
                    }
                case 3:
                    {
                        Find_Field = "Handset";
                        break;
                    }
                case 4:
                    {
                        Find_Field = "WordPhone";
                        break;
                    }
                case 5:
                    {
                        Find_Field = "E_Mail";
                        break;
                    }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入查询条件。");
                return;
            }
            ModuleClass.MyModule.Address_ID = "";
            //用dataGridView1控件显示职工的名称
            MyDS_Grid = MyDataClass.getDataSet(AllSql+" where "+Find_Field+" like '%"+textBox1.Text.Trim()+"%'", "tb_AddressBook");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            if (dataGridView1.RowCount > 1)
            {
                Address_Amend.Enabled = true;
                Address_Delete.Enabled = true;
            }
            else
            {
                Address_Amend.Enabled = false;
                Address_Delete.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowAll();
            this.toolStripProgressBar1.Minimum = 0;
            this.toolStripProgressBar1.Maximum = 1;
            this.toolStripProgressBar1.Step = 1;
            for (int i = 0; i <= 1; i++)
            {
                this.toolStripProgressBar1.PerformStep();
            }
        }

        private void Address_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}