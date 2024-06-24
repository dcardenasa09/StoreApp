import { Component, inject } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {
    adminView: boolean = false;

    private authService = inject(AuthService);
    private router      = inject(Router);

    isAuthenticated(): boolean {
        return this.authService.isAuthenticated();
    }

    isAdminAuthenticated(): boolean {
        return this.authService.isAdminAuthenticated();
    }

    logout(): void {
        this.authService.logout();
        this.router.navigate(['/']);
    }
}