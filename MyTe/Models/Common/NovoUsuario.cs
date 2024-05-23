using Microsoft.AspNetCore.Identity;

namespace MyTe.Models.Common
{
    public class NovoUsuario
    {
        public bool Success { get; set; }
        public IEnumerable<IdentityError>? Errors { get; set; }
    }
}
