namespace MaterialWpfApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RationCow")]
    public partial class RationCow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int MilkId { get; set; }

        public int KormId { get; set; }

        public double Value { get; set; }

        public virtual Korm Korm { get; set; }

        public virtual Milk Milk { get; set; }
    }
}
