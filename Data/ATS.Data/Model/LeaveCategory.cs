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
    
    public partial class LeaveCategory
    {
        public LeaveCategory()
        {
            this.LeavePlans = new HashSet<LeavePlan>();
        }
    
        public int LeaveCategoryId { get; set; }
        public string LeaveCategoryDesc { get; set; }
    
        public virtual ICollection<LeavePlan> LeavePlans { get; set; }
    }
}