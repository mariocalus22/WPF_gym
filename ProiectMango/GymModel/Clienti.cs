namespace GymModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Clienti")]
    public partial class Clienti
    {
        [Key]
        public int ClientID { get; set; }

        [StringLength(10)]
        public string Nume { get; set; }

        [StringLength(10)]
        public string TipAbonament { get; set; }
    }
}
