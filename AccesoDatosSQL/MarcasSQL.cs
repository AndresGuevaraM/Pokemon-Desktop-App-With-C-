using DominioClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosSQL
{
    public class MarcasSQL
    {
        public List<Marcas> listar()
        {
            // Variable de tipo arreglo que guardara los datos de tipo Marca.
            List<Marcas> lista = new List<Marcas>();
            // con esta linea se hace la instancia de la clase que accede a la DB, pudiendo llamar todas sus funciones con la variable datos.
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.setearConsulta("Select Id, Descripcion from MARCAS");
                datos.ejecutarLectura();

                // se ejecuta el while mientras se esten leyendo los datos.
                while (datos.Lector.Read())
                {
                    // por medio de la variable mar se obtendran los property del objeto marca.
                    Marcas mar = new Marcas();
                    mar.Id = (int)datos.Lector["Id"];
                    mar.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(mar);
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
