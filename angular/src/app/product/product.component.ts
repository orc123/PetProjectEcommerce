import { Component } from "@angular/core";
import { ProductDto } from "@proxy/products";
import { Observable } from "rxjs";


@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.scss'],
})
export class ProductComponent {
    items$: Observable<ProductDto[]>;
    blockedPanel: boolean = false;
}
