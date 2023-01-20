import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ProductRoutingModule } from './product-routing.module';
import { ProductComponent } from './product.component';
import { PanelModule } from 'primeng/panel';
import { TableModule } from 'primeng/table';
import { PaginatorModule } from 'primeng/paginator';
import { BlockUIModule } from "primeng/blockui";
import { ButtonModule } from "primeng/button";
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { ProgressSpinnerModule } from "primeng/progressspinner";
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { DynamicDialogModule } from "primeng/dynamicdialog";

@NgModule({
    declarations: [
        ProductComponent,
        ProductDetailComponent
    ],
    imports: [
        SharedModule, 
        ProductRoutingModule,
        PanelModule,
        TableModule,
        PaginatorModule,
        BlockUIModule,
        ButtonModule,
        DropdownModule,
        InputTextModule,
        ProgressSpinnerModule,
        DynamicDialogModule
    ],
})
export class ProductModule { }
