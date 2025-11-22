import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})

export class AnimationService{

    resetCustomerAnimation(){
        var refresh = <HTMLElement> document.getElementById('animatedCustomerHeader');
        refresh.style.animation = 'none';
        refresh.offsetHeight;
        refresh.style.animation = null!;
      }

      resetCarAnimation(){
        var refresh = <HTMLElement> document.getElementById('animatedCarHeader');
        refresh.style.animation = 'none';
        refresh.offsetHeight;
        refresh.style.animation = null!;
      }

      resetServiceAnimation(){
        var refresh = <HTMLElement> document.getElementById('animated-service-header');
        refresh.style.animation = 'none';
        refresh.offsetHeight;
        refresh.style.animation = null!;
      }

      resetSummaryAnimation(){
        var refresh = <HTMLElement> document.getElementById('animated-summary-header');
        refresh.style.animation = 'none';
        refresh.offsetHeight;
        refresh.style.animation = null!;
      }
}