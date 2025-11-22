import { Component, EventEmitter, Output, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, Validators, FormsModule, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { NgIf } from '@angular/common';
import { MatDialog, MatDialogModule } from '@angular/material/dialog'
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button'
import { Router } from '@angular/router';
import { DialogContentComponent } from './dialog-content/dialog-content.component';
import { NewCarComponent } from '../new-car/new-car.component';
import { AnimationService } from 'src/app/services/refresh.service';
import { DataService } from 'src/app/services/data.service';



@Component({
  selector: 'app-new-customer',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    NgIf,
    MatButtonModule,
    MatDialogModule

  ],
  templateUrl: './new-customer.component.html'
  ,
  styleUrls: ['./new-customer.component.scss']
})
export class NewCustomerComponent implements OnInit {


  @Input() formGroup?: FormGroup<{
    firstName: FormControl<string | null>,
    lastName: FormControl<string | null>,
    email: FormControl<string | null>
  }>
  firstName: FormControl = null!;
  lastName: FormControl = null!;
  email: FormControl = null!;

  

  @Output() onChange = new EventEmitter<string>;

  capture(e:any){
    this.onChange.emit(e.target.value);
  }


  constructor(private _router: Router, public dialog: MatDialog, 
    private animationService:AnimationService, private dataService:DataService) {}

  ngOnInit(): void {
    this.firstName = this.formGroup!.get("firstName")! as FormControl;
    this.lastName = this.formGroup!.get("lastName")! as FormControl;
    this.email = this.formGroup!.get("email")! as FormControl;

  }


  nameError = 'You must enter a name';
  nameInvalid = 'Not a valid name';


  navigateToNewCar() {
    this._router.navigate([NewCarComponent])
  }

  getFirstNameErrorMessage() {
    if (this.firstName.hasError('required')) {
      return this.nameError;
    }
    return this.firstName.hasError('pattern') ? this.nameInvalid : '';
  }

  getLastNameErrorMessage() {
    if (this.lastName.hasError('required')) {
      return this.nameError;
    }
    return this.lastName.hasError('pattern') ? this.nameInvalid : '';
  }

  getEmailErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter an email';
    }
    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  openDialog() {
    const dialogRef = this.dialog.open(DialogContentComponent)

    dialogRef.afterClosed().subscribe(result => {
      console.log('Dialog result: $(result)');
    })
  }

  submitPersonData(){
  const formData = this.formGroup?.value;
  console.log(formData)


    this.dataService.sendDataToDB(formData).subscribe(response => {
      console.log('Data sent to server:', response);
    })
  }
}


