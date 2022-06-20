using System.ComponentModel.DataAnnotations.Schema;
using UniNote.Core.Common.AbstractClasses;
using UniNote.Core.Common.Interfaces;

namespace UniNote.Domain.Entities;

public class RefreshToken : EntityBaseWithDateCreated
{
    public string Token { get; set; }
    public DateTime DateExpiration { get; set; }

    [NotMapped] public bool IsValid => !IsInvalid && DateExpiration > DateTime.UtcNow;
        
    public bool IsInvalid { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
        
    public RefreshToken(string token)
    {
        Token = token;
    }
}