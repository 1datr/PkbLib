namespace PkbLib
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbZ = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.tbX = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbCell2 = new System.Windows.Forms.TextBox();
            this.tbCell1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pkbStacker1 = new PkbLib.PkbStacker();
            this.pkbStackermanTiara1 = new PkbLib.PkbStackermanTiara(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.bdTiaraDataSet = new PkbLib.bdTiaraDataSet();
            this.coordsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coordsTableAdapter = new PkbLib.bdTiaraDataSetTableAdapters.CoordsTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ncellDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xStopBackDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xStopForwardDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xCellBackDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xCellForwardDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yCheckStopDownDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yCheckStopUpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yCheckCellDownDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yCheckCellUpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yCheckCellBusyDownDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yCheckCellBusyUpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yLoadStopDownDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yLoadStopUpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yLoadCellDownDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yLoadCellUpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yUploadStopDownDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yUploadStopUpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yUploadCellDownDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yUploadCellUpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zStopCellDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zStopStackerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdTiaraDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coordsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tbZ);
            this.groupBox1.Controls.Add(this.tbY);
            this.groupBox1.Controls.Add(this.tbX);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(76, 147);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tbZ
            // 
            this.tbZ.Location = new System.Drawing.Point(6, 89);
            this.tbZ.Name = "tbZ";
            this.tbZ.Size = new System.Drawing.Size(62, 20);
            this.tbZ.TabIndex = 4;
            this.tbZ.Text = "0";
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(6, 63);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(62, 20);
            this.tbY.TabIndex = 3;
            this.tbY.Text = "0";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(6, 37);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(62, 20);
            this.tbX.TabIndex = 2;
            this.tbX.Text = "0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "STOP/RESUME";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbCell2);
            this.groupBox2.Controls.Add(this.tbCell1);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(8, 270);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(80, 106);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // tbCell2
            // 
            this.tbCell2.Location = new System.Drawing.Point(15, 48);
            this.tbCell2.Name = "tbCell2";
            this.tbCell2.Size = new System.Drawing.Size(44, 20);
            this.tbCell2.TabIndex = 7;
            // 
            // tbCell1
            // 
            this.tbCell1.Location = new System.Drawing.Point(15, 22);
            this.tbCell1.Name = "tbCell1";
            this.tbCell1.Size = new System.Drawing.Size(44, 20);
            this.tbCell1.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(62, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "RUN";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(18, 207);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(62, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "PARK";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "labelCoords";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point(119, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(937, 429);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pkbStacker1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(929, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // pkbStacker1
            // 
            this.pkbStacker1.AutoSize = true;
           
            this.pkbStacker1.FloorCount = 5;
            this.pkbStacker1.Grouping = 3;
            this.pkbStacker1.Location = new System.Drawing.Point(6, 6);
            this.pkbStacker1.MaximumSize = new System.Drawing.Size(871, 281);
            this.pkbStacker1.MinimumSize = new System.Drawing.Size(871, 281);
            this.pkbStacker1.Name = "pkbStacker1";
  
            this.pkbStacker1.Position = ((PkbLib.Point3)(resources.GetObject("pkbStacker1.Position")));
            this.pkbStacker1.RowCount = 33;
            this.pkbStacker1.Size = new System.Drawing.Size(871, 281);
            this.pkbStacker1.Stacker_Manager = this.pkbStackermanTiara1;
     
            this.pkbStacker1.TabIndex = 2;
            // 
            // pkbStackermanTiara1
            // 
            this.pkbStackermanTiara1.Active = true;
            this.pkbStackermanTiara1.BSAlarmBits = null;
            this.pkbStackermanTiara1.IpAdr = "192.168.1.11";
            this.pkbStackermanTiara1.MustPoint = ((PkbLib.Point3)(resources.GetObject("pkbStackermanTiara1.MustPoint")));
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(929, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.idDataGridViewTextBoxColumn,
            this.ncellDataGridViewTextBoxColumn,
            this.xStopBackDataGridViewTextBoxColumn,
            this.xStopForwardDataGridViewTextBoxColumn,
            this.xCellBackDataGridViewTextBoxColumn,
            this.xCellForwardDataGridViewTextBoxColumn,
            this.yCheckStopDownDataGridViewTextBoxColumn,
            this.yCheckStopUpDataGridViewTextBoxColumn,
            this.yCheckCellDownDataGridViewTextBoxColumn,
            this.yCheckCellUpDataGridViewTextBoxColumn,
            this.yCheckCellBusyDownDataGridViewTextBoxColumn,
            this.yCheckCellBusyUpDataGridViewTextBoxColumn,
            this.yLoadStopDownDataGridViewTextBoxColumn,
            this.yLoadStopUpDataGridViewTextBoxColumn,
            this.yLoadCellDownDataGridViewTextBoxColumn,
            this.yLoadCellUpDataGridViewTextBoxColumn,
            this.yUploadStopDownDataGridViewTextBoxColumn,
            this.yUploadStopUpDataGridViewTextBoxColumn,
            this.yUploadCellDownDataGridViewTextBoxColumn,
            this.yUploadCellUpDataGridViewTextBoxColumn,
            this.zStopCellDataGridViewTextBoxColumn,
            this.zStopStackerDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.coordsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(27, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(247, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column2
            // 
            this.Column2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // statusStrip1
            // 
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 407);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(119, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // bdTiaraDataSet
            // 
            this.bdTiaraDataSet.DataSetName = "bdTiaraDataSet";
            this.bdTiaraDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // coordsBindingSource
            // 
            this.coordsBindingSource.DataMember = "Coords";
            this.coordsBindingSource.DataSource = this.bdTiaraDataSet;
            // 
            // coordsTableAdapter
            // 
            this.coordsTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ncellDataGridViewTextBoxColumn
            // 
            this.ncellDataGridViewTextBoxColumn.DataPropertyName = "ncell";
            this.ncellDataGridViewTextBoxColumn.HeaderText = "ncell";
            this.ncellDataGridViewTextBoxColumn.Name = "ncellDataGridViewTextBoxColumn";
            // 
            // xStopBackDataGridViewTextBoxColumn
            // 
            this.xStopBackDataGridViewTextBoxColumn.DataPropertyName = "X_StopBack";
            this.xStopBackDataGridViewTextBoxColumn.HeaderText = "X_StopBack";
            this.xStopBackDataGridViewTextBoxColumn.Name = "xStopBackDataGridViewTextBoxColumn";
            // 
            // xStopForwardDataGridViewTextBoxColumn
            // 
            this.xStopForwardDataGridViewTextBoxColumn.DataPropertyName = "X_StopForward";
            this.xStopForwardDataGridViewTextBoxColumn.HeaderText = "X_StopForward";
            this.xStopForwardDataGridViewTextBoxColumn.Name = "xStopForwardDataGridViewTextBoxColumn";
            // 
            // xCellBackDataGridViewTextBoxColumn
            // 
            this.xCellBackDataGridViewTextBoxColumn.DataPropertyName = "X_CellBack";
            this.xCellBackDataGridViewTextBoxColumn.HeaderText = "X_CellBack";
            this.xCellBackDataGridViewTextBoxColumn.Name = "xCellBackDataGridViewTextBoxColumn";
            // 
            // xCellForwardDataGridViewTextBoxColumn
            // 
            this.xCellForwardDataGridViewTextBoxColumn.DataPropertyName = "X_CellForward";
            this.xCellForwardDataGridViewTextBoxColumn.HeaderText = "X_CellForward";
            this.xCellForwardDataGridViewTextBoxColumn.Name = "xCellForwardDataGridViewTextBoxColumn";
            // 
            // yCheckStopDownDataGridViewTextBoxColumn
            // 
            this.yCheckStopDownDataGridViewTextBoxColumn.DataPropertyName = "YCheck_StopDown";
            this.yCheckStopDownDataGridViewTextBoxColumn.HeaderText = "YCheck_StopDown";
            this.yCheckStopDownDataGridViewTextBoxColumn.Name = "yCheckStopDownDataGridViewTextBoxColumn";
            // 
            // yCheckStopUpDataGridViewTextBoxColumn
            // 
            this.yCheckStopUpDataGridViewTextBoxColumn.DataPropertyName = "YCheck_StopUp";
            this.yCheckStopUpDataGridViewTextBoxColumn.HeaderText = "YCheck_StopUp";
            this.yCheckStopUpDataGridViewTextBoxColumn.Name = "yCheckStopUpDataGridViewTextBoxColumn";
            // 
            // yCheckCellDownDataGridViewTextBoxColumn
            // 
            this.yCheckCellDownDataGridViewTextBoxColumn.DataPropertyName = "YCheck_CellDown";
            this.yCheckCellDownDataGridViewTextBoxColumn.HeaderText = "YCheck_CellDown";
            this.yCheckCellDownDataGridViewTextBoxColumn.Name = "yCheckCellDownDataGridViewTextBoxColumn";
            // 
            // yCheckCellUpDataGridViewTextBoxColumn
            // 
            this.yCheckCellUpDataGridViewTextBoxColumn.DataPropertyName = "YCheck_CellUp";
            this.yCheckCellUpDataGridViewTextBoxColumn.HeaderText = "YCheck_CellUp";
            this.yCheckCellUpDataGridViewTextBoxColumn.Name = "yCheckCellUpDataGridViewTextBoxColumn";
            // 
            // yCheckCellBusyDownDataGridViewTextBoxColumn
            // 
            this.yCheckCellBusyDownDataGridViewTextBoxColumn.DataPropertyName = "YCheck_CellBusyDown";
            this.yCheckCellBusyDownDataGridViewTextBoxColumn.HeaderText = "YCheck_CellBusyDown";
            this.yCheckCellBusyDownDataGridViewTextBoxColumn.Name = "yCheckCellBusyDownDataGridViewTextBoxColumn";
            // 
            // yCheckCellBusyUpDataGridViewTextBoxColumn
            // 
            this.yCheckCellBusyUpDataGridViewTextBoxColumn.DataPropertyName = "YCheck_CellBusyUp";
            this.yCheckCellBusyUpDataGridViewTextBoxColumn.HeaderText = "YCheck_CellBusyUp";
            this.yCheckCellBusyUpDataGridViewTextBoxColumn.Name = "yCheckCellBusyUpDataGridViewTextBoxColumn";
            // 
            // yLoadStopDownDataGridViewTextBoxColumn
            // 
            this.yLoadStopDownDataGridViewTextBoxColumn.DataPropertyName = "YLoad_StopDown";
            this.yLoadStopDownDataGridViewTextBoxColumn.HeaderText = "YLoad_StopDown";
            this.yLoadStopDownDataGridViewTextBoxColumn.Name = "yLoadStopDownDataGridViewTextBoxColumn";
            // 
            // yLoadStopUpDataGridViewTextBoxColumn
            // 
            this.yLoadStopUpDataGridViewTextBoxColumn.DataPropertyName = "YLoad_StopUp";
            this.yLoadStopUpDataGridViewTextBoxColumn.HeaderText = "YLoad_StopUp";
            this.yLoadStopUpDataGridViewTextBoxColumn.Name = "yLoadStopUpDataGridViewTextBoxColumn";
            // 
            // yLoadCellDownDataGridViewTextBoxColumn
            // 
            this.yLoadCellDownDataGridViewTextBoxColumn.DataPropertyName = "YLoad_CellDown";
            this.yLoadCellDownDataGridViewTextBoxColumn.HeaderText = "YLoad_CellDown";
            this.yLoadCellDownDataGridViewTextBoxColumn.Name = "yLoadCellDownDataGridViewTextBoxColumn";
            // 
            // yLoadCellUpDataGridViewTextBoxColumn
            // 
            this.yLoadCellUpDataGridViewTextBoxColumn.DataPropertyName = "YLoad_CellUp";
            this.yLoadCellUpDataGridViewTextBoxColumn.HeaderText = "YLoad_CellUp";
            this.yLoadCellUpDataGridViewTextBoxColumn.Name = "yLoadCellUpDataGridViewTextBoxColumn";
            // 
            // yUploadStopDownDataGridViewTextBoxColumn
            // 
            this.yUploadStopDownDataGridViewTextBoxColumn.DataPropertyName = "YUpload_StopDown";
            this.yUploadStopDownDataGridViewTextBoxColumn.HeaderText = "YUpload_StopDown";
            this.yUploadStopDownDataGridViewTextBoxColumn.Name = "yUploadStopDownDataGridViewTextBoxColumn";
            // 
            // yUploadStopUpDataGridViewTextBoxColumn
            // 
            this.yUploadStopUpDataGridViewTextBoxColumn.DataPropertyName = "YUpload_StopUp";
            this.yUploadStopUpDataGridViewTextBoxColumn.HeaderText = "YUpload_StopUp";
            this.yUploadStopUpDataGridViewTextBoxColumn.Name = "yUploadStopUpDataGridViewTextBoxColumn";
            // 
            // yUploadCellDownDataGridViewTextBoxColumn
            // 
            this.yUploadCellDownDataGridViewTextBoxColumn.DataPropertyName = "YUpload_CellDown";
            this.yUploadCellDownDataGridViewTextBoxColumn.HeaderText = "YUpload_CellDown";
            this.yUploadCellDownDataGridViewTextBoxColumn.Name = "yUploadCellDownDataGridViewTextBoxColumn";
            // 
            // yUploadCellUpDataGridViewTextBoxColumn
            // 
            this.yUploadCellUpDataGridViewTextBoxColumn.DataPropertyName = "YUpload_CellUp";
            this.yUploadCellUpDataGridViewTextBoxColumn.HeaderText = "YUpload_CellUp";
            this.yUploadCellUpDataGridViewTextBoxColumn.Name = "yUploadCellUpDataGridViewTextBoxColumn";
            // 
            // zStopCellDataGridViewTextBoxColumn
            // 
            this.zStopCellDataGridViewTextBoxColumn.DataPropertyName = "Z_StopCell";
            this.zStopCellDataGridViewTextBoxColumn.HeaderText = "Z_StopCell";
            this.zStopCellDataGridViewTextBoxColumn.Name = "zStopCellDataGridViewTextBoxColumn";
            // 
            // zStopStackerDataGridViewTextBoxColumn
            // 
            this.zStopStackerDataGridViewTextBoxColumn.DataPropertyName = "Z_StopStacker";
            this.zStopStackerDataGridViewTextBoxColumn.HeaderText = "Z_StopStacker";
            this.zStopStackerDataGridViewTextBoxColumn.Name = "zStopStackerDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 429);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "АРМ ТИАРА";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdTiaraDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coordsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbZ;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbX;
        private PkbStacker pkbStacker1;
        private System.Windows.Forms.Button button2;
        private PkbStackermanTiara pkbStackermanTiara1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbCell2;
        private System.Windows.Forms.TextBox tbCell1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private bdTiaraDataSet bdTiaraDataSet;
        private System.Windows.Forms.BindingSource coordsBindingSource;
        private bdTiaraDataSetTableAdapters.CoordsTableAdapter coordsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ncellDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xStopBackDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xStopForwardDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xCellBackDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xCellForwardDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yCheckStopDownDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yCheckStopUpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yCheckCellDownDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yCheckCellUpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yCheckCellBusyDownDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yCheckCellBusyUpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yLoadStopDownDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yLoadStopUpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yLoadCellDownDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yLoadCellUpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yUploadStopDownDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yUploadStopUpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yUploadCellDownDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yUploadCellUpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zStopCellDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zStopStackerDataGridViewTextBoxColumn;

    }
}

