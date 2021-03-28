using Pacagroup.Comercial.Creditos.Dominio;
using Pacagroup.Comercial.Creditos.ContratoRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Pacagroup.Comercial.Creditos.SqlRepositorio
{
    public class ClienteRepositorio: IClienteRepositorio
    {
        public Cliente ObtenerCliente(string numeroDocumento)
        {
           using(IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerrCadenaConexion()) )
            {
                conexion.Open();
                //Crearemos nuestros parametros con base a los procedures que realizamos en SQL, para ello necesitamos:
                var parametros = new DynamicParameters();
                //Aquí añadimos el nombre de la variable del parametro de SQL, solo que sin el simbolo aroba (@)
                //Sintaxis en el Add: variable,el valor de dicha variable
                parametros.Add("pNumeroDocumento",numeroDocumento);
                //Hacemos el query, poniendo el nombre del procedure con:
                //Así mismo el dato que regresa el rpocedure se mapeará en el objeto Cliente
                var cliente = conexion.QuerySingle<Cliente>("dbo.sp_cliente_obtener", param: parametros, commandType: CommandType.StoredProcedure);
                return cliente;
            }
        }

        public IEnumerable<Cliente> ListarCliente()
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerrCadenaConexion()))
            {
                conexion.Open();
                //La función Query retorna un IEnumerable o podemos convertirlo a una lista
                var cliente = conexion.Query<Cliente>("dbo.sp_cliente_listar", commandType: CommandType.StoredProcedure);
                return cliente;
            }
                
        }
    }
}
