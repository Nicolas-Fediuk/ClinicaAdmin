using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnocClinica.Shared.DTO;
using TurnocClinica.Shared.Entidades;

namespace TurnosClinicaAdmin.DAL
{
    public interface IRepositorio
    {
        Task<int> ExisteUsuario(LoginDTO usr);
        Task<IEnumerable<Especialidad>> GetEspecialidades();
        Task<Medico> GetMedicoEditar(double DNI_MED);
        Task<IEnumerable<Medico>> GetMedicos();
        Task<IEnumerable<Medico>> GetMedicos(string dni);
    }
}
