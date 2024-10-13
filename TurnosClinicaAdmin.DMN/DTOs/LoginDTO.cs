using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TurnocClinica.Shared.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="El campo es requerido")]
        [EmailAddress(ErrorMessage ="El campo debe ser un correo electronico valido")]
        public string CORREO_CUENTA { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string PASSWORD_CUENTA { get; set; }
    }
}
