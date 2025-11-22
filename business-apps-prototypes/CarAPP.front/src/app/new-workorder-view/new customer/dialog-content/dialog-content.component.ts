import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewCustomerComponent } from '../new-customer.component';
import { MatDialog, MatDialogModule} from '@angular/material/dialog' 
import { MatButtonModule } from '@angular/material/button';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { Router } from '@angular/router';


@Component({
  selector: 'app-dialog-content',
  standalone: true,
  imports: [
    CommonModule,
    NewCustomerComponent,
    MatDialogModule,
    MatButtonModule,
    MatProgressBarModule
    
  ],
  templateUrl: './dialog-content.component.html',
  styleUrls: ['./dialog-content.component.scss']
})
export class DialogContentComponent {

  constructor(public dialog: MatDialog, private _router:Router){

  }

  navigateToHome(){
    this._router.navigate([''])
  }

}
