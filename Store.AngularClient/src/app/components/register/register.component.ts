import { Component, OnInit, inject } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { IRegister } from 'src/app/models/IRegister';
import { jwtDecode } from 'jwt-decode';
import { of } from 'rxjs';

@Component({
	selector: 'app-register',
	templateUrl: './register.component.html',
	styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

	register: IRegister = {} as IRegister;

	private authService = inject(AuthService);
    private router      = inject(Router);

	ngOnInit(): void {
		this.register = {
			username: "",
			password: "",
			firstName: "",
			lastName: "",
			address: "",
			phone: ""
		}
	}

	createRegister() {
		const register = this.register;
		console.log(register);

		if(register.firstName === "" || register.lastName === "" || register.address === "" || register.phone === "" || register.username === "" || register.password === "") {
			alert("Completa todos los campos.");
			return;
		}

		const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
		if (!emailPattern.test(register.username)) {
			alert("El formato del correo electrónico es inválido.");
			return;
		}

		this.authService.register(this.register).subscribe({
			next: (response) => {
				localStorage.setItem('token', response.token);
				const decodedToken: any = jwtDecode(response.token);

				localStorage.setItem('clientId', decodedToken.ClientId);
				this.router.navigate(['/']);
			},
			error: (e) => console.error(e),
			complete: () => console.info('complete') 
		});
	}
}
