using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejemplo_ado_net
{
    public partial class FrmDiscos : Form
    {
        private List<Disco> discos = new List<Disco>();
        public FrmDiscos()
        {
            InitializeComponent();
        }

        private void FrmDiscos_Load(object sender, EventArgs e)
        {
            DiscoNegocio discoNegocio = new DiscoNegocio();
            discos = discoNegocio.Listar();
            dgvDiscos.DataSource = discos;
            dgvDiscos.Columns["UrlImagen"].Visible = false;
            dgvDiscos.Columns["CantidadCanciones"].HeaderText = "Cantidad de canciones";
            CargarImagen(discos[0].UrlImagen);
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Disco seleccion = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            CargarImagen(seleccion.UrlImagen);
        }

        public void CargarImagen (string urlImagen)
        {
            try
            {
                pbxImagenDisco.Load(urlImagen);
            }
            catch (Exception ex)
            {
                pbxImagenDisco.Load("https://camarasal.com/wp-content/uploads/2020/08/default-image-5-1.jpg");
            }
            
        }
    }
}
