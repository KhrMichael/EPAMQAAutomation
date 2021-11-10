using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Cars.Parts
{
    public class Engine : CarPart
    {
        public double Capasity { get; set; }
        public double Displacement { get; set; }
        public string Type { get; set; }
        public string SerialNumber { get; set; }
    }
}
