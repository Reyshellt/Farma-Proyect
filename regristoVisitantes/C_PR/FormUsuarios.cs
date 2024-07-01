using C_Entidades;
using C_LN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_PR
{
    public partial class FormUsuarios : Form
    {
        private readonly UsuarioController usuarioController = new UsuarioController();

        public FormUsuarios()
        {
            InitializeComponent();

            dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUser.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvUser.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void LimpiarCampos()
        {
            textIdUser.Text = "";
            textNombre.Text = "";
            textApellido.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now;
            textNombreUser.Text = "";
            textUserClave.Text = "";
            rbGeneral.Checked = true;

            // Limpia el origen de datos del DataGridView
            dgvUser.DataSource = null;
        }


        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // Recupera los datos de los controles del formulario
            string nombre = textNombre.Text;
            string apellido = textApellido.Text;
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            string nombreUsuario = textNombreUser.Text;
            string clave = textUserClave.Text;
            string tipoUsuario = rbGeneral.Checked ? "General" : "Administrador";

            // Inserta el nuevo usuario en la base de datos
            usuarioController.InsertarUsuario(nombre, apellido, fechaNacimiento, nombreUsuario, clave, tipoUsuario);

            // Limpia los campos del formulario
            LimpiarCampos();
            CargarUsuarios();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textNombre.Text;
            Usuario usuario = usuarioController.ObtenerUsuarioPorNombre(nombreUsuario);

            if (usuario != null)
            {
                // Mostrar la información del usuario en los controles del formulario
                MostrarInformacionUsuario(usuario);
                //CargarUsuarios();
            }
            else
            {
                // Usuario no encontrado, muestra un mensaje o limpia los controles
                LimpiarCampos();
                MessageBox.Show("Usuario no encontrado.");
                CargarUsuarios();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Recupera los datos de los controles del formulario
            int idUsuario = Convert.ToInt32(textIdUser.Text);
            string nombre = textNombre.Text;
            string apellido = textApellido.Text;
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            string nombreUsuario = textNombreUser.Text;
            string clave = textUserClave.Text;
            string tipoUsuario = rbGeneral.Checked ? "General" : "Administrador";

            // Modifica el usuario en la base de datos
            usuarioController.ModificarUsuario(idUsuario, nombre, apellido, fechaNacimiento, nombreUsuario, clave, tipoUsuario);

            // Limpia los campos del formulario
            LimpiarCampos();
            CargarUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Recupera el ID del usuario a eliminar
            int idUsuario = Convert.ToInt32(textIdUser.Text);

            // Elimina el usuario de la base de datos
            usuarioController.EliminarUsuario(idUsuario);

            // Limpia los campos del formulario
            LimpiarCampos();
            CargarUsuarios();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpia los campos del formulario
            LimpiarCampos();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            // Obtiene los datos de todos los usuarios
            DataTable dataTable = usuarioController.ObtenerTodosLosUsuarios();

            // Asigna la DataTable como origen de datos del DataGridView
            dgvUser.DataSource = dataTable;
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void MostrarInformacionUsuario(Usuario usuario)
        {
            textIdUser.Text = usuario.UsuarioID.ToString();
            textNombre.Text = usuario.Nombre;
            textApellido.Text = usuario.Apellido;
            dtpFechaNacimiento.Value = usuario.FechaNacimiento;
            textNombreUser.Text = usuario.Username;
            textUserClave.Text = usuario.Clave;
            rbGeneral.Checked = (usuario.TipoUsuario == "General");
            rbAdministrador.Checked = (usuario.TipoUsuario == "Administrador");
        }
    }
}

