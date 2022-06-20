using UniNote.Domain.Entities;

namespace UniNote.Domain.Common.Interfaces;

public interface IWithCreatedByUser
{
    int? CreatedByUserId { get; set; }
    User? CreatedByUser { get; set; }
}