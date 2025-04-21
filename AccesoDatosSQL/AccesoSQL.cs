using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosSQL
{
    public class AccesoSQL
    {
        // se declaran los atributos necesarios para hacer la conexion con la DB.
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        // Se crea la property del lector para poder tener acceso a los datos.
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        // constructor para crear la conexion con la base de datos.
        public AccesoSQL()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            comando = new SqlCommand();
        }

        // funcion para obtener la consulta de la base de datos la cual esta en formato string.
        public void setearConsulta(string Consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = Consulta;
        }
        // funcion para crear la conexion con la base de datos, leer la informacion y en dado caso lanzar la excepcion por un posible error.
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // funcion para ejecutar la accion de insertar los datos en donde se aclara que es una accion de tipo no consulta para que despues se puedan agregar los datos.
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        // funcion para cerrar la conexion con la base de datos.
        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }



    }
}

