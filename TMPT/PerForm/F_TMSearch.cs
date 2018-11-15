using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMPT.PerForm
{
    public partial class F_TMSearch : Form
    {
        public F_TMSearch()
        {
            InitializeComponent();
        }

        ModuleClass.MyModule MyMC = new TMPT.ModuleClass.MyModule();
        DataClass.MyMeans MyDataClass = new TMPT.DataClass.MyMeans();
        public static DataSet MyDS_Grid;
        public string ARsign = " AND ";
        public static string Sut_SQL = "select ID as 商标编号,商标名称,商标组成,商标状态,商标类别,商标申请地,商标申请方,商标申请时间,姓名,年龄,性别,QQ,Email,手机号码,身份证号码,公司名称,公司类别,成立时间,公司地址,公司法人,公司业务 from tb_商标基本信息";

        #region  清空控件集上的控件信息
        /// <summary>
        /// 清空GroupBox控件上的控件信息.
        /// </summary>
        /// <param name="n">控件个数</param>
        /// <param name="GBox">GroupBox控件的数据集</param>
        /// <param name="TName">获取信息控件的部份名称</param>
        private void Clear_Box(int n, Control.ControlCollection GBox, string TName)
        {
            for (int i = 0; i < n; i++)
            {
                foreach (Control C in GBox)
                {
                    if (C.GetType().Name == "TextBox" | C.GetType().Name == "MaskedTextBox" | C.GetType().Name == "ComboBox")
                        if (C.Name.IndexOf(TName)>-1)
                        {
                            C.Text = "";
                        }
                }
            }
        }
        #endregion
        
        private void F_Find_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“db_PWMSDataSet.tb_公司类别”中。您可以根据需要移动或移除它。
           
            MyMC.CoPassData(TM_商标组成, "tb_商标组成");  //向“民族类别”列表框中添加信息
            MyMC.CoPassData(TM_商标状态, "tb_商标状态");  //向"文化程度”列表框中添加信息
            MyMC.CoPassData(TM_商标类别, "tb_商标类别");  //向"正治面貌”列表框中添加信息
            MyMC.CoPassData(TM_商标申请地, "tb_商标申请地");  //向"职工类别”列表框中添加信息
            MyMC.CoPassData(TM_商标申请方, "tb_商标申请方");  //向"职务类别”列表框中添加信息

            MyMC.MaskedTextBox_Format(TM_商标申请时间);  //指定MaskedTextBox控件的格式
           
            //根据SQL语句进行查询
            MyDS_Grid = MyDataClass.getDataSet(Sut_SQL, "tb_商标基本信息");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.AutoGenerateColumns = true;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ARsign = " AND ";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ARsign = " OR ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModuleClass.MyModule.FindValue = "";    //清空存储查询语句的变量
            string Find_SQL = Sut_SQL;  //存储显示数据表中所有信息的SQL语句
            MyMC.Find_Grids(groupBox1.Controls, "TM", ARsign);    //将指定控件集下的控件组合成查询条件
            MyMC.Find_Grids(groupBox2.Controls, "TM", ARsign);
            MyMC.Find_Grids(groupBox3.Controls, "TM", ARsign);
         
            if (ModuleClass.MyModule.FindValue != "")   //如果FindValue字段不为空
                //将查询条件添加到SQL语句的尾部
                Find_SQL = Find_SQL + " where " + ModuleClass.MyModule.FindValue;
            //按照指定的条件进行查询
            MyDS_Grid = MyDataClass.getDataSet(Find_SQL, "tb_商标基本信息");
            //在dataGridView1控件是显示查询的结果
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.AutoGenerateColumns = true;
            checkBox1.Checked = false;
        }

        private void TM_年龄_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyMC.Estimate_Key(e, "", 0);
        }

        private void TM_QQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyMC.Estimate_Key(e, "", 0);
        }

        private void TM_手机号码_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyMC.Estimate_Key(e, "", 0);
        }

        //private void Find_M_Pay_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    MyMC.Estimate_Key(e, ((TextBox)sender).Text, 1);
        //}   

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear_Box(6, groupBox1.Controls, "TM_");
            Clear_Box(6, groupBox2.Controls, "TM");
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                MyDS_Grid = MyDataClass.getDataSet(Sut_SQL, "tb_商标基本信息");
                dataGridView1.DataSource = MyDS_Grid.Tables[0];
                dataGridView1.AutoGenerateColumns = true;
            }
        }

       
    }
}