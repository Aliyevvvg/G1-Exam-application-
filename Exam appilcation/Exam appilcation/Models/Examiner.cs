using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_appilcation.Models;

public class Examiner
{
    public long Id { get; set; }
    public long UserId { get; set; }
    [NotMapped]
    public User User { get; set; } 
}