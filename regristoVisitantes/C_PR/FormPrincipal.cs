using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C_Entidades;
using C_Entidades.cache;

namespace C_PR
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void aaa1_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de cerrar la Aplicacion?", "Cuidado",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible=true;
            
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void barraTitulo_Paint(object sender, PaintEventArgs e)
        {
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int Param);

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0xA1, 0x2, 0);
        }

        private void abrirFormHija(Form formHija)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                // Verificar si el formulario a abrir es diferente al que ya está abierto
                if (this.panelContenedor.Controls[0] != formHija)
                {
                    this.panelContenedor.Controls.RemoveAt(0);
                }
                else
                {
                    // Si es el mismo formulario, no hacemos nada y salimos del método
                    return;
                }
            }

            formHija.TopLevel = false;
            formHija.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(formHija);
            this.panelContenedor.Tag = formHija;
            formHija.Show();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            abrirFormHija(new FormUsuarios());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de cerrar la sesión?", "Cuidado",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
                this.Close();
        }

        private void loadUserData()
        {
            lblNombre.Text = cacheUserLogin.Nombre;
            lblApellido.Text = cacheUserLogin.Apellido;
            lblTipo.Text = cacheUserLogin.TipoUsuario;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            loadUserData();

            if(cacheUserLogin.TipoUsuario == cargos.General)
            {
                btnEdificios.Enabled = false;
                btnAulas.Enabled = false;
                btnUsuario.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            abrirFormHija(new FormVisitas());
        }

        private void btnEdificios_Click(object sender, EventArgs e)
        {
            abrirFormHija(new FormEdificios());
        }

        private void btnVisitantes_Click(object sender, EventArgs e)
        {
            abrirFormHija(new FormVisitantes());
        }

        private void btnAulas_Click(object sender, EventArgs e)
        {
            abrirFormHija(new FormAulas());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirFormHija(new FormEstadistica());
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
