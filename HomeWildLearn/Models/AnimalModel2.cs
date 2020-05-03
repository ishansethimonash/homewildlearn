namespace HomeWildLearn.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AnimalModel2 : DbContext
    {
        public AnimalModel2()
            : base("name=AnimalModel2")
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<HomeWildLearn.Models.wildlife_locations> wildlife_locations { get; set; }

        public System.Data.Entity.DbSet<HomeWildLearn.Models.wildlife_details> wildlife_details { get; set; }
    }
}
