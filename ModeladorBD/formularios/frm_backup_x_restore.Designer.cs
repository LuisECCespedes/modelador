namespace ModeladorBD
{
    partial class frm_backup_x_restore
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
            this.txtBaseDatos = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.safi_Backup = new System.Windows.Forms.SaveFileDialog();
            this.opfi_Pg_Dum = new System.Windows.Forms.OpenFileDialog();
            this.opfi_pg_restore = new System.Windows.Forms.OpenFileDialog();
            this.opfi_ruta_backup = new System.Windows.Forms.OpenFileDialog();
            this.Backup_Restore = new System.Windows.Forms.TabControl();
            this.tb_backup = new System.Windows.Forms.TabPage();
            this.cmb_esquema = new System.Windows.Forms.ComboBox();
            this.chk_solo_schema = new System.Windows.Forms.CheckBox();
            this.grb_backup = new System.Windows.Forms.GroupBox();
            this.txt_ruta_creacion_backup = new System.Windows.Forms.TextBox();
            this.btn_ruta_archivo_backup_nuevo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_proceder_backup = new System.Windows.Forms.Button();
            this.tb_restore = new System.Windows.Forms.TabPage();
            this.grb_restore = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ruta_backup = new System.Windows.Forms.TextBox();
            this.btn_ruta_backup = new System.Windows.Forms.Button();
            this.btn_proceder_restore = new System.Windows.Forms.Button();
            this.Backup_Restore.SuspendLayout();
            this.tb_backup.SuspendLayout();
            this.grb_backup.SuspendLayout();
            this.tb_restore.SuspendLayout();
            this.grb_restore.SuspendLayout();
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
            this.btn_salir.Location = new System.Drawing.Point(450, 0);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(44, 42);
            this.btn_salir.TabIndex = 1;
            this.btn_salir.Text = "X";
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // txtBaseDatos
            // 
            this.txtBaseDatos.Location = new System.Drawing.Point(551, 409);
            this.txtBaseDatos.Name = "txtBaseDatos";
            this.txtBaseDatos.Size = new System.Drawing.Size(170, 20);
            this.txtBaseDatos.TabIndex = 34;
            this.txtBaseDatos.Visible = false;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(551, 409);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(170, 20);
            this.txtPass.TabIndex = 33;
            this.txtPass.Visible = false;
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(551, 409);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(170, 20);
            this.txtServidor.TabIndex = 30;
            this.txtServidor.Visible = false;
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(606, 407);
            this.txtPuerto.MaxLength = 6;
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(86, 20);
            this.txtPuerto.TabIndex = 31;
            this.txtPuerto.Visible = false;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(551, 409);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(170, 20);
            this.txtUser.TabIndex = 32;
            this.txtUser.Visible = false;
            // 
            // safi_Backup
            // 
            this.safi_Backup.DefaultExt = "Text files (*.backup)|*.backup|All files (*.*)|*.*";
            this.safi_Backup.Filter = "Text files (*.backup)|*.backup|All files (*.*)|*.*";
            // 
            // opfi_Pg_Dum
            // 
            this.opfi_Pg_Dum.FileName = "pg_dump.exe";
            // 
            // opfi_pg_restore
            // 
            this.opfi_pg_restore.FileName = "pg_restore.exe";
            // 
            // opfi_ruta_backup
            // 
            this.opfi_ruta_backup.DefaultExt = "Text files (*.backup)|*.backup|All files (*.*)|*.*";
            this.opfi_ruta_backup.Filter = "Text files (*.backup)|*.backup|All files (*.*)|*.*";
            // 
            // Backup_Restore
            // 
            this.Backup_Restore.Controls.Add(this.tb_backup);
            this.Backup_Restore.Controls.Add(this.tb_restore);
            this.Backup_Restore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Backup_Restore.Location = new System.Drawing.Point(5, 15);
            this.Backup_Restore.Name = "Backup_Restore";
            this.Backup_Restore.SelectedIndex = 0;
            this.Backup_Restore.Size = new System.Drawing.Size(490, 191);
            this.Backup_Restore.TabIndex = 0;
            // 
            // tb_backup
            // 
            this.tb_backup.BackColor = System.Drawing.SystemColors.Info;
            this.tb_backup.Controls.Add(this.cmb_esquema);
            this.tb_backup.Controls.Add(this.chk_solo_schema);
            this.tb_backup.Controls.Add(this.grb_backup);
            this.tb_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_backup.Location = new System.Drawing.Point(4, 29);
            this.tb_backup.Name = "tb_backup";
            this.tb_backup.Padding = new System.Windows.Forms.Padding(3);
            this.tb_backup.Size = new System.Drawing.Size(482, 158);
            this.tb_backup.TabIndex = 0;
            this.tb_backup.Text = "Backup";
            // 
            // cmb_esquema
            // 
            this.cmb_esquema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_esquema.FormattingEnabled = true;
            this.cmb_esquema.Location = new System.Drawing.Point(243, 124);
            this.cmb_esquema.Name = "cmb_esquema";
            this.cmb_esquema.Size = new System.Drawing.Size(222, 28);
            this.cmb_esquema.TabIndex = 2;
            this.cmb_esquema.Visible = false;
            // 
            // chk_solo_schema
            // 
            this.chk_solo_schema.AutoSize = true;
            this.chk_solo_schema.Location = new System.Drawing.Point(23, 124);
            this.chk_solo_schema.Name = "chk_solo_schema";
            this.chk_solo_schema.Size = new System.Drawing.Size(211, 24);
            this.chk_solo_schema.TabIndex = 1;
            this.chk_solo_schema.Text = "Esquema Determinado";
            this.chk_solo_schema.UseVisualStyleBackColor = true;
            this.chk_solo_schema.CheckedChanged += new System.EventHandler(this.chk_solo_schema_CheckedChanged);
            // 
            // grb_backup
            // 
            this.grb_backup.Controls.Add(this.txt_ruta_creacion_backup);
            this.grb_backup.Controls.Add(this.btn_ruta_archivo_backup_nuevo);
            this.grb_backup.Controls.Add(this.label1);
            this.grb_backup.Controls.Add(this.btn_proceder_backup);
            this.grb_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_backup.Location = new System.Drawing.Point(8, 10);
            this.grb_backup.Name = "grb_backup";
            this.grb_backup.Size = new System.Drawing.Size(462, 108);
            this.grb_backup.TabIndex = 0;
            this.grb_backup.TabStop = false;
            this.grb_backup.Text = "Backup";
            // 
            // txt_ruta_creacion_backup
            // 
            this.txt_ruta_creacion_backup.Enabled = false;
            this.txt_ruta_creacion_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ruta_creacion_backup.Location = new System.Drawing.Point(11, 41);
            this.txt_ruta_creacion_backup.Name = "txt_ruta_creacion_backup";
            this.txt_ruta_creacion_backup.Size = new System.Drawing.Size(395, 29);
            this.txt_ruta_creacion_backup.TabIndex = 1;
            // 
            // btn_ruta_archivo_backup_nuevo
            // 
            this.btn_ruta_archivo_backup_nuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ruta_archivo_backup_nuevo.Location = new System.Drawing.Point(405, 38);
            this.btn_ruta_archivo_backup_nuevo.Name = "btn_ruta_archivo_backup_nuevo";
            this.btn_ruta_archivo_backup_nuevo.Size = new System.Drawing.Size(46, 35);
            this.btn_ruta_archivo_backup_nuevo.TabIndex = 2;
            this.btn_ruta_archivo_backup_nuevo.Text = "...";
            this.btn_ruta_archivo_backup_nuevo.UseVisualStyleBackColor = true;
            this.btn_ruta_archivo_backup_nuevo.Click += new System.EventHandler(this.btn_buscar_archivo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione la Ruta de Creación";
            // 
            // btn_proceder_backup
            // 
            this.btn_proceder_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_proceder_backup.Location = new System.Drawing.Point(139, 75);
            this.btn_proceder_backup.Name = "btn_proceder_backup";
            this.btn_proceder_backup.Size = new System.Drawing.Size(155, 29);
            this.btn_proceder_backup.TabIndex = 1;
            this.btn_proceder_backup.Text = "Proceder";
            this.btn_proceder_backup.UseVisualStyleBackColor = true;
            this.btn_proceder_backup.Click += new System.EventHandler(this.btn_proceder_Click);
            // 
            // tb_restore
            // 
            this.tb_restore.BackColor = System.Drawing.SystemColors.Info;
            this.tb_restore.Controls.Add(this.grb_restore);
            this.tb_restore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_restore.Location = new System.Drawing.Point(4, 29);
            this.tb_restore.Name = "tb_restore";
            this.tb_restore.Padding = new System.Windows.Forms.Padding(3);
            this.tb_restore.Size = new System.Drawing.Size(482, 154);
            this.tb_restore.TabIndex = 1;
            this.tb_restore.Text = "Restore";
            // 
            // grb_restore
            // 
            this.grb_restore.Controls.Add(this.label3);
            this.grb_restore.Controls.Add(this.txt_ruta_backup);
            this.grb_restore.Controls.Add(this.btn_ruta_backup);
            this.grb_restore.Controls.Add(this.btn_proceder_restore);
            this.grb_restore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_restore.Location = new System.Drawing.Point(10, 11);
            this.grb_restore.Name = "grb_restore";
            this.grb_restore.Size = new System.Drawing.Size(462, 115);
            this.grb_restore.TabIndex = 0;
            this.grb_restore.TabStop = false;
            this.grb_restore.Text = "Restore";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ruta del Backup ";
            // 
            // txt_ruta_backup
            // 
            this.txt_ruta_backup.Enabled = false;
            this.txt_ruta_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ruta_backup.Location = new System.Drawing.Point(11, 44);
            this.txt_ruta_backup.Name = "txt_ruta_backup";
            this.txt_ruta_backup.Size = new System.Drawing.Size(395, 29);
            this.txt_ruta_backup.TabIndex = 9;
            // 
            // btn_ruta_backup
            // 
            this.btn_ruta_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ruta_backup.Location = new System.Drawing.Point(405, 41);
            this.btn_ruta_backup.Name = "btn_ruta_backup";
            this.btn_ruta_backup.Size = new System.Drawing.Size(46, 35);
            this.btn_ruta_backup.TabIndex = 10;
            this.btn_ruta_backup.Text = "...";
            this.btn_ruta_backup.UseVisualStyleBackColor = true;
            this.btn_ruta_backup.Click += new System.EventHandler(this.btn_ruta_backup_Click);
            // 
            // btn_proceder_restore
            // 
            this.btn_proceder_restore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_proceder_restore.Location = new System.Drawing.Point(139, 76);
            this.btn_proceder_restore.Name = "btn_proceder_restore";
            this.btn_proceder_restore.Size = new System.Drawing.Size(155, 29);
            this.btn_proceder_restore.TabIndex = 7;
            this.btn_proceder_restore.Text = "Proceder";
            this.btn_proceder_restore.UseVisualStyleBackColor = true;
            this.btn_proceder_restore.Click += new System.EventHandler(this.btn_proceder_restore_Click);
            // 
            // frm_backup_x_restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.CancelButton = this.btn_salir;
            this.ClientSize = new System.Drawing.Size(496, 207);
            this.ControlBox = false;
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.Backup_Restore);
            this.Controls.Add(this.txtBaseDatos);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.txtUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frm_backup_x_restore";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup -- Restore";
            this.Backup_Restore.ResumeLayout(false);
            this.tb_backup.ResumeLayout(false);
            this.tb_backup.PerformLayout();
            this.grb_backup.ResumeLayout(false);
            this.grb_backup.PerformLayout();
            this.tb_restore.ResumeLayout(false);
            this.grb_restore.ResumeLayout(false);
            this.grb_restore.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_salir;
        public System.Windows.Forms.TextBox txtBaseDatos;
        public System.Windows.Forms.TextBox txtPass;
        public System.Windows.Forms.TextBox txtServidor;
        public System.Windows.Forms.TextBox txtPuerto;
        public System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.SaveFileDialog safi_Backup;
        private System.Windows.Forms.OpenFileDialog opfi_Pg_Dum;
        private System.Windows.Forms.OpenFileDialog opfi_pg_restore;
        private System.Windows.Forms.OpenFileDialog opfi_ruta_backup;
        private System.Windows.Forms.TabControl Backup_Restore;
        private System.Windows.Forms.TabPage tb_backup;
        private System.Windows.Forms.TabPage tb_restore;
        private System.Windows.Forms.GroupBox grb_backup;
        private System.Windows.Forms.TextBox txt_ruta_creacion_backup;
        private System.Windows.Forms.Button btn_ruta_archivo_backup_nuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_proceder_backup;
        private System.Windows.Forms.GroupBox grb_restore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ruta_backup;
        private System.Windows.Forms.Button btn_ruta_backup;
        private System.Windows.Forms.Button btn_proceder_restore;
        private System.Windows.Forms.CheckBox chk_solo_schema;
        private System.Windows.Forms.ComboBox cmb_esquema;
    }
}