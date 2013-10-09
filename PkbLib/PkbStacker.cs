using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PkbLib
{

    public partial class PkbStacker : UserControl
    {
        public PkbStacker()
        {
            InitializeComponent();
        }

        int cellsize_field = 25;
        [DisplayName("Размер ячейки")]
        private int cellsize
        {
            get { return cellsize_field; }
            set { 
                cellsize_field = value;

                foreach (DataGridViewRow dgvr in dgvRackDown.Rows)
                {
                    dgvr.Height = cellsize_field;
                }

                foreach (DataGridViewRow dgvr in dgvRackUp.Rows)
                {
                    dgvr.Height = cellsize_field;
                }

                for (int i = 0; i < dgvRackDown.Columns.Count; i++)
                {
                    dgvRackUp.Columns[i].Width = cellsize_field;
                }

                for (int i = 0; i < dgvRackUp.Columns.Count; i++ )
                {
                    dgvRackUp.Columns[i].Width = cellsize_field;
                }

                DGVResize();               
            }

        }
        // Количество рядов ячеек
        private int rowcount = 5;
        [DisplayName("Рядов штабелера")]
        [Description("Количество рядов штабелера")]
        public int RowCount
        {
            get { return rowcount; }
            set {
                rowcount = value;
                SetRowCount(dgvRackDown,rowcount);                
                SetRowCount(dgvRackUp, rowcount);
                SetNumbers();         
            }
        }
        // Количество полок
        private int floorcount = 5;
        [DisplayName("Полок штаблера")]
        [Description("Количество полок штабелера")]
        public int FloorCount
        {
            get { return floorcount; }
            set
            {
                floorcount = value;
                SetFloorCount(dgvRackDown, value);                
                SetFloorCount(dgvRackUp, value);
                SetNumbers();               
              }
        }
        // Установить число полок штабелера
        private void SetFloorCount(DataGridView dgv, int floorcount)
        {
            if (dgv.Columns.Count == 0) SetRowCount(dgv, rowcount);
            if (dgv.Rows.Count < floorcount)
            { 
                for(int i= dgv.Rows.Count; i<floorcount; i++)
                {
                    dgv.Rows.Add();
                    dgv.Rows[dgv.Rows.Count - 1].Height = cellsize_field;
                }
            }
            else if (dgv.Rows.Count > floorcount)
            { 
                while (dgv.Rows.Count!=floorcount)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                        CellBuff.Remove(Convert.ToInt32(dgv[dgv.Rows.Count - 1, i].Value));
                    dgv.Columns.RemoveAt(dgv.Columns.Count - 1);
                    dgv.Rows.RemoveAt(0);
                }
            }
            dgv.Height = floorcount * (this.cellsize+4);
            DGVResize();
        }
        // Установить число вертикальных рядов штабелера
        private void SetRowCount(DataGridView dgv, int rowcount)
        {
            if (dgv.Columns.Count < rowcount)
            {
                
                for (int i = dgv.Columns.Count; i < rowcount; i++)
                {
                    DataGridViewCellStyle dcs;
                    Padding padding;
                    DataGridViewButtonColumn clmn = new DataGridViewButtonColumn();
                    clmn.Width = cellsize_field;
                    
                    clmn.FlatStyle = FlatStyle.Popup;
                    dcs = clmn.DefaultCellStyle;
                 /*   dcs.SelectionBackColor = Color.Red;
                    dcs.SelectionForeColor = Color.Black;*/
                    clmn.DefaultCellStyle = dcs;
                    padding = dcs.Padding;

                    padding.Right = 0;
                    if (f_grouping > 1)
                    {
                        if (((i + 1) % f_grouping == 0) & (i > 0))
                        {
                            padding.Right = 4;
                            clmn.Width = cellsize + 4;
                        }
                    }
                    
                    dcs.Padding = padding;
                    clmn.DefaultCellStyle = dcs;

                    dgv.Columns.Add(clmn);

                    
                }
            }
            else if (dgv.Columns.Count > rowcount)
            {
                while(dgv.Columns.Count!=rowcount)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        int val = Convert.ToInt32(dgv[dgv.Columns.Count - 1, i].Value);
                        CellBuff.Remove(val);
                    }
                    dgv.Columns.RemoveAt(dgv.Columns.Count-1);
                    
                }
            }
            
            dgv.Width = rowcount * (this.cellsize+4);
            DGVResize();
        }
        // массив ячеек
        private Dictionary<int,PkbCell> CellBuff;
        /*// установить координаты ячейки в массив и в штабелер
        private void SetCellCoords(int cell, Point3 coords)
        {
            if (CoordBuff == null) CoordBuff = new Dictionary<int, Point3>();
            if ( this.CoordBuff.ContainsKey(cell)) this.CoordBuff[cell] = coords;
            else this.CoordBuff.Add(cell, coords);

            if(SM!=null)
                SM.SetCellCoord(cell, coords);
        }
        */
        // установить координаты ячейки в массив и в штабелер
        private void SetCellCoords(int cell, RealCellCoord RCC )
        {
            

            if (SM != null)
                SM.SetCellCoord(cell, RCC);
        }

        private CoordCalcer f_calcer;
        [DisplayName("Вычислитель координат")]
        [Description("Компонент, вычисляющий координаты ячейки")]      
        public CoordCalcer Calcer {
            get {
                if (f_calcer == null) f_calcer = new CoordCalcer();
                return f_calcer;
            }
            set {
                f_calcer = value;
            }
        }
        /*
        private void CalcCoords()
        {
            if (this.CellBuff == null) this.CellBuff = new Dictionary<int, PkbCell>();
            foreach(KeyValuePair<int, PkbCell> item in this.CellBuff)
            {                
                SetCellCoords(item.Key, item.Value.CalcPoint(f_CellLength, f_CellWidth, f_CellHeight, f_sub));
            }
        }*/
        //Сохранение координат в БД
        private BindingSource bs_Coords;
        [DisplayName("Источник данных координат")]
        public BindingSource BSCoordsContent
        {
            get
            {
                if (bs_Coords == null) bs_Coords = new BindingSource();
                return bs_Coords;
            }
            set
            {
                bs_Coords = value;
                /*
                if (ds != null)
                {
                    if (this.bs_cell_Content != null)
                        this.ds = ((DataSet)this.bs_cell_Content.DataSource);
                    if (DA != null)
                        DA.Fill(ds);
                }*/

                //this.load_all_cells();
            }
        }

        // Рассчитать реальные координаты ячейки
        public RealCellCoord CalcCellCoord(int ncell)
        {
            RealCellCoord RCC = new RealCellCoord();
            PkbCell cell = CellBuff[ncell];
            /*Point3D cell_indxes = */
            if (this.Calcer != null) RCC = f_calcer.GetCellCoord(cell.Indexes);
            return RCC;
        }

        public RealCellCoord GetCellRealCoords(int ncell)
        {
            if (bs_Coords == null) return CalcCellCoord(ncell);
            bs_Coords.Filter = String.Format("ncell={0}", ncell);
            bs_Coords.MoveFirst();
            object theitem = bs_Coords.Current;
            RealCellCoord coord = new RealCellCoord();
            if (theitem == null)
            {
                coord = CalcCellCoord(ncell);
                bs_Coords.Add(coord);
            }
            else
            {
                if (theitem.GetType() == typeof(DataRowView))
                {
                    DataRowView dr = ((DataRowView)bs_Coords.Current);
                    //DataRowView dr = ((DataRowView)theitem);
                    if (dr != null)
                    {
                        if (dr["Id"] != DBNull.Value)
                            coord.id = Convert.ToInt32(dr["Id"]);
                        if (dr["ncell"] != DBNull.Value)
                            coord.ncell = Convert.ToInt32(dr["ncell"]);
                        if (dr["X_CellBack"] != DBNull.Value)
                            coord.X_CellBack = Convert.ToInt32(dr["X_CellBack"]);
                        if (dr["X_CellForward"] != DBNull.Value)
                            coord.X_CellForward = Convert.ToInt32(dr["X_CellForward"]);
                        if (dr["X_StopBack"] != DBNull.Value)
                            coord.X_StopBack = Convert.ToInt32(dr["X_StopBack"]);
                        if (dr["X_StopForward"] != DBNull.Value)
                            coord.X_StopForward = Convert.ToInt32(dr["X_StopForward"]);
                        if (dr["YCheck_CellBusyDown"] != DBNull.Value)
                            coord.YCheck_CellBusyDown = Convert.ToInt32(dr["YCheck_CellBusyDown"]);
                        if (dr["YCheck_CellUp"] != DBNull.Value)
                            coord.YCheck_CellUp = Convert.ToInt32(dr["YCheck_CellUp"]);
                        if (dr["YCheck_CellDown"] != DBNull.Value)
                            coord.YCheck_CellDown = Convert.ToInt32(dr["YCheck_CellDown"]);
                        if (dr["YCheck_StopDown"] != DBNull.Value)
                            coord.YCheck_StopDown = Convert.ToInt32(dr["YCheck_StopDown"]);
                        if (dr["YCheck_StopUp"] != DBNull.Value)
                            coord.YCheck_StopUp = Convert.ToInt32(dr["YCheck_StopUp"]);
                        if (dr["YLoad_CellDown"] != DBNull.Value)
                            coord.YLoad_CellDown = Convert.ToInt32(dr["YLoad_CellDown"]);
                        if (dr["YLoad_CellUp"] != DBNull.Value)
                            coord.YLoad_CellUp = Convert.ToInt32(dr["YLoad_CellUp"]);
                        if (dr["YLoad_StopDown"] != DBNull.Value)
                            coord.YLoad_StopDown = Convert.ToInt32(dr["YLoad_StopDown"]);
                        if (dr["YLoad_StopUp"] != DBNull.Value)
                            coord.YLoad_StopUp = Convert.ToInt32(dr["YLoad_StopUp"]);
                        if (dr["YUpload_CellDown"] != DBNull.Value)
                            coord.YUpload_CellDown = Convert.ToInt32(dr["YUpload_CellDown"]);
                        if (dr["YUpload_CellUp"] != DBNull.Value)
                            coord.YUpload_CellUp = Convert.ToInt32(dr["YUpload_CellUp"]);
                        if (dr["YUpload_StopDown"] != DBNull.Value)
                            coord.YUpload_StopDown = Convert.ToInt32(dr["YUpload_StopDown"]);
                        if (dr["YUpload_StopUp"] != DBNull.Value)
                            coord.YUpload_StopUp = Convert.ToInt32(dr["YUpload_StopUp"]);
                        if (dr["Z_StopCell"] != DBNull.Value)
                            coord.Z_StopCell = Convert.ToInt32(dr["Z_StopCell"]);
                        if (dr["Z_StopStacker"] != DBNull.Value)
                            coord.Z_StopStacker = Convert.ToInt32(dr["Z_StopStacker"]);
                    }

                }
                else
                {
                    CurrencyManager cmgr = bs_Coords.CurrencyManager;
                    DataRow dr = ((DataRowView)cmgr.Current).Row;
                    //DataRowView dr = ((DataRowView)theitem);             

                    if (dr["Id"] != DBNull.Value)
                        coord.id = Convert.ToInt32(dr["Id"]);
                    if (dr["ncell"] != DBNull.Value)
                        coord.ncell = Convert.ToInt32(dr["ncell"]);
                    if (dr["X_CellBack"] != DBNull.Value)
                        coord.X_CellBack = Convert.ToInt32(dr["X_CellBack"]);
                    if (dr["X_CellForward"] != DBNull.Value)
                        coord.X_CellForward = Convert.ToInt32(dr["X_CellForward"]);
                    if (dr["X_StopBack"] != DBNull.Value)
                        coord.X_StopBack = Convert.ToInt32(dr["X_StopBack"]);
                    if (dr["X_StopForward"] != DBNull.Value)
                        coord.X_StopForward = Convert.ToInt32(dr["X_StopForward"]);
                    if (dr["YCheck_CellBusyDown"] != DBNull.Value)
                        coord.YCheck_CellBusyDown = Convert.ToInt32(dr["YCheck_CellBusyDown"]);
                    if (dr["YCheck_CellUp"] != DBNull.Value)
                        coord.YCheck_CellUp = Convert.ToInt32(dr["YCheck_CellUp"]);
                    if (dr["YCheck_CellDown"] != DBNull.Value)
                        coord.YCheck_CellDown = Convert.ToInt32(dr["YCheck_CellDown"]);
                    if (dr["YCheck_StopDown"] != DBNull.Value)
                        coord.YCheck_StopDown = Convert.ToInt32(dr["YCheck_StopDown"]);
                    if (dr["YCheck_StopUp"] != DBNull.Value)
                        coord.YCheck_StopUp = Convert.ToInt32(dr["YCheck_StopUp"]);
                    if (dr["YLoad_CellDown"] != DBNull.Value)
                        coord.YLoad_CellDown = Convert.ToInt32(dr["YLoad_CellDown"]);
                    if (dr["YLoad_CellUp"] != DBNull.Value)
                        coord.YLoad_CellUp = Convert.ToInt32(dr["YLoad_CellUp"]);
                    if (dr["YLoad_StopDown"] != DBNull.Value)
                        coord.YLoad_StopDown = Convert.ToInt32(dr["YLoad_StopDown"]);
                    if (dr["YLoad_StopUp"] != DBNull.Value)
                        coord.YLoad_StopUp = Convert.ToInt32(dr["YLoad_StopUp"]);
                    if (dr["YUpload_CellDown"] != DBNull.Value)
                        coord.YUpload_CellDown = Convert.ToInt32(dr["YUpload_CellDown"]);
                    if (dr["YUpload_CellUp"] != DBNull.Value)
                        coord.YUpload_CellUp = Convert.ToInt32(dr["YUpload_CellUp"]);
                    if (dr["YUpload_StopDown"] != DBNull.Value)
                        coord.YUpload_StopDown = Convert.ToInt32(dr["YUpload_StopDown"]);
                    if (dr["YUpload_StopUp"] != DBNull.Value)
                        coord.YUpload_StopUp = Convert.ToInt32(dr["YUpload_StopUp"]);
                    if (dr["Z_StopCell"] != DBNull.Value)
                        coord.Z_StopCell = Convert.ToInt32(dr["Z_StopCell"]);
                    if (dr["Z_StopStacker"] != DBNull.Value)
                        coord.Z_StopStacker = Convert.ToInt32(dr["Z_StopStacker"]);
                }
            }

            return coord;
        }
        // раздаем ячейкам номера
        private void SetNumbers()
        {
            if (CellBuff == null) CellBuff = new Dictionary<int, PkbCell>();
            int ncell = 1;
            for (int x = 0 ; x < dgvRackUp.Columns.Count; x++)
            {
                for (int y = dgvRackUp.Rows.Count-1; y >= 0; y--)
                {
                        dgvRackUp[x, y].Value = ncell;
                        if (ncell < CellBuff.Count - 1)
                        {
                            CellBuff[ncell].Indexes = new Point3(x, y, 0);
                            CellBuff[ncell].Coords = new Point3(x, 1, dgvRackUp.Rows.Count - y - 1);
                            CellBuff[ncell].Number = ncell;
                            CellBuff[ncell].Parent = this;
                        }
                        else
                        {
                            PkbCell C = new PkbCell();
                            C.Indexes = new Point3(x,y,0);
                            C.Number = ncell;
                            C.Parent = this;
                            C.Coords = new Point3(x, 1, dgvRackUp.Rows.Count - y - 1);
                            CellBuff[ncell]=C;
                        }
                        
                        ncell++;
                    
                }
            }

            for (int x = 0; x < dgvRackDown.Columns.Count; x++)
            {
                for (int y = 0; y<dgvRackDown.Rows.Count; y++)
                {
                        dgvRackDown[x, y].Value = ncell;
                        if (CellBuff.ContainsKey(ncell))
                        {
                            CellBuff[ncell].Indexes = new Point3(x,y,1);
                            CellBuff[ncell].Coords = new Point3(x, -1, y);
                            CellBuff[ncell].Number = ncell;
                        }
                        else
                        {
                            PkbCell C = new PkbCell();
                            C.Indexes = new Point3(x,y,1);
                            C.Coords = new Point3(x, -1, y);
                            C.Number = ncell;
                            CellBuff.Add(ncell, C);
                        }
                     
                        ncell++;
                }
            }

           
        }

        private void DGVResize()
        {
            dgvRackUp.Height = dgvRackUp.Rows.GetRowsHeight(DataGridViewElementStates.Visible)+2;
            dgvRackUp.Dock = DockStyle.None;
            dgvRackUp.Width = dgvRackUp.Columns.GetColumnsWidth(DataGridViewElementStates.Visible)+2;
            dgvRackDown.Height = dgvRackDown.Rows.GetRowsHeight(DataGridViewElementStates.Visible)+2;
            dgvRackDown.Dock = DockStyle.None;
            dgvRackDown.Width = dgvRackDown.Columns.GetColumnsWidth(DataGridViewElementStates.Visible)+2;

            
            this.rectRails.Width = dgvRackDown.Width;

            this.MinimumSize = new System.Drawing.Size(dgvRackUp.Width, rectRails.Height + dgvRackDown.Height + dgvRackUp.Height + 4);
            this.MaximumSize = this.MinimumSize;
            dgvRackUp.Dock = DockStyle.Top;
            dgvRackDown.Dock = DockStyle.Bottom;

            
         
        }

        private Point3 f_position;
        public Point3 Position
        {
            set
            {
                f_position = value;
                draw_stacker();
            }
            get
            {
                return f_position;
            }
        }
        // стиль ячейки как на границе
        private void SetBorderCellStyle(ref DataGridViewColumn clmn)
        {
            Padding padding;
            DataGridViewCellStyle dcs;
            dcs = clmn.DefaultCellStyle;
            padding = dcs.Padding;
            padding.Right = 0;
            dcs.Padding = padding;
            clmn.DefaultCellStyle = dcs;
            clmn.Width = cellsize;
        }

        private void SetNormalCellStyle(ref DataGridViewColumn clmn)
        {
            Padding padding;
            DataGridViewCellStyle dcs;
            dcs = clmn.DefaultCellStyle;
            padding = dcs.Padding;
            padding.Right = 0;
            dcs.Padding = padding;
            clmn.DefaultCellStyle = dcs;
            clmn.Width = cellsize;
        }

        private int f_grouping = 0;
        [DisplayName("Группировка")]
        [Description("Когда ячейка состоит из нескольких ячеек")]
        public int Grouping
        {
            get { return f_grouping; }
            set
            {
                Padding padding;
                DataGridViewCellStyle dcs;
                f_grouping = value;
                if (this.Calcer != null) this.Calcer.Grouping = f_grouping;
                if (f_grouping > 1)
                {
                    
                    for (int i = 0; i < dgvRackDown.Columns.Count; i++)
                    {                        
                        if (((i + 1) % f_grouping == 0) & (i > 0) & (i < dgvRackDown.Columns.Count - 1))
                        {
                            dcs = dgvRackDown.Columns[i].DefaultCellStyle;
                            padding = dcs.Padding;
                            padding.Right = 4;
                            dcs.Padding = padding;
                            dgvRackDown.Columns[i].DefaultCellStyle = dcs;
                            dgvRackDown.Columns[i].Width = cellsize + 4;
                        }
                        else
                        {
                            dcs = dgvRackDown.Columns[i].DefaultCellStyle;
                            padding = dcs.Padding;
                            padding.Right = 0;
                            dcs.Padding = padding;
                            dgvRackDown.Columns[i].DefaultCellStyle = dcs;
                            dgvRackDown.Columns[i].Width = cellsize;
                        }
                    }
                    for (int i = 0; i < dgvRackUp.Columns.Count; i++)
                    {
                        if (((i + 1) % f_grouping == 0) & (i > 0) & (i < dgvRackDown.Columns.Count - 1))
                        {

                            dcs = dgvRackUp.Columns[i].DefaultCellStyle;
                            padding = dcs.Padding;
                            padding.Right = 4;
                            dcs.Padding = padding;
                            dgvRackUp.Columns[i].DefaultCellStyle = dcs;
                            dgvRackUp.Columns[i].Width = cellsize + 4;

                        }
                        else
                        {
                            dcs = dgvRackUp.Columns[i].DefaultCellStyle;
                            padding = dcs.Padding;
                            padding.Right = 0;
                            dcs.Padding = padding;
                            dgvRackUp.Columns[i].DefaultCellStyle = dcs;
                            dgvRackUp.Columns[i].Width = cellsize;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < dgvRackDown.Columns.Count; i++)
                    {
                        dcs = dgvRackDown.Columns[i].DefaultCellStyle;
                        padding = dcs.Padding;
                        padding.Right = 0;
                        dcs.Padding = padding;
                        dgvRackDown.Columns[i].DefaultCellStyle = dcs;
                        dgvRackDown.Columns[i].Width = cellsize;
                    }
                    for (int i = 0; i < dgvRackUp.Columns.Count; i++)
                    {
                        dcs = dgvRackUp.Columns[i].DefaultCellStyle;
                        padding = dcs.Padding;
                        padding.Right = 0;
                        dcs.Padding = padding;
                        dgvRackUp.Columns[i].DefaultCellStyle = dcs;
                        dgvRackUp.Columns[i].Width = cellsize;
                    }
                }
                DGVResize();
            }
        }

        protected DataGridViewCell GetGridCell(PkbCell C)
        {
            if (C.Indexes.Z == 0) {
                return dgvRackUp[C.Indexes.X, C.Indexes.Y];
            }
            else {
                return dgvRackDown[C.Indexes.X, C.Indexes.Y];
            }
        }
        // Прорисовка штабелера
        protected void draw_stacker()
        {
            int railsheight = rectRails.Height;
            this.rectRails.SetBounds(dgvRackUp.Location.X+1, dgvRackUp.Location.Y + dgvRackUp.Height + 1, dgvRackUp.Width-4, rectRails.Height);
            Point L = this.rectRails.Location;
            // L.X++; L.Y++;
            // Пересчитываем Y c учетом перспективы     
           // int delta = CellBuff[1].GetPoint()
            int qmax;
            if (f_position.Z < 4) 
                {
                    qmax = 4;
                    this.f_position.Y = Position.Y * (qmax / 4);
                    
                }
            else 
                {
                    qmax = 4 + Position.Z;
                    this.f_position.Y = Position.Y * (qmax / cellsize)+cellsize;
                }
            

            if (Position.Y < 0)
            {
                rectCaret.Location = new Point(L.X + Position.X, L.Y);
                rectCaret.Height = rectRails.Height + System.Math.Abs(Position.Y)+1;
                rectCaretEnd.Dock = DockStyle.Bottom;
                
            }
            else 
            {
                
                rectCaret.Location = new Point(L.X + Position.X, L.Y-Position.Y);
                if (Position.Y > 0) rectCaret.Location = new Point(L.X + Position.X, L.Y - Position.Y-1);
                rectCaret.Height = Position.Y+rectRails.Height;
                rectCaretEnd.Dock = DockStyle.Top;
            }           
            
        }

        private void dgv_style_update()
        {
            dgvRackDown.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvRackUp.CellBorderStyle = DataGridViewCellBorderStyle.None;
        }

        // Инициализировать контрол штабелера
        private void init_stacker()
        {
            CellBuff = new Dictionary<int,PkbCell>();
            CmdQueue = new Queue<PkbStackerCmd>();
            Position = new Point3(0, 0, 0);

            SetRowCount(dgvRackDown, rowcount);
            SetRowCount(dgvRackUp, rowcount);

            SetFloorCount(dgvRackDown, floorcount);
            SetFloorCount(dgvRackUp, floorcount);

            dgv_style_update();

            SetNumbers();
            draw_stacker();

            dgvRackDown.ClearSelection();
            dgvRackUp.ClearSelection();
        }
        private DataGridViewButtonCell currcell = null;
        private DataGridView curr_dgv = null;
        private void dgvRackUp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (currcell != null)
                currcell.Style.ForeColor = Color.Black;
            currcell = (DataGridViewButtonCell)dgvRackUp.CurrentCell;
            currcell.Style.ForeColor = Color.Red;
            curr_dgv = dgvRackUp;           
        }

        private void dgvRackDown_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (currcell != null)
                currcell.Style.ForeColor = Color.Black;
            currcell = (DataGridViewButtonCell)dgvRackDown.CurrentCell;
            currcell.Style.ForeColor = Color.Red;
            curr_dgv = dgvRackDown;           
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }
        
        private Stackerman SM;
        [DisplayName("Менеджер штабелера")]
        [Description("Компонент управляющий штабелером")]
        public Stackerman Stacker_Manager
        {
            set {
                SM = value;
                if (SM != null)
                {
                    SM.OnCoordChange += new OnStackermanCoordChange(this.stackerman1_OnCoordChange);
                    // при завершении текущей команды
                    SM.OnCommandEnd += new OnStackermanCommandEnd(this.stackerman1_OnCommandEnd);
                    // при аларме
                    SM.OnAlarm += new OnStackerAlarm(this.stackerman1_OnAlarm);
                    // при программных ошибках
                    SM.OnError += new OnStackermanError(this.stackerman1_OnError);
                }
            }
            get { return SM; }
        }

        // Событие, подключаемое к менеджеру штабелера. Реагирует на событие штабелера при изменении координаты
        private void stackerman1_OnCoordChange(StcCoords Coords, StcCoords OldCoords)
        {
            Position = new Point3(Convert.ToInt32(Coords.X.Dist), Convert.ToInt32(Coords.Y.Dist), Convert.ToInt32(Coords.Z.Dist));
            if(f_grouping>1)
                Position = new Point3((Position.X - this.f_calcer.XOffs) * (f_grouping*cellsize+4) / (f_calcer.InnerCellXDist*f_grouping),
                (Position.Y - this.f_calcer.YOffs - 4) * (cellsize) / f_calcer.DistCellY,
                (Position.Z - this.f_calcer.ZOffs) * (cellsize) / f_calcer.ZCellSize);
            else
                Position = new Point3((Position.X - this.f_calcer.YOffs) * (cellsize) / f_calcer.InnerCellXDist,
                (Position.Y - this.f_calcer.YOffs - 4) * (cellsize) / f_calcer.DistCellY,
                (Position.Z - this.f_calcer.ZOffs) * (cellsize) / f_calcer.ZCellSize);
            this.draw_stacker();
        }

        // Завершено выполнение команды
        private void stackerman1_OnCommandEnd(int cmd, object[] _params)
        {
            //this.CmdQueue.
            send_cmd();
        }

        private void stackerman1_OnAlarm(int cmd, object[] _params, string errstr)
        { 
        
        }

        private void stackerman1_OnError(string errstr)
        {

        }

        // отправить команду
        private void send_cmd(int cmd_idx=0)
        {
            PkbStackerCmd cmd = this.CmdQueue.Peek();
            if(cmd!=null)
                {
                    switch (cmd.cmd)
                    {
                        case "park": SM.Park(); break;
                        case "trans":
                            // яч 1
                            SM.SetCellCoord(cmd.param1, this.GetCellRealCoords(cmd.param1));
                            // яч 2
                            SM.SetCellCoord(cmd.param2, this.GetCellRealCoords(cmd.param2));
                            // команда на перемещение
                            SM.Transmit(cmd.param1, cmd.param2); 
                            break;

                        case "check":
                            break;
                    }
                }
        }

      

        private Queue<PkbStackerCmd> CmdQueue;
        public void AddCommand(string cmdstr, int param1=0, int param2=0)
        {
            CmdQueue.Enqueue(new PkbStackerCmd(cmdstr, param1, param2));
            if (!SM.Occupied)
                send_cmd();
        }

        private bool f_stoped = false;
        public bool stoped { get { return f_stoped; } }
        // Остановить штабелер
        public virtual void Stop()
        {
            SM.Stop();
            f_stoped = true;
        }
        // Возобновить работу штабелера
        public virtual void Resume()
        {
            SM.Resume();
            f_stoped = false;
        }

        /*private Dictionary<int, Point3> f_CoordBuff;
        public Dictionary<int, Point3> CoordBuff { get { return f_CoordBuff; } set { f_CoordBuff = value; } }*/

        private void dgvRackUp_SelectionChanged(object sender, EventArgs e)
        {
      /*      if (currcell != null)
                currcell.Style.ForeColor = Color.Black;*/
            currcell = (DataGridViewButtonCell)dgvRackUp.CurrentCell;
          //  currcell.Style.ForeColor = Color.Red;
            //currcell.Style.B = Color.Red;
            if (curr_dgv != dgvRackUp) if(curr_dgv!=null) curr_dgv.ClearSelection();
            curr_dgv = dgvRackUp; 
        }

        private void dgvRackDown_SelectionChanged(object sender, EventArgs e)
        {
          /*  if (currcell != null)
                currcell.Style.ForeColor = Color.Black;*/
            currcell = (DataGridViewButtonCell)dgvRackDown.CurrentCell;
       //     currcell.Style.ForeColor = Color.Red;
            if (curr_dgv != dgvRackDown) if (curr_dgv != null) curr_dgv.ClearSelection();
            curr_dgv = dgvRackDown;
        }

        private void PkbStacker_Load(object sender, EventArgs e)
        {
            this.init_stacker();
        }
    }
}
