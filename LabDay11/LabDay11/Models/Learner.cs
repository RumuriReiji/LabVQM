using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabDay11.Models
{
    [Table("Learner")]
    public class Learner
    {
        public int LearnerId { get; set; }

        public string FirstMidName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime EnrollmentDate { get; set; }

        public int MajorId { get; set; }

        public virtual Major? Major { get; set; }

        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}
