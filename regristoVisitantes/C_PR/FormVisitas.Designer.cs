namespace C_PR
{
    partial class FormVisitas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerHoraEntrada = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHoraSalida = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textIdUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvVisitas = new System.Windows.Forms.DataGridView();
            this.cmbVisitantes = new System.Windows.Forms.ComboBox();
            this.cmbEdificio = new System.Windows.Forms.ComboBox();
            this.cmbAulas = new System.Windows.Forms.ComboBox();
            this.richTextBoxMotivoVisita = new System.Windows.Forms.RichTextBox();
            this.visitaId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edificio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Aula a Visitar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hora de Entrada";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hora de salida";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Motivo de visita";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(740, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 29);
            this.label6.TabIndex = 5;
            this.label6.Text = "Foto Del Visitante";
            // 
            // dateTimePickerHoraEntrada
            // 
            this.dateTimePickerHoraEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerHoraEntrada.Location = new System.Drawing.Point(203, 166);
            this.dateTimePickerHoraEntrada.Name = "dateTimePickerHoraEntrada";
            this.dateTimePickerHoraEntrada.Size = new System.Drawing.Size(248, 22);
            this.dateTimePickerHoraEntrada.TabIndex = 6;
            // 
            // dateTimePickerHoraSalida
            // 
            this.dateTimePickerHoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerHoraSalida.Location = new System.Drawing.Point(203, 203);
            this.dateTimePickerHoraSalida.Name = "dateTimePickerHoraSalida";
            this.dateTimePickerHoraSalida.Size = new System.Drawing.Size(248, 22);
            this.dateTimePickerHoraSalida.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::C_PR.Properties.Resources.selfie;
            this.pictureBox1.Location = new System.Drawing.Point(757, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // textIdUser
            // 
            this.textIdUser.Location = new System.Drawing.Point(644, 152);
            this.textIdUser.Name = "textIdUser";
            this.textIdUser.Size = new System.Drawing.Size(59, 22);
            this.textIdUser.TabIndex = 12;
            this.textIdUser.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(640, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "UsuarioID";
            this.label7.Visible = false;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Visitante";
            // 
            // dgvVisitas
            // 
            this.dgvVisitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisitas.Location = new System.Drawing.Point(25, 336);
            this.dgvVisitas.Name = "dgvVisitas";
            this.dgvVisitas.RowHeadersWidth = 51;
            this.dgvVisitas.RowTemplate.Height = 24;
            this.dgvVisitas.Size = new System.Drawing.Size(973, 226);
            this.dgvVisitas.TabIndex = 16;
            this.dgvVisitas.SelectionChanged += new System.EventHandler(this.dgvVisitas_SelectionChanged);
            // 
            // cmbVisitantes
            // 
            this.cmbVisitantes.FormattingEnabled = true;
            this.cmbVisitantes.Location = new System.Drawing.Point(181, 54);
            this.cmbVisitantes.Name = "cmbVisitantes";
            this.cmbVisitantes.Size = new System.Drawing.Size(270, 24);
            this.cmbVisitantes.TabIndex = 17;
            // 
            // cmbEdificio
            // 
            this.cmbEdificio.FormattingEnabled = true;
            this.cmbEdificio.Location = new System.Drawing.Point(181, 94);
            this.cmbEdificio.Name = "cmbEdificio";
            this.cmbEdificio.Size = new System.Drawing.Size(270, 24);
            this.cmbEdificio.TabIndex = 18;
            this.cmbEdificio.SelectedIndexChanged += new System.EventHandler(this.cmbEdificio_SelectedIndexChanged);
            // 
            // cmbAulas
            // 
            this.cmbAulas.FormattingEnabled = true;
            this.cmbAulas.Location = new System.Drawing.Point(181, 130);
            this.cmbAulas.Name = "cmbAulas";
            this.cmbAulas.Size = new System.Drawing.Size(270, 24);
            this.cmbAulas.TabIndex = 19;
            // 
            // richTextBoxMotivoVisita
            // 
            this.richTextBoxMotivoVisita.Location = new System.Drawing.Point(83, 256);
            this.richTextBoxMotivoVisita.Name = "richTextBoxMotivoVisita";
            this.richTextBoxMotivoVisita.Size = new System.Drawing.Size(474, 50);
            this.richTextBoxMotivoVisita.TabIndex = 20;
            this.richTextBoxMotivoVisita.Text = "";
            // 
            // visitaId
            // 
            this.visitaId.Location = new System.Drawing.Point(644, 94);
            this.visitaId.Name = "visitaId";
            this.visitaId.Size = new System.Drawing.Size(59, 22);
            this.visitaId.TabIndex = 21;
            this.visitaId.Visible = false;
            this.visitaId.TextChanged += new System.EventHandler(this.visitaId_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(647, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "VisitaID";
            this.label9.Visible = false;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(482, 50);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(482, 97);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(75, 23);
            this.btnInsertar.TabIndex = 24;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(482, 133);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 25;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(482, 172);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 26;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(482, 210);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 27;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FormVisitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 594);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.visitaId);
            this.Controls.Add(this.richTextBoxMotivoVisita);
            this.Controls.Add(this.cmbAulas);
            this.Controls.Add(this.cmbEdificio);
            this.Controls.Add(this.cmbVisitantes);
            this.Controls.Add(this.dgvVisitas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textIdUser);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dateTimePickerHoraSalida);
            this.Controls.Add(this.dateTimePickerHoraEntrada);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVisitas";
            this.Text = "FormVisitas";
            this.Load += new System.EventHandler(this.FormVisitas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerHoraEntrada;
        private System.Windows.Forms.DateTimePicker dateTimePickerHoraSalida;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textIdUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvVisitas;
        private System.Windows.Forms.ComboBox cmbVisitantes;
        private System.Windows.Forms.ComboBox cmbEdificio;
        private System.Windows.Forms.ComboBox cmbAulas;
        private System.Windows.Forms.RichTextBox richTextBoxMotivoVisita;
        private System.Windows.Forms.TextBox visitaId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}