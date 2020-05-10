namespace HomeWildLearn.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WildlifeLocationModel : DbContext
    {
        public WildlifeLocationModel()
            : base("name=WildlifeLocationModel")
        {
        }

        public virtual DbSet<wildlife_locations> wildlife_locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}