using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMPT.PerForm
{
    public partial class F_User : Form
    {
        public F_User()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new TMPT.DataClass.MyMeans();

        public static DataSet MyDS_Grid;

        private void tool_UserAdd_Click(object sender, EventArgs e)
        {
            PerForm.F_UserAdd FrmUserAdd = new F_UserAdd();
            FrmUserAdd.Tag = 1;
            FrmUserAdd.Text = tool_UserAdd.Text + "�û�";
            FrmUserAdd.ShowDialog(this);
        }

        private void tool_UserAmend_Click(object sender, EventArgs e)
        {
            if (ModuleClass.MyModule.User_ID.Trim() == "0001")
            {
                MessageBox.Show("�����޸ĳ����û���");
                return;
            }
            PerForm.F_UserAdd FrmUserAdd = new F_UserAdd();
            FrmUserAdd.Tag = 2;
            FrmUserAdd.Text = tool_UserAmend.Text + "�û�";
            FrmUserAdd.ShowDialog(this);
        }

        private void F_User_Load(object sender, EventArgs e)
        {
            // TODO: ���д��뽫���ݼ��ص���db_PWMSDataSet.tb_��¼���С������Ը�����Ҫ�ƶ����Ƴ�����
            this.tb_��¼TableAdapter.Fill(this.db_PWMSDataSet.tb_��¼);
            MyDS_Grid = MyDataClass.getDataSet("select ID as �û����, �û��� from tb_��¼", "tb_��¼");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
             
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.Columns[0].Width = 260;
            dataGridView1.Columns[1].Width = 330;  
            if (dataGridView1.RowCount > 1)
            {
                ModuleClass.MyModule.User_ID = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                ModuleClass.MyModule.User_Name = dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                tool_UserAmend.Enabled = true;
                tool_UserDelete.Enabled = true;
                tool_UserPopedom.Enabled = true;
            }
            else
            {
                ModuleClass.MyModule.User_ID = "";
                ModuleClass.MyModule.User_Name = "";
                tool_UserAmend.Enabled = false;
                tool_UserDelete.Enabled = false;
                tool_UserPopedom.Enabled = false;
            }
        }

        private void tool_UserPopedom_Click(object sender, EventArgs e)
        {
            if (ModuleClass.MyModule.User_ID.Trim() == "0001")
            {
                MessageBox.Show("�����޸ĳ����û�Ȩ�ޡ�");
                return;
            }
            F_UserPope FrmUserPope = new F_UserPope();
            FrmUserPope.Text = "�û�Ȩ������";
            FrmUserPope.ShowDialog(this);
        }

        private void tool_UserDelete_Click(object sender, EventArgs e)
        {
            if (ModuleClass.MyModule.User_ID != "")
            {
                if (ModuleClass.MyModule.User_ID.Trim() == "0001")
                {
                    MessageBox.Show("����ɾ�������û���");
                    return;
                }
                MyDataClass.getsqlcom("Delete tb_��¼ where ID='" + ModuleClass.MyModule.User_ID.Trim() + "'");
                MyDataClass.getsqlcom("Delete tb_�û�Ȩ�� where ID='" + ModuleClass.MyModule.User_ID.Trim() + "'");
                MyDS_Grid = MyDataClass.getDataSet("select ID as �û����, �û��� from tb_��¼", "tb_��¼");
                dataGridView1.DataSource = MyDS_Grid.Tables[0];
            }
            else
                MessageBox.Show("�޷�ɾ�������ݱ�");
        }

        private void F_User_Activated(object sender, EventArgs e)
        {
            MyDS_Grid = MyDataClass.getDataSet("select ID as ���, �û��� from tb_��¼", "tb_��¼");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
        }

        private void tool_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}