namespace WhatzQ
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Application")]
    public partial class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AppID { get; set; }

        public string QValue { get; set; }

        public string UsesValue { get; set; }

        public int SubjectID { get; set; }

        public int FNum { get; set; }

        public int CNum { get; set; }

        public int MNum { get; set; }

        public virtual Criterion Criterion { get; set; }

        public virtual Factor Factor { get; set; }

        public virtual QualityMetric QualityMetric { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
