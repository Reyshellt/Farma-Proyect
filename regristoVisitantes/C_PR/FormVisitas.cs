using C_Entidades;
using C_Entidades.cache;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C_PR
{
    public partial class FormVisitas : Form
    {
        private readonly VisitaBLL visitaBLL = new VisitaBLL();
        private readonly AulaController aulaController = new AulaController();
        private readonly EdificioController edificioController = new EdificioController();
        private readonly VisitanteController visitanteController = new VisitanteController();
        public FormVisitas()
        {
            InitializeComponent(); 
            
            cmbEdificio.SelectedIndexChanged += cmbEdificio_SelectedIndexChanged;
            dgvVisitas.SelectionChanged += dgvVisitas_SelectionChanged;
            visitaId.TextChanged += visitaId_TextChanged;

            cmbVisitantes.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbVisitantes.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void FormVisitas_Load(object sender, EventArgs e)
        {
            CargarDatosVisitas();
            CargarComboBoxEdificios();
            CargarComboBoxVisitantes();
            textIdUser.Text= cacheUserLogin.UsuarioID.ToString();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbVisitantes.SelectedItem != null)
            {
                int idVisitante = Convert.ToInt32(cmbVisitantes.SelectedValue);

                // Llamar al método en la capa de datos para obtener las visitas por ID de visitante
                DataTable dataTable = visitaBLL.ObtenerVisitasPorIdVisitante(idVisitante);

                // Actualizar el DataSource del DataGridView con los resultados
                dgvVisitas.DataSource = dataTable;
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int usuarioId = int.Parse(textIdUser.Text);
            int visitanteId = Convert.ToInt32(cmbVisitantes.SelectedValue);
            int edificioId = Convert.ToInt32(cmbEdificio.SelectedValue);
            int aulaId = Convert.ToInt32(cmbAulas.SelectedValue);
            DateTime horaEntrada = dateTimePickerHoraEntrada.Value;
            DateTime? horaSalida = dateTimePickerHoraSalida.Checked ? dateTimePickerHoraSalida.Value : (DateTime?)null;
            string motivoVisita = richTextBoxMotivoVisita.Text;

            Visita visita = new Visita
            {
                UsuarioID = usuarioId,
                VisitanteID = visitanteId,
                EdificioID = edificioId,
                AulaID = aulaId,
                HoraEntrada = horaEntrada,
                HoraSalida = horaSalida,
                MotivoVisita = motivoVisita
            };

            visitaBLL.InsertarVisita(visita);
            LimpiarCampos();
            CargarDatosVisitas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int visitaID = ObtenerIdSeleccionado();
            if (visitaID != -1)
            {
                visitaBLL.EliminarVisita(visitaID);
                LimpiarCampos();
                CargarDatosVisitas(); 
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(visitaId.Text, out int visitaID))
            {
                MessageBox.Show("Por favor,seleccione una visita.");
                return;
            }

            int usuarioId = int.Parse(textIdUser.Text);
            int visitanteId = Convert.ToInt32(cmbVisitantes.SelectedValue);
            int edificioId = Convert.ToInt32(cmbEdificio.SelectedValue);
            int aulaId = Convert.ToInt32(cmbAulas.SelectedValue);
            DateTime horaEntrada = dateTimePickerHoraEntrada.Value;
            DateTime? horaSalida = dateTimePickerHoraSalida.Checked ? dateTimePickerHoraSalida.Value : (DateTime?)null;
            string motivoVisita = richTextBoxMotivoVisita.Text;

            Visita visita = new Visita
            {
                VisitaID = visitaID,
                UsuarioID = usuarioId,
                VisitanteID = visitanteId,
                EdificioID = edificioId,
                AulaID = aulaId,
                HoraEntrada = horaEntrada,
                HoraSalida = horaSalida,
                MotivoVisita = motivoVisita
            };

            visitaBLL.ModificarVisita(visita);

            LimpiarCampos();
            CargarDatosVisitas();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }


        private void CargarComboBoxEdificios()
        {
            DataTable dataTable = edificioController.ObtenerTodosLosEdificios();
            cmbEdificio.DisplayMember = "Nombre";
            cmbEdificio.ValueMember = "EdificioID";
            cmbEdificio.DataSource = dataTable;
        }

        private void CargarComboBoxVisitantes()
        {
            DataTable dataTable = visitanteController.ObtenerTodosLosVisitantes();
            cmbVisitantes.DisplayMember = "Nombre";
            cmbVisitantes.ValueMember = "VisitanteID";
            cmbVisitantes.DataSource = dataTable;
        }
        private void LimpiarCampos()
        {
            // Limpiar los controles del formulario
            visitaId.Clear();
            richTextBoxMotivoVisita.Clear();
            // Limpia otros controles si es necesario
        }
        private void CargarDatosVisitas()
        {
            DataTable dataTable = visitaBLL.ObtenerInformacionVisitas();
            dgvVisitas.DataSource = dataTable;
        }

        private int ObtenerIdSeleccionado()
        {
            if (dgvVisitas.SelectedRows.Count > 0)
            {
                int idVisita = Convert.ToInt32(dgvVisitas.SelectedRows[0].Cells["ID de Visita"].Value);
                
                visitaId.Text = Convert.ToString(dgvVisitas.SelectedRows[0].Cells["ID de Visita"].Value);
                return idVisita;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una visita.");
                return -1;
            }
        }

        private void cmbEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEdificio.SelectedItem != null)
            {
                int edificioId = Convert.ToInt32(cmbEdificio.SelectedValue);

                // Obtener las aulas asociadas al edificio
                DataTable dataTable = aulaController.ObtenerAulasPorEdificio(edificioId);

                // Mostrar las aulas en el ComboBox de aulas
                cmbAulas.DisplayMember = "Nombre";
                cmbAulas.ValueMember = "AulaID";
                cmbAulas.DataSource = dataTable;
            }
        }

        private void dgvVisitas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVisitas.SelectedRows.Count > 0)
            {
                int idSeleccionado = Convert.ToInt32(dgvVisitas.SelectedRows[0].Cells["VisitaID"].Value);
                visitaId.Text = idSeleccionado.ToString();
            }

        }

        private void visitaId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(visitaId.Text))
            {
                int visitaID = int.Parse(visitaId.Text);
                Visita visita = visitaBLL.ObtenerVisitaPorID(visitaID);
                if (visita != null)
                {
                    cmbEdificio.SelectedValue = visita.EdificioID;
                    cmbAulas.SelectedValue = visita.AulaID;
                    cmbVisitantes.SelectedValue = visita.VisitanteID;
                    dateTimePickerHoraEntrada.Value = visita.HoraEntrada;
                    if (visita.HoraSalida.HasValue)
                    {
                        dateTimePickerHoraSalida.Value = visita.HoraSalida.Value;
                    }
                    else
                    {
                        dateTimePickerHoraSalida.Checked = false;
                    }
                    richTextBoxMotivoVisita.Text = visita.MotivoVisita;
                }
                else
                {
                    //MessageBox.Show("La visita con el ID especificado no existe.");
                    visitaId.Text = "";
                }
            }
        }
    }
}
