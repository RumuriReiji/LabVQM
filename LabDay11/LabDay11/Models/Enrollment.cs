using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabDay11.Models
{
    [Table("Enrollment")]
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        public int CourseId { get; set; }

        public int LearnerId { get; set; }

        [Display(Name = "Grade")]
        public float? Grade { get; set; }

        // Navigation properties
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        [ForeignKey("LearnerId")]
        public Learner? Learner { get; set; }
    }
}
