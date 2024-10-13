using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TurnocClinica.Shared.Entidades
{
    public class Medico
    {
        [BindProperty(SupportsGet = true)]
        public double DNI_MED { get; set; }
        public string NOMBRE_MED { get; set; }
        public string APELLIDO_MED { get; set; }
        public string SEXO_MED { get; set; }
        public string NACIONALIDAD_MED { get; set; }
        public DateTime FECNAC_MED { get; set; }
        public string DIREC_MED { get; set; }
        public string LOCALIDAD_MED { get; set; }
        public string PROVINCIA_MED { get; set; }
        public string CORREO_MED { get; set; }
        public double TELEFONO_MED { get; set; }
        public string FOTO_MED { get; set; }
        public string IDESP_MED { get; set; }
        public Especialidad? Especialidad { get; set; }
        public List<Atencion>? horarios { get; set; }
        //public Paginacion Paginacion { get; set; } = null!;
    }
}
