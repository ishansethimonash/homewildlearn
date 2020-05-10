namespace HomeWildLearn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int animal_id { get; set; }

        [Required]
        [StringLength(50)]
        public string animal_name { get; set; }

        [StringLength(50)]
        public string animal_class { get; set; }

        public string animal_desc { get; set; }


        public string animal_explore_image { get; set; }
    }
}
