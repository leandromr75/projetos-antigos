namespace Jose_Rubens
{
    partial class ListarDadosAssoc
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
            this.Listar_AssociadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RancheirosDataSet3 = new Jose_Rubens.RancheirosDataSet3();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Listar_AssociadosTableAdapter = new Jose_Rubens.RancheirosDataSet3TableAdapters.Listar_AssociadosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Listar_AssociadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RancheirosDataSet3)).BeginInit();
            this.SuspendLayout();
            // 
            // Listar_AssociadosBindingSource
            // 
            this.Listar_AssociadosBindingSource.DataMember = "Listar_Associados";
            this.Listar_AssociadosBindingSource.DataSource = this.RancheirosDataSet3;
            // 
            // RancheirosDataSet3
            // 
            this.RancheirosDataSet3.DataSetName = "RancheirosDataSet3";
            this.RancheirosDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Listar_AssociadosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Jose_Rubens.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(784, 661);
            this.reportViewer1.TabIndex = 0;
            // 
            // Listar_AssociadosTableAdapter
            // 
            this.Listar_AssociadosTableAdapter.ClearBeforeFill = true;
            // 
            // ListarDadosAssoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ListarDadosAssoc";
            this.Text = "ListarDadosAssoc";
            this.Load += new System.EventHandler(this.ListarDadosAssoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Listar_AssociadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RancheirosDataSet3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Listar_AssociadosBindingSource;
        private RancheirosDataSet3 RancheirosDataSet3;
        private RancheirosDataSet3TableAdapters.Listar_AssociadosTableAdapter Listar_AssociadosTableAdapter;
    }
}