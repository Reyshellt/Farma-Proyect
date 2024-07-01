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
    public partial class FormEdificios : Form
    {
        private readonly EdificioController edificioController = new EdificioController();

        public FormEdificios()
        {
            InitializeComponent();

            dgvEdificios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEdificios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEdificios.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = textNombre.Text;
            DataTable dataTable = edificioController.BuscarEdificioPorNombre(nombre);
            dgvEdificios.DataSource = dataTable;

            // Si hay al menos un resultado, llenar los TextBox con los datos del primer resultado
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                textEdificioId.Text = row["EdificioID"].ToString();
                textNombre.Text = row["Nombre"].ToString();
            }
            else
            {
                LimpiarCampos();
                MessageBox.Show("No se encontraron edificios con ese nombre.");
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string nombre = textNombre.Text;
            edificioController.InsertarEdificio(nombre);
            LimpiarCampos();
            CargarDatosEdificios();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idEdificio = ObtenerIdSeleccionado();
            if (idEdificio != -1)
            {
                string nombre = textNombre.Text;
                edificioController.ModificarEdificio(idEdificio, nombre);
                LimpiarCampos();
            }
            CargarDatosEdificios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEdificio = ObtenerIdSeleccionado();
            if (idEdificio != -1)
            {
                edificioController.EliminarEdificio(idEdificio);
                LimpiarCampos();
            }
            CargarDatosEdificios();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textEdificioId.Clear();
            textNombre.Clear();
        }

        private void FormEdificios_Load(object sender, EventArgs e)
        {
            CargarDatosEdificios();
        }
        private void CargarDatosEdificios()
        {
            DataTable dataTable = edificioController.ObtenerTodosLosEdificios();
            dgvEdificios.DataSource = dataTable;
        }

        private int ObtenerIdSeleccionado()
        {
            if (dgvEdificios.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvEdificios.SelectedRows[0].Cells["EdificioID"].Value);
            }
            else if (!string.IsNullOrEmpty(textEdificioId.Text))
            {
                return Convert.ToInt32(textEdificioId.Text);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un edificio o ingrese un ID.");
                return -1;
            }
        }
    }
}
