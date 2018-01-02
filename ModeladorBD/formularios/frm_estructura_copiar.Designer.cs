namespace ModeladorBD
{
    partial class frm_estructura_copiar
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
            this.btn_salir = new System.Windows.Forms.Button();
            this.grbCadenaConec = new System.Windows.Forms.GroupBox();
            this.lbl_base_datos = new System.Windows.Forms.Label();
            this.btn_listar_esquemas = new System.Windows.Forms.Button();
            this.cmb_base_datos = new System.Windows.Forms.ComboBox();
            this.btn_mostrar = new System.Windows.Forms.Button();
            this.btnConexion = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.lblPuerto = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtBaseDatos_base = new System.Windows.Forms.TextBox();
            this.txtPass_base = new System.Windows.Forms.TextBox();
            this.txtServidor_base = new System.Windows.Forms.TextBox();
            this.txtPuerto_base = new System.Windows.Forms.TextBox();
            this.txtUser_base = new System.Windows.Forms.TextBox();
            this.btn_backup = new System.Windows.Forms.Button();
            this.btn_query = new System.Windows.Forms.Button();
            this.lbl_esquema = new System.Windows.Forms.Label();
            this.lst_esquemas = new System.Windows.Forms.ListBox();
            this.lbl_nombre_esquema = new System.Windows.Forms.Label();
            this.txt_nombre_esquema = new System.Windows.Forms.TextBox();
            this.btn_modelar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_refrescar = new System.Windows.Forms.Button();
            this.grbCadenaConec.SuspendLayout();
            this.SuspendLayout();
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
            this.btn_salir.Location = new System.Drawing.Point(324, 15);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(44, 42);
            this.btn_salir.TabIndex = 0;
            this.btn_salir.Text = "X";
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // grbCadenaConec
            // 
            this.grbCadenaConec.BackColor = System.Drawing.SystemColors.Info;
            this.grbCadenaConec.Controls.Add(this.lbl_base_datos);
            this.grbCadenaConec.Controls.Add(this.btn_listar_esquemas);
            this.grbCadenaConec.Controls.Add(this.cmb_base_datos);
            this.grbCadenaConec.Controls.Add(this.btn_mostrar);
            this.grbCadenaConec.Controls.Add(this.btnConexion);
            this.grbCadenaConec.Controls.Add(this.txtPass);
            this.grbCadenaConec.Controls.Add(this.lblPass);
            this.grbCadenaConec.Controls.Add(this.txtServidor);
            this.grbCadenaConec.Controls.Add(this.btn_salir);
            this.grbCadenaConec.Controls.Add(this.lblHost);
            this.grbCadenaConec.Controls.Add(this.txtPuerto);
            this.grbCadenaConec.Controls.Add(this.lblPuerto);
            this.grbCadenaConec.Controls.Add(this.txtUser);
            this.grbCadenaConec.Controls.Add(this.lblUser);
            this.grbCadenaConec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCadenaConec.Location = new System.Drawing.Point(2, 2);
            this.grbCadenaConec.Name = "grbCadenaConec";
            this.grbCadenaConec.Size = new System.Drawing.Size(374, 247);
            this.grbCadenaConec.TabIndex = 0;
            this.grbCadenaConec.TabStop = false;
            this.grbCadenaConec.Text = "Cadena Conexión";
            // 
            // lbl_base_datos
            // 
            this.lbl_base_datos.AutoSize = true;
            this.lbl_base_datos.BackColor = System.Drawing.SystemColors.Info;
            this.lbl_base_datos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_base_datos.Location = new System.Drawing.Point(59, 183);
            this.lbl_base_datos.Name = "lbl_base_datos";
            this.lbl_base_datos.Size = new System.Drawing.Size(115, 20);
            this.lbl_base_datos.TabIndex = 11;
            this.lbl_base_datos.Text = "Base de Datos";
            this.lbl_base_datos.Visible = false;
            // 
            // btn_listar_esquemas
            // 
            this.btn_listar_esquemas.Location = new System.Drawing.Point(232, 206);
            this.btn_listar_esquemas.Name = "btn_listar_esquemas";
            this.btn_listar_esquemas.Size = new System.Drawing.Size(136, 29);
            this.btn_listar_esquemas.TabIndex = 13;
            this.btn_listar_esquemas.Text = "Listar Esquemas";
            this.btn_listar_esquemas.UseVisualStyleBackColor = true;
            this.btn_listar_esquemas.Visible = false;
            this.btn_listar_esquemas.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmb_base_datos
            // 
            this.cmb_base_datos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_base_datos.FormattingEnabled = true;
            this.cmb_base_datos.Location = new System.Drawing.Point(5, 206);
            this.cmb_base_datos.Name = "cmb_base_datos";
            this.cmb_base_datos.Size = new System.Drawing.Size(222, 28);
            this.cmb_base_datos.TabIndex = 12;
            this.cmb_base_datos.Visible = false;
            // 
            // btn_mostrar
            // 
            this.btn_mostrar.Location = new System.Drawing.Point(316, 118);
            this.btn_mostrar.Name = "btn_mostrar";
            this.btn_mostrar.Size = new System.Drawing.Size(33, 29);
            this.btn_mostrar.TabIndex = 9;
            this.btn_mostrar.Text = "O";
            this.btn_mostrar.UseVisualStyleBackColor = true;
            this.btn_mostrar.Click += new System.EventHandler(this.btn_mostrar_Click);
            // 
            // btnConexion
            // 
            this.btnConexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnConexion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConexion.Location = new System.Drawing.Point(140, 151);
            this.btnConexion.Name = "btnConexion";
            this.btnConexion.Size = new System.Drawing.Size(173, 27);
            this.btnConexion.TabIndex = 10;
            this.btnConexion.Text = "Conectar";
            this.btnConexion.UseVisualStyleBackColor = false;
            this.btnConexion.Click += new System.EventHandler(this.btnConexion_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(140, 119);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(170, 26);
            this.txtPass.TabIndex = 8;
            this.txtPass.Text = "parqueabeja";
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(16, 122);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(104, 20);
            this.lblPass.TabIndex = 7;
            this.lblPass.Text = "Contraseña : ";
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(140, 27);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(170, 26);
            this.txtServidor.TabIndex = 2;
            this.txtServidor.Text = "192.168.0.25";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(16, 30);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(79, 20);
            this.lblHost.TabIndex = 1;
            this.lblHost.Text = "Servidor : ";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(140, 88);
            this.txtPuerto.MaxLength = 6;
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(86, 26);
            this.txtPuerto.TabIndex = 6;
            this.txtPuerto.Text = "5432";
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Location = new System.Drawing.Point(16, 91);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(68, 20);
            this.lblPuerto.TabIndex = 5;
            this.lblPuerto.Text = "Puerto : ";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(140, 58);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(170, 26);
            this.txtUser.TabIndex = 4;
            this.txtUser.Text = "postgres";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(16, 61);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(76, 20);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Usuario : ";
            // 
            // txtBaseDatos_base
            // 
            this.txtBaseDatos_base.Location = new System.Drawing.Point(22, 471);
            this.txtBaseDatos_base.Name = "txtBaseDatos_base";
            this.txtBaseDatos_base.Size = new System.Drawing.Size(170, 20);
            this.txtBaseDatos_base.TabIndex = 28;
            this.txtBaseDatos_base.Text = "sisplani_sql_fuente";
            this.txtBaseDatos_base.Visible = false;
            // 
            // txtPass_base
            // 
            this.txtPass_base.Location = new System.Drawing.Point(25, 471);
            this.txtPass_base.Name = "txtPass_base";
            this.txtPass_base.PasswordChar = '*';
            this.txtPass_base.Size = new System.Drawing.Size(170, 20);
            this.txtPass_base.TabIndex = 27;
            this.txtPass_base.Text = "sisplani";
            this.txtPass_base.Visible = false;
            // 
            // txtServidor_base
            // 
            this.txtServidor_base.Location = new System.Drawing.Point(25, 471);
            this.txtServidor_base.Name = "txtServidor_base";
            this.txtServidor_base.Size = new System.Drawing.Size(170, 20);
            this.txtServidor_base.TabIndex = 24;
            this.txtServidor_base.Text = "192.168.0.25";
            this.txtServidor_base.Visible = false;
            // 
            // txtPuerto_base
            // 
            this.txtPuerto_base.Location = new System.Drawing.Point(25, 470);
            this.txtPuerto_base.MaxLength = 6;
            this.txtPuerto_base.Name = "txtPuerto_base";
            this.txtPuerto_base.Size = new System.Drawing.Size(86, 20);
            this.txtPuerto_base.TabIndex = 25;
            this.txtPuerto_base.Text = "5433";
            this.txtPuerto_base.Visible = false;
            // 
            // txtUser_base
            // 
            this.txtUser_base.Location = new System.Drawing.Point(25, 471);
            this.txtUser_base.Name = "txtUser_base";
            this.txtUser_base.Size = new System.Drawing.Size(170, 20);
            this.txtUser_base.TabIndex = 26;
            this.txtUser_base.Text = "postgres";
            this.txtUser_base.Visible = false;
            // 
            // btn_backup
            // 
            this.btn_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_backup.Location = new System.Drawing.Point(189, 416);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.Size = new System.Drawing.Size(162, 30);
            this.btn_backup.TabIndex = 7;
            this.btn_backup.Text = "Backup -- Restore";
            this.btn_backup.UseVisualStyleBackColor = true;
            this.btn_backup.Visible = false;
            this.btn_backup.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btn_query
            // 
            this.btn_query.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_query.Location = new System.Drawing.Point(189, 382);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(162, 30);
            this.btn_query.TabIndex = 6;
            this.btn_query.Text = "Ejecutar Archivo sql";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Visible = false;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // lbl_esquema
            // 
            this.lbl_esquema.AutoSize = true;
            this.lbl_esquema.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_esquema.Location = new System.Drawing.Point(62, 295);
            this.lbl_esquema.Name = "lbl_esquema";
            this.lbl_esquema.Size = new System.Drawing.Size(77, 20);
            this.lbl_esquema.TabIndex = 1;
            this.lbl_esquema.Text = "Esquema";
            this.lbl_esquema.Visible = false;
            // 
            // lst_esquemas
            // 
            this.lst_esquemas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_esquemas.FormattingEnabled = true;
            this.lst_esquemas.ItemHeight = 20;
            this.lst_esquemas.Location = new System.Drawing.Point(28, 318);
            this.lst_esquemas.Name = "lst_esquemas";
            this.lst_esquemas.Size = new System.Drawing.Size(145, 124);
            this.lst_esquemas.TabIndex = 2;
            this.lst_esquemas.Visible = false;
            // 
            // lbl_nombre_esquema
            // 
            this.lbl_nombre_esquema.AutoSize = true;
            this.lbl_nombre_esquema.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nombre_esquema.Location = new System.Drawing.Point(189, 295);
            this.lbl_nombre_esquema.Name = "lbl_nombre_esquema";
            this.lbl_nombre_esquema.Size = new System.Drawing.Size(162, 20);
            this.lbl_nombre_esquema.TabIndex = 3;
            this.lbl_nombre_esquema.Text = "Nombre del Esquema";
            this.lbl_nombre_esquema.Visible = false;
            // 
            // txt_nombre_esquema
            // 
            this.txt_nombre_esquema.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombre_esquema.Location = new System.Drawing.Point(185, 318);
            this.txt_nombre_esquema.Name = "txt_nombre_esquema";
            this.txt_nombre_esquema.Size = new System.Drawing.Size(170, 26);
            this.txt_nombre_esquema.TabIndex = 4;
            this.txt_nombre_esquema.Text = "nuevo";
            this.txt_nombre_esquema.Visible = false;
            // 
            // btn_modelar
            // 
            this.btn_modelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_modelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modelar.Location = new System.Drawing.Point(189, 350);
            this.btn_modelar.Name = "btn_modelar";
            this.btn_modelar.Size = new System.Drawing.Size(162, 30);
            this.btn_modelar.TabIndex = 5;
            this.btn_modelar.Text = "Copiar Esquema";
            this.btn_modelar.UseVisualStyleBackColor = false;
            this.btn_modelar.Visible = false;
            this.btn_modelar.Click += new System.EventHandler(this.btn_modelar_Click);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(292, 247);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 42);
            this.button3.TabIndex = 10;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(113, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 29);
            this.button2.TabIndex = 8;
            this.button2.Text = "Desconectar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_refrescar
            // 
            this.btn_refrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_refrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_refrescar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refrescar.Location = new System.Drawing.Point(19, 254);
            this.btn_refrescar.Name = "btn_refrescar";
            this.btn_refrescar.Size = new System.Drawing.Size(88, 27);
            this.btn_refrescar.TabIndex = 9;
            this.btn_refrescar.Text = "Actualizar";
            this.btn_refrescar.UseVisualStyleBackColor = false;
            this.btn_refrescar.Click += new System.EventHandler(this.btn_refrescar_Click);
            // 
            // frm_estructura_copiar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.CancelButton = this.button3;
            this.ClientSize = new System.Drawing.Size(374, 453);
            this.ControlBox = false;
            this.Controls.Add(this.btn_refrescar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_backup);
            this.Controls.Add(this.btn_query);
            this.Controls.Add(this.lbl_esquema);
            this.Controls.Add(this.lst_esquemas);
            this.Controls.Add(this.lbl_nombre_esquema);
            this.Controls.Add(this.txt_nombre_esquema);
            this.Controls.Add(this.btn_modelar);
            this.Controls.Add(this.txtBaseDatos_base);
            this.Controls.Add(this.txtPass_base);
            this.Controls.Add(this.txtServidor_base);
            this.Controls.Add(this.txtPuerto_base);
            this.Controls.Add(this.txtUser_base);
            this.Controls.Add(this.grbCadenaConec);
            this.Name = "frm_estructura_copiar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copiar Estructura de Base Datos Externa";
            this.grbCadenaConec.ResumeLayout(false);
            this.grbCadenaConec.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.GroupBox grbCadenaConec;
        private System.Windows.Forms.Button btnConexion;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btn_mostrar;
        public System.Windows.Forms.TextBox txtPass_base;
        public System.Windows.Forms.TextBox txtServidor_base;
        public System.Windows.Forms.TextBox txtPuerto_base;
        public System.Windows.Forms.TextBox txtUser_base;
        public System.Windows.Forms.TextBox txtPass;
        public System.Windows.Forms.TextBox txtServidor;
        public System.Windows.Forms.TextBox txtPuerto;
        public System.Windows.Forms.TextBox txtUser;
        public System.Windows.Forms.TextBox txtBaseDatos_base;
        private System.Windows.Forms.Button btn_listar_esquemas;
        private System.Windows.Forms.ComboBox cmb_base_datos;
        private System.Windows.Forms.Label lbl_base_datos;
        private System.Windows.Forms.Button btn_backup;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Label lbl_esquema;
        private System.Windows.Forms.ListBox lst_esquemas;
        private System.Windows.Forms.Label lbl_nombre_esquema;
        public System.Windows.Forms.TextBox txt_nombre_esquema;
        private System.Windows.Forms.Button btn_modelar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_refrescar;
    }
}