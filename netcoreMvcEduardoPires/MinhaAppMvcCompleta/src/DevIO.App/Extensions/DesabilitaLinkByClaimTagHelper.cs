using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.App.Extensions
{
    [HtmlTargetElement("a", Attributes = "disable-by-claim-name")]
    [HtmlTargetElement("a", Attributes = "disable-by-claim-value")]
    public class DesabilitaLinkByClaimTagHelper : TagHelper
    {
        //Interface para recuperação de context de acesso em qualquer lugar da aplicação
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DesabilitaLinkByClaimTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HtmlAttributeName("disable-by-claim-name")]
        public string IdentityClaimName { get; set; }

        [HtmlAttributeName("disable-by-claim-value")]
        public string IdentityClaimValue { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            var temAcesso = CustomAuthorization.ValidarClaimsUsuario(_httpContextAccessor.HttpContext, IdentityClaimName, IdentityClaimValue);

            if (temAcesso) return;

            output.Attributes.RemoveAll("href");
            output.Attributes.Add(new TagHelperAttribute("style", "cursor: not-allowed"));
            output.Attributes.Add(new TagHelperAttribute("title", "Você não tem permissão"));
        }
    }
}
