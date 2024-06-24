import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { CartComponent } from './components/cart/cart.component';
import { StoreComponent } from './components/store/store.component';
import { AuthGuard } from './auth.guard';
import { ProductComponent } from './components/product/product.component';
import { PurchaseComponent } from './components/purchase/purchase.component';

const routes: Routes = [
    { path: 'store', component: StoreComponent },
    { path: 'products', component: ProductComponent },
    { path: 'purchases', component: PurchaseComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'cart', component: CartComponent, canActivate: [AuthGuard] },
    { path: '**', redirectTo: '/store', pathMatch: 'full' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
