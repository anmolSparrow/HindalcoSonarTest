using DevExpress.XtraEditors;
using RMPCLApp.Class_Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMPCLApp.AuditHind
{
    public partial class AuditMgmtDetail : XtraForm
    {
        public AuditMgmtDetail()
        {
            InitializeComponent();
        }
        private void btnUaucPcBox_Click(object sender, EventArgs e)
        {
            string impath = browseImageFile();
            //if (string.IsNullOrEmpty(impath)) return;
            //UAUC.SnapImage = System.IO.File.ReadAllBytes(impath);
        }
        private void btnReOpen_Click(object sender, EventArgs e)
        {
            DialogResult drr = MessageBox.Show("Are you Sure ?", "Alert", MessageBoxButtons.YesNo);
            if (drr == DialogResult.Yes)
            {
                if (txtStatus.Text == "Submitted")
                {
                    txtStatus.Text = "Rejected";
                }
            }
        }
        public string browseImageFile()
        {
            string imgPath = string.Empty;
            try
            {
                OpenFileDialog opFileDialog = new OpenFileDialog();
                {
                    opFileDialog.InitialDirectory = @"C:\";
                    opFileDialog.Title = "Browse";
                    opFileDialog.CheckFileExists = true;
                    opFileDialog.CheckPathExists = true;
                    //DefaultExt = "txt",
                    opFileDialog.Filter = "Images(*.Jpeg;*.png;*.jpg;)|*.Jpeg;*.png;*.jpg;";
                    //FilterIndex = 2,
                    //RestoreDirectory = true,
                    opFileDialog.ReadOnlyChecked = false;
                    // ShowReadOnly = true
                }

                if (opFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //if (is_Redirected == true)
                    {
                        PictureBox imageControl = new PictureBox();
                        PcbxAuditMgmt.Image = new Bitmap(opFileDialog.FileName);
                        imgPath = opFileDialog.FileName;
                        PcbxAuditMgmt.SizeMode = PictureBoxSizeMode.StretchImage;

                    }
                    //else
                    //{
                    //    PcbxUauc.Image = new Bitmap(opFileDialog.FileName);
                    //    imgPath = openFileDialog1.FileName;
                    //}
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return imgPath;
        }
    }
}
