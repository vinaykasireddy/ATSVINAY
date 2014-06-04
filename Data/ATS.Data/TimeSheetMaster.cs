using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Data.DAL;

namespace ATS.Data.Model
{
    public partial class TimeSheetMaster
    {
        public static TimeSheetMaster GetById(int TimeSheetMasterId)
        {
            ATSCEEntities context = new ATSCEEntities();
            return context.TimeSheetMasters.Find(TimeSheetMasterId);
        }

        public static IEnumerable<TimeSheetMaster> GetAll()
        {
            ATSCEEntities context = new ATSCEEntities();
            return context.TimeSheetMasters;
        }

        public string Save()
        {
            string result = string.Empty;
            try
            {
                using (var context = new ATSCEEntities())
                {
                    if (this.TimeSheetMasterId <= 0)
                    {
                        context.TimeSheetMasters.Add(this);
                    }
                    else
                    {
                        context.Entry(this).State = System.Data.EntityState.Modified;
                    }
                    
                    context.SaveChanges();

                    foreach (TimeSheetDetail detail in this.TimeSheetDetail.ToList())
                    {
                        detail.Save();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Record is not saved");
            }

            return result;
        }

        public static bool Delete(int id)
        {
            try
            {
                ATSCEEntities context = new ATSCEEntities();
                TimeSheetMaster master = context.TimeSheetMasters.Find(id);
                context.TimeSheetMasters.Remove(master);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
