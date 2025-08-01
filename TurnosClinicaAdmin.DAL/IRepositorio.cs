using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnocClinica.Shared.DTO;
using TurnocClinica.Shared.Entidades;
using TurnosClinicaAdmin.DMN;

namespace TurnosClinicaAdmin.DAL
{
    public interface IRepositorio
    {
        Task EditarMedico(Medico medico);
        Task<int> ExisteUsuario(LoginDTO usr);
        Task<IEnumerable<Especialidad>> GetEspecialidades();
        Task<IEnumerable<Localidad>> GetLocalidades(string pais);
        Task<Medico> GetMedicoEditar(double DNI_MED);
        Task<IEnumerable<Medico>> GetMedicos();
        Task<IEnumerable<Medico>> GetMedicos(string dni);
        Task<IEnumerable<Pais>> GetPaises();
    }
}
