namespace FrbaCommerce.Facturar_Publicaciones
{
    partial class Admin_Fact
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
            this.Lista_Usuarios = new System.Windows.Forms.DataGridView();
            this.Cliente_Seleccionado = new System.Windows.Forms.Label();
            this.textBox_Usuario = new System.Windows.Forms.TextBox();
            this.button_Seleccionar = new System.Windows.Forms.Button();
            this.button_Atras = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Filtrar = new System.Windows.Forms.Button();
            this.textBox_FiltroMail = new System.Windows.Forms.TextBox();
            this.textBox_FiltroNombre = new System.Windows.Forms.TextBox();
            this.textBox_FiltroUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Facturar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Lista_Usuarios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lista_Usuarios
            // 
            this.Lista_Usuarios.AllowUserToAddRows = false;
            this.Lista_Usuarios.AllowUserToDeleteRows = false;
            this.Lista_Usuarios.AllowUserToOrderColumns = true;
            this.Lista_Usuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Lista_Usuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Lista_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Lista_Usuarios.Location = new System.Drawing.Point(9, 10);
            this.Lista_Usuarios.Margin = new System.Windows.Forms.Padding(2);
            this.Lista_Usuarios.Name = "Lista_Usuarios";
            this.Lista_Usuarios.ReadOnly = true;
            this.Lista_Usuarios.RowTemplate.Height = 24;
            this.Lista_Usuarios.Size = new System.Drawing.Size(156, 364);
            this.Lista_Usuarios.TabIndex = 0;
            this.Lista_Usuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Lista_Usuarios_CellContentClick);
            // 
            // Cliente_Seleccionado
            // 
            this.Cliente_Seleccionado.AutoSize = true;
            this.Cliente_Seleccionado.Location = new System.Drawing.Point(296, 216);
            this.Cliente_Seleccionado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Cliente_Seleccionado.Name = "Cliente_Seleccionado";
            this.Cliente_Seleccionado.Size = new System.Drawing.Size(112, 13);
            this.Cliente_Seleccionado.TabIndex = 1;
            this.Cliente_Seleccionado.Text = "Usuario seleccionado:";
            // 
            // textBox_Usuario
            // 
            this.textBox_Usuario.Location = new System.Drawing.Point(299, 241);
            this.textBox_Usuario.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Usuario.Name = "textBox_Usuario";
            this.textBox_Usuario.ReadOnly = true;
            this.textBox_Usuario.Size = new System.Drawing.Size(110, 20);
            this.textBox_Usuario.TabIndex = 2;
            // 
            // button_Seleccionar
            // 
            this.button_Seleccionar.Location = new System.Drawing.Point(198, 216);
            this.button_Seleccionar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Seleccionar.Name = "button_Seleccionar";
            this.button_Seleccionar.Size = new System.Drawing.Size(80, 45);
            this.button_Seleccionar.TabIndex = 3;
            this.button_Seleccionar.Text = "Seleccionar";
            this.button_Seleccionar.UseVisualStyleBackColor = true;
            this.button_Seleccionar.Click += new System.EventHandler(this.button_Seleccionar_Click);
            // 
            // button_Atras
            // 
            this.button_Atras.Location = new System.Drawing.Point(216, 344);
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
            this.groupBox1.Controls.Add(this.button_Filtrar);
            this.groupBox1.Controls.Add(this.textBox_FiltroMail);
            this.groupBox1.Controls.Add(this.textBox_FiltroNombre);
            this.groupBox1.Controls.Add(this.textBox_FiltroUsuario);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(191, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(218, 171);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // button_Filtrar
            // 
            this.button_Filtrar.Location = new System.Drawing.Point(9, 123);
            this.button_Filtrar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Filtrar.Name = "button_Filtrar";
            this.button_Filtrar.Size = new System.Drawing.Size(80, 29);
            this.button_Filtrar.TabIndex = 8;
            this.button_Filtrar.Text = "Filtrar";
            this.button_Filtrar.UseVisualStyleBackColor = true;
            this.button_Filtrar.Click += new System.EventHandler(this.button_Filtrar_Click);
            // 
            // textBox_FiltroMail
            // 
            this.textBox_FiltroMail.Location = new System.Drawing.Point(56, 86);
            this.textBox_FiltroMail.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FiltroMail.Name = "textBox_FiltroMail";
            this.textBox_FiltroMail.Size = new System.Drawing.Size(158, 20);
            this.textBox_FiltroMail.TabIndex = 5;
            // 
            // textBox_FiltroNombre
            // 
            this.textBox_FiltroNombre.Location = new System.Drawing.Point(56, 54);
            this.textBox_FiltroNombre.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FiltroNombre.Name = "textBox_FiltroNombre";
            this.textBox_FiltroNombre.Size = new System.Drawing.Size(158, 20);
            this.textBox_FiltroNombre.TabIndex = 4;
            // 
            // textBox_FiltroUsuario
            // 
            this.textBox_FiltroUsuario.Location = new System.Drawing.Point(56, 25);
            this.textBox_FiltroUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FiltroUsuario.Name = "textBox_FiltroUsuario";
            this.textBox_FiltroUsuario.Size = new System.Drawing.Size(159, 20);
            this.textBox_FiltroUsuario.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 86);
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
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // btn_Facturar
            // 
            this.btn_Facturar.Location = new System.Drawing.Point(336, 344);
            this.btn_Facturar.Name = "btn_Facturar";
            this.btn_Facturar.Size = new System.Drawing.Size(84, 30);
            this.btn_Facturar.TabIndex = 8;
            this.btn_Facturar.Text = "Facturar";
            this.btn_Facturar.UseVisualStyleBackColor = true;
            this.btn_Facturar.Click += new System.EventHandler(this.btn_Facturar_Click);
            // 
            // Admin_Fact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 384);
            this.Controls.Add(this.btn_Facturar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Atras);
            this.Controls.Add(this.button_Seleccionar);
            this.Controls.Add(this.textBox_Usuario);
            this.Controls.Add(this.Cliente_Seleccionado);
            this.Controls.Add(this.Lista_Usuarios);
            this.Name = "Admin_Fact";
            this.Text = "Listado_Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.Lista_Usuarios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Lista_Usuarios;
        private System.Windows.Forms.Label Cliente_Seleccionado;
        private System.Windows.Forms.TextBox textBox_Usuario;
        private System.Windows.Forms.Button button_Seleccionar;
        private System.Windows.Forms.Button button_Atras;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Filtrar;
        private System.Windows.Forms.TextBox textBox_FiltroMail;
        private System.Windows.Forms.TextBox textBox_FiltroNombre;
        private System.Windows.Forms.TextBox textBox_FiltroUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Facturar;
    }
}