namespace Gestor_De_Datos
{
    partial class GestorDeDatos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelBuscador = new System.Windows.Forms.Label();
            this.Buscador = new System.Windows.Forms.TextBox();
            this.Buscar = new System.Windows.Forms.Button();
            this.labelListadoArticulos = new System.Windows.Forms.Label();
            this.ListadoArticulos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.labelImagen = new System.Windows.Forms.Label();
            this.ImagenArticulo = new System.Windows.Forms.PictureBox();
            this.AgregarArticulo = new System.Windows.Forms.Button();
            this.EliminarArticulo = new System.Windows.Forms.Button();
            this.ModificarArticulo = new System.Windows.Forms.Button();
            this.labelBusquedaEspecifica = new System.Windows.Forms.Label();
            this.labelCampo = new System.Windows.Forms.Label();
            this.labelCriterio = new System.Windows.Forms.Label();
            this.CboxCampo = new System.Windows.Forms.ComboBox();
            this.CboxKeyWord = new System.Windows.Forms.ComboBox();
            this.labelFiltro = new System.Windows.Forms.Label();
            this.DetalleId = new System.Windows.Forms.TextBox();
            this.labelDetalleArticulo = new System.Windows.Forms.Label();
            this.DetalleArticulo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ListadoArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBuscador
            // 
            this.labelBuscador.AutoSize = true;
            this.labelBuscador.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuscador.Location = new System.Drawing.Point(269, 67);
            this.labelBuscador.Name = "labelBuscador";
            this.labelBuscador.Size = new System.Drawing.Size(0, 23);
            this.labelBuscador.TabIndex = 0;
            // 
            // Buscador
            // 
            this.Buscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buscador.Location = new System.Drawing.Point(529, 111);
            this.Buscador.Name = "Buscador";
            this.Buscador.Size = new System.Drawing.Size(250, 20);
            this.Buscador.TabIndex = 2;
            this.Buscador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Buscador.TextChanged += new System.EventHandler(this.Buscador_TextChanged);
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(831, 111);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(67, 24);
            this.Buscar.TabIndex = 3;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // labelListadoArticulos
            // 
            this.labelListadoArticulos.AutoSize = true;
            this.labelListadoArticulos.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListadoArticulos.Location = new System.Drawing.Point(270, 181);
            this.labelListadoArticulos.Name = "labelListadoArticulos";
            this.labelListadoArticulos.Size = new System.Drawing.Size(166, 21);
            this.labelListadoArticulos.TabIndex = 3;
            this.labelListadoArticulos.Text = "Listado de Artículos";
            // 
            // ListadoArticulos
            // 
            this.ListadoArticulos.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.ListadoArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListadoArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ListadoArticulos.Location = new System.Drawing.Point(62, 216);
            this.ListadoArticulos.Name = "ListadoArticulos";
            this.ListadoArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListadoArticulos.Size = new System.Drawing.Size(600, 343);
            this.ListadoArticulos.TabIndex = 4;
            this.ListadoArticulos.SelectionChanged += new System.EventHandler(this.ListadoArticulos_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(779, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 21);
            this.label1.TabIndex = 5;
            // 
            // labelImagen
            // 
            this.labelImagen.AutoSize = true;
            this.labelImagen.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImagen.Location = new System.Drawing.Point(827, 181);
            this.labelImagen.Name = "labelImagen";
            this.labelImagen.Size = new System.Drawing.Size(132, 21);
            this.labelImagen.TabIndex = 6;
            this.labelImagen.Text = "Imagen Artículo";
            // 
            // ImagenArticulo
            // 
            this.ImagenArticulo.Location = new System.Drawing.Point(735, 216);
            this.ImagenArticulo.Name = "ImagenArticulo";
            this.ImagenArticulo.Size = new System.Drawing.Size(345, 343);
            this.ImagenArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagenArticulo.TabIndex = 7;
            this.ImagenArticulo.TabStop = false;
            // 
            // AgregarArticulo
            // 
            this.AgregarArticulo.Location = new System.Drawing.Point(62, 586);
            this.AgregarArticulo.Name = "AgregarArticulo";
            this.AgregarArticulo.Size = new System.Drawing.Size(92, 27);
            this.AgregarArticulo.TabIndex = 4;
            this.AgregarArticulo.Text = "Agregar Articulo";
            this.AgregarArticulo.UseVisualStyleBackColor = true;
            this.AgregarArticulo.Click += new System.EventHandler(this.AgregarArticulo_Click);
            // 
            // EliminarArticulo
            // 
            this.EliminarArticulo.Location = new System.Drawing.Point(305, 586);
            this.EliminarArticulo.Name = "EliminarArticulo";
            this.EliminarArticulo.Size = new System.Drawing.Size(92, 27);
            this.EliminarArticulo.TabIndex = 6;
            this.EliminarArticulo.Text = "Eliminar Articulo";
            this.EliminarArticulo.UseVisualStyleBackColor = true;
            this.EliminarArticulo.Click += new System.EventHandler(this.EliminarArticulo_Click);
            // 
            // ModificarArticulo
            // 
            this.ModificarArticulo.Location = new System.Drawing.Point(178, 586);
            this.ModificarArticulo.Name = "ModificarArticulo";
            this.ModificarArticulo.Size = new System.Drawing.Size(101, 27);
            this.ModificarArticulo.TabIndex = 5;
            this.ModificarArticulo.Text = "Modificar Articulo";
            this.ModificarArticulo.UseVisualStyleBackColor = true;
            this.ModificarArticulo.Click += new System.EventHandler(this.ModificarArticulo_Click);
            // 
            // labelBusquedaEspecifica
            // 
            this.labelBusquedaEspecifica.AutoSize = true;
            this.labelBusquedaEspecifica.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBusquedaEspecifica.Location = new System.Drawing.Point(58, 48);
            this.labelBusquedaEspecifica.Name = "labelBusquedaEspecifica";
            this.labelBusquedaEspecifica.Size = new System.Drawing.Size(183, 21);
            this.labelBusquedaEspecifica.TabIndex = 11;
            this.labelBusquedaEspecifica.Text = "Busqueda Especifica:";
            // 
            // labelCampo
            // 
            this.labelCampo.AutoSize = true;
            this.labelCampo.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCampo.Location = new System.Drawing.Point(58, 81);
            this.labelCampo.Name = "labelCampo";
            this.labelCampo.Size = new System.Drawing.Size(72, 21);
            this.labelCampo.TabIndex = 12;
            this.labelCampo.Text = "Campo:";
            // 
            // labelCriterio
            // 
            this.labelCriterio.AutoSize = true;
            this.labelCriterio.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCriterio.Location = new System.Drawing.Point(285, 81);
            this.labelCriterio.Name = "labelCriterio";
            this.labelCriterio.Size = new System.Drawing.Size(128, 21);
            this.labelCriterio.TabIndex = 13;
            this.labelCriterio.Text = "Palabra Clave:";
            // 
            // CboxCampo
            // 
            this.CboxCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxCampo.FormattingEnabled = true;
            this.CboxCampo.Location = new System.Drawing.Point(62, 111);
            this.CboxCampo.Name = "CboxCampo";
            this.CboxCampo.Size = new System.Drawing.Size(176, 21);
            this.CboxCampo.TabIndex = 0;
            this.CboxCampo.SelectedIndexChanged += new System.EventHandler(this.CboxCampo_SelectedIndexChanged);
            // 
            // CboxKeyWord
            // 
            this.CboxKeyWord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxKeyWord.FormattingEnabled = true;
            this.CboxKeyWord.Location = new System.Drawing.Point(289, 111);
            this.CboxKeyWord.Name = "CboxKeyWord";
            this.CboxKeyWord.Size = new System.Drawing.Size(176, 21);
            this.CboxKeyWord.TabIndex = 1;
            // 
            // labelFiltro
            // 
            this.labelFiltro.AutoSize = true;
            this.labelFiltro.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFiltro.Location = new System.Drawing.Point(525, 81);
            this.labelFiltro.Name = "labelFiltro";
            this.labelFiltro.Size = new System.Drawing.Size(55, 21);
            this.labelFiltro.TabIndex = 16;
            this.labelFiltro.Text = "Filtro:";
            // 
            // DetalleId
            // 
            this.DetalleId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetalleId.Location = new System.Drawing.Point(662, 586);
            this.DetalleId.Name = "DetalleId";
            this.DetalleId.Size = new System.Drawing.Size(79, 20);
            this.DetalleId.TabIndex = 7;
            this.DetalleId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelDetalleArticulo
            // 
            this.labelDetalleArticulo.AutoSize = true;
            this.labelDetalleArticulo.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetalleArticulo.Location = new System.Drawing.Point(403, 586);
            this.labelDetalleArticulo.Name = "labelDetalleArticulo";
            this.labelDetalleArticulo.Size = new System.Drawing.Size(243, 21);
            this.labelDetalleArticulo.TabIndex = 18;
            this.labelDetalleArticulo.Text = "Ver detalle de un Articulo (Id):";
            // 
            // DetalleArticulo
            // 
            this.DetalleArticulo.Location = new System.Drawing.Point(759, 582);
            this.DetalleArticulo.Name = "DetalleArticulo";
            this.DetalleArticulo.Size = new System.Drawing.Size(92, 27);
            this.DetalleArticulo.TabIndex = 8;
            this.DetalleArticulo.Text = "Ver Articulo";
            this.DetalleArticulo.UseVisualStyleBackColor = true;
            this.DetalleArticulo.Click += new System.EventHandler(this.DetalleArticulo_Click);
            // 
            // GestorDeDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1145, 686);
            this.Controls.Add(this.DetalleArticulo);
            this.Controls.Add(this.labelDetalleArticulo);
            this.Controls.Add(this.DetalleId);
            this.Controls.Add(this.labelFiltro);
            this.Controls.Add(this.CboxKeyWord);
            this.Controls.Add(this.CboxCampo);
            this.Controls.Add(this.labelCriterio);
            this.Controls.Add(this.labelCampo);
            this.Controls.Add(this.labelBusquedaEspecifica);
            this.Controls.Add(this.ModificarArticulo);
            this.Controls.Add(this.EliminarArticulo);
            this.Controls.Add(this.AgregarArticulo);
            this.Controls.Add(this.ImagenArticulo);
            this.Controls.Add(this.labelImagen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListadoArticulos);
            this.Controls.Add(this.labelListadoArticulos);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.Buscador);
            this.Controls.Add(this.labelBuscador);
            this.Name = "GestorDeDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor De Datos";
            this.Load += new System.EventHandler(this.GestorDeDatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListadoArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBuscador;
        private System.Windows.Forms.TextBox Buscador;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.Label labelListadoArticulos;
        private System.Windows.Forms.DataGridView ListadoArticulos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelImagen;
        private System.Windows.Forms.PictureBox ImagenArticulo;
        private System.Windows.Forms.Button AgregarArticulo;
        private System.Windows.Forms.Button EliminarArticulo;
        private System.Windows.Forms.Button ModificarArticulo;
        private System.Windows.Forms.Label labelBusquedaEspecifica;
        private System.Windows.Forms.Label labelCampo;
        private System.Windows.Forms.Label labelCriterio;
        private System.Windows.Forms.ComboBox CboxCampo;
        private System.Windows.Forms.ComboBox CboxKeyWord;
        private System.Windows.Forms.Label labelFiltro;
        private System.Windows.Forms.TextBox DetalleId;
        private System.Windows.Forms.Label labelDetalleArticulo;
        private System.Windows.Forms.Button DetalleArticulo;
    }
}

