using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace ModeladorBD
{
    /// <summary>
    // CONTINUAR CON LA IMPLEMENTACION DE LA CREACION DE BACKUP POR ESQUEMA Y LA RESTAURACION DE BD Y ESQUEMA
    /// </summary>
    public partial class frm_principal : Form
    {
        public frm_mensaje frmmensaje = new frm_mensaje();
        public String cadenaConexion ="";
        
        public frm_principal()
        {
            InitializeComponent();
            Size = new System.Drawing.Size(590, 170);
            cargar_parametros();
        }
        //CONECTAR BD
        public Boolean conectarBd(String baseDatos)
        {
            Boolean v = false;
            //Alamcenamos en variables "LUEGO SE VALIDA SU VALOR VACIO"
            String cuser = this.txtUser.Text, cpass = this.txtPass.Text, cport = this.txtPuerto.Text,
                cdata = baseDatos, chost = this.txtServidor.Text;
            //Conexion
            if (ClsDatos.Conectar(cuser, cpass, chost, cport, cdata)) { 
                v = true;
            }
            return v ;
        }
        //MENSAJES DE PROCESO
        public void abrirCerrarFormulario(bool v)
        {       frmmensaje.Visible = v;        }
        //MENSAJE PARA EL FLOTANTE
        public void mensaje(String mensaje)
        {
            frmmensaje.Text = mensaje;
        }
        //SOLO NUMEROS EN EL PUERTO
        private void txtPuerto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utiles.olyNumero(e);
        }
        //VISUALIZACION DE PARAMETROS 
        private void rb_Esquema_comparar_CheckedChanged(object sender, EventArgs e)
        {//CONDICIONAL PARA MUESTRA DE CONTROL
            rb_funciones.Visible    = rb_Esquema_modelo.Checked ? true:false;
            txt_nom_func.Visible    =   lbl_nomfun.Visible      = false;
            rb_estructura.Checked   = true;
            txt_nom_func.Text       = "";
            groupBox3.Visible       = rb_Esquema_comparar.Checked ? false : true;
        }
        //VISUALIZACION DE PARAMETROS 
        private void rb_funciones_CheckedChanged(object sender, EventArgs e)
        {
            //MUESTRAR O OCULTAR CONTROLES
            this.lbl_nomfun.Visible = this.rb_funciones.Checked ? true : false;
            txt_nom_func.Visible    = this.rb_funciones.Checked ? true : false;
        }
        private void button2_Click(object sender, EventArgs e)
        {   //DESCONECTAR
            ClsDatos.Desconectar();
            //CONECTAR
            conectarBd(this.cmb_base_datos.SelectedItem.ToString());
            //ELIMINAR LOS DATOS
            ClsDatos.run_script(Utiles.Retornar_lectura_script("limpiar_funciones.sql"));
            //OCULTAR MOSTRAR FORMULARIO
            formulario_inicio();
            ClsDatos.Desconectar();
        }
        private void button3_Click(object sender, EventArgs e)
        {   //DESCONECTAR
            ClsDatos.Desconectar();
            //CONECTAR
            conectarBd(this.cmb_base_datos.SelectedItem.ToString());
            //ELIMINAR LOS DATOS
            ClsDatos.run_script(Utiles.Retornar_lectura_script("limpiar_funciones.sql"));
            //cerrar conexion y cerrar formulario
            ClsDatos.Desconectar();
            this.Close();
        }
        private void rb_Esquema_modelo_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = rb_Esquema_modelo.Checked ? true : false;
        }

        private void rb_estructura_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = rb_estructura.Checked ? true : false;
        }
        private void ejecutar_funciones()
        {
            MessageBox.Show(Application.StartupPath);
        }
        private void btn_guardar_parametros_Click(object sender, EventArgs e)
        {   //  Guardar Parametros 
            guardar_parametros();
            MessageBox.Show("Los Parametros se han guardado correctamente");
        }
        #region Respuesta de comparacion
        //GENERAR LA ESTRUCTURA
        private void btn_generar_Click(object sender, EventArgs e)
            {//SI NO EXISTE NINGUN ESQUEMA BLOQUEAR
                if (this.lst_esquemas.Items.Count < 1)
                {//MENSAJE
                    MessageBox.Show("No Hay Esquemas");
                    return;
                }
                //MENSAJE
                frmmensaje.Text = "Realizando Analisis. Espere...";
                //METODO MUESTRA MENSAJE
                abrirCerrarFormulario(true);
                //FORMULARIO DE ESTRUCTURA 
                frm_estructura estruc = new frm_estructura();

                //ATRAPAMOS LOS VALORES DE LOS ESQUEMAS 
                String squemaModelo = lst_modelo.SelectedItem.ToString(), squema = lst_esquemas.SelectedItem.ToString();
                //CONEXION A BASE DATOS 
                if (conectarBd(this.cmb_base_datos.SelectedItem.ToString()))
                {
                    //ENVIAMOS EL VALOR RETORNADO AL OTRO FORMULARIO
                    //              estruc.txt_query.Text = chk_triggers.Checked ? "set search_path to " + squemaModelo +";": "" +
                    //                    ClsDatos.cadenaDatos(TipFuncion(squemaModelo,squema));
                    String Cadena = ClsDatos.cadenaDatos(TipFuncion(squemaModelo, squema));
                    Cadena = ((rb_triggers.Checked && rb_estructura.Checked) ? "set search_path to " + squemaModelo + ";" : "") + Cadena;
                    estruc.txt_query.Text = Cadena;
                    //MOSTRAMOS EN FORMULARIO EL VALOR ENVIADO DE LA BASE DE DATOS 
                    estruc.txt_query.Focus();
                    frmmensaje.Text = "Estructurando Esquema. Espere...";
                    //CERRAMOS FORMULARIO DE MENSAJE
                    abrirCerrarFormulario(false);
                    //ABRIMOS EL FORMULARIO
                    estruc.txtBaseDatos.Text = this.cmb_base_datos.SelectedItem.ToString();
                    estruc.txtPass.Text = txtPass.Text;
                    estruc.txtPuerto.Text = txtPuerto.Text;
                    estruc.txtServidor.Text = txtServidor.Text;
                    estruc.txtUser.Text = txtUser.Text;
                    estruc.ShowDialog();
                }
                //CERRAMOS FORMULARIO DE MENSAJE
                abrirCerrarFormulario(false);
            }
        #endregion
        #region ejecucion de Archivo Sql
            //VENTANA DE EJECUCION DE ARCHIVOS SQL
            private void btn_query_Click(object sender, EventArgs e)
            {//METODO MUESTRA MENSAJE
                abrirCerrarFormulario(true);
                //FORMULARIO DE ESTRUCTURA 
                frm_lectura lectura = new frm_lectura();
                //CONEXION A BASE DATOS 
                //ENVIAMOS EL VALOR RETORNADO AL OTRO FORMULARIO
                frmmensaje.Text = "Estructurando Esquema. Espere...";
                //CERRAMOS FORMULARIO DE MENSAJE
                abrirCerrarFormulario(false);
                //ABRIMOS EL FORMULARIO
                lectura.txtBaseDatos.Text = this.cmb_base_datos.SelectedItem.ToString();
                lectura.txtPass.Text = txtPass.Text;
                lectura.txtPuerto.Text = txtPuerto.Text;
                lectura.txtServidor.Text = txtServidor.Text;
                lectura.txtUser.Text = txtUser.Text;
                lectura.ShowDialog();
                //CERRAMOS FORMULARIO DE MENSAJE
                abrirCerrarFormulario(false);
            }
        #endregion
        #region Backup y Restore
            //MOSTRAR LA VENTANA DE BAKUP Y RESTAURACION 
            private void button1_Click(object sender, EventArgs e)
            {   //METODO MUESTRA MENSAJE
                abrirCerrarFormulario(true);
                //FORMULARIO DE ESTRUCTURA 
                frm_backup_x_restore backup_rest = new frm_backup_x_restore();
                //CONEXION A BASE DATOS 
                //ENVIAMOS EL VALOR RETORNADO AL OTRO FORMULARIO
                frmmensaje.Text = "Estructurando Esquema. Espere...";
                //CERRAMOS FORMULARIO DE MENSAJE
                abrirCerrarFormulario(false);
                //ABRIMOS EL FORMULARIO
                backup_rest.txtBaseDatos.Text = this.cmb_base_datos.SelectedItem.ToString();
                backup_rest.txtPass.Text = txtPass.Text;
                backup_rest.txtPuerto.Text = txtPuerto.Text;
                backup_rest.txtServidor.Text = txtServidor.Text;
                backup_rest.txtUser.Text = txtUser.Text;
                backup_rest.ShowDialog();
                //CERRAMOS FORMULARIO DE MENSAJE
                abrirCerrarFormulario(false);
            }
        #endregion
        #region Copiar Esquema
            private void btn_copiar_Click(object sender, EventArgs e)
            {
                frm_estructura_copiar estruc_cop = new frm_estructura_copiar();
                frmmensaje.Text = "Estructurando Esquema. Espere...";
                //CERRAMOS FORMULARIO DE MENSAJE
                abrirCerrarFormulario(false);
                //ABRIMOS EL FORMULARIO
                estruc_cop.txtBaseDatos_base.Text = this.cmb_base_datos.SelectedItem.ToString();
                estruc_cop.txtPass_base.Text = txtPass.Text;
                estruc_cop.txtPuerto_base.Text = txtPuerto.Text;
                estruc_cop.txtServidor_base.Text = txtServidor.Text;
                estruc_cop.txtUser_base.Text = txtUser.Text;
                estruc_cop.ShowDialog();
                //CERRAMOS FORMULARIO DE MENSAJE
                abrirCerrarFormulario(false);
                btn_listar_esquemas_Click(sender, e);
            }
        #endregion
        #region Carga y Actualiza Esquemas -- Formulario Principal
        //CARGAR LOS ESQUEMAS DE LA BD
        public void consultarEsquemas()
            {
                //Array para los registros
                ArrayList xLista;
                //Cadena de Consulta 
                String cadena = "select nspname::varchar as nombre_del_los_esquema_listados from pg_namespace "
                        + "where substring(nspname from 1 for 3) != 'pg_'  and nspname not in ('information_schema','public') order by nspname ";
                //CARGAMOS LOS DATOS DE LOS ESQUEMA
                xLista = ClsDatos.listaDatos(cadena);
                Utiles.cargarLista(this.lst_esquemas, xLista);
                Utiles.cargarLista(this.lst_modelo, xLista);
            }
            private void btn_refrescar_Click(object sender, EventArgs e)
            {
                if (conectarBd(this.cmb_base_datos.SelectedItem.ToString()))
                {//DATOS DE LOS ESQUEMA DE LA BD                
                    consultarEsquemas();
                    //DESCONECTAR
                    ClsDatos.Desconectar();
                }
            }
        #endregion
        #region Conexion y Base de datos -- Formulario Principal
            //SALIR
            private void btn_salir_Click(object sender, EventArgs e)
            {   //CERRAR CONEXION Y CERRAR FORMULARIO
                ClsDatos.Desconectar();
                //CERRAR EL FORMULARIO
                this.Close();
            }
            private void btn_mostrar_Click(object sender, EventArgs e)
            //mostrar ocultar la Contraseña 
            {
                this.txtPass.UseSystemPasswordChar = (this.txtPass.UseSystemPasswordChar) ? false : true;
            }
            //REALIZAR CONEXION
            private void btnConexion_Click(object sender, EventArgs e)
            {//OBJETO TIPO FORMULARIO MENSAJE
                frmmensaje.Visible = false;
                frmmensaje.Show();
                frmmensaje.Text = "Cargando Esquemas. Espere...";
                formulario_inicio();
                //ABRIMOS
                abrirCerrarFormulario(true);
                //CONSULTAR BD
                if (conectarBd("postgres"))
                {//CARGAR LAS BASE DE DATOS EXISTENTES
                    cargar_bd();
                    this.lbl_base_datos.Visible = this.cmb_base_datos.Visible = this.btn_listar_esquemas.Visible = true;
                    Size = new System.Drawing.Size(590, 242);
                }
                abrirCerrarFormulario(false);
            }
            private void btn_listar_esquemas_Click(object sender, EventArgs e)
            {
                if (conectarBd(this.cmb_base_datos.SelectedItem.ToString()))
                {//DATOS DE LOS ESQUEMA DE LA BD
                    //TAMAÑO DE FORMULARIO
                    consultarEsquemas();
                    //DESCONECTAR
                    ClsDatos.Desconectar();
                    //CONECTAR
                    conectarBd(this.cmb_base_datos.SelectedItem.ToString());
                    //EJECUTAR EL ARCHIVO SQL
                    ClsDatos.run_script(Utiles.Retornar_lectura_script("modelador.sql"));
                    this.Size = new System.Drawing.Size(590, 560);
                    MaximumSize = new System.Drawing.Size(590, 560);
                    //BLOQUEO OPCIONES DE CONEXION
                    grbCadenaConec.Enabled = false;
                    ClsDatos.Desconectar();
                }
                abrirCerrarFormulario(false);
            }
        #endregion
        #region lectura y escritura -- Archivos
            private void cargar_parametros()
            {   // los parametros se tomaran de archivo TxT
                try
                {
                    StreamReader objReader = new StreamReader(Utiles.Ruta_Path("parametros.txt"));
                    txtServidor.Text = objReader.ReadLine();
                    txtPuerto.Text = objReader.ReadLine();
                    txtUser.Text = objReader.ReadLine();
                    txtPass.Text = objReader.ReadLine();
                    objReader.Close();
                }
                catch (Exception)
                {
                    
                }
            }
            private void guardar_parametros()
            {   // guardar parametros en hoja tXt
                StreamWriter textArchivo = File.CreateText(Utiles.Ruta_Path("parametros.txt"));
                textArchivo.WriteLine(txtServidor.Text.Trim());
                textArchivo.WriteLine(txtPuerto.Text.Trim());
                textArchivo.WriteLine(txtUser.Text.Trim());
                textArchivo.WriteLine(txtPass.Text.Trim());
                textArchivo.Close();
            }
        #endregion
        #region Funciones
            private void cargar_bd()
            {//Array para los registros
                ArrayList xLista;
                //Cadena de Consulta 
                String cadena = "select datname from pg_database where datname not in ('template1','template0') order by datname asc";
                //CARGAMOS LOS DATOS DE LOS ESQUEMA
                xLista = ClsDatos.listaDatos(cadena);
                Utiles.cargarCombo(this.cmb_base_datos, xLista);
            }
            public void formulario_inicio()
            {//VALORES DE CONTROLES AL INICIAR EL FORMULARIO
                grbCadenaConec.Enabled = true;
                groupBox3.Visible = lbl_base_datos.Visible
                    = this.cmb_base_datos.Visible = this.btn_listar_esquemas.Visible = false;
                Size = new System.Drawing.Size(590, 170);
                txt_nom_func.Text = "";
                rb_Esquema_comparar.Checked = true;
                rb_estructura.Checked = true;
            }
            //CREACION DE CADENA 
            public String TipFuncion(String squemaModelo, String squema)
            {   //PRIMERA CONDICIONAL

                //return (chk_triggers.Checked && rb_estructura.Checked) 
                return (groupBox3.Visible && rb_triggers.Checked && rb_estructura.Checked) ? "select bd_crear_estructura_trigger_funciones('" + squemaModelo + "')"
                        : (groupBox3.Visible && rb_estructura.Checked && rb_trigger_index.Checked) ? "select generar_create_trigger_index('" + squemaModelo + "')"
                        : (rb_Esquema_modelo.Checked && rb_funciones.Checked) ? "select bd_crear_estructura_funciones('" + squemaModelo + "'" +
                        (txt_nom_func.Text.Length > 0 ? ",'" + txt_nom_func.Text + "'" : "") + ")"
                        //SEGUNDA CONDICIONAL
                        : rb_Esquema_comparar.Checked ? "select bd_comparar_esquemas('" + squemaModelo + "','" + squema + "')"
                        //TERCERA CONDICIONAL
                        : "select bd_comparar_esquemas('" + squemaModelo + "','')";
            }
        #endregion        
    }
}
