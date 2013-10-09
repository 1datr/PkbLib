using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PkbLib
{
    // координаты штабелера
    public class StcCoordItem
    {
        public double Value;
        public double Dist;
        public double Speed;
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            StcCoordItem obj_item = (StcCoordItem)obj;
            return ((obj_item.Value == this.Value) & (obj_item.Dist == this.Dist) & (obj_item.Speed == this.Speed));
        }
    }



    public class StcCoords:ICloneable
    {
        public StcCoordItem X; // отход от изначальной позиции
        public StcCoordItem Y; // на сколько поднялся наверх
        public StcCoordItem Z; // сдвиг каретки
        public string[] motionX;
        public string[] motionY;
        public string[] motionZ;
        public StcCoords()
        {
            X = new StcCoordItem();
            Y = new StcCoordItem();
            Z = new StcCoordItem();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            StcCoords obj_item = (StcCoords)obj;
            return (obj_item.X.Equals(this.X) & obj_item.Y.Equals(this.Y) & obj_item.Z.Equals(this.Z));
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
        public StcCoords Clone()
        {
            return (StcCoords)this.MemberwiseClone();           
        }

        public void Copy(StcCoords Coords)
        {
            this.X.Value = Coords.X.Value;
            this.Y.Value = Coords.Y.Value;
            this.Z.Value = Coords.Z.Value;

            this.X.Dist = Coords.X.Dist;
            this.Y.Dist = Coords.Y.Dist;
            this.Z.Dist = Coords.Z.Dist;

            this.X.Speed = Coords.X.Speed;
            this.Y.Speed = Coords.Y.Speed;
            this.Z.Speed = Coords.Z.Speed;
        }
    }

    /* делегаты событий */
    public delegate void OnStackermanCommandExec(int cmd, object[] _params);
    // команда выполнена
    public delegate void OnStackermanCommandEnd(int cmd, object[] _params);
    // команда завершилась с аварией
    public delegate void OnStackerAlarm(int cmd, object[] _params, string errstr);
    // ошибка. Исключительная ситуация
    public delegate void OnStackermanError(string errstr);
    // при изменении координат штабелера
    public delegate void OnStackermanCoordChange(StcCoords Coords, StcCoords OldCoords);
    // при изменении состояния готовности
    public delegate void OnReadyStateChange(bool ready, string msg);

    public partial class Stackerman : Component
    {
        public Stackerman()
        {
            InitializeComponent();
            
        }

        public Stackerman(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            
        }

        public virtual object stateinfo()
        {
            return "OK";
        }

        private void WatchTimer_Tick(object sender, EventArgs e)
        {
            WatchTimer.Enabled = false;
            OnTimer();
            WatchPosition();
            WatchCmd();
            WatchTimer.Enabled = true;
        }

        private string command;
        private int param1;
        private int param2;

        protected virtual void WatchCmd()
        {
            switch (command)
            {
                case "park":
                    break;
                case "trans":
                    {
                        if ((MustPoint.X == this.CoordsBuf[param1].X) & (MustPoint.Y == this.CoordsBuf[param1].Y) & (MustPoint.Z == this.CoordsBuf[param1].Z))
                        {

                            this.MustPoint = new Point3(this.CoordsBuf[param2].X, this.CoordsBuf[param2].Y, this.CoordsBuf[param2].Z);
                        }
                        else if ((MustPoint.X == this.CoordsBuf[param2].X) & (MustPoint.Y == this.CoordsBuf[param2].Y) & (MustPoint.Z == this.CoordsBuf[param2].Z))
                        {
                            f_occupied = false;
                            if (this.OnCommandEnd != null)
                                this.OnCommandEnd(0, null);
                        }
                    };break;
            }
        }

        private StcCoords CoordsMust;
        public Point3 MustPoint {
            set {
                if (CoordsMust == null) CoordsMust = new StcCoords();
                CoordsMust.X.Dist = value.X;
                CoordsMust.Y.Dist = value.Y;
                CoordsMust.Z.Dist = value.Z;                
            }
            get {
                if (CoordsMust == null) return new Point3();
                return new Point3(Convert.ToInt32(Coords.X.Dist), Convert.ToInt32(Coords.Y.Dist), Convert.ToInt32(Coords.Z.Dist));
            }
        }

        private bool caret_mode = false;

        protected virtual void OnTimer()
        {
            if (active)
            {
                if ((CoordsMust.X.Dist != Coords.X.Dist) | (CoordsMust.Z.Dist != Coords.Z.Dist) | (CoordsMust.Y.Dist != Coords.Y.Dist))
                {
                    if (!caret_mode) // не в нужной z,y позиции - обнуляем
                    {
                        if (Coords.Y.Dist > 0) Coords.Y.Dist = Coords.Y.Dist - 1;
                        else if (Coords.Y.Dist < 0) Coords.Y.Dist = Coords.Y.Dist + 1;
                    }

                    if (Coords.Y.Dist == 0)
                    {
                        if (CoordsMust.X.Dist < Coords.X.Dist) Coords.X.Dist = Coords.X.Dist - 1;
                        else if (CoordsMust.X.Dist > Coords.X.Dist) Coords.X.Dist = Coords.X.Dist + 1;
                        if (CoordsMust.Z.Dist < Coords.Z.Dist) Coords.Z.Dist = Coords.Z.Dist - 1;
                        else if (CoordsMust.Z.Dist > Coords.Z.Dist) Coords.Z.Dist = Coords.Z.Dist + 1;
                    }

                    if ((CoordsMust.X.Dist == Coords.X.Dist) & (CoordsMust.Z.Dist == Coords.Z.Dist) & (CoordsMust.Y.Dist != Coords.Y.Dist))
                    {
                        caret_mode = true;
                        if (CoordsMust.Y.Dist < Coords.Y.Dist) Coords.Y.Dist = Coords.Y.Dist - 1;
                        else if (CoordsMust.Y.Dist > Coords.Y.Dist) Coords.Y.Dist = Coords.Y.Dist + 1;
                    }
                    if ((CoordsMust.X.Dist == Coords.X.Dist) & (CoordsMust.Z.Dist == Coords.Z.Dist) & (CoordsMust.Y.Dist == Coords.Y.Dist))
                        caret_mode = false;
                }
            }
        }

        [DisplayName("При изменении координат штабелера")]
        [Description("Событие, возникающее при изменении координат штабелера")]
        public event OnStackermanCoordChange OnCoordChange;

        [DisplayName("При завершении выполнения команды штабелера")]
        [Description("Событие, возникающее при завершении выполнения команды штабелера")]
        public event OnStackermanCommandEnd OnCommandEnd;

        [DisplayName("При программном исключении")]
        [Description("Событие, возникающее при программном исключении (не аварии штабелера)")]
        public event OnStackermanError OnError;

        [DisplayName("При ошибке выполнения команды штабелера")]
        [Description("Событие, возникающее при ошибке выполнения команды штабелера")]
        public event OnStackerAlarm OnAlarm;

        protected void ExeOnEndCmd(int cmd, object[] _params)
        {
            if (OnCommandEnd != null)
                OnCommandEnd(cmd, _params);
        }       

        private StcCoords Coords;
        private StcCoords OldCoords;

        protected virtual void WatchPosition()
        {
            Coords = GetCoords();
            if(!Coords.Equals(OldCoords))
                if (OnCoordChange!=null) 
                    OnCoordChange(Coords, OldCoords);
            OldCoords.Copy(Coords);
        }

        protected virtual StcCoords GetCoords()
        {            
            return Coords;
        }

        public bool Active {
            get {
                return WatchTimer.Enabled;
            }
            set {
                WatchTimer.Enabled = value;
            }
        }

        public virtual void Park()
        {
            command = "park";
            MustPoint = new Point3(0, 0, 0);
        }

        // Штабелер занят выполнением команды
        private bool f_occupied;
        public bool Occupied
        {
            get {
                return f_occupied;
            }
        }
        private int cmd;
        public void GenError(object obj, string str="")
        {
            if (str == "") str = obj.ToString();
            if (this.OnError != null) this.OnError(str);
        }

        private bool active = true;
        public virtual void Stop()
        {
            active = false;
        }
        
        public virtual void Resume()
        {
            active = true;
        }

        

        public virtual void Transmit(int cell1, int cell2)
        {
            command = "trans";
            param1 = cell1;
            param2 = cell2;
            MustPoint = new Point3(CoordsBuf[cell1].X,CoordsBuf[cell1].Y, CoordsBuf[cell1].Z);
            active = true;
            this.f_occupied = true;
        }
        // буфер координат
        private Dictionary<int,Point3> CoordsBuf;
        // Установить координаты ячейки
        public virtual void SetCellCoord(int numcell, Point3 coords)
        {
            if (CoordsBuf == null)
                CoordsBuf = new Dictionary<int, Point3>();
            if (CoordsBuf.ContainsKey(numcell))
                CoordsBuf[numcell] = coords;
            else
                CoordsBuf.Add(numcell, coords);

        }

        public virtual void SetCellCoord(int numcell, RealCellCoord RCC)
        {
            
        }

        public virtual void CellCheck(int numcell)
        { 
            
        }

        // Переместить
        public virtual void Trans(int numcell1, int numcell2)
        {
            
        }
    }
}
