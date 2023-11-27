namespace OrcamentosIfc.Sinapi
{
    partial class Frm_DetalhesComposicao
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
            this.Lbl_Descricao = new System.Windows.Forms.Label();
            this.Lsv_Itens = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Btn_DetalharComposicao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lbl_Descricao
            // 
            this.Lbl_Descricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Descricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Descricao.Location = new System.Drawing.Point(5, 5);
            this.Lbl_Descricao.Name = "Lbl_Descricao";
            this.Lbl_Descricao.Size = new System.Drawing.Size(956, 35);
            this.Lbl_Descricao.TabIndex = 0;
            this.Lbl_Descricao.Text = "---";
            this.Lbl_Descricao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lsv_Itens
            // 
            this.Lsv_Itens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lsv_Itens.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.Lsv_Itens.FullRowSelect = true;
            this.Lsv_Itens.GridLines = true;
            this.Lsv_Itens.HideSelection = false;
            this.Lsv_Itens.Location = new System.Drawing.Point(5, 46);
            this.Lsv_Itens.Name = "Lsv_Itens";
            this.Lsv_Itens.Size = new System.Drawing.Size(1055, 629);
            this.Lsv_Itens.TabIndex = 1;
            this.Lsv_Itens.UseCompatibleStateImageBehavior = false;
            this.Lsv_Itens.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tipo";
            this.columnHeader7.Width = 77;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descrição";
            this.columnHeader2.Width = 573;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Unidade";
            this.columnHeader3.Width = 67;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Quantidade";
            this.columnHeader4.Width = 78;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Custo Unitário";
            this.columnHeader5.Width = 88;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Custo Total";
            this.columnHeader6.Width = 86;
            // 
            // Btn_DetalharComposicao
            // 
            this.Btn_DetalharComposicao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_DetalharComposicao.Location = new System.Drawing.Point(967, 5);
            this.Btn_DetalharComposicao.Name = "Btn_DetalharComposicao";
            this.Btn_DetalharComposicao.Size = new System.Drawing.Size(93, 35);
            this.Btn_DetalharComposicao.TabIndex = 5;
            this.Btn_DetalharComposicao.Text = "Detalhar Composição";
            this.Btn_DetalharComposicao.UseVisualStyleBackColor = true;
            this.Btn_DetalharComposicao.Click += new System.EventHandler(this.Btn_DetalharComposicao_Click);
            // 
            // Frm_DetalhesComposicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.Btn_DetalharComposicao);
            this.Controls.Add(this.Lsv_Itens);
            this.Controls.Add(this.Lbl_Descricao);
            this.Name = "Frm_DetalhesComposicao";
            this.Text = "Frm_DetalhesComposicao";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Descricao;
        private System.Windows.Forms.ListView Lsv_Itens;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button Btn_DetalharComposicao;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}