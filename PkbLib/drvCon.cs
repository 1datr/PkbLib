using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Net.NetworkInformation;
using System.ComponentModel;
using Modbus.Device;


namespace PkbLib
{

      
    class AddrFieldConverter : ExpandableObjectConverter
    {
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
        {
            return new AddrField((ushort)propertyValues["Addr"], (ushort)propertyValues["WordCount"], (ushort)propertyValues["Bit"]);
        }
    }

    [System.SerializableAttribute]
    [TypeConverter(typeof(AddrFieldConverter))]
    public class AddrField
    {
        public AddrField(ushort addr = 0, ushort count = 1, ushort bit = 0)
        {
            this.Addr = addr;
            this.WordCount = count;
            this.Bit = bit;
        }
        public ushort Addr;
        public ushort WordCount;
        public ushort Bit;
    }

    public class drvCon
    {
       // public AddrMap addr_map; // карта адресов
        private ModbusIpMaster master;
        private TcpClient client;

        private Stackerman Parent;

        // Константы
        public static ushort alarmAdr = 31938, andAlarmAdr = 9;
        private static ushort alarmDeblockAdr = 31944, andAlarmDeblockAdr = 1;
        // текущая команда
        private static ushort codeCmdAdr = 32280/*31796*/, andCodeCmdAdr = 1;
        // следующая команда
        private static ushort codeOtherCmdAdr = 31780, andOtherCodeCmdAdr = 1;
        // адрес ячейки загрузки
        private static ushort cellLoadAdr = 30018, andcellLoadAdr = 1;

        private static ushort cellUploadAdr = 30019, andcellUploadAdr = 1;
        // оси
        private static ushort axisAdr = 31947, andAxisAdr = 3;
        // область энкодера
        private static ushort encoderAdr = 31896, andEncoderAdr = 54;
        // область дискретных входов
        public static ushort DInAdr = 31800/* 30020*/, andDInAdr = 96;//andDInAdr = 64;

        private static ushort RackAdr = 30017, andRackAdr = 1;

        public static ushort datetime_Addr = 31788;
        // ядрес ячейки с координатами
        private static int coordCellAdr = 15000, andCoordCellAdr = 41;

        public struct FT
        {
            public int nStartTrans;
            public int nAndSh;
            public int idTrans;
            public int resetTrans;
            public int blockTrans;
            public int error1;
            public int error2;
            public int error3;
            public int error4;
            public int error5;
            public int error6;
            public int state;
            public int lowMotion;
            public int positionTrans;
            public int item07;
            public int item08;
            public int item09;
            public int item10;
            public int item11;
            public int item12;
            public int modeWork;
            public int errorTrans;
            public int pallet;
            public int productId;
            public int productNamber;
            public int pathFrom;
            public int pathTo;
            public int reserv;
        }
        public struct RC
        {
            public int nStartTrans;
            public int nAndSh;
            public int idTrans;
            public int resetTrans;
            public int blockTrans;
            public int error1;
            public int error2;
            public int error3;
            public int state;
            public int lowMotion;
            public int item09;
            public int item11;
            public int item12;
            public int modeWork;
            public int errorTrans;
            public int pallet;
            public int productId;
            public int productNamber;
            public int pathFrom;
            public int pathTo;
            public int reserv;
        }

        public drvCon(Stackerman shman=null)
        {

            this.Parent = shman;
        }

        private string error_str;
        public string Error {
            get { return error_str; }
        }
        private void setError(string str="")
        {
            if(this.Parent!=null)
            {
                this.Parent.GenError(this,str);
            }
           /* if (MainForm == null) return;
            
            if (MainForm.Name == "fSh1")
            { this.MainForm.ErrorConnectSh1 = true; }
            else if (MainForm.Name == "fSh2")
            { this.MainForm.ErrorConnectSh2 = true; }
            else if (MainForm.Name == "fSh3")
            { this.MainForm.ErrorConnectSh3 = true; }
            else if (MainForm.Name == "fSh4")
            { this.MainForm.ErrorConnectSh4 = true; }
            else if (MainForm.Name == "fSh5")
            { this.MainForm.ErrorConnectSh5 = true; }
            else if (MainForm.Name == "fLoadTrans")
            { this.MainForm.ErrorConnectLoadTrans = true; }
            else if (MainForm.Name == "fUnloadTrans")
            { this.MainForm.ErrorConnectUnloadTrans = true; }*/
        }

        private void resetError()
        {
            this.error_str = "";
           /* if (MainForm == null) return;

            if (MainForm.Name == "fSh1")
            { this.MainForm.ErrorConnectSh1 = false; 
            }
            else if (MainForm.Name == "fSh2")
            { this.MainForm.ErrorConnectSh2 = false; }
            else if (MainForm.Name == "fSh3")
            { this.MainForm.ErrorConnectSh3 = false; }
            else if (MainForm.Name == "fSh4")
            { this.MainForm.ErrorConnectSh4 = false; }
            else if (MainForm.Name == "fSh5")
            { this.MainForm.ErrorConnectSh5 = false; }
            else if (MainForm.Name == "fLoadTrans")
            { this.MainForm.ErrorConnectLoadTrans = false; }
            else if (MainForm.Name == "fUnloadTrans")
            { this.MainForm.ErrorConnectUnloadTrans = false; }*/

        }
        
        public bool Connect(string ipAdr)
        {
            bool ret = false;
            try
            {
                Ping png = new Ping();
                PingReply retPng = png.Send(ipAdr, 300);
                if (retPng.Status == IPStatus.Success)
                {//client = new TcpClient(ipAdr, 502);
                    client = new TcpClient();
                    client.SendTimeout = 1000;
                    client.ReceiveTimeout = 1000;                    
                    client.Connect(ipAdr, 502);
                    client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

                    master = ModbusIpMaster.CreateIp(client);

                    resetError();
                    ret = true;
                }
                else
                {
                    ret = false;
                    this.error_str = "Connection error";
                }
            }
            catch (Exception e)
            {
                this.error_str = e.Message;
                setError();
            }
            finally
            {}
            return ret;
        }

        public bool Disconnect(string ipAdr)
        {
            try
            {                
            }
            catch (Exception e)
            {
            }

            return true;
        }

        public ushort Reg(ushort addr)
        {
            ushort[] tempUSmas = null;
            try
            {
                tempUSmas = master.ReadHoldingRegisters((ushort)(addr), (ushort)(1));
                
            }
            catch (Exception e)
            {
                this.error_str = e.Message;
                setError();
            }
            finally
            {}
            return tempUSmas[0];
        }

        public bool SetRegValue(ushort addr, ushort value)
        {
            bool ret = true;
            try
            {
                master.WriteSingleRegister(addr, value);
            }
            catch (Exception e)
            {
                ret = false;
                MessageBox.Show(e.InnerException.Message);
            }
            finally
            { }
            return ret;
        }


        // Событие при ошибке        
        // public event EventOnDrvError OnError;

        //Получить аварии штабелера
        int index = 0;
        static int sizeMas = 9*16;
        public bool[] AlarmMsg = new bool[sizeMas];
        
        public bool GetAlarm()
        {
            bool[] tempBoolMas = new bool[16];
            bool ret = false;

            try
            {
                ushort[] tempUSmas = master.ReadHoldingRegisters(alarmAdr, andAlarmAdr);

                foreach (ushort item in tempUSmas)
                {
                    tempBoolMas = this.toMasBool(item);
                    foreach (bool bit in tempBoolMas)
                    {
                        if (bit == true) ret = true;
                        AlarmMsg[index] = bit;
                        index++;
                    }
                }
            }
            catch
            {
                this.error_str = "Ошибка произошла при получении аварии штабелера.";
                setError();
                AlarmMsg = null;
                //MessageBox.Show("Ошибка произошла при получении аварии штабелера.");
            }
            finally
            {
                index = 0;
            }
            return ret;
        }

       

        //Получить аварии деблокировка
        static int sizeMasDeblock = 16;
        public bool[] AlarmDeblockMsg = new bool[sizeMasDeblock];
        
        public bool GetAlarmDeblock()
        {
            bool[] tempBoolMas = new bool[16];
            bool ret = false;

            try
            {
                ushort[] tempUSmas = master.ReadHoldingRegisters(alarmDeblockAdr, andAlarmDeblockAdr);

                foreach (ushort item in tempUSmas)
                {
                    tempBoolMas = this.toMasBool(item);
                    foreach (bool bit in tempBoolMas)
                    {
                        //if (bit == true)
                        ret |= bit;
                        AlarmDeblockMsg[index] = bit;
                        index++;
                    }
                }
            }
            catch
            {
                this.error_str = "Ошибка произошла при получении аварии штабелера.";
                setError();
                AlarmDeblockMsg = null;
                //MessageBox.Show("Ошибка произошла при получении аварии штабелера.");
            }
            finally
            {
                index = 0;
            }
            return ret;
        }

        //Получить код выполняемой команды
        
        public int GetCodeCmd()
        {
            int ret = -1;
            try
            {
                ushort[] tempUSmas = master.ReadHoldingRegisters(codeCmdAdr, andCodeCmdAdr);
                ret = (int)tempUSmas[0];
            }
            catch
            {
                this.error_str = "Ошибка произошла при получении кода выполняемой команды.";
                setError();
                //MessageBox.Show("Ошибка произошла при получении кода выполняемой команды.");
            }
            finally 
            { }
            return ret;
        }

        //Установить код выполняемой команды 
        public bool SetCodeCmd(ushort value)
        {
            bool ret = false;
            try
            {                
                master.WriteSingleRegister(codeCmdAdr, value);
                ret = true;
            }
            catch
            {
                this.error_str = "Ошибка произошла при попытке записи кода выполняемой команды.";
                setError();
                //MessageBox.Show("Ошибка произошла при попытке записи кода выполняемой команды.");                
            }
            finally
            { }
            return ret;
        }
        //---------------------------------------

        //Получить код другой команды
        
        public int GetOtherCodeCmd()
        {
            int ret = -1;
            try
            {
                ushort[] tempUSmas = master.ReadHoldingRegisters(codeOtherCmdAdr, andOtherCodeCmdAdr);
                ret = (int)tempUSmas[0];
            }
            catch
            {
                this.error_str = "Ошибка произошла при получении другого кода выполняемой команды.";
                setError();
                //MessageBox.Show("Ошибка произошла при получении другого кода выполняемой команды.");
            }
            finally
            { }
            return ret;
        }

        //Установить код другой выполняемой команды 
        public bool SetOtherCodeCmd(ushort value)
        {
            bool ret = false;
            try
            {
                master.WriteSingleRegister(codeOtherCmdAdr, value);
                ret = true;
            }
            catch
            {
                this.error_str = "Ошибка произошла при попытке записи кода другой выполняемой команды.";
                setError();
                //MessageBox.Show("Ошибка произошла при попытке записи кода другой выполняемой команды.");
            }
            finally
            { }
            return ret;
        }
        //---------------------------------------


        //Получить номер ячейки откуда берем паллет
        
        public int GetCellUnload()
        {
            int ret = -1;
            try
            {
                ushort[] tempUSmas = master.ReadHoldingRegisters(cellUploadAdr, andcellUploadAdr);
                ret = (int)tempUSmas[0];
            }
            catch
            {
                this.error_str = "Ошибка произошла при получении номера ячейки откуда берем паллет.";
                setError();
                //MessageBox.Show("Ошибка произошла при получении номера ячейки откуда берем паллет.");
            }
            finally
            { }
            return ret;
        }

        //Установить ячейку откуда взять паллет        
        public bool SetCellUnload(ushort value)
        {
            bool ret = false;
            try
            {
                master.WriteSingleRegister(cellUploadAdr, value);
                ret = true;
            }
            catch
            {
                this.error_str = "Ошибка произошла при попытке записи номера ячейки откуда берем паллет";
                setError();
                //MessageBox.Show("Ошибка произошла при попытке записи номера ячейки откуда берем паллет");
            }
            finally
            { }
            return ret;
        }
        //--------------------------------------------------

        //Получить номер ячейки для выгрузки паллета
        
        public int GetCellLoad()
        {
            int ret = -1;
            try
            {
                ushort[] tempUSmas = master.ReadHoldingRegisters(cellLoadAdr, andcellLoadAdr);
                ret = (int)tempUSmas[0];
            }
            catch
            {
                this.error_str = "Ошибка произошла при получении номера ячейки для выгрузки паллета.";
                setError();
                //MessageBox.Show("Ошибка произошла при получении номера ячейки для выгрузки паллета.");
            }
            finally
            { }
            return ret;
        }

        //Установить ячейку для выгрузки паллета        
        public bool SetCellLoad(ushort value)
        {
            bool ret = false;
            try
            {
                master.WriteSingleRegister(cellLoadAdr, value);
                ret = true;
            }
            catch
            {
                this.error_str = "Ошибка произошла при попытке записи номера ячейки для выгрузки паллета";
                setError();
                //MessageBox.Show("Ошибка произошла при попытке записи номера ячейки для выгрузки паллета");
            }
            finally
            { }
            return ret;
        }
        //--------------------------------------------------

        //Получить сторону стелажа для разгрузки Arr[0] склада и загрузки Arr[1]
        //1-левая сторона, 2-правая сторона
        
        public int [] GetSideRack()
        {
            int ret = -1;
            try
            {
                ushort[] tempUSmas = master.ReadHoldingRegisters(RackAdr, andRackAdr);
                ret = (int)tempUSmas[0];
            }
            catch
            {
                this.error_str = "Ошибка произошла при получении сторон для ячеек разгрузки/загрузки склада.";
                setError();
                //MessageBox.Show("Ошибка произошла при получении сторон для ячеек разгрузки/загрузки склада.");
                return null;
            }
            finally
            { }
            
            return ushortToTwoInt((ushort)ret);
        }

        //Установить сторону стелажа для разгрузки Arr[0] склада и загрузки Arr[1]   
        public bool SetSideRack(int rackUnload, int rackLoad)
        {            
            bool ret = false;
            try
            {
                master.WriteSingleRegister(RackAdr, twoIntToUshort(rackUnload, rackLoad));
                ret = true;
            }
            catch
            {
                this.error_str = "Ошибка произошла при записи сторон для ячеек разгрузки/загрузки склада.";
                setError();
                //MessageBox.Show("Ошибка произошла при записи сторон для ячеек разгрузки/загрузки склада.");
            }
            finally
            { }
            return ret;
        }
        //--------------------------------------------------
        
        private ushort[] dt = new ushort[7];
        //Установить ДТ
        public bool SetDT()
        {
            bool ret = false;
            try
            {
                dt[0] = ushort.Parse(System.DateTime.Now.Year.ToString());
                dt[1] = ushort.Parse(System.DateTime.Now.Month.ToString());
                dt[2] = ushort.Parse(System.DateTime.Now.Day.ToString());
                dt[3] = ushort.Parse(System.DateTime.Now.Hour.ToString());
                dt[4] = ushort.Parse(System.DateTime.Now.Minute.ToString());
                dt[5] = ushort.Parse(System.DateTime.Now.Second.ToString());
                dt[6] = (ushort)System.DateTime.Now.DayOfWeek;
                master.WriteMultipleRegisters(datetime_Addr, dt);

                ret = true;
            }
            catch
            {
                this.error_str = "Ошибка произошла при записи даты и время.";
                setError();
                //MessageBox.Show("Ошибка произошла при записи даты и время.");
            }
            finally
            { }
            return ret;
        }


        //Получить признак наличия тары
        public bool GetPresentTaraSh()
        {
            bool[][] din = GetDIn();
            if (din == null)
                return false;
            else
                return din[11][0];
        }
        
        //Получить дискретные входа, (выхода?)
        //11.0 - Наличие тары
        
        public bool[][] GetDIn()
        {
            bool[][] ret = new bool[96][];
            
            try
            {
                //ushort[] tempUSmas = master.ReadHoldingRegisters(this.addr_map.DiscrIO.Addr, this.addr_map.DiscrIO.WordCount );
                ushort[] tempUSmas = master.ReadHoldingRegisters(drvCon.DInAdr, drvCon.andDInAdr);
                for (int i = 0; i < andDInAdr; i++)
                {
                    ret[i]=toMasBool(tempUSmas[i]);
                }
            }
            catch
            {
                this.error_str = "Ошибка произошла при получении сторон для ячеек разгрузки/загрузки склада.";
                setError();
                ret = null;
                //MessageBox.Show("Ошибка произошла при получении сторон для ячеек разгрузки/загрузки склада.");
            }
            finally
            { }

            return ret;
        }

        public bool[][] GetBitMap(ushort AddrBegin, ushort Count)
        {
            bool[][] ret = new bool[Count][];

            try
            {
                ushort[] tempUSmas = master.ReadHoldingRegisters(AddrBegin, Count);
                for (int i = 0; i < Count; i++)
                {
                    ret[i] = toMasBool(tempUSmas[i]);
                }
            }
            catch
            {
                this.error_str = "Ошибка произошла при получении сторон для ячеек разгрузки/загрузки склада.";
                setError();
                ret = null;
                //MessageBox.Show("Ошибка произошла при получении сторон для ячеек разгрузки/загрузки склада.");
            }
            finally
            { }

            return ret;
        }

        //Получить координаты ячейки
        
        public int[] GetCoordCell(int numCell, int Rack)
        {
            int tmpCoordCellAdr;
            ushort temp;
            int[] ret = new int[21];

            try
            {
                if (numCell > 168 && numCell <= 336)
                {
                    tmpCoordCellAdr = (coordCellAdr + 30) + (andCoordCellAdr + 1) * 3;
                    temp = ushort.Parse((tmpCoordCellAdr + (numCell - 1) * (andCoordCellAdr + 1)).ToString());
                }
                //Ячейка загрузки склада
                else if (numCell == 337)
                {
                    if (Rack == 2)
                        temp = 29268;
                    else
                        temp = 22056;
                }
                //Ячейка разгрузки склада
                else if (numCell == 338)
                {
                    if (Rack == 2)
                        temp = 29310;
                    else
                        temp = 22098;
                }
                else
                {
                    tmpCoordCellAdr = coordCellAdr;
                    temp = ushort.Parse((tmpCoordCellAdr + (numCell - 1) * (andCoordCellAdr + 1)).ToString());
                }
                
                ushort[] tempUSmas = master.ReadHoldingRegisters(temp, (ushort)andCoordCellAdr);

                for (int i = 0; i < andCoordCellAdr; i++)
                {
                    ushort[] tmpArray = new ushort[2];
                    tmpArray[0] = tempUSmas[i];
                    if (i != andCoordCellAdr - 1)
                        tmpArray[1] = tempUSmas[i + 1];
                    else
                        tmpArray[1] = 0;
                    ret[i / 2] = twoUshortToInt(tmpArray);
                    i++;
                }
            }
            catch
            {
                this.error_str = "Ошибка произошла при получениикоординат ячейки.";
                setError();
                ret = null;
                //MessageBox.Show("Ошибка произошла при получениикоординат ячейки.");
            }
            finally
            { }
            return ret;
        }

        //Записать координаты ячейки         
        public bool SetCoordCell(int numCell, int[] arrayInt, int Rack)
        {
            bool ret = false;
            int lenArray= arrayInt.Length;
            int tmpCoordCellAdr;
            ushort startAdress;

            try
            {
                if (numCell > 168 && numCell <= 336)
                {
                    tmpCoordCellAdr = (coordCellAdr + 30) + (andCoordCellAdr + 1) * 3;
                    switch (lenArray)
                    {
                        case 4: break;
                        case 10: tmpCoordCellAdr = tmpCoordCellAdr + 16; break;
                        case 2: tmpCoordCellAdr = tmpCoordCellAdr + 36; break;
                    }
                    startAdress = ushort.Parse((tmpCoordCellAdr + (numCell - 1) * (andCoordCellAdr + 1)).ToString());
                }
                //Ячейка загрузки склада
                else if (numCell == 337)
                {
                    if (Rack == 2)
                        startAdress = 29268;
                    else
                        startAdress = 22056;
                    switch (lenArray)
                    {
                        case 4: break;
                        case 10: startAdress += 16; break;
                        case 2: startAdress += 36; break;
                    }
                }
                //Ячейка разгрузки склада
                else if (numCell == 338)
                {
                    if (Rack == 2)
                        startAdress = 29310;
                    else
                        startAdress = 22098;
                    switch (lenArray)
                    {
                        case 4: break;
                        case 10: startAdress += 16; break;
                        case 2: startAdress += 36; break;
                    }
                }
                else
                {
                    tmpCoordCellAdr = coordCellAdr;
                    switch (lenArray)
                    {
                        case 4: break;
                        case 10: tmpCoordCellAdr = tmpCoordCellAdr + 16; break;
                        case 2: tmpCoordCellAdr = tmpCoordCellAdr + 36; break;
                    }
                    startAdress = ushort.Parse((tmpCoordCellAdr + (numCell - 1) * (andCoordCellAdr + 1)).ToString());
                }



                ushort[] coordArray = new ushort[lenArray * 2];

                for (int i = 0, j = 0; i < lenArray; i++, j = j + 2)
                {
                    ushort[] temp = intToTwoUshort(arrayInt[i]);

                    coordArray[j] = temp[0];
                    coordArray[j + 1] = temp[1];

                }

                master.WriteMultipleRegisters(startAdress, coordArray);

                ret = true;
            }
            catch
            {
                this.error_str = "Ошибка произошла при записи координат ячейки.";
                setError();
                //MessageBox.Show("Ошибка произошла при записи координат ячейки.");
            }
            finally
            { }
            return ret;
        }


        //Получить информацию о энкодерах
        
        public string[] GetEncoderInfo()
        {
            string[] str = new string[16];

            try
            {
                ushort[] tempUSmas = master.ReadHoldingRegisters(drvCon.encoderAdr, drvCon.andEncoderAdr);

                //Значение энкодера по Y
                ushort[] temp = new ushort[] { tempUSmas[0], tempUSmas[1] };
                str[0] = twoUshortToInt(temp).ToString();
                //Пройденная дестанция по Y
                temp = new ushort[] { tempUSmas[10], tempUSmas[11] };
                str[1] = twoUshortToFloat(temp).ToString();
                //Скорость по Y
                temp = new ushort[] { tempUSmas[12], tempUSmas[13] };
                str[2] = twoUshortToFloat(temp).ToString();

                //Значение энкодера по X
                temp = new ushort[] { tempUSmas[14], tempUSmas[15] };
                str[5] = twoUshortToInt(temp).ToString();
                //Пройденная дестанция по X
                temp = new ushort[] { tempUSmas[24], tempUSmas[25] };
                str[6] = twoUshortToFloat(temp).ToString();
                //Скорость по X
                temp = new ushort[] { tempUSmas[26], tempUSmas[27] };
                str[7] = twoUshortToFloat(temp).ToString();

                //Значение энкодера по Z
                temp = new ushort[] { tempUSmas[28], tempUSmas[29] };
                str[10] = twoUshortToInt(temp).ToString();
                //Пройденная дестанция по Z
                temp = new ushort[] { tempUSmas[34], tempUSmas[35] };
                str[11] = twoUshortToFloat(temp).ToString();
                //Скорость по Z
                temp = new ushort[] { tempUSmas[36], tempUSmas[37] };
                str[12] = twoUshortToFloat(temp).ToString();
            }
            catch
            {
                this.error_str = "Ошибка произошла при получении информации о энкодерах.";
                setError();
                str = null;
                //MessageBox.Show("Ошибка произошла при получении информации о энкодерах.");
            }
            finally
            { }
            return str;
        }

        public bool[,] HoldingRegs(int byte1, int byte2, int offset = 0)
        {
            bool[,] ret = new bool[byte2 - byte1 + 1,16];
            if (offset > 0) offset = DInAdr;
            try
            {
                ushort[] tempUSmas = master.ReadHoldingRegisters((ushort)(byte1 + offset), (ushort)(byte2 - byte1 + 1));
                for (int j = 0; j <= (byte2 - byte1); j++)
                {
                    for(int i=0; i<16; i++)
                        ret[j,i] = toMasBool(tempUSmas[j])[i];
                }
            }
            catch
            {
                this.setError("Ошибка произошла при получении байтовой карты.");
                ret = null;
                //MessageBox.Show("Ошибка произошла при получении байтовой карты.");*/
            }
            finally
            { }

            return ret;
        }

        //Получить информацию о 
        
        public int[] GetAxisInfo()
        {
            int [] rez = new int[3];

            try
            {
                ushort[] tempUSmas = master.ReadHoldingRegisters(axisAdr, andAxisAdr);

                rez[0] = int.Parse(tempUSmas[0].ToString());
                rez[1] = int.Parse(tempUSmas[0].ToString());
                rez[2] = int.Parse(tempUSmas[0].ToString());
            }
            catch
            {
                this.error_str = "Ошибка произошла при получении информации о .";
                setError();
                rez = null;
                //MessageBox.Show("Ошибка произошла при получении информации о .");
            }
            finally
            { }
            return rez;       
        }


        //Получение информации о цепных транспортерах
        private static ushort funiculerTransCntrAdr = 2701, andFuniculerTransAdr = 30;
        private static ushort funiculerTransInfoAdr = 4101, andFuniculerTransInfoAdr = 50;
        public FT [] GetInfoFuniTrans()
        {
            FT[] rezArray = new FT[10];

            try
            {
                ushort[] tempUSmas1 = master.ReadHoldingRegisters(funiculerTransCntrAdr, andFuniculerTransAdr);
                ushort[] tempUSmas2 = master.ReadHoldingRegisters(funiculerTransInfoAdr, andFuniculerTransInfoAdr);
                ushort[] rez = new ushort[andFuniculerTransAdr + andFuniculerTransInfoAdr];

                for (int i = 0; i < andFuniculerTransAdr + andFuniculerTransInfoAdr; i++)
                {
                    if (i < andFuniculerTransAdr)
                        rez[i] = tempUSmas1[i];
                    else
                        rez[i] = tempUSmas2[i - andFuniculerTransAdr];
                }

                for (int i = 0; i < rezArray.Length; i++)
                {
                    //Регистр управления
                    rezArray[i].nStartTrans = rez[0 + i] & 7;       //Номер отправного ЦТ
                    rezArray[i].nAndSh = rez[0 + i] >> 3 & 7;       //Номер приемочного СШ
                    rezArray[i].idTrans = rez[0 + i] >> 6 & 15;     //ИД транспортера
                    rezArray[i].resetTrans = rez[0 + i] >> 15 & 1;  //Сброс параметров маршрута для транспортера
                    rezArray[i].blockTrans = rez[0 + i] >> 16 & 1;  //Блокировка

                    //Регистр неисправностей ЦТ
                    rezArray[i].error1 = rez[10 + i] & 1;           //Сигнал с аварийных контактов автоматов SF1 - SF3
                    rezArray[i].error2 = rez[10 + i] >> 1 & 1;      //Сработал таймер контроля хода вверх
                    rezArray[i].error3 = rez[10 + i] >> 2 & 1;      //Сработал таймер контроля хода вниз
                    rezArray[i].error4 = rez[10 + i] >> 3 & 1;      //Сработал таймер контроля хода вперед
                    rezArray[i].error5 = rez[10 + i] >> 4 & 1;      //Негабаритный груз BS1 - BS2
                    rezArray[i].error6 = rez[10 + i] >> 5 & 1;      //Негабаритный груз BS2 - BS3

                    //Регистр состояния ЦТ
                    rezArray[i].state = rez[20 + i] & 7;                //Состояние движение транспортера (0-покоится, 1-ходвверх, 2-ход вниз, 3-вращение вперед)
                    rezArray[i].lowMotion = rez[20 + i] >> 3 & 1;       //Движение с медленной скоростью
                    rezArray[i].positionTrans = rez[21 + i] >> 4 & 3;   //Положение транспортера (0-Неопределено, 1-вверху, 2-внизу)
                    rezArray[i].item07 = rez[20 + i] >> 7 & 1;          //Разрешение на переправку на ПП
                    rezArray[i].item08 = rez[20 + i] >> 8 & 1;          //Транспортер свободен для отправки на ПП
                    rezArray[i].item09 = rez[20 + i] >> 9 & 1;          //Транспортер свободен для отправки по маршруту
                    rezArray[i].item10 = rez[20 + i] >> 10 & 1;         //Разрешение на работу (к штабелеру)
                    rezArray[i].item11 = rez[20 + i] >> 11 & 1;         //Разрешение на работу со смежным транспортером
                    rezArray[i].item12 = rez[20 + i] >> 12 & 1;         //Разрешение на работу от штабелера
                    rezArray[i].modeWork = rez[20 + i] >> 13 & 1;       //Режим работы авто
                    rezArray[i].errorTrans = rez[20 + i] >> 14 & 1;     //Неисправность
                    rezArray[i].pallet = rez[20 + i] >> 15 & 1;         //Наличие паллеты

                    //Информация по Паллету на ЦТ
                    rezArray[i].productId = (int)rez[30 + i * 5];       //ИД продукта
                    rezArray[i].productNamber = (int)rez[31 + i * 5];   //Колличество продукта на паллете
                    rezArray[i].pathFrom = (int)rez[32 + i * 5];        //Отправная точка паллеты
                    rezArray[i].pathTo = (int)rez[33 + i * 5];          //Точка прибытия паллеты
                    rezArray[i].reserv = (int)rez[34 + i * 5];          //Резерв паллеты
                }
            }
            catch
            {
                this.error_str = "Ошибка произошла при получении информации о цепных транспортерах.";
                setError();
                rezArray = null;
                //MessageBox.Show("Ошибка произошла при получении информации о цепных транспортерах.");
            }
            finally
            { }
            return rezArray;
        }

        public bool SetPermitFuniTrans(ushort adr, int permit)
        {
            bool ret = false;

            try
            {
                ushort[] tempUSmas = master.ReadHoldingRegisters(adr, 1);
                int tmp;

                if (permit == 1)
                {
                    tmp = permit << 12;
                    tempUSmas[0] = (ushort)((int)tempUSmas[0] | tmp);
                }
                else if (permit == 0)
                {
                    tmp = 61439;
                    tempUSmas[0] = (ushort)((int)tempUSmas[0] & tmp);
                }

                master.WriteMultipleRegisters(adr, tempUSmas);
                
                ret = true;
            }
            catch
            {
                this.error_str = "Ошибка произошла при записи разрешения цепному транспортеру переместить паллет в ячейку загрузки склада.";
                setError();
                //MessageBox.Show("Ошибка произошла при записи разрешения цепному транспортеру переместить паллет в ячейку загрузки склада.");
            }

            return ret;
        }

        public bool ResetErrPermitFuniTrans(ushort adr)
        {
            bool ret = false;
            try
            {
                master.WriteSingleRegister(adr, 0);

                ret = true;
            }
            catch
            {
                this.error_str = "Ошибка произошла при записи разрешения цепному транспортеру переместить паллет в ячейку загрузки склада.";
                setError();
                //MessageBox.Show("Ошибка произошла при записи разрешения цепному транспортеру переместить паллет в ячейку загрузки склада.");
            }

            return ret;
        }

        public bool SetPathFuniTrans(ushort adr, int nSh)
        {
            bool ret = false;

            try
            {
                ushort[] value = new ushort[] { (ushort)nSh };
                master.WriteMultipleRegisters(adr, value);

                ret = true;
            }
            catch
            {
                this.error_str = "Ошибка произошла при записи пути цепному транспортеру при отправки паллета.";
                setError();
                //MessageBox.Show("Ошибка произошла при записи пути цепному транспортеру при отправки паллета.");
            }
            return ret;
        }

        ////Получение информации о роликовых конвейеров загрузочной транспортной линии
        //private static ushort rollerConveyorCntrAdr = 2801, andRollerConveyorCntrAdr = 46;
        //private static ushort rollerConveyorInfoAdr = 4151, andRollerConveyorInfoAdr = 75;
        //public RC[] GetInfoRolConveyor()
        //{             
        //    RC[] rezArray = new RC[15];

        //    try
        //    {
        //        ushort[] tempUSmas1 = master.ReadHoldingRegisters(rollerConveyorCntrAdr, andRollerConveyorCntrAdr);
        //        ushort[] tempUSmas2 = master.ReadHoldingRegisters(rollerConveyorInfoAdr, andRollerConveyorInfoAdr);
        //        ushort[] rez = new ushort[andRollerConveyorCntrAdr + andRollerConveyorInfoAdr];


        //        for (int i = 0; i < andRollerConveyorCntrAdr + andRollerConveyorInfoAdr; i++)
        //        {
        //            if (i < andRollerConveyorCntrAdr)
        //                rez[i] = tempUSmas1[i];
        //            else
        //                rez[i] = tempUSmas2[i - andRollerConveyorCntrAdr];
        //        }

        //        for (int i = 0; i < rezArray.Length; i++)
        //        {
        //            //Регистр управления
        //            rezArray[i].nStartTrans = rez[0 + i] & 7;       //Номер отправного РК
        //            rezArray[i].nAndSh = rez[0 + i] >> 3 & 7;       //Номер приемочного СШ
        //            rezArray[i].idTrans = rez[0 + i] >> 6 & 15;     //ИД транспортера
        //            rezArray[i].resetTrans = rez[0 + i] >> 14 & 1;  //Сброс параметров маршрута для транспортера
        //            rezArray[i].blockTrans = rez[0 + i] >> 15 & 1;  //Блокировка

        //            //Регистр неисправностей РК
        //            rezArray[i].error1 = rez[15 + i] & 1;           //Сигнал с аварийных контактов автоматов SF1 - SF3
        //            rezArray[i].error2 = rez[15 + i] >> 1 & 1;      //Сработал таймер контроля хода вперед
        //            rezArray[i].error3 = rez[15 + i] >> 2 & 1;      //Сработал таймер контроля хода назад

        //            //Регистр состояния РК
        //            rezArray[i].state = rez[30 + i] & 7;                //Состояние движение транспортера (0-покоится, 3-вращение вперед, 4-вращение назад)
        //            rezArray[i].lowMotion = rez[30 + i] >> 3 & 1;       //Движение с медленной скоростью
        //            rezArray[i].item09 = rez[30 + i] >> 9 & 1;          //Транспортер свободен для отправки по маршруту
        //            rezArray[i].item11 = rez[30 + i] >> 11 & 1;         //Разрешение на вращение вперед
        //            rezArray[i].item12 = rez[30 + i] >> 12 & 1;         //Разрешение на вращение назад
        //            rezArray[i].modeWork = rez[30 + i] >> 13 & 1;       //Режим работы авто
        //            rezArray[i].errorTrans = rez[30 + i] >> 14 & 1;     //Неисправность
        //            rezArray[i].pallet = rez[30 + i] >> 15 & 1;         //Наличие паллеты

        //            //Информация по Паллету на РК
        //            rezArray[i].productId = (int)rez[46 + i * 5];       //ИД продукта
        //            rezArray[i].productNamber = (int)rez[47 + i * 5];   //Колличество продукта на паллете
        //            rezArray[i].pathFrom = (int)rez[48 + i * 5];        //Отправная точка паллеты
        //            rezArray[i].pathTo = (int)rez[49 + i * 5];          //Точка прибытия паллеты
        //            rezArray[i].reserv = (int)rez[50 + i * 5];          //Резерв паллеты
        //        }
        //    }
        //    catch
        //    {
        //        setError();
        //        rezArray = null;
        //        MessageBox.Show("Ошибка произошла при информации о роликовых конвейеров.");
        //    }
        //    finally
        //    { }
        //    return rezArray;
        //}


        //Получение информации о роликовых конвейеров разгрузочной транспортной линии
        private static ushort rollerUnloadConveyorCntrAdr = 2801, andRollerUnloadConveyorCntrAdr = 46;
        private static ushort rollerUnloadConveyorInfoAdr = 4151, andRollerUnloadConveyorInfoAdr = 75;
        public RC[] GetInfoRolConveyor()
        {
            RC[] rezArray = new RC[15];

            try
            {
                ushort[] tempUSmas1 = master.ReadHoldingRegisters(rollerUnloadConveyorCntrAdr, andRollerUnloadConveyorCntrAdr);
                ushort[] tempUSmas2 = master.ReadHoldingRegisters(rollerUnloadConveyorInfoAdr, andRollerUnloadConveyorInfoAdr);
                ushort[] rez = new ushort[andRollerUnloadConveyorCntrAdr + andRollerUnloadConveyorInfoAdr];


                for (int i = 0; i < andRollerUnloadConveyorCntrAdr + andRollerUnloadConveyorInfoAdr; i++)
                {
                    if (i < andRollerUnloadConveyorCntrAdr)
                        rez[i] = tempUSmas1[i];
                    else
                        rez[i] = tempUSmas2[i - andRollerUnloadConveyorCntrAdr];
                }

                for (int i = 0; i < rezArray.Length; i++)
                {
                    //Регистр управления
                    rezArray[i].nStartTrans = rez[0 + i] & 7;       //Номер отправного РК
                    rezArray[i].nAndSh = rez[0 + i] >> 3 & 7;       //Номер приемочного СШ
                    rezArray[i].idTrans = rez[0 + i] >> 6 & 15;     //ИД транспортера
                    rezArray[i].resetTrans = rez[0 + i] >> 14 & 1;  //Сброс параметров маршрута для транспортера
                    rezArray[i].blockTrans = rez[0 + i] >> 15 & 1;  //Блокировка

                    //Регистр неисправностей РК
                    rezArray[i].error1 = rez[15 + i] & 1;           //Сигнал с аварийных контактов автоматов SF1 - SF3
                    rezArray[i].error2 = rez[15 + i] >> 1 & 1;      //Сработал таймер контроля хода вперед
                    rezArray[i].error3 = rez[15 + i] >> 2 & 1;      //Сработал таймер контроля хода назад

                    //Регистр состояния РК
                    rezArray[i].state = rez[30 + i] & 7;                //Состояние движение транспортера (0-покоится, 3-вращение вперед, 4-вращение назад)
                    rezArray[i].lowMotion = rez[30 + i] >> 3 & 1;       //Движение с медленной скоростью
                    rezArray[i].item09 = rez[30 + i] >> 9 & 1;          //Транспортер свободен для отправки по маршруту
                    rezArray[i].item11 = rez[30 + i] >> 11 & 1;         //Разрешение на вращение вперед
                    rezArray[i].item12 = rez[30 + i] >> 12 & 1;         //Разрешение на вращение назад
                    rezArray[i].modeWork = rez[30 + i] >> 13 & 1;       //Режим работы авто
                    rezArray[i].errorTrans = rez[30 + i] >> 14 & 1;     //Неисправность
                    rezArray[i].pallet = rez[30 + i] >> 15 & 1;         //Наличие паллеты

                    //Информация по Паллету на РК
                    rezArray[i].productId = (int)rez[46 + i * 5];       //ИД продукта
                    rezArray[i].productNamber = (int)rez[47 + i * 5];   //Колличество продукта на паллете
                    rezArray[i].pathFrom = (int)rez[48 + i * 5];        //Отправная точка паллеты
                    rezArray[i].pathTo = (int)rez[49 + i * 5];          //Точка прибытия паллеты
                    rezArray[i].reserv = (int)rez[50 + i * 5];          //Резерв паллеты
                }
            }
            catch
            {
                this.error_str = "Ошибка произошла при информации о роликовых конвейеров.";
                setError();
                rezArray = null;
                //MessageBox.Show("Ошибка произошла при информации о роликовых конвейеров.");
            }
            finally
            { }
            return rezArray;
        }


        
        //Методы перевода чисел
        private float twoUshortToFloat(ushort[] value)
        {
            byte[] A = BitConverter.GetBytes(value[0]);
            byte[] B = BitConverter.GetBytes(value[1]);
            byte[] z = new byte[4];
            z[0] = A[0];
            z[1] = A[1];
            z[2] = B[0];
            z[3] = B[1];

            float rez = BitConverter.ToSingle(z, 0);

            return rez;
        }
        
        private ushort[] intToTwoUshort(int value)
        {
            byte[] b = BitConverter.GetBytes(value);
            
            ushort[] z = new ushort[2];            
            z[0] = (ushort)BitConverter.ToInt16(b, 0);
            z[1] = (ushort)BitConverter.ToInt16(b, 2);
            
            return z;
        }

        
        private int twoUshortToInt(ushort[] value)
        {
            Byte[] q = new Byte[4];
            q[0] = BitConverter.GetBytes(value[0])[0];
            q[1] = BitConverter.GetBytes(value[0])[1];
            q[2] = BitConverter.GetBytes(value[1])[0];
            q[3] = BitConverter.GetBytes(value[1])[1];

            return BitConverter.ToInt32(q, 0);            
        }
        
        private bool[] toMasBool(ushort value)
        {
            bool[] rez = new bool[16];
            int temp = 0;

            for (int i = 1; i <= 16; i++)
            {
                if (i == 1)
                {
                    temp = (value & i);
                    rez[i - 1] = Convert.ToBoolean(temp);
                }
                else
                {
                    temp = (value & (int)(Math.Pow((double)2, (double)(i - 1)))) >> (i - 1);
                    rez[i - 1] = Convert.ToBoolean(temp);
                }
            }
            return rez;
        }

        public ushort twoIntToUshort(int rackUnload, int rackLoad)
        {
            ushort res = 0;
            int tmp;
            tmp = (byte)rackUnload << 8;
            res = (ushort)(tmp | (byte)rackLoad);
            return res;
        }

        public int [] ushortToTwoInt(ushort value)
        {
            int[] res = new int[2];
            res[0] = value & 255;
            res[1] = (value & 65280) >> 8;
            return res;
        }
    }
}
