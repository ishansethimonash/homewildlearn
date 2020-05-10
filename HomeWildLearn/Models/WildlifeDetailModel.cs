namespace HomeWildLearn.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WildlifeDetailModel : DbContext
    {
        public WildlifeDetailModel()
            : base("name=WildlifeDetailModel")
        {
        }

        public virtual DbSet<wildlife_details> wildlife_details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
