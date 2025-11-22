import { Injectable } from '@angular/core';
import { Moment } from 'moment';
import { Subject, first } from 'rxjs';

@Injectable({
    providedIn: 'root',
})

export class InformationService{
  
    firstName = new Subject<string>();
    lastName = new Subject<string>();
    email = new Subject<string>();

    make = new Subject<string>();
    model = new Subject<string>();
    color = new Subject<string>();
    year = new Subject<string>();

    cart = new Subject<string>();

    totalPrice = new Subject<number>();
    subTotal = new Subject<number>();
    tax = new Subject<number>();

    constructor () {}

    setPersonInfo(firstName: string, lastName: string, email: string){
        this.firstName.next(firstName);
        this.lastName.next(lastName);
        this.email.next(email);
    }

   // setLastName(data: string){
     //   this.lastName.next(data);
   // }

    //setEmail(data: string){
      //  this.email.next(data);
    //}



    setCarInfo(make: string, model: string, year: string, color: string) {
        this.make.next(make);
        this.model.next(model);
        this.year.next(year);
        this.color.next(color);
    }
    
    //setModel(data: string) {
      //  this.model.next(data);
   // }

    //setColor(data: string){
      //  this.color.next(data);

    //}
    //setYear(data: string) {
      //  this.year.next(data);
    //}

    setCart(data: string){
        this.cart.next(data);
    }

    setSubTotal(data: number){
        this.subTotal.next(data);
    }

    setTax(data: number){
        this.tax.next(data);
    }

    setTotalPrice(data:number){
        this.totalPrice.next(data);
    }
}