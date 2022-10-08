//AINA WAHIDAH BT OSMAN (1171201426)
//LAW JUNWEI (1171201084)
//PUTERI NURHANIS SHAMIMI MAHZLAN (1171200172)
//DMP5018 Programming in Mobile Apps 
//Group Project
//VolumeEasyPeasy - SphereModel.cs [Class]

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace VolumeEasyPeasy.Model
{
    class SphereModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Radius { get; set; }
        public double Total { get; set; }
        public override string ToString()
        {
            return $"{this.Id}: V = 4.0 / 3.0 * 3.142 * {this.Radius}^3 = {this.Total}";
        }
    }
}
