namespace PkbLib
{
    partial class PkbStacker
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvRackUp = new System.Windows.Forms.DataGridView();
            this.dgvRackDown = new System.Windows.Forms.DataGridView();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectRails = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectCaret = new System.Windows.Forms.Panel();
            this.rectCaretEnd = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRackUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRackDown)).BeginInit();
            this.rectCaret.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRackUp
            // 
            this.dgvRackUp.AllowUserToAddRows = false;
            this.dgvRackUp.AllowUserToDeleteRows = false;
            this.dgvRackUp.AllowUserToResizeColumns = false;
            this.dgvRackUp.AllowUserToResizeRows = false;
            this.dgvRackUp.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRackUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRackUp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvRackUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRackUp.ColumnHeadersVisible = false;
            this.dgvRackUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvRackUp.Location = new System.Drawing.Point(0, 0);
            this.dgvRackUp.Name = "dgvRackUp";
            this.dgvRackUp.RowHeadersVisible = false;
            this.dgvRackUp.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvRackUp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRackUp.Size = new System.Drawing.Size(467, 65);
            this.dgvRackUp.TabIndex = 0;
            this.dgvRackUp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRackUp_CellClick);
            // 
            // dgvRackDown
            // 
            this.dgvRackDown.AllowUserToAddRows = false;
            this.dgvRackDown.AllowUserToDeleteRows = false;
            this.dgvRackDown.AllowUserToResizeColumns = false;
            this.dgvRackDown.AllowUserToResizeRows = false;
            this.dgvRackDown.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRackDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRackDown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRackDown.ColumnHeadersVisible = false;
            this.dgvRackDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvRackDown.Location = new System.Drawing.Point(0, 108);
            this.dgvRackDown.Name = "dgvRackDown";
            this.dgvRackDown.RowHeadersVisible = false;
            this.dgvRackDown.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvRackDown.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRackDown.Size = new System.Drawing.Size(467, 54);
            this.dgvRackDown.TabIndex = 2;
            this.dgvRackDown.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRackDown_CellClick);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectRails});
            this.shapeContainer1.Size = new System.Drawing.Size(467, 162);
            this.shapeContainer1.TabIndex = 3;
            this.shapeContainer1.TabStop = false;
            // 
            // rectRails
            // 
            this.rectRails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rectRails.Location = new System.Drawing.Point(6, 74);
            this.rectRails.Name = "rectRails";
            this.rectRails.Size = new System.Drawing.Size(466, 23);
            // 
            // rectCaret
            // 
            this.rectCaret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rectCaret.Controls.Add(this.rectCaretEnd);
            this.rectCaret.Location = new System.Drawing.Point(356, 40);
            this.rectCaret.Name = "rectCaret";
            this.rectCaret.Size = new System.Drawing.Size(22, 58);
            this.rectCaret.TabIndex = 4;
            // 
            // rectCaretEnd
            // 
            this.rectCaretEnd.BackColor = System.Drawing.SystemColors.HotTrack;
            this.rectCaretEnd.Dock = System.Windows.Forms.DockStyle.Top;
            this.rectCaretEnd.Location = new System.Drawing.Point(0, 0);
            this.rectCaretEnd.Name = "rectCaretEnd";
            this.rectCaretEnd.Size = new System.Drawing.Size(20, 21);
            this.rectCaretEnd.TabIndex = 0;
            // 
            // PkbStacker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.rectCaret);
            this.Controls.Add(this.dgvRackUp);
            this.Controls.Add(this.dgvRackDown);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "PkbStacker";
            this.Size = new System.Drawing.Size(467, 162);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRackUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRackDown)).EndInit();
            this.rectCaret.ResumeLayout(false);
            this.ResumeLayout(false);
            this.init_stacker();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRackUp;
        private System.Windows.Forms.DataGridView dgvRackDown;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectRails;
        private System.Windows.Forms.Panel rectCaret;
        private System.Windows.Forms.Panel rectCaretEnd;
    }
}
