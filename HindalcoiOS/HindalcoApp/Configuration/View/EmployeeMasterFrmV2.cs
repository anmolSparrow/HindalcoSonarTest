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
using HindalcoiOS.Login_Form;
using HindalcoiOS;

namespace HindalcoiOS.Configuration
{
    public partial class EmployeeMasterFrm : DevExpress.XtraEditors.XtraForm
    {
        #region "Variable declaration"
        List<Department_Master> departmodel = null;
        List<Employment_Type> empltypemodel = null;
        List<GeoTeam_Master> geolocatmodel = null;
        List<EmployeeDetail> employeeModel = null;

        DataTable dtsEmp = null;
        #endregion
        public EmployeeMasterFrm()
        {
            InitializeComponent();
        }

        private void btnFinder_Click(object sender, EventArgs e)
        {
            HindalcoiOS.Form_Collection.Frm_GlobalEmloyeeHierarchy Femps = new HindalcoiOS.Form_Collection.Frm_GlobalEmloyeeHierarchy();
            Femps.Show();
        }


        private void EmployeeMasterFrm_Load(object sender, EventArgs e)
        {
            try
            {
                //departmodel = Resources.Instance.GetDepartmentDetails(1);
                ////List<string> deptEmp = new List<string>();
                ////deptEmp = Resources.Instance.GetDepartmentWiseEmployee(DepartmentID);
                ////for (int i = 0; i < departmodel.Count; i++)
                //{
                //    cmbDepartment.Items.Add(departmodel[i].Dept_Name);
                //}
                dtsEmp = Resources.Instance.GetEmployeeMasterData();
                DgvMasterView.DataSource = dtsEmp;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //int deptIndex = cmbDepartment.SelectedIndex;
        //        //int deptId = departmodel[deptIndex].DeptId;
        //        //List<string> deptEmp = new List<string>();
        //        //deptEmp = Resources.Instance.GetDepartmentWiseEmployee(deptId);
        //        //for (int i = 0; i < deptEmp.Count; i++)
        //        //{
        //        //    cmbEmployee.Items.Add(deptEmp[i]);
        //        //}
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}

        //private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // int deptIndex = cmbDepartment.SelectedIndex;
        //        // int deptId = departmodel[deptIndex].DeptId;
        //        // List<EmployeeDetailMaster> empDet = new List<EmployeeDetailMaster>();
        //        // empDet = Resources.Instance.GetEmployeeDatafromName(deptId, cmbEmployee.Text);
        //        // if (empDet.Count > 0)
        //        // {
        //        //     lblEmpType.Text = empDet[0].emailId;
        //        //     lblGeoLocation.Text = empDet[0].GeoTeamName;
        //        //     lblDeptHead.Text = empDet[0].emp_name;
        //        // }
        //        //// lblDeptHead.Text=
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}

        private void btnUserMaster_Click(object sender, EventArgs e)
        {
            if (GlobalDeclaration._holdInfo[0].UserRole.Equals("Admin"))
            {
                frmRegistration frms = new frmRegistration();
                frms.Show();
            }
            else
            {
                XtraMessageBox.Show(new Form { TopMost = true }, "Not allowed", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void DgvMasterView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    GlobalDeclaration.isEmpMaster = true;
                    GlobalDeclaration.isEpmCode = DgvMasterView.Rows[e.RowIndex].Cells[3].Value.ToString();
                    HindalcoiOS.Form_Collection.Frm_GlobalEmloyeeHierarchy fms = new HindalcoiOS.Form_Collection.Frm_GlobalEmloyeeHierarchy();
                    fms.Show();
                }
                else if (e.ColumnIndex == 1)
                {

                }

            }
            catch (Exception Ex)
            {

            }
        }

       
    }
}