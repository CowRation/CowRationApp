namespace MaterialWpfApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NutritionalCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NutritionalCategory()
        {
            FNutritionalCharacteristics = new HashSet<FNutritionalCharacteristic>();
            NNutritionalCharacteristics = new HashSet<NNutritionalCharacteristic>();
        }

        [Key]
        public int Id_category { get; set; }

        public int Id_faza { get; set; }

        public int Weight { get; set; }

        public int? VolumeOfMilk { get; set; }

        public decimal? Fat_content { get; set; }

        public decimal? Protein { get; set; }

        public virtual Faza Faza { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FNutritionalCharacteristic> FNutritionalCharacteristics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NNutritionalCharacteristic> NNutritionalCharacteristics { get; set; }
    }
}
