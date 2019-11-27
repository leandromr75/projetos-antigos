namespace FT_Comercio
{
    partial class Impressao
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
            this.Listar_RelatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FTDataSet2 = new FT_Comercio.FTDataSet2();
            this.RelatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FTDataSet1 = new FT_Comercio.FTDataSet1();
            this.PedidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FTDataSet = new FT_Comercio.FTDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PedidosTableAdapter = new FT_Comercio.FTDataSetTableAdapters.PedidosTableAdapter();
            this.RelatTableAdapter = new FT_Comercio.FTDataSet1TableAdapters.RelatTableAdapter();
            this.Listar_RelatTableAdapter = new FT_Comercio.FTDataSet2TableAdapters.Listar_RelatTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Listar_RelatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FTDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RelatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FTDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PedidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FTDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // Listar_RelatBindingSource
            // 
            this.Listar_RelatBindingSource.DataMember = "Listar_Relat";
            this.Listar_RelatBindingSource.DataSource = this.FTDataSet2;
            // 
            // FTDataSet2
            // 
            this.FTDataSet2.DataSetName = "FTDataSet2";
            this.FTDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RelatBindingSource
            // 
            this.RelatBindingSource.DataMember = "Relat";
            this.RelatBindingSource.DataSource = this.FTDataSet1;
            // 
            // FTDataSet1
            // 
            this.FTDataSet1.DataSetName = "FTDataSet1";
            this.FTDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PedidosBindingSource
            // 
            this.PedidosBindingSource.DataMember = "Pedidos";
            this.PedidosBindingSource.DataSource = this.FTDataSet;
            // 
            // FTDataSet
            // 
            this.FTDataSet.DataSetName = "FTDataSet";
            this.FTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Listar_RelatBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FT_Comercio.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowPageNavigationControls = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(632, 661);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // PedidosTableAdapter
            // 
            this.PedidosTableAdapter.ClearBeforeFill = true;
            // 
            // RelatTableAdapter
            // 
            this.RelatTableAdapter.ClearBeforeFill = true;
            // 
            // Listar_RelatTableAdapter
            // 
            this.Listar_RelatTableAdapter.ClearBeforeFill = true;
            // 
            // Impressao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 661);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Impressao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orçamento";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Impressao_FormClosed);
            this.Load += new System.EventHandler(this.Impressao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Listar_RelatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FTDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RelatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FTDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PedidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FTDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PedidosBindingSource;
        private FTDataSet FTDataSet;
        private FTDataSetTableAdapters.PedidosTableAdapter PedidosTableAdapter;
        private System.Windows.Forms.BindingSource RelatBindingSource;
        private FTDataSet1 FTDataSet1;
        private FTDataSet1TableAdapters.RelatTableAdapter RelatTableAdapter;
        private System.Windows.Forms.BindingSource Listar_RelatBindingSource;
        private FTDataSet2 FTDataSet2;
        private FTDataSet2TableAdapters.Listar_RelatTableAdapter Listar_RelatTableAdapter;
    }
}