namespace Windows.Kiosco
{
    partial class FrmKioscoAE
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtPrecioBase = new TextBox();
            txtStock = new TextBox();
            dtpFechaIngreso = new DateTimePicker();
            dtpFechaVto = new DateTimePicker();
            cboTipo = new ComboBox();
            cboMarca = new ComboBox();
            btnOk = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 9);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(125, 9);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 1;
            txtNombre.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 45);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 2;
            label1.Text = "Precio Base";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 75);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 3;
            label2.Text = "Stock";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 103);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 4;
            label3.Text = "Feha Ingreso";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 147);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 5;
            label4.Text = "Fecha Vencimiento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(291, 17);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 6;
            label5.Text = "Tipo Producto";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(291, 54);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 7;
            label6.Text = "Marca";
            // 
            // txtPrecioBase
            // 
            txtPrecioBase.Location = new Point(125, 46);
            txtPrecioBase.Name = "txtPrecioBase";
            txtPrecioBase.Size = new Size(100, 23);
            txtPrecioBase.TabIndex = 8;
            txtPrecioBase.TextChanged += txtPrecioBase_TextChanged;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(125, 75);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 9;
            // 
            // dtpFechaIngreso
            // 
            dtpFechaIngreso.Location = new Point(125, 103);
            dtpFechaIngreso.Name = "dtpFechaIngreso";
            dtpFechaIngreso.Size = new Size(200, 23);
            dtpFechaIngreso.TabIndex = 10;
            // 
            // dtpFechaVto
            // 
            dtpFechaVto.Location = new Point(125, 141);
            dtpFechaVto.Name = "dtpFechaVto";
            dtpFechaVto.Size = new Size(200, 23);
            dtpFechaVto.TabIndex = 11;
            // 
            // cboTipo
            // 
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(380, 17);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(121, 23);
            cboTipo.TabIndex = 12;
            // 
            // cboMarca
            // 
            cboMarca.FormattingEnabled = true;
            cboMarca.Location = new Point(337, 46);
            cboMarca.Name = "cboMarca";
            cboMarca.Size = new Size(121, 23);
            cboMarca.TabIndex = 13;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(66, 203);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(136, 56);
            btnOk.TabIndex = 14;
            btnOk.Text = "Aceptar";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(257, 203);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(136, 56);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FrmKioscoAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(cboMarca);
            Controls.Add(cboTipo);
            Controls.Add(dtpFechaVto);
            Controls.Add(dtpFechaIngreso);
            Controls.Add(txtStock);
            Controls.Add(txtPrecioBase);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Name = "FrmKioscoAE";
            Text = "FrmKioscoAE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtNombre;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtPrecioBase;
        private TextBox txtStock;
        private DateTimePicker dtpFechaIngreso;
        private DateTimePicker dtpFechaVto;
        private ComboBox cboTipo;
        private ComboBox cboMarca;
        private Button btnOk;
        private Button btnCancelar;
    }
}