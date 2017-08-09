namespace FrbaCommerce.Abm_Cliente
{
    partial class Listado_Clientes
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
            this.Cliente_Seleccionado = new System.Windows.Forms.Label();
            this.textBox_Usuario = new System.Windows.Forms.TextBox();
            this.button_Seleccionar = new System.Windows.Forms.Button();
            this.button_Modificar = new System.Windows.Forms.Button();
            this.button_Eliminar = new System.Windows.Forms.Button();
            this.button_Atras = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_FiltroTipoDoc = new System.Windows.Forms.ComboBox();
            this.textBox_FiltroTelefono = new System.Windows.Forms.TextBox();
            this.textBox_FiltroNumDoc = new System.Windows.Forms.TextBox();
            this.textBox_FiltroMail = new System.Windows.Forms.TextBox();
            this.textBox_FiltroNombre = new System.Windows.Forms.TextBox();
            this.textBox_FiltroApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Filtrar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Usuarios = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Usuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // Cliente_Seleccionado
            // 
            this.Cliente_Seleccionado.AutoSize = true;
            this.Cliente_Seleccionado.Location = new System.Drawing.Point(119, 146);
            this.Cliente_Seleccionado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Cliente_Seleccionado.Name = "Cliente_Seleccionado";
            this.Cliente_Seleccionado.Size = new System.Drawing.Size(108, 13);
            this.Cliente_Seleccionado.TabIndex = 1;
            this.Cliente_Seleccionado.Text = "Cliente seleccionado:";
            // 
            // textBox_Usuario
            // 
            this.textBox_Usuario.Location = new System.Drawing.Point(231, 144);
            this.textBox_Usuario.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Usuario.Name = "textBox_Usuario";
            this.textBox_Usuario.ReadOnly = true;
            this.textBox_Usuario.Size = new System.Drawing.Size(110, 20);
            this.textBox_Usuario.TabIndex = 2;
            // 
            // button_Seleccionar
            // 
            this.button_Seleccionar.Location = new System.Drawing.Point(373, 138);
            this.button_Seleccionar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Seleccionar.Name = "button_Seleccionar";
            this.button_Seleccionar.Size = new System.Drawing.Size(80, 29);
            this.button_Seleccionar.TabIndex = 3;
            this.button_Seleccionar.Text = "Seleccionar";
            this.button_Seleccionar.UseVisualStyleBackColor = true;
            this.button_Seleccionar.Click += new System.EventHandler(this.button_Seleccionar_Click);
            // 
            // button_Modificar
            // 
            this.button_Modificar.Location = new System.Drawing.Point(21, 18);
            this.button_Modificar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Modificar.Name = "button_Modificar";
            this.button_Modificar.Size = new System.Drawing.Size(80, 29);
            this.button_Modificar.TabIndex = 4;
            this.button_Modificar.Text = "Modificar";
            this.button_Modificar.UseVisualStyleBackColor = true;
            this.button_Modificar.Click += new System.EventHandler(this.button_Modificar_Click);
            // 
            // button_Eliminar
            // 
            this.button_Eliminar.Location = new System.Drawing.Point(21, 60);
            this.button_Eliminar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Eliminar.Name = "button_Eliminar";
            this.button_Eliminar.Size = new System.Drawing.Size(80, 29);
            this.button_Eliminar.TabIndex = 5;
            this.button_Eliminar.Text = "Eliminar";
            this.button_Eliminar.UseVisualStyleBackColor = true;
            this.button_Eliminar.Click += new System.EventHandler(this.button_Eliminar_Click);
            // 
            // button_Atras
            // 
            this.button_Atras.Location = new System.Drawing.Point(21, 104);
            this.button_Atras.Margin = new System.Windows.Forms.Padding(2);
            this.button_Atras.Name = "button_Atras";
            this.button_Atras.Size = new System.Drawing.Size(80, 29);
            this.button_Atras.TabIndex = 6;
            this.button_Atras.Text = "Atras";
            this.button_Atras.UseVisualStyleBackColor = true;
            this.button_Atras.Click += new System.EventHandler(this.button_Atras_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_FiltroTipoDoc);
            this.groupBox1.Controls.Add(this.textBox_FiltroTelefono);
            this.groupBox1.Controls.Add(this.textBox_FiltroNumDoc);
            this.groupBox1.Controls.Add(this.textBox_FiltroMail);
            this.groupBox1.Controls.Add(this.textBox_FiltroNombre);
            this.groupBox1.Controls.Add(this.textBox_FiltroApellido);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(442, 123);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tel:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Num Doc:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tipo Doc:";
            // 
            // comboBox_FiltroTipoDoc
            // 
            this.comboBox_FiltroTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FiltroTipoDoc.FormattingEnabled = true;
            this.comboBox_FiltroTipoDoc.Items.AddRange(new object[] {
            "DNI",
            "CI",
            "LE",
            "LC"});
            this.comboBox_FiltroTipoDoc.Location = new System.Drawing.Point(282, 22);
            this.comboBox_FiltroTipoDoc.Name = "comboBox_FiltroTipoDoc";
            this.comboBox_FiltroTipoDoc.Size = new System.Drawing.Size(127, 21);
            this.comboBox_FiltroTipoDoc.TabIndex = 11;
            // 
            // textBox_FiltroTelefono
            // 
            this.textBox_FiltroTelefono.Location = new System.Drawing.Point(254, 91);
            this.textBox_FiltroTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FiltroTelefono.Name = "textBox_FiltroTelefono";
            this.textBox_FiltroTelefono.Size = new System.Drawing.Size(155, 20);
            this.textBox_FiltroTelefono.TabIndex = 10;
            // 
            // textBox_FiltroNumDoc
            // 
            this.textBox_FiltroNumDoc.Location = new System.Drawing.Point(282, 58);
            this.textBox_FiltroNumDoc.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FiltroNumDoc.Name = "textBox_FiltroNumDoc";
            this.textBox_FiltroNumDoc.Size = new System.Drawing.Size(127, 20);
            this.textBox_FiltroNumDoc.TabIndex = 9;
            // 
            // textBox_FiltroMail
            // 
            this.textBox_FiltroMail.Location = new System.Drawing.Point(37, 88);
            this.textBox_FiltroMail.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FiltroMail.Name = "textBox_FiltroMail";
            this.textBox_FiltroMail.Size = new System.Drawing.Size(153, 20);
            this.textBox_FiltroMail.TabIndex = 5;
            // 
            // textBox_FiltroNombre
            // 
            this.textBox_FiltroNombre.Location = new System.Drawing.Point(55, 56);
            this.textBox_FiltroNombre.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FiltroNombre.Name = "textBox_FiltroNombre";
            this.textBox_FiltroNombre.Size = new System.Drawing.Size(135, 20);
            this.textBox_FiltroNombre.TabIndex = 4;
            // 
            // textBox_FiltroApellido
            // 
            this.textBox_FiltroApellido.Location = new System.Drawing.Point(57, 22);
            this.textBox_FiltroApellido.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FiltroApellido.Name = "textBox_FiltroApellido";
            this.textBox_FiltroApellido.Size = new System.Drawing.Size(133, 20);
            this.textBox_FiltroApellido.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // button_Filtrar
            // 
            this.button_Filtrar.Location = new System.Drawing.Point(11, 138);
            this.button_Filtrar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Filtrar.Name = "button_Filtrar";
            this.button_Filtrar.Size = new System.Drawing.Size(80, 29);
            this.button_Filtrar.TabIndex = 8;
            this.button_Filtrar.Text = "Filtrar";
            this.button_Filtrar.UseVisualStyleBackColor = true;
            this.button_Filtrar.Click += new System.EventHandler(this.button_Filtrar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Modificar);
            this.groupBox2.Controls.Add(this.button_Eliminar);
            this.groupBox2.Controls.Add(this.button_Atras);
            this.groupBox2.Location = new System.Drawing.Point(478, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(124, 150);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones";
            // 
            // dataGridView_Usuarios
            // 
            this.dataGridView_Usuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Usuarios.Location = new System.Drawing.Point(11, 174);
            this.dataGridView_Usuarios.Name = "dataGridView_Usuarios";
            this.dataGridView_Usuarios.Size = new System.Drawing.Size(595, 355);
            this.dataGridView_Usuarios.TabIndex = 10;
            
            // 
            // Listado_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 541);
            this.Controls.Add(this.dataGridView_Usuarios);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Seleccionar);
            this.Controls.Add(this.textBox_Usuario);
            this.Controls.Add(this.button_Filtrar);
            this.Controls.Add(this.Cliente_Seleccionado);
            this.Name = "Listado_Clientes";
            this.Text = "Listado_Clientes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Usuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Cliente_Seleccionado;
        private System.Windows.Forms.TextBox textBox_Usuario;
        private System.Windows.Forms.Button button_Seleccionar;
        private System.Windows.Forms.Button button_Modificar;
        private System.Windows.Forms.Button button_Eliminar;
        private System.Windows.Forms.Button button_Atras;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Filtrar;
        private System.Windows.Forms.TextBox textBox_FiltroMail;
        private System.Windows.Forms.TextBox textBox_FiltroNombre;
        private System.Windows.Forms.TextBox textBox_FiltroApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_FiltroTipoDoc;
        private System.Windows.Forms.TextBox textBox_FiltroTelefono;
        private System.Windows.Forms.TextBox textBox_FiltroNumDoc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_Usuarios;
    }
}