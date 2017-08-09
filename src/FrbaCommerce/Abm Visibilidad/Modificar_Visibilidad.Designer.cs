namespace FrbaCommerce.Abm_Visibilidad
{
    partial class Modificar_Visibilidad
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_desc = new System.Windows.Forms.TextBox();
            this.textBox_precio = new System.Windows.Forms.TextBox();
            this.textBox_porc = new System.Windows.Forms.TextBox();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBx_CodVisib = new System.Windows.Forms.TextBox();
            this.btn_Cargar = new System.Windows.Forms.Button();
            this.label_ErrorDesc = new System.Windows.Forms.Label();
            this.label_ErrorPrecio = new System.Windows.Forms.Label();
            this.label_ErrorPorcentaje = new System.Windows.Forms.Label();
            this.label_ErrorMensaje = new System.Windows.Forms.Label();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_dias = new System.Windows.Forms.TextBox();
            this.label_ErrorDias = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Precio p/ publicar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Porcentaje por venta";
            // 
            // textBox_desc
            // 
            this.textBox_desc.Location = new System.Drawing.Point(346, 75);
            this.textBox_desc.Multiline = true;
            this.textBox_desc.Name = "textBox_desc";
            this.textBox_desc.Size = new System.Drawing.Size(125, 35);
            this.textBox_desc.TabIndex = 3;
            // 
            // textBox_precio
            // 
            this.textBox_precio.Location = new System.Drawing.Point(346, 118);
            this.textBox_precio.Name = "textBox_precio";
            this.textBox_precio.Size = new System.Drawing.Size(125, 20);
            this.textBox_precio.TabIndex = 8;
            // 
            // textBox_porc
            // 
            this.textBox_porc.Location = new System.Drawing.Point(346, 164);
            this.textBox_porc.Name = "textBox_porc";
            this.textBox_porc.Size = new System.Drawing.Size(125, 20);
            this.textBox_porc.TabIndex = 9;
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(422, 265);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(75, 34);
            this.button_aceptar.TabIndex = 4;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(27, 265);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 34);
            this.button_cancelar.TabIndex = 5;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Visibilidades";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(27, 50);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(181, 173);
            this.listBox1.TabIndex = 11;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Visibilidad Seleccionada:";
            // 
            // txtBx_CodVisib
            // 
            this.txtBx_CodVisib.Location = new System.Drawing.Point(375, 6);
            this.txtBx_CodVisib.Name = "txtBx_CodVisib";
            this.txtBx_CodVisib.ReadOnly = true;
            this.txtBx_CodVisib.Size = new System.Drawing.Size(100, 20);
            this.txtBx_CodVisib.TabIndex = 13;
            // 
            // btn_Cargar
            // 
            this.btn_Cargar.Location = new System.Drawing.Point(248, 35);
            this.btn_Cargar.Name = "btn_Cargar";
            this.btn_Cargar.Size = new System.Drawing.Size(121, 23);
            this.btn_Cargar.TabIndex = 14;
            this.btn_Cargar.Text = "Cargar";
            this.btn_Cargar.UseVisualStyleBackColor = true;
            this.btn_Cargar.Click += new System.EventHandler(this.btn_Cargar_Click);
            // 
            // label_ErrorDesc
            // 
            this.label_ErrorDesc.AutoSize = true;
            this.label_ErrorDesc.ForeColor = System.Drawing.Color.Red;
            this.label_ErrorDesc.Location = new System.Drawing.Point(477, 78);
            this.label_ErrorDesc.Name = "label_ErrorDesc";
            this.label_ErrorDesc.Size = new System.Drawing.Size(35, 13);
            this.label_ErrorDesc.TabIndex = 15;
            this.label_ErrorDesc.Text = "label6";
            // 
            // label_ErrorPrecio
            // 
            this.label_ErrorPrecio.AutoSize = true;
            this.label_ErrorPrecio.ForeColor = System.Drawing.Color.Red;
            this.label_ErrorPrecio.Location = new System.Drawing.Point(477, 121);
            this.label_ErrorPrecio.Name = "label_ErrorPrecio";
            this.label_ErrorPrecio.Size = new System.Drawing.Size(35, 13);
            this.label_ErrorPrecio.TabIndex = 16;
            this.label_ErrorPrecio.Text = "label7";
            // 
            // label_ErrorPorcentaje
            // 
            this.label_ErrorPorcentaje.AutoSize = true;
            this.label_ErrorPorcentaje.ForeColor = System.Drawing.Color.Red;
            this.label_ErrorPorcentaje.Location = new System.Drawing.Point(477, 164);
            this.label_ErrorPorcentaje.Name = "label_ErrorPorcentaje";
            this.label_ErrorPorcentaje.Size = new System.Drawing.Size(35, 13);
            this.label_ErrorPorcentaje.TabIndex = 17;
            this.label_ErrorPorcentaje.Text = "label8";
            // 
            // label_ErrorMensaje
            // 
            this.label_ErrorMensaje.AutoSize = true;
            this.label_ErrorMensaje.ForeColor = System.Drawing.Color.Red;
            this.label_ErrorMensaje.Location = new System.Drawing.Point(119, 276);
            this.label_ErrorMensaje.Name = "label_ErrorMensaje";
            this.label_ErrorMensaje.Size = new System.Drawing.Size(35, 13);
            this.label_ErrorMensaje.TabIndex = 18;
            this.label_ErrorMensaje.Text = "label9";
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Location = new System.Drawing.Point(400, 35);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(75, 23);
            this.btn_Eliminar.TabIndex = 19;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(230, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Duración (en días)";
            // 
            // textBox_dias
            // 
            this.textBox_dias.Location = new System.Drawing.Point(346, 209);
            this.textBox_dias.Name = "textBox_dias";
            this.textBox_dias.Size = new System.Drawing.Size(125, 20);
            this.textBox_dias.TabIndex = 21;
            // 
            // label_ErrorDias
            // 
            this.label_ErrorDias.AutoSize = true;
            this.label_ErrorDias.ForeColor = System.Drawing.Color.Red;
            this.label_ErrorDias.Location = new System.Drawing.Point(477, 212);
            this.label_ErrorDias.Name = "label_ErrorDias";
            this.label_ErrorDias.Size = new System.Drawing.Size(35, 13);
            this.label_ErrorDias.TabIndex = 22;
            this.label_ErrorDias.Text = "label7";
            // 
            // Modificar_Visibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 316);
            this.Controls.Add(this.label_ErrorDias);
            this.Controls.Add(this.textBox_dias);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.label_ErrorMensaje);
            this.Controls.Add(this.label_ErrorPorcentaje);
            this.Controls.Add(this.label_ErrorPrecio);
            this.Controls.Add(this.label_ErrorDesc);
            this.Controls.Add(this.btn_Cargar);
            this.Controls.Add(this.txtBx_CodVisib);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_porc);
            this.Controls.Add(this.textBox_precio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.textBox_desc);
            this.Controls.Add(this.label2);
            this.Name = "Modificar_Visibilidad";
            this.Text = "Modificar_Visibilidad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_desc;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_precio;
        private System.Windows.Forms.TextBox textBox_porc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBx_CodVisib;
        private System.Windows.Forms.Button btn_Cargar;
        private System.Windows.Forms.Label label_ErrorDesc;
        private System.Windows.Forms.Label label_ErrorPrecio;
        private System.Windows.Forms.Label label_ErrorPorcentaje;
        private System.Windows.Forms.Label label_ErrorMensaje;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_dias;
        private System.Windows.Forms.Label label_ErrorDias;
    }
        /*
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Modificar_Visibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 121);
            this.Name = "Modificar_Visibilidad";
            this.Text = "Modificar_Visibilidad";
            this.ResumeLayout(false);

        }

        #endregion
         */
    }
