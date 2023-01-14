using AutoMapper;
using PE.TabelaFipe.Domain.Models;
using PE.TabelaFipe.MVC.ViewModel;

namespace PE.TabelaFipe.Application.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MarcaViewModel, Marca>().ReverseMap();
            CreateMap<ModeloViewModel, Modelo>().ReverseMap();
            CreateMap<FipeViewModel, Fipe>().ReverseMap();
        }
    }
}
