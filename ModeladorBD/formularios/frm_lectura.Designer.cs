namespace ModeladorBD
{
    partial class frm_lectura
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
            this.btn_buscar_archivo = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txt_query = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_proceder = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.txtBaseDatos = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_buscar_archivo
            // 
            this.btn_buscar_archivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_buscar_archivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar_archivo.Location = new System.Drawing.Point(12, 48);
            this.btn_buscar_archivo.Name = "btn_buscar_archivo";
            this.btn_buscar_archivo.Size = new System.Drawing.Size(352, 35);
            this.btn_buscar_archivo.TabIndex = 0;
            this.btn_buscar_archivo.Text = "...";
            this.btn_buscar_archivo.UseVisualStyleBackColor = true;
            this.btn_buscar_archivo.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "sql";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Text files (*.sql)|*.sql|All files (*.*)|*.*";
            // 
            // txt_query
            // 
            this.txt_query.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_query.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_query.Location = new System.Drawing.Point(12, 89);
            this.txt_query.Name = "txt_query";
            this.txt_query.Size = new System.Drawing.Size(352, 485);
            this.txt_query.TabIndex = 1;
            this.txt_query.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione el Archivo";
            // 
            // btn_proceder
            // 
            this.btn_proceder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_proceder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_proceder.Location = new System.Drawing.Point(113, 580);
            this.btn_proceder.Name = "btn_proceder";
            this.btn_proceder.Size = new System.Drawing.Size(155, 29);
            this.btn_proceder.TabIndex = 2;
            this.btn_proceder.Text = "Ejecutar";
            this.btn_proceder.UseVisualStyleBackColor = true;
            this.btn_proceder.Click += new System.EventHandler(this.btn_proceder_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_salir.AutoSize = true;
            this.btn_salir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_salir.Location = new System.Drawing.Point(321, 5);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(44, 42);
            this.btn_salir.TabIndex = 3;
            this.btn_salir.Text = "X";
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // txtBaseDatos
            // 
            this.txtBaseDatos.Location = new System.Drawing.Point(274, 586);
            this.txtBaseDatos.Name = "txtBaseDatos";
            this.txtBaseDatos.Size = new System.Drawing.Size(170, 20);
            this.txtBaseDatos.TabIndex = 26;
            this.txtBaseDatos.Visible = false;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(274, 586);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(170, 20);
            this.txtPass.TabIndex = 25;
            this.txtPass.Visible = false;
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(274, 586);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(170, 20);
            this.txtServidor.TabIndex = 22;
            this.txtServidor.Visible = false;
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(316, 586);
            this.txtPuerto.MaxLength = 6;
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(86, 20);
            this.txtPuerto.TabIndex = 23;
            this.txtPuerto.Visible = false;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(274, 586);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(170, 20);
            this.txtUser.TabIndex = 24;
            this.txtUser.Visible = false;
            // 
            // frm_lectura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.CancelButton = this.btn_salir;
            this.ClientSize = new System.Drawing.Size(374, 611);
            this.ControlBox = false;
            this.Controls.Add(this.txtBaseDatos);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_proceder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_query);
            this.Controls.Add(this.btn_buscar_archivo);
            this.Name = "frm_lectura";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lectura de Archivo Sql";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_buscar_archivo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox txt_query;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_proceder;
        private System.Windows.Forms.Button btn_salir;
        public System.Windows.Forms.TextBox txtBaseDatos;
        public System.Windows.Forms.TextBox txtPass;
        public System.Windows.Forms.TextBox txtServidor;
        public System.Windows.Forms.TextBox txtPuerto;
        public System.Windows.Forms.TextBox txtUser;
    }
}