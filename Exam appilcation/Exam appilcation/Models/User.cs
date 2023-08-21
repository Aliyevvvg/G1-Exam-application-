using Exam_appilcation.Models.Enums;

namespace Exam_appilcation.Models;

public class User
{
    public string  Id { get; set; }
    public string  Phone_number { get; set; }
    public string  Password { get; set; }
    public string  Telgram_Chat_Id { get; set; }
    public UserStatus Status { get; set; }
}