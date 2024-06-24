import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IClient } from '../models/IClient';

@Injectable({
    providedIn: 'root'
})
export class ClientService {
    private apiUrl = 'http://localhost:5001/api/Clients';

    constructor(private http: HttpClient) { }

    getClients(): Observable<IClient[]> {
        return this.http.get<IClient[]>(this.apiUrl);
    }

    getClient(id: number): Observable<IClient> {
        return this.http.get<IClient>(`${this.apiUrl}/${id}`);
    }

    addClient(cliente: IClient): Observable<IClient> {
        return this.http.post<IClient>(this.apiUrl, cliente);
    }

    updateClient(id: number, cliente: IClient): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/${id}`, cliente);
    }

    deleteClient(id: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${id}`);
    }
}
