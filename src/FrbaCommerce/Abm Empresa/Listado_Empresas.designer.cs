namespace FrbaCommerce.Abm_Empresa
{
    partial class Listado_Empresas
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
            this.Lista_Empresas = new System.Windows.Forms.DataGridView();
            this.button_Seleccionar = new System.Windows.Forms.Button();
            this.Empresa_Seleccionada = new System.Windows.Forms.Label();
            this.textBox_Empresa = new System.Windows.Forms.TextBox();
            this.button_Modificar = new System.Windows.Forms.Button();
            this.button_Eliminar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Filtrar = new System.Windows.Forms.Button();
            this.textBox_FiltroMail = new System.Windows.Forms.TextBox();
            this.textBox_FiltroCUIT = new System.Windows.Forms.TextBox();
            this.textBox_FiltroEmpresa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Atras = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Lista_Empresas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lista_Empresas
            // 
            this.Lista_Empresas.AllowUserToAddRows = false;
            this.Lista_Empresas.AllowUserToDeleteRows = false;
            this.Lista_Empresas.AllowUserToOrderColumns = true;
            this.Lista_Empresas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Lista_Empresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Lista_Empresas.Location = new System.Drawing.Point(11, 177);
            this.Lista_Empresas.Margin = new System.Windows.Forms.Padding(2);
            this.Lista_Empresas.Name = "Lista_Empresas";
            this.Lista_Empresas.ReadOnly = true;
            this.Lista_Empresas.RowTemplate.Height = 24;
            this.Lista_Empresas.Size = new System.Drawing.Size(596, 353);
            this.Lista_Empresas.TabIndex = 1;
            
            // 
            // button_Seleccionar
            // 
            this.button_Seleccionar.Location = new System.Drawing.Point(357, 143);
            this.button_Seleccionar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Seleccionar.Name = "button_Seleccionar";
            this.button_Seleccionar.Size = new System.Drawing.Size(80, 29);
            this.button_Seleccionar.TabIndex = 4;
            this.button_Seleccionar.Text = "Seleccionar";
            this.button_Seleccionar.UseVisualStyleBackColor = true;
            this.button_Seleccionar.Click += new System.EventHandler(this.button_Seleccionar_Click);
            // 
            // Empresa_Seleccionada
            // 
            this.Empresa_Seleccionada.AutoSize = true;
            this.Empresa_Seleccionada.Location = new System.Drawing.Point(115, 151);
            this.Empresa_Seleccionada.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Empresa_Seleccionada.Name = "Empresa_Seleccionada";
            this.Empresa_Seleccionada.Size = new System.Drawing.Size(117, 13);
            this.Empresa_Seleccionada.TabIndex = 5;
            this.Empresa_Seleccionada.Text = "Empresa seleccionada:";
            // 
            // textBox_Empresa
            // 
            this.textBox_Empresa.Location = new System.Drawing.Point(236, 149);
            this.textBox_Empresa.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Empresa.Name = "textBox_Empresa";
            this.textBox_Empresa.ReadOnly = true;
            this.textBox_Empresa.Size = new System.Drawing.Size(101, 20);
            this.textBox_Empresa.TabIndex = 6;
            // 
            // button_Modificar
            // 
            this.button_Modificar.Location = new System.Drawing.Point(21, 27);
            this.button_Modificar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Modificar.Name = "button_Modificar";
            this.button_Modificar.Size = new System.Drawing.Size(80, 29);
            this.button_Modificar.TabIndex = 7;
            this.button_Modificar.Text = "Modificar";
            this.button_Modificar.UseVisualStyleBackColor = true;
            this.button_Modificar.Click += new System.EventHandler(this.button_Modificar_Click);
            // 
            // button_Eliminar
            // 
            this.button_Eliminar.Location = new System.Drawing.Point(21, 72);
            this.button_Eliminar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Eliminar.Name = "button_Eliminar";
            this.button_Eliminar.Size = new System.Drawing.Size(80, 29);
            this.button_Eliminar.TabIndex = 8;
            this.button_Eliminar.Text = "Eliminar";
            this.button_Eliminar.UseVisualStyleBackColor = true;
            this.button_Eliminar.Click += new System.EventHandler(this.button_Eliminar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_FiltroMail);
            this.groupBox1.Controls.Add(this.textBox_FiltroCUIT);
            this.groupBox1.Controls.Add(this.textBox_FiltroEmpresa);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(248, 119);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // button_Filtrar
            // 
            this.button_Filtrar.Location = new System.Drawing.Point(11, 144);
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
            this.textBox_FiltroMail.Size = new System.Drawing.Size(159, 20);
            this.textBox_FiltroMail.TabIndex = 5;
            // 
            // textBox_FiltroCUIT
            // 
            this.textBox_FiltroCUIT.Location = new System.Drawing.Point(56, 54);
            this.textBox_FiltroCUIT.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FiltroCUIT.Name = "textBox_FiltroCUIT";
            this.textBox_FiltroCUIT.Size = new System.Drawing.Size(159, 20);
            this.textBox_FiltroCUIT.TabIndex = 4;
            // 
            // textBox_FiltroEmpresa
            // 
            this.textBox_FiltroEmpresa.Location = new System.Drawing.Point(56, 25);
            this.textBox_FiltroEmpresa.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_FiltroEmpresa.Name = "textBox_FiltroEmpresa";
            this.textBox_FiltroEmpresa.Size = new System.Drawing.Size(159, 20);
            this.textBox_FiltroEmpresa.TabIndex = 3;
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
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Empresa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CUIT:";
            // 
            // button_Atras
            // 
            this.button_Atras.Location = new System.Drawing.Point(21, 113);
            this.button_Atras.Margin = new System.Windows.Forms.Padding(2);
            this.button_Atras.Name = "button_Atras";
            this.button_Atras.Size = new System.Drawing.Size(80, 29);
            this.button_Atras.TabIndex = 10;
            this.button_Atras.Text = "Atras";
            this.button_Atras.UseVisualStyleBackColor = true;
            this.button_Atras.Click += new System.EventHandler(this.button_Atras_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Modificar);
            this.groupBox2.Controls.Add(this.button_Eliminar);
            this.groupBox2.Controls.Add(this.button_Atras);
            this.groupBox2.Location = new System.Drawing.Point(482, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(124, 150);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones";
            // 
            // Listado_Empresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 541);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_Filtrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_Empresa);
            this.Controls.Add(this.Empresa_Seleccionada);
            this.Controls.Add(this.button_Seleccionar);
            this.Controls.Add(this.Lista_Empresas);
            this.Name = "Listado_Empresas";
            this.Text = "Listado_Empresas";
            ((System.ComponentModel.ISupportInitialize)(this.Lista_Empresas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Lista_Empresas;
        private System.Windows.Forms.Button button_Seleccionar;
        private System.Windows.Forms.Label Empresa_Seleccionada;
        private System.Windows.Forms.TextBox textBox_Empresa;
        private System.Windows.Forms.Button button_Modificar;
        private System.Windows.Forms.Button button_Eliminar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Filtrar;
        private System.Windows.Forms.TextBox textBox_FiltroMail;
        private System.Windows.Forms.TextBox textBox_FiltroCUIT;
        private System.Windows.Forms.TextBox textBox_FiltroEmpresa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Atras;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}