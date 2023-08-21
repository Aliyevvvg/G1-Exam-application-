using System.ComponentModel.DataAnnotations.Schema;
using Exam_appilcation.Models.Enums;


namespace Exam_appilcation.Models;

public class Client
{
    [Column("id")]
    public long Id { get; set; }
    [Column("user_id")]
    public long  UserId { get; set; }
    [NotMapped]
    public virtual User User { get; set; } 
    [Column("user_name")]
    public string  UserName { get; set; }
    [Column("nickname")]
    public string Nickname { get; set; }
    [Column("status")]
    public ClientStatus Status { get; set; }
    [Column("is_premium")]
    public bool IsPremium { get; set; }
}