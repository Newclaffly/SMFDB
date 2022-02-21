using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMFDB.Models
{
    public class MyApiContext : DbContext
    {
        public MyApiContext(DbContextOptions<MyApiContext> options) : base(options) { }
        public virtual DbSet<get_vw_sdt_project> get_vw_sdt_project { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<get_vw_sdt_project>().ToTable("get_vw_sdt_project");
        //    //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        //    //modelBuilder.Entity<Student>().ToTable("Student");
        //}

    }
}
