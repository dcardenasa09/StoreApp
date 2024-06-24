import { Component, OnInit, inject } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { IProduct } from 'src/app/models/IProduct';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProductModalComponent } from './product-modal/product-modal.component';


@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
    products: IProduct[] = [];
    purchaseId: number = 0;
    clientId: number = 0;
    totalPrecio: number = 0;

    private productService = inject(ProductService);
    private modalService = inject(NgbModal);

    ngOnInit(): void {
        this.getProducts();
    }

    getProducts() {
        this.productService.getProducts().subscribe({
            next: (response: IProduct[]) => {
                this.products = response;
            },
            error: (e) => alert(e.error.Message)
        });
    }

    removeItem(item: IProduct) {
        this.productService.deleteProduct(item.id).subscribe({
            next: () => {
                this.products = this.products.filter(i => i !== item);
                alert("Producto eliminado.");
            },
            error: (e) => alert(e.error.Message)
        });
    }

    create() {
        const modalRef = this.modalService.open(ProductModalComponent);
        modalRef.componentInstance.product = { id: 0, key: '', description: '', stock: 0, price: 0 };
        modalRef.result.then((result: any) => {
            if (result) {
                this.getProducts();
            }
        }).catch((error: any) => {});
    }

    editItem(item: IProduct) {
        const modalRef = this.modalService.open(ProductModalComponent);
        modalRef.componentInstance.product = { ...item };
        modalRef.result.then((result: any) => {
            if (result) {
                this.getProducts();
            }
        }).catch((error: any) => {});
    }
}
