using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscosApp;
using Dominio;
using Negocio;


namespace ejemplo_ado_net
{
    public partial class FrmDisco : Form
    {
        private List<Disco> discos = new List<Disco>();
        public FrmDisco()
        {
            InitializeComponent();
        }

        private void FrmDisco_Load(object sender, EventArgs e)
        {
            CargarDgv();
        }

        private void CargarDgv ()
        {
            DiscoNegocio discoNegocio = new DiscoNegocio();
            try
            {
                discos = discoNegocio.Listar();
                dgvDiscos.DataSource = discos;
                dgvDiscos.Columns["UrlImagen"].Visible = false;
                CargarImagen(discos[0].UrlImagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Disco seleccion = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            CargarImagen(seleccion.UrlImagen);
        }

        public void CargarImagen(string urlImagen)
        {
            try
            {
                pbxImagen.Load(urlImagen);
            }
            catch (Exception ex)
            {
                pbxImagen.Load("https://camarasal.com/wp-content/uploads/2020/08/default-image-5-1.jpg");
            }

        }

        private void btnAgregarDisco_Click(object sender, EventArgs e)
        {
            FrmEjecutarAccion ventanaAgregar = new FrmEjecutarAccion();
            ventanaAgregar.ShowDialog();
            CargarDgv();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Disco discoSeleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            FrmEjecutarAccion ventanaModificar = new FrmEjecutarAccion(discoSeleccionado);
            ventanaModificar.Text = "Modificar disco";
            ventanaModificar.ShowDialog();
            CargarDgv();
        }

        private void btnEliminacionFisica_Click(object sender, EventArgs e)
        {
            Eliminar(logico: false);
        }

        private void btnEliminacionLogica_Click(object sender, EventArgs e)
        {
            Eliminar(logico: true);
        }

        public void Eliminar (bool logico = true)
        {
            DialogResult respuesta = MessageBox.Show("Estas seguro de que queres eliminar el disco?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Disco discoSeleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                DiscoNegocio negocio = new DiscoNegocio();

                if (logico)
                    negocio.EliminarLogico(discoSeleccionado.Id);
                else
                    negocio.EliminarFisico(discoSeleccionado.Id);

                CargarDgv();
            }
        }
    }
}
