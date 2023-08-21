using System.ComponentModel.DataAnnotations.Schema;
using Exam_appilcation.Models.Enums;

namespace Exam_appilcation.Models;

public class User
{
    [Column("id")]
    public long  Id { get; set; }
    [Column("phone_number")]
    public string  Phone_number { get; set; }
    [Column("password")]
    public string  Password { get; set; }
    [Column("telgram_chat_id")]
    public long  Telgram_Chat_Id { get; set; }
    [Column("status")]
    public UserStatus Status { get; set; }
[NotMapped]
    public virtual Student Student { get; set; }
    [NotMapped]
    public virtual Client Client { get; set; }
}