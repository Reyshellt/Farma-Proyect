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
    public partial class FormAulas : Form
    {
        private readonly AulaController aulaController = new AulaController();
        private readonly EdificioController edificioController = new EdificioController();

        public FormAulas()
        {
            InitializeComponent();
            CargarComboBoxEdificios();
            CargarDatosAulas();

            dgvAulas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAulas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAulas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
        private void CargarComboBoxEdificios()
        {
            DataTable dataTable = edificioController.ObtenerTodosLosEdificios();
            cmbEdificios.DisplayMember = "Nombre";
            cmbEdificios.ValueMember = "EdificioID";
            cmbEdificios.DataSource = dataTable;
        }

        private void CargarDatosAulas()
        {
            DataTable dataTable = aulaController.ObtenerTodasLasAulas();
            dgvAulas.DataSource = dataTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textAulaId.Text))
            {
                int idAula = Convert.ToInt32(textAulaId.Text);
                aulaController.EliminarAula(idAula);
                LimpiarCampos();
                CargarDatosAulas();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de aula válido.");
            }
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreAula = textNombreAula.Text;
            DataTable dataTable = aulaController.BuscarAulaPorNombre(nombreAula);
            dgvAulas.DataSource = dataTable;

            // Obtener el ID del primer aula encontrada
            if (dataTable.Rows.Count > 0)
            {
                int idAula = Convert.ToInt32(dataTable.Rows[0]["AulaID"]);
                textAulaId.Text = idAula.ToString();

                // Obtener todos los edificios
                DataTable edificios = edificioController.ObtenerTodosLosEdificios();

                // Cargar los nombres de los edificios en el ComboBox
                cmbEdificios.DisplayMember = "Nombre";
                cmbEdificios.ValueMember = "EdificioID";
                cmbEdificios.DataSource = edificios;

                // Seleccionar el edificio asociado al aula encontrada
                int edificioId = Convert.ToInt32(dataTable.Rows[0]["EdificioID"]);
                cmbEdificios.SelectedValue = edificioId;
            }
            else
            {
                textAulaId.Text = string.Empty;
                cmbEdificios.DataSource = null;
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string nombreAula = textNombreAula.Text;
            int edificioId = Convert.ToInt32(cmbEdificios.SelectedValue);
            aulaController.InsertarAula(nombreAula, edificioId);
            LimpiarCampos();
            CargarDatosAulas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textAulaId.Text))
            {
                int idAula = Convert.ToInt32(textAulaId.Text);
                string nombreAula = textNombreAula.Text;
                int edificioId = Convert.ToInt32(cmbEdificios.SelectedValue);
                aulaController.ModificarAula(idAula, nombreAula, edificioId);
                LimpiarCampos();
                CargarDatosAulas();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un aula para modificar.");
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textAulaId.Clear();
            textNombreAula.Clear();
            cmbEdificios.SelectedIndex = -1;
        }

        private int ObtenerIdSeleccionado()
        {
            if (dgvAulas.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvAulas.SelectedRows[0].Cells["AulaID"].Value);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un aula.");
                return -1;
            }
        }
    }
}
