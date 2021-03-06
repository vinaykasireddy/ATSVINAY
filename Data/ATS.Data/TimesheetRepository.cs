﻿using ATS.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Data.DAL
{
    public class TimesheetRepository
    {
        public static CodeTable GetCodeTableById(int codeTableId)
        {
            return CodeTable.GetById(codeTableId);
        }

        public static IEnumerable<CodeTable> GetCodeTables()
        {
            return CodeTable.GetAll();
        }

        //--------------------------------------------------------------------------------
        public static LeavePlan GetLeavePlanById(int leavePlanId)
        {
            return LeavePlan.GetById(leavePlanId);
        }

        public static IEnumerable<LeavePlan> GetLeavePlans(int userId)
        {
            return LeavePlan.GetAll(userId);
        }

        public static IEnumerable<LeavePlan> GetLeavePlans()
        {
            return LeavePlan.GetAll();
        }

        public static IEnumerable<LeavePlan> GetLeavePlansForTeam(int userId)
        {
            return LeavePlan.GetAllLeavePlansForTeam(userId);
        }

        public static LeavePlan AddUpdateLeavePlan(LeavePlan leavePlan)
        {
            return LeavePlan.Save(leavePlan);
        }

        public static bool RemoveLeavePlan(int leavePlanId) 
        {
            return LeavePlan.Delete(leavePlanId);
        }

        public static IEnumerable<LeaveCategory> GetLeaveCategories()
        {
            return LeaveCategory.getAll();
        }

        public static IEnumerable<LeavePlan> GetAllPersonsBySupervisorId(int SupervisorId)
        {
            return LeavePlan.GetAllLeavePlansBySupervisorId(SupervisorId);
        }

        public static IEnumerable<LeavePlan> AdmitReject(int LeavePlanId, bool AdmitReject)
        {
            return LeavePlan.AdmitOrRejectLeaves(LeavePlanId, AdmitReject);
        }
        //--------------------------------------------------------------------------------

        public static Person GetPersonById(int PersonId)
        {
            return Person.GetById(PersonId);
        }

        public static IEnumerable<Person> GetAllPersons()
        {
            return Person.GetAll();
        }

        //----------------------------------------------------------------------------------

        public static TimeSheetDetail GetTimeSheetDetailById(int TimeSheetDetailId)
        {
            return TimeSheetDetail.GetById(TimeSheetDetailId);
        }

        public static IEnumerable<TimeSheetDetail> GetAllTimeSheetDetails()
        {
            return TimeSheetDetail.GetAll();
        }

        //----------------------------------------------------------------------------------

        public static TimeSheetMaster GetTimeSheetMasterById(int TimeSheetMasterId)
        {
            return TimeSheetMaster.GetById(TimeSheetMasterId);
        }

        public static IEnumerable<TimeSheetMaster> GetAllTimeSheetMasters()
        {
            return TimeSheetMaster.GetAll();
        }

        //----------------------------------------------------------------------------------

        public static IEnumerable<Person> GetAllSupervisors()
        {
            return Supervisor.GetAll();
        }

        public static IEnumerable<Company> GetAllCompanies()
        {
            return Company.GetAll();
        }

        public static TimeSheetMaster CreateTimeSheetMasterTemplate(DateTime forCalendarMonth, Staff staff)
        {
            TimeSheetMaster master = new TimeSheetMaster();
            master.PersonId = staff.PersonId;
            master.Person = staff;
            master.Company = staff.Supervisor.Company;
            master.Supervisor = staff.Supervisor;
            master.AgencyId = staff.AgentId;
            master.Month = forCalendarMonth.Month;
            master.Year = forCalendarMonth.Year;
            
            List<TimeSheetDetail> listDetails = new List<TimeSheetDetail>();
            for (int i = 1; i <= DateTime.DaysInMonth(forCalendarMonth.Year, forCalendarMonth.Month); i++)
            {
                TimeSheetDetail detail = new TimeSheetDetail();
                detail.StartTime = new DateTime(forCalendarMonth.Year, forCalendarMonth.Month, i);
                detail.EndTime = new DateTime(forCalendarMonth.Year, forCalendarMonth.Month, i);
                listDetails.Add(detail);
            }
            master.TimeSheetDetail = listDetails;

            return master;
        }

    }
}
