namespace BookClub
{
    partial class Form_Konyvklub
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
            this.buttonTiltas = new System.Windows.Forms.Button();
            this.dataGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonTiltas
            // 
            this.buttonTiltas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonTiltas.Location = new System.Drawing.Point(54, 12);
            this.buttonTiltas.Name = "buttonTiltas";
            this.buttonTiltas.Size = new System.Drawing.Size(222, 45);
            this.buttonTiltas.TabIndex = 0;
            this.buttonTiltas.Text = "Tiltás / Tiltás visszavonása";
            this.buttonTiltas.UseVisualStyleBackColor = false;
            // 
            // dataGV
            // 
            this.dataGV.AllowUserToAddRows = false;
            this.dataGV.AllowUserToDeleteRows = false;
            this.dataGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGV.Location = new System.Drawing.Point(0, 76);
            this.dataGV.Name = "dataGV";
            this.dataGV.ReadOnly = true;
            this.dataGV.RowHeadersWidth = 51;
            this.dataGV.RowTemplate.Height = 24;
            this.dataGV.Size = new System.Drawing.Size(1116, 374);
            this.dataGV.TabIndex = 1;
            // 
            // Form_Konyvklub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 450);
            this.Controls.Add(this.dataGV);
            this.Controls.Add(this.buttonTiltas);
            this.Name = "Form_Konyvklub";
            this.Text = "Konyvklub";
            this.Load += new System.EventHandler(this.Form_Konyvklub_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTiltas;
        private System.Windows.Forms.DataGridView dataGV;
    }
}

