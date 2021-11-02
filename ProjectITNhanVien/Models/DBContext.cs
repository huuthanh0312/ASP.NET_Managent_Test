using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ProjectITNhanVien.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Skills)
                .WithMany(e => e.Employees)
                .Map(m => m.ToTable("Employee_Skill").MapLeftKey("EmployeeID").MapRightKey("SkillID"));
        }
    }
}
