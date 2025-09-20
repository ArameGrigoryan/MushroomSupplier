using AutoMapper;
using MushroomSupplier.Core.DTOs;
using MushroomSupplier.Core.Models;

namespace MushroomSupplier.Application.Mapping;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateProductDto, Product>();
        CreateMap<Product, ProductDto>();
        
        CreateMap<CreateOrderDto, Order>();
        CreateMap<Order, OrderDto>();

        CreateMap<CreateOrderItemDto, OrderItem>();
        CreateMap<OrderItem, OrderItemDto>();
        
        CreateMap<CreateRestaurantDto, Restaurant>();
        CreateMap<Restaurant, RestaurantDto>();
        
        CreateMap<CreateSupplierDto, Supplier>();
        CreateMap<Supplier, SupplierDto>();    }
}