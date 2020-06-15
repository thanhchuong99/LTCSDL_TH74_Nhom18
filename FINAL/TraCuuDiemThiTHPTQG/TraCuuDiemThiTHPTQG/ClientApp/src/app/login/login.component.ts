import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  {

  invalidLogin: boolean;

  constructor(private router: Router, private http:HttpClient
    , @Inject('BASE_URL') baseUrl: string) { }
  login(form: NgForm) {
    let credentials = JSON.stringify(form.value);
    this.http.post('https://localhost:44394/'+'api/auth/login'  , credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      let token = (<any>response).token;
      localStorage.setItem("jwt", token);
      this.invalidLogin = false;
      this.router.navigate(["sogd"]);
    }, err => {
      this.invalidLogin = true;
    });
  }

}
