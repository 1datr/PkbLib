using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PkbLib
{
    // трехмерная координата/индекс
    [System.SerializableAttribute]
    public struct Point3
    {
        public Point3(int x, int y, int z)
        {
            X = x; Y = y; Z = z;
        }
        public int X;
        public int Y;
        public int Z;
    }
    // ячейка
    [System.SerializableAttribute]
    public class PkbCell
    {
        public PkbStacker Parent;
        /* 
         * x,y - координаты в гриде
         * z - 0- верхний грид, 1 - нижний грид
        */
        public Point3 Indexes;
        public Point3 Coords;

        public int Number;
        // реальные координаты ячейки
        public RealCellCoord RCC;

        public Point3 CalcPoint(int cell_length, int cell_width, int cell_height, int sub)
        {
            if(Indexes.Z==0)
                return new Point3(cell_length * Coords.X, cell_width * Coords.Y, sub + cell_height * Coords.Z); 
            else
                return new Point3(cell_length * Coords.X, cell_width * Coords.Y, sub + cell_height * Coords.Z); 
        }

    }
    // команда штабелеру
    [System.SerializableAttribute]
    public class PkbStackerCmd
    {
        public string cmd;
        public int param1;
        public int param2;
        public PkbStackerCmd(string cmdstr, int param1 = 0, int param2 = 0)
        {
            this.cmd = cmdstr;
            this.param1 = param1;
            this.param2 = param2;
        }
    }
    // Команда штабелера
    [System.SerializableAttribute]
    public struct StdShCommand
    {
        public int cmd;
        public int cell_load;
        public int cell_unload;
    }


    // Точка в 3-х мерном пространстве
    public struct Point3D
    {
        public int X, Y, Z;
        public Point3D(int x = 0, int y = 0, int z = 0)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public void mul(int mulx, int muly, int mulz)
        {
            this.X *= mulx;
            this.Y *= muly;
            this.Z *= mulz;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Point3D obj_item = (Point3D)obj;
            return ((obj_item.X == this.X) & (obj_item.Y == this.Y) & (obj_item.Z == this.Z));
        }

        public void incx(int inc = 1)
        {
            this.X += inc;
        }

        public void incy(int inc = 1)
        {
            this.Y += inc;
        }

        public void incz(int inc = 1)
        {
            this.Z += inc;
        }

        public bool EqX(object obj)
        {
            if (obj == null) return false;
            Point3D obj_item = (Point3D)obj;
            return (obj_item.X == this.X);
        }

        public bool EqY(object obj)
        {
            if (obj == null) return false;
            Point3D obj_item = (Point3D)obj;
            return (obj_item.Y == this.Y);
        }

        public bool EqZ(object obj)
        {
            if (obj == null) return false;
            Point3D obj_item = (Point3D)obj;
            return (obj_item.Z == this.Z);
        }
    }

    // Координаты ячейки штабелера
    [System.SerializableAttribute]
    public class RealCellCoord
    {
        public int id;
        // cell number
        public int ncell;
        //  CoordX
        public int X_StopBack;
        public int X_StopForward;
        public int X_CellBack;
        public int X_CellForward;
        //  CoordYCheck
        public int YCheck_StopDown;
        public int YCheck_StopUp;
        public int YCheck_CellDown;
        public int YCheck_CellUp;
        public int YCheck_CellBusyDown;
        public int YCheck_CellBusyUp;
        // CoordYLoad
        public int YLoad_StopDown;
        public int YLoad_StopUp;
        public int YLoad_CellDown;
        public int YLoad_CellUp;
        //CoordYUpload
        public int YUpload_StopDown;
        public int YUpload_StopUp;
        public int YUpload_CellDown;
        public int YUpload_CellUp;
        //CoordZ
        public int Z_StopCell;
        public int Z_StopStacker;
    }

    public struct BitMapItem
    {
        public ushort addr;     // адрес слова
        public ushort word;     // слово
        public ushort bit;      // бит
        public bool value;      // установлен ли бит
        public string caption;  // что означает этот бит
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            BitMapItem obj_item = (BitMapItem)obj;
            return ((obj_item.addr == this.addr) & (obj_item.word == this.word) & (obj_item.bit == this.bit) & (obj_item.value == this.value) & (obj_item.caption == this.caption));
        }
    }
}
