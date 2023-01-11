import { PagedResultDto } from "@abp/ng.core";
import { Component, OnInit } from "@angular/core";
import { ProductDto, ProductIntListDto, ProductService } from "@proxy/products";
import { ProductCategoryService, ProductCategoryIntListDto } from '@proxy/product-categories';
import { Observable } from "rxjs";


@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.scss'],
})
export class ProductComponent implements OnInit {
    blockedPanel: boolean = false;
    listPaging$: Observable<PagedResultDto<ProductIntListDto>>;

    //Paging variables
    public skipCount: number = 0;
    public maxResultCount: number = 10;

    //Filter
    productCategories: any[] = [];
    keyword: string = '';
    categoryId: string = '';

    constructor(
        private _productService: ProductService,
        private _productCategoryService: ProductCategoryService
    ) {

    }

    ngOnInit(): void {
        this.loadData();
        this.loadProductCategories();
    }

    loadData() {
        this.listPaging$ = this._productService.getListFilter({
            keyword: this.keyword,
            maxResultCount: this.maxResultCount,
            skipCount: this.skipCount,
            categoryId: this.categoryId
        });
    }

    loadProductCategories() {
        this._productCategoryService.getListAll()
            .subscribe((response: ProductCategoryIntListDto[]) => {
                response.forEach(element => {
                    this.productCategories.push({
                        value: element.id,
                        name: element.name
                    })
                });
            });
    }

    pageChanged(event: any): void {
        this.skipCount = (event.page - 1) * this.maxResultCount;
        this.maxResultCount = event.rows;
        this.loadData();
    }
}
