using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacagroup.Comercial.Creditos.ContratoRepositorio;
using Pacagroup.Comercial.Creditos.Dominio;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Pacagroup.Comercial.Creditos.SqlRepositorio
{
    public class CreditoRepositorio : ICreditoRepositorio
    {
        public Credito ActualizarCredito(Credito credito)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerrCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("IdCredito", credito.IdCredito);
                parametros.Add("TipoCredito", credito.TipoCredito);
                parametros.Add("IdCliente", credito.IdCliente);
                parametros.Add("Fecha", credito.fecha);
                parametros.Add("Monto", credito.monto);
                parametros.Add("DiaPago", credito.DiaPago);
                parametros.Add("Tasa", credito.tasa);
                parametros.Add("Comision", credito.Comision);
               
                var result = conexion.Execute("dbo.sp_credito_actualizar", param: parametros, commandType: CommandType.StoredProcedure);
                
                return result > 0 ? credito : new Credito ();
            }
        }

       public bool EliminarCredito(string idCredito)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerrCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("IdCredito", idCredito);
                var result = conexion.Execute("dbo.sp_credito_eliminar", param: parametros, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
    }

        public IEnumerable<Credito> ListarCredito()
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerrCadenaConexion()))
            {
             conexion.Open();
            var coleccion = conexion.Query<Credito>("dbo.sp_credito_listar", commandType: CommandType.StoredProcedure);
            return coleccion;
            }
        }

        Credito ICreditoRepositorio.RegistrarCredito(Credito credito)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerrCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("TipoCredito",credito.TipoCredito);
                parametros.Add("IdCliente", credito.IdCliente);
                parametros.Add("Fecha", credito.fecha);
                parametros.Add("Monto", credito.monto);
                parametros.Add("DiaPago", credito.DiaPago);
                parametros.Add("Tasa", credito.tasa);
                parametros.Add("Comision", credito.Comision);
                //Aquí recuperamos lo que retorno la consulta del procedure porque se genera automaticamente con el Identity
                parametros.Add("IdCredito", credito.IdCredito, DbType.Int32, ParameterDirection.Output);

                var result = conexion.ExecuteScalar("dbo.sp_credito_registrar", param: parametros, commandType: CommandType.StoredProcedure);
                //Obtenemos ek Id credto con base a neustros parametros
                var pIdCredito = parametros.Get<Int32>("IdCredito");
                //Aquí le setamos el valor que ha generado la BD
                credito.IdCredito = pIdCredito;
                return credito;
            }
        }
    }
}
