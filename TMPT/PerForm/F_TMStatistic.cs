using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TMPT.PerForm
{
    public partial class F_TMStat : Form
    {
        public F_TMStat()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new TMPT.DataClass.MyMeans();


        public static string Term_Value = "商标组成,商标状态,商标类别,商标申请地,商标申请方,商标申请时间,姓名,性别,年龄,公司名称,公司类别,成立时间,公司地址,公司法人";
    
        public static string[] A_Value = Term_Value.Split(Convert.ToChar(','));
        public static DataSet MyDS_Grid;

        public void Stat_Class(int n)
        {
            MyDS_Grid = MyDataClass.getDataSet("select " + A_Value[n] + ", count(" + A_Value[n] + ")  as '人数' from tb_商标基本信息 group by " + A_Value[n], "tb_商标基本信息");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.Columns[0].Width = 330;
            dataGridView1.Columns[1].Width =303;
        }

        private void F_Stat_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < A_Value.Length; i++)
                listBox1.Items.Add("按" + A_Value[i] + "统计");
            Stat_Class(0);

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            Stat_Class(listBox1.SelectedIndex);
        }
    }
}