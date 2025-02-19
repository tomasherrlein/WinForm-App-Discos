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
using System.IO;

namespace DiscosApp
{
    public partial class FrmEjecutarAccion : Form
    {
        private Disco disco = null;
        private OpenFileDialog archivo = null;
        private string rutaImagenes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes");
        public FrmEjecutarAccion()
        {
            InitializeComponent();
        }

        public FrmEjecutarAccion(Disco disco)
        {
            InitializeComponent();
            this.disco = disco;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                //Guardo imagen localmente en carpeta "Imagenes"
                if (archivo != null && !txtbUrlImagen.Text.ToLower().Contains("http"))
                {
                    string rutaImagen = Path.Combine(rutaImagenes, archivo.SafeFileName);
                    File.Copy(archivo.FileName, rutaImagen, true);
                    txtbUrlImagen.Text = rutaImagen;
                }

                if (disco == null)
                    disco = new Disco();

                disco.Titulo = txtbTitulo.Text;
                disco.CantidadCanciones = int.Parse(txtbCantidadCanciones.Text);
                disco.FechaLanzamiento = dtpFechaLanzamiento.Value;
                disco.UrlImagen = txtbUrlImagen.Text;
                disco.Estilo = (DatoDisco)cboxEstilo.SelectedItem;
                disco.Edicion = (DatoDisco)cboxEdicion.SelectedItem;


                

                DiscoNegocio negocio = new DiscoNegocio();
                if (disco.Id != 0)
                {
                    negocio.Modificar(disco);
                    MessageBox.Show("Disco modificado correctamente");
                }
                else
                {
                    negocio.Agregar(disco);
                    MessageBox.Show("Disco ingresado correctamente");
                }
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
            cboxEstilo.ValueMember = "Id";
            cboxEstilo.DisplayMember = "Descripcion";

            EdicionNegocio edicionNegocio = new EdicionNegocio();
            cboxEdicion.ValueMember = "Id";
            cboxEdicion.DisplayMember = "Descripcion";

            try
            {
                cboxEstilo.DataSource = estiloNegocio.Listar();
                
                cboxEdicion.DataSource = edicionNegocio.Listar();

                // Precargar los datos de la ventana si se quiere modificar un disco
                if (disco != null)
                {
                    txtbTitulo.Text = disco.Titulo;
                    dtpFechaLanzamiento.Value = disco.FechaLanzamiento;
                    txtbCantidadCanciones.Text = disco.CantidadCanciones.ToString();
                    CargarImagen(disco.UrlImagen);
                    txtbUrlImagen.Text = disco.UrlImagen;
                    cboxEstilo.SelectedValue = disco.Estilo.Id;
                    cboxEdicion.SelectedValue = disco.Edicion.Id;
                }

                //Crea la carpeta "Imagenes" si no existe
                if (!Directory.Exists(rutaImagenes))
                    Directory.CreateDirectory(rutaImagenes);

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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            string rutaImagenes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes");
            archivo = new OpenFileDialog();
            archivo.Filter = "Imágenes (*.jpg, *.png)|*.jpg;*.png";
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtbUrlImagen.Text = archivo.FileName;
                CargarImagen(archivo.FileName);
            }
        }
    }
}
