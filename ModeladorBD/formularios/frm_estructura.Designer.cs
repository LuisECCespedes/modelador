namespace ModeladorBD
{
    partial class frm_estructura
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_esquema = new System.Windows.Forms.Label();
            this.btn_modelar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_query = new System.Windows.Forms.RichTextBox();
            this.txtBaseDatos = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_esquema
            // 
            this.lbl_esquema.AutoSize = true;
            this.lbl_esquema.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_esquema.Location = new System.Drawing.Point(190, 3);
            this.lbl_esquema.Name = "lbl_esquema";
            this.lbl_esquema.Size = new System.Drawing.Size(128, 31);
            this.lbl_esquema.TabIndex = 4;
            this.lbl_esquema.Text = "Esquema";
            // 
            // btn_modelar
            // 
            this.btn_modelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_modelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modelar.Location = new System.Drawing.Point(106, 524);
            this.btn_modelar.Name = "btn_modelar";
            this.btn_modelar.Size = new System.Drawing.Size(95, 47);
            this.btn_modelar.TabIndex = 1;
            this.btn_modelar.Text = "Modelar";
            this.btn_modelar.UseVisualStyleBackColor = true;
            this.btn_modelar.Click += new System.EventHandler(this.btn_modelar_Click);
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
            this.btn_salir.Location = new System.Drawing.Point(443, 6);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(44, 42);
            this.btn_salir.TabIndex = 3;
            this.btn_salir.Text = "X";
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(1, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(484, 493);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_query);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(476, 467);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt_query
            // 
            this.txt_query.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_query.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_query.Location = new System.Drawing.Point(0, 0);
            this.txt_query.Name = "txt_query";
            this.txt_query.Size = new System.Drawing.Size(480, 471);
            this.txt_query.TabIndex = 0;
            this.txt_query.Text = "";
            // 
            // txtBaseDatos
            // 
            this.txtBaseDatos.Location = new System.Drawing.Point(8, 668);
            this.txtBaseDatos.Name = "txtBaseDatos";
            this.txtBaseDatos.Size = new System.Drawing.Size(170, 20);
            this.txtBaseDatos.TabIndex = 21;
            this.txtBaseDatos.Visible = false;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(8, 668);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(170, 20);
            this.txtPass.TabIndex = 20;
            this.txtPass.Visible = false;
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(8, 668);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(170, 20);
            this.txtServidor.TabIndex = 17;
            this.txtServidor.Visible = false;
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(50, 668);
            this.txtPuerto.MaxLength = 6;
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(86, 20);
            this.txtPuerto.TabIndex = 18;
            this.txtPuerto.Visible = false;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(8, 668);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(170, 20);
            this.txtUser.TabIndex = 19;
            this.txtUser.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(207, 524);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 47);
            this.button1.TabIndex = 2;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "Text files (*.sql)|*.sql|All files (*.*)|*.*";
            this.saveFileDialog1.Filter = "Text files (*.sql)|*.sql|All files (*.*)|*.*";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(301, 524);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 47);
            this.button2.TabIndex = 22;
            this.button2.Text = "Copiar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frm_estructura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.CancelButton = this.btn_salir;
            this.ClientSize = new System.Drawing.Size(487, 574);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBaseDatos);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lbl_esquema);
            this.Controls.Add(this.btn_modelar);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.tabControl1);
            this.Name = "frm_estructura";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estructura";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_esquema;
        private System.Windows.Forms.Button btn_modelar;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.RichTextBox txt_query;
        public System.Windows.Forms.TextBox txtBaseDatos;
        public System.Windows.Forms.TextBox txtPass;
        public System.Windows.Forms.TextBox txtServidor;
        public System.Windows.Forms.TextBox txtPuerto;
        public System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button2;
    }
}

