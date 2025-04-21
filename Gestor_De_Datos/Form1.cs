using AccesoDatosSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DominioClases;

namespace Gestor_De_Datos
{
    public partial class GestorDeDatos: Form
    {
        private List<Articulos> listaArticulos;
        public GestorDeDatos()
        {
            InitializeComponent();
        }

        private void GestorDeDatos_Load(object sender, EventArgs e)
        {
            
            CboxCampo.Items.Add("Codigo");
            CboxCampo.Items.Add("Nombre");
            CboxCampo.Items.Add("Marca");
            CboxCampo.Items.Add("Categoria");
            CboxCampo.Items.Add("Descripcion");
            cargar();
        }

        private void ListadoArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (ListadoArticulos.CurrentRow != null)
            {
                Articulos seleccionado = (Articulos)ListadoArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.ImagenUrl);
            }
        }

        private void cargar()
        {
            ArticulosSQL data = new ArticulosSQL();
            try
            {
                listaArticulos = data.Listar();
                ListadoArticulos.DataSource = listaArticulos;
                ocultarColumnas();
                cargarImagen(listaArticulos[0].ImagenUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            ListadoArticulos.Columns["ImagenUrl"].Visible = false;
            ListadoArticulos.Columns["Id"].Visible = false;
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                ImagenArticulo.Load(imagen);
            }
            catch
            {
                ImagenArticulo.Load("https://socialistmodernism.com/wp-content/uploads/2017/07/placeholder-image.png");
            }
        }
        // funcion para que al hacer click en buscar el filtro por criterio y campo obtenga la busqueda del usuario y las opciones seleccionadas en los  combobox, para que con ello  se los proporcione al metodo filtrar de la clase que maneja el  flujo de la DB y dependiendo de ello se actualice la lista de datos. 
        private void Buscar_Click(object sender, EventArgs e)
        {
            ArticulosSQL buscar = new ArticulosSQL();
            try
            {
                if (validarfiltro())
                {
                    return;
                }
                string campo = CboxCampo.SelectedItem.ToString();
                string criterio = CboxKeyWord.SelectedItem.ToString();
                string filtro = Buscador.Text;
                ListadoArticulos.DataSource = buscar.Filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }

        private void EliminarArticulo_Click(object sender, EventArgs e)
        {
            Articulos seleccionado = (Articulos)ListadoArticulos.CurrentRow.DataBoundItem;
            ArticulosSQL Delete = new ArticulosSQL();
            try
            {
                // El MessageBox devuelve una respuesta de tipo Dialog Result, por lo que con el mismo se puede guardar esta en una variable.
                DialogResult res = MessageBox.Show(" Confirma la eliminacion?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // condicional para evaluar si se confirma la eliminacion del articulo o no.

                if (res == DialogResult.Yes)
                {
                    Delete.Eliminar(seleccionado.Id);

                }
                cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void ModificarArticulo_Click(object sender, EventArgs e)
        {
            // obtiene toda la info de la fila actual del articulo.
            Articulos seleccionado = (Articulos)ListadoArticulos.CurrentRow.DataBoundItem;

            // se crea la instancia para editar el articulo haciendo uso del 2 constructor (reutilizado) de la venta NuevoArticulo.
            NuevoArticulo EditArti = new NuevoArticulo(seleccionado);
            EditArti.ShowDialog();
            cargar();

        }

        private void AgregarArticulo_Click(object sender, EventArgs e)
        {
            NuevoArticulo nuevoarticulo = new NuevoArticulo();
            nuevoarticulo.ShowDialog();
            cargar();

        }
        // Evento utilizado en el Combobox para que suceden cosas dependiendo la seleccion de opcion  del usuario, en este caso segun lo que elija el  2 combobox tendra diferentes opciones.
        private void CboxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = CboxCampo.SelectedItem.ToString();

            if (opcion == "Codigo")
            {
                CboxKeyWord.Items.Clear();
                CboxKeyWord.Items.Add("Inicia con la letra o numero...");
                CboxKeyWord.Items.Add("Finaliza con la letra o numero...");
                CboxKeyWord.Items.Add("Contiene la letra o numero...");

            }
            else
            {
                CboxKeyWord.Items.Clear();
                CboxKeyWord.Items.Add("Inicia con las letras...");
                CboxKeyWord.Items.Add("Finaliza con las letras...");
                CboxKeyWord.Items.Add("Contiene las letras...");

            }

        }

        // Funcion que realiza diferentes validaciones basandose en si lo que esta sucediendo es verdadero o falso. En  caso de que todo este bien se retorna false porque no se dio el error por asi decirlo, y en las condiciones donde se evalua el mismo si se da sera true porque es verdadero el error.
        private bool validarfiltro()
        {
            // el selectedIndex es una coleccion que evalua los indices para saber si hay opciones seleccionadas en los combobox, si es menor a cero es porque no hubo seleccion, cuando se selecciona la primera opcion por ejemplo sera 1.
            if (CboxCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione un campo, para con ello poder filtrar, gracias.");
                return true;
            }

            if (CboxKeyWord.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione un criterio, para con ello poder filtrar, gracias.");
                return true;

            }

            if (Buscador.Text == "")
            {
                
                MessageBox.Show("Por favor escriba en el buscador, para con ello poder filtrar, gracias.");
                return true;          
            }

            return false;

        }

        // Funcion para que se muestren todos los articulos de la tabla cuando la persona borre completamente el buscador, esto para que pueda visualizar nuevamente todo y hacer mas facil una nueva busqueda por criterio.
        private void Buscador_TextChanged(object sender, EventArgs e)
        {
            string filtro = Buscador.Text;
            if (filtro.Length < 1)
            {
                ListadoArticulos.DataSource = null;
                ListadoArticulos.DataSource = listaArticulos;
                ocultarColumnas();
            }
        }

        private void DetalleArticulo_Click(object sender, EventArgs e)
        {
            Articulos IdArticulo = new Articulos();
            // se crea la instancia para ver el detalle del articulo haciendo uso de un constructor de la ventana DetalleArticulo que espera un int, en este caso corresponde al id del articulo que se desea ver a detalle.
            DetalleArticulo DetArti = new DetalleArticulo(IdArticulo.Id = int.Parse(DetalleId.Text));
            DetArti.ShowDialog();
            cargar();
            DetalleId.Text = null;

        }
    }
}
