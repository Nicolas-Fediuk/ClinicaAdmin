using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnocClinica.Shared.Entidades
{
    public class Especialidad
    {
        public string ID_ESP { get; set; }
        public string NOMBRE_ESP { get; set; } = null!;
    }
}
