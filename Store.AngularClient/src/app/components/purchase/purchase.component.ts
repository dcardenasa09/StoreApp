import { Component, OnInit, inject } from '@angular/core';
import { PurchaseService } from '../../services/purchase.service';
import { IPurchase } from 'src/app/models/IPurchase';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-purchase',
    templateUrl: './purchase.component.html',
    styleUrls: ['./purchase.component.scss']
})
export class PurchaseComponent implements OnInit {

    purchases: IPurchase[] = [];

    private purchaseService = inject(PurchaseService);

    ngOnInit(): void {
        this.getPurchases();
    }

    getPurchases() {
        this.purchaseService.getPurchases().subscribe({
            next: (response: IPurchase[]) => {
                this.purchases = response;
            },
            error: (e) => alert(e.error.Message)
        });
    }

    removeItem(item: IPurchase) {
        this.purchaseService.deletePurchase(item.id).subscribe({
            next: () => {
                alert("Compra cancelada.");
                this.getPurchases();
            },
            error: (e) => alert(e.error.Message)
        });
    }
}
