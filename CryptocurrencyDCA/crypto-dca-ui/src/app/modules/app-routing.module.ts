import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomePageComponent} from "../pages/home-page/home-page.component";
import {CryptocurrencyTableComponent} from "../pages/cryptocurrency-table/cryptocurrency-table.component";
import {InvestmentTableComponent} from "../pages/investment-table/investment-table.component";

const routes: Routes = [
  {path: 'home', component: HomePageComponent},
  {path: 'cryptocurrencies', component: CryptocurrencyTableComponent},
  {path: 'investments', component: InvestmentTableComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
