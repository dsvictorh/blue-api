using AutoMapper;
using BlueAPI.Data.Models;
using BlueAPI.DataTransferObjects;

namespace BlueAPI.Mappers
{
    public class ProductMapper : Profile
    {
        public ProductMapper() 
        {
            this.CreateMap<InsertUpdateProductDTO, Product>();
            this.CreateMap<Product, GetProductDTO>()
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(source => source.Status.Name));
        }
    }
}
