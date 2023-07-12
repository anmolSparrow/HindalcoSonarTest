using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Audit_frm
{
    public partial class ExternalTracker : DevExpress.XtraEditors.XtraForm
    {
        public ExternalTracker()
        {
            InitializeComponent();
        }
        TrackerControl usercontrol = null;
        private void ExternalTracker_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
            usercontrol = new TrackerControl("External");
            this.Controls.Add(usercontrol);
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

        private void bntSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string code = usercontrol.cmbcode.Text;
                string namofau = usercontrol.cmbaudit.Text;
                string authername = usercontrol.cmbuditName.Text;
                string date = Convert.ToDateTime(usercontrol.dateTimePicker1.Text).ToString("yyyy-MM-dd");
                string value = code + "_" + authername + "_" + namofau + "_" + "External" + "_" + date;
                if (DgvStatus.Rows.Count > 0)
                {
                    DgvStatus.Rows.Clear();
                }
                DataTable Dt = Resources.Instance.GetDataKey("SP_GetAuditCategory", "@auditcode", "@auditorname", "@auditname", "@action", "@date", code, authername, namofau, "External", date);
                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DgvStatus.Rows.Add(dr);
                        int index = DgvStatus.Rows.Count - 1;
                        DgvStatus.Rows[index].Cells["Category"].Value = Dt.Rows[i]["Category"];
                        DgvStatus.Rows[index].Cells["Count"].Value = Dt.Rows[i]["Count"];
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}
