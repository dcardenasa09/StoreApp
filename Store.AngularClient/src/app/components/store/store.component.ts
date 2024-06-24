import { Component, OnInit, inject } from '@angular/core';
import { IProduct } from 'src/app/models/IProduct';
import { IPurchaseDetail } from 'src/app/models/IPurchaseDetail';
import { AuthService } from 'src/app/services/auth.service';
import { ProductService } from 'src/app/services/product.service';
import { StoreService } from 'src/app/services/store.service';

@Component({
    selector: 'app-store',
    templateUrl: './store.component.html',
    styleUrls: ['./store.component.scss']
})
export class StoreComponent implements OnInit {

    productList: IProduct[]   = [];
    itemCart: IPurchaseDetail = {} as IPurchaseDetail;

    private productService = inject(ProductService);
    private authService    = inject(AuthService);
    private storeService   = inject(StoreService);

    ngOnInit(): void {
		this.productService.getProductsStore().subscribe({
			next: (response: any[]) => { this.productList = response; },
			error: (e) => console.error(e)
		});

        this.getPurchase();
	}

    isAuthenticated(): boolean {
        return this.authService.isAuthenticated();
    }

    isAdminAuthenticated(): boolean {
        return this.authService.isAdminAuthenticated();
    }

    addCart(item: IProduct) {
        this.cleanPurchaseDetail();
        const detail: IPurchaseDetail = { ...this.itemCart }

        if(item.productStores) {
            detail.productStoreId = item.productStores[0].id;
        }
        if(localStorage.getItem('purchaseId')) {
            detail.purchaseId = Number(localStorage.getItem('purchaseId'));
        }

        detail.price = item.price;
        detail.total = item.price;
        console.log(detail);

        this.storeService.addPurchaseDetail(detail).subscribe({
            next: (response) => {
                console.log(response);
            },
            error: (e) => alert(e.error.Message),
            complete: () => console.info('complete') 
        });
    }

    cleanPurchaseDetail() {
        this.itemCart = {
            id: 0,
            productStoreId: 0,
            purchaseId: 0,
            quantity: 1,
            price: 0,
            total: 0,
        };
    };

    getPurchase() {
        if(localStorage.getItem('clientId')) {
            let clientId = localStorage.getItem('clientId');

            this.storeService.getPurchase(Number(clientId)).subscribe({
                next: (response) => {
                    console.log(response);
                    localStorage.setItem('purchaseId', response.id);
                },
                error: (e) => alert(e.error.Message),
                complete: () => console.info('complete') 
            });
        }
    }
}
