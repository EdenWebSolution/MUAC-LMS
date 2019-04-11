import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginService } from './../services/login.service';
import { LoginModel } from '../models/loginModel';
import { NotificationService } from './../../shared/services/notification.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loginModel: LoginModel;
  isLoginFormSubmitted = false;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private loginService: LoginService,
    private notificationService: NotificationService
  ) {}

  ngOnInit() {
    this.loginForm = this.getLoginForm();
  }

  getLoginForm() {
    return this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  btnUserLogin() {
    this.isLoginFormSubmitted = true;
    if (!this.loginForm.valid){
      return;
    }

    this.loginModel = Object.assign({}, this.loginModel, this.loginForm.value);
    this.loginService.authenticateUser(this.loginModel).subscribe(
      result => {
        localStorage.setItem('TokenId', result.token);
        localStorage.setItem(
          'UserAccessLevel',
          result.isTeacher ? 'Teacher' : 'Student'
        );
        this.router.navigate(['/muac/dashboard']);
      },
      error => {
        this.notificationService.errorMessage(
          error.message !== undefined && error.message !== null
            ? error.message
            : 'Something went wrong, refresh page again'
        );
      }
    );
  }
}
