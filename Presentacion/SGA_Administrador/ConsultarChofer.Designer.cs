﻿
namespace Presentacion.SGA_Administrador
{
    partial class ConsultarChofer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.DataGridChofer = new Guna.UI2.WinForms.Guna2DataGridView();
            this.NombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CedulaCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorreoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar_Cliente = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BtnConsultar = new FontAwesome.Sharp.IconPictureBox();
            this.TxtChofer = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridChofer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnConsultar)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Controls.Add(this.DataGridChofer);
            this.guna2GroupBox1.Controls.Add(this.BtnConsultar);
            this.guna2GroupBox1.Controls.Add(this.TxtChofer);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GroupBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(144)))), ((int)(((byte)(176)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(689, 365);
            this.guna2GroupBox1.TabIndex = 3;
            this.guna2GroupBox1.Text = "Eliminar chofer";
            // 
            // DataGridChofer
            // 
            this.DataGridChofer.AllowUserToAddRows = false;
            this.DataGridChofer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DataGridChofer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridChofer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridChofer.BackgroundColor = System.Drawing.Color.White;
            this.DataGridChofer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGridChofer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridChofer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(205)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(205)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridChofer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridChofer.ColumnHeadersHeight = 30;
            this.DataGridChofer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreCliente,
            this.CedulaCliente,
            this.CorreoCliente,
            this.Eliminar_Cliente,
            this.Editar});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(191)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(12)))), ((int)(((byte)(14)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridChofer.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridChofer.EnableHeadersVisualStyles = false;
            this.DataGridChofer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridChofer.Location = new System.Drawing.Point(13, 118);
            this.DataGridChofer.Name = "DataGridChofer";
            this.DataGridChofer.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(191)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridChofer.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridChofer.RowHeadersVisible = false;
            this.DataGridChofer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridChofer.Size = new System.Drawing.Size(658, 234);
            this.DataGridChofer.TabIndex = 4;
            this.DataGridChofer.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridChofer.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridChofer.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridChofer.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridChofer.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridChofer.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridChofer.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridChofer.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Green;
            this.DataGridChofer.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridChofer.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Informal Roman", 10F);
            this.DataGridChofer.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridChofer.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridChofer.ThemeStyle.HeaderStyle.Height = 30;
            this.DataGridChofer.ThemeStyle.ReadOnly = true;
            this.DataGridChofer.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridChofer.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridChofer.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridChofer.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridChofer.ThemeStyle.RowsStyle.Height = 22;
            this.DataGridChofer.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridChofer.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridChofer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridChofer_CellContentClick);
            this.DataGridChofer.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DataGridChofer_CellPainting);
            // 
            // NombreCliente
            // 
            this.NombreCliente.HeaderText = "Nombre";
            this.NombreCliente.Name = "NombreCliente";
            this.NombreCliente.ReadOnly = true;
            // 
            // CedulaCliente
            // 
            this.CedulaCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CedulaCliente.HeaderText = "Cédula";
            this.CedulaCliente.Name = "CedulaCliente";
            this.CedulaCliente.ReadOnly = true;
            // 
            // CorreoCliente
            // 
            this.CorreoCliente.HeaderText = "Correo";
            this.CorreoCliente.Name = "CorreoCliente";
            this.CorreoCliente.ReadOnly = true;
            // 
            // Eliminar_Cliente
            // 
            this.Eliminar_Cliente.HeaderText = "Eliminar";
            this.Eliminar_Cliente.Name = "Eliminar_Cliente";
            this.Eliminar_Cliente.ReadOnly = true;
            this.Eliminar_Cliente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eliminar_Cliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Editar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.BackColor = System.Drawing.Color.Transparent;
            this.BtnConsultar.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.BtnConsultar.ForeColor = System.Drawing.Color.Green;
            this.BtnConsultar.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.BtnConsultar.IconColor = System.Drawing.Color.Green;
            this.BtnConsultar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnConsultar.Location = new System.Drawing.Point(491, 69);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(35, 32);
            this.BtnConsultar.TabIndex = 3;
            this.BtnConsultar.TabStop = false;
            this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // TxtChofer
            // 
            this.TxtChofer.BackColor = System.Drawing.Color.Transparent;
            this.TxtChofer.BorderRadius = 12;
            this.TxtChofer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtChofer.DefaultText = "";
            this.TxtChofer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtChofer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtChofer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtChofer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtChofer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtChofer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtChofer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtChofer.Location = new System.Drawing.Point(254, 69);
            this.TxtChofer.Name = "TxtChofer";
            this.TxtChofer.PasswordChar = '\0';
            this.TxtChofer.PlaceholderText = "Ingresar la cédula o nombre del chofer";
            this.TxtChofer.SelectedText = "";
            this.TxtChofer.Size = new System.Drawing.Size(231, 30);
            this.TxtChofer.TabIndex = 2;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(12)))), ((int)(((byte)(15)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(186, 69);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(62, 30);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "Cédula:";
            // 
            // ConsultarChofer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(713, 389);
            this.Controls.Add(this.guna2GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConsultarChofer";
            this.Text = "EliminarChofer";
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridChofer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnConsultar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private FontAwesome.Sharp.IconPictureBox BtnConsultar;
        private Guna.UI2.WinForms.Guna2TextBox TxtChofer;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridChofer;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CedulaCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorreoCliente;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar_Cliente;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
    }
}