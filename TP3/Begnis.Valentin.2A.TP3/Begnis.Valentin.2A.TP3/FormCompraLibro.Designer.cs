
namespace TP3
{
    partial class form_comprarLibro
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
            this.lbx_listaLibros = new System.Windows.Forms.ListBox();
            this.lbl_libro = new System.Windows.Forms.Label();
            this.btn_comprar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbx_listaLibros
            // 
            this.lbx_listaLibros.BackColor = System.Drawing.Color.MistyRose;
            this.lbx_listaLibros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbx_listaLibros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbx_listaLibros.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbx_listaLibros.FormattingEnabled = true;
            this.lbx_listaLibros.HorizontalScrollbar = true;
            this.lbx_listaLibros.ItemHeight = 19;
            this.lbx_listaLibros.Location = new System.Drawing.Point(43, 57);
            this.lbx_listaLibros.Name = "lbx_listaLibros";
            this.lbx_listaLibros.Size = new System.Drawing.Size(339, 154);
            this.lbx_listaLibros.TabIndex = 0;
            // 
            // lbl_libro
            // 
            this.lbl_libro.AutoSize = true;
            this.lbl_libro.BackColor = System.Drawing.Color.Transparent;
            this.lbl_libro.Font = new System.Drawing.Font("Sitka Subheading", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_libro.ForeColor = System.Drawing.Color.MistyRose;
            this.lbl_libro.Location = new System.Drawing.Point(43, 33);
            this.lbl_libro.Name = "lbl_libro";
            this.lbl_libro.Size = new System.Drawing.Size(214, 21);
            this.lbl_libro.TabIndex = 1;
            this.lbl_libro.Text = "Seleccione el libro a comprar";
            // 
            // btn_comprar
            // 
            this.btn_comprar.BackColor = System.Drawing.Color.LightSalmon;
            this.btn_comprar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_comprar.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_comprar.ForeColor = System.Drawing.Color.Maroon;
            this.btn_comprar.Location = new System.Drawing.Point(132, 230);
            this.btn_comprar.Name = "btn_comprar";
            this.btn_comprar.Size = new System.Drawing.Size(75, 44);
            this.btn_comprar.TabIndex = 2;
            this.btn_comprar.Text = "Comprar";
            this.btn_comprar.UseVisualStyleBackColor = false;
            this.btn_comprar.Click += new System.EventHandler(this.btn_comprar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.Silver;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cancelar.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_cancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_cancelar.Location = new System.Drawing.Point(228, 230);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 44);
            this.btn_cancelar.TabIndex = 3;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // form_comprarLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TP3.Properties.Resources.imagen_biblioteca;
            this.ClientSize = new System.Drawing.Size(430, 296);
            this.ControlBox = false;
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_comprar);
            this.Controls.Add(this.lbl_libro);
            this.Controls.Add(this.lbx_listaLibros);
            this.Name = "form_comprarLibro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Libros disponibles";
            this.Load += new System.EventHandler(this.FormCompraLibros_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbx_listaLibros;
        private System.Windows.Forms.Label lbl_libro;
        private System.Windows.Forms.Button btn_comprar;
        private System.Windows.Forms.Button btn_cancelar;
    }
}