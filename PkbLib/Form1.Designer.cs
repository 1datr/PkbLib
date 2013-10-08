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
            this.stackerman1 = new PkbLib.Stackerman(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pkbStackermanTiara1 = new PkbLib.PkbStackermanTiara(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.groupBox2.Location = new System.Drawing.Point(0, 320);
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
            // 
            // pkbStacker1
            // 
            this.pkbStacker1.AutoSize = true;
            this.pkbStacker1.CellHeight = 20;
            this.pkbStacker1.CellLength = 30;
            this.pkbStacker1.CellWidth = 15;
            this.pkbStacker1.CoordBuff = ((System.Collections.Generic.Dictionary<int, PkbLib.Point3>)(resources.GetObject("pkbStacker1.CoordBuff")));
            this.pkbStacker1.FloorCount = 5;
            this.pkbStacker1.Grouping = 3;
            this.pkbStacker1.Location = new System.Drawing.Point(6, 6);
            this.pkbStacker1.MaximumSize = new System.Drawing.Size(871, 281);
            this.pkbStacker1.MinimumSize = new System.Drawing.Size(871, 281);
            this.pkbStacker1.Name = "pkbStacker1";
            this.pkbStacker1.OffsX = 0;
            this.pkbStacker1.OffsY = 0;
            this.pkbStacker1.OffsZ = 0;
            this.pkbStacker1.Position = ((PkbLib.Point3)(resources.GetObject("pkbStacker1.Position")));
            this.pkbStacker1.RowCount = 33;
            this.pkbStacker1.Size = new System.Drawing.Size(871, 281);
            this.pkbStacker1.Stacker_Manager = this.stackerman1;
            this.pkbStacker1.Sub = 4;
            this.pkbStacker1.TabIndex = 2;
            // 
            // stackerman1
            // 
            this.stackerman1.Active = true;
            this.stackerman1.MustPoint = ((PkbLib.Point3)(resources.GetObject("stackerman1.MustPoint")));
            this.stackerman1.OnCoordChange += new PkbLib.OnStackermanCoordChange(this.stackerman1_OnCoordChange);
            this.stackerman1.OnCommandError += new PkbLib.OnStackermanCommandError(this.stackerman1_OnCommandError);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(929, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pkbStackermanTiara1
            // 
            this.pkbStackermanTiara1.Active = true;
            this.pkbStackermanTiara1.IpAdr = "";
            this.pkbStackermanTiara1.MustPoint = ((PkbLib.Point3)(resources.GetObject("pkbStackermanTiara1.MustPoint")));
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 429);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "АРМ ТИАРА";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PkbLib.Stackerman stackerman1;
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

    }
}

