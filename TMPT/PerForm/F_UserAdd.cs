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
                DSet = MyDataClass.getDataSet("select 用户名,密码 from tb_登录 where 用户名='"+ID+"'", "tb_登录");
                //text_Name.Text = Convert.ToString(DSet.Tables[0].Rows[0][0]);
               // text_Pass.Text = Convert.ToString(DSet.Tables[0].Rows[0][1]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (text_Name.Text == "" && text_Pass.Text == "")
            {
                MessageBox.Show("请将用户名和密码添加完整。");
                return;
               
            }
            DSet = MyDataClass.getDataSet("select 用户名 from tb_登录 where 用户名='" + text_Name.Text + "'", "tb_登录");
            if ((int)this.Tag == 2 && text_Name.Text == ModuleClass.MyModule.User_Name)
            {
                MyDataClass.getsqlcom("update tb_登录 set 用户名='" + text_Name.Text + "',密码='" + text_Pass.Text + "' where ID='" + ModuleClass.MyModule.User_ID + "'");
                return;
            }
            if (DSet.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("当前用户名已存在，请重新输入。");
                text_Name.Text = "";
                text_Pass.Text = "";
                return;
             
            }
            if ((int)this.Tag == 1)
            {
                AutoID = MyMC.GetAutocoding("tb_登录", "ID");
                MyDataClass.getsqlcom("insert into tb_登录 (ID,用户名,密码) values('" + AutoID + "','" + text_Name.Text + "','" + text_Pass.Text + "')");
                MyMC.ADD_Pope(AutoID, 0);
                MessageBox.Show("添加成功。");
                this.Close();
            }
            else
            {
                MyDataClass.getsqlcom("update tb_登录 set 用户名='" + text_Name.Text + "',密码='" + text_Pass.Text + "' where ID='" + ModuleClass.MyModule.User_ID + "'");
                if (ModuleClass.MyModule.User_ID == DataClass.MyMeans.Login_ID)
                    DataClass.MyMeans.Login_Name = text_Name.Text;
                MessageBox.Show("修改成功。");
                
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}