namespace HomeWildLearn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class wildlife_locations
    {
        public int Animal_id { get; set; }
        // Added Animal class to retrieve animal name
        public virtual Animal Animal { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }

        [Key]
        public int Location_id { get; set; }
    }
}