namespace OrcamentosIfc.Forms
{
    partial class Frm_VisualizarProjeto
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
            this.ControlHost = new System.Windows.Forms.Integration.ElementHost();
            this.button2 = new System.Windows.Forms.Button();
            this.Lsv_CustosElemento = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Lbl_CustoTotal = new System.Windows.Forms.Label();
            this.Btn_RemoverCusto = new System.Windows.Forms.Button();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ControlHost
            // 
            this.ControlHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlHost.Location = new System.Drawing.Point(5, 5);
            this.ControlHost.Name = "ControlHost";
            this.ControlHost.Size = new System.Drawing.Size(475, 640);
            this.ControlHost.TabIndex = 2;
            this.ControlHost.Text = "elementHost1";
            this.ControlHost.Child = null;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(610, 651);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Adicionar Custo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Lsv_CustosElemento
            // 
            this.Lsv_CustosElemento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lsv_CustosElemento.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader5});
            this.Lsv_CustosElemento.FullRowSelect = true;
            this.Lsv_CustosElemento.HideSelection = false;
            this.Lsv_CustosElemento.Location = new System.Drawing.Point(484, 5);
            this.Lsv_CustosElemento.Name = "Lsv_CustosElemento";
            this.Lsv_CustosElemento.Size = new System.Drawing.Size(576, 640);
            this.Lsv_CustosElemento.TabIndex = 3;
            this.Lsv_CustosElemento.UseCompatibleStateImageBehavior = false;
            this.Lsv_CustosElemento.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tipo";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nome";
            this.columnHeader2.Width = 265;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "$ Unit";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 3;
            this.columnHeader4.Text = "Qntd";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 4;
            this.columnHeader5.Text = "$ Total";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Lbl_CustoTotal
            // 
            this.Lbl_CustoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_CustoTotal.Location = new System.Drawing.Point(837, 651);
            this.Lbl_CustoTotal.Name = "Lbl_CustoTotal";
            this.Lbl_CustoTotal.Size = new System.Drawing.Size(223, 23);
            this.Lbl_CustoTotal.TabIndex = 4;
            this.Lbl_CustoTotal.Text = "label1";
            this.Lbl_CustoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Btn_RemoverCusto
            // 
            this.Btn_RemoverCusto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_RemoverCusto.Location = new System.Drawing.Point(486, 651);
            this.Btn_RemoverCusto.Name = "Btn_RemoverCusto";
            this.Btn_RemoverCusto.Size = new System.Drawing.Size(120, 23);
            this.Btn_RemoverCusto.TabIndex = 5;
            this.Btn_RemoverCusto.Text = "Remover Custo";
            this.Btn_RemoverCusto.UseVisualStyleBackColor = true;
            this.Btn_RemoverCusto.Click += new System.EventHandler(this.Btn_RemoverCusto_Click);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Dimensão";
            // 
            // Frm_VisualizarProjeto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.Btn_RemoverCusto);
            this.Controls.Add(this.Lbl_CustoTotal);
            this.Controls.Add(this.Lsv_CustosElemento);
            this.Controls.Add(this.ControlHost);
            this.Controls.Add(this.button2);
            this.Name = "Frm_VisualizarProjeto";
            this.Text = "Frm_VisualizarProjeto";
            this.Load += new System.EventHandler(this.Frm_VisualizarProjeto_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Integration.ElementHost ControlHost;
        private Xbim.Presentation.IfcMetaDataControl ifcMetaDataControl1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView Lsv_CustosElemento;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label Lbl_CustoTotal;
        private System.Windows.Forms.Button Btn_RemoverCusto;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}