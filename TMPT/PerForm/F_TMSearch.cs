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
        public static string Sut_SQL = "select ID as �̱���,�̱�����,�̱����,�̱�״̬,�̱����,�̱������,�̱����뷽,�̱�����ʱ��,����,����,�Ա�,QQ,Email,�ֻ�����,���֤����,��˾����,��˾���,����ʱ��,��˾��ַ,��˾����,��˾ҵ�� from tb_�̱������Ϣ";

        #region  ��տؼ����ϵĿؼ���Ϣ
        /// <summary>
        /// ���GroupBox�ؼ��ϵĿؼ���Ϣ.
        /// </summary>
        /// <param name="n">�ؼ�����</param>
        /// <param name="GBox">GroupBox�ؼ������ݼ�</param>
        /// <param name="TName">��ȡ��Ϣ�ؼ��Ĳ�������</param>
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
            // TODO: ���д��뽫���ݼ��ص���db_PWMSDataSet.tb_��˾����С������Ը�����Ҫ�ƶ����Ƴ�����
           
            MyMC.CoPassData(TM_�̱����, "tb_�̱����");  //����������б���������Ϣ
            MyMC.CoPassData(TM_�̱�״̬, "tb_�̱�״̬");  //��"�Ļ��̶ȡ��б���������Ϣ
            MyMC.CoPassData(TM_�̱����, "tb_�̱����");  //��"������ò���б���������Ϣ
            MyMC.CoPassData(TM_�̱������, "tb_�̱������");  //��"ְ������б���������Ϣ
            MyMC.CoPassData(TM_�̱����뷽, "tb_�̱����뷽");  //��"ְ������б���������Ϣ

            MyMC.MaskedTextBox_Format(TM_�̱�����ʱ��);  //ָ��MaskedTextBox�ؼ��ĸ�ʽ
           
            //����SQL�����в�ѯ
            MyDS_Grid = MyDataClass.getDataSet(Sut_SQL, "tb_�̱������Ϣ");
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
            ModuleClass.MyModule.FindValue = "";    //��մ洢��ѯ���ı���
            string Find_SQL = Sut_SQL;  //�洢��ʾ���ݱ���������Ϣ��SQL���
            MyMC.Find_Grids(groupBox1.Controls, "TM", ARsign);    //��ָ���ؼ����µĿؼ���ϳɲ�ѯ����
            MyMC.Find_Grids(groupBox2.Controls, "TM", ARsign);
            MyMC.Find_Grids(groupBox3.Controls, "TM", ARsign);
         
            if (ModuleClass.MyModule.FindValue != "")   //���FindValue�ֶβ�Ϊ��
                //����ѯ������ӵ�SQL����β��
                Find_SQL = Find_SQL + " where " + ModuleClass.MyModule.FindValue;
            //����ָ�����������в�ѯ
            MyDS_Grid = MyDataClass.getDataSet(Find_SQL, "tb_�̱������Ϣ");
            //��dataGridView1�ؼ�����ʾ��ѯ�Ľ��
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.AutoGenerateColumns = true;
            checkBox1.Checked = false;
        }

        private void TM_����_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyMC.Estimate_Key(e, "", 0);
        }

        private void TM_QQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyMC.Estimate_Key(e, "", 0);
        }

        private void TM_�ֻ�����_KeyPress(object sender, KeyPressEventArgs e)
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
                MyDS_Grid = MyDataClass.getDataSet(Sut_SQL, "tb_�̱������Ϣ");
                dataGridView1.DataSource = MyDS_Grid.Tables[0];
                dataGridView1.AutoGenerateColumns = true;
            }
        }

       
    }
}