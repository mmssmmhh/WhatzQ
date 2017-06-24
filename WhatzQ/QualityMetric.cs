namespace WhatzQ
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QualityMetric")]
    public partial class QualityMetric
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QualityMetric()
        {
            Applications = new HashSet<Application>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MetricNum { get; set; }

        public string Description { get; set; }

        public int? TypeofMetric { get; set; }

        [StringLength(50)]
        public string TypesofValue { get; set; }

        [StringLength(50)]
        public string TypeofQualifiration { get; set; }

        [StringLength(50)]
        public string RelationofMetric { get; set; }

        [StringLength(50)]
        public string RatedBased { get; set; }

        public int? Subject_Id { get; set; }

        public int? Factor_Id { get; set; }

        public int? Criteria_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Application> Applications { get; set; }

        public virtual Criterion Criterion { get; set; }

        public virtual Factor Factor { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
