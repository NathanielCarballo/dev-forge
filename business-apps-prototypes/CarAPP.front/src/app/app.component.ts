import { compileNgModule } from '@angular/compiler';
import { Component, Input } from '@angular/core';
import { MomentDateAdapter } from '@angular/material-moment-adapter';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})

export class AppComponent {
  title = 'CarApp.Front';
  
}
