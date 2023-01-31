import { PagedResultDto } from "@abp/ng.core";
import { Component, OnDestroy, OnInit } from "@angular/core";
import { ProductDto, ProductIntListDto, ProductService } from "@proxy/products";
import { ProductCategoryService } from '@proxy/product-categories';
import { firstValueFrom, Observable, Subject, takeUntil } from "rxjs";
import { DialogService } from "primeng/dynamicdialog";
import { ProductDetailComponent } from "./product-detail/product-detail.component";
import { NotificationService } from "../shared/services/notification.service";
import { ProductType } from "@proxy/pet-project-ecommerce/products";
import { ConfirmationService } from "primeng/api";


@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.scss'],
})
export class ProductComponent implements OnInit, OnDestroy {
    private ngUnsubscribe = new Subject<void>();
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
        private _notificationService: NotificationService,
        private _confirmationService: ConfirmationService
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
        })
            .pipe(takeUntil(this.ngUnsubscribe));

        this.toggleBlockUI(false)
    }

    async loadProductCategories() {
        var result = await firstValueFrom(
            this._productCategoryService.getListAll()
                .pipe(takeUntil(this.ngUnsubscribe))
        );

        result.forEach(element => {
            this.productCategories.push({
                value: element.id,
                label: element.name
            })
        });

    }

    showModal() {
        const ref = this._dialogService.open(ProductDetailComponent, {
            header: 'Thêm mới sản phẩm',
            width: '70%'
        });

        ref.onClose.subscribe((data: ProductDto) => {
            if (data) {
                this.loadData();
                this._notificationService.showSuccess("Thêm mới thành công");
            }
        });
    }

    showEditModal(row) {
        const ref = this._dialogService.open(ProductDetailComponent, {
            data: {
                id: row.id
            },
            header: 'Cập nhật sản phẩm',
            width: '70%'
        });

        ref.onClose.subscribe((data: ProductDto) => {
            if (data) {
                this.loadData();
                this._notificationService.showSuccess("Cập nhật sản phẩm thành công");
            }
        });
    }

    onDelete(row) {
        this._confirmationService.confirm({
            message: 'Bạn có muốn xóa bản ghi này không?',
            accept: () => {
                this.deleteItem(row.id);
            }
        });
    }

    deleteItem(id: string) {
        this.toggleBlockUI(true);
        this._productService.delete(id).subscribe({
            next: () => {
                this.toggleBlockUI(false);
                this._notificationService.showSuccess("Xóa sản phẩm thành công");
                this.loadData();
            },
            error: (err) => {
                this._notificationService.showError(err.error.error.message);
                this.toggleBlockUI(false)
            }
        });
    }

    pageChanged(event: any): void {
        this.skipCount = (event.page - 1) * this.maxResultCount;
        this.maxResultCount = event.rows;
        this.loadData();
    }

    getProductType(value: number) {
        return ProductType[value];
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

    ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }
}
