namespace GymModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Antrenori")]
    public partial class Antrenori
    {
        [Key]
        public int AntrenorID { get; set; }

        [StringLength(10)]
        public string Prenume { get; set; }

        [StringLength(10)]
        public string Varsta { get; set; }
        public object Clienti { get; set; }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
