using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PkbLib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stackerman1.Active = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            stackerman1.MustPoint = new PkbLib.Point3(Convert.ToInt32(tbX.Text), Convert.ToInt32(tbY.Text), Convert.ToInt32(tbZ.Text));
        }

        private void stackerman1_OnCommandEnd(int cmd, object[] _params)
        {

        }

        private void stackerman1_OnCommandError(int cmd, object[] _params, string errstr)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pkbStacker1.stoped) pkbStacker1.Resume();
            else pkbStacker1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pkbStacker1.AddCommand("trans", Convert.ToInt32(tbCell1.Text), Convert.ToInt32(tbCell2.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pkbStacker1.AddCommand("park");
        }

        private void stackerman1_OnCoordChange(StcCoords Coords, StcCoords OldCoords)
        {
            label1.Text = Coords.X.Dist + ":" + Coords.Y.Dist + ":" + Coords.Z.Dist;
        }
    }
}
