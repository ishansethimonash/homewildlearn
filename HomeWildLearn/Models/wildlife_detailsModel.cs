namespace HomeWildLearn.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class wildlife_detailsModel : DbContext
    {
        public wildlife_detailsModel()
            : base("name=wildlife_detailsModel")
        {
        }

        public virtual DbSet<wildlife_details> wildlife_details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
