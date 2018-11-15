using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMPT
{
    public partial class F_Main : Form
    {
        DataClass.MyMeans MyClass = new TMPT.DataClass.MyMeans();
        ModuleClass.MyModule MyMenu = new TMPT.ModuleClass.MyModule();
        public F_Main()
        {
            InitializeComponent();
        }

        #region  通过权限对主窗体进行初始化
        /// <summary>
        /// 对主窗体初始化
        /// </summary>
        private void Preen_Main()
        {
            statusStrip1.Items[2].Text = DataClass.MyMeans.Login_Name;  //在状态栏显示当前登录的用户名
            treeView1.Nodes.Clear();
            MyMenu.GetMenu(treeView1, menuStrip1);  //调用公共类MyModule下的GetMenu()方法，将menuStrip1控件的子菜单添加到treeView1控件中
            MyMenu.MainMenuF(menuStrip1);   //将菜单栏中的各子菜单项设为不可用状态
            MyMenu.MainPope(menuStrip1, DataClass.MyMeans.Login_Name);  //根据权限设置相应子菜单的可用状态
        }
        #endregion

        private void F_Main_Load(object sender, EventArgs e)
        {
            this.toolStripProgressBar1.Minimum = 0;
            this.toolStripProgressBar1.Maximum = 1;
            this.toolStripProgressBar1.Step = 1;
            for (int i = 0; i <= 1; i++)
            {
                this.toolStripProgressBar1.PerformStep();
            }
            this.toolStripStatusLabel4.Text = DateTime.Now.ToString();
            F_Login FrmLogin = new F_Login();   //声时登录窗体，进行调用
            FrmLogin.Tag = 1;   //将登录窗体的Tag属性设为1，表示调用的是登录窗体
            FrmLogin.ShowDialog();
            FrmLogin.Dispose();
            //当调用的是登录窗体时
            if (DataClass.MyMeans.Login_n == 1)
            {
                Preen_Main();   //自定义方法，通过权限对窗体进行初始化


                //MyMenu.PactDay(1);  //MyModule类中的自定义方法，用于查找指定时间内，过生日的职工
                //MyMenu.PactDay(2);  //MyModule类中的自定义方法，用于查找合同到期的职工
            }
            DataClass.MyMeans.Login_n = 3;  //将公共变量设为3，便于控制登录窗体的关闭


            //Tool_Help.Enabled = true;
        }

        private void F_Main_Activated(object sender, EventArgs e)
        {
            if (DataClass.MyMeans.Login_n == 2) //当调用的是重新登录窗体时
             Preen_Main();   //自定义方法，通过权限对窗体进行初始化
             DataClass.MyMeans.Login_n = 3;
            
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text.Trim() == "系统退出")   //如果当前节点的文本为“系统退出”
            {
                Application.Exit(); //关闭应用程序
            }
            MyMenu.TreeMenuF(menuStrip1, e);   //用MyModule公共类中的TreeMenuF()方法调用各窗体
        }

        private void TM_Struct_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);          
        }

        private void TM_State_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void TM_Type_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void TM_Place_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void TM_Person_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void 专利类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void 专利状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void 专利类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void 专利归属地ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void 专利归属方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 2);
        }

        private void 拜访提醒ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 来访提醒ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }


        private void 商标档案管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 商标资料查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 商标资料统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 专利ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 专利资料查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 专利数据统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 通讯录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 日常记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 备份还原ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 清空数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 重新登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Tool_Help_Click(object sender, EventArgs e)
        {
            
        }

        private void Button_Trademarkebasic_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Button_Patentbasic_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Button_ClewBargain_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Botton_AddressBook_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        private void Botton_DayWordPad_Click(object sender, EventArgs e)
        {
            MyMenu.Show_Form(sender.ToString().Trim(), 1);
        }

        

        
      

        



    }
}