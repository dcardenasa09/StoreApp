import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRegister } from '../models/IRegister';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private baseUrl = 'http://localhost:5001/api/auth';

    constructor(private http: HttpClient) { }

    login(username: string, password: string): Observable<any> {
        return this.http.post(`${this.baseUrl}/login`, { username, password });
    }

    register(register: IRegister): Observable<any> {
        return this.http.post(`${this.baseUrl}/register`, register);
    }

    isAuthenticated(): boolean {
        return !!localStorage.getItem('token');
    }

    isAdminAuthenticated(): boolean {
        let response = false;
        if(localStorage.getItem('isAdmin')) {
            let value = localStorage.getItem('isAdmin');
            response = value?.toLowerCase() == "true";
        }

        console.log(response);
        return response;
    }

    logout(): void {
        localStorage.clear();
    }
}
