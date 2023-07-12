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

    public partial class AreaCreationView : XtraForm
    {
        public EventHandler<string> GetValue;
        public AreaCreation areaCreation { get; set; }
        public AreaCreationView()
        {
            InitializeComponent();
            areaCreation = new AreaCreation();
        }
        public void MapAreaToData()
        {
            areaCreation.Name = txtAreaName.Text;
            areaCreation.Code = txtAreaCode.Text;
            areaCreation.CreatedDate = DateTime.Today;
            areaCreation.SetAreaMasterData(areaCreation);
            ViewAllAreas();
        }
        public void ViewAllAreas()
        {
            dgvAllArea.DataSource = areaCreation.GetAllAreas();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MapAreaToData();
        }

        private void AreaCreationView_Load(object sender, EventArgs e)
        {
            ViewAllAreas();
        }
    }
    }

