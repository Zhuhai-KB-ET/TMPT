using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TMPT
{
    public partial class F_Login : Form
    {
        DataClass.MyMeans MyClass = new TMPT.DataClass.MyMeans();//实例化一个类
         public F_Login()
        {
            InitializeComponent();
        }

        private void butClose_Click(object sender, EventArgs e)
         {
             if ((int)(this.Tag) == 1) //调试信息
             {
                 DataClass.MyMeans.Login_n = 3;
                 Application.Exit();
             }
             else
                 if ((int)(this.Tag) == 2)
                     this.Close();
         }

        private void butLogin_Click(object sender, EventArgs e)
        {
            if (textName.Text != "" & textPass.Text != "")
            {
                SqlDataReader temDR = MyClass.getcom("select * from tb_登录 where 用户名='" + textName.Text.Trim() + "' and 密码='" + textPass.Text.Trim() + "'");
                bool ifcom = temDR.Read();
                if (ifcom)
                {
                    DataClass.MyMeans.Login_Name = textName.Text.Trim();
                    DataClass.MyMeans.Login_ID = temDR.GetString(0);
                    DataClass.MyMeans.My_con.Close();
                    DataClass.MyMeans.My_con.Dispose();
                    DataClass.MyMeans.Login_n = (int)(this.Tag);//待总结完善
                    this.Close();
                }
                else
                {
                    MessageBox.Show("亲！对不起，您的用户名或密码错误喔！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textName.Text = "";
                    textPass.Text = "";
                }
                MyClass.con_close();
            }
            else
                MessageBox.Show("亲！请将登录信息添写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void F_Login_Load(object sender, EventArgs e)
        {
            try
            {
                MyClass.con_open();  //连接数据库
                MyClass.con_close();
                textName.Text = "";
                textPass.Text = "";

            }
            catch
            {
                MessageBox.Show("数据库连接失败。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void textName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                textPass.Focus();
        }

        private void textPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                butLogin.Focus();
        }

        private void F_Login_Activated(object sender, EventArgs e)
        {
            textName.Focus();
        }
    
    
    }
}
