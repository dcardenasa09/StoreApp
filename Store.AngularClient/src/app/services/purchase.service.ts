import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IPurchase } from '../models/IPurchase';

@Injectable({
    providedIn: 'root'
})
export class PurchaseService {

    private apiUrl = 'http://localhost:5001/api/Purchases';

    constructor(private http: HttpClient) { }

    getPurchases(): Observable<IPurchase[]> {
        return this.http.get<IPurchase[]>(this.apiUrl);
    }

    getPurchase(id: number): Observable<IPurchase> {
        return this.http.get<IPurchase>(`${this.apiUrl}/${id}`);
    }

    addPurchase(purchase: IPurchase): Observable<IPurchase> {
        return this.http.post<IPurchase>(this.apiUrl, purchase);
    }

    updatePurchase(id: number, purchase: IPurchase): Observable<void> {
        return this.http.put<void>(this.apiUrl, purchase);
    }

    deletePurchase(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`);
    }
}
