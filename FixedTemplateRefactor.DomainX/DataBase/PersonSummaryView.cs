//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FixedTemplateRefactor.DomainX.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonSummaryView
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public Nullable<int> ActivitiesCount { get; set; }
        public Nullable<int> MealsCount { get; set; }
        public Nullable<int> HydrationCount { get; set; }
    }
}