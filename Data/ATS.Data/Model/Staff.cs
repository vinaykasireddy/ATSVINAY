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
    
    public partial class Staff : Person
    {
        public Nullable<int> AgentId { get; set; }
        public Nullable<int> SupervisorId { get; set; }
    
        public virtual Agent Agent { get; set; }
        public virtual Supervisor Supervisor { get; set; }
    }
}