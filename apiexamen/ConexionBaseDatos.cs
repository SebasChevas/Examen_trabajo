using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiexamen
{
    public class ConexionBaseDatos
    {
        private SqlConnection conn = new SqlConnection("Server=ChevasPc;DataBase= BdiExamen;Integrated Security=true");
        public SqlConnection AbrirConexion()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            return conn;
        }
        public SqlConnection CerrarConexion()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            return conn;
        }
    }
}
