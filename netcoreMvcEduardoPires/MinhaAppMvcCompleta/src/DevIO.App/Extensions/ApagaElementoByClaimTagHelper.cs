using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace DevIO.App.Extensions
{
    [HtmlTargetElement("*", Attributes = "supress-by-claim-name")]
    [HtmlTargetElement("*", Attributes = "supress-by-claim-value")]
    public class ApagaElementoByClaimTagHelper : TagHelper
    {
        //Interface para recuperação de context de acesso em qualquer lugar da aplicação
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApagaElementoByClaimTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HtmlAttributeName("supress-by-claim-name")]
        public string IdentityClaimName { get; set; }

        [HtmlAttributeName("supress-by-claim-value")]
        public string IdentityClaimValue { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            var temAcesso = CustomAuthorization.ValidarClaimsUsuario(_httpContextAccessor.HttpContext, IdentityClaimName, IdentityClaimValue);

            if (temAcesso) return;

            output.SuppressOutput();
        }
    }
}
