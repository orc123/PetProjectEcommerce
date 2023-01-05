import { PagedResultDto } from "@abp/ng.core";
import { Component, OnInit } from "@angular/core";
import { ProductDto, ProductIntListDto, ProductService } from "@proxy/products";
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

    constructor(
        private _productService: ProductService
    ) {

    }

    ngOnInit(): void {
        this.loadData();
    }

    loadData() {
        this.listPaging$ = this._productService.getListFilter({
            keyword: '',
            maxResultCount: this.maxResultCount,
            skipCount: this.skipCount
        });
    }

    pageChanged(event: any): void {
        this.skipCount = (event.page - 1) * this.maxResultCount;
        this.maxResultCount = event.rows;
        this.loadData();
    }
}
