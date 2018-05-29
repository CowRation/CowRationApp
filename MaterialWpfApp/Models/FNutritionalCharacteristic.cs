namespace MaterialWpfApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FNutritionalCharacteristic
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_task { get; set; }

        public int Id_category { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_korm { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_index { get; set; }

        public double FValue { get; set; }

        public virtual CatalogIndexNutritional CatalogIndexNutritional { get; set; }

        public virtual Korm Korm { get; set; }

        public virtual NutritionalCategory NutritionalCategory { get; set; }

        public virtual Tasks Task { get; set; }
    }
}
