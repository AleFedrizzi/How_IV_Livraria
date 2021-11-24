
namespace Livraria_da_Lua.Forms
{
    partial class Frm_Busca
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
            this.btnFechar = new System.Windows.Forms.Button();
            this.Lst_Busca = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Btn_Atualiza = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(60)))), ((int)(((byte)(104)))));
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(111)))), ((int)(((byte)(63)))));
            this.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(111)))), ((int)(((byte)(63)))));
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(541, 12);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(47, 37);
            this.btnFechar.TabIndex = 28;
            this.btnFechar.Text = "X";
            this.btnFechar.UseVisualStyleBackColor = false;
            // 
            // Lst_Busca
            // 
            this.Lst_Busca.FormattingEnabled = true;
            this.Lst_Busca.Location = new System.Drawing.Point(8, 79);
            this.Lst_Busca.Name = "Lst_Busca";
            this.Lst_Busca.Size = new System.Drawing.Size(585, 264);
            this.Lst_Busca.TabIndex = 29;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Livraria_da_Lua.Properties.Resources.Pesquisar;
            this.pictureBox1.Location = new System.Drawing.Point(25, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // Btn_Atualiza
            // 
            this.Btn_Atualiza.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Atualiza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_Atualiza.FlatAppearance.BorderSize = 0;
            this.Btn_Atualiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Atualiza.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Atualiza.ForeColor = System.Drawing.Color.White;
            this.Btn_Atualiza.Location = new System.Drawing.Point(8, 7);
            this.Btn_Atualiza.Name = "Btn_Atualiza";
            this.Btn_Atualiza.Size = new System.Drawing.Size(78, 66);
            this.Btn_Atualiza.TabIndex = 32;
            this.Btn_Atualiza.Text = "Selecionar";
            this.Btn_Atualiza.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Atualiza.UseVisualStyleBackColor = false;
            // 
            // Frm_Busca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(60)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Lst_Busca);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.Btn_Atualiza);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Busca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Livros";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.ListBox Lst_Busca;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Btn_Atualiza;
    }
}