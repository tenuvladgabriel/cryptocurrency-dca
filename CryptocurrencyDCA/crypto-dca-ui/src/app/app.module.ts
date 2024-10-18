import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppComponent} from "./components/app/app.component";
import {AppRoutingModule} from "./modules/app-routing.module";
import {MaterialModule} from "./modules/material.module";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {provideHttpClient, withInterceptorsFromDi} from "@angular/common/http";
import {HeaderComponent} from './components/header/header.component';
import {NoDataComponent} from './components/no-data/no-data.component';
import {ReactiveFormsModule} from "@angular/forms";
import {MAT_FORM_FIELD_DEFAULT_OPTIONS} from "@angular/material/form-field";
import {HomePageComponent} from "./pages/home-page/home-page.component";
import {MatFormInputComponent} from './components/mat-form-input/mat-form-input.component';
import {MatFormDateComponent} from './components/mat-form-date/mat-form-date.component';
import {MatFormSelectComponent} from './components/mat-form-select/mat-form-select.component';
import {CryptoDataService} from "./services/crypto-data.service";
import {CryptocurrencyTableComponent} from "./pages/cryptocurrency-table/cryptocurrency-table.component";
import {InvestmentTableComponent} from "./pages/investment-table/investment-table.component";
import {InvestmentDataService} from "./services/investment-data.service";

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    HeaderComponent,
    NoDataComponent,
    MatFormInputComponent,
    MatFormDateComponent,
    MatFormSelectComponent,
    CryptocurrencyTableComponent,
    InvestmentTableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    BrowserAnimationsModule,
    ReactiveFormsModule
  ],
  providers: [
    CryptoDataService,
    InvestmentDataService,
    provideHttpClient(withInterceptorsFromDi()),
    {provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: {appearance: 'fill'},}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
