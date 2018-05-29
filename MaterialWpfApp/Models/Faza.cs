namespace MaterialWpfApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Faza")]
    public partial class Faza
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faza()
        {
            NutritionalCategories = new HashSet<NutritionalCategory>();
        }

        [Key]
        public int Id_faza { get; set; }

        [Column("Faza")]
        [Required]
        [StringLength(20)]
        public string Faza1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NutritionalCategory> NutritionalCategories { get; set; }
    }
}
