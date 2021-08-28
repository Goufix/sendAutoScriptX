namespace SendAutoScriptX
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtFrase = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFrase
            // 
            this.txtFrase.Location = new System.Drawing.Point(-3, -2);
            this.txtFrase.Name = "txtFrase";
            this.txtFrase.Size = new System.Drawing.Size(358, 56);
            this.txtFrase.TabIndex = 0;
            this.txtFrase.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(353, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 56);
            this.button1.TabIndex = 1;
            this.button1.Text = "Abrir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 53);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFrase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(416, 92);
            this.Name = "Form1";
            this.Text = "SendAutoScriptX v1.0.0";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtFrase;
        private System.Windows.Forms.Button button1;
    }
}

