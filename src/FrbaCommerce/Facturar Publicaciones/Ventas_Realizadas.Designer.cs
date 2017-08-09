namespace FrbaCommerce.Facturar_Publicaciones
{
    partial class Ventas_Realizadas
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_PubliFinalizadas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_PubliAFacturar = new System.Windows.Forms.TextBox();
            this.button_VistaPrevia = new System.Windows.Forms.Button();
            this.button_Facturar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBx_Num = new System.Windows.Forms.TextBox();
            this.txtBx_Cod = new System.Windows.Forms.TextBox();
            this.txtBx_Tarjeta = new System.Windows.Forms.TextBox();
            this.lbl_Cod = new System.Windows.Forms.Label();
            this.lbl_Num = new System.Windows.Forms.Label();
            this.lbl_Tarjeta = new System.Windows.Forms.Label();
            this.comboBox_FormaDePago = new System.Windows.Forms.ComboBox();
            this.label_ErrorMensaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 119);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(633, 246);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cantidad de publicaciones finalizadas:";
            // 
            // textBox_PubliFinalizadas
            // 
            this.textBox_PubliFinalizadas.Location = new System.Drawing.Point(206, 19);
            this.textBox_PubliFinalizadas.Name = "textBox_PubliFinalizadas";
            this.textBox_PubliFinalizadas.ReadOnly = true;
            this.textBox_PubliFinalizadas.Size = new System.Drawing.Size(100, 20);
            this.textBox_PubliFinalizadas.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Publicaciones a facturar:";
            // 
            // textBox_PubliAFacturar
            // 
            this.textBox_PubliAFacturar.Location = new System.Drawing.Point(146, 57);
            this.textBox_PubliAFacturar.Name = "textBox_PubliAFacturar";
            this.textBox_PubliAFacturar.Size = new System.Drawing.Size(100, 20);
            this.textBox_PubliAFacturar.TabIndex = 4;
            // 
            // button_VistaPrevia
            // 
            this.button_VistaPrevia.Location = new System.Drawing.Point(252, 56);
            this.button_VistaPrevia.Name = "button_VistaPrevia";
            this.button_VistaPrevia.Size = new System.Drawing.Size(75, 23);
            this.button_VistaPrevia.TabIndex = 5;
            this.button_VistaPrevia.Text = "Vista previa";
            this.button_VistaPrevia.UseVisualStyleBackColor = true;
            this.button_VistaPrevia.Click += new System.EventHandler(this.button_VistaPrevia_Click);
            // 
            // button_Facturar
            // 
            this.button_Facturar.Location = new System.Drawing.Point(577, 383);
            this.button_Facturar.Name = "button_Facturar";
            this.button_Facturar.Size = new System.Drawing.Size(75, 23);
            this.button_Facturar.TabIndex = 6;
            this.button_Facturar.Text = "Facturar";
            this.button_Facturar.UseVisualStyleBackColor = true;
            this.button_Facturar.Click += new System.EventHandler(this.button_Facturar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(19, 383);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_Cancelar.TabIndex = 7;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Forma de pago:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBx_Num);
            this.groupBox1.Controls.Add(this.txtBx_Cod);
            this.groupBox1.Controls.Add(this.txtBx_Tarjeta);
            this.groupBox1.Controls.Add(this.lbl_Cod);
            this.groupBox1.Controls.Add(this.lbl_Num);
            this.groupBox1.Controls.Add(this.lbl_Tarjeta);
            this.groupBox1.Controls.Add(this.comboBox_FormaDePago);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(344, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 101);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forma de Pago";
            // 
            // txtBx_Num
            // 
            this.txtBx_Num.Location = new System.Drawing.Point(48, 78);
            this.txtBx_Num.Name = "txtBx_Num";
            this.txtBx_Num.Size = new System.Drawing.Size(100, 20);
            this.txtBx_Num.TabIndex = 10;
            // 
            // txtBx_Cod
            // 
            this.txtBx_Cod.Location = new System.Drawing.Point(240, 75);
            this.txtBx_Cod.Name = "txtBx_Cod";
            this.txtBx_Cod.Size = new System.Drawing.Size(47, 20);
            this.txtBx_Cod.TabIndex = 14;
            // 
            // txtBx_Tarjeta
            // 
            this.txtBx_Tarjeta.Location = new System.Drawing.Point(48, 52);
            this.txtBx_Tarjeta.Name = "txtBx_Tarjeta";
            this.txtBx_Tarjeta.Size = new System.Drawing.Size(100, 20);
            this.txtBx_Tarjeta.TabIndex = 13;
            // 
            // lbl_Cod
            // 
            this.lbl_Cod.AutoSize = true;
            this.lbl_Cod.Location = new System.Drawing.Point(154, 78);
            this.lbl_Cod.Name = "lbl_Cod";
            this.lbl_Cod.Size = new System.Drawing.Size(80, 13);
            this.lbl_Cod.TabIndex = 12;
            this.lbl_Cod.Text = "Cod. Seguridad";
            // 
            // lbl_Num
            // 
            this.lbl_Num.AutoSize = true;
            this.lbl_Num.Location = new System.Drawing.Point(6, 78);
            this.lbl_Num.Name = "lbl_Num";
            this.lbl_Num.Size = new System.Drawing.Size(44, 13);
            this.lbl_Num.TabIndex = 11;
            this.lbl_Num.Text = "Número";
            // 
            // lbl_Tarjeta
            // 
            this.lbl_Tarjeta.AutoSize = true;
            this.lbl_Tarjeta.Location = new System.Drawing.Point(6, 54);
            this.lbl_Tarjeta.Name = "lbl_Tarjeta";
            this.lbl_Tarjeta.Size = new System.Drawing.Size(40, 13);
            this.lbl_Tarjeta.TabIndex = 10;
            this.lbl_Tarjeta.Text = "Tarjeta";
            // 
            // comboBox_FormaDePago
            // 
            this.comboBox_FormaDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FormaDePago.FormattingEnabled = true;
            this.comboBox_FormaDePago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta de crédito"});
            this.comboBox_FormaDePago.Location = new System.Drawing.Point(123, 23);
            this.comboBox_FormaDePago.Name = "comboBox_FormaDePago";
            this.comboBox_FormaDePago.Size = new System.Drawing.Size(121, 21);
            this.comboBox_FormaDePago.TabIndex = 9;
            this.comboBox_FormaDePago.SelectedIndexChanged += new System.EventHandler(this.comboBox_FormaDePago_SelectedIndexChanged);
            // 
            // label_ErrorMensaje
            // 
            this.label_ErrorMensaje.AutoSize = true;
            this.label_ErrorMensaje.ForeColor = System.Drawing.Color.Red;
            this.label_ErrorMensaje.Location = new System.Drawing.Point(249, 393);
            this.label_ErrorMensaje.Name = "label_ErrorMensaje";
            this.label_ErrorMensaje.Size = new System.Drawing.Size(35, 13);
            this.label_ErrorMensaje.TabIndex = 15;
            this.label_ErrorMensaje.Text = "label4";
            // 
            // Ventas_Realizadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 421);
            this.Controls.Add(this.label_ErrorMensaje);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Facturar);
            this.Controls.Add(this.button_VistaPrevia);
            this.Controls.Add(this.textBox_PubliAFacturar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_PubliFinalizadas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Ventas_Realizadas";
            this.Text = "Ventas_Realizadas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_PubliFinalizadas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_PubliAFacturar;
        private System.Windows.Forms.Button button_VistaPrevia;
        private System.Windows.Forms.Button button_Facturar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_FormaDePago;
        private System.Windows.Forms.TextBox txtBx_Cod;
        private System.Windows.Forms.TextBox txtBx_Tarjeta;
        private System.Windows.Forms.Label lbl_Cod;
        private System.Windows.Forms.Label lbl_Num;
        private System.Windows.Forms.Label lbl_Tarjeta;
        private System.Windows.Forms.TextBox txtBx_Num;
        private System.Windows.Forms.Label label_ErrorMensaje;
    }
}