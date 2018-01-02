namespace ModeladorBD
{
    partial class frm_seleccionar_items
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
            this.dgv_lista = new System.Windows.Forms.DataGridView();
            this.marca = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.descri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_lista
            // 
            this.dgv_lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_lista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.marca,
            this.descri});
            this.dgv_lista.Location = new System.Drawing.Point(12, 12);
            this.dgv_lista.Name = "dgv_lista";
            this.dgv_lista.Size = new System.Drawing.Size(594, 362);
            this.dgv_lista.TabIndex = 0;
            // 
            // marca
            // 
            this.marca.HeaderText = "Marca";
            this.marca.Name = "marca";
            // 
            // descri
            // 
            this.descri.HeaderText = "Descripción";
            this.descri.Name = "descri";
            this.descri.Width = 450;
            // 
            // frm_seleccionar_items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 386);
            this.Controls.Add(this.dgv_lista);
            this.Name = "frm_seleccionar_items";
            this.Text = "frm_seleccionar_items";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_lista;
        private System.Windows.Forms.DataGridViewCheckBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn descri;
    }
}