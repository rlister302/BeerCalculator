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
    
    public partial class Hop
    {
        public int HopID { get; set; }
        public Nullable<int> HopTypeID { get; set; }
        public Nullable<int> RecipeID { get; set; }
        public Nullable<int> AlphaAcid { get; set; }
    
        public virtual HopType HopType { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}