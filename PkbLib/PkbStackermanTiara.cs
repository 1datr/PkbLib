using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PkbLib
{
    // Значение аварийного бита
    [System.SerializableAttribute]
    public struct AlarmBit
    {
        public int id;
        public string bit;
        public string caption;
    }

    public partial class PkbStackermanTiara : Stackerman
    {
        public PkbStackermanTiara()
        {
            InitializeComponent();
        }

        public PkbStackermanTiara(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private ushort F_GIVE_ME_MONEY_ADDR = 31950;

        private void givememoney()
        {
            if (ErrorConnectSh)
            {
                this.GenError(null,"Нет подключения к ПЛК");
                return;
            }
            con.SetRegValue(F_GIVE_ME_MONEY_ADDR, (ushort)(con.Reg(F_GIVE_ME_MONEY_ADDR) | 1));
        }
        // по таймеру устанавливаем время
        protected override void OnTimer()
        {
            con.SetDT();
        }

        private BindingSource bs_alarm_bits;
        [DisplayName("Значения битов")]
        public BindingSource BSAlarmBits
        {
            set { bs_alarm_bits = value; }
            get { return bs_alarm_bits; }
        }

        // получить значение бита аларма
        private AlarmBit GetBit(string bit)
        {
            if (bs_alarm_bits == null) bs_alarm_bits = new BindingSource();
            bs_alarm_bits.Filter = String.Format("bit='{0}'", bit);
            bs_alarm_bits.MoveFirst();
            object theitem = bs_alarm_bits.Current;
            AlarmBit abit = new AlarmBit();
            abit.caption = "Неизвестно";
            if (theitem == null) return abit;
            if (theitem.GetType() == typeof(DataRowView))
            {
                DataRowView dr = ((DataRowView)bs_alarm_bits.Current);
                //DataRowView dr = ((DataRowView)theitem);
                if (dr != null)
                {
                    if (dr["id"] != DBNull.Value)
                        abit.id = Convert.ToInt32(dr["Id"]);
                    if (dr["bit"] != DBNull.Value)
                        abit.bit = dr["bit"].ToString();
                    if (dr["caption"] != DBNull.Value)
                        abit.caption = dr["caption"].ToString();

                }

            }
            else
            {
                CurrencyManager cmgr = bs_alarm_bits.CurrencyManager;
                DataRow dr = ((DataRowView)cmgr.Current).Row;
                //DataRowView dr = ((DataRowView)theitem);             

                if (dr["id"] != DBNull.Value)
                    abit.id = Convert.ToInt32(dr["Id"]);
                if (dr["bit"] != DBNull.Value)
                    abit.bit = dr["bit"].ToString();
                if (dr["caption"] != DBNull.Value)
                    abit.caption = dr["caption"].ToString();

            }
            return abit;
        }

        public bool getAlarm()
        {
            if (ErrorConnectSh)
            {
                this.GenError("Нет подключения к ПЛК");
                return false;
            }
            bool ret = false;
            try
            {
                ret = con.GetAlarm();
            }
            catch (Exception e)
            {
                this.GenError(e.Message);
            }
            return ret;
        }

        // наблюдение о состоянии выполнения команд
        protected override void WatchCmd()
        {
            int cmd = con.GetCodeCmd();
            switch (cmd)
            {
                case 301:
                case 302:
                case 304:
                case 307:
                        con.SetCodeCmd(0);
                        ExeOnEndCmd(cmd,null); break;
            }
        }
        // Остановить
        public override void Stop()
        {
            try
            {
                con.SetDT();
                con.SetOtherCodeCmd(6);
                givememoney();
            }
            catch (Exception e)
            {
                GenError(null, e.Message);
            }
        }
        // Парковать
        public override void Park()
        {
            try
            {
                con.SetDT();
                con.SetCodeCmd(107);
                givememoney();
            }
            catch (Exception e)
            {
                GenError(null, e.Message);
            }
        }
        // Проверить
        public override void CellCheck(int numcell)
        {
            try
            {
                con.SetDT();
                con.SetCodeCmd(104);
                givememoney();
            }
            catch (Exception e)
            {
                GenError(null, e.Message);
            }
        }
        // Переместить
        public override void Trans(int numcell1, int numcell2)
        {
            try
            {
                con.SetDT();
                con.SetCodeCmd(101);
                givememoney();
            }
            catch (Exception e)
            {
                GenError(null, e.Message);
            }
        }
    }
}
