using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PkbLib;

namespace Tiara
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pkbStackermanTiara1_OnError(string errstr)
        {
            tslStatus.ForeColor = Color.Red;
            tslStatus.Text = errstr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pkbStacker1.AddCommand("park");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pkbStacker1.Stop();
        }

        private List<BitMapItem> currbits = null;

        private void timer1_Tick(object sender, EventArgs e)
        {
          /*  if (currbits == null) currbits = new List<BitMapItem>();
            timer1.Enabled = false;
            Dictionary<string,object> info = this.pkbStackermanTiara1.stateinfo();

            List<BitMapItem> bmi_list = (List<BitMapItem>)info["Alarm Bits"];

            if (!bmi_list.SequenceEqual<BitMapItem>(this.currbits))
            {
                this.currbits = bmi_list;
                dgvAlarms.Rows.Clear();

                foreach (BitMapItem bmi in bmi_list)
                {
                    dgvAlarms.Rows.Add(bmi.word.ToString() + "." + bmi.bit.ToString(), bmi.value, bmi.caption);
                }
                // foreach(                dgvAlarms.Rows.Add()
            }
            timer1.Enabled = true;*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bdTiaraDataSet1.Coords". При необходимости она может быть перемещена или удалена.
            this.coordsTableAdapter.Fill(this.bdTiaraDataSet1.Coords);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bdTiaraDataSet.AlarmBits". При необходимости она может быть перемещена или удалена.
            this.alarmBitsTableAdapter.Fill(this.bdTiaraDataSet.AlarmBits);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pkbStackermanTiara1.Kvit();
        }

        private void pkbStackermanTiara1_OnAlarm(int cmd, object[] _params, string errstr)
        {
            DrawAlarms();
           
        }

        private void DrawAlarms()
        {
            Dictionary<string, object> info = this.pkbStackermanTiara1.stateinfo();

            List<BitMapItem> bmi_list = (List<BitMapItem>)info["Alarm Bits"];


            this.currbits = bmi_list;
            dgvAlarms.Rows.Clear();

            foreach (BitMapItem bmi in bmi_list)
            {
                dgvAlarms.Rows.Add(bmi.word.ToString() + "." + bmi.bit.ToString(), bmi.value, bmi.caption);
            }
            // foreach(                dgvAlarms.Rows.Add()
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DrawAlarms();
        }

        private void pkbStackermanTiara1_OnStateChange(object _params)
        {
            Dictionary<string,object> dic = (Dictionary<string,object>)_params;
            if (dic.ContainsKey("Alarms"))
            {
                List<BitMapItem> bmi_list = (List<BitMapItem>)dic["Alarms"];


                dgvAlarms.Rows.Clear();

                foreach (BitMapItem bmi in bmi_list)
                {
                    dgvAlarms.Rows.Add(bmi.word.ToString() + "." + bmi.bit.ToString(), bmi.value, bmi.caption);
                }
            }
        }

        

        
    }
}
