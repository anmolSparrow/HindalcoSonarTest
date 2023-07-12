
namespace RMPCLApp.PermitToWork.View
{
    partial class XtraReport2
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery2 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReport2));
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.VerticalHeader = new DevExpress.XtraReports.UI.VerticalHeaderBand();
            this.VerticalDetail = new DevExpress.XtraReports.UI.VerticalDetailBand();
            this.pageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.pageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.table1 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.table2 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData1Vertical = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData1VerticalFirstRow = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData1VerticalRow_Even = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DetailData1VerticalLastRow_Even = new DevExpress.XtraReports.UI.XRControlStyle();
            this.HeaderData1Vertical = new DevExpress.XtraReports.UI.XRControlStyle();
            this.HeaderData1VerticalFirstRow = new DevExpress.XtraReports.UI.XRControlStyle();
            this.HeaderData1VerticalRow_Even = new DevExpress.XtraReports.UI.XRControlStyle();
            this.HeaderData1VerticalLastRow_Even = new DevExpress.XtraReports.UI.XRControlStyle();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pageInfo1,
            this.pageInfo2});
            this.BottomMargin.Name = "BottomMargin";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.label1});
            this.ReportHeader.HeightF = 60F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // VerticalHeader
            // 
            this.VerticalHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table1});
            this.VerticalHeader.HeightF = 112F;
            this.VerticalHeader.Name = "VerticalHeader";
            this.VerticalHeader.RepeatEveryPage = true;
            this.VerticalHeader.WidthF = 103.8533F;
            // 
            // VerticalDetail
            // 
            this.VerticalDetail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table2});
            this.VerticalDetail.HeightF = 112F;
            this.VerticalDetail.KeepTogether = true;
            this.VerticalDetail.Name = "VerticalDetail";
            this.VerticalDetail.WidthF = 103.8533F;
            // 
            // pageInfo1
            // 
            this.pageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.pageInfo1.Name = "pageInfo1";
            this.pageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.pageInfo1.SizeF = new System.Drawing.SizeF(325F, 23F);
            this.pageInfo1.StyleName = "PageInfo";
            // 
            // pageInfo2
            // 
            this.pageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(325F, 0F);
            this.pageInfo2.Name = "pageInfo2";
            this.pageInfo2.SizeF = new System.Drawing.SizeF(325F, 23F);
            this.pageInfo2.StyleName = "PageInfo";
            this.pageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.pageInfo2.TextFormatString = "Page {0} of {1}";
            // 
            // label1
            // 
            this.label1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.label1.Name = "label1";
            this.label1.SizeF = new System.Drawing.SizeF(74.67039F, 24.19433F);
            this.label1.StyleName = "Title";
            this.label1.Text = "TestTT";
            // 
            // table1
            // 
            this.table1.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.table1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.table1.Name = "table1";
            this.table1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow1,
            this.tableRow2,
            this.tableRow3,
            this.tableRow4});
            this.table1.SizeF = new System.Drawing.SizeF(103.8533F, 112F);
            // 
            // tableRow1
            // 
            this.tableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell1});
            this.tableRow1.Name = "tableRow1";
            this.tableRow1.Weight = 0.25D;
            // 
            // tableRow2
            // 
            this.tableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell2});
            this.tableRow2.Name = "tableRow2";
            this.tableRow2.Weight = 0.25D;
            // 
            // tableRow3
            // 
            this.tableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell3});
            this.tableRow3.Name = "tableRow3";
            this.tableRow3.Weight = 0.25D;
            // 
            // tableRow4
            // 
            this.tableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell4});
            this.tableRow4.Name = "tableRow4";
            this.tableRow4.Weight = 0.25D;
            // 
            // tableCell1
            // 
            this.tableCell1.Name = "tableCell1";
            this.tableCell1.StyleName = "HeaderData1VerticalFirstRow";
            this.tableCell1.Text = "Machine Tag No";
            this.tableCell1.Weight = 53.275370813397132D;
            this.tableCell1.WordWrap = false;
            // 
            // tableCell2
            // 
            this.tableCell2.Name = "tableCell2";
            this.tableCell2.StyleName = "HeaderData1VerticalRow_Even";
            this.tableCell2.Text = "Machine Name";
            this.tableCell2.Weight = 9.8932962548015357D;
            this.tableCell2.WordWrap = false;
            // 
            // tableCell3
            // 
            this.tableCell3.Name = "tableCell3";
            this.tableCell3.StyleName = "HeaderData1Vertical";
            this.tableCell3.Text = "Cad Location";
            this.tableCell3.Weight = 5.0384430948064267D;
            this.tableCell3.WordWrap = false;
            // 
            // tableCell4
            // 
            this.tableCell4.Name = "tableCell4";
            this.tableCell4.StyleName = "HeaderData1VerticalLastRow_Even";
            this.tableCell4.Text = "Machinelocation";
            this.tableCell4.Weight = 1D;
            this.tableCell4.WordWrap = false;
            // 
            // table2
            // 
            this.table2.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.table2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.table2.Name = "table2";
            this.table2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow5,
            this.tableRow6,
            this.tableRow7,
            this.tableRow8});
            this.table2.SizeF = new System.Drawing.SizeF(103.8533F, 112F);
            // 
            // tableRow5
            // 
            this.tableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell5});
            this.tableRow5.Name = "tableRow5";
            this.tableRow5.Weight = 0.25D;
            // 
            // tableRow6
            // 
            this.tableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell6});
            this.tableRow6.Name = "tableRow6";
            this.tableRow6.Weight = 0.25D;
            // 
            // tableRow7
            // 
            this.tableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell7});
            this.tableRow7.Name = "tableRow7";
            this.tableRow7.Weight = 0.25D;
            // 
            // tableRow8
            // 
            this.tableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell8});
            this.tableRow8.Name = "tableRow8";
            this.tableRow8.Weight = 0.25D;
            // 
            // tableCell5
            // 
            this.tableCell5.CanGrow = false;
            this.tableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MachineTagNo]")});
            this.tableCell5.Name = "tableCell5";
            this.tableCell5.StyleName = "DetailData1VerticalFirstRow";
            this.tableCell5.Weight = 0.41825932973017127D;
            this.tableCell5.WordWrap = false;
            // 
            // tableCell6
            // 
            this.tableCell6.CanGrow = false;
            this.tableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MachineName]")});
            this.tableCell6.Name = "tableCell6";
            this.tableCell6.StyleName = "DetailData1VerticalRow_Even";
            this.tableCell6.Weight = 0.41825932973017127D;
            this.tableCell6.WordWrap = false;
            // 
            // tableCell7
            // 
            this.tableCell7.CanGrow = false;
            this.tableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CadLocation]")});
            this.tableCell7.Name = "tableCell7";
            this.tableCell7.StyleName = "DetailData1Vertical";
            this.tableCell7.Weight = 0.41825932973017127D;
            this.tableCell7.WordWrap = false;
            // 
            // tableCell8
            // 
            this.tableCell8.CanGrow = false;
            this.tableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Machinelocation]")});
            this.tableCell8.Name = "tableCell8";
            this.tableCell8.StyleName = "DetailData1VerticalLastRow_Even";
            this.tableCell8.Weight = 0.41825932973017127D;
            this.tableCell8.WordWrap = false;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "ConnectionString1";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "Sp_Loadachines";
            storedProcQuery1.StoredProcName = "Sp_Loadachines";
            storedProcQuery2.Name = "Sp_FetchUnitMaster";
            storedProcQuery2.StoredProcName = "Sp_FetchUnitMaster";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1,
            storedProcQuery2});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Arial", 14.25F);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.Title.Name = "Title";
            this.Title.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            // 
            // PageInfo
            // 
            this.PageInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.PageInfo.Name = "PageInfo";
            this.PageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            // 
            // DetailData1Vertical
            // 
            this.DetailData1Vertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.DetailData1Vertical.BorderColor = System.Drawing.Color.White;
            this.DetailData1Vertical.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.DetailData1Vertical.BorderWidth = 2F;
            this.DetailData1Vertical.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData1Vertical.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DetailData1Vertical.Name = "DetailData1Vertical";
            this.DetailData1Vertical.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData1Vertical.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData1VerticalFirstRow
            // 
            this.DetailData1VerticalFirstRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.DetailData1VerticalFirstRow.BorderColor = System.Drawing.Color.White;
            this.DetailData1VerticalFirstRow.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.DetailData1VerticalFirstRow.BorderWidth = 2F;
            this.DetailData1VerticalFirstRow.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData1VerticalFirstRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DetailData1VerticalFirstRow.Name = "DetailData1VerticalFirstRow";
            this.DetailData1VerticalFirstRow.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData1VerticalFirstRow.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData1VerticalRow_Even
            // 
            this.DetailData1VerticalRow_Even.BackColor = System.Drawing.Color.Transparent;
            this.DetailData1VerticalRow_Even.BorderColor = System.Drawing.Color.White;
            this.DetailData1VerticalRow_Even.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.DetailData1VerticalRow_Even.BorderWidth = 2F;
            this.DetailData1VerticalRow_Even.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData1VerticalRow_Even.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DetailData1VerticalRow_Even.Name = "DetailData1VerticalRow_Even";
            this.DetailData1VerticalRow_Even.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData1VerticalRow_Even.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DetailData1VerticalLastRow_Even
            // 
            this.DetailData1VerticalLastRow_Even.BackColor = System.Drawing.Color.Transparent;
            this.DetailData1VerticalLastRow_Even.BorderColor = System.Drawing.Color.White;
            this.DetailData1VerticalLastRow_Even.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.DetailData1VerticalLastRow_Even.BorderWidth = 2F;
            this.DetailData1VerticalLastRow_Even.Font = new System.Drawing.Font("Arial", 8.25F);
            this.DetailData1VerticalLastRow_Even.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DetailData1VerticalLastRow_Even.Name = "DetailData1VerticalLastRow_Even";
            this.DetailData1VerticalLastRow_Even.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.DetailData1VerticalLastRow_Even.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // HeaderData1Vertical
            // 
            this.HeaderData1Vertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(229)))), ((int)(((byte)(250)))));
            this.HeaderData1Vertical.BorderColor = System.Drawing.Color.White;
            this.HeaderData1Vertical.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.HeaderData1Vertical.BorderWidth = 2F;
            this.HeaderData1Vertical.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.HeaderData1Vertical.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.HeaderData1Vertical.Name = "HeaderData1Vertical";
            this.HeaderData1Vertical.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.HeaderData1Vertical.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // HeaderData1VerticalFirstRow
            // 
            this.HeaderData1VerticalFirstRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(229)))), ((int)(((byte)(250)))));
            this.HeaderData1VerticalFirstRow.BorderColor = System.Drawing.Color.White;
            this.HeaderData1VerticalFirstRow.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.HeaderData1VerticalFirstRow.BorderWidth = 2F;
            this.HeaderData1VerticalFirstRow.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.HeaderData1VerticalFirstRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.HeaderData1VerticalFirstRow.Name = "HeaderData1VerticalFirstRow";
            this.HeaderData1VerticalFirstRow.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.HeaderData1VerticalFirstRow.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // HeaderData1VerticalRow_Even
            // 
            this.HeaderData1VerticalRow_Even.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(239)))), ((int)(((byte)(252)))));
            this.HeaderData1VerticalRow_Even.BorderColor = System.Drawing.Color.White;
            this.HeaderData1VerticalRow_Even.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.HeaderData1VerticalRow_Even.BorderWidth = 2F;
            this.HeaderData1VerticalRow_Even.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.HeaderData1VerticalRow_Even.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.HeaderData1VerticalRow_Even.Name = "HeaderData1VerticalRow_Even";
            this.HeaderData1VerticalRow_Even.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.HeaderData1VerticalRow_Even.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // HeaderData1VerticalLastRow_Even
            // 
            this.HeaderData1VerticalLastRow_Even.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(239)))), ((int)(((byte)(252)))));
            this.HeaderData1VerticalLastRow_Even.BorderColor = System.Drawing.Color.White;
            this.HeaderData1VerticalLastRow_Even.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.HeaderData1VerticalLastRow_Even.BorderWidth = 2F;
            this.HeaderData1VerticalLastRow_Even.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.HeaderData1VerticalLastRow_Even.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.HeaderData1VerticalLastRow_Even.Name = "HeaderData1VerticalLastRow_Even";
            this.HeaderData1VerticalLastRow_Even.Padding = new DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100F);
            this.HeaderData1VerticalLastRow_Even.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XtraReport2
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.VerticalHeader,
            this.VerticalDetail});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Sp_Loadachines";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.PageInfo,
            this.DetailData1Vertical,
            this.DetailData1VerticalFirstRow,
            this.DetailData1VerticalRow_Even,
            this.DetailData1VerticalLastRow_Even,
            this.HeaderData1Vertical,
            this.HeaderData1VerticalFirstRow,
            this.HeaderData1VerticalRow_Even,
            this.HeaderData1VerticalLastRow_Even});
            this.Version = "20.2";
            this.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRPageInfo pageInfo1;
        private DevExpress.XtraReports.UI.XRPageInfo pageInfo2;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel label1;
        private DevExpress.XtraReports.UI.VerticalHeaderBand VerticalHeader;
        private DevExpress.XtraReports.UI.XRTable table1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell2;
        private DevExpress.XtraReports.UI.XRTableRow tableRow3;
        private DevExpress.XtraReports.UI.XRTableCell tableCell3;
        private DevExpress.XtraReports.UI.XRTableRow tableRow4;
        private DevExpress.XtraReports.UI.XRTableCell tableCell4;
        private DevExpress.XtraReports.UI.VerticalDetailBand VerticalDetail;
        private DevExpress.XtraReports.UI.XRTable table2;
        private DevExpress.XtraReports.UI.XRTableRow tableRow5;
        private DevExpress.XtraReports.UI.XRTableCell tableCell5;
        private DevExpress.XtraReports.UI.XRTableRow tableRow6;
        private DevExpress.XtraReports.UI.XRTableCell tableCell6;
        private DevExpress.XtraReports.UI.XRTableRow tableRow7;
        private DevExpress.XtraReports.UI.XRTableCell tableCell7;
        private DevExpress.XtraReports.UI.XRTableRow tableRow8;
        private DevExpress.XtraReports.UI.XRTableCell tableCell8;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData1Vertical;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData1VerticalFirstRow;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData1VerticalRow_Even;
        private DevExpress.XtraReports.UI.XRControlStyle DetailData1VerticalLastRow_Even;
        private DevExpress.XtraReports.UI.XRControlStyle HeaderData1Vertical;
        private DevExpress.XtraReports.UI.XRControlStyle HeaderData1VerticalFirstRow;
        private DevExpress.XtraReports.UI.XRControlStyle HeaderData1VerticalRow_Even;
        private DevExpress.XtraReports.UI.XRControlStyle HeaderData1VerticalLastRow_Even;
    }
}
