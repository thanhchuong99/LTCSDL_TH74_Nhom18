import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-so-gd',
  templateUrl: './so-gd.component.html',
  styleUrls: ['./so-gd.component.css']
})
export class SoGDComponent implements OnInit {
  SoGDs:any={
    data:[],
    totalRecord:0,
    page:0,
    size:65,
    TotalPage:0 
  }
  constructor(
    private http:HttpClient
    , @Inject('BASE_URL') baseUrl: string) {
  }
  ngOnInit() {
    let token = "Bearer "+localStorage.getItem("jwt");
    let x={
      page:1,
      size:65,
      keyword:""
    }
    
    this.http.post('https://localhost:44394/'+'api/SoGD/search-SoGD',x,{
      headers: new HttpHeaders({
        'Authorization':token,
        "Content-Type": "application/json"
      })}).subscribe(result => {
      this.SoGDs = result;
      this.SoGDs = this.SoGDs.data;
      console.log(this.SoGDs)
    }, error => console.error(error));

  }

  p: number = 1;

}
