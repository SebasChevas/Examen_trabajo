using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.WebSockets;

namespace WebServices_Examen
{
    /// <summary>
    /// Descripción breve de BD
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class BD : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {

            return "Hola a todos";
        }

        [WebMethod]
        public DataSet GetData()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=ChevasPc;DataBase= BdiExamen;Integrated Security=true";
            SqlDataAdapter da = new SqlDataAdapter("Select * from tblExamen", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}