import { ChangeDetectorRef, Component, OnDestroy, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { DomSanitizer } from "@angular/platform-browser";
import { ManufacturerInListDto, ManufacturerService } from "@proxy/manufacturers";
import { productTypeOptions } from "@proxy/pet-project-ecommerce/products";
import { ProductCategoryIntListDto, ProductCategoryService } from "@proxy/product-categories";
import { ProductDto, ProductService } from "@proxy/products";
import { DynamicDialogConfig, DynamicDialogRef } from "primeng/dynamicdialog";
import { firstValueFrom, Observer, Subject, takeUntil } from "rxjs";
import { NotificationService } from "src/app/shared/services/notification.service";
import { UtilityService } from "src/app/shared/services/utility.service";

@Component({
    selector: 'app-product-detail',
    templateUrl: './product-detail.component.html'
})
export class ProductDetailComponent implements OnInit, OnDestroy {
    private ngUnsubscribe = new Subject<void>();
    blockedPanel: boolean = false;
    btnDisabled: boolean = false;
    public thumbnailImage;


    public form: FormGroup;

    //Dropdown
    productCategories: any[] = [];
    manufacturers: any[] = [];
    productTypes: any[] = [];
    selectedEntity = {} as ProductDto;

    observer = {
        next: value => {
            this.toggleBlockUI(false);
            this.ref.close(value);
        },
        error: (err) => {
            this._notificationService.showError(err.error.error.message);
            this.toggleBlockUI(false)
        }
    }

    constructor(
        private _productService: ProductService,
        private _productCategoryService: ProductCategoryService,
        private _manufacturerService: ManufacturerService,
        private _utilityService: UtilityService,
        private _notificationService: NotificationService,
        private fb: FormBuilder,
        public ref: DynamicDialogRef,
        public config: DynamicDialogConfig,
        private cd: ChangeDetectorRef,
        private sanitizer: DomSanitizer
    ) { }

    validationMessages = {
        code: [{ type: 'required', message: 'Bạn phải nhập mã duy nhất' }],
        name: [
            { type: 'required', message: 'Bạn phải nhập tên' },
            { type: 'maxlength', message: 'Bạn không được nhập quá 255 kí tự' },
        ],
        slug: [{ type: 'required', message: 'Bạn phải URL duy nhất' }],
        sku: [{ type: 'required', message: 'Bạn phải mã SKU sản phẩm' }],
        manufacturerId: [{ type: 'required', message: 'Bạn phải chọn nhà cung cấp' }],
        categoryId: [{ type: 'required', message: 'Bạn phải chọn danh mục' }],
        productType: [{ type: 'required', message: 'Bạn phải chọn loại sản phẩm' }],
        sortOrder: [{ type: 'required', message: 'Bạn phải nhập thứ tự' }],
        sellPrice: [{ type: 'required', message: 'Bạn phải nhập giá bán' }]
    };

    ngOnDestroy(): void {
        if (this.ref) {
            this.ref.close();
        }
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    ngOnInit(): void {
        this.loadProductCategories();
        this.loadManufacturers();
        this.loadProductTypes();
        this.buildForm();
        if (this.config.data?.id)
            this.loadFormDetails(this.config.data?.id);

    }

    generateSlug() {
        this.form.controls['slug'].setValue(this._utilityService.MakeSeoTitle(this.form.get('name').value));
    }

    async loadFormDetails(id: string) {
        this.toggleBlockUI(true);
        this.selectedEntity = await firstValueFrom(
            this._productService.get(id).pipe(takeUntil(this.ngUnsubscribe))
        );
        this.loadThumbnail(this.selectedEntity.thumbnailPicture);

        this.loadData();
        this.toggleBlockUI(false);
    }

    saveChange() {
        this.toggleBlockUI(true);
        if (this.config.data?.id) {
            this._productService.update(this.config.data?.id, this.form.value)
                .pipe(takeUntil(this.ngUnsubscribe))
                .subscribe(this.observer);
        }
        else {
            this._productService.create(this.form.value)
                .pipe(takeUntil(this.ngUnsubscribe))
                .subscribe(this.observer);
        }
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

    async loadManufacturers() {
        var result = await firstValueFrom(
            this._manufacturerService.getListAll()
                .pipe(takeUntil(this.ngUnsubscribe))
        );
        result.forEach(element => {
            this.manufacturers.push({
                value: element.id,
                label: element.name
            })
        });
    }

    loadProductTypes() {
        productTypeOptions.forEach(element => {
            this.productTypes.push({
                value: element.value,
                label: element.key,
            });
        });
    }

    onFileChange(event) {
        const reader = new FileReader();

        if (event.target.files && event.target.files.length) {
            const [file] = event.target.files;
            reader.readAsDataURL(file);
            reader.onload = () => {
                this.form.patchValue({
                    thumbnailPictureName: file.name,
                    thumbnailPictureContent: reader.result,
                });

                // need to run CD since file load runs outside of zone
                this.cd.markForCheck();
            };
        }
    }

    async loadThumbnail(fileName: string) {
        var result = await firstValueFrom(this._productService.getThumbnailImage(fileName)
            .pipe(takeUntil(this.ngUnsubscribe)));

        var fileExt = this.selectedEntity.thumbnailPicture?.split('.').pop();
        this.thumbnailImage = this.sanitizer.bypassSecurityTrustResourceUrl(
            `data:image/${fileExt};base64, ${result}`
        );
    }

    private buildForm() {
        this.form = this.fb.group({
            name: new FormControl(null, Validators.compose([
                Validators.required,
                Validators.maxLength(250)
            ])),
            code: new FormControl(null, Validators.required),
            slug: new FormControl(null, Validators.required),
            sku: new FormControl(null, Validators.required),
            manufacturerId: new FormControl(null, Validators.required),
            categoryId: new FormControl(null, Validators.required),
            productType: new FormControl(null, Validators.required),
            sortOrder: new FormControl(null, Validators.required),
            sellPrice: new FormControl(null, Validators.required),
            visibility: new FormControl(true),
            isActive: new FormControl(true),
            seoMetaDescription: new FormControl(null),
            description: new FormControl(null),
            thumbnailPictureName: new FormControl(null),
            thumbnailPictureContent: new FormControl(null)
        });
    }

    private loadData() {
        this.form.patchValue({
            name: this.selectedEntity.name,
            code: this.selectedEntity.code,
            slug: this.selectedEntity.slug,
            sku: this.selectedEntity.sku,
            manufacturerId: this.selectedEntity.manufacturerId,
            categoryId: this.selectedEntity.categoryId,
            productType: this.selectedEntity.productType,
            sortOrder: this.selectedEntity.sortOrder,
            sellPrice: this.selectedEntity.sellPrice,
            visibility: this.selectedEntity.visibility,
            isActive: this.selectedEntity.isActive,
            seoMetaDescription: this.selectedEntity.seoMetaDescription,
            description: this.selectedEntity.description,
        });
    }

    private toggleBlockUI(enabled: boolean) {
        if (enabled == true) {
            this.blockedPanel = true;
            this.btnDisabled = true;
        } else {
            setTimeout(() => {
                this.blockedPanel = false;
                this.btnDisabled = false;
            }, 1000);
        }
    }
}