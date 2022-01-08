namespace GymModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Suplimente")]
    public partial class Suplimente
    {
        [Key]
        public int SplimenteID { get; set; }

        public int? NrBuc { get; set; }

        [StringLength(10)]
        public string ClientID { get; set; }
    }
}
