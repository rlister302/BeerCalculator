//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeerCalculator.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recipe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recipe()
        {
            this.Grains = new HashSet<Grain>();
            this.Hops = new HashSet<Hop>();
            this.Yeasts = new HashSet<Yeast>();
        }
    
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public decimal ExpectedABV { get; set; }
        public Nullable<decimal> ActualABV { get; set; }
        public decimal ExpectedOG { get; set; }
        public Nullable<decimal> ActualOG { get; set; }
        public decimal ExpectedFG { get; set; }
        public Nullable<decimal> ActualFG { get; set; }
        public int IBU { get; set; }
        public int ExpectedMashEfficiency { get; set; }
        public Nullable<int> ActualMashEfficiency { get; set; }
        public decimal BoilVolume { get; set; }
        public decimal FinalVolume { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grain> Grains { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hop> Hops { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yeast> Yeasts { get; set; }
    }
}