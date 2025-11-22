import { AfterViewInit, Component, inject, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators, FormsModule, ReactiveFormsModule, FormControl, FormGroup } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatStepHeader, MatStepperIntl, MatStepperModule } from '@angular/material/stepper';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { NewCustomerComponent } from './new customer/new-customer.component';
import { NewCarComponent } from './new-car/new-car.component';
import { ServicesComponent } from './service/services.component';
import { SummaryComponent } from './summary/summary.component';
import { AnimationService } from '../services/refresh.service';
import { InformationService } from '../services/infocapture.service';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-new-workorder-view',
  standalone: true,
  providers:[FormBuilder],
  imports: [
    CommonModule,
    MatButtonModule,
    MatStepperModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    NewCustomerComponent,
    NewCarComponent,
    ServicesComponent,
    SummaryComponent,
    MatIconModule,
  ],
  templateUrl: './new-workorder-view.html',
  styleUrls: ['./new-workorder-view.component.scss']
})
export class NewWorkorderViewComponent {
  
  @ViewChild(NewCustomerComponent) newCustomerComponent!: NewCustomerComponent;
  @ViewChild(NewCarComponent) newCarComponent!: NewCarComponent;
  @ViewChild(ServicesComponent) servicesComponent!: ServicesComponent;
  @ViewChild(SummaryComponent) summary!:SummaryComponent;

  animationService:AnimationService = inject(AnimationService);
  dataService:DataService = inject(DataService);


  /*firstFormGroup = this._formBuilder.group({
     firstName:  new FormControl('',  [Validators.required, Validators.pattern('^[a-zA-Z]*$')]),
     lastName: new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z]*$')]),
     email: new FormControl('',[Validators.required, Validators.email])
  });*/

  firstFormGroup = this._formBuilder.group({
   firstName: new FormControl(''),
   lastName:  new FormControl(''),
   email: new FormControl('')
  })

  
  secondFormGroup = this._formBuilder.group({
    color: new FormControl('', [Validators.required]),
    year: new FormControl('',[Validators.required]),
    make:  new FormControl('',[Validators.required]),
    model:  new FormControl('',[Validators.required]),
  });

  thirdFormGroup = this._formBuilder.group({
    serviceControl: new FormControl ('' , [Validators.required]),
  });

  submitDataFirstForm(){
    var firstName = this.firstFormGroup.get('firstName')?.value
    var lastName = this.firstFormGroup.get('lastName')?.value
    var email = this.firstFormGroup.get('email')?.value

    this.infoService.setPersonInfo(firstName!, lastName!, email!)

    //this.infoService.setFirstName(firstName!);
    //this.infoService.setLastName(lastName!);
    //this.infoService.setEmail(email!);
  };

  submitDataSecondForm(){
    var make = this.secondFormGroup.get('make')?.value
    var model = this.secondFormGroup.get('model')?.value
    var color = this.secondFormGroup.get('color')?.value
    var year = this.secondFormGroup.get('year')?.value

    this.infoService.setCarInfo(make!, model!, color!, year!)

    //this.infoService.setMake(make!);
    //this.infoService.setModel(model!);
    //this.infoService.setColor(color!);
    //this.infoService.setYear(year!);
    
  };

  submitDataThirdForm(){
   
    var shoppingCart = this.thirdFormGroup.get('serviceControl')?.value
    this.infoService.setCart(shoppingCart!)
  };

  constructor(private _formBuilder : FormBuilder,
     private infoService: InformationService) {}

  refreshCustomer(): void{
    this.animationService.resetCustomerAnimation();
  }

  refreshCar(): void{
    this.animationService.resetCarAnimation();
  }

  refreshService(): void{
    this.animationService.resetServiceAnimation();
  }

  refreshSummary(): void{
    this.animationService.resetSummaryAnimation();
  }


  callDialogFunction(): void{
    this.newCustomerComponent.openDialog();
  }

  submit(){
    const person = this.firstFormGroup.value
    const car = this.secondFormGroup.value;
    //const formData = {...person, ...car};
    const formData = {
      person: person,
      car : car,
    };
    

    console.log(formData);

    this.dataService.sendDataToDB(formData).subscribe(response => {
      console.log('Data sent to server:', response);
    })

    //this.newCustomerComponent.submitPersonData();
    //this.newCarComponent.submitCarData();
  }
}