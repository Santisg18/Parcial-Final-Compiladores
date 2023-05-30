namespace AnalisisDete
{
    partial class Form1
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
            this.txtAlgoritmo = new System.Windows.Forms.RichTextBox();
            this.btnCompilar = new System.Windows.Forms.Button();
            this.dgTablaSimbolos = new System.Windows.Forms.DataGridView();
            this.dgErrores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgTablaSimbolos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgErrores)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAlgoritmo
            // 
            this.txtAlgoritmo.Location = new System.Drawing.Point(273, 25);
            this.txtAlgoritmo.Name = "txtAlgoritmo";
            this.txtAlgoritmo.Size = new System.Drawing.Size(269, 246);
            this.txtAlgoritmo.TabIndex = 0;
            this.txtAlgoritmo.Text = "";
            // 
            // btnCompilar
            // 
            this.btnCompilar.Location = new System.Drawing.Point(359, 277);
            this.btnCompilar.Name = "btnCompilar";
            this.btnCompilar.Size = new System.Drawing.Size(92, 23);
            this.btnCompilar.TabIndex = 1;
            this.btnCompilar.Text = "<<Compilar>>";
            this.btnCompilar.UseVisualStyleBackColor = true;
            this.btnCompilar.Click += new System.EventHandler(this.btnCompilar_Click);
            // 
            // dgTablaSimbolos
            // 
            this.dgTablaSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTablaSimbolos.Location = new System.Drawing.Point(47, 317);
            this.dgTablaSimbolos.Name = "dgTablaSimbolos";
            this.dgTablaSimbolos.Size = new System.Drawing.Size(240, 150);
            this.dgTablaSimbolos.TabIndex = 2;
            // 
            // dgErrores
            // 
            this.dgErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgErrores.Location = new System.Drawing.Point(496, 317);
            this.dgErrores.Name = "dgErrores";
            this.dgErrores.Size = new System.Drawing.Size(240, 150);
            this.dgErrores.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 508);
            this.Controls.Add(this.dgErrores);
            this.Controls.Add(this.dgTablaSimbolos);
            this.Controls.Add(this.btnCompilar);
            this.Controls.Add(this.txtAlgoritmo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgTablaSimbolos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgErrores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtAlgoritmo;
        private System.Windows.Forms.Button btnCompilar;
        private System.Windows.Forms.DataGridView dgTablaSimbolos;
        private System.Windows.Forms.DataGridView dgErrores;
    }
}

