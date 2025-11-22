import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, Validators, FormsModule, ReactiveFormsModule, FormGroup, FormBuilder } from '@angular/forms';
import { NgIf, NgFor} from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button'
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSelectModule} from '@angular/material/select';
import { InformationService } from 'src/app/services/infocapture.service';
import { Router } from '@angular/router';

interface Service {
  id: number;
  name: string;
  price: number;
}

@Component({
  selector: 'app-services',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    NgIf,
    MatButtonModule,
    MatProgressBarModule,
    MatSelectModule,
  ],
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.scss']
})
export class ServicesComponent implements OnInit {

  @Input() formGroup? : FormGroup<{
    serviceControl: FormControl<string | null>
  }>;
  
  serviceControl: FormControl = null!;

  ngOnInit(): void {
    //console.log("here")
    this.serviceControl = this.formGroup!.get("serviceControl")! as FormControl;
  }

  services: Service [] = [
    {id: 0, name: 'Oil Change', price:39.99},
    {id: 1, name: 'Brake Change', price:99.99},
    {id: 2, name: 'Tire Rotation', price:10.99}
  ];

  cartArray : Service [] = [];

  toggleService(service:Service){
    if (this.cartArray.includes(service))
    this.cartArray = this.cartArray.filter((currentService) => { 
      return currentService.id != service.id})
    else this.cartArray.push(service)
    
    //console.log(this.cartArray)
  }


doSomething(serviceControl:FormControl){
  //console.log(serviceControl)
  //debugger
}

calculateTotalPrice(){
  let totalPrice = 0.00;
  let subTotal = 0.00;
  let tax = 0.00;
  for(const service of this.cartArray){
    totalPrice = totalPrice + service.price + (service.price * 0.0820)
    subTotal += service.price;
    tax += (service.price * 0.0820);
    console.log("subtotal: ",subTotal)
    console.log("tax: ", tax)
  }
  const formattedSubTotal = +subTotal.toFixed(2);
  const formattedTax = +tax.toFixed(2);
  const formattedTotalPrice = +totalPrice.toFixed(2);
  this.infoService.setSubTotal(formattedSubTotal);
  this.infoService.setTax(formattedTax);
  this.infoService.setTotalPrice(formattedTotalPrice) 
  return formattedTotalPrice;
}


constructor(private _router:Router, public infoService:InformationService) {}

navigateToPreviousScreen(){
  this._router.navigate(["newCar"])
}

}
