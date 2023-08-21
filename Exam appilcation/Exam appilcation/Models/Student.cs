using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_appilcation.Models;

public class Student
{
    [Column("id")]
    public long Id { get; set; }
    [Column("full_name")]
    public string FullName { get; set; }
    [Column("telegram_chat_id")]
    public long Telgram_Chat_Id { get; set; }
    [Column("status")]
    public Enums.StudentStatus Status { get; set; }
    [Column("user_id")]
    public long UserId { get; set; }
    [NotMapped]
    public  virtual User User_ { get; set; }

    [Column("exam_id")]
    public long Exam_id { get; set; }
    [NotMapped]
    public virtual Exam Exam { get; set; }
}