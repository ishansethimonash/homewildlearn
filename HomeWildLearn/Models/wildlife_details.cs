namespace HomeWildLearn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class wildlife_details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Animal_id { get; set; }

        [ForeignKey("Animal_id")]
        public virtual Animal Animal { get; set; }


        [Required]
        public string Fact_1 { get; set; }

        public string Fact_2 { get; set; }

        [Required]
        [StringLength(50)]
        public string Animal_Sound { get; set; }

        [Required]
        [StringLength(100)]
        public string Animal_Image_Main { get; set; }

        [StringLength(100)]
        public string Animal_Image_1 { get; set; }

        [StringLength(100)]
        public string Animal_Image_2 { get; set; }

        [StringLength(100)]
        public string Animal_Image_3 { get; set; }

        [StringLength(100)]
        public string Animal_Image_4 { get; set; }

        [StringLength(100)]
        public string Animal_Image_5 { get; set; }
    }
}
