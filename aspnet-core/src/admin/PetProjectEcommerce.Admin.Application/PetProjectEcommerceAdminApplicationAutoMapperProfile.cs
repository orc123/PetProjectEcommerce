﻿using AutoMapper;
using PetProjectEcommerce.Admin.ProductCategories;
using PetProjectEcommerce.ProductCategories;

namespace PetProjectEcommerce.Admin;

public class PetProjectEcommerceAdminApplicationAutoMapperProfile : Profile
{
    public PetProjectEcommerceAdminApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<ProductCategory, ProductCategoryDto>();
        CreateMap<ProductCategory, ProductCategoryIntListDto>();
        CreateMap<CreateUpdateProductCategoryDto, ProductCategory>();
    }
}
