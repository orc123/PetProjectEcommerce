import { Component, OnDestroy, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { ProductCategoryIntListDto, ProductCategoryService } from "@proxy/product-categories";
import { ProductDto, ProductService } from "@proxy/products";
import { Subject, takeUntil } from "rxjs";

@Component({
    selector: 'app-product-detail',
    templateUrl: './product-detail.component.html'
})
export class ProductDetailComponent implements OnInit, OnDestroy {
    private ngUnsubscribe = new Subject<void>();
    blockedPanel: boolean = false;

    public form: FormGroup;

    //Dropdown
    productCategories: any[] = [];
    selectedEntity = {} as ProductDto;

    constructor(
        private _productService: ProductService,
        private _productCategoryService: ProductCategoryService,
        private fb: FormBuilder
    ) { }

    ngOnDestroy(): void { }

    ngOnInit(): void {
        this.buildForm();
    }

    loadFormDetails(id: string) {
        this.toggleBlockUI(true);
        this._productService
            .get(id)
            .pipe(takeUntil(this.ngUnsubscribe))
            .subscribe({
                next: (response: ProductDto) => {
                    this.selectedEntity = response;
                    this.buildForm();
                    this.toggleBlockUI(false);
                },
                error: () => {
                    this.toggleBlockUI(false);
                },
            });
    }
    saveChange() {


    }
    loadProductCategories() {
        this._productCategoryService.getListAll().subscribe((response: ProductCategoryIntListDto[]) => {
            response.forEach(element => {
                this.productCategories.push({
                    value: element.id,
                    name: element.name,
                });
            });
        });
    }

    private buildForm() {
        this.form = this.fb.group({
            name: new FormControl(this.selectedEntity.name || null, Validators.required),
        });
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