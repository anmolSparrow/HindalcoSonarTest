using SparrowRMS;
using System;
using System.Data;

namespace HindalcoiOS.DAL
{
    public class ServiceDAL
    {
        int retVal = 0;
        DataTable dt = null;
        public int AddIncidentReport(Models.IncidentReport IncReport, int mode)
        {
            retVal = Resources.Instance.AddIncidentReport_RMPCL(IncReport.ReportNo, IncReport.ReportDate, IncReport.ReportTime, IncReport.EmployeeType,
                IncReport.Shift, IncReport.IncidentType, IncReport.IncidentDate,IncReport.Hours,IncReport.Minuts,IncReport.IncidentTime, IncReport.IncidentLocation,
                IncReport.ExactLocation, IncReport.Description, IncReport.CorrectiveAction, IncReport.ObservedBy,IncReport.DocumentedBy,IncReport.ReportedBy, IncReport.PersonInjured, IncReport.DepartmentId,
                IncReport.PersonAge, IncReport.MachineTag, IncReport.IncidentImage, IncReport.IncidentStatus, IncReport.OperationUnit, IncReport.is_localSaved, IncReport.is_Assigned, IncReport.AssignedToGM, DateTime.Now, mode);
            return retVal;
        }

        public int AddNearMissUAUCRequestor(Models.NearMissUAUC nearMiss)
        {
            retVal = Resources.Instance.AddUAUCNearMissRequestor_RMPCL(nearMiss.ObservationNo, nearMiss.ObservationDate, nearMiss.OperationUnit, nearMiss.SpecificLocation,
                nearMiss.DocumentedBy, nearMiss.Area, nearMiss.MachineTag, nearMiss.Observation, nearMiss.NearMissStatus,
                nearMiss.DocumentStatus, nearMiss.ActOrCondition, nearMiss.ObservedBy, nearMiss.Recommendation, nearMiss.ImgPath,
                nearMiss.AssignedTo, nearMiss.Remarks, nearMiss.is_admin, nearMiss.is_GMCode, nearMiss.AssigneeImgPath, nearMiss.ObserverImgPath, nearMiss.AssignedDate, nearMiss.ObservationDate, nearMiss.Reqester_FinalApproval_RejectionDate, nearMiss.is_AdminClosed, nearMiss.RequestStage);
            return retVal;
        }

        public int UpdateUAUCNearMissData(Models.NearMissUAUC nearMiss, int mode)
        {
            retVal = Resources.Instance.UpdateUAUCNearMissData_RMPCL(nearMiss.ObservationNo, nearMiss.ObservationDate, nearMiss.OperationUnit, nearMiss.SpecificLocation,
                nearMiss.DocumentedBy, nearMiss.Area, nearMiss.MachineTag, nearMiss.Observation, nearMiss.NearMissStatus,
                nearMiss.DocumentStatus, nearMiss.ActOrCondition, nearMiss.ObservedBy, nearMiss.Recommendation, nearMiss.ImgPath,
                nearMiss.AssignedTo, nearMiss.Remarks, nearMiss.is_admin, nearMiss.is_GMCode, nearMiss.AssigneeImgPath, nearMiss.ObserverImgPath, nearMiss.AssignedDate, nearMiss.ObservationDate, nearMiss.Reqester_FinalApproval_RejectionDate, nearMiss.is_AdminClosed, nearMiss.RequestStage, mode);
            return retVal;
        }

       

        public int AddUnitMaster(Models.UnitMaster unitMaster, int mode)
        {
            retVal = Resources.Instance.AddUnitMaster_RMPCL(unitMaster.UnitName, mode);
            return retVal;
        }

        public int DropDailyProdTempData(DateTime DateFilledFrom, string PlantName)
        {
            retVal = Resources.Instance.DropDailyTempTbl_RMPCL(DateFilledFrom, PlantName);
            return retVal;
        }

        public int DropDailyGridProductionTempData(string ProdCode, string PlantName)
        {
            retVal = Resources.Instance.DropDailyGridTempTbl_RMPCL(ProdCode, PlantName);
            return retVal;
        }
        public int DropDailyProductionData(string DProdCode)
        {
            retVal = Resources.Instance.DropDailyProductionData_RMPCL(DProdCode);
            return retVal;
        }
        public int AddProductionCalendar(string MonthName, int CalendarYear, string WorkingDays,int IsFirstEntry)
        {
            retVal = Resources.Instance.AddProductionCalendar_RMPCL(MonthName,CalendarYear, WorkingDays, IsFirstEntry);
            return retVal;
        }
     

        public DataTable GetMonthlyProductionTarget_RMPCL(int NoWorkDays, string DaysWorked, string PlantName, decimal MonthlyTarget, decimal DailyTarget,

          decimal ClosingStock, string MonthlyTargetUnit, string DailyTargetUnit, string ClosingStockUnit, DateTime CreatedDate, string TargetCode, int RoleId, string CreatedBy, string TargetMonth, int TargetYear, string ProdCode, int mode)
        {
            dt = new DataTable();
            dt = Resources.Instance.GetMonthlyProductionTarget_RMPCL(NoWorkDays, DaysWorked, PlantName, MonthlyTarget, DailyTarget, ClosingStock, MonthlyTargetUnit, DailyTargetUnit, ClosingStockUnit, CreatedDate, TargetCode, RoleId, CreatedBy, TargetMonth, TargetYear, ProdCode, mode);
            return dt;
        }

        public int AddDailyConsumption(Models.DailyConsumption DailyConsumption, int mode)
        {
            retVal = Resources.Instance.AddDailyConsumption(DailyConsumption.DProdCode, DailyConsumption.DConsumCode, DailyConsumption.PlantName, DailyConsumption.ElectricityConsumed, DailyConsumption.ElectricityUnit, DailyConsumption.ElectricityRate, DailyConsumption.CoalConsumed, DailyConsumption.CoalUnit,
                DailyConsumption.CoalRate, DailyConsumption.TotalProduction, DailyConsumption.TotalUnit, DailyConsumption.PowerTrip, DailyConsumption.PowerTripUnit, DailyConsumption.MaintenanceTime, DailyConsumption.MaintenanceTimeUnit, DailyConsumption.TotalRunningTime, DailyConsumption.TotalRunningTimeUnit, DailyConsumption.CreatedDate, mode);
            return retVal;
        }

        public int UpdateProductionCalendar(string WorkingDays, int MonthId)
        {
            retVal = Resources.Instance.UpdateProductionCalendar_RMPCL( WorkingDays,  MonthId);
            return retVal;
        }

        public DataTable GetDailyConsumption(string DProdCode, int mode)
        {
            dt = new DataTable();
            dt = Resources.Instance.GetDailyConsumption_RMPCL(DProdCode, mode);
            return dt;
        }

        public DataTable GetDailyProductionTempTbl(string DProdCode, string PlantName, string ProdName, string ProdCode, decimal OpeningStock, decimal DailyTarget, decimal ActualProd,
            decimal ProdDispatched, decimal ClosingStock, string EmpCode, int RoleId, DateTime CreatedDate, DateTime DateFilledFor, DateTime UpdateDate, string ActualProdUnit, string PrdoDispatchedUnit, int mode)
        {
            dt = new DataTable();
            dt = Resources.Instance.GetDailyProductionTempTbl_RMPCL(DProdCode, PlantName, ProdName, ProdCode, OpeningStock, DailyTarget, ActualProd, ProdDispatched, ClosingStock, EmpCode, RoleId, CreatedDate, DateFilledFor, UpdateDate, ActualProdUnit, PrdoDispatchedUnit, mode);
            return dt;
        }

        public DataTable GetDailyProduction(string DProdCode)
        {
            dt = new DataTable();
            dt = Resources.Instance.GetDailyProductionDetails_RMPCL(DProdCode);
            return dt;
        }
        public DataTable GetProductionCalendar(string MonthName, int CalendarYear, string WorkingDays,int IsFirstEntry)
        {
            dt = new DataTable();
            dt = Resources.Instance.GetProductionCalendar_RMPCL(MonthName, CalendarYear, WorkingDays, IsFirstEntry);
            return dt;
        }
        public DataTable GetProductCode()
        {
            dt = new DataTable();
            dt = Resources.Instance.GetProductCode_RMPCL();
            return dt;
        }
        public DataTable GetDailyProductionLineData(string LineName, DateTime DateFor, int TargetMonth, int targetYear)
        {
            dt = new DataTable();
            dt = Resources.Instance.GetDailyProductionDataLineWise_RMPCL(LineName, DateFor, TargetMonth, targetYear);
            return dt;
        }

        public DataTable GetConsumptionMaster_RMPCL(string PlantName, DateTime DateFillfrom, DateTime DateFilledTo)
        {
            dt = new DataTable();
            dt = Resources.Instance.GetConsumptionDetails_RMPCL(PlantName, DateFillfrom, DateFilledTo);
            return dt;
        }

        public DataTable GetDailyProdConsumption_RMPCL(string PlantName, DateTime DateFilledFor)
        {
            dt = new DataTable();
            dt = Resources.Instance.GetDailyProdConsumption_RMPCL(PlantName, DateFilledFor);
            return dt;
        }

        public DataTable GetEmployeeTyp(int mode, string EmpType, int TypeId)
        {
            dt = new DataTable();
            dt = Resources.Instance.GetEmployeeType_RMPCL(mode, EmpType, TypeId);
            return dt;
        }

        public DataTable GetDailyProductProduced(DateTime dateTime)
        {
            dt = new DataTable();
            dt = Resources.Instance.GetDailyProductionData_RMPCL(dateTime);
            return dt;
        }


        public int EmployeeType(int mode, string EmpType, int TypeId)
        {
            retVal = Resources.Instance.AddEmployeeType_RMPCL(mode, EmpType, TypeId);
            return retVal;
        }

        public DataTable GetShiftData(string shiftName, DateTime entryDate, DateTime entryDate1, int mode, Guid IncId)
        {
            dt = new DataTable();
            dt = Resources.Instance.GetShiftData(shiftName, entryDate, entryDate1, mode, IncId);
            return dt;
        }
    }
}
