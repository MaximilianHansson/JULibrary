namespace RepositoryLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMINISTRATOR")]
    public partial class ADMINISTARTOR
    {
        [Key]
        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string passwordHash { get; set; }

        [StringLength(50)]
        public string salt { get; set; }

    }
}
