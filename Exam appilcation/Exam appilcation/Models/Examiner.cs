using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_appilcation.Models;

public class Examiner
{
    [Column("id")]
    public long Id { get; set; }
    [Column("user_id")]
    public long UserId { get; set; }
    [NotMapped]
    public virtual User User { get; set; }
    
    [Column("exam_id")]
    public long ExamId { get; set; }
    [NotMapped]
    public virtual Exam Exam { get; set; }
}