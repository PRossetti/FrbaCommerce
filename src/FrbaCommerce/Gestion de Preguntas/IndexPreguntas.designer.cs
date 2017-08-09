namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class IndexPreguntas
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
            this.lbl_Preguntas = new System.Windows.Forms.Label();
            this.txtBx_cantPreguntas = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btm_Responder = new System.Windows.Forms.Button();
            this.btn_Atras = new System.Windows.Forms.Button();
            this.btn_verResp = new System.Windows.Forms.Button();
            this.btn_verPreg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Preguntas
            // 
            this.lbl_Preguntas.AutoSize = true;
            this.lbl_Preguntas.Location = new System.Drawing.Point(12, 25);
            this.lbl_Preguntas.Name = "lbl_Preguntas";
            this.lbl_Preguntas.Size = new System.Drawing.Size(183, 13);
            this.lbl_Preguntas.TabIndex = 0;
            this.lbl_Preguntas.Text = "Cantidad de preguntas sin responder:";
            // 
            // txtBx_cantPreguntas
            // 
            this.txtBx_cantPreguntas.Location = new System.Drawing.Point(218, 25);
            this.txtBx_cantPreguntas.Name = "txtBx_cantPreguntas";
            this.txtBx_cantPreguntas.Size = new System.Drawing.Size(37, 20);
            this.txtBx_cantPreguntas.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(791, 161);
            this.dataGridView1.TabIndex = 2;
            // 
            // btm_Responder
            // 
            this.btm_Responder.Location = new System.Drawing.Point(120, 291);
            this.btm_Responder.Name = "btm_Responder";
            this.btm_Responder.Size = new System.Drawing.Size(75, 23);
            this.btm_Responder.TabIndex = 3;
            this.btm_Responder.Text = "Responder";
            this.btm_Responder.UseVisualStyleBackColor = true;
            this.btm_Responder.Click += new System.EventHandler(this.btm_Responder_Click);
            // 
            // btn_Atras
            // 
            this.btn_Atras.Location = new System.Drawing.Point(15, 291);
            this.btn_Atras.Name = "btn_Atras";
            this.btn_Atras.Size = new System.Drawing.Size(75, 23);
            this.btn_Atras.TabIndex = 4;
            this.btn_Atras.Text = "Atrás";
            this.btn_Atras.UseVisualStyleBackColor = true;
            this.btn_Atras.Click += new System.EventHandler(this.btn_Atras_Click);
            // 
            // btn_verResp
            // 
            this.btn_verResp.Location = new System.Drawing.Point(297, 19);
            this.btn_verResp.Name = "btn_verResp";
            this.btn_verResp.Size = new System.Drawing.Size(146, 31);
            this.btn_verResp.TabIndex = 5;
            this.btn_verResp.Text = "Ver respuestas anteriores";
            this.btn_verResp.UseVisualStyleBackColor = true;
            this.btn_verResp.Click += new System.EventHandler(this.btn_verResp_Click);
            // 
            // btn_verPreg
            // 
            this.btn_verPreg.Location = new System.Drawing.Point(504, 19);
            this.btn_verPreg.Name = "btn_verPreg";
            this.btn_verPreg.Size = new System.Drawing.Size(146, 31);
            this.btn_verPreg.TabIndex = 6;
            this.btn_verPreg.Text = "Ver preguntas realizadas";
            this.btn_verPreg.UseVisualStyleBackColor = true;
            this.btn_verPreg.Click += new System.EventHandler(this.btn_verPreg_Click);
            // 
            // IndexPreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 345);
            this.Controls.Add(this.btn_verPreg);
            this.Controls.Add(this.btn_verResp);
            this.Controls.Add(this.btn_Atras);
            this.Controls.Add(this.btm_Responder);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtBx_cantPreguntas);
            this.Controls.Add(this.lbl_Preguntas);
            this.Name = "IndexPreguntas";
            this.Text = "IndexPreguntas";
            this.Load += new System.EventHandler(this.IndexPreguntas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Preguntas;
        private System.Windows.Forms.TextBox txtBx_cantPreguntas;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btm_Responder;
        private System.Windows.Forms.Button btn_Atras;
        private System.Windows.Forms.Button btn_verResp;
        private System.Windows.Forms.Button btn_verPreg;
    }
}