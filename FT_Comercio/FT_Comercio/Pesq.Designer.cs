﻿namespace FT_Comercio
{
    partial class Pesq
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.FTDataSet2 = new FT_Comercio.FTDataSet2();
            this.Listar_RelatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Listar_RelatTableAdapter = new FT_Comercio.FTDataSet2TableAdapters.Listar_RelatTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.FTDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Listar_RelatBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.Listar_RelatBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FT_Comercio.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowPageNavigationControls = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(632, 593);
            this.reportViewer1.TabIndex = 0;
            // 
            // FTDataSet2
            // 
            this.FTDataSet2.DataSetName = "FTDataSet2";
            this.FTDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Listar_RelatBindingSource
            // 
            this.Listar_RelatBindingSource.DataMember = "Listar_Relat";
            this.Listar_RelatBindingSource.DataSource = this.FTDataSet2;
            // 
            // Listar_RelatTableAdapter
            // 
            this.Listar_RelatTableAdapter.ClearBeforeFill = true;
            // 
            // Pesq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 593);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Pesq";
            this.Text = "Imprimir Orçamento";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Pesq_FormClosed);
            this.Load += new System.EventHandler(this.Pesq_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FTDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Listar_RelatBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Listar_RelatBindingSource;
        private FTDataSet2 FTDataSet2;
        private FTDataSet2TableAdapters.Listar_RelatTableAdapter Listar_RelatTableAdapter;
    }
}