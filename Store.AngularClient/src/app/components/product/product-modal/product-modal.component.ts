import { Component, Input, inject } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { IProduct } from 'src/app/models/IProduct';
import { ProductService } from 'src/app/services/product.service';

@Component({
    selector: 'app-product-modal',
    templateUrl: './product-modal.component.html',
    styleUrls: ['./product-modal.component.scss']
})
export class ProductModalComponent {

    @Input() product: IProduct = { id: 0, key: '', urlImage: '', description: '', stock: 0, price: 0 };

    private activeModal    = inject(NgbActiveModal);
    private productService = inject(ProductService);

    save() {
        if (this.product.id === 0) {
            this.productService.addProduct(this.product).subscribe({
                next: () => this.activeModal.close(true),
                error: (e) => alert(e.error.Message)
            });
        } else {
            this.productService.updateProduct(this.product.id, this.product).subscribe({
                next: () => this.activeModal.close(true),
                error: (e) => alert(e.error.Message)
            });
        }
    }

    close() {
        this.activeModal.dismiss();
    }
}
