using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiexamen
{
    public class StoredProcedures
    {
        private ConexionBaseDatos conn = new ConexionBaseDatos();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        public DataTable Mostrar()
        {

            comando.Connection = conn.AbrirConexion();
            comando.CommandText = "spConsultar";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conn.CerrarConexion();
            return tabla;

        }
        public void Insertar(string nombre, string Descripcion)
        {
            comando.Connection = conn.AbrirConexion();
            comando.CommandText = "spAgregar";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.Clear();
            conn.CerrarConexion();
        }
        public void Editar(string nombre, string Descripcion)
        {
            comando.Connection = conn.AbrirConexion();
            comando.CommandText = "spActualizar ";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);

            comando.Parameters.Clear();
            conn.CerrarConexion();
        }
        public void Eliminar(int id)
        {
            comando.Connection = conn.AbrirConexion();
            comando.CommandText = "spEliminar";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idpro", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conn.CerrarConexion();
        }
    }
}
