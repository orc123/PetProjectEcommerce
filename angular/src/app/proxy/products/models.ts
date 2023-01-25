import type { ProductType } from '../pet-project-ecommerce/products/product-type.enum';
import type { EntityDto } from '@abp/ng.core';
import type { BaseListFilterDto } from '../models';

export interface CreateUpdateProductDto {
  manufacturerId?: string;
  name?: string;
  code?: string;
  description?: string;
  productType: ProductType;
  sku?: string;
  slug?: string;
  sortOrder: number;
  visibility: boolean;
  isActive: boolean;
  sellPrice: number;
  categoryId?: string;
  seoMetaDescription?: string;
  thumbnailPicture?: string;
}

export interface ProductDto extends EntityDto<string> {
  manufacturerId?: string;
  name?: string;
  code?: string;
  description?: string;
  productType: ProductType;
  sku?: string;
  slug?: string;
  sortOrder: number;
  visibility: boolean;
  isActive: boolean;
  categoryId?: string;
  seoMetaDescription?: string;
  thumbnailPicture?: string;
  sellPrice: number;
}

export interface ProductIntListDto extends EntityDto<string> {
  manufacturerId?: string;
  name?: string;
  code?: string;
  description?: string;
  productType: ProductType;
  sku?: string;
  slug?: string;
  sortOrder: number;
  visibility: boolean;
  isActive: boolean;
  categoryId?: string;
  thumbnailPicture?: string;
}

export interface ProductListFilterDto extends BaseListFilterDto {
  categoryId?: string;
}
