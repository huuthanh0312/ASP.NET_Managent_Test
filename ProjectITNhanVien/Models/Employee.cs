namespace ProjectITNhanVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Skills = new HashSet<Skill>();
        }

        public long EmployeeID { get; set; }

        [Required]
        public long? BranchID { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [StringLength(50)]
        [Required]
        public string Address { get; set; }

        [Column(TypeName = "date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime? Joining_Date { get; set; }

        [StringLength(50)]
        [Required]
        public string Notes { get; set; }

        public virtual Branch Branch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
