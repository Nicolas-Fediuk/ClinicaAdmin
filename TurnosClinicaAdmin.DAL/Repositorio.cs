using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnocClinica.Shared.DTO;
using TurnocClinica.Shared.Entidades;
using TurnosClinicaAdmin.BlazorServer.Helpers;

namespace TurnosClinicaAdmin.DAL
{
    public class Repositorio : IRepositorio
    {
        private readonly string connectionString = "Server=SM-NFEDIUKR7\\SQLEXPRESS;database=TurnosClinica;Integrated Security=True";
        public async Task<int> ExisteUsuario(LoginDTO usr)
        {
            using var connection = new SqlConnection(connectionString);

            string passEncrypt = Encrypt.GetSHA256(usr.PASSWORD_CUENTA);
            usr.PASSWORD_CUENTA = passEncrypt;

            int existe = await connection.QueryFirstOrDefaultAsync<int>(@"select 1 from CUENTAS where CORREO_CUENTA = @CORREO_CUENTA and PASSWORD_CUENTA = @PASSWORD_CUENTA", usr);

            return existe;
        }

        public async Task<IEnumerable<Medico>> GetMedicos()
        {
            using var connection = new SqlConnection(connectionString);

            var resultado = await connection.QueryAsync<Medico>(@"select * from MEDICOS");

            foreach (var result in resultado)
            {
                try
                {
                    result.Especialidad = await BuscarEspecialidad(result.IDESP_MED);
                    IEnumerable<Atencion> horarios = await BuscarHorarios(result.DNI_MED);
                    result.horarios = horarios.ToList();
                }
                catch (Exception ex)
                {
                    var mensaje = ex.Message.ToString();
                }
            }

            return resultado.ToList();
        }

        public async Task<IEnumerable<Medico>> GetMedicos(string dni)
        {

            using var connection = new SqlConnection(connectionString);

            var query = @"SELECT * FROM MEDICOS WHERE NOMBRE_MED LIKE @Dni";

            var resultado = await connection.QueryAsync<Medico>(query, new { Dni = $"%{dni}%" });

            foreach (var result in resultado)
            {
                try
                {
                    result.Especialidad = await BuscarEspecialidad(result.IDESP_MED);
                    IEnumerable<Atencion> horarios = await BuscarHorarios(result.DNI_MED);
                    result.horarios = horarios.ToList();
                }
                catch (Exception ex)
                {
                    var mensaje = ex.Message.ToString();
                }
            }

            return resultado.ToList();
        }

        private async Task<Especialidad> BuscarEspecialidad(string id)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<Especialidad>("SELECT * FROM ESPECIALIDADES where ID_ESP = @id", new { id });
        }

        private async Task<IEnumerable<Atencion>> BuscarHorarios(double DNIMED_ATEN)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Atencion>("SELECT * FROM ATENCION WHERE DNIMED_ATEN = @DNIMED_ATEN", new { DNIMED_ATEN });
        }

        
        public async Task<Medico> GetMedicoEditar(double DNI_MED)
        {
            using var connection = new SqlConnection(connectionString);

            var resultado = await connection.QueryFirstOrDefaultAsync<Medico>(@"select * from MEDICOS where DNI_MED = @DNI_MED", new{DNI_MED});

            resultado.Especialidad = await BuscarEspecialidad(resultado.IDESP_MED);
            IEnumerable<Atencion> horarios = await BuscarHorarios(resultado.DNI_MED);
            resultado.horarios = horarios.ToList();

            return resultado;
        }

        public async Task<IEnumerable<Especialidad>> GetEspecialidades()
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Especialidad>(@"SELECT * FROM ESPECIALIDADES");
        }

        public async Task<string> GetNombreUser(string correo)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<string>("select NOMBRE_USR + ' ' + APELLIDO_USR from USUARIO where CORREO_USR = @correo", correo);
        }

    }
}
