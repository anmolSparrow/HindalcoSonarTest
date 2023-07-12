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

namespace HindalcoiOS.Safety_Form_list
{
    public partial class ListSOP : XtraForm
    {
        public ListSOP()
        {
            InitializeComponent();
        }

        private void ListSOP_Load(object sender, EventArgs e)
        {
            // Load  Employee Data for  Combox from DB  and Map in Combox
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
        }
        private void CallInvoke(object sender, EventArgs e)
        {
            string tag = ((Button)sender).Tag.ToString();
            switch (tag)
            {
                case "Attached":
                    break;
                case "Defination":
                    break;
                case "Save":
                    break;
            }
            this.Close();
        }
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
    }
}
