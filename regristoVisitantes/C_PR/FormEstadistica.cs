using C_LN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_PR
{
    public partial class FormEstadistica : Form
    {
        private readonly EdificioController edificioController = new EdificioController();
        private readonly VisitaBLL visitaBLL = new VisitaBLL();
        public FormEstadistica()
        {
            InitializeComponent();
            cmbEdificios.SelectedIndexChanged += cmbEdificios_SelectedIndexChanged;
            cmbFecha.TextChanged += cmbFecha_TextChanged;
        }

        private void FormEstadistica_Load(object sender, EventArgs e)
        {
            CargarComboBoxEdificios();
            CargarFechasEntradaEdificios();
        }
        private void CargarComboBoxEdificios()
        {
            DataTable dataTable = edificioController.ObtenerTodosLosEdificios();
            cmbEdificios.DisplayMember = "Nombre";
            cmbEdificios.ValueMember = "EdificioID";
            cmbEdificios.DataSource = dataTable;
        }

        private void CargarFechasEntradaEdificios()
        {
            List<DateTime> fechasEntrada = edificioController.ObtenerFechasEntradaEdificios();

            cmbFecha.Items.Clear();

            HashSet<string> fechasUnicas = new HashSet<string>(); // Utilizamos un HashSet para almacenar fechas únicas

            foreach (DateTime fecha in fechasEntrada)
            {
                string fechaFormateada = fecha.ToString("dd/MM/yy");

                // Si la fecha no está en el HashSet, la agregamos al ComboBox y al HashSet
                if (!fechasUnicas.Contains(fechaFormateada))
                {
                    cmbFecha.Items.Add(fechaFormateada);
                    fechasUnicas.Add(fechaFormateada);
                }
            }
        }

        private void cmbEdificios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEdificios.SelectedItem != null)
            {
                int edificioId = Convert.ToInt32(cmbEdificios.SelectedValue);

                // Llamar a un método que obtenga la cantidad de personas que han visitado el edificio seleccionado
                int cantidadPersonas = visitaBLL.ObtenerCantidadVisitantesPorEdificio(edificioId);

                // Mostrar la cantidad de personas en un Label
                lblNum.Text = cantidadPersonas.ToString();
            }
        }

        private void cmbFecha_TextChanged(object sender, EventArgs e)
        {
            ActualizarCantidadVisitantes();
        }

        private void ActualizarCantidadVisitantes()
        {
            if (cmbEdificios.SelectedItem != null && !string.IsNullOrEmpty(cmbFecha.Text))
            {
                int edificioId = Convert.ToInt32(cmbEdificios.SelectedValue);
                DateTime fecha;

                if (DateTime.TryParseExact(cmbFecha.Text, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
                {
                    int cantidadPersonas = visitaBLL.ObtenerCantidadVisitantesPorEdificioYFecha(edificioId, fecha);
                    lblNum.Text = cantidadPersonas.ToString();
                }
                else
                {
                    MessageBox.Show("El formato de fecha ingresado no es válido. Utilice el formato dd/MM/yy.");
                }
            }
        }
       
    }
}
