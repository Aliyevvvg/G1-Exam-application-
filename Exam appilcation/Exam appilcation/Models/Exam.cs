using System.ComponentModel.DataAnnotations.Schema;
using File = Telegram.Bot.Types.File;

namespace Exam_appilcation.Models;

public class Exam
{
    [Column("id")]
    public long Id { get; set; }
    [Column("exam_name")]
    public string  ExamName { get; set; }
    [Column("file")]
    public virtual File File { get; set; } 
    [Column("students")]
    public virtual List<Student> Students { get; set; } = new List<Student>();
    [Column("examiner")]
    public long Examiner_id { get; set; }
   [NotMapped]
    public virtual Examiner Examiner { get; set; }
    [Column("start_datatime")]
    public DateTime StartDataTime { get; set; }
    [Column("end_datatime")]
    public DateTime EndDateTime { get; set; }
}