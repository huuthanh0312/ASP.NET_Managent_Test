namespace ProjectITNhanVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Username { get; set; }

        [StringLength(50)]
        [Required]
        public string Password { get; set; }
    }
}
