using DevExpress.XtraEditors;
using RMPCLApp.Class_Operation;
using SparrowRMS;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RMPCLApp.Login_Form
{
    public partial class frmManageUsers : DevExpress.XtraEditors.XtraForm
    {
        public string userName, Email;
        public string Role;
        public string isActive;
        public string islocked;
        public string temp;
        public string result;
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            try
            {
                dgvUserdata.SelectionChanged += new EventHandler(dgvUserdata_SelectionChanged);
                DataTable rolDf = Resources.Instance.GetDataKey("Sp_GetRoles");
                if (rolDf.Rows.Count > 0)
                {
                    cobRole.Items.Clear();
                    cobRole.DataSource = rolDf;
                    cobRole.DisplayMember = "RoleName";
                    cobRole.ValueMember = "RoleID";
                }
                RefreshDataGrid();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
            }
        }
        public void RefreshDataGrid()
        {
            dgvUserdata.DataSource = Resources.Instance.GetDataKey("SP_SearchViewUsers", "@Search", txtSearch.Text);
            dgvUserdata.Refresh();
        }
        private void dgvUserdata_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvUserdata.SelectedCells.Count > 0)
                {
                    temp = dgvUserdata.SelectedCells[0].Value.ToString();
                    Resources.Instance.spReadUsers(Convert.ToInt32(temp), ref userName, ref Email, ref Role, ref isActive, ref islocked);
                }
                txtUserName.Text = userName;
                txtEmail.Text = Email;
                cobRole.SelectedValue = Convert.ToInt32(Role);
                if (isActive == "1")
                {
                    chkIsActived.Checked = true;
                    chkunlick.Checked = false;
                    chkunlick.Visible = false;
                    lblunlock.Visible = false;
                }
                else
                {
                    chkIsActived.Checked = false;
                }
                if (islocked == "1")
                {
                    chkunlick.Checked = true;
                    chkunlick.Visible = true;
                    lblunlock.Visible = true;
                }
                else
                {
                    chkunlick.Checked = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkIsActived.Checked == true && chkunlick.Checked==false)
                {
                    Resources.Instance.spManageUsers(Convert.ToInt32(temp), Convert.ToInt32(cobRole.SelectedValue), true,false, ref result);
                    XtraMessageBox.Show(result, ApplicationConstants.MessageDisplay,
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information
                           );
                    chkunlick.Visible = false;
                    lblunlock.Visible = false;
                    RefreshDataGrid();
                }
                else
                {
                    Resources.Instance.spManageUsers(Convert.ToInt32(temp), Convert.ToInt32(cobRole.SelectedValue), false, true,ref result);
                    XtraMessageBox.Show(result, ApplicationConstants.MessageDisplay,
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information
                           );
                    RefreshDataGrid();

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error
                          );
            }
        }
    }
}
