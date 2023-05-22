using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiexamen
{
    public class EntradaSalida
    {
        private StoredProcedures CBD = new StoredProcedures();
        public DataTable MostrarExamen()
        {
            DataTable tabla = new DataTable();
            tabla = CBD.Mostrar();
            return tabla;
        }
        public void InsertarExamen(string nombre, string Descripcion)
        {
            CBD.Insertar(nombre, Descripcion);
        }
        public void EditarExamen(string nombre, string descripcion)
        {
            CBD.Editar(nombre, descripcion);
        }
        public void EliminarExamen(string id)
        {
            CBD.Eliminar(Convert.ToInt32(id));
        }
    }
}
