using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_appilcation.Models;

public class Student
{
    public string FullName { get; set; }
    public long Telgram_Chat_Id { get; set; }
    public long Id { get; set; }
    public Enums.StudentStatus Status { get; set; }
    public long UserId { get; set; }
    [NotMapped]
    private User User_ { get; set; }
}