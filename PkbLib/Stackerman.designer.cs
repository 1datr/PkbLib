namespace PkbLib
{
    partial class Stackerman
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
            this.components = new System.ComponentModel.Container();
            this.WatchTimer = new System.Windows.Forms.Timer(this.components);
            // 
            // WatchTimer
            // 
            this.WatchTimer.Tick += new System.EventHandler(this.WatchTimer_Tick);
            CoordsMust = new StcCoords();
            Coords = new StcCoords();
            OldCoords = new StcCoords();
            f_occupied = false;
            WatchTimer.Enabled = true;

        }

        #endregion

        private System.Windows.Forms.Timer WatchTimer;
    }
}
