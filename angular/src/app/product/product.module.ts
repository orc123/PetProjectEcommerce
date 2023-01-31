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
import { InputNumberModule } from 'primeng/inputnumber';
import { CheckboxModule } from 'primeng/checkbox';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { EditorModule } from 'primeng/editor';
import { Shared2Module } from '../shared/modules/shared.module';
import { BadgeModule } from "primeng/badge";
import { ImageModule } from 'primeng/image';
import { ConfirmDialogModule } from 'primeng/confirmdialog';


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
        DynamicDialogModule,
        InputNumberModule,
        CheckboxModule,
        InputTextareaModule,
        EditorModule,
        Shared2Module,
        BadgeModule,
        ImageModule,
        ConfirmDialogModule
    ],
    entryComponents: [
        ProductDetailComponent
    ]
})
export class ProductModule { }
