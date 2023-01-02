import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { LayoutService } from 'src/app/layout/service/app.layout.service';
import { ACCESS_TOKEN, REFRESH_TOKEN } from 'src/app/shared/constants/keys.const';
import { LoginRequestDto } from 'src/app/shared/models/login-request.dto';
import { LoginResponseDto } from 'src/app/shared/models/login-response.dto';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styles: [`
        :host ::ng-deep .pi-eye,
        :host ::ng-deep .pi-eye-slash {
            transform:scale(1.6);
            margin-right: 1rem;
            color: var(--primary-color) !important;
        }
    `]
})
export class LoginComponent implements OnInit, OnDestroy {

    private ngUnsubscribe = new Subject<void>();

    valCheck: string[] = ['remember'];

    password!: string;

    loginForm: FormGroup;

    constructor(
        public layoutService: LayoutService,
        private authService: AuthService,
        private fb: FormBuilder,
        private router: Router
        ) { }
    
    ngOnInit(): void {
        this.initForm();
    }

    initForm () {
        this.loginForm = this.fb.group({
            username: new FormControl('', Validators.required),
            password: new FormControl('', Validators.required)
        })
    }

    onLogin() {
        this.loginForm.markAsUntouched();
        if  (!this.loginForm.valid) 
            return;
        
        var request: LoginRequestDto = {
            username: this.loginForm.controls["username"].value,
            password: this.loginForm.controls["password"].value,
        }
        this.authService
            .login(request)
            .pipe(takeUntil(this.ngUnsubscribe))
            .subscribe({
                next: (value: LoginResponseDto) =>{
                    localStorage.setItem(ACCESS_TOKEN, value.access_token);
                    localStorage.setItem(REFRESH_TOKEN, value.refresh_token);
                    this.router.navigate(['']);
                },
                error: (err) => {
                    console.log(err);
                }
            })
    }
    
    ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
      }
}
