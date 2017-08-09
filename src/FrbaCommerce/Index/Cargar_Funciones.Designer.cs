namespace FrbaCommerce.Index
{
    partial class Cargar_Funciones
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
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txt_Rol = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_UsuarioID = new System.Windows.Forms.Label();
            this.txtBx_UsuarioID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Siguiente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Location = new System.Drawing.Point(231, 227);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cerrar.TabIndex = 1;
            this.btn_Cerrar.Text = "Cerrar";
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(36, 71);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(209, 121);
            this.listBox1.TabIndex = 2;
            // 
            // txt_Rol
            // 
            this.txt_Rol.AutoSize = true;
            this.txt_Rol.Location = new System.Drawing.Point(65, 13);
            this.txt_Rol.Name = "txt_Rol";
            this.txt_Rol.Size = new System.Drawing.Size(80, 13);
            this.txt_Rol.TabIndex = 3;
            this.txt_Rol.Text = "Aca figura el rol";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Funciones:";
            // 
            // label_UsuarioID
            // 
            this.label_UsuarioID.AutoSize = true;
            this.label_UsuarioID.Location = new System.Drawing.Point(196, 9);
            this.label_UsuarioID.Name = "label_UsuarioID";
            this.label_UsuarioID.Size = new System.Drawing.Size(60, 13);
            this.label_UsuarioID.TabIndex = 5;
            this.label_UsuarioID.Text = "Usuario ID:";
            // 
            // txtBx_UsuarioID
            // 
            this.txtBx_UsuarioID.Location = new System.Drawing.Point(262, 6);
            this.txtBx_UsuarioID.Name = "txtBx_UsuarioID";
            this.txtBx_UsuarioID.ReadOnly = true;
            this.txtBx_UsuarioID.Size = new System.Drawing.Size(44, 20);
            this.txtBx_UsuarioID.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Rol:";
            // 
            // Cargar_Funciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBx_UsuarioID);
            this.Controls.Add(this.label_UsuarioID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Rol);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.button1);
            this.Name = "Cargar_Funciones";
            this.Text = "Cargar_Funciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label txt_Rol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_UsuarioID;
        private System.Windows.Forms.TextBox txtBx_UsuarioID;
        private System.Windows.Forms.Label label2;

    }
}