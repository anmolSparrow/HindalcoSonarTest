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
using SparrowRMS;
using DevExpress.XtraGrid.Views.Grid;
using HindalcoiOS.Class_Operation;

namespace HindalcoiOS
{
    public partial class ListAllTask : DevExpress.XtraEditors.XtraForm
    {
        public ListAllTask()
        {
            InitializeComponent();
        }

        #region "Variable Declaration"
        DataTable taskList = null;
        DataTable BindDataTBL = null;
        public EventHandler<DataTable> _UpdateDT;
        public EventHandler<Guid> TaskNotification1;
      //  public EventHandler<Guid> _TaskAccepted;

        #endregion
        private void ListAllTask_Load(object sender, EventArgs e)
        {
            try
            {
                DGVGridview.Columns.Clear();
                taskList = new DataTable();
                taskList = Resources.Instance.GetUserTaskAllCategory(GlobalDeclaration._holdInfo[0].EmpCode, 3);
                DgvViewTaskList.DataSource = BindColumn();
                DGVGridview.InitNewRow += DGVGridview_InitNewRow;
                FillSummaryData();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void NotificationHandler1(object sender, Guid value)
        {
            try
            {
                ReloadUpdatedTask();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReloadUpdatedTask()
        {
            try
            {
                taskList = new DataTable();
                taskList = Resources.Instance.GetUserTaskAllCategory(GlobalDeclaration._holdInfo[0].EmpCode, 3);
                DgvViewTaskList.DataSource = BindColumn();
                DGVGridview.InitNewRow += DGVGridview_InitNewRow;
                FillSummaryData();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FillSummaryData()
        {
            try
            {
                if (taskList.Rows.Count > 0)
                {
                    for (int i = 0; i < taskList.Rows.Count; i++)
                    {
                        DataRow nDR = BindDataTBL.NewRow();
                        nDR["Task Name"] = taskList.Rows[i]["Task Name"].ToString();
                        nDR["Frequency"] = taskList.Rows[i]["Frequency"].ToString();
                        nDR["Priority"] = taskList.Rows[i]["Priority"].ToString();
                        nDR["Action"] = taskList.Rows[i]["Action"].ToString();
                        nDR["Description"] = taskList.Rows[i]["Description"].ToString();
                        nDR["Status"] = taskList.Rows[i]["Status"].ToString();
                        nDR["Task_Id"] = Guid.Parse(taskList.Rows[i]["Task_Id"].ToString());
                        nDR["User Category"] = taskList.Rows[i]["User Category"].ToString();
                        nDR["TransactionId"] = taskList.Rows[i]["TransactionId"].ToString();
                        // DgvViewTaskList.
                        BindDataTBL.Rows.Add(nDR);
                        //DGVGridview.AddNewRow();
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable BindColumn()
        {
            BindDataTBL = new DataTable("TaskDetails");
            try
            {
                BindDataTBL.Columns.Add("Task Name", typeof(string));
                BindDataTBL.Columns.Add("Frequency", typeof(string));
                BindDataTBL.Columns.Add("Priority", typeof(string));
                BindDataTBL.Columns.Add("Action", typeof(string));
                BindDataTBL.Columns.Add("Description", typeof(string));
                BindDataTBL.Columns.Add("Status", typeof(string));
                BindDataTBL.Columns.Add("Task_Id", typeof(Guid));
                BindDataTBL.Columns.Add("User Category", typeof(string));
                BindDataTBL.Columns.Add("TransactionId", typeof(Guid));
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return BindDataTBL;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void DgvViewTaskList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable TaskNotify = new DataTable();
                int[] selectedRows = DGVGridview .GetSelectedRows();
                Guid cellValue = Guid.NewGuid();
                foreach (int rowHandle in selectedRows)
                {
                      cellValue=Guid.Parse( DGVGridview.GetRowCellValue(rowHandle, "Task_Id").ToString());
                }
                //   Guid TaskId =new Guid(DgvViewTaskList.Rows[e.RowIndex].Cells["Task_Id"].Value.ToString());
                //Guid tid=Guid.Parse(DgvViewTaskList.)
                TaskNotify = Resources.Instance.GetTaskActionMaster(cellValue, 1);
                if (TaskNotify.Rows[0]["Task_Status"].ToString() == "Tagged")
                {
                  //  Safety_Task.TaggedFrm tgdFrm = new TaggedFrm(TaskNotify);
                 //   tgdFrm._UpdateDT += LoadDataTBL;
                //    tgdFrm.ShowDialog();
                }
             //   Safety_Task.Forms.Frm_TaskView Tview = new Safety_Task.Forms.Frm_TaskView(TaskNotify);
             //   Tview.Show();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvViewTaskList_Click(object sender, EventArgs e)
        {

        }
        private void DGVGridview_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
               GridView view = sender as GridView;
                for (int i = 0; i <= taskList.Rows.Count; i++)
                {
                    view.SetRowCellValue(e.RowHandle, "Task Name", taskList.Rows[i]["Task Name"].ToString());
                    view.SetRowCellValue(e.RowHandle, "Frequency", taskList.Rows[i]["Frequency"].ToString());
                    view.SetRowCellValue(e.RowHandle, "Priority", taskList.Rows[i]["Priority"].ToString());
                    view.SetRowCellValue(e.RowHandle, "Action", taskList.Rows[i]["Action"].ToString());
                    view.SetRowCellValue(e.RowHandle, "Description", taskList.Rows[i]["Description"].ToString());
                    view.SetRowCellValue(e.RowHandle, "Status", taskList.Rows[i]["Status"].ToString());
                    view.SetRowCellValue(e.RowHandle, "Task_Id", taskList.Rows[i]["Task_Id"].ToString());
                    view.SetRowCellValue(e.RowHandle, "User Category", taskList.Rows[i]["User Category"].ToString());
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvViewTaskList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int[] selectedRowHandles = DGVGridview.GetSelectedRows();
                if (selectedRowHandles.Length > 0)
                {
                    DGVGridview.FocusedRowHandle = selectedRowHandles[0];
                    DataRowView selRow = (DataRowView)(((GridView)DgvViewTaskList.MainView).GetRow(selectedRowHandles[0]));
                    //  oHCReport.SINO = int.Parse(selRow["S.No."].ToString());
                    Guid Transactionid = Guid.Parse(selRow["Task_Id"].ToString());
                    DataTable TaskNotify = new DataTable();
                    TaskNotify = Resources.Instance.GetTaskActionMaster(Transactionid, 1);
                    string[] empTagArr = new string[] { };
                    empTagArr = TaskNotify.Rows[0]["EmpCode"].ToString().Split(',');
                    if (TaskNotify.Rows[0]["Task_Status"].ToString() == "Tagged" && empTagArr[1].Equals(GlobalDeclaration._holdInfo[0].EmpCode))
                    {
                        //Safety_Task.NewDesign.TagApprovalForm tgdFrm = new NewDesign.TagApprovalForm(TaskNotify);
                        //tgdFrm._UpdateDT += LoadDataTBL;
                        //tgdFrm.ShowDialog();
                    }
                    //Safety_Task.NewDesign.TakeOverFrm Tview = new Safety_Task.NewDesign.TakeOverFrm(TaskNotify);
                    //Tview._TaskNotifyDT += NotificationHandler;
                    //Tview._UpdateDT += LoadDataTBL;
                    //Tview.Show();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void NotificationHandler(object sender, Guid value)
        {
            try
            {
                OpenPopUP();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OpenPopUP()
        {
            try
            {
               toastNotificationsManager1.ShowNotification("2966d717-2d6e-42c7-984c-7e9697bf0314");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataTBL(object sender, DataTable value)
        {
            try
            {
                DataTable taskList = new DataTable();
                taskList = Resources.Instance.GetUserTaskAllCategory(GlobalDeclaration._holdInfo[0].EmpCode, 3);
                DgvViewTaskList.DataSource = taskList;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}