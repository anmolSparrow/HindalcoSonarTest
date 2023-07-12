using DevExpress.XtraEditors;
using RatingControls;
using HindalcoiOS.Class_Operation;
//using RatingControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Dynamic_Form
{
    public struct MapEmployeeRating
    {
        public Color _selectionclr;
        public int AddCount;
    }
    public partial class EmployeeRatingFrm : DevExpress.XtraEditors.XtraForm
    {

        // private System.ComponentModel.Container components = null;
        //private System.Windows.Forms.Label label1;

        private StarRatingControl m_starRatingControl = new StarRatingControl();
        public int NumberRating = 0;
        public Color _SetColor;

        public EmployeeRatingFrm(string EmpName)
        {
            InitializeComponent();
            m_starRatingControl.Top = 45;

            m_starRatingControl.Left = 75;
            Controls.Add(m_starRatingControl);
            m_starRatingControl.Click += M_starRatingControl_Click;
            this.Text = EmpName;
            UpdateTextPosition();
        }



        private void M_starRatingControl_Click(object sender, EventArgs e)
        {

            try
            {
                int str = ((RatingControls.StarRatingControl)sender).SelectedStar;
                Color rrr = ((RatingControls.StarRatingControl)sender).SelectedColor;
                NumberRating = str;
                _SetColor = rrr;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTextPosition()
        {
            try
            {
                Graphics g = this.CreateGraphics();
                Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
                Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
                String tmp = " ";
                Double tmpWidth = 0;
                while ((tmpWidth + widthOfASpace) < startingPoint)
                {
                    tmp += " ";
                    tmpWidth += widthOfASpace;
                }

                this.Text = tmp + this.Text.Trim();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EmployeeRatingFrm_Load(object sender, EventArgs e)
        {
            //string nnnn = "Rahnedra,Gola";
            //if(nnnn.Contains(","))
            //{

            //}
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}