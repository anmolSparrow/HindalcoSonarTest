
namespace RMPCLApp.Machine_Edit_Form
{
    partial class KeyCompoSpecsReader
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
            Utilities.BunifuPages.BunifuAnimatorNS.Animation animation1 = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyCompoSpecsReader));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.tabControl1 = new Bunifu.UI.WinForms.BunifuPages();
            this.GeneralPage = new System.Windows.Forms.TabPage();
            this.DBGridGeneral = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.SpecificParameterPage = new System.Windows.Forms.TabPage();
            this.DBGridSpecific = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.workLocationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.GeneralButton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuButton2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuGroupBox1 = new Bunifu.UI.WinForms.BunifuGroupBox();
            this.tabControl1.SuspendLayout();
            this.GeneralPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBGridGeneral)).BeginInit();
            this.SpecificParameterPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBGridSpecific)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workLocationBindingSource)).BeginInit();
            this.bunifuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.AllowTransitions = false;
            this.tabControl1.Controls.Add(this.GeneralPage);
            this.tabControl1.Controls.Add(this.SpecificParameterPage);
            this.tabControl1.Location = new System.Drawing.Point(17, 47);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Page = this.GeneralPage;
            this.tabControl1.PageIndex = 0;
            this.tabControl1.PageName = "GeneralPage";
            this.tabControl1.PageTitle = "General";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(773, 300);
            this.tabControl1.TabIndex = 0;
            animation1.AnimateOnlyDifferences = false;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.tabControl1.Transition = animation1;
            this.tabControl1.TransitionType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // GeneralPage
            // 
            this.GeneralPage.Controls.Add(this.DBGridGeneral);
            this.GeneralPage.Location = new System.Drawing.Point(4, 4);
            this.GeneralPage.Name = "GeneralPage";
            this.GeneralPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralPage.Size = new System.Drawing.Size(765, 267);
            this.GeneralPage.TabIndex = 0;
            this.GeneralPage.Tag = "General";
            this.GeneralPage.Text = "General";
            this.GeneralPage.UseVisualStyleBackColor = true;
            // 
            // DBGridGeneral
            // 
            this.DBGridGeneral.AllowCustomTheming = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.DBGridGeneral.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DBGridGeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DBGridGeneral.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DBGridGeneral.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DBGridGeneral.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DBGridGeneral.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DBGridGeneral.ColumnHeadersHeight = 40;
            this.DBGridGeneral.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.DBGridGeneral.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DBGridGeneral.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DBGridGeneral.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DBGridGeneral.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DBGridGeneral.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.DBGridGeneral.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DBGridGeneral.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.DBGridGeneral.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DBGridGeneral.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DBGridGeneral.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.DBGridGeneral.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DBGridGeneral.CurrentTheme.Name = null;
            this.DBGridGeneral.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DBGridGeneral.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DBGridGeneral.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DBGridGeneral.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DBGridGeneral.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DBGridGeneral.DefaultCellStyle = dataGridViewCellStyle3;
            this.DBGridGeneral.EnableHeadersVisualStyles = false;
            this.DBGridGeneral.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DBGridGeneral.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.DBGridGeneral.HeaderBgColor = System.Drawing.Color.Empty;
            this.DBGridGeneral.HeaderForeColor = System.Drawing.Color.White;
            this.DBGridGeneral.Location = new System.Drawing.Point(5, 19);
            this.DBGridGeneral.Name = "DBGridGeneral";
            this.DBGridGeneral.RowHeadersVisible = false;
            this.DBGridGeneral.RowHeadersWidth = 51;
            this.DBGridGeneral.RowTemplate.Height = 40;
            this.DBGridGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DBGridGeneral.Size = new System.Drawing.Size(755, 242);
            this.DBGridGeneral.TabIndex = 0;
            this.DBGridGeneral.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // SpecificParameterPage
            // 
            this.SpecificParameterPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SpecificParameterPage.Controls.Add(this.DBGridSpecific);
            this.SpecificParameterPage.Location = new System.Drawing.Point(4, 4);
            this.SpecificParameterPage.Name = "SpecificParameterPage";
            this.SpecificParameterPage.Padding = new System.Windows.Forms.Padding(3);
            this.SpecificParameterPage.Size = new System.Drawing.Size(765, 267);
            this.SpecificParameterPage.TabIndex = 1;
            this.SpecificParameterPage.Tag = "Specific";
            this.SpecificParameterPage.Text = "Specific Parameter";
            this.SpecificParameterPage.UseVisualStyleBackColor = true;
            this.SpecificParameterPage.Click += new System.EventHandler(this.SpecificParameterPage_Click);
            // 
            // DBGridSpecific
            // 
            this.DBGridSpecific.AllowCustomTheming = true;
            this.DBGridSpecific.AllowUserToAddRows = false;
            this.DBGridSpecific.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.DBGridSpecific.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DBGridSpecific.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DBGridSpecific.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DBGridSpecific.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DBGridSpecific.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DBGridSpecific.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DBGridSpecific.ColumnHeadersHeight = 40;
            this.DBGridSpecific.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.DBGridSpecific.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DBGridSpecific.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DBGridSpecific.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DBGridSpecific.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DBGridSpecific.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.DBGridSpecific.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DBGridSpecific.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.DBGridSpecific.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DBGridSpecific.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DBGridSpecific.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.DBGridSpecific.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DBGridSpecific.CurrentTheme.Name = null;
            this.DBGridSpecific.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DBGridSpecific.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DBGridSpecific.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DBGridSpecific.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DBGridSpecific.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DBGridSpecific.DefaultCellStyle = dataGridViewCellStyle6;
            this.DBGridSpecific.EnableHeadersVisualStyles = false;
            this.DBGridSpecific.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DBGridSpecific.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.DBGridSpecific.HeaderBgColor = System.Drawing.Color.Empty;
            this.DBGridSpecific.HeaderForeColor = System.Drawing.Color.White;
            this.DBGridSpecific.Location = new System.Drawing.Point(5, 19);
            this.DBGridSpecific.Name = "DBGridSpecific";
            this.DBGridSpecific.RowHeadersVisible = false;
            this.DBGridSpecific.RowHeadersWidth = 51;
            this.DBGridSpecific.RowTemplate.Height = 40;
            this.DBGridSpecific.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DBGridSpecific.Size = new System.Drawing.Size(749, 240);
            this.DBGridSpecific.TabIndex = 0;
            this.DBGridSpecific.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // workLocationBindingSource
            // 
            this.workLocationBindingSource.DataMember = "WorkLocation";
            // 
            // btnSave
            // 
            this.btnSave.AllowAnimations = true;
            this.btnSave.AllowMouseEffects = true;
            this.btnSave.AllowToggling = false;
            this.btnSave.AllowV2Features = false;
            this.btnSave.AnimationSpeed = 200;
            this.btnSave.AutoGenerateColors = false;
            this.btnSave.AutoRoundBorders = true;
            this.btnSave.AutoSizeLeftIcon = true;
            this.btnSave.AutoSizeRightIcon = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.ButtonText = "Save";
            this.btnSave.ButtonTextMarginLeft = 0;
            this.btnSave.ColorContrastOnClick = 45;
            this.btnSave.ColorContrastOnHover = 45;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnSave.CustomizableEdges = borderEdges1;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSave.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSave.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSave.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSave.IconMarginLeft = 11;
            this.btnSave.IconPadding = 10;
            this.btnSave.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSave.IconSize = 25;
            this.btnSave.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.IdleBorderRadius = 27;
            this.btnSave.IdleBorderThickness = 1;
            this.btnSave.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.IdleIconLeftImage = null;
            this.btnSave.IdleIconRightImage = null;
            this.btnSave.IndicateFocus = false;
            this.btnSave.Location = new System.Drawing.Point(676, 374);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSave.OnDisabledState.BorderRadius = 1;
            this.btnSave.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.OnDisabledState.BorderThickness = 1;
            this.btnSave.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSave.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSave.OnDisabledState.IconLeftImage = null;
            this.btnSave.OnDisabledState.IconRightImage = null;
            this.btnSave.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnSave.onHoverState.BorderRadius = 1;
            this.btnSave.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.onHoverState.BorderThickness = 1;
            this.btnSave.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnSave.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnSave.onHoverState.IconLeftImage = null;
            this.btnSave.onHoverState.IconRightImage = null;
            this.btnSave.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.OnIdleState.BorderRadius = 1;
            this.btnSave.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.OnIdleState.BorderThickness = 1;
            this.btnSave.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnSave.OnIdleState.IconLeftImage = null;
            this.btnSave.OnIdleState.IconRightImage = null;
            this.btnSave.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSave.OnPressedState.BorderRadius = 1;
            this.btnSave.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.OnPressedState.BorderThickness = 1;
            this.btnSave.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSave.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnSave.OnPressedState.IconLeftImage = null;
            this.btnSave.OnPressedState.IconRightImage = null;
            this.btnSave.Size = new System.Drawing.Size(131, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSave.TextMarginLeft = 0;
            this.btnSave.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSave.UseDefaultRadiusAndThickness = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // GeneralButton
            // 
            this.GeneralButton.AllowAnimations = true;
            this.GeneralButton.AllowMouseEffects = true;
            this.GeneralButton.AllowToggling = false;
            this.GeneralButton.AllowV2Features = false;
            this.GeneralButton.AnimationSpeed = 200;
            this.GeneralButton.AutoGenerateColors = false;
            this.GeneralButton.AutoRoundBorders = true;
            this.GeneralButton.AutoSizeLeftIcon = true;
            this.GeneralButton.AutoSizeRightIcon = true;
            this.GeneralButton.BackColor = System.Drawing.Color.Transparent;
            this.GeneralButton.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.GeneralButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GeneralButton.BackgroundImage")));
            this.GeneralButton.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.GeneralButton.ButtonText = "General";
            this.GeneralButton.ButtonTextMarginLeft = 0;
            this.GeneralButton.ColorContrastOnClick = 45;
            this.GeneralButton.ColorContrastOnHover = 45;
            this.GeneralButton.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.GeneralButton.CustomizableEdges = borderEdges2;
            this.GeneralButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.GeneralButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.GeneralButton.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.GeneralButton.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.GeneralButton.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.GeneralButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GeneralButton.ForeColor = System.Drawing.Color.White;
            this.GeneralButton.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GeneralButton.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.GeneralButton.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.GeneralButton.IconMarginLeft = 11;
            this.GeneralButton.IconPadding = 10;
            this.GeneralButton.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.GeneralButton.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.GeneralButton.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.GeneralButton.IconSize = 25;
            this.GeneralButton.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.GeneralButton.IdleBorderRadius = 24;
            this.GeneralButton.IdleBorderThickness = 1;
            this.GeneralButton.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.GeneralButton.IdleIconLeftImage = null;
            this.GeneralButton.IdleIconRightImage = null;
            this.GeneralButton.IndicateFocus = false;
            this.GeneralButton.Location = new System.Drawing.Point(30, 11);
            this.GeneralButton.Name = "GeneralButton";
            this.GeneralButton.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.GeneralButton.OnDisabledState.BorderRadius = 1;
            this.GeneralButton.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.GeneralButton.OnDisabledState.BorderThickness = 1;
            this.GeneralButton.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.GeneralButton.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.GeneralButton.OnDisabledState.IconLeftImage = null;
            this.GeneralButton.OnDisabledState.IconRightImage = null;
            this.GeneralButton.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.GeneralButton.onHoverState.BorderRadius = 1;
            this.GeneralButton.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.GeneralButton.onHoverState.BorderThickness = 1;
            this.GeneralButton.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.GeneralButton.onHoverState.ForeColor = System.Drawing.Color.White;
            this.GeneralButton.onHoverState.IconLeftImage = null;
            this.GeneralButton.onHoverState.IconRightImage = null;
            this.GeneralButton.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.GeneralButton.OnIdleState.BorderRadius = 1;
            this.GeneralButton.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.GeneralButton.OnIdleState.BorderThickness = 1;
            this.GeneralButton.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.GeneralButton.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.GeneralButton.OnIdleState.IconLeftImage = null;
            this.GeneralButton.OnIdleState.IconRightImage = null;
            this.GeneralButton.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.GeneralButton.OnPressedState.BorderRadius = 1;
            this.GeneralButton.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.GeneralButton.OnPressedState.BorderThickness = 1;
            this.GeneralButton.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.GeneralButton.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.GeneralButton.OnPressedState.IconLeftImage = null;
            this.GeneralButton.OnPressedState.IconRightImage = null;
            this.GeneralButton.Size = new System.Drawing.Size(111, 26);
            this.GeneralButton.TabIndex = 2;
            this.GeneralButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GeneralButton.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.GeneralButton.TextMarginLeft = 0;
            this.GeneralButton.TextPadding = new System.Windows.Forms.Padding(0);
            this.GeneralButton.UseDefaultRadiusAndThickness = true;
            this.GeneralButton.Click += new System.EventHandler(this.bunifuButton1_Click);
            // 
            // bunifuButton2
            // 
            this.bunifuButton2.AllowAnimations = true;
            this.bunifuButton2.AllowMouseEffects = true;
            this.bunifuButton2.AllowToggling = false;
            this.bunifuButton2.AllowV2Features = false;
            this.bunifuButton2.AnimationSpeed = 200;
            this.bunifuButton2.AutoGenerateColors = false;
            this.bunifuButton2.AutoRoundBorders = true;
            this.bunifuButton2.AutoSizeLeftIcon = true;
            this.bunifuButton2.AutoSizeRightIcon = true;
            this.bunifuButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton2.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.bunifuButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton2.BackgroundImage")));
            this.bunifuButton2.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton2.ButtonText = "Specific Parameter";
            this.bunifuButton2.ButtonTextMarginLeft = 0;
            this.bunifuButton2.ColorContrastOnClick = 45;
            this.bunifuButton2.ColorContrastOnHover = 45;
            this.bunifuButton2.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.bunifuButton2.CustomizableEdges = borderEdges3;
            this.bunifuButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton2.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton2.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton2.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton2.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuButton2.ForeColor = System.Drawing.Color.White;
            this.bunifuButton2.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuButton2.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton2.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.bunifuButton2.IconMarginLeft = 11;
            this.bunifuButton2.IconPadding = 10;
            this.bunifuButton2.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bunifuButton2.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton2.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.bunifuButton2.IconSize = 25;
            this.bunifuButton2.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.bunifuButton2.IdleBorderRadius = 24;
            this.bunifuButton2.IdleBorderThickness = 1;
            this.bunifuButton2.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.bunifuButton2.IdleIconLeftImage = null;
            this.bunifuButton2.IdleIconRightImage = null;
            this.bunifuButton2.IndicateFocus = false;
            this.bunifuButton2.Location = new System.Drawing.Point(152, 11);
            this.bunifuButton2.Name = "bunifuButton2";
            this.bunifuButton2.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton2.OnDisabledState.BorderRadius = 1;
            this.bunifuButton2.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton2.OnDisabledState.BorderThickness = 1;
            this.bunifuButton2.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton2.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton2.OnDisabledState.IconLeftImage = null;
            this.bunifuButton2.OnDisabledState.IconRightImage = null;
            this.bunifuButton2.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuButton2.onHoverState.BorderRadius = 1;
            this.bunifuButton2.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton2.onHoverState.BorderThickness = 1;
            this.bunifuButton2.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuButton2.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton2.onHoverState.IconLeftImage = null;
            this.bunifuButton2.onHoverState.IconRightImage = null;
            this.bunifuButton2.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.bunifuButton2.OnIdleState.BorderRadius = 1;
            this.bunifuButton2.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton2.OnIdleState.BorderThickness = 1;
            this.bunifuButton2.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.bunifuButton2.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton2.OnIdleState.IconLeftImage = null;
            this.bunifuButton2.OnIdleState.IconRightImage = null;
            this.bunifuButton2.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton2.OnPressedState.BorderRadius = 1;
            this.bunifuButton2.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton2.OnPressedState.BorderThickness = 1;
            this.bunifuButton2.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton2.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton2.OnPressedState.IconLeftImage = null;
            this.bunifuButton2.OnPressedState.IconRightImage = null;
            this.bunifuButton2.Size = new System.Drawing.Size(130, 26);
            this.bunifuButton2.TabIndex = 3;
            this.bunifuButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.bunifuButton2.TextMarginLeft = 0;
            this.bunifuButton2.TextPadding = new System.Windows.Forms.Padding(0);
            this.bunifuButton2.UseDefaultRadiusAndThickness = true;
            this.bunifuButton2.Click += new System.EventHandler(this.bunifuButton2_Click);
            // 
            // bunifuGroupBox1
            // 
            this.bunifuGroupBox1.BorderColor = System.Drawing.Color.LightGray;
            this.bunifuGroupBox1.BorderRadius = 1;
            this.bunifuGroupBox1.BorderThickness = 1;
            this.bunifuGroupBox1.Controls.Add(this.tabControl1);
            this.bunifuGroupBox1.Controls.Add(this.bunifuButton2);
            this.bunifuGroupBox1.Controls.Add(this.GeneralButton);
            this.bunifuGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuGroupBox1.LabelAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuGroupBox1.LabelIndent = 10;
            this.bunifuGroupBox1.LineStyle = Bunifu.UI.WinForms.BunifuGroupBox.LineStyles.Solid;
            this.bunifuGroupBox1.Location = new System.Drawing.Point(12, 2);
            this.bunifuGroupBox1.Name = "bunifuGroupBox1";
            this.bunifuGroupBox1.Size = new System.Drawing.Size(795, 363);
            this.bunifuGroupBox1.TabIndex = 4;
            this.bunifuGroupBox1.TabStop = false;
            // 
            // KeyCompoSpecsReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(816, 410);
            this.Controls.Add(this.bunifuGroupBox1);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.Name = "KeyCompoSpecsReader";
            this.Text = "Key Component Spaces Reader";
            this.Load += new System.EventHandler(this.KeyCompoSpecsReader_Load);
            this.tabControl1.ResumeLayout(false);
            this.GeneralPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DBGridGeneral)).EndInit();
            this.SpecificParameterPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DBGridSpecific)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workLocationBindingSource)).EndInit();
            this.bunifuGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPages tabControl1;
        private System.Windows.Forms.TabPage GeneralPage;
        private System.Windows.Forms.TabPage SpecificParameterPage;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSave;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton GeneralButton;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton2;
        private Bunifu.UI.WinForms.BunifuDataGridView DBGridSpecific;
        //private IndustryOSCoralLiteDataSet industryOSCoralLiteDataSet;
        private System.Windows.Forms.BindingSource workLocationBindingSource;
        //private IndustryOSCoralLiteDataSetTableAdapters.WorkLocationTableAdapter workLocationTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private Bunifu.UI.WinForms.BunifuDataGridView DBGridGeneral;
        private Bunifu.UI.WinForms.BunifuGroupBox bunifuGroupBox1;
    }
}