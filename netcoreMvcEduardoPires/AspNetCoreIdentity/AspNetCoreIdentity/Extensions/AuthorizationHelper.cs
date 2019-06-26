using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Extensions
{
    public class PermissaoNecessaria : IAuthorizationRequirement
    {
        public string Permissao { get; }

        public PermissaoNecessaria(string permissao)
        {
            Permissao = permissao;
        }
    }
    public class PermissaoNecessariaHandler : AuthorizationHandler<PermissaoNecessaria>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissaoNecessaria requirement)
        {
            throw new NotImplementedException();
        }
    }
}
