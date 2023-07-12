using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;

namespace HindalcoiOS.Audit_frm
{
    public partial class TrackerControl : UserControl
    {
        string TrackerType = string.Empty;
        public TrackerControl()
        {
            InitializeComponent();
        }
        public TrackerControl(string CallingType)
        {
            TrackerType = CallingType;
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void TrackerControl_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
            cmbcode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbcode.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbaudit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbaudit.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbuditName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbuditName.AutoCompleteSource = AutoCompleteSource.ListItems;
            // cmbcode.Items.Add("GGGG");
            LoadTracketData();
            
        }

        private void LoadTracketData()
        {
            string uqwr = string.Empty;
            if (TrackerType=="Internal")
            {
                uqwr = "select Distinct AuditCode from InternAuditCalendarTBL";
            }
            else
            {
                uqwr = "select Distinct AuditCode from ExternalAuditCalenTBL";
            }
            DataTable dt = Resources.Instance.TrackerLoadquery(uqwr);
            if(dt.Rows.Count>0)
            {
                cmbcode.DataSource = dt;
                cmbcode.DisplayMember = "AuditCode";
                cmbcode.ValueMember = "AuditCode";
                cmbcode.SelectedIndex = 0;
            }

        }
        private void cmbcode_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string quey = string.Empty;
                string vlaue1 = cmbcode.SelectedValue.ToString();
                if (cmbcode.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    string vlaue = cmbcode.SelectedValue.ToString();
                    if (TrackerType == "Internal")
                    {
                        quey = "select Distinct NameofAudit from InternAuditCalendarTBL where AuditCode='" + vlaue + "'";
                    }
                    else
                    {
                        quey = "select Distinct NameofAudit from ExternalAuditCalenTBL where AuditCode='" + vlaue + "'";
                    }
                    DataTable dt = Resources.Instance.TrackerLoadquery(quey);
                    if (dt.Rows.Count > 0)
                    {
                        cmbaudit.DataSource = dt;
                        cmbaudit.DisplayMember = dt.Columns[0].ColumnName;
                        cmbaudit.ValueMember = dt.Columns[0].ColumnName;
                        cmbaudit.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {
                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }
            return list;
        }

        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }                  
        private void cmbaudit_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbaudit.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    string query = string.Empty;
                    string code = cmbcode.SelectedValue.ToString();
                    string name = cmbaudit.SelectedValue.ToString();
                    if (TrackerType == "Internal")
                    {
                        query = "select Distinct  Auditowner from InternAuditCalendarTBL where AuditCode='" + code + "' and NameofAudit='" + name + "' ";
                    }
                    else
                    {
                        query = "select Distinct  Auditowner from ExternalAuditCalenTBL where AuditCode='" + code + "' and NameofAudit='" + name + "' ";
                    }
                   
                    DataTable dt = Resources.Instance.TrackerLoadquery(query);
                    if (dt.Rows.Count > 0)
                    {
                        cmbuditName.DataSource = dt;
                        cmbuditName.DisplayMember = dt.Columns[0].ColumnName;
                        cmbuditName.ValueMember = dt.Columns[0].ColumnName;
                        cmbuditName.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbuditName_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
