using HomeworkTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeworkTracker.DAL {
    public class HomeworkContext : DbContext {

        public HomeworkContext() : base("name=HomeworkDB") {
            Database.SetInitializer<HomeworkContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Homework>().ToTable("homeworks");
        }

        public virtual DbSet<Homework> Homeworks { get; set; }
    }
}