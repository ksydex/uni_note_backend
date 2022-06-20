using Microsoft.EntityFrameworkCore;
using SoftDeleteServices.Configuration;
using UniNote.Core.Common.Interfaces;

namespace UniNote.Data;

public class SoftDeleteConfiguration : SingleSoftDeleteConfiguration<IDeletable>
{
    public SoftDeleteConfiguration(DbContext context) : base(context)
    {
        GetSoftDeleteValue = e => e.IsDeleted;
        SetSoftDeleteValue = (e, v) => { e.IsDeleted = v; };
    }
}