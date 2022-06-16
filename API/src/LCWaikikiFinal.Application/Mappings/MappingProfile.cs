using AutoMapper;
using LCWaikikiFinal.Application.Features.AuthenticationOperations;
using LCWaikikiFinal.Application.Features.BrandOperations.Queries;
using LCWaikikiFinal.Application.Features.CategoryOperations.Command;
using LCWaikikiFinal.Application.Features.CategoryOperations.Queries;
using LCWaikikiFinal.Application.Features.ColorOperations.Queries;
using LCWaikikiFinal.Application.Features.LifecyclesOperations.Queries;
using LCWaikikiFinal.Application.Features.OfferOperations.Command;
using LCWaikikiFinal.Application.Features.OfferOperations.Queries;
using LCWaikikiFinal.Application.Features.ProductOperations.Command;
using LCWaikikiFinal.Application.Features.ProductOperations.Queries;
using LCWaikikiFinal.Application.Features.SizeOperations.Queries;
using LCWaikikiFinal.Domain.Entities;

namespace LCWaikikiFinal.Application.Mappings
{
        public class MappingProfile : Profile
        {
                public MappingProfile()
                {

                        #region Categories

                        CreateMap<Category, GetCategoriesQueryResponse>();
                        CreateMap<Category, GetCategoryDetailQueryResponse>();

                        CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();

                        #endregion

                        #region Products

                        CreateMap<Product, GetProductsQueryResponse>()
                                         .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.AppUser.UserName))
                                         .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size.Name))
                                         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Lifecycle.Description))
                                         .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
                                         .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.Name));

                        CreateMap<Product, GetProductDetailQueryResponse>()
                                         .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.AppUser.UserName))
                                         .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size.Name))
                                         .ForMember(dest => dest.Pattern, opt => opt.MapFrom(src => src.ProductDetail.Pattern))
                                         .ForMember(dest => dest.Fabric, opt => opt.MapFrom(src => src.ProductDetail.Fabric))
                                         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Lifecycle.Description))
                                         .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.Name))
                                         .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name));

                        CreateMap<Product, GetProductsByCategoryQueryResponse>()
                                          .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.AppUser.UserName))
                                         .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size.Name))
                                         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Lifecycle.Description))
                                         .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
                                         .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.Name));

                        CreateMap<Product, GetProductsByUserQueryResponse>().ReverseMap();

                        CreateMap<Product, CreateProductCommandRequest>().ReverseMap();

                        #endregion

                        #region Users

                        CreateMap<AppUser, LoginCommandResponse>().ReverseMap();
                        CreateMap<AppUser, RegisterCommandRequest>().ReverseMap();
                        CreateMap<AppUser, GetUserDetailQueryResponse>().ReverseMap();

                        #endregion

                        #region Offers

                        CreateMap<Offer, GetOffersByUserQueryResponse>()
                                 .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

                        CreateMap<Offer, CreateOfferCommandRequest>().ReverseMap();

                        #endregion

                        #region Brand, Color, Size and ProductStatus

                        CreateMap<Brand, GetBrandsQueryResponse>();
                        CreateMap<Color, GetColorsQueryResponse>();
                        CreateMap<Lifecycle, GetLifecyclesQueryResponse>();
                        CreateMap<Size, GetSizesQueryResponse>();

                        #endregion
                }
        }
}
