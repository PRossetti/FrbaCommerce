namespace FrbaCommerce.Editar_Publicacion
{
    partial class Listar_Publicaciones
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
            this.maskedTextBox4 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Actualizar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_PrimerPagina = new System.Windows.Forms.Button();
            this.button_UltimaPagina = new System.Windows.Forms.Button();
            this.button_PagSiguiente = new System.Windows.Forms.Button();
            this.button_PagAnterior = new System.Windows.Forms.Button();
            this.button_Seleccionar = new System.Windows.Forms.Button();
            this.textBox_Publicacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_AgregarEstado = new System.Windows.Forms.CheckBox();
            this.checkBox_AgregarVisib = new System.Windows.Forms.CheckBox();
            this.comboBox_FiltroEstado = new System.Windows.Forms.ComboBox();
            this.comboBox_FiltroVisib = new System.Windows.Forms.ComboBox();
            this.label_FiltroEstado = new System.Windows.Forms.Label();
            this.button_Filtrar = new System.Windows.Forms.Button();
            this.textBox_FiltroDesc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label_FiltroVisib = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Crear = new System.Windows.Forms.Button();
            this.button_EditarPublicacion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // maskedTextBox4
            // 
            this.maskedTextBox4.Location = new System.Drawing.Point(138, 92);
            this.maskedTextBox4.Mask = "9999999999";
            this.maskedTextBox4.Name = "maskedTextBox4";
            this.maskedTextBox4.PromptChar = ' ';
            this.maskedTextBox4.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox4.TabIndex = 18;
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.Enabled = false;
            this.maskedTextBox3.Location = new System.Drawing.Point(138, 66);
            this.maskedTextBox3.Mask = "9999999999";
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.PromptChar = ' ';
            this.maskedTextBox3.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox3.TabIndex = 17;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Enabled = false;
            this.maskedTextBox2.Location = new System.Drawing.Point(138, 40);
            this.maskedTextBox2.Mask = "9999999999";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.PromptChar = ' ';
            this.maskedTextBox2.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox2.TabIndex = 16;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Enabled = false;
            this.maskedTextBox1.Location = new System.Drawing.Point(138, 14);
            this.maskedTextBox1.Mask = "9999999999";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PromptChar = ' ';
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(22, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Maximo por pagina:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(50, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ultima pagina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(27, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Numero de pagina";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Cantidad de registros:";
            // 
            // button_Actualizar
            // 
            this.button_Actualizar.Location = new System.Drawing.Point(163, 118);
            this.button_Actualizar.Name = "button_Actualizar";
            this.button_Actualizar.Size = new System.Drawing.Size(75, 29);
            this.button_Actualizar.TabIndex = 19;
            this.button_Actualizar.Text = "Actualizar";
            this.button_Actualizar.UseVisualStyleBackColor = true;
            this.button_Actualizar.Click += new System.EventHandler(this.button_Actualizar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 205);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(830, 322);
            this.dataGridView1.TabIndex = 20;
            // 
            // button_PrimerPagina
            // 
            this.button_PrimerPagina.Location = new System.Drawing.Point(15, 175);
            this.button_PrimerPagina.Name = "button_PrimerPagina";
            this.button_PrimerPagina.Size = new System.Drawing.Size(119, 23);
            this.button_PrimerPagina.TabIndex = 24;
            this.button_PrimerPagina.Text = "Primera pagina";
            this.button_PrimerPagina.UseVisualStyleBackColor = true;
            this.button_PrimerPagina.Click += new System.EventHandler(this.button_PrimerPagina_Click);
            // 
            // button_UltimaPagina
            // 
            this.button_UltimaPagina.Location = new System.Drawing.Point(312, 175);
            this.button_UltimaPagina.Name = "button_UltimaPagina";
            this.button_UltimaPagina.Size = new System.Drawing.Size(108, 23);
            this.button_UltimaPagina.TabIndex = 23;
            this.button_UltimaPagina.Text = "Ultima Pagina";
            this.button_UltimaPagina.UseVisualStyleBackColor = true;
            this.button_UltimaPagina.Click += new System.EventHandler(this.button_UltimaPagina_Click);
            // 
            // button_PagSiguiente
            // 
            this.button_PagSiguiente.Location = new System.Drawing.Point(221, 175);
            this.button_PagSiguiente.Name = "button_PagSiguiente";
            this.button_PagSiguiente.Size = new System.Drawing.Size(75, 23);
            this.button_PagSiguiente.TabIndex = 22;
            this.button_PagSiguiente.Text = "Siguiente";
            this.button_PagSiguiente.UseVisualStyleBackColor = true;
            this.button_PagSiguiente.Click += new System.EventHandler(this.button_PagSiguiente_Click);
            // 
            // button_PagAnterior
            // 
            this.button_PagAnterior.Location = new System.Drawing.Point(140, 175);
            this.button_PagAnterior.Name = "button_PagAnterior";
            this.button_PagAnterior.Size = new System.Drawing.Size(75, 23);
            this.button_PagAnterior.TabIndex = 21;
            this.button_PagAnterior.Text = "Anterior";
            this.button_PagAnterior.UseVisualStyleBackColor = true;
            this.button_PagAnterior.Click += new System.EventHandler(this.button_PagAnterior_Click);
            // 
            // button_Seleccionar
            // 
            this.button_Seleccionar.Location = new System.Drawing.Point(696, 177);
            this.button_Seleccionar.Name = "button_Seleccionar";
            this.button_Seleccionar.Size = new System.Drawing.Size(75, 23);
            this.button_Seleccionar.TabIndex = 27;
            this.button_Seleccionar.Text = "Seleccionar";
            this.button_Seleccionar.UseVisualStyleBackColor = true;
            this.button_Seleccionar.Click += new System.EventHandler(this.button_Seleccionar_Click);
            // 
            // textBox_Publicacion
            // 
            this.textBox_Publicacion.Location = new System.Drawing.Point(578, 177);
            this.textBox_Publicacion.Name = "textBox_Publicacion";
            this.textBox_Publicacion.ReadOnly = true;
            this.textBox_Publicacion.Size = new System.Drawing.Size(100, 20);
            this.textBox_Publicacion.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(440, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Publicacion Seleccionada";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_AgregarEstado);
            this.groupBox1.Controls.Add(this.checkBox_AgregarVisib);
            this.groupBox1.Controls.Add(this.comboBox_FiltroEstado);
            this.groupBox1.Controls.Add(this.comboBox_FiltroVisib);
            this.groupBox1.Controls.Add(this.label_FiltroEstado);
            this.groupBox1.Controls.Add(this.button_Filtrar);
            this.groupBox1.Controls.Add(this.textBox_FiltroDesc);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label_FiltroVisib);
            this.groupBox1.Location = new System.Drawing.Point(249, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(347, 149);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // checkBox_AgregarEstado
            // 
            this.checkBox_AgregarEstado.AutoSize = true;
            this.checkBox_AgregarEstado.Location = new System.Drawing.Point(15, 84);
            this.checkBox_AgregarEstado.Name = "checkBox_AgregarEstado";
            this.checkBox_AgregarEstado.Size = new System.Drawing.Size(99, 17);
            this.checkBox_AgregarEstado.TabIndex = 13;
            this.checkBox_AgregarEstado.Text = "Agregar Estado";
            this.checkBox_AgregarEstado.UseVisualStyleBackColor = true;
            this.checkBox_AgregarEstado.CheckedChanged += new System.EventHandler(this.checkBox_AgregarEstado_CheckedChanged);
            // 
            // checkBox_AgregarVisib
            // 
            this.checkBox_AgregarVisib.AutoSize = true;
            this.checkBox_AgregarVisib.Location = new System.Drawing.Point(15, 56);
            this.checkBox_AgregarVisib.Name = "checkBox_AgregarVisib";
            this.checkBox_AgregarVisib.Size = new System.Drawing.Size(112, 17);
            this.checkBox_AgregarVisib.TabIndex = 12;
            this.checkBox_AgregarVisib.Text = "Agregar Visibilidad";
            this.checkBox_AgregarVisib.UseVisualStyleBackColor = true;
            this.checkBox_AgregarVisib.CheckedChanged += new System.EventHandler(this.checkBox_AgregarVisib_CheckedChanged);
            // 
            // comboBox_FiltroEstado
            // 
            this.comboBox_FiltroEstado.FormattingEnabled = true;
            this.comboBox_FiltroEstado.Items.AddRange(new object[] {
            "Borrador",
            "Publicada",
            "Pausada",
            "Finalizada"});
            this.comboBox_FiltroEstado.Location = new System.Drawing.Point(199, 84);
            this.comboBox_FiltroEstado.Name = "comboBox_FiltroEstado";
            this.comboBox_FiltroEstado.Size = new System.Drawing.Size(121, 21);
            this.comboBox_FiltroEstado.TabIndex = 11;
            // 
            // comboBox_FiltroVisib
            // 
            this.comboBox_FiltroVisib.FormattingEnabled = true;
            this.comboBox_FiltroVisib.Location = new System.Drawing.Point(199, 54);
            this.comboBox_FiltroVisib.Name = "comboBox_FiltroVisib";
            this.comboBox_FiltroVisib.Size = new System.Drawing.Size(121, 21);
            this.comboBox_FiltroVisib.TabIndex = 10;
            // 
            // label_FiltroEstado
            // 
            this.label_FiltroEstado.AutoSize = true;
            this.label_FiltroEstado.Location = new System.Drawing.Point(138, 87);
            this.label_FiltroEstado.Name = "label_FiltroEstado";
            this.label_FiltroEstado.Size = new System.Drawing.Size(43, 13);
            this.label_FiltroEstado.TabIndex = 9;
            this.label_FiltroEstado.Text = "Estado:";
            // 
            // button_Filtrar
            // 
            this.button_Filtrar.Location = new System.Drawing.Point(245, 111);
            this.button_Filtrar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Filtrar.Name = "button_Filtrar";
            this.button_Filtrar.Size = new System.Drawing.Size(79, 29);
            this.button_Filtrar.TabIndex = 8;
            this.button_Filtrar.Text = "Filtrar";
            this.button_Filtrar.UseVisualStyleBackColor = true;
            this.button_Filtrar.Click += new System.EventHandler(this.button_Filtrar_Click);
            // 
            // textBox_FiltroDesc
            // 
            this.textBox_FiltroDesc.Location = new System.Drawing.Point(79, 25);
            this.textBox_FiltroDesc.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FiltroDesc.Name = "textBox_FiltroDesc";
            this.textBox_FiltroDesc.Size = new System.Drawing.Size(242, 20);
            this.textBox_FiltroDesc.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Descripcion:";
            // 
            // label_FiltroVisib
            // 
            this.label_FiltroVisib.AutoSize = true;
            this.label_FiltroVisib.Location = new System.Drawing.Point(138, 57);
            this.label_FiltroVisib.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_FiltroVisib.Name = "label_FiltroVisib";
            this.label_FiltroVisib.Size = new System.Drawing.Size(56, 13);
            this.label_FiltroVisib.TabIndex = 0;
            this.label_FiltroVisib.Text = "Visibilidad:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Crear);
            this.groupBox2.Controls.Add(this.button_EditarPublicacion);
            this.groupBox2.Location = new System.Drawing.Point(627, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(103, 117);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // button_Crear
            // 
            this.button_Crear.Location = new System.Drawing.Point(10, 24);
            this.button_Crear.Margin = new System.Windows.Forms.Padding(2);
            this.button_Crear.Name = "button_Crear";
            this.button_Crear.Size = new System.Drawing.Size(80, 29);
            this.button_Crear.TabIndex = 10;
            this.button_Crear.Text = "Crear";
            this.button_Crear.UseVisualStyleBackColor = true;
            this.button_Crear.Click += new System.EventHandler(this.button_Crear_Click);
            // 
            // button_EditarPublicacion
            // 
            this.button_EditarPublicacion.Location = new System.Drawing.Point(10, 70);
            this.button_EditarPublicacion.Margin = new System.Windows.Forms.Padding(2);
            this.button_EditarPublicacion.Name = "button_EditarPublicacion";
            this.button_EditarPublicacion.Size = new System.Drawing.Size(80, 29);
            this.button_EditarPublicacion.TabIndex = 9;
            this.button_EditarPublicacion.Text = "Editar";
            this.button_EditarPublicacion.UseVisualStyleBackColor = true;
            this.button_EditarPublicacion.Click += new System.EventHandler(this.button_EditarPublicacion_Click);
            // 
            // Listar_Publicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 539);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Seleccionar);
            this.Controls.Add(this.textBox_Publicacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_PrimerPagina);
            this.Controls.Add(this.button_UltimaPagina);
            this.Controls.Add(this.button_PagSiguiente);
            this.Controls.Add(this.button_PagAnterior);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_Actualizar);
            this.Controls.Add(this.maskedTextBox4);
            this.Controls.Add(this.maskedTextBox3);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Listar_Publicaciones";
            this.Text = "Listar_Publicaciones";
            this.Load += new System.EventHandler(this.load_Publicaciones);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Actualizar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_PrimerPagina;
        private System.Windows.Forms.Button button_UltimaPagina;
        private System.Windows.Forms.Button button_PagSiguiente;
        private System.Windows.Forms.Button button_PagAnterior;
        private System.Windows.Forms.Button button_Seleccionar;
        private System.Windows.Forms.TextBox textBox_Publicacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Filtrar;
        private System.Windows.Forms.TextBox textBox_FiltroDesc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_FiltroVisib;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_EditarPublicacion;
        private System.Windows.Forms.Button button_Crear;
        private System.Windows.Forms.ComboBox comboBox_FiltroEstado;
        private System.Windows.Forms.ComboBox comboBox_FiltroVisib;
        private System.Windows.Forms.Label label_FiltroEstado;
        private System.Windows.Forms.CheckBox checkBox_AgregarEstado;
        private System.Windows.Forms.CheckBox checkBox_AgregarVisib;
    }
}