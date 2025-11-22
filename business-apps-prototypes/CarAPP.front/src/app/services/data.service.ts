import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { InformationService } from './infocapture.service';
import { NewCarComponent } from '../new-workorder-view/new-car/new-car.component';
import { NewCustomerComponent } from '../new-workorder-view/new customer/new-customer.component';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  protected headers: HttpHeaders = new HttpHeaders({ 'Content-Type':'application/json' });

  constructor(private http: HttpClient, private info: InformationService) {}
  //firstName = this.info.firstName;

  sendDataToDB(data: any) {
    return this.http.post('http://localhost:5275/api/Course', data, {headers:this.headers});
  }

  sendDataToCars(data: any){
    return this.http.post('http://localhost:5277/api/Cars', data, {headers:this.headers});
  }
}
