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

namespace ModeladorBD
{
    public partial class frm_estructura_copiar : Form
    {
        public frm_mensaje frmmensaje = new frm_mensaje();
        public String cadenaConexion = "";
        public frm_estructura_copiar()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            ocultar_mostrar(false);
            Size = new System.Drawing.Size(390, 221);
            cargar_parametros();
        }
        public Boolean conectarBd(String cuser, String cpass, String cport, String cdata, String chost)
        {
            //Alamcenamos en variables "LUEGO SE VALIDA SU VALOR VACIO"
            //Conexion
            return (ClsDatos.Conectar(cuser, cpass, chost, cport, cdata))? true :false;
        }
        //CARGAR LOS ESQUEMAS DE LA BD
        public void consultarEsquemas()
        {//Array para los registros
            ArrayList xLista;
            //Cadena de Consulta 
            String cadena = "select nspname::varchar as nombre_del_los_esquema_listados from pg_namespace "
                    + "where substring(nspname from 1 for 3) != 'pg_'  and nspname not in ('information_schema','public') order by nspname";
            //CARGAMOS LOS DATOS DE LOS ESQUEMA
            xLista = ClsDatos.listaDatos(cadena);
            Utiles.cargarLista(this.lst_esquemas, xLista);
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            ClsDatos.Desconectar();
            this.Close();
        }
        public void abrirCerrarFormulario(bool v)
        {frmmensaje.Visible = v;}
        private void btnConexion_Click(object sender, EventArgs e)
        {//ocultar objetos
            ocultar_mostrar(false);
            lbl_base_datos.Visible = cmb_base_datos.Visible = btn_listar_esquemas.Visible = false;
            //OBJETO TIPO FORMULARIO MENSAJE
            frmmensaje.Visible = false;
            frmmensaje.Show();
            frmmensaje.Text = "Cargando Esquemas. Espere...";
            //ABRIMOS
            abrirCerrarFormulario(true);
            Size = new System.Drawing.Size(390, 221);
            //CONSULTAR BD
            if (conectarBd(txtUser.Text,txtPass.Text,txtPuerto.Text,"postgres",txtServidor.Text))
            {//DATOS DE LOS ESQUEMA DE LA BD
                cargar_bd();
                lbl_base_datos.Visible = cmb_base_datos.Visible = btn_listar_esquemas.Visible = true;
                Size = new System.Drawing.Size(390,280);
            }
            abrirCerrarFormulario(false);
        }
        private void btn_mostrar_Click(object sender, EventArgs e)
        //mostrar ocultar la Contraseña 
        { this.txtPass.UseSystemPasswordChar = (txtPass.UseSystemPasswordChar) ? false : true; }

        private void btn_modelar_Click(object sender, EventArgs e)
        {
            if (this.txt_nombre_esquema.Text.Trim().Length < 1)
            {//MENSAJE
                MessageBox.Show("Debe Ingresar Un Nombre Para El Nuevo");
                this.txt_nombre_esquema.Focus();
                return;
            }
            if (this.lst_esquemas.Items.Count < 1)
            {//MENSAJE
                MessageBox.Show("No Hay Esquemas");
                this.txt_nombre_esquema.Focus();
                return;
            }
            frmmensaje.Text = "Realizando Analisis. Espere...";
            //METODO MUESTRA MENSAJE
            abrirCerrarFormulario(true);
            //FORMULARIO DE ESTRUCTURA 
            frm_estructura estruc = new frm_estructura();
            //ATRAPAMOS LOS VALORES DE LOS ESQUEMAS 
            String squema = lst_esquemas.SelectedItem.ToString();
            //CONEXION A BASE DATOS 
            if (conectarBd(txtUser.Text,txtPass.Text,txtPuerto.Text,cmb_base_datos.SelectedItem.ToString(),txtServidor.Text))
            {//ENVIAMOS EL VALOR RETORNADO AL OTRO FORMULARIO
                frmmensaje.Text = "Estructurando Esquema. Espere...";
                String cEstructura = ClsDatos.cadenaDatos("select public.generar_empresa_nueva_texto('" + squema+ "','"+ 
                    txt_nombre_esquema.Text +"')");
                ClsDatos.Desconectar();
                //EJECUTAMOS LA NUEVA SENTENCIA 
                if (conectarBd(txtUser_base.Text,txtPass_base.Text,txtPuerto_base.Text,txtBaseDatos_base.Text,txtServidor_base.Text))
                {//COMPROBAR LA EXISTENCIA
                    if (Comprobar_existencia_nombre())
                    {//ABRIR Y CERRAR
                        abrirCerrarFormulario(false);
                        MessageBox.Show("El Esquema Ya Existe");
                        return;
                    }//EJECUTAR LA ESTRUCTURA
                    if (conectarBd(txtUser_base.Text,txtPass_base.Text,txtPuerto_base.Text,txtBaseDatos_base.Text,txtServidor_base.Text))
                    {   //EJECUTAR
                        ClsDatos.run_script(cEstructura);
                        abrirCerrarFormulario(false);
                        MessageBox.Show("Creacion de Estructura del esquema " + cmb_base_datos.SelectedItem.ToString());
                    }//CERRAMOS FORMULARIO DE MENSAJE
                    abrirCerrarFormulario(false);
                }
            }
        }
        //COMPROBAR SI EL NOMBRE EXISTE
        private bool Comprobar_existencia_nombre()
        {   //LISTA DE DATOS
            ArrayList xLista;
            //Cadena de Consulta 
            String cadena = "select nspname from pg_namespace"
                            + " where substring(nspname from 1 for 3) != 'pg_' and nspname = '" + this.txt_nombre_esquema.Text.Trim()+"'";
            //CARGAMOS LOS DATOS DE LOS ESQUEMA
            xLista = ClsDatos.listaDatos(cadena);
            //RETORNO DE DATOS 
            return (xLista.Count > 0 )?true:false;
        }
        private void ocultar_mostrar(bool bvalor)
        {//DATOS DE MUESTRA
            btn_listar_esquemas.Visible = cmb_base_datos.Visible = lbl_base_datos.Visible
            = btn_backup.Visible = btn_query.Visible  = btn_modelar.Visible = txt_nombre_esquema.Visible
            = lst_esquemas.Visible = lbl_nombre_esquema.Visible = lbl_esquema.Visible = bvalor;
            Size = new System.Drawing.Size(390, bvalor ? 490 : 280);
            txt_nombre_esquema.Text = "";
            grbCadenaConec.Enabled = !bvalor;
        }

        private void button1_Click(object sender, EventArgs e)
        {//cargamos los datos al combo box
            ocultar_mostrar(false);
            if (conectarBd(txtUser.Text,txtPass.Text,txtPuerto.Text,cmb_base_datos.SelectedItem.ToString(),txtServidor.Text))
            {//DATOS DE LOS ESQUEMA DE LA BD
                consultarEsquemas();
                ocultar_mostrar(true);
                ClsDatos.Desconectar();
                //CONECTAR
                conectarBd(txtUser.Text, txtPass.Text, txtPuerto.Text,cmb_base_datos.SelectedItem.ToString(), txtServidor.Text);
                //EJECUTAR EL ARCHIVO SQL
                ClsDatos.run_script(Utiles.Retornar_lectura_script("modelador.sql"));
            }
            abrirCerrarFormulario(false);
        }
        private void cargar_bd()
        {//Array para los registros
            ArrayList xLista;
            //Cadena de Consulta 
            String cadena = "select datname from pg_database where datname not in ('template1','template0') order by datname asc";
            //CARGAMOS LOS DATOS DE LOS ESQUEMA
            xLista = ClsDatos.listaDatos(cadena);
            Utiles.cargarCombo(this.cmb_base_datos, xLista);
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            //METODO MUESTRA MENSAJE
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

        private void button1_Click_1(object sender, EventArgs e)
        {   //METODO MUESTRA MENSAJE
            abrirCerrarFormulario(true);
            //FORMULARIO DE ESTRUCTURA 
            frm_backup_x_restore backup_rest = new frm_backup_x_restore();
            //CONEXION A BASE DATOS , ENVIAMOS EL VALOR RETORNADO AL OTRO FORMULARIO
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

        private void button2_Click(object sender, EventArgs e)
        {
            ClsDatos.Desconectar();
            //CONECTAR
            conectarBd(txtUser.Text, txtPass.Text, txtPuerto.Text, cmb_base_datos.SelectedItem.ToString(), txtServidor.Text);
            //ELIMINAR LOS DATOS
            ClsDatos.run_script(Utiles.Retornar_lectura_script("limpiar_funciones.sql"));
            //desconectar
            ClsDatos.Desconectar();
            ocultar_mostrar(false);
            Size = new System.Drawing.Size(390, 221);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClsDatos.Desconectar();
            //CONECTAR
            conectarBd(txtUser.Text, txtPass.Text, txtPuerto.Text, cmb_base_datos.SelectedItem.ToString(), txtServidor.Text);
            //ELIMINAR LOS DATOS
            ClsDatos.run_script(Utiles.Retornar_lectura_script("limpiar_funciones.sql"));
            //desconectar
            ClsDatos.Desconectar();
            this.Close();
        }

        private void btn_refrescar_Click(object sender, EventArgs e)
        {
            if (conectarBd(txtUser.Text, txtPass.Text, txtPuerto.Text, cmb_base_datos.SelectedItem.ToString(), txtServidor.Text))
            {//DATOS DE LOS ESQUEMA DE LA BD                
                consultarEsquemas();
                //DESCONECTAR
                ClsDatos.Desconectar();
            }
        }
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
    }
}
