using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Safety_Form_list
{
    public partial class SafetyChecklist : XtraForm
    {
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int iColumnIndex);
        private string SysGenNo = string.Empty;
        private bool _IsNewEntry;
        private bool bIsComboBox;
        public SafetyChecklist()
        {
            InitializeComponent();
        }
        public SafetyChecklist(string sysgeno)
        {
            this.SysGenNo = sysgeno;
            InitializeComponent();
        }
        private void btnload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _opfl = new OpenFileDialog();
                _opfl.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.BMP)| *.jpg; *.jpeg; *.png; *.gif | bmp files(*.bmp) | *.bmp; ";
                if (_opfl.ShowDialog() != DialogResult.Cancel)
                {
                    //FileInfo file = new FileInfo(_opfl.FileName);
                    // var sizeInBytes = file.Length;
                    // Image myImg = new Image.FromFile("");
                    // int  imageHeight = myImg.Height;
                    // int imageWidth = myImg.Width;
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image = null;
                    }
                    loadImage(_opfl.FileName);
                    //if (imageHeight == 32 && imageWidth == 32)
                    //{
                    //    pictureBox1.Image = img;
                    //    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show("Image Size should no be Exceed" + 32 * 32 + "Pixel" + "\n" + "Please Try Again", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}


                }
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        byte[] ImageSize;

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

        private void Bindcolumn()
        {
            try
            {
                DataTable dt = Resources.Instance.CreateCommand();
                if (dt.Rows.Count > 0)
                {
                    // GlobalDeclaration.Splitclm(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString());
                    GlobalDeclaration.Splitclm(dt.Rows[2][0].ToString(), dt.Rows[2][1].ToString());
                }

                if (DgvSafetychklist.Columns.Count > 0) return;
                DataGridViewComboBoxColumn colCombo = new DataGridViewComboBoxColumn();
                colCombo.HeaderText = "Deviation";
                colCombo.Name = "cmbdeviation";
                colCombo.Items.Add("Yes");
                colCombo.Items.Add("No");
                DataGridViewComboBoxColumn frqncy = new DataGridViewComboBoxColumn();
                frqncy.HeaderText = "Freequency";
                frqncy.Name = "cmbfrequncy";
                frqncy.Items.Add("Day");
                frqncy.Items.Add("Month");
                frqncy.Items.Add("Quaterllay");
                frqncy.Items.Add("Half-Year");
                frqncy.Items.Add("Year");
                DataGridViewImageColumn imagebtn = new DataGridViewImageColumn();
                imagebtn.HeaderText = "LoadImage";
                imagebtn.Name = "btnImage";
                //imagebtn.Text = "Pic";
                DgvSafetychklist.DataSource = GlobalDeclaration.MapColumnSafetChkList;
                DgvSafetychklist.Columns.Add(colCombo);
                DgvSafetychklist.Columns.Add(frqncy);
                DgvSafetychklist.Columns.Add(imagebtn);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void loadImage(string path)
        {
            try
            {

                if (pictureBox1.Image != null) pictureBox1.Dispose();
                pictureBox1.Image = Image.FromFile(path);
                MemoryStream ms1 = new MemoryStream();
                pictureBox1.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                ImageSize = new byte[ms1.Length];
                if (ms1.Length > 35600)
                {
                    pictureBox1.Image = null;
                    XtraMessageBox.Show("Please upload less than 25 kb image");
                }
                else
                {

                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    btnUpdateList.Enabled = true;
                }
                //using (var srce = new Bitmap(path))
                //{
                //    var dest = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                //    using (var gr = Graphics.FromImage(dest))
                //    {
                //        gr.DrawImage(srce, new Rectangle(Point.Empty, dest.Size));
                //    }

                //    if (pictureBox1.Image != null) pictureBox1.Dispose();
                //    pictureBox1.Image = dest;

                //    pictureBox1.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                //    if (ms1.Length > 25600)
                //    {
                //        XtraMessageBox.Show("Please upload less than 25 kb image");
                //        pictureBox1.Image = null;
                //    }
                //    else
                //    {
                //        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //        btnUpdateList.Enabled = true;
                //    }
                //}
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ReceiveCount = 0;
        private void ReadData()
        {
            try
            {
                DataTable dt = null;
                if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety"))
                {
                    dt = Resources.Instance.GetDataKey("Sp_fetchSafetyData1", "p_machineCor", this.SysGenNo);
                }
                else
                {
                    dt = Resources.Instance.GetDataKey("Sp_fetchSafetyData", "p_machineCor", this.SysGenNo, "p_empCode", GlobalDeclaration._holdInfo[0].EmpCode);
                }
                if (dt.Rows.Count > 0)
                {
                    // ReceiveCount = dt.Rows.Count;
                    //  Bindcolumn();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["SrNo"] == null || dt.Rows[i]["Aspect"] == null || dt.Rows[i]["QueryElmt"] == null || dt.Rows[i]["Responce"] == null || dt.Rows[i]["AreaOwner"] == null) continue;
                        DataGridViewRow dr = new DataGridViewRow();
                        DgvSafetychklist.Rows.Add(dr);
                        int index = DgvSafetychklist.Rows.Count - 1;
                        DgvSafetychklist.Rows[i].Cells["SrNo"].Value = dt.Rows[i]["SrNo"].ToString();
                        DgvSafetychklist.Rows[i].Cells["Aspect"].Value = dt.Rows[i]["Aspect"].ToString();
                        DgvSafetychklist.Rows[i].Cells["QueryElement"].Value = dt.Rows[i]["QueryElmt"].ToString();
                        DgvSafetychklist.Rows[i].Cells["Responce"].Value = dt.Rows[i]["Responce"].ToString();
                        DgvSafetychklist.Rows[i].Cells["AreaOwner"].Value = dt.Rows[i]["Areaowner"].ToString();
                        DgvSafetychklist.Rows[i].Cells["cmbdeviation"].Value = dt.Rows[i]["Deviation"].ToString();
                        DgvSafetychklist.Rows[i].Cells["cmbfrequncy"].Value = dt.Rows[i]["Freeqncy"].ToString();
                        DgvSafetychklist.Rows[i].Cells["btnImage"].Value = GetImage((byte[])dt.Rows[i]["Image"]);
                        DgvSafetychklist.Rows[i].Cells["Status"].Value = dt.Rows[i]["Status"];

                    }
                    // btnUpdateList.Visible = false;                    
                }
                else
                {
                    //Bindcolumn();
                }
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Image GetImage(byte[] bytearr)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytearr);
            Image i = Image.FromStream(ms);
            return i;
        }
        private void txtAspect_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void SafetyChecklist_Load(object sender, EventArgs e)
        {
            // btnUpdateList.Enabled = false;   
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
            ReadData();
        }
        private void DgvSafetychklist_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                if (e.ColumnIndex == this.DgvSafetychklist.Columns["cmbdeviation"].Index)
                {
                    this.DgvSafetychklist.BeginInvoke(objChangeCellType, e.RowIndex, "Devition", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvSafetychklist.Columns["cmbfrequncy"].Index)
                {
                    this.DgvSafetychklist.BeginInvoke(objChangeCellType, e.RowIndex, "freequency", e.ColumnIndex);
                    bIsComboBox = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ChangeCellToComboBox(int iRowIndex, string ColumnName, int iColumnIndex)
        {
            try
            {
                if (bIsComboBox == false)
                {
                    if (ColumnName == "Devition")
                    {
                        if (DgvSafetychklist.Rows[iRowIndex].Cells[DgvSafetychklist.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell DgvArea = new DataGridViewComboBoxCell();
                        DgvArea.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DataTable RiskDt = new DataTable();
                        RiskDt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "Yes", "No" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = RiskDt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            RiskDt.Rows.Add(dr);
                        }
                        DgvArea.DataSource = RiskDt;
                        DgvArea.ValueMember = "Name";
                        DgvArea.DisplayMember = "Name";
                        DgvSafetychklist.Rows[iRowIndex].Cells[DgvSafetychklist.CurrentCell.ColumnIndex] = DgvArea;
                        bIsComboBox = true;

                    }
                    else if (ColumnName == "freequency")
                    {
                        if (DgvSafetychklist.Rows[iRowIndex].Cells[DgvSafetychklist.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell DGVcmbMachineTag = new DataGridViewComboBoxCell();
                        DGVcmbMachineTag.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DataTable RiskDt = new DataTable();
                        RiskDt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "High", "Low", "Mediam", "Very-High", "Critical" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = RiskDt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            RiskDt.Rows.Add(dr);
                        }
                        DGVcmbMachineTag.DataSource = RiskDt;
                        DGVcmbMachineTag.ValueMember = "Name";
                        DGVcmbMachineTag.DisplayMember = "Name";
                        DgvSafetychklist.Rows[iRowIndex].Cells[DgvSafetychklist.CurrentCell.ColumnIndex] = DGVcmbMachineTag;
                        bIsComboBox = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Saveentry(int i, MemoryStream ms1)
        {
            try
            {
                string valuedetails = this.SysGenNo + "_" + DgvSafetychklist.Rows[i].Cells["SrNo"].Value.ToString() + "_" + DgvSafetychklist.Rows[i].Cells["Aspect"].Value.ToString() + "_" + DgvSafetychklist.Rows[i].Cells["QueryElement"].Value.ToString() + "_"
                                   + DgvSafetychklist.Rows[i].Cells["Responce"].Value.ToString() + "_" + DgvSafetychklist.Rows[i].Cells["cmbdeviation"].Value.ToString() + "_"
                                 + DgvSafetychklist.Rows[i].Cells["AreaOwner"].Value.ToString() + "_" + DgvSafetychklist.Rows[i].Cells["cmbfrequncy"].Value.ToString()
                                 + "_" + GlobalDeclaration._holdInfo[0].EmpCode + "_" + "Saved";

                int value = Resources.Instance.InsertSafetyListDetails("Sp_insertSafetyChkList", valuedetails, SaveImage(DgvSafetychklist.Rows[i].Cells["btnImage"].Value));
                if (value > 0)
                {
                    XtraMessageBox.Show("Entry Save Successfully in DB.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Error in Entry?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ms1.Dispose();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveentryEx(DataGridViewRow dr, MemoryStream ms1)
        {
            try
            {
                string valuedetails = this.SysGenNo + "_" + dr.Cells["SrNo"].Value.ToString() + "_" + dr.Cells["Aspect"].Value.ToString() + "_" + dr.Cells["QueryElement"].Value.ToString() + "_"
                                   + dr.Cells["Responce"].Value.ToString() + "_" + dr.Cells["cmbdeviation"].Value.ToString() + "_"
                                 + dr.Cells["AreaOwner"].Value.ToString() + "_" + dr.Cells["cmbfrequncy"].Value.ToString()
                                 + "_" + GlobalDeclaration._holdInfo[0].EmpCode + "_" + "Saved";


                int value = Resources.Instance.InsertSafetyListDetails("Sp_insertSafetyChkList", valuedetails, SaveImage(dr.Cells["btnImage"].Value));
                if (value > 0)
                {
                    XtraMessageBox.Show("Entry Save Successfully in DB.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DgvSafetychklist.Rows[dr.Index].Cells["Status"].Value = "Saved";

                }
                else
                {
                    XtraMessageBox.Show("Error in Entry?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ms1.Dispose();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private byte[] SaveImage(object value)
        {
            Image image = (Image)value;
            byte[] imageData = null;
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imageData = ms.ToArray();
            }
            return imageData;
        }

        private void DgvSafetychklist_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void DgvSafetychklist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7 && e.RowIndex > -1)
                {
                    //if (DgvSafetychklist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) return;
                    //Image img = Properties.Resources.DeleteRule;
                    OpenFileDialog _opfl = new OpenFileDialog();
                    _opfl.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.BMP)| *.jpg; *.jpeg; *.png; *.gif | bmp files(*.bmp) | *.bmp; ";
                    if (_opfl.ShowDialog() != DialogResult.Cancel)
                    {
                        Image img = Image.FromFile(_opfl.FileName);
                        MemoryStream ms1 = new MemoryStream();
                        img.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] ImageSize = new byte[ms1.Length];
                        if (ms1.Length > 20600)
                        {
                            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please upload less than 25 kb image");
                        }
                        else
                        {
                            DgvSafetychklist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = img;
                        }
                    }
                }
                else
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image = null;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvSafetychklist_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex > -1)
            {
                if (DgvSafetychklist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    Image image = (Image)DgvSafetychklist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    pictureBox1.Image = image;
                }
            }
        }

        private void DgvSafetychklist_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = null;
            }

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvSafetychklist.Rows.Count > 0)
                {
                    MemoryStream ms1 = new MemoryStream();
                    //if (ReceiveCount > 0)
                    //{
                    //    int remaincout = DgvSafetychklist.Rows.Count - ReceiveCount;
                    //    for (int i = DgvSafetychklist.Rows.Count - 1; i >=remaincout; i--)
                    //    {
                    //        Saveentry(i, ms1);
                    //    }
                    //}
                    //else
                    //{
                    //    for (int i = 0; i < DgvSafetychklist.Rows.Count; i++)
                    //    {
                    //        Saveentry(i, ms1);
                    //    }
                    //}

                    foreach (DataGridViewRow rw in this.DgvSafetychklist.Rows)
                    {
                        for (int i = 0; i < rw.Cells.Count; i++)
                        {
                            if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                            {
                                XtraMessageBox.Show(new Form { TopMost = true }, "Please Fill All details of Safety Check List..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    var query = from DataGridViewRow row in DgvSafetychklist.Rows where row.Cells["Status"].Value.ToString().StartsWith("New") select row;



                    foreach (DataGridViewRow Data in query)
                    {

                        //Saveentry(1, ms1);
                        SaveentryEx(Data, ms1);
                    }





                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Tag.ToString() == "Add")
            {
                DataGridViewRow dr = new DataGridViewRow();
                DgvSafetychklist.Rows.Add(dr);
                ReceiveCount++;
                int GridIndex = DgvSafetychklist.Rows.Count - 1;
                DgvSafetychklist.Rows[GridIndex].Cells["SrNo"].Value = DgvSafetychklist.Rows.Count;
                DgvSafetychklist.Rows[GridIndex].Cells["Status"].Value = "New";
                DgvSafetychklist.Columns["SrNo"].ReadOnly = true;
            }
            else
            {
                try
                {
                    if (DgvSafetychklist.Rows.Count > 0)
                    {
                        if (DgvSafetychklist.SelectedRows.Count > 0)
                        {
                            // Delete row from DB
                            if (DgvSafetychklist.SelectedRows[0].Cells["Aspect"].Value != null)
                            {
                                string valued = DgvSafetychklist.SelectedRows[0].Cells["Aspect"].Value.ToString();
                                int rcv = Resources.Instance.RemoveEntry("Sp_deleteSafetyChkList", "p_srNo", DgvSafetychklist.SelectedRows[0].Cells["Aspect"].Value.ToString());
                            }
                            int index = DgvSafetychklist.SelectedRows[0].Index;
                            DgvSafetychklist.Rows.RemoveAt(index);
                            pictureBox1.Image = null;
                            ReceiveCount--;
                        }
                        else
                        {
                            XtraMessageBox.Show("Please Select Row First.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception Ex)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
