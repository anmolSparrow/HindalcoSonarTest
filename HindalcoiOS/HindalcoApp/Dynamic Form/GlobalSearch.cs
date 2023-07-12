using CADImport;
using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.Connector_FRM;
using HindalcoiOS.Machine_Edit_Form;
using SparrowRMS;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Dynamic_Form
{
    public partial class GlobalSearch : XtraForm
    {
        
        bool nodefound = false;       
        /// <summary>
        /// ID of the node which is currently selected in the address space.
        /// </summary>
        public NodeCreator SelectedNode { get; set; }
        public GlobalSearch()
        {
            SelectedNode = new NodeCreator();
            InitializeComponent();
        }
        private void GlobalSearch_Load(object sender, EventArgs e)
        {
            Globaltree.BeginUpdate();
            Globaltree.Nodes.AddRange(SelectedNode.CreateParentNode(SelectedNode.TagList, SelectedNode._McordList, SelectedNode._listconnt, SelectedNode.GetpermitCode,SelectedNode.PermitIsolation));
            Globaltree.EndUpdate();
        }       
        private bool SearchRecursive(IEnumerable nodes, string searchFor)
        {
            foreach (TreeNode node in nodes)
            {
               // SelectedNode.ClearBackColor(node);
                if (node.Text.ToUpper().Contains(searchFor))
                {                   
                    Globaltree.SelectedNode = node;
                    node.BackColor = Color.Yellow;                 
                    return true;
                }
                if (SearchRecursive(node.Nodes, searchFor))
                    return true;
            }
            return false;
        }       
        private void PrintRecursive(TreeNode treeNode)
        {
            if (nodefound)
                return;
            if (treeNode.Text.ToUpper().Contains(textBox1.Text.ToUpper().ToString()))
            {
                Globaltree.SelectedNode = treeNode;
                Globaltree.SelectedNode.Expand();
                //treeNode.NodeFont= new Font(treeNode.NodeFont,FontStyle.Bold);
                treeNode.BackColor = Color.Yellow;
                Globaltree.Focus();
                nodefound = true;
                return;
            }
            foreach (TreeNode tn in treeNode.Nodes)
            {
                PrintRecursive(tn);
                if (nodefound)
                    return;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string textToSearch = textBox1.Text.ToLower();
            listBox1.Visible = false;
            if (String.IsNullOrEmpty(textToSearch))
                return;
            string[] arr = SelectedNode.GlobalSerachList.ToArray();
            string[] result = (from i in arr
                               where i.ToLower().Contains(textToSearch)
                               select i).ToArray();
            if (result.Length == 0)
                return;
            listBox1.Items.Clear();
            listBox1.Items.AddRange(result);
            listBox1.Visible = true;
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
            {
                Globaltree.BeginUpdate();
               
                foreach (TreeNode node in this.Globaltree.Nodes)
                {                    
                    switch (node.Text)
                    {
                        case "Audit":
                            {
                                foreach (TreeNode item in node.FirstNode.FirstNode.FirstNode.Nodes)
                                {
                                    
                                    if (item.Text.ToUpper().Contains(this.textBox1.Text.ToUpper()))
                                    {
                                        Globaltree.SelectedNode = item;
                                        Globaltree.SelectedNode.Expand();
                                        Globaltree.SelectedNode.ForeColor = Color.LimeGreen;

                                        Globaltree.Focus();
                                        break;
                                    }

                                }
                            }
                            break;
                        case "Connector":
                            {

                            }
                            break;
                        case "Dashboard":
                            {

                            }
                            break;
                        case "Machine Info":
                            {
                                foreach (TreeNode item in node.FirstNode.Nodes)
                                {                                    
                                    if (item.Text.ToUpper().Contains(this.textBox1.Text.ToUpper()))
                                    {
                                        Globaltree.SelectedNode = item;
                                        Globaltree.SelectedNode.Expand();
                                        Globaltree.SelectedNode.ForeColor = Color.LimeGreen;
                                        Globaltree.Focus();
                                        break;
                                    }
                                }
                            }
                            break;
                        case "Operation":
                            {

                            }
                            break;
                        case "Permit to Work":
                            {

                            }
                            break;
                        case "Task":
                            {

                            }
                            break;
                        case "Training":
                            {

                            }
                            break;
                    }
                    //if (node.FirstNode != null && node.FirstNode.FirstNode.FirstNode != null)
                    //{
                    //    foreach (TreeNode item in node.FirstNode.FirstNode.FirstNode.Nodes)
                    //    {
                    //        if (item.Text.ToUpper().Contains(this.textBox1.Text.ToUpper()))
                    //        {

                    //            Globaltree.SelectedNode = item;
                    //            Globaltree.SelectedNode.Expand();
                    //            Globaltree.SelectedNode.BackColor = Color.Yellow;
                    //            Globaltree.Focus();
                    //            break;

                    //        }
                           
                    //    }
                    //}                   

                }
                    Globaltree.EndUpdate();
                //var searchFor = textBox1.Text.Trim().ToUpper();
                //if (searchFor != "")
                //{
                //    if (Globaltree.Nodes.Count > 0)
                //    {
                //        nodefound = false;
                //        //TreeNodeCollection nodes = Globaltree.Nodes;
                //        //foreach (TreeNode n in nodes)
                //        //{
                //        //    if (!nodefound)
                //        //        PrintRecursive(n);
                //        //    else
                //        //        return;
                //        //}                        
                //        if (SearchRecursive(Globaltree.Nodes, searchFor))
                //        {
                //           // Globaltree.SelectedNode.Expand();
                //            Globaltree.Focus();
                //        }
                //    }
                //}
            }
        }
       
        private void Globaltree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                btnselectNode.Visible = false;
                var selectedNode = Globaltree.SelectedNode;
                if (selectedNode!= null)
                {
                    if (selectedNode.Parent!= null)
                    {
                        nodeViewTable.Rows.Clear();
                        var NodeCollection = selectedNode.Nodes;
                        List<string[]> nodeProperties=SelectedNode.GetProperties(NodeCollection);
                        foreach (string[] property in nodeProperties)
                        {
                            nodeViewTable.Rows.Add(property);
                        }
                        lblname.Text = selectedNode.Text;
                        SelectedNode.NodeCollection = NodeCollection;
                        if (nodeViewTable.Rows.Count > 0)
                            btnselectNode.Visible = true;
                    }
                    else
                    {
                        nodeViewTable.Rows.Clear();
                    }
                }                
            }
            catch(Exception Ex)
            {
                removeSelection();
            }
        }
        /// <summary>
        /// Removes the selection from the Address Space Treeview.
        /// </summary>
        private void removeSelection()
        {
            Globaltree.SelectedNode = null;
            SelectedNode.NodeId = null;            
        }

        private void btnselectNode_Click(object sender, EventArgs e)
        {
            if (nodeViewTable.Rows.Count == 0) return;
            if(SelectedNode.NodeCollection.Count>0)
            {
                string[] NodeId = SelectedNode.NodeCollection[0].FullPath.Split('\\');
                switch (NodeId[0])
                {                  
                    case "Connector":
                        {
                        }
                        break;
                    case "Dashboard":
                        {

                        }
                        break;
                    case "Machine Info":
                        {
                            string MachineName = NodeId[1];
                            string MachineType = string.Empty;
                            string MachinSubType = string.Empty;
                            if (SelectedNode._MachinePathHold.Count > 0)
                            {                                
                                string MachinePah = SelectedNode._MachinePathHold[MachineName];
                                DirectoryInfo info = new DirectoryInfo(MachinePah);
                                MachineType = info.Parent.Name;
                                MachinSubType = info.Parent.Parent.Name;
                            }
                            string SysGenNo = NodeId[2];
                            string Cordinates = SelectedNode.NodeCollection[0].NextNode.Text;
                            Cordinates = string.Concat("X", Cordinates.Split(' ')[0], " Y", Cordinates.Split(' ')[1]);
                             Machine_Edit_Data mcd = new Machine_Edit_Data(MachineName, SysGenNo, MachineName.Split('~')[0]);
                            mcd.cmblayer.Items.Add(MachinSubType);
                            mcd.cmblayer.SelectedIndex = 0;
                            mcd.MachineSybType = MachinSubType;
                            mcd.MachinType = MachineType;
                            mcd.cmblayer.Enabled = false;                            
                            mcd._listconnt = SelectedNode._listconnt;
                            mcd.cmblocation.Items.Add(Cordinates);
                            mcd.cmblocation.SelectedIndex = 0;
                            mcd.cmblocation.Enabled = false;
                            mcd._dropMachineList = SelectedNode.TagList;
                            mcd.TopMost = false;                            
                            mcd.Show();
                        }
                        break;
                    case "Maintenence":
                        {

                        }
                        break;
                    case "Operation":
                        {

                        }
                        break;
                    case "Permit to Work":
                        {                          
                        }
                        break;
                    case "Task":
                        {
                            MessageBox.Show(NodeId[2]);
                        }
                        break;
                    case "Training":
                        {

                        }
                        break;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }
    }
}
