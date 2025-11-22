import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NewCustomerComponent } from './new-workorder-view/new customer/new-customer.component';
import { NewCarComponent } from './new-workorder-view/new-car/new-car.component';
import { ServicesComponent } from './new-workorder-view/service/services.component';
import { NewWorkorderViewComponent } from './new-workorder-view/new-workorder-view.component';

const routes: Routes = [
  {path: '',
  component: HomeComponent,
  title: 'Home Page'},
  
  {path: 'newWorkOrder',
  component: NewWorkorderViewComponent,
  title: 'New WorkOrder'},

  /*{path: 'newCar',
  component: NewCarComponent,
  title:'New Car'},

  {path: 'services',
  component: ServicesComponent,
  title:'Services'}*/
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
