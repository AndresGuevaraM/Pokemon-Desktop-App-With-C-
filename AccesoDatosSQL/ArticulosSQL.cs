using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DominioClases;
namespace AccesoDatosSQL
{
    public class ArticulosSQL
    {
        // Se crea un metodo de tipo coleccion que emule el comportamiento de la clase Articulos.
        public List<Articulos> Listar()
        {
            // se crea la coleccion como tal que guardara los datos en una variable (lista) emulando el comportamiento de la clase.
            List<Articulos> lista = new List<Articulos>();
            AccesoSQL articulos = new AccesoSQL();
            string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, C.Descripcion Categoria, M.Descripcion Marca, A.IdMarca, A.IdCategoria, Precio From ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id And A.IdMarca = M.Id";
            try
            {
                articulos.setearConsulta(consulta);
                articulos.ejecutarLectura();
                // se hace un while que funcionara mientras este leyendo datos.
                while (articulos.Lector.Read())
                {
                    Articulos arti = new Articulos();
                    // se le asigna al objeto de la clase los datos esperados por sus propiedades leyendolos y obteniendolos de la DB.
                    arti.Id = (int)articulos.Lector["Id"];
                    arti.Codigo = (string)articulos.Lector["Codigo"];
                    arti.Nombre = (string)articulos.Lector["Nombre"];
                    arti.Descripcion = (string)articulos.Lector["Descripcion"];
                    // if para que identifique si la lectura que se obtiene es nula, en caso de serlo no se leera.
                    if (!(articulos.Lector["ImagenUrl"] is DBNull))
                    {
                        arti.ImagenUrl = (string)articulos.Lector["ImagenUrl"];
                    }
                    // se crea la instancia de las clases Categorias y Marcas, ya que no se hace en la declaracion hecha en la clase Articulos, porque se procesa como una propiedad
                    arti.Marca = new Marcas();
                    arti.Marca.Id = (int)articulos.Lector["IdMarca"];
                    arti.Marca.Descripcion = (string)articulos.Lector["Marca"];
                    arti.Categoria = new Categorias();
                    arti.Categoria.Id = (int)articulos.Lector["IdCategoria"];
                    arti.Categoria.Descripcion = (string)articulos.Lector["Categoria"];
                    arti.Precio = (decimal)articulos.Lector["Precio"];
                    //se agregan a la coleccion los datos del objeto.
                    lista.Add(arti);
                }
                
                return lista;

            }

            // catch con manejo de las excepciones lanzando el tipo de error.
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                articulos.cerrarConexion();
            }

        }
        public int IdArticulo { get; set;}
        public List<Articulos> LDetalleArticulo()
        {
            // se crea la coleccion como tal que guardara los datos en una variable (lista) emulando el comportamiento de la clase.
            List<Articulos> ldetallearticulo = new List<Articulos>();
            AccesoSQL articulos = new AccesoSQL();
            int IdA = IdArticulo;
            string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, C.Descripcion Categoria, M.Descripcion Marca, Precio From ARTICULOS A, CATEGORIAS C, MARCAS M Where A.Id = '" + IdA +"'";
            try
            {
                articulos.setearConsulta(consulta);
                articulos.ejecutarLectura();
                // se hace un while que funcionara mientras este leyendo datos.
                while (articulos.Lector.Read())
                {
                    Articulos arti = new Articulos();
                    // se le asigna al objeto de la clase los datos esperados por sus propiedades leyendolos y obteniendolos de la DB.
                    arti.Id = (int)articulos.Lector["Id"];
                    arti.Codigo = (string)articulos.Lector["Codigo"];
                    arti.Nombre = (string)articulos.Lector["Nombre"];
                    arti.Descripcion = (string)articulos.Lector["Descripcion"];
                    // if para que identifique si la lectura que se obtiene es nula, en caso de serlo no se leera.
                    if (!(articulos.Lector["ImagenUrl"] is DBNull))
                    {
                        arti.ImagenUrl = (string)articulos.Lector["ImagenUrl"];
                    }
                    // se crea la instancia de las clases Categorias y Marcas, ya que no se hace en la declaracion hecha en la clase Articulos, porque se procesa como una propiedad
                    arti.Marca = new Marcas();
                    arti.Marca.Descripcion = (string)articulos.Lector["Marca"];
                    arti.Categoria = new Categorias();
                    arti.Categoria.Descripcion = (string)articulos.Lector["Categoria"];
                    arti.Precio = (decimal)articulos.Lector["Precio"];
                    //se agregan a la coleccion los datos del objeto.
                    ldetallearticulo.Add(arti);
                }

                return ldetallearticulo;

            }

            // catch con manejo de las excepciones lanzando el tipo de error.
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                articulos.cerrarConexion();
            }

        }


        // FUNCION para agregar datos a la DB

        public void Agregar(Articulos newarti)
        {
            // Se crea la instancia de la clase que tiene las funciones que acceden a la base de datos.
            AccesoSQL data = new AccesoSQL();

            try
            {
                data.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria,ImagenUrl, Precio) values (" + newarti.Codigo + ", '" + newarti.Nombre + "', ' " + newarti.Descripcion + "', '" + newarti.Marca.Id + "','" + newarti.Categoria.Id + "', '" + newarti.ImagenUrl + "', '" + newarti.Precio + "') ");
                data.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }

        // FUNCION para modificar datos a la DB

        public void Modificar(Articulos modify)
        {
            // Se crea la instancia de la clase que tiene las funciones que acceden a la base de datos.
            AccesoSQL data = new AccesoSQL();

            try
            {
                data.setearConsulta("Update ARTICULOS  set Codigo = '" + modify.Codigo + "' , Nombre = '" + modify.Nombre + "', Descripcion = '" + modify.Descripcion + "', IdMarca = '" + modify.Marca.Id + "', IdCategoria = '" + modify.Categoria.Id + "', ImagenUrl = '" + modify.ImagenUrl + "' Where Id = '" + modify.Id + "'");
                data.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }

        // FUNCION para eliminar datos en la DB

        public void Eliminar(int id)
        {
            // Se crea la instancia de la clase que tiene las funciones que acceden a la base de datos.
            AccesoSQL data = new AccesoSQL();

            try
            {
                data.setearConsulta("Delete from ARTICULOS  Where Id = '" + id + "'");
                data.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }


        //Metodo de tipo list para filtrar segun campo, criterio y el filtro de busqueda.
        public List<Articulos> Filtrar(string campo, string criterio, string filtro)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoSQL articulos = new AccesoSQL();

            try
            {

                string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, C.Descripcion Categoria, M.Descripcion Marca, A.IdMarca, A.IdCategoria, Precio From ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id And A.IdMarca = M.Id And ";

                if (campo == "Codigo")
                {
                    switch (criterio)
                    {
                        case "Inicia con la letra o numero...":
                            consulta += "Codigo like '" + filtro + "%' ";
                            break;
                        case "Finaliza con la letra o numero...":
                            consulta += "Codigo like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "Codigo like '%" + filtro + "%' ";
                            break;
                    }

                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Inicia con las letras...":

                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Finaliza con las letras...":
                            consulta += "Nombre like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%' ";
                            break;
                    }

                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Inicia con las letras...":
                            consulta += "M.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Finaliza con las letras...":
                            consulta += "M.Descripcion like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "M.Descripcion like '%" + filtro + "%' ";
                            break;
                    }

                }
                else if (campo == "Categoria")
                {
                    switch (criterio)
                    {
                        case "Inicia con las letras...":
                            consulta += "C.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Finaliza con las letras...":
                            consulta += "C.Descripcion like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "%' ";
                            break;
                    }

                }
                else
                {
                    switch (criterio)
                    {
                        case "Inicia con las letras...":
                            consulta += "A.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Finaliza con las letras...":
                            consulta += "A.Descripcion like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "A.Descripcion like '%" + filtro + "%' ";
                            break;
                    }

                }
                articulos.setearConsulta(consulta);
                articulos.ejecutarLectura();

                while (articulos.Lector.Read())
                {
                    Articulos arti = new Articulos();
                    // se le asigna al objeto de la clase los datos esperados por sus propiedades leyendolos y obteniendolos de la DB.
                    arti.Id = (int)articulos.Lector["Id"];
                    arti.Codigo = (string)articulos.Lector["Codigo"];
                    arti.Nombre = (string)articulos.Lector["Nombre"];
                    arti.Descripcion = (string)articulos.Lector["Descripcion"];
                    // if para que identifique si la lectura que se obtiene es nula, en caso de serlo no se leera.
                    if (!(articulos.Lector["ImagenUrl"] is DBNull))
                    {
                        arti.ImagenUrl = (string)articulos.Lector["ImagenUrl"];
                    }
                    // se crea la instancia de las clases Categorias y Marcas, ya que no se hace en la declaracion hecha en la clase Articulos, porque se procesa como una propiedad
                    arti.Marca = new Marcas();
                    arti.Marca.Id = (int)articulos.Lector["IdMarca"];
                    arti.Marca.Descripcion = (string)articulos.Lector["Marca"];
                    arti.Categoria = new Categorias();
                    arti.Categoria.Id = (int)articulos.Lector["IdCategoria"];
                    arti.Categoria.Descripcion = (string)articulos.Lector["Categoria"];
                    arti.Precio = (decimal)articulos.Lector["Precio"];
                    //se agregan a la coleccion los datos del objeto.
                    lista.Add(arti);
                }

                return lista;

            }

            // catch con manejo de las excepciones lanzando el tipo de error.
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                articulos.cerrarConexion();
            }


        }
    }

 }

