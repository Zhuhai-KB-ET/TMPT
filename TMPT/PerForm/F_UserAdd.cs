using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMPT.PerForm
{
    public partial class F_UserAdd : Form
    {
        public F_UserAdd()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new TMPT.DataClass.MyMeans();
        ModuleClass.MyModule MyMC = new TMPT.ModuleClass.MyModule();
        public DataSet DSet;
        public static string AutoID = "";

        private void F_UserAdd_Load(object sender, EventArgs e)
        {
            if ((int)this.Tag == 1)
            {
                text_Name.Text = "";
                text_Pass.Text = "";
            }
            else
            {
                string ID = ModuleClass.MyModule.User_ID;
                DSet = MyDataClass.getDataSet("select �û���,���� from tb_��¼ where �û���='"+ID+"'", "tb_��¼");
                //text_Name.Text = Convert.ToString(DSet.Tables[0].Rows[0][0]);
               // text_Pass.Text = Convert.ToString(DSet.Tables[0].Rows[0][1]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (text_Name.Text == "" && text_Pass.Text == "")
            {
                MessageBox.Show("�뽫�û������������������");
                return;
               
            }
            DSet = MyDataClass.getDataSet("select �û��� from tb_��¼ where �û���='" + text_Name.Text + "'", "tb_��¼");
            if ((int)this.Tag == 2 && text_Name.Text == ModuleClass.MyModule.User_Name)
            {
                MyDataClass.getsqlcom("update tb_��¼ set �û���='" + text_Name.Text + "',����='" + text_Pass.Text + "' where ID='" + ModuleClass.MyModule.User_ID + "'");
                return;
            }
            if (DSet.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("��ǰ�û����Ѵ��ڣ����������롣");
                text_Name.Text = "";
                text_Pass.Text = "";
                return;
             
            }
            if ((int)this.Tag == 1)
            {
                AutoID = MyMC.GetAutocoding("tb_��¼", "ID");
                MyDataClass.getsqlcom("insert into tb_��¼ (ID,�û���,����) values('" + AutoID + "','" + text_Name.Text + "','" + text_Pass.Text + "')");
                MyMC.ADD_Pope(AutoID, 0);
                MessageBox.Show("��ӳɹ���");
                this.Close();
            }
            else
            {
                MyDataClass.getsqlcom("update tb_��¼ set �û���='" + text_Name.Text + "',����='" + text_Pass.Text + "' where ID='" + ModuleClass.MyModule.User_ID + "'");
                if (ModuleClass.MyModule.User_ID == DataClass.MyMeans.Login_ID)
                    DataClass.MyMeans.Login_Name = text_Name.Text;
                MessageBox.Show("�޸ĳɹ���");
                
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}