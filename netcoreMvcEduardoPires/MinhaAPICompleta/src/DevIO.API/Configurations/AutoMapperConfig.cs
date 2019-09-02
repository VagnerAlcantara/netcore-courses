using AppMvcBasica.Models;
using AutoMapper;
using DevIO.API.ViewModels;

namespace DevIO.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>();

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(destino => destino.NomeFornecedor, opt => opt.MapFrom(x => x.Fornecedor.Nome));
        }
    }
}
