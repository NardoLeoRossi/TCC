namespace OrcamentosIfc.Sinapi
{
    partial class Frm_SelecionarItemsSinapi
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
            this.Lst_Insumos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Pnl_InsumosFiltros = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Cbb_Tipo = new System.Windows.Forms.ComboBox();
            this.Cbb_Classe = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Pnl_Sinteticas = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Lst_Sinteticas = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.LBL_Referência = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lst_Insumos
            // 
            this.Lst_Insumos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.Lst_Insumos.HideSelection = false;
            this.Lst_Insumos.Location = new System.Drawing.Point(5, 41);
            this.Lst_Insumos.Name = "Lst_Insumos";
            this.Lst_Insumos.Size = new System.Drawing.Size(980, 503);
            this.Lst_Insumos.TabIndex = 0;
            this.Lst_Insumos.UseCompatibleStateImageBehavior = false;
            this.Lst_Insumos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            this.columnHeader1.Width = 92;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descrição";
            this.columnHeader2.Width = 642;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "UN";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Origem Preço";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Preço";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 90;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 599);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Pnl_InsumosFiltros);
            this.tabPage1.Controls.Add(this.Lst_Insumos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(992, 573);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Insumos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Pnl_InsumosFiltros
            // 
            this.Pnl_InsumosFiltros.Location = new System.Drawing.Point(5, 5);
            this.Pnl_InsumosFiltros.Name = "Pnl_InsumosFiltros";
            this.Pnl_InsumosFiltros.Size = new System.Drawing.Size(975, 30);
            this.Pnl_InsumosFiltros.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Cbb_Tipo);
            this.tabPage2.Controls.Add(this.Cbb_Classe);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.Pnl_Sinteticas);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.Lst_Sinteticas);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(992, 573);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Composições Sintéticas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Cbb_Tipo
            // 
            this.Cbb_Tipo.FormattingEnabled = true;
            this.Cbb_Tipo.Location = new System.Drawing.Point(311, 23);
            this.Cbb_Tipo.Name = "Cbb_Tipo";
            this.Cbb_Tipo.Size = new System.Drawing.Size(350, 21);
            this.Cbb_Tipo.TabIndex = 4;
            // 
            // Cbb_Classe
            // 
            this.Cbb_Classe.FormattingEnabled = true;
            this.Cbb_Classe.Location = new System.Drawing.Point(5, 23);
            this.Cbb_Classe.Name = "Cbb_Classe";
            this.Cbb_Classe.Size = new System.Drawing.Size(300, 21);
            this.Cbb_Classe.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tipo";
            // 
            // Pnl_Sinteticas
            // 
            this.Pnl_Sinteticas.Location = new System.Drawing.Point(5, 50);
            this.Pnl_Sinteticas.Name = "Pnl_Sinteticas";
            this.Pnl_Sinteticas.Size = new System.Drawing.Size(975, 30);
            this.Pnl_Sinteticas.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Classe";
            // 
            // Lst_Sinteticas
            // 
            this.Lst_Sinteticas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.Lst_Sinteticas.HideSelection = false;
            this.Lst_Sinteticas.Location = new System.Drawing.Point(5, 86);
            this.Lst_Sinteticas.Name = "Lst_Sinteticas";
            this.Lst_Sinteticas.Size = new System.Drawing.Size(980, 458);
            this.Lst_Sinteticas.TabIndex = 2;
            this.Lst_Sinteticas.UseCompatibleStateImageBehavior = false;
            this.Lst_Sinteticas.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Código";
            this.columnHeader6.Width = 92;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Descrição";
            this.columnHeader7.Width = 596;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "UN";
            this.columnHeader8.Width = 50;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Origem Preço";
            this.columnHeader9.Width = 128;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Custo Total";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader10.Width = 94;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(992, 573);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Referência";
            // 
            // LBL_Referência
            // 
            this.LBL_Referência.AutoSize = true;
            this.LBL_Referência.Location = new System.Drawing.Point(77, 9);
            this.LBL_Referência.Name = "LBL_Referência";
            this.LBL_Referência.Size = new System.Drawing.Size(25, 13);
            this.LBL_Referência.TabIndex = 1;
            this.LBL_Referência.Text = "------";
            // 
            // Frm_SelecionarItemsSinapi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 621);
            this.Controls.Add(this.LBL_Referência);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "Frm_SelecionarItemsSinapi";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView Lst_Insumos;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBL_Referência;
        private System.Windows.Forms.Panel Pnl_InsumosFiltros;
        private System.Windows.Forms.ComboBox Cbb_Tipo;
        private System.Windows.Forms.ComboBox Cbb_Classe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel Pnl_Sinteticas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView Lst_Sinteticas;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.TabPage tabPage3;
    }
}