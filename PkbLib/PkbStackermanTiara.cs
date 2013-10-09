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

        private bool lastalarm;
        private bool[,] oldalarms;
        protected override void WatchState()
        {
            bool[,] AlarmBits = con.HoldingRegs(drvCon.alarmAdr, drvCon.alarmAdr + drvCon.andAlarmAdr);
            Dictionary<string, object> dict = new Dictionary<string, object>();

            if (oldalarms == null)
            { 
                oldalarms = new bool[AlarmBits.GetLength(0),16];
            }

            bool matr_equal = true;
            for(int j=0;j<AlarmBits.GetLength(0);j++)
                for (int i = 0; i < AlarmBits.GetLength(1); i++)
                {
                    if (AlarmBits[j, i] != oldalarms[j, i]) matr_equal = false;
                }
            if( !matr_equal)
            {
                dict.Add("Alarms", this.AlarmMap());
    
            }
            if (dict.Count > 0)
                this.CallStateChange(dict);
            oldalarms = AlarmBits;
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

        public List<BitMapItem> AlarmMap()
        {
            List<BitMapItem> bmitems = new List<BitMapItem>();

            BitMapItem bmi = new BitMapItem();
            bool[,] AlarmBits = con.HoldingRegs(drvCon.alarmAdr, drvCon.alarmAdr + drvCon.andAlarmAdr);

            string[] BitGroupName = new string[] { "AlarmWithoutAcknowledgment", "AlarmWithAcknowledgment", "AlarmWithoutAcknowledgmentDeblock" };
            int bgindex = 0;
            for (int z = 0; z < 9; z++)
            {
                if ((z > 0) & (z % 3 == 0)) bgindex++;
                for (int bit = 0; bit < 16; bit++)
                {
                    bmi.bit = (ushort)bit;
                    bmi.value = AlarmBits[z,bit];
                    bmi.word = (ushort)(z + 1);
                    string bitstr = BitGroupName[bgindex] + "[" + ((z % 3) + 1).ToString() + "]." + bit.ToString();
                    AlarmBit abit = this.GetBit(bitstr);
                    bmi.caption = abit.caption;
                    bmitems.Add(bmi);
                }

            }
            return bmitems;
        }

        // информация о соединении и штабелере
        public override Dictionary<string, object> stateinfo()
        {
            Dictionary<string, object> info = new Dictionary<string, object>();
            info.Add("Alarm", con.GetAlarm());
            info.Add("Deblock Alarm", con.GetAlarmDeblock());
            info.Add("Tara", con.GetPresentTaraSh());
            bool[][] Din = con.GetDIn();
            info.Add("Din", Din);
            bool[,] AlarmBits = con.HoldingRegs(drvCon.alarmAdr, drvCon.alarmAdr + drvCon.andAlarmAdr);



            List<BitMapItem> bmitems = new List<BitMapItem>();

            BitMapItem bmi = new BitMapItem();

            if (AlarmBits != null)
            {/*
                for (ushort j = 0; j < captions.Length; j++)
                {
                    bmi.bit = bit;
                    bmi.caption = captions[j];
                    bmi.value = AlarmBits[z][bit];
                    bmi.word = (ushort)(z + 1);
                    bmitems.Add(bmi);
                    bit++;
                    bit %= 16;
                    if (bit == 0) z++;
                }*/
                string[] BitGroupName = new string[] { "AlarmWithoutAcknowledgment", "AlarmWithAcknowledgment", "AlarmWithoutAcknowledgmentDeblock" };
                int bgindex = 0;
                for (int z = 0; z < 9; z++)
                {
                    if ((z > 0) & (z % 3 == 0)) bgindex++;
                    for (int bit = 0; bit < 16; bit++)
                    {
                        bmi.bit = (ushort)bit;
                        bmi.value = AlarmBits[z,bit];
                        bmi.word = (ushort)(z + 1);
                        string bitstr = BitGroupName[bgindex] + "[" + ((z % 3) + 1).ToString() + "]." + bit.ToString();
                        AlarmBit abit = this.GetBit(bitstr);
                        bmi.caption = abit.caption;
                        bmitems.Add(bmi);
                    }

                }
            }
            info.Add("Alarm Bits", bmitems);
            return info;
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
                Kvit();
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
                Kvit();
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
                Kvit();
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
