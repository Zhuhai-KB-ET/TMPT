namespace TMPT.PerForm
{
    partial class F_User
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_User));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool_UserAdd = new System.Windows.Forms.ToolStripButton();
            this.tool_UserAmend = new System.Windows.Forms.ToolStripButton();
            this.tool_UserDelete = new System.Windows.Forms.ToolStripButton();
            this.tool_UserPopedom = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_Close = new System.Windows.Forms.ToolStripButton();
            this.db_PWMSDataSet = new TMPT.db_PWMSDataSet();
            this.tb登录BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_登录TableAdapter = new TMPT.db_PWMSDataSetTableAdapters.tb_登录TableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.db_PWMSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb登录BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 400);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(602, 374);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_UserAdd,
            this.tool_UserAmend,
            this.tool_UserDelete,
            this.tool_UserPopedom,
            this.toolStripSeparator1,
            this.tool_Close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(617, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool_UserAdd
            // 
            this.tool_UserAdd.Image = ((System.Drawing.Image)(resources.GetObject("tool_UserAdd.Image")));
            this.tool_UserAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_UserAdd.Name = "tool_UserAdd";
            this.tool_UserAdd.Size = new System.Drawing.Size(52, 22);
            this.tool_UserAdd.Text = "添加";
            this.tool_UserAdd.Click += new System.EventHandler(this.tool_UserAdd_Click);
            // 
            // tool_UserAmend
            // 
            this.tool_UserAmend.Image = ((System.Drawing.Image)(resources.GetObject("tool_UserAmend.Image")));
            this.tool_UserAmend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_UserAmend.Name = "tool_UserAmend";
            this.tool_UserAmend.Size = new System.Drawing.Size(52, 22);
            this.tool_UserAmend.Text = "修改";
            this.tool_UserAmend.Click += new System.EventHandler(this.tool_UserAmend_Click);
            // 
            // tool_UserDelete
            // 
            this.tool_UserDelete.Image = ((System.Drawing.Image)(resources.GetObject("tool_UserDelete.Image")));
            this.tool_UserDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_UserDelete.Name = "tool_UserDelete";
            this.tool_UserDelete.Size = new System.Drawing.Size(52, 22);
            this.tool_UserDelete.Text = "删除";
            this.tool_UserDelete.Click += new System.EventHandler(this.tool_UserDelete_Click);
            // 
            // tool_UserPopedom
            // 
            this.tool_UserPopedom.Image = ((System.Drawing.Image)(resources.GetObject("tool_UserPopedom.Image")));
            this.tool_UserPopedom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_UserPopedom.Name = "tool_UserPopedom";
            this.tool_UserPopedom.Size = new System.Drawing.Size(52, 22);
            this.tool_UserPopedom.Text = "权限";
            this.tool_UserPopedom.Click += new System.EventHandler(this.tool_UserPopedom_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tool_Close
            // 
            this.tool_Close.Image = ((System.Drawing.Image)(resources.GetObject("tool_Close.Image")));
            this.tool_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_Close.Name = "tool_Close";
            this.tool_Close.Size = new System.Drawing.Size(52, 22);
            this.tool_Close.Text = "关闭";
            this.tool_Close.Click += new System.EventHandler(this.tool_Close_Click);
            // 
            // db_PWMSDataSet
            // 
            this.db_PWMSDataSet.DataSetName = "db_PWMSDataSet";
            this.db_PWMSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb登录BindingSource
            // 
            this.tb登录BindingSource.DataMember = "tb_登录";
            this.tb登录BindingSource.DataSource = this.db_PWMSDataSet;
            // 
            // tb_登录TableAdapter
            // 
            this.tb_登录TableAdapter.ClearBeforeFill = true;
            // 
            // F_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 439);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "F_User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_User";
            this.Load += new System.EventHandler(this.F_User_Load);
            this.Activated += new System.EventHandler(this.F_User_Activated);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.db_PWMSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb登录BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tool_UserAdd;
        private System.Windows.Forms.ToolStripButton tool_UserAmend;
        private System.Windows.Forms.ToolStripButton tool_UserDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tool_UserPopedom;
        private System.Windows.Forms.ToolStripButton tool_Close;
        private System.Windows.Forms.DataGridView dataGridView1;
        private db_PWMSDataSet db_PWMSDataSet;
        private System.Windows.Forms.BindingSource tb登录BindingSource;
        private TMPT.db_PWMSDataSetTableAdapters.tb_登录TableAdapter tb_登录TableAdapter;
    }
}