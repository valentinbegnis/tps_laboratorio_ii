
namespace TP3
{
    partial class form_agregarModificarCliente
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
            this.tb_nombre = new System.Windows.Forms.TextBox();
            this.tb_apellido = new System.Windows.Forms.TextBox();
            this.tb_dni = new System.Windows.Forms.TextBox();
            this.tb_telefono = new System.Windows.Forms.TextBox();
            this.tb_email = new System.Windows.Forms.TextBox();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.lbl_apellido = new System.Windows.Forms.Label();
            this.lbl_dni = new System.Windows.Forms.Label();
            this.lbl_telefono = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_nombre
            // 
            this.tb_nombre.BackColor = System.Drawing.Color.MistyRose;
            this.tb_nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_nombre.Font = new System.Drawing.Font("Sitka Text", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_nombre.ForeColor = System.Drawing.Color.Maroon;
            this.tb_nombre.Location = new System.Drawing.Point(34, 53);
            this.tb_nombre.Name = "tb_nombre";
            this.tb_nombre.Size = new System.Drawing.Size(348, 24);
            this.tb_nombre.TabIndex = 0;
            this.tb_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nombre_KeyPress);
            // 
            // tb_apellido
            // 
            this.tb_apellido.BackColor = System.Drawing.Color.MistyRose;
            this.tb_apellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_apellido.Font = new System.Drawing.Font("Sitka Text", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_apellido.ForeColor = System.Drawing.Color.Maroon;
            this.tb_apellido.Location = new System.Drawing.Point(35, 105);
            this.tb_apellido.Name = "tb_apellido";
            this.tb_apellido.Size = new System.Drawing.Size(348, 24);
            this.tb_apellido.TabIndex = 1;
            this.tb_apellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_apellido_KeyPress);
            // 
            // tb_dni
            // 
            this.tb_dni.BackColor = System.Drawing.Color.MistyRose;
            this.tb_dni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_dni.Font = new System.Drawing.Font("Sitka Text", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_dni.ForeColor = System.Drawing.Color.Maroon;
            this.tb_dni.Location = new System.Drawing.Point(35, 181);
            this.tb_dni.Name = "tb_dni";
            this.tb_dni.Size = new System.Drawing.Size(152, 24);
            this.tb_dni.TabIndex = 2;
            this.tb_dni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_dni_KeyPress);
            // 
            // tb_telefono
            // 
            this.tb_telefono.BackColor = System.Drawing.Color.MistyRose;
            this.tb_telefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_telefono.Font = new System.Drawing.Font("Sitka Text", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_telefono.ForeColor = System.Drawing.Color.Maroon;
            this.tb_telefono.Location = new System.Drawing.Point(34, 242);
            this.tb_telefono.Name = "tb_telefono";
            this.tb_telefono.Size = new System.Drawing.Size(152, 24);
            this.tb_telefono.TabIndex = 3;
            this.tb_telefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_telefono_KeyPress);
            // 
            // tb_email
            // 
            this.tb_email.BackColor = System.Drawing.Color.MistyRose;
            this.tb_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_email.Font = new System.Drawing.Font("Sitka Text", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_email.ForeColor = System.Drawing.Color.Maroon;
            this.tb_email.Location = new System.Drawing.Point(35, 308);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(152, 24);
            this.tb_email.TabIndex = 4;
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.BackColor = System.Drawing.Color.Transparent;
            this.lbl_nombre.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_nombre.ForeColor = System.Drawing.Color.MistyRose;
            this.lbl_nombre.Location = new System.Drawing.Point(34, 29);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(58, 19);
            this.lbl_nombre.TabIndex = 5;
            this.lbl_nombre.Text = "Nombre";
            // 
            // lbl_apellido
            // 
            this.lbl_apellido.AutoSize = true;
            this.lbl_apellido.BackColor = System.Drawing.Color.Transparent;
            this.lbl_apellido.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_apellido.ForeColor = System.Drawing.Color.MistyRose;
            this.lbl_apellido.Location = new System.Drawing.Point(35, 81);
            this.lbl_apellido.Name = "lbl_apellido";
            this.lbl_apellido.Size = new System.Drawing.Size(59, 19);
            this.lbl_apellido.TabIndex = 6;
            this.lbl_apellido.Text = "Apellido";
            // 
            // lbl_dni
            // 
            this.lbl_dni.AutoSize = true;
            this.lbl_dni.BackColor = System.Drawing.Color.Transparent;
            this.lbl_dni.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_dni.ForeColor = System.Drawing.Color.MistyRose;
            this.lbl_dni.Location = new System.Drawing.Point(35, 157);
            this.lbl_dni.Name = "lbl_dni";
            this.lbl_dni.Size = new System.Drawing.Size(33, 19);
            this.lbl_dni.TabIndex = 7;
            this.lbl_dni.Text = "DNI";
            // 
            // lbl_telefono
            // 
            this.lbl_telefono.AutoSize = true;
            this.lbl_telefono.BackColor = System.Drawing.Color.Transparent;
            this.lbl_telefono.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_telefono.ForeColor = System.Drawing.Color.MistyRose;
            this.lbl_telefono.Location = new System.Drawing.Point(34, 218);
            this.lbl_telefono.Name = "lbl_telefono";
            this.lbl_telefono.Size = new System.Drawing.Size(61, 19);
            this.lbl_telefono.TabIndex = 8;
            this.lbl_telefono.Text = "Teléfono";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.BackColor = System.Drawing.Color.Transparent;
            this.lbl_email.Font = new System.Drawing.Font("Sitka Subheading", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_email.ForeColor = System.Drawing.Color.MistyRose;
            this.lbl_email.Location = new System.Drawing.Point(34, 284);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(44, 19);
            this.lbl_email.TabIndex = 9;
            this.lbl_email.Text = "Email";
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.BackColor = System.Drawing.Color.LightSalmon;
            this.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_aceptar.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_aceptar.ForeColor = System.Drawing.Color.Maroon;
            this.btn_aceptar.Location = new System.Drawing.Point(211, 288);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(75, 44);
            this.btn_aceptar.TabIndex = 11;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = false;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.Silver;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cancelar.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_cancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_cancelar.Location = new System.Drawing.Point(308, 288);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 44);
            this.btn_cancelar.TabIndex = 12;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::TP3.Properties.Resources.user;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(231, 145);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 126);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // form_agregarModificarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TP3.Properties.Resources.imagen_biblioteca;
            this.ClientSize = new System.Drawing.Size(423, 374);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_telefono);
            this.Controls.Add(this.lbl_dni);
            this.Controls.Add(this.lbl_apellido);
            this.Controls.Add(this.lbl_nombre);
            this.Controls.Add(this.tb_email);
            this.Controls.Add(this.tb_telefono);
            this.Controls.Add(this.tb_dni);
            this.Controls.Add(this.tb_apellido);
            this.Controls.Add(this.tb_nombre);
            this.Name = "form_agregarModificarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar/Modificar cliente";
            this.Load += new System.EventHandler(this.FormAgregarModificarCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_nombre;
        private System.Windows.Forms.TextBox tb_apellido;
        private System.Windows.Forms.TextBox tb_dni;
        private System.Windows.Forms.TextBox tb_telefono;
        private System.Windows.Forms.TextBox tb_email;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.Label lbl_apellido;
        private System.Windows.Forms.Label lbl_dni;
        private System.Windows.Forms.Label lbl_telefono;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}