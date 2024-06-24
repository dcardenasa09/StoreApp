import { Component, OnInit, inject } from '@angular/core';
import { ClientService } from '../../services/client.service';
import { ProductService } from '../../services/product.service';
import { StoreService } from 'src/app/services/store.service';
import { IPurchase } from 'src/app/models/IPurchase';

@Component({
    selector: 'app-cart',
    templateUrl: './cart.component.html',
    styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

    cartItems: any[]    = [];
    purchaseId: number  = 0;
    clientId: number    = 0;
    totalPrecio: number = 0;

    private clientService = inject(ClientService);
    private storeService  = inject(StoreService);

    ngOnInit(): void {
        this.loadCartItems();

        if(localStorage.getItem('clientId')) {
            this.clientId = Number(localStorage.getItem('clientId'));
        }
    }

    loadCartItems() {
        if(localStorage.getItem('purchaseId')) {
            this.purchaseId = Number(localStorage.getItem('purchaseId'));

            this.storeService.getCart(this.purchaseId).subscribe({
                next: (response: any[]) => {
                    console.log(response);
                    this.cartItems = response;
                    this.calcularTotal();
                },
                error: (e) => alert(e.error.Message)
            });
        }
    }

    calcularTotal(): void {
        this.totalPrecio = this.cartItems.reduce((sum, producto) => sum + producto.price, 0);
    }

    removeItem(item: any) {
        this.storeService.deleteItemCart(item.id).subscribe({
            next: (response: any) => {
                this.cartItems = this.cartItems.filter(i => i !== item);
                this.calcularTotal();

                alert("Producto eliminado.")
            },
            error: (e) => alert(e.error.Message)
        });
    }

    purchase() {
        const purchase: IPurchase = {
            id: this.purchaseId,
            folio: "",
            clientId: this.clientId,
            date: new Date(),
            total: this.totalPrecio,
            status: 2,
            observations: "",
            isActive: true
        }

        this.storeService.update(purchase).subscribe({
            next: (response: any) => {
                console.log(response);
                this.cartItems   = [];
                this.totalPrecio = 0;

                alert("La compra se finalizó.")
            },
            error: (e) => alert(e.error.Message)
        });
    }
}
