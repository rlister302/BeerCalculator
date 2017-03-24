//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class BrewProcess
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public BrewProcess()
    {
        this.Grains = new HashSet<Grain>();
        this.Hops = new HashSet<Hop>();
        this.Yeasts = new HashSet<Yeast>();
    }

    public long BrewProcessID { get; set; }
    public Nullable<double> ActualABV { get; set; }
    public Nullable<double> ActualOG { get; set; }
    public Nullable<double> ActualFG { get; set; }
    public Nullable<int> ActualMashEfficiency { get; set; }
    public Nullable<int> RecipeID { get; set; }
    public Nullable<long> UserID { get; set; }

    public virtual Recipe Recipe { get; set; }
    public virtual User User { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Grain> Grains { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Hop> Hops { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Yeast> Yeasts { get; set; }
}
