import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { CartComponent } from './components/cart/cart.component';
import { HttpClientModule } from '@angular/common/http';
import { StoreComponent } from './components/store/store.component';
import { ProductComponent } from './components/product/product.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ProductModalComponent } from './components/product/product-modal/product-modal.component';
import { PurchaseComponent } from './components/purchase/purchase.component';
import { PasswordValidatorDirective } from './directives/password-validator.directive';

@NgModule({
    declarations: [
        AppComponent,
        LoginComponent,
        RegisterComponent,
        CartComponent,
        StoreComponent,
        ProductComponent,
        ProductModalComponent,
        PurchaseComponent,
        PasswordValidatorDirective,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule,
        NgbModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
