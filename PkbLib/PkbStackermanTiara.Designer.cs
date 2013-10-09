﻿using System.ComponentModel;
using System;

namespace PkbLib
{
    partial class PkbStackermanTiara
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

            con = new drvCon();
            if (ip_adr != "")
                if (con.Connect(ip_adr))
                {
                    this.Resume();
                }
                else
                {
                    this.ErrorConnectSh = true;
                    this.GenError(null, "Не удалось соединиться с ПЛК");
                }
        }

        private drvCon con;
        public bool ErrorConnectSh = true;
        public StdShCommand CurrCom;
        private bool flagAddCom;
        private bool permitSh;
        private string ip_adr = "";
        [DisplayName("IP адрес ПЛК")]
        [Description("IP-адрес ПЛК, управляющего производством.")]
        public string IpAdr
        {
            get
            {
                return ip_adr;
            }
            set
            {
                ip_adr = value;
                if (!this.DesignMode)
                {
                    con = new drvCon();

                    this.ErrorConnectSh = !con.Connect(ip_adr);
                    if (this.ErrorConnectSh)
                    {
                        this.ErrorConnectSh = true;
                        this.GenError(null,"Не удалось соединиться с ПЛК");
                    }
                    else
                    {

                        con.SetDT();
                        this.Resume();

                    }
                }
            }
        }

        public override bool Kvit(object kvitparams = null)
        {
            /*con.ResetErrPermitFuniTrans(1);
            con.ResetErrPermitFuniTrans(30160);*/
            if (ErrorConnectSh)
            {
                this.GenError("Нет подключения к ПЛК");
                return false;
            }
            con.SetDT();
            this.reset_alarms();
            return true;
        }

        private void reset_alarms()
        {
            try
            {
                con.SetDT();
                // reset
                for (ushort i = drvCon.alarmAdr/*31942*/; i <= /*31942*/drvCon.alarmAdr + drvCon.andAlarmAdr; i++)
                    con.ResetErrPermitFuniTrans(i);
                con.ResetErrPermitFuniTrans(F_GIVE_ME_MONEY_ADDR);
                con.SetOtherCodeCmd((ushort)5);
                con.SetCodeCmd((ushort)5);
            }
            catch (Exception e)
            {
                this.GenError(e.Message);
            }
        }

        #endregion
    }
}
