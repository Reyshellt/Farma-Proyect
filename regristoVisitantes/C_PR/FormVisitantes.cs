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
    public partial class FormVisitantes : Form
    {
        private readonly VisitanteController visitanteController = new VisitanteController();

        public FormVisitantes()
        {
            InitializeComponent();

            dgvVisitantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVisitantes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvVisitantes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = textNombre.Text;
            DataTable dataTable = visitanteController.BuscarVisitantePorNombre(nombre);
            dgvVisitantes.DataSource = dataTable;

            // Si hay al menos un resultado, llenar los TextBox con los datos del primer resultado
            if (dataTable.Rows.Count > 0)
            {
                LlenarTextBoxConDatos(dataTable.Rows[0]);
            }
            else
            {
                LimpiarCampos();
                MessageBox.Show("No se encontraron visitantes con ese nombre.");
            }
        }

        private void LlenarTextBoxConDatos(DataRow row)
        {
            textIdVisitante.Text = row["VisitanteID"].ToString();
            textNombre.Text = row["Nombre"].ToString();
            textApellido.Text = row["Apellido"].ToString();
            textCarrera.Text = row["Carrera"].ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textNombre.Text;
            string apellido = textApellido.Text;
            string carrera = textCarrera.Text;
            visitanteController.InsertarVisitante(nombre, apellido, carrera);
            LimpiarCampos();
            CargarDatosVisitantes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idVisitante = ObtenerIdSeleccionado();
            if (idVisitante != -1)
            {
                string nombre = textNombre.Text;
                string apellido = textApellido.Text;
                string carrera = textCarrera.Text;
                visitanteController.ModificarVisitante(idVisitante, nombre, apellido, carrera);
                LimpiarCampos();
                CargarDatosVisitantes();
            }
            CargarDatosVisitantes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idVisitante = ObtenerIdSeleccionado();
            if (idVisitante != -1)
            {
                visitanteController.EliminarVisitante(idVisitante);
                LimpiarCampos();
                MessageBox.Show("El visitante ha sido eliminado correctamente.");
            }
            CargarDatosVisitantes();
        }

        private int ObtenerIdSeleccionado()
        {
            if (dgvVisitantes.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvVisitantes.SelectedRows[0].Cells["VisitanteID"].Value);
            }
            else if (!string.IsNullOrEmpty(textIdVisitante.Text))
            {
                return Convert.ToInt32(textIdVisitante.Text);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un visitante o realice una búsqueda.");
                return -1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textNombre.Text = "";
            textApellido.Text = "";
            textCarrera.Text = "";
            textIdVisitante.Text = "";
        }

        private void FormVisitantes_Load(object sender, EventArgs e)
        {
            CargarDatosVisitantes();
        }

        private void CargarDatosVisitantes()
        {
            DataTable dataTable = visitanteController.ObtenerTodosLosVisitantes();
            dgvVisitantes.DataSource = dataTable;
        }
    }
}
