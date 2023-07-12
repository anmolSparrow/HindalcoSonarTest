using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;

namespace HindalcoiOS.TempLicencing
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        string getpassword;
        string regPath;
        public Form1(String passname, String path)
        {
            InitializeComponent();
            getpassword = passname;
            regPath = path;
        }

        public bool passwordEntry(String originalPass, String pass)
        {
            if (originalPass == pass)
            {
                RegistryKey regkey = Registry.CurrentUser;
                regkey = regkey.CreateSubKey(regPath); //path

                if (regkey != null)
                {
                    regkey.SetValue("Password", pass); //Value Name,Value Data
                }
                return true;
            }
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if password true then send true			
            bool value = passwordEntry(getpassword,textBox1.Text);
            if (value ==true)
            {
                XtraMessageBox.Show("Thank you for activation!","Activate",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Hide();
                this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.DialogResult = DialogResult.OK;
            }
            else
                XtraMessageBox.Show("Product Key is not valid! Please Enter a valid Product Key!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			//----------------------------------------------		
		
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
