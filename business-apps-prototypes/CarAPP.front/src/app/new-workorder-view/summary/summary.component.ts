import { Component, Input, OnInit, inject } from '@angular/core';
import { CommonModule, KeyValuePipe } from '@angular/common';
import { NgFor } from '@angular/common'
import { NewWorkorderViewComponent } from '../new-workorder-view.component';
import { FormControl, FormGroup } from '@angular/forms';
import { InformationService } from 'src/app/services/infocapture.service';
import { Subscriber, Subscription } from 'rxjs';

@Component({
  selector: 'app-summary',
  standalone: true,
  imports: [CommonModule, NgFor],
  templateUrl:'./summary.component.html',
  styleUrls: ['./summary.component.scss'],

})


export class SummaryComponent {

  

  constructor(private infoService:InformationService){
    this.infoService.firstName.subscribe ( { next : (d) => { this.firstName = d} } )
    this.infoService.lastName.subscribe ( { next : (d) => { this.lastName = d} } )
    this.infoService.email.subscribe ( { next : (d) => { this.email = d} } )

    this.infoService.make.subscribe ( { next : (d) => { this.make = d } } )
    this.infoService.model.subscribe ( { next : (d) => { this.model = d } } ) 
    this.infoService.year.subscribe ( { next : (d) => { this.year = d } } )
    this.infoService.color.subscribe ( { next : (d) => { this.color = d } } )

    this.infoService.cart.subscribe ( { next : (d) => { this.cart = d } } )
    this.infoService.totalPrice.subscribe ( { next : (d) => { this.totalPrice = d; console.log(d); console.log(this.totalPrice) } } )
    this.infoService.subTotal.subscribe ( { next : (d) => { this.subTotal = d } } )
    this.infoService.tax.subscribe ( { next : (d) => { this.tax = d } } )
    

  }


  firstName : any;
  lastName : any;
  email : any;
  make : any;
  model : any;
  color : any;
  year : any;
  cart : any;
  totalPrice : any;
  subTotal : any;
  tax : any;

}
