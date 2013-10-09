using System.ComponentModel;

namespace PkbLib
{
    partial class CoordCalcer
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
            components = new System.ComponentModel.Container();
        }

        int f_zcellsize = 900;
        [DisplayName("Расстояние между ячейками по вертикали")]
        public int ZCellSize { get { return f_zcellsize; } set { f_zcellsize = value; } }

        int f_inner_cell_x_dist = 880;
        [DisplayName("Между внутренними ячейками")]
        [Description("Расстояние между центрами ячеек в одной макроячейке")]   
        public int InnerCellXDist { get { return f_inner_cell_x_dist; } set { f_inner_cell_x_dist = value; } }

        int f_outer_cell_x_dist = 1040;
        [DisplayName("Между внешними ячейками")]
        [Description("Расстояние между центрами соседних ячеек в разных макроячейках")]   
        public int OuterCellXDist { get { return f_outer_cell_x_dist; } set { f_outer_cell_x_dist = value; } }

        private int f_cellwidth = 1200;
        [DisplayName("Ширина ячейки")]
        [Description("Ширина ячейки")]
        public int CellWidth { get { return f_zcellsize; } set { f_zcellsize = value; } }

        private int f_dist_cell_y = 130;
        [DisplayName("Полный ход каретки")]
        [Description("Максимальное расстояние от центра, которое проходит каретка ход каретки")]
        public int DistCellY { get { return f_dist_cell_y; } set { f_zcellsize = value; } }

        private int f_imp_mm_X = 58;
        [DisplayName("Скорость энкодера")]
        [Description("Сколько милиметров приходится на 1 единицу счета X-энкодера")]
        public int ImpMeasureX { get { return f_imp_mm_X; } set { f_imp_mm_X = value; } }

        private int f_imp_mm_Y = 58;
        [DisplayName("Скорость энкодера")]
        [Description("Сколько милиметров приходится на 1 единицу счета Y-энкодера")]
        public int ImpMeasureY { get { return f_imp_mm_Y; } set { f_imp_mm_Y = value; } }

        private int f_imp_mm_Z = 58;
        [DisplayName("Скорость энкодера")]
        [Description("Сколько милиметров приходится на 1 единицу счета Z-энкодера")]
        public int ImpMeasureZ { get { return f_imp_mm_Z; } set { f_imp_mm_Z = value; } }

        private int f_OffsX = 100000;
        [DisplayName("Смещение по X")]
        [Description("Сколько единиц X-энкодера соответствует нулевой позиции")]
        public int XOffs { get { return f_OffsX; } set { f_OffsX = value; } }

        private int f_OffsZ = 50000;
        [DisplayName("Смещение по X")]
        [Description("Сколько единиц X-энкодера соответствует нулевой позиции")]
        public int ZOffs { get { return f_OffsZ; } set { f_OffsZ = value; } }

        private int f_OffsY = 20000;
        [DisplayName("Смещение по Y")]
        [Description("Сколько единиц Y-энкодера соответствует нулевой позиции")]
        public int YOffs { get { return f_OffsY; } set { f_OffsY = value; } }

        private int f_grouping = 0;
        [DisplayName("Группировка")]
        [Description("Сколько ячеек в одной ячейке")]        
        public int Grouping
        {
            get { return f_grouping; } 
                set { 
                    if(value>1) 
                        f_grouping = value; 
                    else 
                        f_grouping = 0; 
                } 
        }

        // выдать реальные координаты ячейки
        public RealCellCoord GetCellCoord(Point3 CellIdx)
        {
            RealCellCoord RCC = new RealCellCoord();
            if ((CellIdx.X < f_grouping)||(f_grouping == 0))
            {
                RCC.X_CellBack = f_inner_cell_x_dist * CellIdx.X;
            }
            else
            {
                int bordercell_count;
                bordercell_count = CellIdx.X/f_grouping; 
                RCC.X_CellBack = bordercell_count * f_outer_cell_x_dist + (CellIdx.X + 1 - bordercell_count) * f_inner_cell_x_dist;
            }
            RCC.Z_StopCell = f_zcellsize * CellIdx.Z;
            
            if (CellIdx.Y == 0)
                RCC.YCheck_CellDown = this.f_dist_cell_y;
            else if (CellIdx.Y == 1)
                RCC.YCheck_CellDown = -this.f_dist_cell_y;
            
            RCC.X_CellBack = f_OffsX + f_imp_mm_X * RCC.X_CellBack;
            RCC.YCheck_CellDown = f_OffsY + f_imp_mm_Y * RCC.YCheck_CellDown;
            RCC.Z_StopCell = f_OffsZ + f_imp_mm_Z * RCC.Z_StopCell;

            return RCC;
        }

        #endregion
    }
}
