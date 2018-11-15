namespace TMPT.PerForm
{
    partial class F_WordPad
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Word_Save = new System.Windows.Forms.Button();
            this.Word_Cancel = new System.Windows.Forms.Button();
            this.Word_Delete = new System.Windows.Forms.Button();
            this.Word_Amend = new System.Windows.Forms.Button();
            this.Word_Add = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WordPad_4 = new System.Windows.Forms.TextBox();
            this.WordPad_3 = new System.Windows.Forms.TextBox();
            this.WordPad_2 = new System.Windows.Forms.ComboBox();
            this.WordPad_1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(983, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(782, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(71, 20);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(72, 16);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "全部显示";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Click += new System.EventHandler(this.checkBox3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(586, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 20);
            this.comboBox1.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(253, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(169, 21);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.Value = new System.DateTime(2008, 3, 18, 0, 0, 0, 0);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(503, 20);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "记事类别";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(172, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "记事时间";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(8, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(983, 520);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "信息表";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Word_Save);
            this.groupBox4.Controls.Add(this.Word_Cancel);
            this.groupBox4.Controls.Add(this.Word_Delete);
            this.groupBox4.Controls.Add(this.Word_Amend);
            this.groupBox4.Controls.Add(this.Word_Add);
            this.groupBox4.Location = new System.Drawing.Point(398, 461);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(585, 50);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // Word_Save
            // 
            this.Word_Save.Location = new System.Drawing.Point(469, 10);
            this.Word_Save.Name = "Word_Save";
            this.Word_Save.Size = new System.Drawing.Size(100, 30);
            this.Word_Save.TabIndex = 4;
            this.Word_Save.Text = "保存";
            this.Word_Save.UseVisualStyleBackColor = true;
            this.Word_Save.Click += new System.EventHandler(this.Word_Save_Click);
            // 
            // Word_Cancel
            // 
            this.Word_Cancel.Location = new System.Drawing.Point(361, 10);
            this.Word_Cancel.Name = "Word_Cancel";
            this.Word_Cancel.Size = new System.Drawing.Size(100, 30);
            this.Word_Cancel.TabIndex = 3;
            this.Word_Cancel.Text = "取消";
            this.Word_Cancel.UseVisualStyleBackColor = true;
            this.Word_Cancel.Click += new System.EventHandler(this.Word_Cancel_Click);
            // 
            // Word_Delete
            // 
            this.Word_Delete.Location = new System.Drawing.Point(246, 10);
            this.Word_Delete.Name = "Word_Delete";
            this.Word_Delete.Size = new System.Drawing.Size(100, 30);
            this.Word_Delete.TabIndex = 2;
            this.Word_Delete.Text = "删除";
            this.Word_Delete.UseVisualStyleBackColor = true;
            this.Word_Delete.Click += new System.EventHandler(this.Word_Delete_Click);
            // 
            // Word_Amend
            // 
            this.Word_Amend.Location = new System.Drawing.Point(131, 10);
            this.Word_Amend.Name = "Word_Amend";
            this.Word_Amend.Size = new System.Drawing.Size(100, 30);
            this.Word_Amend.TabIndex = 1;
            this.Word_Amend.Text = "修改";
            this.Word_Amend.UseVisualStyleBackColor = true;
            this.Word_Amend.Click += new System.EventHandler(this.button3_Click);
            // 
            // Word_Add
            // 
            this.Word_Add.Location = new System.Drawing.Point(16, 10);
            this.Word_Add.Name = "Word_Add";
            this.Word_Add.Size = new System.Drawing.Size(100, 30);
            this.Word_Add.TabIndex = 0;
            this.Word_Add.Text = "添加";
            this.Word_Add.UseVisualStyleBackColor = true;
            this.Word_Add.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(387, 487);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.WordPad_4);
            this.groupBox3.Controls.Add(this.WordPad_3);
            this.groupBox3.Controls.Add(this.WordPad_2);
            this.groupBox3.Controls.Add(this.WordPad_1);
            this.groupBox3.Location = new System.Drawing.Point(406, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(585, 455);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "记事本内容";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "主    题：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "内容：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "记事类别：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "记事时间：";
            // 
            // WordPad_4
            // 
            this.WordPad_4.Location = new System.Drawing.Point(51, 143);
            this.WordPad_4.Multiline = true;
            this.WordPad_4.Name = "WordPad_4";
            this.WordPad_4.Size = new System.Drawing.Size(483, 306);
            this.WordPad_4.TabIndex = 3;
            // 
            // WordPad_3
            // 
            this.WordPad_3.Location = new System.Drawing.Point(117, 78);
            this.WordPad_3.Name = "WordPad_3";
            this.WordPad_3.Size = new System.Drawing.Size(417, 21);
            this.WordPad_3.TabIndex = 2;
            // 
            // WordPad_2
            // 
            this.WordPad_2.FormattingEnabled = true;
            this.WordPad_2.Location = new System.Drawing.Point(117, 47);
            this.WordPad_2.Name = "WordPad_2";
            this.WordPad_2.Size = new System.Drawing.Size(417, 20);
            this.WordPad_2.TabIndex = 1;
            // 
            // WordPad_1
            // 
            this.WordPad_1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.WordPad_1.Location = new System.Drawing.Point(117, 20);
            this.WordPad_1.Name = "WordPad_1";
            this.WordPad_1.Size = new System.Drawing.Size(417, 21);
            this.WordPad_1.TabIndex = 0;
            // 
            // F_WordPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 600);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "F_WordPad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_WordPad";
            this.Load += new System.EventHandler(this.F_WordPad_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TextBox WordPad_4;
        private System.Windows.Forms.TextBox WordPad_3;
        private System.Windows.Forms.ComboBox WordPad_2;
        private System.Windows.Forms.DateTimePicker WordPad_1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Word_Save;
        private System.Windows.Forms.Button Word_Cancel;
        private System.Windows.Forms.Button Word_Delete;
        private System.Windows.Forms.Button Word_Amend;
        private System.Windows.Forms.Button Word_Add;
    }
}