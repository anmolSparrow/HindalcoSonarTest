using CADImport;
using HindalcoiOS.Connector_FRM;
using SparrowRMS;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Class_Operation
{
    /// <summary>
    /// Represents a node on the TreeView List.
    /// </summary>
    public class NodeCreator
    {
        /// <summary>
        /// Represents the nodeId of the selected node.
        /// </summary>       
        #region Property Declaration
        public string NodeId { get; set; }
        public DataTable AuditDataTable { get; set; }
        public DataTable TaskDataTable { get; set; }
        public DataTable GetpermitCode { get; set; }
        public DataTable PermitIsolation { get; set; }
        public Dictionary<string, string> TagList { get; set; }
        public Dictionary<string, DPoint> _McordList { get; set; }
        public Dictionary<string, Connector> _listconnt { get; set; }
        public List<string> GlobalSerachList { get; set; }
        public TreeNodeCollection NodeCollection { get; set; }
        public ConcurrentDictionary<string, string> _MachinePathHold { get; set; }
        #endregion

        public readonly string[] FirstNames = { "Audit", "Connector", "Dashboard", "Machine Info", "Maintenence", "Operation", "Permit to Work","Task", "Training" };
        private const string IconType = "ClassType";
        private List<string>addRowData  = new List<string>();
       
       

        /// <summary>
        /// Generate Parent Node List into TreeView
        /// </summary>
        /// <returns> TreeNode Collection</returns>
        public TreeNode[] CreateParentNode(Dictionary<string, string> _TagList, Dictionary<string, DPoint> _McordList, Dictionary<string, Connector> _listconnt, DataTable PermitCodeList,DataTable PermitIsolation)
        {
            addRowData.Clear();
            List<TreeNode> branch = new List<TreeNode>();
            try
            {
                //string path = @"C:\Users\Public\Documents\HindalcoiOS\Urgent TestingDxf.xml";
                //string Pth = @"C:\Users\Public\Documents\HindalcoiOS\Urgent Testing~MTag.xml";                
                //Dictionary<DPoint, string> _Tag = GlobalDeclaration.LoadMachineTag(Pth);
                //var Diclist = GlobalDeclaration.GetDictionary(path);
                //ConcurrentDictionary<string, DPoint> _Mcord = Diclist.Item2;
              //  Dictionary<string, string> TagDic = Diclist.Item1;              
                for (int i = 0; i < FirstNames.Length; i++)
                {
                    int InconIndex = Iconmapping.GetIconIndex(NodeClass.ClassType, IconType);
                    TreeNode tNode = new TreeNode(FirstNames[i], InconIndex, InconIndex);
                    tNode.Tag = FirstNames[i];
                    branch.Add(tNode);
                }
                for (int i = 0; i < branch.Count; i++)
                {
                    TreeNode _returnView = branch[i];
                    switch (_returnView.Tag)
                    {
                        case "Audit":
                            {
                                if(AuditDataTable.Rows.Count > 0)
                                {
                                    int InconIndex = Iconmapping.GetIconIndex(NodeClass.ObjectType, "FolderType");
                                    TreeNode InodeChild = new TreeNode("Internal", InconIndex, InconIndex);
                                    InodeChild.Tag = "Internal";
                                    TreeNode AuditCde = new TreeNode("Audit Code", InconIndex, InconIndex);
                                    AuditCde.Tag = "Audit Code";
                                    int InconIndexvalue = Iconmapping.GetIconIndex(NodeClass.ValueType, "Value");
                                    for (int j = 0; j < AuditDataTable.Rows.Count; j++)
                                    {
                                        string dd = AuditDataTable.Rows[j]["AuditCode"].ToString();
                                        if (!addRowData.Contains(dd))
                                            addRowData.Add(dd);
                                        TreeNode AuditNumber = new TreeNode(AuditDataTable.Rows[j]["AuditCode"].ToString(), InconIndex, InconIndex);
                                        AuditNumber.Tag = dd;
                                        AuditNumber.Nodes.Add(NodeClass.ValueType.ToString(), AuditDataTable.Rows[j]["NameofAudit"].ToString(), InconIndexvalue, InconIndexvalue);
                                        if (!addRowData.Contains(AuditDataTable.Rows[j]["NameofAudit"].ToString()))
                                            addRowData.Add(AuditDataTable.Rows[j]["NameofAudit"].ToString());
                                        AuditNumber.Nodes.Add(NodeClass.ValueType.ToString(), AuditDataTable.Rows[j]["TypeofAudit"].ToString(), InconIndexvalue, InconIndexvalue);
                                        if (!addRowData.Contains(AuditDataTable.Rows[j]["TypeofAudit"].ToString()))
                                            addRowData.Add(AuditDataTable.Rows[j]["TypeofAudit"].ToString());
                                        AuditNumber.Nodes.Add(NodeClass.ValueType.ToString(), AuditDataTable.Rows[j]["ProcessName"].ToString(), InconIndexvalue, InconIndexvalue);
                                        AuditNumber.Nodes.Add(NodeClass.ValueType.ToString(), AuditDataTable.Rows[j]["Area"].ToString(), InconIndexvalue, InconIndexvalue);
                                        AuditCde.Nodes.Add(AuditNumber);
                                    }
                                    InodeChild.Nodes.Add(AuditCde);
                                    _returnView.Nodes.Add(InodeChild);
                                }
                            }
                            break;
                        case "Connector":
                            {
                                foreach (KeyValuePair<string, Connector> item in _listconnt)
                                {
                                    string KeyKey = item.Key;
                                    Connector sourceMachines = _listconnt[KeyKey];
                                    int InconIndex = Iconmapping.GetIconIndex(NodeClass.ObjectType, "FolderType");
                                    TreeNode InodeChild = new TreeNode(KeyKey, InconIndex, InconIndex);
                                    int InconIndexvalue = Iconmapping.GetIconIndex(NodeClass.ValueType, "Value");
                                    InodeChild.Nodes.Add(NodeClass.ValueType.ToString(), sourceMachines.FromData, InconIndexvalue, InconIndexvalue);
                                    InodeChild.Nodes.Add(NodeClass.ValueType.ToString(), sourceMachines.Connecto, InconIndexvalue, InconIndexvalue);
                                    _returnView.Nodes.Add(InodeChild);
                                }
                            }
                            break;
                        case "Dashboard":
                            {

                            }
                            break;
                        case "Machine Info":
                            {
                                foreach(KeyValuePair<string, string> item in _TagList)
                                {
                                    int InconIndex = Iconmapping.GetIconIndex(NodeClass.ObjectType, "FolderType");
                                    TreeNode nodeChild = new TreeNode(item.Key, InconIndex, InconIndex);
                                    int InconIndexvalue = Iconmapping.GetIconIndex(NodeClass.ValueType, "Value");
                                    nodeChild.Nodes.Add(NodeClass.ValueType.ToString(), item.Value.ToString(), InconIndexvalue, InconIndexvalue);
                                    if (!addRowData.Contains(item.Value.ToString()))
                                        addRowData.Add(item.Value.ToString());
                                    if (_McordList.ContainsKey(item.Key))
                                    {
                                        DPoint dPoint = _McordList[item.Key];
                                        nodeChild.Nodes.Add(NodeClass.ValueType.ToString(), dPoint.X + " " + dPoint.Y, InconIndexvalue, InconIndexvalue);
                                        var Area = Resources.Instance.MachineDt.AsEnumerable().Where(X => X.Field<string>("Cadlocation") == "X" + dPoint.X + " " + "Y" + dPoint.Y).Select(X => X.Field<string>("MachineLocation")).Distinct().ToList();
                                        if (GlobalDeclaration._MyTagDictinary.ContainsKey(dPoint))
                                        {
                                            string Tag = GlobalDeclaration._MyTagDictinary[dPoint];
                                            nodeChild.Nodes.Add(NodeClass.ValueType.ToString(), Tag, InconIndexvalue, InconIndexvalue);
                                            if (!addRowData.Contains(Tag))
                                                addRowData.Add(Tag);
                                        }
                                        if (Area.Count > 0)
                                        {
                                            nodeChild.Nodes.Add(NodeClass.ValueType.ToString(), Area[0].ToString(), InconIndexvalue, InconIndexvalue);
                                            if (!addRowData.Contains(Area[0].ToString()))
                                                addRowData.Add(Area[0].ToString());
                                        }
                                    }
                                    _returnView.Nodes.Add(nodeChild);
                                }
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
                                int InconIndex = Iconmapping.GetIconIndex(NodeClass.ObjectType, "FolderType");
                                TreeNode PermitCde = new TreeNode("Permit Code", InconIndex, InconIndex);
                                int InconIndexvalue = Iconmapping.GetIconIndex(NodeClass.ValueType, "Value");
                                for (int j = 0; j < PermitCodeList.Rows.Count; j++)
                                {
                                    TreeNode AuditNumber = new TreeNode(PermitCodeList.Rows[j]["permitCode"].ToString(), InconIndex, InconIndex);
                                    PermitCde.Nodes.Add(AuditNumber);
                                    if (!addRowData.Contains(PermitCodeList.Rows[j]["permitCode"].ToString()))
                                        addRowData.Add(PermitCodeList.Rows[j]["permitCode"].ToString());
                                    TreeNode ChildNode = new TreeNode(PermitCodeList.Rows[j]["MachineTagNo"].ToString(), InconIndex, InconIndex);
                                    DataRow[] dr = PermitIsolation.AsEnumerable().Where(X => X.Field<string>("permitCode") == PermitCodeList.Rows[j]["permitCode"].ToString()).ToArray();
                                    for (int m = 0; m < dr.Length; m++)
                                    {
                                        TreeNode MachineNameIsolation = new TreeNode(dr[m]["equipName"].ToString(), InconIndex, InconIndex);
                                        if (!addRowData.Contains(dr[m]["equipName"].ToString()))
                                            addRowData.Add(dr[m]["equipName"].ToString());
                                        MachineNameIsolation.Nodes.Add(NodeClass.ValueType.ToString(), dr[m]["location"].ToString(), InconIndexvalue, InconIndexvalue);                                     
                                        MachineNameIsolation.Nodes.Add(NodeClass.ValueType.ToString(), dr[m]["connectorType"].ToString(), InconIndexvalue, InconIndexvalue);
                                        MachineNameIsolation.Nodes.Add(NodeClass.ValueType.ToString(), dr[m]["LockNo"].ToString(), InconIndexvalue, InconIndexvalue);
                                        MachineNameIsolation.Nodes.Add(NodeClass.ValueType.ToString(), dr[m]["personName"].ToString(), InconIndexvalue, InconIndexvalue);
                                        ChildNode.Nodes.Add(MachineNameIsolation);
                                    }
                                    AuditNumber.Nodes.Add(ChildNode);
                                    // AuditCde.Nodes.Add(NodeClass.ValueType.ToString(), "PTW-" + 1, InconIndexvalue, InconIndexvalue);
                                }
                                _returnView.Nodes.Add(PermitCde);
                            }
                            break;
                        case "Task":
                            {
                                int InconIndex = Iconmapping.GetIconIndex(NodeClass.ObjectType, "FolderType");
                                TreeNode InodeChild = new TreeNode("Task Code", InconIndex, InconIndex);
                                int InconIndexvalue = Iconmapping.GetIconIndex(NodeClass.ValueType, "Value");
                                for (int j = 0; j < TaskDataTable.Rows.Count; j++)
                                {
                                    TreeNode AuditNumber = new TreeNode(TaskDataTable.Rows[j]["taskCode"].ToString(), InconIndex, InconIndex);
                                    if (!addRowData.Contains(TaskDataTable.Rows[j]["taskCode"].ToString()))
                                        addRowData.Add(TaskDataTable.Rows[j]["taskCode"].ToString());
                                    AuditNumber.Nodes.Add(NodeClass.ValueType.ToString(), TaskDataTable.Rows[j]["taskType"].ToString(), InconIndexvalue, InconIndexvalue);
                                    AuditNumber.Nodes.Add(NodeClass.ValueType.ToString(), TaskDataTable.Rows[j]["taskDescription"].ToString(), InconIndexvalue, InconIndexvalue);
                                    AuditNumber.Nodes.Add(NodeClass.ValueType.ToString(), TaskDataTable.Rows[j]["actionName"].ToString(), InconIndexvalue, InconIndexvalue);
                                    AuditNumber.Nodes.Add(NodeClass.ValueType.ToString(), TaskDataTable.Rows[j]["AssignedTo"].ToString(), InconIndexvalue, InconIndexvalue);
                                    AuditNumber.Nodes.Add(NodeClass.ValueType.ToString(), TaskDataTable.Rows[j]["AssignedBy"].ToString(), InconIndexvalue, InconIndexvalue);
                                    AuditNumber.Nodes.Add(NodeClass.ValueType.ToString(), TaskDataTable.Rows[j]["taskCategory"].ToString(), InconIndexvalue, InconIndexvalue);
                                    AuditNumber.Nodes.Add(NodeClass.ValueType.ToString(), TaskDataTable.Rows[j]["SeekPartner"].ToString(), InconIndexvalue, InconIndexvalue);
                                    InodeChild.Nodes.Add(AuditNumber);
                                }
                                _returnView.Nodes.Add(InodeChild);
                            }
                            break;
                        case "Training":
                            {

                            }
                            break;
                        default:
                            {

                            }
                            break;
                    }
                }

                GlobalSerachList = addRowData;
            }
            catch (Exception Ex)
            {
                throw;
            }
            return branch.ToArray();
        }
        /// <summary>
        /// Gets the properties of the node from  Node List.
        /// </summary>
        /// <returns>List of string[2] arrays containing the attributes and values of the properties.</returns>
        public List<string[]> GetProperties(TreeNodeCollection NodeId)
        {
            return ReadNodeProperties(NodeId);
        }
        /// <summary>
        /// Reads an node and returns its properties.
        /// </summary>
        /// <param name="selectedNodeId">ID of the node which is to be read.</param>
        /// <returns>List of string[2] arrays containing the attributes and values of the properties.</returns>
        protected internal List<string[]> ReadNodeProperties(TreeNodeCollection selectedNodeId)
        {
            List<string[]> baseNodeProperties = new List<string[]>();
            try
            {
                if (selectedNodeId.Count > 0)
                {
                    if (selectedNodeId[0].Parent.Parent.Parent != null && selectedNodeId[0].Parent.Parent.Parent.Parent != null)
                    {
                        if (selectedNodeId[0].Parent.Parent.Parent.Parent.Text == "Permit Code")
                        {


                            var objid = new string[] { "Machine Location", "" };
                            var objClass = new string[] { "Connector Type", "" };
                            var objname = new string[] { "Lock No", "" };
                            var objarea = new string[] { "Person Name", "" };
                            baseNodeProperties.Add(objid);
                            baseNodeProperties.Add(objClass);
                            baseNodeProperties.Add(objname);
                            baseNodeProperties.Add(objarea);
                            for (int i = 0; i < selectedNodeId.Count; i++)
                            {
                                string[] ff = baseNodeProperties[i];
                                ff[1] = selectedNodeId[i].Text;
                                baseNodeProperties[i] = ff;
                            }
                        }
                    }

                    switch (selectedNodeId[0].Parent.Parent.Text)
                    {
                        case "Machine Info":
                            {
                                var objid = new string[] { "Machine Number", "" };
                                var objClass = new string[] { "Machine Co-ordinates", "" };
                                var objname = new string[] { "Machine Tag", "" };
                                var objarea = new string[] { "Machine Area", "" };
                                baseNodeProperties.Add(objid);
                                baseNodeProperties.Add(objClass);
                                baseNodeProperties.Add(objname);
                                baseNodeProperties.Add(objarea);
                                for (int i = 0; i < selectedNodeId.Count; i++)
                                {
                                    string[] ff = baseNodeProperties[i];
                                    ff[1] = selectedNodeId[i].Text;
                                    baseNodeProperties[i] = ff;
                                }
                            }
                            break;
                        case "Audit Code":
                            {
                                var objid = new string[] { "Name Of Audit", "" };
                                var objClass = new string[] { "Type Of Audit", "" };
                                var objname = new string[] { "Process Name", "" };
                                var objarea = new string[] { "Audit Area", "" };
                                baseNodeProperties.Add(objid);
                                baseNodeProperties.Add(objClass);
                                baseNodeProperties.Add(objname);
                                baseNodeProperties.Add(objarea);
                                for (int i = 0; i < selectedNodeId.Count; i++)
                                {
                                    string[] ff = baseNodeProperties[i];
                                    ff[1] = selectedNodeId[i].Text;
                                    baseNodeProperties[i] = ff;
                                }
                            }
                            break;
                        case "Connector":
                            {
                                var objid = new string[] { "From Connection", "" };
                                var objClass = new string[] { "ToConnection", "" };
                                baseNodeProperties.Add(objid);
                                baseNodeProperties.Add(objClass);
                                for (int i = 0; i < selectedNodeId.Count; i++)
                                {
                                    string[] ff = baseNodeProperties[i];
                                    ff[1] = selectedNodeId[i].Text;
                                    baseNodeProperties[i] = ff;
                                }
                            }
                            break;
                        case "Task Code":
                            {
                                var objid = new string[] { "Task Type", "" };
                                var objClass = new string[] { "Task Details", "" };
                                var objname = new string[] { "Action Process", "" };
                                var objarea = new string[] { "Assigned To", "" };
                                var objAssignby = new string[] { "Assigned By", "" };
                                var objtaskcategory = new string[] { "Task Category", "" };
                                var objseekpartner = new string[] { "Seek Partner", "" };
                                baseNodeProperties.Add(objid);
                                baseNodeProperties.Add(objClass);
                                baseNodeProperties.Add(objname);
                                baseNodeProperties.Add(objarea);
                                baseNodeProperties.Add(objAssignby);
                                baseNodeProperties.Add(objtaskcategory);
                                baseNodeProperties.Add(objseekpartner);
                                for (int i = 0; i < selectedNodeId.Count; i++)
                                {
                                    string[] ff = baseNodeProperties[i];
                                    ff[1] = selectedNodeId[i].Text;
                                    baseNodeProperties[i] = ff;
                                }
                            }
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            return baseNodeProperties;
        }
        public void ClearBackColor(TreeNode tr)
        {
            TreeNodeCollection nodes = tr.Nodes;
            foreach (TreeNode n in nodes)
            {
                ClearRecursive(n);
            }
        }
        // called by ClearBackColor function  
        public void ClearRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                tn.BackColor = Color.White;
                ClearRecursive(tn);
            }
        }
    }
}
