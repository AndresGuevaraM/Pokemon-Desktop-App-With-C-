using DominioClases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using AccesoDatosSQL;


namespace Gestor_De_Datos
{
    public partial class NuevoArticulo: Form
    {
        // se crea un atributo privado de tipo articulos para que se pueda saber cuando los datos del objeto esten vacios o no, y con ello esta ventana actual sepa si se  esta  agregando o modificando un nuevo articulo.
        private Articulos articulos = null;
        // con OpenFileDialog se abre una ventana para elegir archivos localmente pero se crea como tipo privado en nulo para evaluar despues si se esta usando o no despues de hacer la instancia, y que con ello pase de nulo a true.
        private OpenFileDialog archivo = null;
        public NuevoArticulo()
        {
            InitializeComponent();
        }

        // constructor reutilizado para poder utilizar la misma ventana para la modificacion del articulo, cuando sea el agregado se utilizara el  constructor de la clase normal porque no espera ningun tipo de valor, por el contrario este espera un tipo de dato objeto articulo el cual editara cuando se este modificando.

        public NuevoArticulo(Articulos articulos)
        {
            InitializeComponent();
            this.articulos = articulos;
            // Se Cambia el Nombre de la ventana para cuando se este modificando un articulo, ya que cuando se este agregando tendra el nombre original Nuevo Articulo.
            this.Text = "Modificar Articulo";
        }

        // Funcion para que se confirme y realice la modificacion de un articulo o el agregado de un nuevo articulo.
        private void Aceptar_Click(object sender, EventArgs e)
        {
            //Se llama la funcion validar campos, para que se verifique si todos los campos fueron llenados antes de proseguir con la modificacion o agregacion de un articulo.
            //validarCampos();

            // instancia para llamar a la clase Articulos que contiene el formato de datos que se quieren agregar a la DB.

            Articulos arti = new Articulos();
            ArticulosSQL data = new ArticulosSQL();

            try
            {
                // se utiliza un if para que en caso de que el articulo sea nulo se cree el nuevo, esto en caso de no comenzar agregando un articulo sino modificandolo.
                if (articulos == null)
                {
                    articulos = new Articulos();

                }
                articulos.Codigo = Codigo.Text;
                articulos.Nombre = Nombre.Text;
                articulos.Descripcion = Descripcion.Text;
                articulos.ImagenUrl = ImagenNURL.Text;
                articulos.Marca= (Marcas)CboxMarca.SelectedItem;
                articulos.Categoria =(Categorias) CboxCategoria.SelectedItem;
                articulos.Precio =decimal.Parse (Precio.Text);

                // se utiliza un condicional para saber si el id del articulo es diferente de cero, si lo es se esta modificando porque el articulo ya fue creado, sino lo es se esta agregando el articulo hasta ahora y por eso no tiene id.
               
                if (articulos.Id != 0)
                {
                    if (validarCampos() == false)
                    {
                        data.Modificar(articulos);
                        MessageBox.Show("Articulo Modificado exitosamente");
                    }

                }
                else
                {
                    if (validarCampos() == false)
                    {
                        data.Agregar(articulos);
                        MessageBox.Show("Articulo Agregado exitosamente");
                    }

                }

                // Condicional que evalua si accedio a una imagen local y sino se utilizo una url para cargar la imagen.
                if (archivo != null && !(ImagenNURL.Text.ToUpper().Contains("HTTP")))
                {
                    // Por medio de la clase File y el comando Copy se puede hacer una copia local de la imagen, para determinar en que ubicacion se utiliza el configurationManager que por medio de un key y un valor del app setting podra guardar la imagen en la ruta deseada. SafeFilename es para que obtenga el nombre original del archivo para que con ello quede con el mismo al momento de guardar.
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);

                }
                if (validarCampos() == false)
                {
                    Close();
                }

                }
            catch (FormatException)
            {
                validarCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NuevoArticulo_Load(object sender, EventArgs e)
        {
            CategoriasSQL data = new CategoriasSQL();
            MarcasSQL data2 = new MarcasSQL();

            try
            {
                CboxMarca.DataSource = data2.listar();
                // Value Member y DisplayMember son comandos de tipo DataSource con los cuales se puede obtener el valor en este caso id y su correspondiente info, esto se hace para obtener el valor de los despegables que tienen varias opciones de  diferente id  con su  info correspondiente.
                CboxMarca.ValueMember = "Id";
                CboxMarca.DisplayMember = "Descripcion";
                CboxCategoria.DataSource = data.listar();
                CboxCategoria.ValueMember = "Id";
                CboxCategoria.DisplayMember = "Descripcion";

                // condicional para saber si el objeto articulo esta nulo o no, en dado caso que no lo este se carguen los datos  del articulo seleccionado automaticamente al momento de editar con el mismo uso de esta ventana que se usa para agregar.
                if (articulos != null)
                {
                    Codigo.Text = articulos.Codigo;
                    Nombre.Text = articulos.Nombre;
                    Descripcion.Text = articulos.Descripcion;
                    ImagenNURL.Text = articulos.ImagenUrl;
                    cargarImagen(ImagenNURL.Text);
                    // con Selectedvalue se obtiene el valor del value member que corresponde a esa variable que usa a su vez DataSource.
                    CboxMarca.SelectedValue = articulos.Marca.Id;
                    CboxCategoria.SelectedValue = articulos.Categoria.Id;
                    Precio.Text = articulos.Precio.ToString().Split('.')[0];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }

        private void URL_Leave(object sender, EventArgs e)
        {
            cargarImagen(ImagenNURL.Text);
        }
        //  reutilizacion del metodo cargar imagen de la clase form1 (ventana principal), para poder cargar la imagen en esta ventana  actual.

        private void cargarImagen(string imagen)
        {
            try
            {
                ImagenNuevoArticulo.Load(imagen);
            }
            catch
            {
                ImagenNuevoArticulo.Load("https://socialistmodernism.com/wp-content/uploads/2017/07/placeholder-image.png");
            }

        }

        private void Abrir_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            // con el comando filter se le dice que tipo de formatos de imagen se podran leer.
            archivo.Filter = "jpg|*.jpg;|png|*.png";
            // condional para evualuar si la lectura fue correcta
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                // con FileName se obtiene la ruta del archivo y con esta misma ruta se carga posteriormente la imagen.
                ImagenNURL.Text = archivo.FileName;
                cargarImagen(archivo.FileName);

            }

        }

        // Funcion para las validaciones de los campos de modificacion o agregacion de un articulo que se hacen en esta ventana (Secundaria).
        private bool validarCampos()
        {

            if (Codigo.Text == "" || Nombre.Text == "" || Descripcion.Text == "" || ImagenNURL.Text == "" || Precio.Text == "")
            {

                MessageBox.Show("Por favor llene los campos vacios, para con ello poder procesar la info, gracias.");
                return true;
            }

            if (CboxMarca.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione una marca, para con ello poder procesar la info, gracias.");
                return true;
            }

            if (CboxCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione una categoria, para con ello poder procesar la info, gracias.");
                return true;

            }

            if (!(solonumeros(Precio.Text.ToString())))
            {
                MessageBox.Show("Por favor ingrese solo numeros sin espacios en el campo (precio), para con ello poder procesar la info, gracias.");
                Precio.Text = null;
                return true;
            }

            // Se que la descripcion puede contener numeros, pero como normalmente tiene solo letras pobre esta validacion aca para mostrar funcionamiento. 

            if (!(sololetras(Descripcion.Text)))
            {
                MessageBox.Show("Por favor ingrese solo letras en el campo (descripcion), para con ello poder procesar la info, gracias.");
                Descripcion.Text = null;
                return true;
            }

            if (!(sololetras2(Descripcion.Text)))
            {
                MessageBox.Show("Por favor ingrese solo letras en el campo (descripcion), para con ello poder procesar la info, gracias.");
                Descripcion.Text = null;
                return true;
            }

            // Al codigo y  URL no se le hacen validaciones de solo tener numeros o letras ya que los mismos pueden contener ambos.

            return false;

        }

        // Funcion que evalua que solo hayan numeros en los campos que corresponda, esto lo hace por medio de un foreach que ira recorriendo caracter por caracter en la cadena, si no hay solo numeros retorna falso, y si no verdadero cumpliendose el comportamiento ideal.
        private bool solonumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                {
                    return false;
                }
            }
            return true;

        }

        // Funcion que evalua que solo hayan letras en los campos que corresponda.

        private bool sololetras(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsLetter(caracter)) && (char.IsWhiteSpace(caracter)))
                {
                    return true;
                }
                if (!(char.IsLetter(caracter)) && !(char.IsWhiteSpace(caracter)))
                {
                    return false;
                }

                if ((char.IsNumber(caracter)) && !(char.IsLetter(caracter)))
                {
                    return false;
                }

            }
                return true;
            
        }

        private bool sololetras2(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsLetter(caracter)) && (char.IsNumber(caracter)))
                {
                    return false;
                }
            }
            return true;

        }

    }
}
