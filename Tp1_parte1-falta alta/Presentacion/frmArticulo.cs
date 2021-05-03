using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace Presentacion
{
    public partial class frmArticulo : Form
    {
        public frmArticulo()
        {
            InitializeComponent();
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {


            MarcaNegocio marcaNegocio = new MarcaNegocio();

            CategoriaNegocio categoriaNegocia = new CategoriaNegocio();

            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboCategoria.DataSource = categoriaNegocia.listar();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }




        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {


            Articulo nuevo = new Articulo();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            try
            {
                nuevo.CodigoArticulo = txtCodigoArticulo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;

                nuevo.marca = (Marca)cboMarca.SelectedItem;
                nuevo.categoria = (Categoria)cboCategoria.SelectedItem;

                nuevo.UrlImagen = txtUrlImagen.Text;

                nuevo.Precio = decimal.Parse(txtPrecio.Text);
            

                articuloNegocio.agregar(nuevo);
                MessageBox.Show("Agregado sin problemas");
                Close();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
          



        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
