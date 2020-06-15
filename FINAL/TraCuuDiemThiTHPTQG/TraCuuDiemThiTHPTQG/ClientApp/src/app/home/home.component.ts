import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpHeaders ,HttpClient} from '@angular/common/http';
import { ValueConverter } from '@angular/compiler/src/render3/view/template';
import {Chart}   from 'chart.js';
import { map } from 'rxjs/operators';
declare var $:any;
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
chart;
  constructor(  private http:HttpClient
    , @Inject('BASE_URL') baseUrl: string,private jwtHelper: JwtHelperService, private router: Router) {}
  

  p: number = 1;
  mon:string="1";
  diem:any={
   id: 0,
   keyword:""
  }
  diems:any={
    data:[],
    success:true,
    code:null,
    message:"",
    variant:"" ,
    title:""
  }
  per:any={
    data:[],
    success:true,
    code:null,
    message:"",
    variant:"" ,
    title:""
  }
  res:any={
    soBaoDanh:"",
    diemToan:"",
    diemVan:"",
    diemNgoaiNgu:"",
    diemHoa:"",
    diemLy:"",
    diemSinh:"",
    diemDia:"",
    diemSu:"",
    diemGdcd:"",
    diemKHTN:"",
    diemKHXH:""
    }
    read:boolean=false;
    read2:boolean=false;
    notfound:boolean=false;
  searchDiembySBD(){
      let token = "Bearer "+localStorage.getItem("jwt");
      var x = this.diem;    
      this.read=true;
      this.notfound =false;
      this.read2=false;
      this.http.post('https://localhost:44394/'+'api/Diem/get-Diem-by-SBD',x,{
        headers: new HttpHeaders({
          'Authorization':token,
          "Content-Type": "application/json"
        })}).subscribe(result => {
        this.res = result;
        this.res = this.res.data;
        console.log(this.res)
      },  error => {
        this.notfound = true;
      } );
    }
    top100(){
      let token = "Bearer "+localStorage.getItem("jwt");
      this.read=false;
      this.read2=true;
      this.notfound =false;
      let x = {
        keyword: this.mon.toString()
      }
      this.http.post('https://localhost:44394/'+'api/Diem/top100',x,{
        headers: new HttpHeaders({
          'Authorization':token,
          "Content-Type": "application/json"
        })}).subscribe(result => {
        this.diems = result;
        console.log(this.diems)
      },  error => {
        this.notfound = true;
      }  );
    }
    perc;
    sgd:string[];
    per100(){
      this.chart = new Chart('canvas',{
        type:'pie',
        options:{
          responsive: true,
          title:{
            display:true,
          },
        },
        data:{
          
          datasets:[
            {
              type:'pie',
              label:'test chart',
              backgroundColor:[ '#5163ce','#7d51ce','#bc51ce','#ce5163','#ce7d51', '#5163ce','#7d51ce','#bc51ce','#ce5163','#ce7d51', '#5163ce','#7d51ce','#bc51ce','#ce5163','#ce7d51', '#5163ce','#7d51ce','#bc51ce','#ce5163','#ce7d51', '#5163ce','#7d51ce','#bc51ce','#ce5163','#ce7d51', '#5163ce','#7d51ce','#bc51ce','#ce5163','#ce7d51', '#5163ce','#7d51ce','#bc51ce','#ce5163','#ce7d51', '#5163ce','#7d51ce','#bc51ce','#ce5163','#ce7d51', '#5163ce','#7d51ce','#bc51ce','#ce5163','#ce7d51', '#5163ce','#7d51ce','#bc51ce','#ce5163','#ce7d51', '#5163ce','#7d51ce','#bc51ce','#ce5163','#ce7d51', '#5163ce','#7d51ce','#bc51ce','#ce5163','#ce7d51',
            ],
              fill:false
            }
          ]
        }
      })
      this.chart.data.datasets[0].data=[];
      this.chart.data.labels=[];
      let token = "Bearer "+localStorage.getItem("jwt");
      this.read=false;
      this.read2=true;
      this.notfound =false;
      let x = {
        keyword: this.mon.toString()
      }
      this.http.post('https://localhost:44394/'+'api/Diem/per100',x,{
        headers: new HttpHeaders({
          'Authorization':token,
          "Content-Type": "application/json"
        })}).subscribe(result => {
          this.perc=result;
          this.perc=this.perc.data;
          for (let index = 0; index <  this.perc.length; index++) {
            this.chart.data.datasets[0].data.push(this.perc[index].per);  
          }
          for (let index = 0; index <  this.perc.length; index++) {
            this.chart.data.labels.push(this.perc[index].soGD.toString());  
          }
         this.chart.update();

        console.log(this.chart.data.labels[0].toString())
      },  error => {
        this.notfound = true;
      }  );
    }
  isUserAuthenticated() {
    let token: string = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }
  
  value = this.per;
  logOut() {
    localStorage.removeItem("jwt");
  }
    
  }

