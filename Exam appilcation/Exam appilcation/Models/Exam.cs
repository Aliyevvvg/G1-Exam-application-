namespace Exam_appilcation.Models;

public class Exam
{
    public long Id { get; set; }
    public string  ExamName { get; set; }
    public FileInfo File { get; set; } 
    public List<Student> Students { get; set; } = new List<Student>();
    public Examiner Examiner { get; set; }
    public DateTime StartDataTime { get; set; }
    public DateTime EndDateTime { get; set; }
}