//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grain
    {
        public int GrainID { get; set; }
        public int GrainTypeID { get; set; }
        public int RecipeID { get; set; }
        public decimal Amount { get; set; }
    
        public virtual GrainType GrainType { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
