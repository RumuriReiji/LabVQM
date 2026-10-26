using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabDay11.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã môn")]
        public int CourseId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tên môn học")]
        public string Title { get; set; } = string.Empty;

        [Range(1, 5)]
        [Display(Name = "Số tín chỉ")]
        public int Credits { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
