import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IProduct } from '../models/IProduct';

@Injectable({
    providedIn: 'root'
})
export class ProductService {

    private apiUrl = 'http://localhost:5001/api/Products';

    constructor(private http: HttpClient) { }

    getProductsStore(): Observable<IProduct[]> {
        let queryParams = new HttpParams();
        queryParams = queryParams.set('branchStoreId', 1);
        return this.http.get<IProduct[]>(`${this.apiUrl}/ProductsStore`, { params: queryParams });
    }

    getProducts(): Observable<IProduct[]> {
        return this.http.get<IProduct[]>(this.apiUrl);
    }

    getProduct(id: number): Observable<IProduct> {
        return this.http.get<IProduct>(`${this.apiUrl}/${id}`);
    }

    addProduct(product: IProduct): Observable<IProduct> {
        return this.http.post<IProduct>(this.apiUrl, product);
    }

    updateProduct(id: number, product: IProduct): Observable<void> {
        return this.http.put<void>(this.apiUrl, product);
    }

    deleteProduct(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`);
    }
}
