//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ATS.Data.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TimeSheetDetail
    {
        public int TimeSheetDetailId { get; set; }
        public int TimeSheetMasterId { get; set; }
        public int CalendarYearId { get; set; }
        public Nullable<int> LeaveCategoryId { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public float Hour { get; set; }
        public string Remarks { get; set; }
        public string SupportDocument1 { get; set; }
        public string SupportDocument2 { get; set; }
        public string SupportDocument3 { get; set; }
    
        public virtual TimeSheetMaster TimeSheetMaster { get; set; }
    }
}
