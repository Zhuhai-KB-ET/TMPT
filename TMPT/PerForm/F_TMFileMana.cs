using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace TMPT.PerForm
{
    public partial class F_TMFileMana : Form
    {
        public F_TMFileMana()
        {
            InitializeComponent();
        }

        DataClass.MyMeans MyDataClass = new TMPT.DataClass.MyMeans();
        ModuleClass.MyModule MyMC = new TMPT.ModuleClass.MyModule();

        #region  当前窗体的所有共公变量
        public static DataSet MyDS_Grid;
        public static string tem_Field = "";
        public static string tem_Value = "";
        public static string tem_ID = "";   //获取当前商标编号
        public static int hold_n = 0;         //用于记录操作的标识
        public static byte[] imgBytesIn1;  //用来存储图片的二进制数
        public static byte[] imgBytesIn2;
        public static byte[] imgBytesIn3; 
        public static int Ima_n = 0;  //判断是否对图片进行了操作
        public static string Part_ID = "";  //存储数据表的ID信息
        #endregion

        private void F_ManFile_Load(object sender, EventArgs e)
        {
            Ind_Mome.Multiline = true;
            Ind_Mome.ScrollBars = RichTextBoxScrollBars.Vertical;
            Ind_Mome.SelectionIndent = 8;
            Ind_Mome.SelectionRightIndent = 12;
            Ind_Mome.SelectionFont = new Font("微软雅黑",13,FontStyle.Bold);
            Ind_Mome.SelectionColor = System.Drawing.Color.Blue;
            Ind_Mome.SelectionBullet = true;

            //用dataGridView1控件显示商标名称
            MyDS_Grid = MyDataClass.getDataSet(DataClass.MyMeans.AllSql, "tb_商标基本信息");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.AutoGenerateColumns = true;  //是否自动创建列
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 80;
            for (int i = 2; i < dataGridView1.ColumnCount; i++)  //隐藏dataGridView1控件中不需要的列字段
            {
                dataGridView1.Columns[i].Visible = false;
            }
            MyMC.MaskedTextBox_Format(S_7);  //指定MaskedTextBox控件的格式
            MyMC.MaskedTextBox_Format(S_17);

            DataClass.MyMeans.AllSql = "Select * from tb_商标基本信息";      
        }
        // LinkClicked事件中实现网址带下划线
        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e) 
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        public void ShowData_Image(byte[] DI, PictureBox Ima)  //显示数据库图片
        {
            byte[] buffer = DI;
            MemoryStream ms = new MemoryStream(buffer);
            Ima.Image = Image.FromStream(ms);
        }

        #region  将图片转换成字节数组
        public void Read_Image(OpenFileDialog openF, PictureBox MyImage)
        {
            openF.Filter = "*.jpg|*.jpg|*.bmp|*.bmp";   //指定OpenFileDialog控件打开的文件格式
            if (openF.ShowDialog(this) == DialogResult.OK)  //如果打开了图片文件
            {
                try
                {
                    MyImage.Image = System.Drawing.Image.FromFile(openF.FileName);  //将图片文件存入到PictureBox控件中
                    string strimg = openF.FileName.ToString();  //记录图片的所在路径
                    FileStream fs = new FileStream(strimg, FileMode.Open, FileAccess.Read); //将图片以文件流的形式进行保存
                    BinaryReader br = new BinaryReader(fs);
                    if (MyImage.Name == "S_Photo1")
                    {
                        imgBytesIn1 = br.ReadBytes((int)fs.Length);  //将流读入到字节数组中
                    }
                    else
                    {
                        if (MyImage.Name == "S_Photo2")
                        {
                            imgBytesIn2 = br.ReadBytes((int)fs.Length);  //将流读入到字节数组中
                        }
                        else
                        {
                            if (MyImage.Name == "S_Photo3")
                            {
                                imgBytesIn3 = br.ReadBytes((int)fs.Length);  //将流读入到字节数组中
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("您选择的图片不能被读取或文件类型不对！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    S_Photo1.Image = null;
                    S_Photo2.Image = null;
                    S_Photo3.Image = null;
                }
            }
        }
        #endregion

        private void F_TMFileMana_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“db_PWMSDataSet.tb_公司类别”中。您可以根据需要移动或移除它。
           
            // TODO: 这行代码将数据加载到表“db_PWMSDataSet.tb_商标申请方”中。您可以根据需要移动或移除它。
           
            // TODO: 这行代码将数据加载到表“db_PWMSDataSet.tb_商标申请地”中。您可以根据需要移动或移除它。
            
            // TODO: 这行代码将数据加载到表“db_PWMSDataSet.tb_商标类别”中。您可以根据需要移动或移除它。
           
            // TODO: 这行代码将数据加载到表“db_PWMSDataSet.tb_商标状态”中。您可以根据需要移动或移除它。
          
            // TODO: 这行代码将数据加载到表“db_PWMSDataSet.tb_商标组成”中。您可以根据需要移动或移除它。
            
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)  //向comboBox2控件中添加相应的查询条件
            {
                case 0:
                    {
                        MyMC.NameInfo(comboBox2, "select distinct 商标名称 from tb_商标基本信息", 0);  //商标名称
                        tem_Field = "商标名称";
                        break;
                    }
                case 1:
                    {
                        MyMC.CoPassData(comboBox2, "tb_商标组成");  //商标组成
                        tem_Field = "商标组成";
                        break;
                    }
                case 2:
                    {
                        MyMC.CoPassData(comboBox2, "tb_商标状态");  //商标状态
                        tem_Field = "商标状态";
                        break;
                    }
                case 3:
                    {
                        MyMC.CoPassData(comboBox2, "tb_商标类别");  //商标类别
                        tem_Field = "商标类别";
                        break;
                    }
                case 4:
                    {
                        MyMC.CoPassData(comboBox2, "tb_商标申请地");  //商标申请地
                        tem_Field = "商标申请地";
                        break;
                    }
                case 5:
                    {
                        MyMC.CoPassData(comboBox2, "tb_商标申请方");  //商标申请方
                        tem_Field = "商标申请方";
                        break;
                    }
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tem_Value = comboBox2.SelectedItem.ToString();
                Condition_Lookup(tem_Value);
            }
            catch
            {
                comboBox2.Text = "";
                MessageBox.Show("只能以选择方式查询。");
            }
        }


        #region  按条件显示“商标基本信息”表的内容
        /// <summary>
        /// 通过公共变量动态进行查询.
        /// </summary>
        /// <param name="C_Value">条件值</param>
        public void Condition_Lookup(string C_Value)
        {
            MyDS_Grid = MyDataClass.getDataSet("Select * from tb_商标基本信息 where " + tem_Field + "='" + tem_Value + "'", "tb_商标基本信息");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            textBox1.Text = Grid_Inof(dataGridView1);  //显示职工信息表的当前记录            
        }
        #endregion

        #region  显示“商标基本信息”表中的指定记录
        /// <summary>
        /// 动态读取指定的记录行，并进行显示.
        /// </summary>
        /// <param name="DGrid">DataGridView控件</param>
        /// <returns>返回string对象</returns> 
        public string Grid_Inof(DataGridView DGrid)
        {
            byte[] pic1,pic2,pic3; //定义一个字节数组
            //当DataGridView控件的记录>1时，将当前行中信息显示在相应的控件上
            if (DGrid.RowCount > 1)
            {
                S_0.Text = DGrid[0, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_1.Text = DGrid[1, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_2.Text = DGrid[2, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_3.Text = DGrid[3, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_4.Text = DGrid[4, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_5.Text = DGrid[5, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_6.Text = DGrid[6, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_7.Text = MyMC.Date_Format(Convert.ToString(DGrid[7, DGrid.CurrentCell.RowIndex].Value).Trim());


                  S_8.Text = DGrid[8, DGrid.CurrentCell.RowIndex].Value.ToString();
                  S_9.Text = DGrid[9, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_10.Text = DGrid[10, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_11.Text = DGrid[11, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_12.Text = DGrid[12, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_13.Text = DGrid[13, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_14.Text = DGrid[14, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_15.Text = DGrid[15, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_16.Text = DGrid[16, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_17.Text = MyMC.Date_Format(Convert.ToString(DGrid[17, DGrid.CurrentCell.RowIndex].Value).Trim());
                S_18.Text = DGrid[18, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_19.Text = DGrid[19, DGrid.CurrentCell.RowIndex].Value.ToString();
                S_20.Text = DGrid[20, DGrid.CurrentCell.RowIndex].Value.ToString();

                try
                {
                    //将数据库中的图片存入到字节数组中
                    pic1 = (byte[])(MyDS_Grid.Tables[0].Rows[DGrid.CurrentCell.RowIndex][21]);
                    //DataGridView1中的数据，最终对相应表字段的读取
                    pic2 = (byte[])(MyDS_Grid.Tables[0].Rows[DGrid.CurrentCell.RowIndex][22]);//DataGridView1中的数据，最终对相应表字段的读取
                    pic3 = (byte[])(MyDS_Grid.Tables[0].Rows[DGrid.CurrentCell.RowIndex][23]);//读取S_Photo_2,S_Photo_3，
                    MemoryStream ms1 = new MemoryStream(pic1);			//将字节数组存入到二进制流中
                    MemoryStream ms2 = new MemoryStream(pic2);
                    MemoryStream ms3 = new MemoryStream(pic3);
                    S_Photo1.Image = Image.FromStream(ms1);   //二进制流Image控件中显示
                    S_Photo2.Image = Image.FromStream(ms2);
                    S_Photo3.Image = Image.FromStream(ms3);
                }

                catch
                { 
                    S_Photo1.Image = null;
                    S_Photo2.Image = null;
                    S_Photo3.Image = null; 

                } //当出现错误时，将Image控件清空

                tem_ID = S_0.Text.Trim();   //获取当前商标编号
                return DGrid[0, DGrid.CurrentCell.RowIndex].Value.ToString();   //返回当前商标的编号
            }
            else
            {
                //使用MyMeans公共类中的Clear_Control()方法清空指定控件集中的相应控件
                MyMC.Clear_Control(tabControl1.TabPages[0].Controls);
                tem_ID = "";
                return "";
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //用dataGridView1控件显示职工的名称
            MyDS_Grid = MyDataClass.getDataSet(DataClass.MyMeans.AllSql, "tb_商标基本信息");
            dataGridView1.DataSource = MyDS_Grid.Tables[0];
            dataGridView1.AutoGenerateColumns = true;  //是否自动创建列
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 120;

            for (int i = 2; i < dataGridView1.ColumnCount; i++)  //隐藏dataGridView1控件中不需要的列字段
            {
                dataGridView1.Columns[i].Visible = false;
            }
        }

        private void N_First_Click(object sender, EventArgs e)
        {
            int ColInd = 0;
            if (dataGridView1.CurrentCell.ColumnIndex == -1 || dataGridView1.CurrentCell.ColumnIndex > 1)
                ColInd = 0;
            else
                ColInd = dataGridView1.CurrentCell.ColumnIndex;
            if ((((Button)sender).Name) == "N_First")
            {
                dataGridView1.CurrentCell = this.dataGridView1[ColInd, 0];
                MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 0, 0, 1, 1);
            }
            if ((((Button)sender).Name) == "N_Previous")
            {
                if (dataGridView1.CurrentCell.RowIndex == 0)
                {
                    MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 0, 0, 1, 1);
                }
                else
                {
                    dataGridView1.CurrentCell = this.dataGridView1[ColInd, dataGridView1.CurrentCell.RowIndex - 1];
                    MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 1, 1, 1, 1);
                }
            }
            if ((((Button)sender).Name) == "N_Next")
            {
                if (dataGridView1.CurrentCell.RowIndex == dataGridView1.RowCount - 2)
                {
                    MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 1, 1, 0, 0);
                }
                else
                {
                    dataGridView1.CurrentCell = this.dataGridView1[ColInd, dataGridView1.CurrentCell.RowIndex + 1];
                    MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 1, 1, 1, 1);
                }
            }
            if ((((Button)sender).Name) == "N_Cauda")
            {
                dataGridView1.CurrentCell = this.dataGridView1[ColInd, dataGridView1.RowCount - 2];
                MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 1, 1, 0, 0);
            }

        }

        private void N_Previous_Click(object sender, EventArgs e)
        {
            N_First_Click(sender, e);
        }

        private void N_Next_Click(object sender, EventArgs e)
        {
            N_First_Click(sender, e);
        }

        private void N_Cauda_Click(object sender, EventArgs e)
        {
            N_First_Click(sender, e);
        }

        private void Sut_Add_Click(object sender, EventArgs e)
        {
            MyMC.Clear_Control(tabControl1.TabPages[0].Controls);   //清空商标基本信息的相应文本框
            S_0.Text = MyMC.GetAutocoding("tb_商标基本信息", "ID");  //自动添加编号
            hold_n = 1;  //用于记录添加操作的标识
            MyMC.Ena_Button(Sut_Add, Sut_Amend, Sut_Cancel, Sut_Save, 0, 0, 1, 1);
            groupBox5.Text = "当前正在添加信息";
            Img_Clear_1.Enabled = true;   //使图片选择按钮为可用状态
            Img_Save_1.Enabled = true;
            Img_Clear_2.Enabled = true;   //使图片选择按钮为可用状态
            Img_Save_2.Enabled = true;
            Img_Clear_3.Enabled = true;   //使图片选择按钮为可用状态
            Img_Save_3.Enabled = true;
        }

        private void Sut_Amend_Click(object sender, EventArgs e)
        {
            hold_n = 2;  //用于记录修改操作的标识
            MyMC.Ena_Button(Sut_Add, Sut_Amend, Sut_Cancel, Sut_Save, 0, 0, 1, 1);
            groupBox5.Text = "当前正在修改信息";
            Img_Clear_1.Enabled = true;   //使图片选择按钮为可用状态
            Img_Save_1.Enabled = true;
            Img_Clear_2.Enabled = true;   //使图片选择按钮为可用状态
            Img_Save_2.Enabled = true;
            Img_Clear_3.Enabled = true;   //使图片选择按钮为可用状态
            Img_Save_3.Enabled = true;
        }

        private void Sut_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount < 2) //判断dataGridView1控件中是否有记录
            {
                MessageBox.Show("数据表为空，不可以删除。");
                return;
            }
            //删除职工信息表中的当前记录，及其他相关表中的信息
            MyDataClass.getsqlcom("Delete tb_商标基本信息 where ID='" + S_0.Text.Trim() + "'");
            Sut_Cancel_Click(sender, e);    //调用“取消”按钮的单击事件
        }

        private void Sut_Cancel_Click(object sender, EventArgs e)
        {
            hold_n = 0;  //恢复原始标识
            MyMC.Ena_Button(Sut_Add, Sut_Amend, Sut_Cancel, Sut_Save, 1, 1, 0, 0);
            groupBox5.Text = "";
            Ima_n = 0;
            if (tem_Field == "")
                button1_Click(sender, e);
            else
                Condition_Lookup(tem_Value);
            Img_Clear_1.Enabled = false;
            Img_Save_1.Enabled = false;
            Img_Clear_2.Enabled = false;
            Img_Save_2.Enabled = false;
            Img_Clear_3.Enabled = false;
            Img_Save_3.Enabled = false;
        }

        private void Sut_Save_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage3") //如果当前是“个人简历”选项卡
            {
                //通过MyMeans公共类中的getcom()方法查询当前职工是否添加了个人简历
                SqlDataReader Read_Memo = MyDataClass.getcom("Select * from tb_商标心得体会 where ID='" + tem_ID + "'");
                if (Read_Memo.Read())   //如果有记录
                    //将当前设置的个人简历进行修改
                    MyDataClass.getsqlcom("update tb_商标心得体会 set 总结='" + Ind_Mome.Text + "' where ID='" + tem_ID + "'");
                else
                    //如果没有记录，则进行添加操作
                    MyDataClass.getsqlcom("insert into tb_商标心得体会 (ID,总结) values('" + tem_ID + "','" + Ind_Mome.Text + "')");
            }
            else //如果当前是“商标基本信息”选项卡
            {
                //定义字符串变量，并存储将“职工基本信息表”中的所有字段
                string All_Field = "ID,商标名称,商标组成,商标状态,商标类别,商标申请地,商标申请方,商标申请时间,姓名,性别,年龄,QQ,Email,手机号码,身份证号码,公司名称,公司类别,成立时间,公司地址,公司法人,公司业务,商标图片,人物图片,公司图片";
                try
                {
                    if (hold_n == 1 || hold_n == 2) //判断当前是添加，还是修改操作
                    {
                        ModuleClass.MyModule.ADDs = ""; //清空MyModule公共类中的ADDs变量
                        //用MyModule公共类中的Part_SaveClass()方法组合添加或修改的SQL语句
                        MyMC.Part_SaveClass(All_Field, S_0.Text.Trim(), "", tabControl1.TabPages[0].Controls, "S_", "tb_商标基本信息", 24, hold_n);
                        //如果ADDs变量不为空，则通过MyMeans公共类中的getsqlcom()方法执行添加、修改操作
                        if (ModuleClass.MyModule.ADDs != "")
                            MyDataClass.getsqlcom(ModuleClass.MyModule.ADDs);
                    }
                    if (Ima_n > 0)  //如果图片标识大于0
                    {
                        //通过MyModule公共类中r的SaveImage()方法将图片存入数据库中
                        MyMC.SaveImage(S_0.Text.Trim(), imgBytesIn1, imgBytesIn2, imgBytesIn3);
                    }
                    Sut_Cancel_Click(sender, e);    //调用“取消”按钮的单击事件
                }
                catch
                {
                    MessageBox.Show("请输入正确的商标信息！");
                }
            }
        }

        private void Part_Add_Click(object sender, EventArgs e)
        {
            hold_n = 1;
            if (tabControl1.SelectedTab.Name == "tabPage1")
            {
                MyMC.Clear_Control(this.groupBox14.Controls);
                Part_ID = MyMC.GetAutocoding("tb_商标拜访", "ID");  //自动添加编号;
            }
            if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                MyMC.Clear_Control(this.groupBox6.Controls);
                Part_ID = MyMC.GetAutocoding("tb_商标接待", "ID");  //自动添加编号;
            }

            MyMC.Ena_Button(Part_Add, Part_Amend, Part_Cancel, Part_Save, 1, 0, 1, 1);
        }

        private void Part_Amend_Click(object sender, EventArgs e)
        {
            hold_n = 2;
            MyMC.Ena_Button(Part_Add, Part_Amend, Part_Cancel, Part_Save, 0, 1, 1, 1);
        }

        private void Part_Delete_Click(object sender, EventArgs e)
        {
            string Delete_Table = "";
            string Delete_ID = "";
            if (tabControl1.SelectedTab.Name == "tabPage1")
            {
                if (dataGridView2.RowCount < 2)
                {
                    MessageBox.Show("数据表为空，不可以删除。");
                    return;
                }
                MyMC.Clear_Control(this.groupBox14.Controls);
                Delete_ID = dataGridView2[1, dataGridView2.CurrentCell.RowIndex].Value.ToString();
                Delete_Table = "tb_商标拜访";
            }
            if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                if (dataGridView3.RowCount < 2)
                {
                    MessageBox.Show("数据表为空，不可以删除。");
                    return;
                }
                MyMC.Clear_Control(this.groupBox6.Controls);
                Delete_ID = dataGridView3[1, dataGridView3.CurrentCell.RowIndex].Value.ToString();
                Delete_Table = "tb_商标接待";
            }
          
           
            if ((Delete_ID.Trim()).Length > 0)
            {
                MyDataClass.getsqlcom("Delete " + Delete_Table + " where ID='" + Delete_ID + "'");
                Part_Cancel_Click(sender, e);
            }
        }

        private void Part_Cancel_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage1")
            {
                DataSet WDset = MyDataClass.getDataSet("select  TM_ID,ID,拜访人姓名,所在部门, 拜访日期,拜访对象,拜访地点,拜访成果 from tb_商标拜访  where TM_ID='" + tem_ID + "'", "tb_商标拜访");
                MyMC.Correlation_Table(WDset, dataGridView2);
            }
            if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                DataSet FDset = MyDataClass.getDataSet("select  TM_ID,ID,接待人姓名,所在部门, 接待日期,接待对象,接待地点,接待成果  from tb_商标接待 where TM_ID='" + tem_ID + "'", "tb_商标接待");
                MyMC.Correlation_Table(FDset, dataGridView3);
            }
         
            hold_n = 0;  //恢复原始标识
            MyMC.Ena_Button(Part_Add, Part_Amend, Part_Cancel, Part_Save, 1, 1, 0, 0);
        }

        private void Part_Save_Click(object sender, EventArgs e)
        {
            string s = "";
            if (tabControl1.SelectedTab.Name == "tabPage1")
            {
                s = "ID,TM_ID,拜访人姓名,所在部门,拜访日期,拜访对象,拜访地点,拜访成果 ";
                //"select TM_ID,ID,BeginDate as 开始时间,EndDate as 结束时间, Branch as 部门, Business as 职务, WordUnit as 工作单位 from tb_WordResume
                ModuleClass.MyModule.ADDs = "";
                if (hold_n == 2)
                {
                    if (dataGridView2.RowCount < 2)
                    {
                        MessageBox.Show("数据表为空，不可以修改");
                    }
                    else
                        Part_ID = dataGridView2[1, dataGridView2.CurrentCell.RowIndex].Value.ToString();
                }
                MyMC.Part_SaveClass(s, tem_ID, Part_ID, this.groupBox14.Controls, "B_", "tb_商标拜访", 8, hold_n);
            }
            if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                s = "select  ID,TM_ID,接待人姓名,所在部门,接待日期,接待对象,接待地点,接待成果";
                ModuleClass.MyModule.ADDs = "";
                if (hold_n == 2)
                {
                    if (dataGridView3.RowCount < 2)
                    {
                        MessageBox.Show("数据表为空，不可以修改");
                    }
                    else
                        Part_ID = dataGridView3[1, dataGridView3.CurrentCell.RowIndex].Value.ToString();
                }
                MyMC.Part_SaveClass(s, tem_ID, Part_ID, this.groupBox6.Controls, "C_", "tb_商标接待", 8, hold_n);
            }
          
            if (ModuleClass.MyModule.ADDs != "")
                MyDataClass.getsqlcom(ModuleClass.MyModule.ADDs);
            Part_Cancel_Click(sender, e);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.RowIndex > -1)
                {
                    textBox1.Text = Grid_Inof(dataGridView1);  //显示商标信息表的当前记录
                    MyMC.Ena_Button(N_First, N_Previous, N_Next, N_Cauda, 1, 1, 1, 1);  //使窗体中的编辑按钮可用
                    //获取商标拜访表中的信息
                    DataSet WDset = MyDataClass.getDataSet("select  TM_ID,ID,拜访人姓名,所在部门, 拜访日期,拜访对象,拜访地点,拜访成果,备注 from tb_商标拜访  where TM_ID='" + tem_ID + "'", "tb_商标拜访");
                    MyMC.Correlation_Table(WDset, dataGridView2);   //将WDset存储的信息显示在dataGridView2控件中
                    if (WDset.Tables[0].Rows.Count < 1) //当WDset中没有信息时
                        //清空相应的控件
                        MyMC.Clear_Grids(WDset.Tables[0].Columns.Count, groupBox14.Controls, "B_");
                    //获取商标接待表中的信息
                    DataSet FDset = MyDataClass.getDataSet("select  TM_ID,ID,接待人姓名,所在部门, 接待日期,接待对象,接待地点,接待成果,备注  from tb_商标接待 where TM_ID='" + tem_ID + "'", "tb_商标接待");
                    MyMC.Correlation_Table(FDset, dataGridView3);
                    if (FDset.Tables[0].Rows.Count < 1)
                        MyMC.Clear_Grids(FDset.Tables[0].Columns.Count, groupBox6.Controls, "C_");
                 
                    //获取心得体会表中的信息
                    SqlDataReader Read_Memo = MyDataClass.getcom("Select   *  from tb_商标心得体会  where ID='" + tem_ID + "'");
                    if (Read_Memo.Read())
                        Ind_Mome.Text = Read_Memo[1].ToString();
                    else
                        Ind_Mome.Clear();


                    //MyMC.Show_DGrid(dataGridView2, groupBox7.Controls, "Word_");


                }
                this.toolStripProgressBar1.Minimum = 0;
                this.toolStripProgressBar1.Maximum = 1;
                this.toolStripProgressBar1.Step = 10;
                for (int i = 0; i <= 1; i++)
                {
                    this.toolStripProgressBar1.PerformStep();
                }
            }
            catch  { }
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView2, groupBox14.Controls, "B_");
        }

        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MyMC.Show_DGrid(dataGridView3, groupBox6.Controls, "C_");
        }

        private void Img_Save_1_Click(object sender, EventArgs e)
        {
            Read_Image(openFileDialog1, S_Photo1);
            Ima_n = 1;
        }

        private void Img_Clear_1_Click(object sender, EventArgs e)
        {
            S_Photo1.Image = null;
            imgBytesIn1 = new byte[65536];
            Ima_n = 2;
        }

        private void Img_Save_2_Click(object sender, EventArgs e)
        {
            Read_Image(openFileDialog2, S_Photo2);
            Ima_n = 1;
        }

        private void Img_Clear_2_Click(object sender, EventArgs e)
        {
            S_Photo2.Image = null;
            imgBytesIn2 = new byte[65536];
            Ima_n = 2;
        }

        private void Img_Save_3_Click(object sender, EventArgs e)
        {
            Read_Image(openFileDialog3, S_Photo3);
            Ima_n = 1;
        }

        private void Img_Clear_3_Click(object sender, EventArgs e)
        {
            S_Photo3.Image = null;
            imgBytesIn3 = new byte[65536];
            Ima_n = 2;
        }

        


       




    }
}
