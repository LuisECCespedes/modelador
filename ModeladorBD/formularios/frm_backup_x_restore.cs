using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace ModeladorBD
{
    public partial class frm_backup_x_restore : Form
    {
        string  ruta_pg_dum     = Application.StartupPath + "\\pg_libs\\pg_dump.exe",
                ruta_pg_restore = Application.StartupPath + "\\pg_libs\\pg_restore.exe";
        public frm_backup_x_restore()
        {
            InitializeComponent();
        }
        //SALIR
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //RUTA DONDE SE CREARA EL ARCHIVO
        private void btn_buscar_archivo_Click(object sender, EventArgs e)
        {   //VARIABLE DE RUTA
            String path = "";
            //BUSCAMOS LA RUTA PARA GUARDAR EL ARCHIVO
            if (safi_Backup.ShowDialog() == DialogResult.OK)
            {   //ALMACENAMOS LA DIRECCION DEL ARCHIVO
                path = safi_Backup.FileName;
                //COMPROBAMOS EXISTENCIA Y REEMPLAZO
                if (!File.Exists(path))
                {   // ALMACENO LA RUTA DE CREACION DEL ARCHIVO
                    txt_ruta_creacion_backup.Text = path;
                }
            }
        }
        //REALIZAMOS EL BACKUP
        private void btn_proceder_Click(object sender, EventArgs e)
        {   //RUTAS SELECCIONADAS 
            if (txt_ruta_creacion_backup.Text.Length > 0 )
            {//instancia ala clase
                frm_principal estruc = new frm_principal();
                estruc.mensaje("Generando Copia de Seguridad. Espere...");
                estruc.abrirCerrarFormulario(true);
                //ruta de pgdump
                string cSchema = cmb_esquema.Items.Count > 0 ? cmb_esquema.SelectedItem.ToString() : "";
                //Ejecutamos el codigo de generacion
                Utiles.PostgreSqlDump(ruta_pg_dum, txt_ruta_creacion_backup.Text, chk_solo_schema.Checked? true :false,cSchema
                        , txtServidor.Text, txtPuerto.Text, txtBaseDatos.Text, txtUser.Text, txtPass.Text);
//                Utiles.PostgreSqlDump(path, txt_ruta_creacion_backup.Text,chk_solo_schema.Checked,cmb_esquema.SelectedItem.ToString()
  //                      ,txtServidor.Text, txtPuerto.Text, txtBaseDatos.Text, txtUser.Text, txtPass.Text);
                //cerramos y confirmamos
                estruc.abrirCerrarFormulario(false);
                MessageBox.Show("Backup Realizado Correctamente en :" + txt_ruta_creacion_backup.Text);
            }
            else
            {
                MessageBox.Show("Ruta Invalida :" + txt_ruta_creacion_backup.Text);
            }
        }
        //RUTA PARA EL BACKUP
        private void btn_ruta_backup_Click(object sender, EventArgs e)
        {//EL RESULTADO SEA OK
            if (opfi_ruta_backup.ShowDialog() == DialogResult.OK)
            {//mostrar la ruta en el texto
                txt_ruta_backup.Text = opfi_ruta_backup.FileName;
            }
        }        
        //PROCEDEMOS CON LA RESTAURACION DE BASE DATOS COMPLETA 
        private void btn_proceder_restore_Click(object sender, EventArgs e)
        {   //RUTAS SELECCIONADAS 
            if (txt_ruta_backup.Text.Length > 0)
            {//INSTANCIA ALA CLASE
                frm_principal estruc = new frm_principal();
                estruc.mensaje("Generando Copia de Seguridad. Espere...");
                estruc.abrirCerrarFormulario(true);
                //EJECUTAMOS EL CODIGO DE GENERACION
                Utiles.PostgreSqlRestoreBackup(ruta_pg_restore, txt_ruta_backup.Text, this.txtServidor.Text, txtPuerto.Text, txtBaseDatos.Text, txtUser.Text, txtPass.Text);
                //CERRAMOS Y CONFIRMAMOS
                estruc.abrirCerrarFormulario(false);
                MessageBox.Show("Restauración Realizada Correctamente del Archivo :" + txt_ruta_backup.Text+ "\r" +" En la Base de Datos "+ txtBaseDatos);
            }
            else
            {// FALLA LA RUTA
                MessageBox.Show("Ruta Invalida :" + txt_ruta_creacion_backup.Text);
            }
        }
        private void chk_solo_schema_CheckedChanged(object sender, EventArgs e)
        {//MOSTRAR OCULTAR
            cmb_esquema.Visible = chk_solo_schema.Checked ? true : false;
            if(chk_solo_schema.Checked) cargarCombo();
        }
        void cargarCombo()
        {
            ClsDatos.Conectar(txtUser.Text, txtPass.Text, txtServidor.Text, txtPuerto.Text, txtBaseDatos.Text);
            ArrayList xLista;
            //Cadena de Consulta 
            String cadena = "select nspname::varchar as nombre_del_los_esquema_listados from pg_namespace "
                    + "where substring(nspname from 1 for 3) != 'pg_' and nspname not in ('information_schema','public') order by nspname ";
            //CARGAMOS LOS DATOS DE LOS ESQUEMA
            xLista = ClsDatos.listaDatos(cadena);
            Utiles.cargarCombo(cmb_esquema, xLista);
        }
    }
}
