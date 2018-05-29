namespace MaterialWpfApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Korm")]
    public partial class Korm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Korm()
        {
            FNutritionalCharacteristics = new HashSet<FNutritionalCharacteristic>();
            Rations = new HashSet<Ration>();
            RationCows = new HashSet<RationCow>();
            Storages = new HashSet<Storage>();
            NNutritionalCharacteristics = new HashSet<NNutritionalCharacteristic>();
        }

        public int Korm_category { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_korm { get; set; }

        [Required]
        [StringLength(50)]
        public string Name_korm { get; set; }

        public decimal? Price_korm { get; set; }

        [StringLength(50)]
        public string Unit { get; set; }

        [StringLength(3)]
        public string Voluminousness { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FNutritionalCharacteristic> FNutritionalCharacteristics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ration> Rations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RationCow> RationCows { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Storage> Storages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NNutritionalCharacteristic> NNutritionalCharacteristics { get; set; }
    }
}
