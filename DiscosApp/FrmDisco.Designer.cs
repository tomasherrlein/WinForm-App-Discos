﻿namespace ejemplo_ado_net
{
    partial class FrmDisco
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
            this.pbxImagen = new System.Windows.Forms.PictureBox();
            this.dgvDiscos = new System.Windows.Forms.DataGridView();
            this.btnAgregarDisco = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminacionFisica = new System.Windows.Forms.Button();
            this.btnEliminacionLogica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxImagen
            // 
            this.pbxImagen.Location = new System.Drawing.Point(824, 56);
            this.pbxImagen.Name = "pbxImagen";
            this.pbxImagen.Size = new System.Drawing.Size(352, 318);
            this.pbxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImagen.TabIndex = 0;
            this.pbxImagen.TabStop = false;
            // 
            // dgvDiscos
            // 
            this.dgvDiscos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDiscos.Location = new System.Drawing.Point(54, 56);
            this.dgvDiscos.MultiSelect = false;
            this.dgvDiscos.Name = "dgvDiscos";
            this.dgvDiscos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiscos.Size = new System.Drawing.Size(643, 318);
            this.dgvDiscos.TabIndex = 1;
            this.dgvDiscos.SelectionChanged += new System.EventHandler(this.dgvDiscos_SelectionChanged);
            // 
            // btnAgregarDisco
            // 
            this.btnAgregarDisco.Location = new System.Drawing.Point(54, 396);
            this.btnAgregarDisco.Name = "btnAgregarDisco";
            this.btnAgregarDisco.Size = new System.Drawing.Size(85, 33);
            this.btnAgregarDisco.TabIndex = 2;
            this.btnAgregarDisco.Text = "Agregar disco";
            this.btnAgregarDisco.UseVisualStyleBackColor = true;
            this.btnAgregarDisco.Click += new System.EventHandler(this.btnAgregarDisco_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(162, 396);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(93, 33);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar disco";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminacionFisica
            // 
            this.btnEliminacionFisica.Location = new System.Drawing.Point(278, 396);
            this.btnEliminacionFisica.Name = "btnEliminacionFisica";
            this.btnEliminacionFisica.Size = new System.Drawing.Size(140, 33);
            this.btnEliminacionFisica.TabIndex = 4;
            this.btnEliminacionFisica.Text = "Eliminar fisico";
            this.btnEliminacionFisica.UseVisualStyleBackColor = true;
            this.btnEliminacionFisica.Click += new System.EventHandler(this.btnEliminacionFisica_Click);
            // 
            // btnEliminacionLogica
            // 
            this.btnEliminacionLogica.Location = new System.Drawing.Point(436, 396);
            this.btnEliminacionLogica.Name = "btnEliminacionLogica";
            this.btnEliminacionLogica.Size = new System.Drawing.Size(140, 33);
            this.btnEliminacionLogica.TabIndex = 5;
            this.btnEliminacionLogica.Text = "Eliminar logico";
            this.btnEliminacionLogica.UseVisualStyleBackColor = true;
            this.btnEliminacionLogica.Click += new System.EventHandler(this.btnEliminacionLogica_Click);
            // 
            // FrmDisco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 454);
            this.Controls.Add(this.btnEliminacionLogica);
            this.Controls.Add(this.btnEliminacionFisica);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregarDisco);
            this.Controls.Add(this.dgvDiscos);
            this.Controls.Add(this.pbxImagen);
            this.Name = "FrmDisco";
            this.Text = "Discos";
            this.Load += new System.EventHandler(this.FrmDisco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxImagen;
        private System.Windows.Forms.DataGridView dgvDiscos;
        private System.Windows.Forms.Button btnAgregarDisco;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminacionFisica;
        private System.Windows.Forms.Button btnEliminacionLogica;
    }
}