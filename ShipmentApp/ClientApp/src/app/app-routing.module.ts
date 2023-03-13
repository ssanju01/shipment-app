import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { QuotesComponent } from './components/quotes/quotes.component';
import { ShipmentDetailComponent } from './components/shipment-detail/shipment-detail.component';
import { ShippersComponent } from './components/shippers/shippers.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'quotes', component: QuotesComponent },
  { path: 'shippers', component: ShippersComponent },
  { path: 'shipper/detail/:id', component: ShipmentDetailComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
