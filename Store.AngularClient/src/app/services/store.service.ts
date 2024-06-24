import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IPurchaseDetail } from '../models/IPurchaseDetail';
import { IPurchase } from '../models/IPurchase';

@Injectable({
    providedIn: 'root'
})
export class StoreService {

    private apiUrl = 'http://localhost:5001/api/Purchases';

    constructor(private http: HttpClient) { }

    getPurchase(clientId: number): Observable<any> {
        return this.http.get<any>(`${this.apiUrl}/${clientId}/Client`);
    }

    addPurchaseDetail(detail: IPurchaseDetail): Observable<any> {
        return this.http.post<any>(this.apiUrl + '/Detail', detail);
    }

    deleteItemCart(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}/Detail`);
    }

    getCart(purchaseId: number): Observable<IPurchaseDetail[]> {
        return this.http.get<IPurchaseDetail[]>(this.apiUrl + '/' + purchaseId + '/Detail');
    }

    update(data: IPurchase): Observable<IPurchase> {
        return this.http.put<IPurchase>(this.apiUrl, data);
    }
}
