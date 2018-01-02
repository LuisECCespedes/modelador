namespace ModeladorBD
{
    partial class frm_principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_principal));
            this.btn_generar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lst_esquemas = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lst_modelo = new System.Windows.Forms.ListBox();
            this.grbCadenaConec = new System.Windows.Forms.GroupBox();
            this.btn_guardar_parametros = new System.Windows.Forms.Button();
            this.lbl_base_datos = new System.Windows.Forms.Label();
            this.btn_listar_esquemas = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
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
            this.rb_estructura = new System.Windows.Forms.RadioButton();
            this.rb_funciones = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_Esquema_comparar = new System.Windows.Forms.RadioButton();
            this.rb_Esquema_modelo = new System.Windows.Forms.RadioButton();
            this.txt_nom_func = new System.Windows.Forms.TextBox();
            this.lbl_nomfun = new System.Windows.Forms.Label();
            this.btn_query = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_copiar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rb_triggers = new System.Windows.Forms.RadioButton();
            this.rb_trigger_index = new System.Windows.Forms.RadioButton();
            this.btn_refrescar = new System.Windows.Forms.Button();
            this.grbCadenaConec.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_generar
            // 
            this.btn_generar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_generar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generar.Location = new System.Drawing.Point(452, 476);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(105, 35);
            this.btn_generar.TabIndex = 12;
            this.btn_generar.Text = "Generar";
            this.btn_generar.UseVisualStyleBackColor = false;
            this.btn_generar.Click += new System.EventHandler(this.btn_generar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(207, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Esquema";
            // 
            // lst_esquemas
            // 
            this.lst_esquemas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_esquemas.FormattingEnabled = true;
            this.lst_esquemas.ItemHeight = 20;
            this.lst_esquemas.Location = new System.Drawing.Point(173, 246);
            this.lst_esquemas.Name = "lst_esquemas";
            this.lst_esquemas.Size = new System.Drawing.Size(145, 224);
            this.lst_esquemas.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Esquema Modelo";
            // 
            // lst_modelo
            // 
            this.lst_modelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_modelo.FormattingEnabled = true;
            this.lst_modelo.ItemHeight = 20;
            this.lst_modelo.Location = new System.Drawing.Point(18, 246);
            this.lst_modelo.Name = "lst_modelo";
            this.lst_modelo.Size = new System.Drawing.Size(148, 224);
            this.lst_modelo.TabIndex = 3;
            // 
            // grbCadenaConec
            // 
            this.grbCadenaConec.BackColor = System.Drawing.SystemColors.Info;
            this.grbCadenaConec.Controls.Add(this.btn_guardar_parametros);
            this.grbCadenaConec.Controls.Add(this.lbl_base_datos);
            this.grbCadenaConec.Controls.Add(this.btn_listar_esquemas);
            this.grbCadenaConec.Controls.Add(this.btn_salir);
            this.grbCadenaConec.Controls.Add(this.cmb_base_datos);
            this.grbCadenaConec.Controls.Add(this.btn_mostrar);
            this.grbCadenaConec.Controls.Add(this.btnConexion);
            this.grbCadenaConec.Controls.Add(this.txtPass);
            this.grbCadenaConec.Controls.Add(this.lblPass);
            this.grbCadenaConec.Controls.Add(this.txtServidor);
            this.grbCadenaConec.Controls.Add(this.lblHost);
            this.grbCadenaConec.Controls.Add(this.txtPuerto);
            this.grbCadenaConec.Controls.Add(this.lblPuerto);
            this.grbCadenaConec.Controls.Add(this.txtUser);
            this.grbCadenaConec.Controls.Add(this.lblUser);
            this.grbCadenaConec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCadenaConec.Location = new System.Drawing.Point(0, 4);
            this.grbCadenaConec.Name = "grbCadenaConec";
            this.grbCadenaConec.Size = new System.Drawing.Size(578, 206);
            this.grbCadenaConec.TabIndex = 1;
            this.grbCadenaConec.TabStop = false;
            this.grbCadenaConec.Text = "Cadena Conexión";
            // 
            // btn_guardar_parametros
            // 
            this.btn_guardar_parametros.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_guardar_parametros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_guardar_parametros.Location = new System.Drawing.Point(18, 92);
            this.btn_guardar_parametros.Name = "btn_guardar_parametros";
            this.btn_guardar_parametros.Size = new System.Drawing.Size(162, 27);
            this.btn_guardar_parametros.TabIndex = 14;
            this.btn_guardar_parametros.Text = "Guardar Parametros";
            this.btn_guardar_parametros.UseVisualStyleBackColor = false;
            this.btn_guardar_parametros.Click += new System.EventHandler(this.btn_guardar_parametros_Click);
            // 
            // lbl_base_datos
            // 
            this.lbl_base_datos.AutoSize = true;
            this.lbl_base_datos.BackColor = System.Drawing.SystemColors.Info;
            this.lbl_base_datos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_base_datos.Location = new System.Drawing.Point(148, 133);
            this.lbl_base_datos.Name = "lbl_base_datos";
            this.lbl_base_datos.Size = new System.Drawing.Size(115, 20);
            this.lbl_base_datos.TabIndex = 10;
            this.lbl_base_datos.Text = "Base de Datos";
            this.lbl_base_datos.Visible = false;
            // 
            // btn_listar_esquemas
            // 
            this.btn_listar_esquemas.Location = new System.Drawing.Point(388, 159);
            this.btn_listar_esquemas.Name = "btn_listar_esquemas";
            this.btn_listar_esquemas.Size = new System.Drawing.Size(145, 29);
            this.btn_listar_esquemas.TabIndex = 12;
            this.btn_listar_esquemas.Text = "Listar Esquemas";
            this.btn_listar_esquemas.UseVisualStyleBackColor = true;
            this.btn_listar_esquemas.Visible = false;
            this.btn_listar_esquemas.Click += new System.EventHandler(this.btn_listar_esquemas_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.AutoSize = true;
            this.btn_salir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_salir.Location = new System.Drawing.Point(528, 12);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(44, 42);
            this.btn_salir.TabIndex = 13;
            this.btn_salir.Text = "X";
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // cmb_base_datos
            // 
            this.cmb_base_datos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_base_datos.FormattingEnabled = true;
            this.cmb_base_datos.Location = new System.Drawing.Point(28, 159);
            this.cmb_base_datos.Name = "cmb_base_datos";
            this.cmb_base_datos.Size = new System.Drawing.Size(354, 28);
            this.cmb_base_datos.TabIndex = 11;
            this.cmb_base_datos.Visible = false;
            // 
            // btn_mostrar
            // 
            this.btn_mostrar.Location = new System.Drawing.Point(537, 57);
            this.btn_mostrar.Name = "btn_mostrar";
            this.btn_mostrar.Size = new System.Drawing.Size(33, 29);
            this.btn_mostrar.TabIndex = 8;
            this.btn_mostrar.Text = "O";
            this.btn_mostrar.UseVisualStyleBackColor = true;
            this.btn_mostrar.Click += new System.EventHandler(this.btn_mostrar_Click);
            // 
            // btnConexion
            // 
            this.btnConexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnConexion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConexion.Location = new System.Drawing.Point(195, 92);
            this.btnConexion.Name = "btnConexion";
            this.btnConexion.Size = new System.Drawing.Size(189, 27);
            this.btnConexion.TabIndex = 9;
            this.btnConexion.Text = "Conectar";
            this.btnConexion.UseVisualStyleBackColor = false;
            this.btnConexion.Click += new System.EventHandler(this.btnConexion_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(383, 58);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(153, 26);
            this.txtPass.TabIndex = 7;
            this.txtPass.Text = "parqueabeja";
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(287, 61);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(92, 20);
            this.lblPass.TabIndex = 6;
            this.lblPass.Text = "Contraseña";
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(97, 27);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(170, 26);
            this.txtServidor.TabIndex = 1;
            this.txtServidor.Text = "192.168.0.161";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(16, 30);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(67, 20);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Servidor";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(383, 27);
            this.txtPuerto.MaxLength = 6;
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(86, 26);
            this.txtPuerto.TabIndex = 3;
            this.txtPuerto.Text = "5432";
            this.txtPuerto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPuerto_KeyPress);
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Location = new System.Drawing.Point(287, 30);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(56, 20);
            this.lblPuerto.TabIndex = 2;
            this.lblPuerto.Text = "Puerto";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(97, 58);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(170, 26);
            this.txtUser.TabIndex = 5;
            this.txtUser.Text = "postgres";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(16, 61);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(64, 20);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "Usuario";
            // 
            // rb_estructura
            // 
            this.rb_estructura.AutoSize = true;
            this.rb_estructura.Checked = true;
            this.rb_estructura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_estructura.Location = new System.Drawing.Point(6, 19);
            this.rb_estructura.Name = "rb_estructura";
            this.rb_estructura.Size = new System.Drawing.Size(174, 24);
            this.rb_estructura.TabIndex = 0;
            this.rb_estructura.TabStop = true;
            this.rb_estructura.Text = "Estructura de Tablas";
            this.rb_estructura.UseVisualStyleBackColor = true;
            this.rb_estructura.CheckedChanged += new System.EventHandler(this.rb_estructura_CheckedChanged);
            // 
            // rb_funciones
            // 
            this.rb_funciones.AutoSize = true;
            this.rb_funciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_funciones.Location = new System.Drawing.Point(6, 42);
            this.rb_funciones.Name = "rb_funciones";
            this.rb_funciones.Size = new System.Drawing.Size(201, 24);
            this.rb_funciones.TabIndex = 1;
            this.rb_funciones.Text = "Estructura de Funciones";
            this.rb_funciones.UseVisualStyleBackColor = true;
            this.rb_funciones.Visible = false;
            this.rb_funciones.CheckedChanged += new System.EventHandler(this.rb_funciones_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_estructura);
            this.groupBox1.Controls.Add(this.rb_funciones);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(330, 322);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 68);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generar ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_Esquema_comparar);
            this.groupBox2.Controls.Add(this.rb_Esquema_modelo);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(330, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 74);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Esquemas";
            // 
            // rb_Esquema_comparar
            // 
            this.rb_Esquema_comparar.AutoSize = true;
            this.rb_Esquema_comparar.Checked = true;
            this.rb_Esquema_comparar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Esquema_comparar.Location = new System.Drawing.Point(6, 19);
            this.rb_Esquema_comparar.Name = "rb_Esquema_comparar";
            this.rb_Esquema_comparar.Size = new System.Drawing.Size(169, 24);
            this.rb_Esquema_comparar.TabIndex = 0;
            this.rb_Esquema_comparar.TabStop = true;
            this.rb_Esquema_comparar.Text = "Comparar Esquema";
            this.rb_Esquema_comparar.UseVisualStyleBackColor = true;
            this.rb_Esquema_comparar.CheckedChanged += new System.EventHandler(this.rb_Esquema_comparar_CheckedChanged);
            // 
            // rb_Esquema_modelo
            // 
            this.rb_Esquema_modelo.AutoSize = true;
            this.rb_Esquema_modelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Esquema_modelo.Location = new System.Drawing.Point(6, 42);
            this.rb_Esquema_modelo.Name = "rb_Esquema_modelo";
            this.rb_Esquema_modelo.Size = new System.Drawing.Size(212, 24);
            this.rb_Esquema_modelo.TabIndex = 1;
            this.rb_Esquema_modelo.Text = "Modelar Esquema Modelo";
            this.rb_Esquema_modelo.UseVisualStyleBackColor = true;
            this.rb_Esquema_modelo.CheckedChanged += new System.EventHandler(this.rb_Esquema_modelo_CheckedChanged);
            // 
            // txt_nom_func
            // 
            this.txt_nom_func.Location = new System.Drawing.Point(333, 439);
            this.txt_nom_func.Name = "txt_nom_func";
            this.txt_nom_func.Size = new System.Drawing.Size(232, 20);
            this.txt_nom_func.TabIndex = 9;
            this.txt_nom_func.Visible = false;
            // 
            // lbl_nomfun
            // 
            this.lbl_nomfun.AutoSize = true;
            this.lbl_nomfun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nomfun.Location = new System.Drawing.Point(327, 416);
            this.lbl_nomfun.Name = "lbl_nomfun";
            this.lbl_nomfun.Size = new System.Drawing.Size(164, 20);
            this.lbl_nomfun.TabIndex = 8;
            this.lbl_nomfun.Text = "Nombre de la Función";
            this.lbl_nomfun.Visible = false;
            // 
            // btn_query
            // 
            this.btn_query.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_query.Location = new System.Drawing.Point(13, 476);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(156, 35);
            this.btn_query.TabIndex = 9;
            this.btn_query.Text = "Ejecutar Archivo sql";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(167, 476);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 35);
            this.button1.TabIndex = 10;
            this.button1.Text = "Backup -- Restore";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_copiar
            // 
            this.btn_copiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_copiar.Location = new System.Drawing.Point(312, 476);
            this.btn_copiar.Name = "btn_copiar";
            this.btn_copiar.Size = new System.Drawing.Size(136, 35);
            this.btn_copiar.TabIndex = 11;
            this.btn_copiar.Text = "Copiar Esquema";
            this.btn_copiar.UseVisualStyleBackColor = true;
            this.btn_copiar.Click += new System.EventHandler(this.btn_copiar_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(418, 216);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 27);
            this.button2.TabIndex = 13;
            this.button2.Text = "Desconectar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(528, 208);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 42);
            this.button3.TabIndex = 14;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.rb_triggers);
            this.groupBox3.Controls.Add(this.rb_trigger_index);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(330, 390);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 82);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Generar ";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(6, 55);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(86, 24);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "Ninguno";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rb_triggers
            // 
            this.rb_triggers.AutoSize = true;
            this.rb_triggers.Checked = true;
            this.rb_triggers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_triggers.Location = new System.Drawing.Point(6, 14);
            this.rb_triggers.Name = "rb_triggers";
            this.rb_triggers.Size = new System.Drawing.Size(160, 24);
            this.rb_triggers.TabIndex = 0;
            this.rb_triggers.TabStop = true;
            this.rb_triggers.Text = "Código de Triggers";
            this.rb_triggers.UseVisualStyleBackColor = true;
            // 
            // rb_trigger_index
            // 
            this.rb_trigger_index.AutoSize = true;
            this.rb_trigger_index.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_trigger_index.Location = new System.Drawing.Point(6, 33);
            this.rb_trigger_index.Name = "rb_trigger_index";
            this.rb_trigger_index.Size = new System.Drawing.Size(215, 24);
            this.rb_trigger_index.TabIndex = 1;
            this.rb_trigger_index.Text = "Triggers y Index  de Tablas";
            this.rb_trigger_index.UseVisualStyleBackColor = true;
            // 
            // btn_refrescar
            // 
            this.btn_refrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_refrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_refrescar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refrescar.Location = new System.Drawing.Point(328, 216);
            this.btn_refrescar.Name = "btn_refrescar";
            this.btn_refrescar.Size = new System.Drawing.Size(88, 27);
            this.btn_refrescar.TabIndex = 15;
            this.btn_refrescar.Text = "Actualizar";
            this.btn_refrescar.UseVisualStyleBackColor = false;
            this.btn_refrescar.Click += new System.EventHandler(this.btn_refrescar_Click);
            // 
            // frm_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.CancelButton = this.button3;
            this.ClientSize = new System.Drawing.Size(574, 522);
            this.ControlBox = false;
            this.Controls.Add(this.btn_refrescar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_query);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbl_nomfun);
            this.Controls.Add(this.txt_nom_func);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_generar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lst_esquemas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_modelo);
            this.Controls.Add(this.grbCadenaConec);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_copiar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(590, 560);
            this.Name = "frm_principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modelador -- Panel Control";
            this.grbCadenaConec.ResumeLayout(false);
            this.grbCadenaConec.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_generar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lst_esquemas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lst_modelo;
        private System.Windows.Forms.GroupBox grbCadenaConec;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btnConexion;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.RadioButton rb_estructura;
        private System.Windows.Forms.RadioButton rb_funciones;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_Esquema_comparar;
        private System.Windows.Forms.RadioButton rb_Esquema_modelo;
        private System.Windows.Forms.TextBox txt_nom_func;
        private System.Windows.Forms.Label lbl_nomfun;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_copiar;
        private System.Windows.Forms.Button btn_mostrar;
        private System.Windows.Forms.Label lbl_base_datos;
        private System.Windows.Forms.Button btn_listar_esquemas;
        private System.Windows.Forms.ComboBox cmb_base_datos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rb_triggers;
        private System.Windows.Forms.RadioButton rb_trigger_index;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btn_refrescar;
        private System.Windows.Forms.Button btn_guardar_parametros;
    }
}