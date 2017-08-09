namespace FrbaCommerce.Calificar_Vendedor
{
    partial class CalificarCompra
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
            this.btn_Atras = new System.Windows.Forms.Button();
            this.btn_Calificar = new System.Windows.Forms.Button();
            this.txtBx_Calificacion = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelRemaining = new System.Windows.Forms.Label();
            this.label_ErrorMensaje = new System.Windows.Forms.Label();
            this.label_ErrorM = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calificación (Obligatorio)";
            // 
            // btn_Atras
            // 
            this.btn_Atras.Location = new System.Drawing.Point(16, 225);
            this.btn_Atras.Name = "btn_Atras";
            this.btn_Atras.Size = new System.Drawing.Size(75, 23);
            this.btn_Atras.TabIndex = 1;
            this.btn_Atras.Text = "Atrás";
            this.btn_Atras.UseVisualStyleBackColor = true;
            this.btn_Atras.Click += new System.EventHandler(this.btn_Atras_Click);
            // 
            // btn_Calificar
            // 
            this.btn_Calificar.Location = new System.Drawing.Point(197, 225);
            this.btn_Calificar.Name = "btn_Calificar";
            this.btn_Calificar.Size = new System.Drawing.Size(75, 23);
            this.btn_Calificar.TabIndex = 2;
            this.btn_Calificar.Text = "Calificar";
            this.btn_Calificar.UseVisualStyleBackColor = true;
            this.btn_Calificar.Click += new System.EventHandler(this.btn_Calificar_Click);
            // 
            // txtBx_Calificacion
            // 
            this.txtBx_Calificacion.Location = new System.Drawing.Point(11, 122);
            this.txtBx_Calificacion.MaxLength = 140;
            this.txtBx_Calificacion.Multiline = true;
            this.txtBx_Calificacion.Name = "txtBx_Calificacion";
            this.txtBx_Calificacion.Size = new System.Drawing.Size(256, 47);
            this.txtBx_Calificacion.TabIndex = 3;
            this.txtBx_Calificacion.TextChanged += new System.EventHandler(this.txtBx_Calificacion_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Caracteres restantes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descripción (opcional)";
            // 
            // labelRemaining
            // 
            this.labelRemaining.AutoSize = true;
            this.labelRemaining.Location = new System.Drawing.Point(246, 172);
            this.labelRemaining.Name = "labelRemaining";
            this.labelRemaining.Size = new System.Drawing.Size(0, 13);
            this.labelRemaining.TabIndex = 7;
            // 
            // label_ErrorMensaje
            // 
            this.label_ErrorMensaje.AutoSize = true;
            this.label_ErrorMensaje.ForeColor = System.Drawing.Color.Red;
            this.label_ErrorMensaje.Location = new System.Drawing.Point(16, 206);
            this.label_ErrorMensaje.Name = "label_ErrorMensaje";
            this.label_ErrorMensaje.Size = new System.Drawing.Size(69, 13);
            this.label_ErrorMensaje.TabIndex = 8;
            this.label_ErrorMensaje.Text = "ErrorMensaje";
            // 
            // label_ErrorM
            // 
            this.label_ErrorM.AutoSize = true;
            this.label_ErrorM.ForeColor = System.Drawing.Color.Red;
            this.label_ErrorM.Location = new System.Drawing.Point(142, 61);
            this.label_ErrorM.Name = "label_ErrorM";
            this.label_ErrorM.Size = new System.Drawing.Size(17, 13);
            this.label_ErrorM.TabIndex = 9;
            this.label_ErrorM.Text = "(*)";
            // 
            // CalificarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label_ErrorM);
            this.Controls.Add(this.label_ErrorMensaje);
            this.Controls.Add(this.labelRemaining);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtBx_Calificacion);
            this.Controls.Add(this.btn_Calificar);
            this.Controls.Add(this.btn_Atras);
            this.Controls.Add(this.label1);
            this.Name = "CalificarCompra";
            this.Text = "CalificarCompra";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Atras;
        private System.Windows.Forms.Button btn_Calificar;
        private System.Windows.Forms.TextBox txtBx_Calificacion;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelRemaining;
        private System.Windows.Forms.Label label_ErrorMensaje;
        private System.Windows.Forms.Label label_ErrorM;
    }
}