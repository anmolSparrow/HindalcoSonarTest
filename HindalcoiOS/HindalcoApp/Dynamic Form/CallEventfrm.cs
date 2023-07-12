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

namespace HindalcoiOS.Dynamic_Form
{
    public partial class CallEventfrm : XtraForm
    {
        #region Update Value Event
        public delegate void SendValueEvents(params object[] objevt);
        public event SendValueEvents SendValueEvent;
        #endregion 
        public CallEventfrm()
        {
            InitializeComponent();           
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedItem.ToString();
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Select Cad Layout..":
                    this.Hide();
                    break;
            }
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            
            string textToSearch = comboBox1.Text.ToLower();
            listBox1.Visible = false; 
            if (String.IsNullOrEmpty(textToSearch))
                return;                         
            string[] arr = (new List<string>(GlobalDeclaration._MyTagDictinary.Values)).ToArray();
            string[] result = (from i in arr
                               where i.ToLower().Contains(textToSearch)
                               select i).ToArray();            
            if (result.Length == 0)
                return; 
            listBox1.Items.Clear(); 
            listBox1.Items.AddRange(result);
            listBox1.Visible = true; 
        }
        private void CallEventfrm_Load(object sender, EventArgs e)
        {
            SendValueEvent += CallEventfrm_SendValueEvent;
            if (this.comboBox1.Items.Count == 0)
            {
                foreach (var item in GlobalDeclaration._MyTagDictinary)
                {
                    string MachineTag = item.Value;
                    this.comboBox1.Items.Add(MachineTag);
                }
                this.comboBox1.Items.Add("Select Cad Layout..");
            }
           // comboBox1.SelectedIndex = 0;
        }
        private void CallEventfrm_SendValueEvent(params object[] objevt)
        {
            throw new NotImplementedException();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = listBox1.SelectedItem;
            listBox1.Visible = false;
        }
        public void CallEventfrm_SomeEvent(params object[] args)
        {
            textBox1.Text = args[0].ToString();
            textBox2.Text = args[1].ToString();
            textBox3.Text = args[2].ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if(textBox1.Text=="")
            {
                label4.Text = "*";
                label4.BackColor = Color.Red;
                label4.Visible = false;
            }
        }
    }
}
