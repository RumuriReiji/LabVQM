using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabDay11.Models
{
    [Table("Major")]
    public class Major
    {
        [Key]
        public int MajorId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tên ngành")]
        public string MajorName { get; set; } = string.Empty;

        public ICollection<Learner>? Learners { get; set; }
    }
}
