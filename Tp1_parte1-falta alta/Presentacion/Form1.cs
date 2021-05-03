using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Presentacion
{
    public partial class Form1 : Form

    {

        private List<Articulo> listaArticulo;




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            cargarGrilla();
        }


        private void cargarGrilla()
        {


            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            try
            {

                listaArticulo = articuloNegocio.listar();
                dgvArticulo.DataSource = listaArticulo;

                //dgvArticulo.Columns["Descripcion"].Visible = false;

                RecargarImg(listaArticulo[0].UrlImagen);



            }

            catch (Exception ex)
            {


                MessageBox.Show(ex.ToString());
            }


        }


        private void RecargarImg(string img)
        {
            
            pbxArticulo.Load(img);

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmArticulo agregar = new frmArticulo();
            agregar.ShowDialog();
            cargarGrilla();




        }

        //evento
        private void dgvArticulo_MouseClick(object sender, MouseEventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
            RecargarImg(seleccionado.UrlImagen);

        }
    }
}
