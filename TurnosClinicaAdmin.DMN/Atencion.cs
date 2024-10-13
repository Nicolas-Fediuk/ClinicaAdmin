using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnocClinica.Shared.Entidades
{
    public class Atencion
    {
        public double DNIMED_ATEN { get; set; }
        public string DIA_ATEN { get; set; }
        public TimeSpan HRINICIO_ATEN { get; set; }
        public TimeSpan HRFIN_ATEN { get; set; }
    }
}
