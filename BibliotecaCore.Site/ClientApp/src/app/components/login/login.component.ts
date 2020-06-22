import { Component, OnInit } from '@angular/core';
import { UserAuth } from '../../model/user-auth';
import { ResponseAuth } from '../../model/response-auth';
import { AuthService } from '../../service/auth.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  securityObject: ResponseAuth = new ResponseAuth();
  returnUrl = '/book';
  errorMessage = '';

  constructor(
    private authServie: AuthService,
    private router: Router
  ) { }

  LoginForm: FormGroup;
  submitted = false;

  ngOnInit() {
    this.inicialFormLogin();
  }

  inicialFormLogin() {
    this.LoginForm = new FormGroup({
      user: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
    });
  }

  resetForm() {
    this.inicialFormLogin();
    this.submitted = false;
  }

  login() {
     this.submitted = true;
     if (this.LoginForm.invalid) {
      return;
     }
     this.errorMessage = '';
     this.authServie.login(this.LoginForm.value).subscribe(resp => {
        this.securityObject = resp;
        this.resetForm();
        this.router.navigateByUrl(this.returnUrl);
      }
    ),
    error => this.errorMessage = error;
  }
}
