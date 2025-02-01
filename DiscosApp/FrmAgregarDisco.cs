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

namespace DiscosApp
{
    public partial class FrmAgregarDisco : Form
    {
        public FrmAgregarDisco()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Disco disco = new Disco();

            try
            {
                disco.Titulo = txtbTitulo.Text;
                disco.CantidadCanciones = int.Parse(txtbCantidadCanciones.Text);
                disco.FechaLanzamiento = dtpFechaLanzamiento.Value;
                disco.UrlImagen = txtbUrlImagen.Text;
                disco.Estilo = (DatoDisco)cboxEstilo.SelectedItem;
                disco.Edicion = (DatoDisco)cboxEstilo.SelectedItem;


                DiscoNegocio negocio = new DiscoNegocio();
                negocio.Agregar(disco);
                MessageBox.Show("Disco ingresado correctamente");
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
            

        private void FrmAgregarDisco_Load(object sender, EventArgs e)
        {
            EstiloNegocio estiloNegocio = new EstiloNegocio();
            EdicionNegocio edicionNegocio = new EdicionNegocio();
            try
            {
                cboxEstilo.DataSource = estiloNegocio.Listar();
                cboxEdicion.DataSource = edicionNegocio.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void txtbUrlImagen_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtbUrlImagen.Text);
        }

        public void CargarImagen(string urlImagen)
        {
            try
            {
                pboxUrlImagen.Load(urlImagen);
            }
            catch (Exception ex)
            {
                pboxUrlImagen.Load("https://camarasal.com/wp-content/uploads/2020/08/default-image-5-1.jpg");
            }

        }
    }
}
