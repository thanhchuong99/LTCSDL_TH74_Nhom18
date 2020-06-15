import { Component, OnInit, Inject, Input } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { formatDate, DatePipe } from '@angular/common';
import { Validators, FormControl, FormBuilder } from '@angular/forms';
declare var $:any;
@Component({
  selector: 'app-thisinh',
  templateUrl: './thisinh.component.html',
  styleUrls: ['./thisinh.component.css']
})
export class ThisinhComponent implements OnInit {
  isDelete : boolean = false;
  invalid: boolean;
  private optionsGT: string[] = ["Nam", "Nữ"];
  private optionsKT: string[] = ["KHTN", "KHXH"];
  selectedGT = "NAM";
  selectedKT ="KHTN"
  thisinhs:any={
    data:[],
    totalRecord:0,
    page:0,
    size:5,
    TotalPage:0 
  }
  thisinh:any={
    soBaoDanh :"",
    ho:"",
    ten:"",
    ngaySinh:"",
    queQuan:"",
    gioiTinh:"",
    khoiThi:""
  }
  constructor(
    private http:HttpClient
    , @Inject('BASE_URL') baseUrl: string,private route:ActivatedRoute,private fb:FormBuilder ) {
  }
  ngOnInit() {
    this.searchThisinh();
  }
  searchThisinh(){
  let id = this.route.snapshot.params['id'];
    if(id == null)
    {
      id = '';
    };
    let token = "Bearer "+localStorage.getItem("jwt");
    let x={
      page:1,
      size:65,
      keyword:id
    }
    
    this.http.post('https://localhost:44394/'+'api/ThiSinh/search-ThiSinh',x,{
      headers: new HttpHeaders({
        'Authorization':token,
        "Content-Type": "application/json"
      })}).subscribe(result => {
      this.thisinhs = result;
      this.thisinhs = this.thisinhs.data;
      console.log(this.thisinhs)
    },  err => {
      this.isDelete = true;
    });
  }
  p: number = 1;
  isEdit : boolean = true;
  pipe = new DatePipe('en-US');
  openModal(isNew,index)
  {
    if(isNew)
    {
      let id = this.route.snapshot.params['id'];
      this.isEdit=false;
      this.thisinh={
        soBaoDanh :id,
        ho:"",
        ten:"",
        ngaySinh:"",
        queQuan:"",
        gioiTinh:"",
        khoiThi:""
      }
    }
    else
      {
        this.isEdit= true;
        var item = index;
        this.thisinh={
          soBaoDanh :item.soBaoDanh,
          ho:item.ho,
          ten:item.ten,
          ngaySinh:item.ngaySinh,
          queQuan:item.queQuan.toString(),
          gioiTinh:item.gioiTinh,
          khoiThi:item.khoiThi
        }
        this.thisinh.ngaySinh = this.pipe.transform(this.thisinh.ngaySinh,"yyyy-MM-dd")
      }
      $('#exampleModal').modal('show');
    }
    res : boolean ;
    addThisinh(){
      var x = this.thisinh;
      let token = "Bearer "+localStorage.getItem("jwt");
      this.http.post('https://localhost:44394/'+'api/ThiSinh/Create-ThiSinh',x,{
        headers: new HttpHeaders({
          'Authorization':token,
          "Content-Type": "application/json"
        })}).subscribe(result => {
      var res:any = result;
      if(res.success)
      {
      this.isDelete=false;
      this.isEdit = true;
      this.invalid = false;
      alert("new Thisinh have been added successfully");
      this.searchThisinh();
      }
    }, err => {
      this.invalid = true;
    });
  }
    updateThisinh(){
      var x = this.thisinh;
      let token = "Bearer "+localStorage.getItem("jwt");
      this.http.post('https://localhost:44394/'+'api/ThiSinh/Update-ThiSinh',x,{
        headers: new HttpHeaders({
          'Authorization':token,
          "Content-Type": "application/json"
        })}).subscribe(result => {
      var res:any = result;
      if(res.success)
      {
      this.isEdit = true;
      this.invalid = false;
      this.searchThisinh();
      alert("one Thisinh have been update successfully");
      }
    },  err => {
      this.invalid = true;
    });
    }
    deleteThisinh(index: string){
      let x = {
        keyword: index
      }
       let token = "Bearer "+localStorage.getItem("jwt");
      if (confirm('Are you sure you want to delete this?')) {
      this.http.post('https://localhost:44394/'+'api/ThiSinh/Delete-ThiSinh',x,{
        headers: new HttpHeaders({
          'Authorization':token,
          "Content-Type": "application/json"
        })}).subscribe(result => {  
      var res:any = result;
      if(res.success)
      {
      this.isEdit = true;
      alert("one Thisinh have been delete successfully");
      this.searchThisinh();
      }
    }, error => console.error(error));
  }
  else
  {
    this.searchThisinh();
  }
    }
    
}


