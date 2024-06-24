import { Component, inject } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { StoreService } from 'src/app/services/store.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent {
    username?: string;
    password?: string;

    private storeService = inject(StoreService);
    private authService = inject(AuthService);
    private router      = inject(Router);

    login() {
        this.authService.login(this.username ?? "", this.password ?? "").subscribe({
			next: (response) => {
                localStorage.setItem('token', response.token);
                localStorage.setItem('isAdmin', response.isAdmin);

                if(!response.isAdmin) {
                    localStorage.setItem('clientId', response.ClientId);
                    this.router.navigate(['/']);
                } else {
                    this.router.navigate(['/products']);
                }

			},
			error: (e) => alert(e.error.Message),
			complete: () => this.getPurchase()
		});
    }

    getPurchase() {
        if(localStorage.getItem('clientId')) {
            let clientId = localStorage.getItem('clientId');

            this.storeService.getPurchase(Number(clientId)).subscribe({
                next: (response) => {
                    console.log(response);
                },
                error: (e) => alert(e.error.Message),
                complete: () => console.info('complete')
            });
        }
    }
}
