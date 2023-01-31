import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PrimeNGConfig } from 'primeng/api';
import { LOGIN_URL } from './shared/constants/keys.const';
import { AuthService } from './shared/services/auth.service';

@Component({
  selector: 'app-root',
  template: `
    <router-outlet></router-outlet>
    <p-toast position="top-right"></p-toast>
    <p-confirmDialog header="Xác nhận" acceptLabel="Có" rejectLabel="Không" icon="pi pi-exclamation-triangle"></p-confirmDialog>
  `,
})
export class AppComponent implements OnInit {

  menu = 'static';
  constructor(
    private _primengConfig: PrimeNGConfig,
    private _authService: AuthService,
    private _router: Router
  ){

  }
  ngOnInit(): void { 
    this._primengConfig.ripple = true;
    document.documentElement.style.fontSize = '14px';
    
    if (!this._authService.isAuthenticated()) {
      this._router.navigate([LOGIN_URL]);
    }
  }
}
