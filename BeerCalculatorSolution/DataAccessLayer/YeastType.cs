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
    
    public partial class YeastType
    {
        public int YeastTypeID { get; set; }
        public string YeastName { get; set; }
        public Nullable<int> LowAttenuationRate { get; set; }
        public Nullable<int> HighAttentuationRate { get; set; }
        public Nullable<int> LowTemperatureRange { get; set; }
        public Nullable<int> HighTemperatureRange { get; set; }
        public string Description { get; set; }
    }
}
