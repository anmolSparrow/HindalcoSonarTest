using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Configuration
{
    public partial class OperationUnitView : XtraForm
    {
        public OperationUnit OperationUnit { get; set; }
        public OperationUnitView()
        {
            InitializeComponent();
            OperationUnit = new OperationUnit();
        }

        private void btnOunitSave_Click(object sender, EventArgs e)
        {
            MapOperationUnitToData();
        }
        public void MapOperationUnitToData()
        {
            OperationUnit.OperationUnitName = txtOUnitName.Text;
            OperationUnit.OperationUnitCode = txtOUnitCode.Text;
            OperationUnit.CreatedDate = DateTime.Today;
            OperationUnit.SetOperationUnitToData(OperationUnit);
            ViewAllOperationUnit();
        }
        public void ViewAllOperationUnit()
        {
            dgvOperationUnitView.DataSource = OperationUnit.GetAllOperationUnit();
        }



        private void OperationUnitView_Load(object sender, EventArgs e)
        {
            ViewAllOperationUnit();
        }

        
    }
}
