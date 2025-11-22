import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation, inject} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, Validators, FormsModule, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { NgIf } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button'
import { NgFor } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { Router } from '@angular/router';
import { CarList } from '../../carlist';
import { CarService } from '../../services/car.service';
import { NewCustomerComponent } from '../new customer/new-customer.component';
import { DataService } from 'src/app/services/data.service';


interface DbModel {
  modelId: number;
  value: string;
}


@Component({
  selector: 'app-new-car',
  standalone: true,
  providers:[],
  encapsulation: ViewEncapsulation.None,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    NgIf,
    MatButtonModule,
    MatSelectModule,
    NgFor,
    MatProgressBarModule,
    NewCustomerComponent,
    MatCheckboxModule
  ],
  templateUrl: './new-car.component.html',
  styleUrls: ['./new-car.component.scss']

})
export class NewCarComponent implements OnInit{

  @Input() formGroup?: FormGroup<{
    color: FormControl<string | null>,
    year: FormControl<string| null>,
    make: FormControl<string | null>,
    model: FormControl<string | null>
  }>
  color: FormControl = null!;
  year: FormControl = null!;
  make: FormControl = null!;
  model: FormControl = null!;

  @Output() onChange = new EventEmitter<string>;

  capture(e:any){
    this.onChange.emit(e.target.value);
  }
  
  
  carService: CarService = inject(CarService);

  filteredMakeList: DbModel [] = [];
  carMakeList: CarList[] = [];

  carDbSelected = ''
  carDbModelSelected = ''
  inputYear = ''

  startYear = 2023;
  endYear = 1870;
  descendingSeries: string[] = [];


ngOnInit(): void {
  this.color = this.formGroup!.get("color")! as FormControl;
  this.year = this.formGroup!.get("year")! as FormControl;
  this.make = this.formGroup!.get("make")! as FormControl;
  this.model = this.formGroup!.get("model")! as FormControl;


if (this.startYear >= this.endYear) {
  for(let i = this.startYear; i >= this.endYear; i--){
    this.descendingSeries.push(i.toString());
  }
} else {
  console.error('Start value should be greater than or equal to end value.')
}
console.log(this.descendingSeries);
}


  public filterFunctionDb(){
    for(let i = 0; i < this.carMakeList.length; i++){
      if(this.carMakeList[i].make === this.carDbSelected){
        this.filteredMakeList = this.carMakeList[i].models
      }
    }
  }

constructor(private _router:Router, private dataService:DataService) {

  this.carService.getAllCars().then((carMakeList:CarList[]) => {
    this.carMakeList = carMakeList;
  });
}

navigateToServices(){
  this._router.navigate(['services'])
}

navigateToPreviousScreen(){
  this._router.navigate(['newCustomer'])
}

submitCarData(){
  const formData = this.formGroup?.value;
  console.log(formData);
  
  this.dataService.sendDataToDB(formData).subscribe(response => {
    console.log('Data sent to server:', response);
})
}

}