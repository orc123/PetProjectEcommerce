import { PagedResultDto } from "@abp/ng.core";
import { Component, OnInit } from "@angular/core";
import { ProductDto, ProductIntListDto, ProductService } from "@proxy/products";
import { ProductCategoryService, ProductCategoryIntListDto } from '@proxy/product-categories';
import { firstValueFrom, Observable } from "rxjs";
import { DialogService } from "primeng/dynamicdialog";
import { ProductDetailComponent } from "./product-detail/product-detail.component";
import { NotificationService } from "../shared/services/notification.service";


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
        private _productCategoryService: ProductCategoryService,
        private _dialogService: DialogService,
        private _notificationService: NotificationService
    ) {

    }

    ngOnInit(): void {
        this.loadData();
        this.loadProductCategories();
    }

    loadData() {
        this.toggleBlockUI(true)
        this.listPaging$ = this._productService.getListFilter({
            keyword: this.keyword,
            maxResultCount: this.maxResultCount,
            skipCount: this.skipCount,
            categoryId: this.categoryId
        });

        this.toggleBlockUI(false)
    }

    async loadProductCategories() {
        var result = await firstValueFrom(this._productCategoryService.getListAll());

        result.forEach(element => {
            this.productCategories.push({
                value: element.id,
                name: element.name
            })
        });
    }

    showModal() {
       const ref = this._dialogService.open(ProductDetailComponent, {
            header: 'Thêm mới sản phẩm',
            width: '70%'
        });

        ref.onClose.subscribe((data: ProductDto)=> {
            if (data) {
                this.loadData(); 
                this._notificationService.showSuccess("Thêm mới thành công");
            }  
        });
    }

    pageChanged(event: any): void {
        this.skipCount = (event.page - 1) * this.maxResultCount;
        this.maxResultCount = event.rows;
        this.loadData();
    }

    private toggleBlockUI(enabled: boolean) {
        if (enabled == true) {
            this.blockedPanel = true;
        } else {
            setTimeout(() => {
                this.blockedPanel = false;
            }, 1000);
        }
    }
}
