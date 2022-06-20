using Microsoft.AspNetCore.Http;
using UniNote.Application.Modules.AuthorizedContext.Common;
using UniNote.Data.Common;

namespace UniNote.Application.Modules.AuthorizedContext;

public class AuthorizedContext : IAuthorizedContext
{
    private readonly HttpContext _httpContext;

    public AuthorizedContext(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext.HttpContext;
    }
    
    private int? _userId;

    public virtual int UserId => _userId ??=
        int.Parse(_httpContext.User.Identity?.Name ??
                  throw new Exception("Name claim should be presented in JWT!"));
}