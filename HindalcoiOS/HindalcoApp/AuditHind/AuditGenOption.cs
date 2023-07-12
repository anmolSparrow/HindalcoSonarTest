using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.AuditHind
{
    public partial class AuditGenOption : XtraForm
    {
        public event SomeEvents GetValue;
        public AuditGenOption()
        {
            InitializeComponent();
        }
        List<string> QuarterList = new List<string>();
        private void btnGenPlan_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(cmbAuditType.Text))
            {
                MessageBox.Show("Please select AuditType");
                cmbAuditType.Focus();
                return;
            }
          else  if (string.IsNullOrEmpty(cmbYear.Text))
            {
                MessageBox.Show("Please select Financial Year");
                cmbYear.Focus();
                return;
            }
           else if (string.IsNullOrEmpty(cmbQuater.Text))
            {
                MessageBox.Show("Please select Financial Quarter");
                cmbQuater.Focus();
                return;
            }
          else  if (string.IsNullOrEmpty(cmbOunit.Text))
            {
                MessageBox.Show("Please select Operation Unit");
                cmbOunit.Focus();
                return;
            }
            if (GetValue != null)
            {
                GetValue.Invoke(cmbAuditType.Text,cmbYear.Text,cmbQuater.Text,cmbOunit.Text);
                DialogResult = DialogResult.OK;
            }

        }
        private void PopulateQtr()
        {
           
            if (cmbAuditType.SelectedItem.ToString()=="L1")
            {
                QuarterList.Clear();
                QuarterList.Add("Q1");
                //QuarterList.Add("Q3");
                
            }
            if (cmbAuditType.SelectedItem.ToString() == "L2")
            {
                QuarterList.Clear();
                QuarterList.Add("Q2");
                //QuarterList.Add("Q3");
            }

            
            cmbQuater.DataSource = null;//.Clear();
            cmbQuater.DataSource = QuarterList;
            cmbQuater.Text = string.Empty;
        }
        //public void FinancialYearGenerator(SparrowRMSControl.SparrowControl.SparrowComboBox cmbYr)
        //{
        //    int val1 = 20;
        //    int val2 = 21;
            
        //    int startYear = 2020;
        //    int currYear = 0;
        //    if (DateTime.Today.Month != 1 && DateTime.Today.Month != 2 && DateTime.Today.Month != 3)
        //    {
        //        currYear = DateTime.Today.AddYears(1).Year;
        //    }
        //    else
        //    {
        //        currYear = DateTime.Today.Year;
        //    }
        //    int yearDiff = currYear - startYear;
        //    for(int i=1;i<=yearDiff;i++)
        //    {
        //       string str = string.Format("{0}-{1}", val1.ToString(), val2.ToString());
        //        cmbYr.Items.Add(str);
        //        val1 = val2;
        //        val2 += 1;
        //    }

        //}

        private void cmbAuditType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateQtr();
        }

        private void AuditGenOption_Load(object sender, EventArgs e)
        {
            foreach (var item in GlobalDeclaration.FinancialYears)
            {
                cmbYear.Items.Add(item);
           }
        }
    }
}
