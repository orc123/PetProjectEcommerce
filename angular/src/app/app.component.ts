import { Component, OnInit } from '@angular/core';
import { PrimeNGConfig } from 'primeng/api';

@Component({
  selector: 'app-root',
  template: `
    <router-outlet></router-outlet>
  `,
})
export class AppComponent implements OnInit {

  menu = 'static';
  constructor(
    private _primengConfig: PrimeNGConfig
  ){

  }
  ngOnInit(): void { 
    this._primengConfig.ripple = true;
    document.documentElement.style.fontSize = '14px';   
  }
}
