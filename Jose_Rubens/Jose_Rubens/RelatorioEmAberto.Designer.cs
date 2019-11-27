namespace Jose_Rubens
{
    partial class RelatorioEmAberto
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Relatorio_emAbertoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RancheirosDataSet1 = new Jose_Rubens.RancheirosDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RancheirosDataSet = new Jose_Rubens.RancheirosDataSet();
            this.PagamentosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PagamentosTableAdapter = new Jose_Rubens.RancheirosDataSetTableAdapters.PagamentosTableAdapter();
            this.Relatorio_emAbertoTableAdapter = new Jose_Rubens.RancheirosDataSet1TableAdapters.Relatorio_emAbertoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Relatorio_emAbertoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RancheirosDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RancheirosDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PagamentosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Relatorio_emAbertoBindingSource
            // 
            this.Relatorio_emAbertoBindingSource.DataMember = "Relatorio_emAberto";
            this.Relatorio_emAbertoBindingSource.DataSource = this.RancheirosDataSet1;
            // 
            // RancheirosDataSet1
            // 
            this.RancheirosDataSet1.DataSetName = "RancheirosDataSet1";
            this.RancheirosDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Relatorio_emAbertoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Jose_Rubens.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this.reportViewer1.Size = new System.Drawing.Size(784, 661);
            this.reportViewer1.TabIndex = 0;
            // 
            // RancheirosDataSet
            // 
            this.RancheirosDataSet.DataSetName = "RancheirosDataSet";
            this.RancheirosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PagamentosBindingSource
            // 
            this.PagamentosBindingSource.DataMember = "Pagamentos";
            this.PagamentosBindingSource.DataSource = this.RancheirosDataSet;
            // 
            // PagamentosTableAdapter
            // 
            this.PagamentosTableAdapter.ClearBeforeFill = true;
            // 
            // Relatorio_emAbertoTableAdapter
            // 
            this.Relatorio_emAbertoTableAdapter.ClearBeforeFill = true;
            // 
            // RelatorioEmAberto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelatorioEmAberto";
            this.ShowIcon = false;
            this.Text = "Relatorio Recibos Em Aberto";
            this.Load += new System.EventHandler(this.RelatorioEmAberto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Relatorio_emAbertoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RancheirosDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RancheirosDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PagamentosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PagamentosBindingSource;
        private RancheirosDataSet RancheirosDataSet;
        private RancheirosDataSetTableAdapters.PagamentosTableAdapter PagamentosTableAdapter;
        private System.Windows.Forms.BindingSource Relatorio_emAbertoBindingSource;
        private RancheirosDataSet1 RancheirosDataSet1;
        private RancheirosDataSet1TableAdapters.Relatorio_emAbertoTableAdapter Relatorio_emAbertoTableAdapter;
    }
}