namespace FrbaCommerce.Historial_Cliente
{
    partial class Historial_Listar
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
            this.button_PrimerPagina = new System.Windows.Forms.Button();
            this.button_UltimaPagina = new System.Windows.Forms.Button();
            this.button_PagSiguiente = new System.Windows.Forms.Button();
            this.button_PagAnterior = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Actualizar = new System.Windows.Forms.Button();
            this.maskedTextBox4 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Atras = new System.Windows.Forms.Button();
            this.comboBox_Filtro = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_PrimerPagina
            // 
            this.button_PrimerPagina.Location = new System.Drawing.Point(274, 120);
            this.button_PrimerPagina.Name = "button_PrimerPagina";
            this.button_PrimerPagina.Size = new System.Drawing.Size(119, 23);
            this.button_PrimerPagina.TabIndex = 29;
            this.button_PrimerPagina.Text = "Primera pagina";
            this.button_PrimerPagina.UseVisualStyleBackColor = true;
            this.button_PrimerPagina.Click += new System.EventHandler(this.button_PrimerPagina_Click);
            // 
            // button_UltimaPagina
            // 
            this.button_UltimaPagina.Location = new System.Drawing.Point(562, 120);
            this.button_UltimaPagina.Name = "button_UltimaPagina";
            this.button_UltimaPagina.Size = new System.Drawing.Size(108, 23);
            this.button_UltimaPagina.TabIndex = 28;
            this.button_UltimaPagina.Text = "Ultima Pagina";
            this.button_UltimaPagina.UseVisualStyleBackColor = true;
            this.button_UltimaPagina.Click += new System.EventHandler(this.button_UltimaPagina_Click);
            // 
            // button_PagSiguiente
            // 
            this.button_PagSiguiente.Location = new System.Drawing.Point(480, 120);
            this.button_PagSiguiente.Name = "button_PagSiguiente";
            this.button_PagSiguiente.Size = new System.Drawing.Size(75, 23);
            this.button_PagSiguiente.TabIndex = 27;
            this.button_PagSiguiente.Text = "Siguiente";
            this.button_PagSiguiente.UseVisualStyleBackColor = true;
            this.button_PagSiguiente.Click += new System.EventHandler(this.button_PagSiguiente_Click);
            // 
            // button_PagAnterior
            // 
            this.button_PagAnterior.Location = new System.Drawing.Point(399, 120);
            this.button_PagAnterior.Name = "button_PagAnterior";
            this.button_PagAnterior.Size = new System.Drawing.Size(75, 23);
            this.button_PagAnterior.TabIndex = 26;
            this.button_PagAnterior.Text = "Anterior";
            this.button_PagAnterior.UseVisualStyleBackColor = true;
            this.button_PagAnterior.Click += new System.EventHandler(this.button_PagAnterior_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 152);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(666, 353);
            this.dataGridView1.TabIndex = 25;
            // 
            // button_Actualizar
            // 
            this.button_Actualizar.Location = new System.Drawing.Point(164, 117);
            this.button_Actualizar.Name = "button_Actualizar";
            this.button_Actualizar.Size = new System.Drawing.Size(74, 29);
            this.button_Actualizar.TabIndex = 38;
            this.button_Actualizar.Text = "Actualizar";
            this.button_Actualizar.UseVisualStyleBackColor = true;
            this.button_Actualizar.Click += new System.EventHandler(this.button_Actualizar_Click);
            // 
            // maskedTextBox4
            // 
            this.maskedTextBox4.Location = new System.Drawing.Point(138, 91);
            this.maskedTextBox4.Mask = "9999999999";
            this.maskedTextBox4.Name = "maskedTextBox4";
            this.maskedTextBox4.PromptChar = ' ';
            this.maskedTextBox4.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox4.TabIndex = 37;
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.Enabled = false;
            this.maskedTextBox3.Location = new System.Drawing.Point(138, 65);
            this.maskedTextBox3.Mask = "9999999999";
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.PromptChar = ' ';
            this.maskedTextBox3.ReadOnly = true;
            this.maskedTextBox3.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox3.TabIndex = 36;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Enabled = false;
            this.maskedTextBox2.Location = new System.Drawing.Point(138, 39);
            this.maskedTextBox2.Mask = "9999999999";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.PromptChar = ' ';
            this.maskedTextBox2.ReadOnly = true;
            this.maskedTextBox2.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox2.TabIndex = 35;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Enabled = false;
            this.maskedTextBox1.Location = new System.Drawing.Point(138, 13);
            this.maskedTextBox1.Mask = "9999999999";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PromptChar = ' ';
            this.maskedTextBox1.ReadOnly = true;
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(22, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Maximo por pagina:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(50, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Ultima pagina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(27, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Numero de pagina";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Cantidad de registros:";
            // 
            // button_Atras
            // 
            this.button_Atras.Location = new System.Drawing.Point(15, 117);
            this.button_Atras.Name = "button_Atras";
            this.button_Atras.Size = new System.Drawing.Size(75, 29);
            this.button_Atras.TabIndex = 39;
            this.button_Atras.Text = "Atras";
            this.button_Atras.UseVisualStyleBackColor = true;
            this.button_Atras.Click += new System.EventHandler(this.button_Atras_Click);
            // 
            // comboBox_Filtro
            // 
            this.comboBox_Filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Filtro.FormattingEnabled = true;
            this.comboBox_Filtro.Location = new System.Drawing.Point(331, 12);
            this.comboBox_Filtro.Name = "comboBox_Filtro";
            this.comboBox_Filtro.Size = new System.Drawing.Size(173, 21);
            this.comboBox_Filtro.TabIndex = 40;
            this.comboBox_Filtro.SelectedIndexChanged += new System.EventHandler(this.comboBox_Filtro_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Vista por:";
            // 
            // Historial_Listar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 517);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_Filtro);
            this.Controls.Add(this.button_Atras);
            this.Controls.Add(this.button_Actualizar);
            this.Controls.Add(this.maskedTextBox4);
            this.Controls.Add(this.maskedTextBox3);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_PrimerPagina);
            this.Controls.Add(this.button_UltimaPagina);
            this.Controls.Add(this.button_PagSiguiente);
            this.Controls.Add(this.button_PagAnterior);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Historial_Listar";
            this.Text = "Historial_Listar";
            this.Load += new System.EventHandler(this.Historial_Listar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_PrimerPagina;
        private System.Windows.Forms.Button button_UltimaPagina;
        private System.Windows.Forms.Button button_PagSiguiente;
        private System.Windows.Forms.Button button_PagAnterior;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Actualizar;
        private System.Windows.Forms.MaskedTextBox maskedTextBox4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Atras;
        private System.Windows.Forms.ComboBox comboBox_Filtro;
        private System.Windows.Forms.Label label5;
    }
}