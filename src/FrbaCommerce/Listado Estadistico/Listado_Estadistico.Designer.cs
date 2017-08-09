namespace FrbaCommerce.Listado_Estadistico
{
    partial class Listado_Estadistico
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
            this.comboBox_Rank = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Listar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_ErrorAnio = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox_Visib = new System.Windows.Forms.ComboBox();
            this.comboBox_Trimestre = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBx_Anio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label_RankSeleccioando = new System.Windows.Forms.Label();
            this.label_ErrorMensaje = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_Rank
            // 
            this.comboBox_Rank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Rank.FormattingEnabled = true;
            this.comboBox_Rank.Items.AddRange(new object[] {
            "Vendedores con mayor cantidad de productos no vendidos",
            "Vendedores con mayor facturación",
            "Vendedores con mayores calificaciones",
            "Clientes con mayor cantidad de publicaciones sin calificar"});
            this.comboBox_Rank.Location = new System.Drawing.Point(91, 33);
            this.comboBox_Rank.Name = "comboBox_Rank";
            this.comboBox_Rank.Size = new System.Drawing.Size(306, 21);
            this.comboBox_Rank.TabIndex = 0;
            this.comboBox_Rank.SelectedIndexChanged += new System.EventHandler(this.comboBox_Rank_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TOP 5:";
            // 
            // btn_Listar
            // 
            this.btn_Listar.Location = new System.Drawing.Point(206, 119);
            this.btn_Listar.Name = "btn_Listar";
            this.btn_Listar.Size = new System.Drawing.Size(78, 34);
            this.btn_Listar.TabIndex = 2;
            this.btn_Listar.Text = "Listar";
            this.btn_Listar.UseVisualStyleBackColor = true;
            this.btn_Listar.Click += new System.EventHandler(this.btn_Listar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 269);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(568, 134);
            this.dataGridView1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Listado:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_ErrorAnio);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.comboBox_Visib);
            this.groupBox1.Controls.Add(this.comboBox_Trimestre);
            this.groupBox1.Controls.Add(this.btn_Listar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBx_Anio);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(26, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 163);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // label_ErrorAnio
            // 
            this.label_ErrorAnio.AutoSize = true;
            this.label_ErrorAnio.ForeColor = System.Drawing.Color.Red;
            this.label_ErrorAnio.Location = new System.Drawing.Point(165, 28);
            this.label_ErrorAnio.Name = "label_ErrorAnio";
            this.label_ErrorAnio.Size = new System.Drawing.Size(35, 13);
            this.label_ErrorAnio.TabIndex = 9;
            this.label_ErrorAnio.Text = "label7";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(206, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 25);
            this.button2.TabIndex = 8;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox_Visib
            // 
            this.comboBox_Visib.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Visib.FormattingEnabled = true;
            this.comboBox_Visib.Location = new System.Drawing.Point(65, 111);
            this.comboBox_Visib.Name = "comboBox_Visib";
            this.comboBox_Visib.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Visib.TabIndex = 5;
            // 
            // comboBox_Trimestre
            // 
            this.comboBox_Trimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Trimestre.FormattingEnabled = true;
            this.comboBox_Trimestre.Items.AddRange(new object[] {
            "Enero - Marzo",
            "Abril - Junio",
            "Julio - Septiembre",
            "Octubre - Diciembre"});
            this.comboBox_Trimestre.Location = new System.Drawing.Point(65, 73);
            this.comboBox_Trimestre.Name = "comboBox_Trimestre";
            this.comboBox_Trimestre.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Trimestre.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Visibildad:";
            // 
            // txtBx_Anio
            // 
            this.txtBx_Anio.Location = new System.Drawing.Point(65, 28);
            this.txtBx_Anio.Name = "txtBx_Anio";
            this.txtBx_Anio.Size = new System.Drawing.Size(94, 20);
            this.txtBx_Anio.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Año:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Trimestre:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_RankSeleccioando
            // 
            this.label_RankSeleccioando.AutoSize = true;
            this.label_RankSeleccioando.Location = new System.Drawing.Point(88, 244);
            this.label_RankSeleccioando.Name = "label_RankSeleccioando";
            this.label_RankSeleccioando.Size = new System.Drawing.Size(35, 13);
            this.label_RankSeleccioando.TabIndex = 8;
            this.label_RankSeleccioando.Text = "label7";
            // 
            // label_ErrorMensaje
            // 
            this.label_ErrorMensaje.AutoSize = true;
            this.label_ErrorMensaje.ForeColor = System.Drawing.Color.Red;
            this.label_ErrorMensaje.Location = new System.Drawing.Point(326, 196);
            this.label_ErrorMensaje.Name = "label_ErrorMensaje";
            this.label_ErrorMensaje.Size = new System.Drawing.Size(35, 13);
            this.label_ErrorMensaje.TabIndex = 10;
            this.label_ErrorMensaje.Text = "label8";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(329, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "asd";
            // 
            // Listado_Estadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 449);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_ErrorMensaje);
            this.Controls.Add(this.label_RankSeleccioando);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Rank);
            this.Name = "Listado_Estadistico";
            this.Text = "Listado Estadistico";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Rank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Listar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_Visib;
        private System.Windows.Forms.ComboBox comboBox_Trimestre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBx_Anio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_RankSeleccioando;
        private System.Windows.Forms.Label label_ErrorAnio;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_ErrorMensaje;
        private System.Windows.Forms.Label label5;
    }
}