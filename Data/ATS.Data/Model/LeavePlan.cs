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
    
    public partial class LeavePlan
    {
        public int LeavePlanId { get; set; }
        public int PersonId { get; set; }
        public int LeaveCategoryId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public double Duration { get; set; }
        public Nullable<bool> Admitted { get; set; }
    
        public virtual LeaveCategory LeaveCategory { get; set; }
        public virtual Person Person { get; set; }
    }
}
