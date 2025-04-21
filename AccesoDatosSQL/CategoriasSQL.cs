using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DominioClases;

namespace AccesoDatosSQL
{
    public class CategoriasSQL
    {
        public List<Categorias> listar()
        {
            // Variable de tipo arreglo que guardara los datos de tipo Categoria.
            List<Categorias> lista = new List<Categorias>();
            // con esta linea se hace la instancia de la clase que accede a la DB, pudiendo llamar todas sus funciones con la variable datos.
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.setearConsulta("Select Id, Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                // se ejecuta el while mientras se esten leyendo los datos.
                while (datos.Lector.Read())
                {
                    // por medio de la variable cate se obtendran los property del objeto Categoria.
                    Categorias cate = new Categorias();
                    cate.Id = (int)datos.Lector["Id"];
                    cate.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(cate);
                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;

            }
            // si o si con el finally se ejecuta el cierre de la conexion.
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
