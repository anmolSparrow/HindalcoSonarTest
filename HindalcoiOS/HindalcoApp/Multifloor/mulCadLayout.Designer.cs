
namespace HindalcoiOS.Multifloor
{
    partial class mulCadLayout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mulCadLayout));
            this.cadPictBox = new CADImport.FaceModule.CADPictureBox();
            this.OffSetCalculatorMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openEditMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPackageMAchineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBreakDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changeMachineConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputUtilityIssuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewReportLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestLOTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMachineDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getMachineReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.machineComplianceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePTWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.machineHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportAnIncidentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadedDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safetyDocsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liveFeedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpenfile = new System.Windows.Forms.OpenFileDialog();
            this.printPrevDlg = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.OffSetCalculatorMenu.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cadPictBox
            // 
            this.cadPictBox.BackColor = System.Drawing.Color.Black;
            this.cadPictBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cadPictBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cadPictBox.DoubleBuffering = true;
            this.cadPictBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cadPictBox.Location = new System.Drawing.Point(0, 0);
            this.cadPictBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cadPictBox.Name = "cadPictBox";
            this.cadPictBox.Ortho = false;
            this.cadPictBox.Position = new System.Drawing.Point(0, 0);
            this.cadPictBox.ScrollBars = CADImport.FaceModule.ScrollBarsShow.Automatic;
            this.cadPictBox.Size = new System.Drawing.Size(1113, 815);
            this.cadPictBox.TabIndex = 1;
            this.cadPictBox.VirtualSize = new System.Drawing.Size(0, 0);
            this.cadPictBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.cadPictBox_DragDrop);
            this.cadPictBox.Paint += new System.Windows.Forms.PaintEventHandler(this.cadPictBox_Paint);
            this.cadPictBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cadPictBox_KeyDown);
            this.cadPictBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CADPictBoxKeyUp);
            this.cadPictBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cadPictBox_MouseClick);
            this.cadPictBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cadPictBox_MouseDoubleClick);
            this.cadPictBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cadPictBox_MouseDown);
            this.cadPictBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cadPictBox_MouseMove);
            this.cadPictBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cadPictBox_MouseUp);
            // 
            // OffSetCalculatorMenu
            // 
            this.OffSetCalculatorMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.OffSetCalculatorMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.OffSetCalculatorMenu.Name = "OffSetCalculatorMenu";
            this.OffSetCalculatorMenu.Size = new System.Drawing.Size(186, 28);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(185, 24);
            this.toolStripMenuItem2.Text = "Calculate OffSet";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.calculateoffsetStripItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openEditMenuToolStripMenuItem,
            this.createPackageMAchineToolStripMenuItem,
            this.addBreakDownToolStripMenuItem,
            this.remoteConnectionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.changeMachineConfigurationToolStripMenuItem,
            this.inputUtilityIssuesToolStripMenuItem,
            this.viewConnectionToolStripMenuItem,
            this.viewReportLineToolStripMenuItem,
            this.requestLOTOToolStripMenuItem,
            this.copyMachineDataToolStripMenuItem,
            this.getMachineReportToolStripMenuItem,
            this.machineComplianceToolStripMenuItem,
            this.generatePTWToolStripMenuItem,
            this.assignJobToolStripMenuItem,
            this.machineHistoryToolStripMenuItem,
            this.reportAnIncidentToolStripMenuItem,
            this.uploadedDocumentsToolStripMenuItem,
            this.safetyDocsToolStripMenuItem,
            this.liveFeedDataToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowItemToolTips = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(288, 524);
            // 
            // openEditMenuToolStripMenuItem
            // 
            this.openEditMenuToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.PaperKind_Tabloid;
            this.openEditMenuToolStripMenuItem.Name = "openEditMenuToolStripMenuItem";
            this.openEditMenuToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.openEditMenuToolStripMenuItem.Tag = "OpenEdit";
            this.openEditMenuToolStripMenuItem.Text = "Open Edit Menu";
            this.openEditMenuToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // createPackageMAchineToolStripMenuItem
            // 
            this.createPackageMAchineToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.PageMarginsNarrow;
            this.createPackageMAchineToolStripMenuItem.Name = "createPackageMAchineToolStripMenuItem";
            this.createPackageMAchineToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.createPackageMAchineToolStripMenuItem.Tag = "PackageMachine";
            this.createPackageMAchineToolStripMenuItem.Text = "Package Machine";
            this.createPackageMAchineToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // addBreakDownToolStripMenuItem
            // 
            this.addBreakDownToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.whitebg;
            this.addBreakDownToolStripMenuItem.Name = "addBreakDownToolStripMenuItem";
            this.addBreakDownToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.addBreakDownToolStripMenuItem.Tag = "AddBRK";
            this.addBreakDownToolStripMenuItem.Text = "Add Break Down";
            this.addBreakDownToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // remoteConnectionToolStripMenuItem
            // 
            this.remoteConnectionToolStripMenuItem.Name = "remoteConnectionToolStripMenuItem";
            this.remoteConnectionToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.remoteConnectionToolStripMenuItem.Tag = "RC";
            this.remoteConnectionToolStripMenuItem.Text = "Remote Connection";
            this.remoteConnectionToolStripMenuItem.Visible = false;
            this.remoteConnectionToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(287, 26);
            this.toolStripMenuItem1.Tag = "ReportIssue";
            this.toolStripMenuItem1.Text = "Report Issue";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // changeMachineConfigurationToolStripMenuItem
            // 
            this.changeMachineConfigurationToolStripMenuItem.Name = "changeMachineConfigurationToolStripMenuItem";
            this.changeMachineConfigurationToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.changeMachineConfigurationToolStripMenuItem.Tag = "ChangeMachine";
            this.changeMachineConfigurationToolStripMenuItem.Text = "Change Machine Configuration";
            this.changeMachineConfigurationToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // inputUtilityIssuesToolStripMenuItem
            // 
            this.inputUtilityIssuesToolStripMenuItem.Name = "inputUtilityIssuesToolStripMenuItem";
            this.inputUtilityIssuesToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.inputUtilityIssuesToolStripMenuItem.Tag = "InputUtility";
            this.inputUtilityIssuesToolStripMenuItem.Text = "Input Utility Issues";
            this.inputUtilityIssuesToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // viewConnectionToolStripMenuItem
            // 
            this.viewConnectionToolStripMenuItem.Name = "viewConnectionToolStripMenuItem";
            this.viewConnectionToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.viewConnectionToolStripMenuItem.Tag = "ViewConnection";
            this.viewConnectionToolStripMenuItem.Text = "View Connection";
            this.viewConnectionToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // viewReportLineToolStripMenuItem
            // 
            this.viewReportLineToolStripMenuItem.Name = "viewReportLineToolStripMenuItem";
            this.viewReportLineToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.viewReportLineToolStripMenuItem.Tag = "ViewLine";
            this.viewReportLineToolStripMenuItem.Text = "View /Report Line";
            this.viewReportLineToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // requestLOTOToolStripMenuItem
            // 
            this.requestLOTOToolStripMenuItem.Name = "requestLOTOToolStripMenuItem";
            this.requestLOTOToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.requestLOTOToolStripMenuItem.Tag = "RequestLOTO";
            this.requestLOTOToolStripMenuItem.Text = "Request LOTO";
            this.requestLOTOToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // copyMachineDataToolStripMenuItem
            // 
            this.copyMachineDataToolStripMenuItem.Name = "copyMachineDataToolStripMenuItem";
            this.copyMachineDataToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.copyMachineDataToolStripMenuItem.Tag = "CopyMachine";
            this.copyMachineDataToolStripMenuItem.Text = "Copy Machine Data";
            this.copyMachineDataToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // getMachineReportToolStripMenuItem
            // 
            this.getMachineReportToolStripMenuItem.Name = "getMachineReportToolStripMenuItem";
            this.getMachineReportToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.getMachineReportToolStripMenuItem.Tag = "GetMachine";
            this.getMachineReportToolStripMenuItem.Text = "Get Machine Report";
            this.getMachineReportToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // machineComplianceToolStripMenuItem
            // 
            this.machineComplianceToolStripMenuItem.Name = "machineComplianceToolStripMenuItem";
            this.machineComplianceToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.machineComplianceToolStripMenuItem.Tag = "MachineCOMP";
            this.machineComplianceToolStripMenuItem.Text = "Machine Compliance";
            this.machineComplianceToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // generatePTWToolStripMenuItem
            // 
            this.generatePTWToolStripMenuItem.Name = "generatePTWToolStripMenuItem";
            this.generatePTWToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.generatePTWToolStripMenuItem.Tag = "RequestPTW";
            this.generatePTWToolStripMenuItem.Text = "Request PTW";
            this.generatePTWToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // assignJobToolStripMenuItem
            // 
            this.assignJobToolStripMenuItem.Name = "assignJobToolStripMenuItem";
            this.assignJobToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.assignJobToolStripMenuItem.Tag = "AssignJob";
            this.assignJobToolStripMenuItem.Text = "Assign Job";
            this.assignJobToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // machineHistoryToolStripMenuItem
            // 
            this.machineHistoryToolStripMenuItem.Name = "machineHistoryToolStripMenuItem";
            this.machineHistoryToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.machineHistoryToolStripMenuItem.Tag = "MachineHistory";
            this.machineHistoryToolStripMenuItem.Text = "Machine History";
            this.machineHistoryToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // reportAnIncidentToolStripMenuItem
            // 
            this.reportAnIncidentToolStripMenuItem.Name = "reportAnIncidentToolStripMenuItem";
            this.reportAnIncidentToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.reportAnIncidentToolStripMenuItem.Tag = "ReportIncident";
            this.reportAnIncidentToolStripMenuItem.Text = "Report an Incident";
            this.reportAnIncidentToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // uploadedDocumentsToolStripMenuItem
            // 
            this.uploadedDocumentsToolStripMenuItem.Name = "uploadedDocumentsToolStripMenuItem";
            this.uploadedDocumentsToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.uploadedDocumentsToolStripMenuItem.Tag = "UploadDoc";
            this.uploadedDocumentsToolStripMenuItem.Text = "Uploaded Documents";
            this.uploadedDocumentsToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // safetyDocsToolStripMenuItem
            // 
            this.safetyDocsToolStripMenuItem.Name = "safetyDocsToolStripMenuItem";
            this.safetyDocsToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.safetyDocsToolStripMenuItem.Tag = "SafetyDock";
            this.safetyDocsToolStripMenuItem.Text = "Safety Docs";
            this.safetyDocsToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // liveFeedDataToolStripMenuItem
            // 
            this.liveFeedDataToolStripMenuItem.Name = "liveFeedDataToolStripMenuItem";
            this.liveFeedDataToolStripMenuItem.Size = new System.Drawing.Size(287, 26);
            this.liveFeedDataToolStripMenuItem.Tag = "LiveData";
            this.liveFeedDataToolStripMenuItem.Text = "Live Feed Data";
            this.liveFeedDataToolStripMenuItem.Click += new System.EventHandler(this.openEditMenuToolStripMenuItem_Click);
            // 
            // dlgOpenfile
            // 
            this.dlgOpenfile.DefaultExt = "*.bmp;*.jpg;*.jpeg;*.tiff; *.gif; *.ico;*.dxf;*.dwg;*.hpg;*.plt;*.rtl; *.spl; *.p" +
    "rn; *.gl2;*.hpgl2;*.hpgl;*.hp2;*.hp1; *.hp; *.plo; *.hg;*.hgl;*.cur;*.png; *.emf" +
    "; *.wmf; *.cgm";
            this.dlgOpenfile.FileName = "dlgOpenfile";
            this.dlgOpenfile.Filter = resources.GetString("dlgOpenfile.Filter");
            // 
            // printPrevDlg
            // 
            this.printPrevDlg.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPrevDlg.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPrevDlg.ClientSize = new System.Drawing.Size(400, 300);
            this.printPrevDlg.Enabled = true;
            this.printPrevDlg.Icon = ((System.Drawing.Icon)(resources.GetObject("printPrevDlg.Icon")));
            this.printPrevDlg.Name = "printPrevDlg";
            this.printPrevDlg.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // mulCadLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 815);
            this.Controls.Add(this.cadPictBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "mulCadLayout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "CadLayout";
            this.Text = "CadLayout";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mulCadLayout_FormClosed);
            this.OffSetCalculatorMenu.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public CADImport.FaceModule.CADPictureBox cadPictBox;
        private System.Windows.Forms.OpenFileDialog dlgOpenfile;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.ToolStripMenuItem openEditMenuToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem createPackageMAchineToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem addBreakDownToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem remoteConnectionToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem changeMachineConfigurationToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem inputUtilityIssuesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem viewConnectionToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem viewReportLineToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem requestLOTOToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem copyMachineDataToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem getMachineReportToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem machineComplianceToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem generatePTWToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem assignJobToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem machineHistoryToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem reportAnIncidentToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem uploadedDocumentsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem safetyDocsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem liveFeedDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        public System.Windows.Forms.ContextMenuStrip OffSetCalculatorMenu;
        private System.Windows.Forms.PrintPreviewDialog printPrevDlg;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}