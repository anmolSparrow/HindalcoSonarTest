using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HindalcoiOS.Class_Operation;
using DevExpress.XtraEditors;
using SparrowRMS;

namespace HindalcoiOS.Form_Collection
{
    public partial class AddNewServiceConn : DevExpress.XtraEditors.XtraForm
    {
        public EventHandler<string> updateComboUnit;
        private DataTable paramlist;
        private string paramname;
        private string[] _list = new string[] { };
        string oldval = "";
        string newval = "";
        int paramId = 0;
        List<string> dataunit = new List<string>();

        public AddNewServiceConn()  //init constructor
        {
            InitializeComponent();
        }

        private void AddNewUnitFrm_Load(object sender, EventArgs e)
        {
            //this.txtcode1.Focus();
            lblcode.Visible = false;
            lblname.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Recultstring = string.Empty;
                bool valideted = true;
                if (txtcode.Text == "")
                {
                    lblcode.Visible = true;
                    lblname.Visible = false;
                    valideted = false;
                }
                if (txtname.Text == "")
                {
                    lblcode.Visible = false;
                    lblname.Visible = true;
                    valideted = false;
                }
                if (valideted)
                {
                    Resources.Instance.InsertMasterKeycom("SP_AddNewServiceConn", "@serviceCode", "@serviceName", this.txtcode.Text, txtname.Text, "@returnvalue", out Recultstring);
                    XtraMessageBox.Show(Recultstring, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Recultstring == "Same Connection Already Exist") return;

                    if (updateComboUnit != null)
                        updateComboUnit.Invoke(sender, txtname.Text + "_" + this.txtcode.Text);
                    txtname.Text = "";
                    this.txtcode.Text = "";
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar == '.' && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtcode.Text = "";
            txtname.Text = "";
        }


    }
}
