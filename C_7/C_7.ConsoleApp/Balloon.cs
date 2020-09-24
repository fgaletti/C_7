using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_7.ConsoleApp
{
     public class Balloon : IEquatable<Balloon>
    {
        public string Color { get; set; }
        public int CC { get; set; }

        public bool Equals(Balloon b)
        {
            if (b == null) return false;
            return b.Color == Color && b.CC == CC;
        }
    }
}
