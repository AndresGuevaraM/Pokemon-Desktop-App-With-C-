using AccesoDatosSQL;
using DominioClases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_De_Datos
{
    public partial class DetalleArticulo: Form
    {
        private int IdArticulo;
        private List<Articulos> DataIdArticulo;
        public DetalleArticulo()
        {
            InitializeComponent();
        }

        public DetalleArticulo(int Idarticulo)
        {
            InitializeComponent();
            this.IdArticulo = Idarticulo;
        }

        private void DetalleArticulo_Load(object sender, EventArgs e)
        {
            ArticulosSQL data = new ArticulosSQL();
            data.IdArticulo = IdArticulo;
            DataIdArticulo=data.LDetalleArticulo();
            Codigo.Text = DataIdArticulo[0].Codigo;
            Nombre.Text = DataIdArticulo[0].Nombre;
            Descripcion.Text = DataIdArticulo[0].Descripcion;
            Marca.Text = DataIdArticulo[0].Marca.Descripcion;
            Categoria.Text = DataIdArticulo[0].Categoria.Descripcion;
            Precio.Text = DataIdArticulo[0].Precio.ToString();
            ImagenNURL.Text = DataIdArticulo[0].ImagenUrl;
            cargarImagen(ImagenNURL.Text);
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
    }
}
