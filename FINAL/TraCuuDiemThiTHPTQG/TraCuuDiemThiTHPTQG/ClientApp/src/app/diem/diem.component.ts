import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder } from '@angular/forms';
declare var $:any;

@Component({
  selector: 'app-diem',
  templateUrl: './diem.component.html',
  styleUrls: ['./diem.component.css']
})
export class DiemComponent implements OnInit {
  test :boolean = true ;
  isDelete : boolean = false;
  invalid :boolean;
  khoithi:boolean;
  diems:any={
    data:[],
    totalRecord:0,
    page:0,
    size:5,
    TotalPage:0 
  }
  diem:any={
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
    }
  constructor(
    private http:HttpClient
    , @Inject('BASE_URL') baseUrl: string,private route:ActivatedRoute,private fb:FormBuilder ) {
  }
  ngOnInit() {
    this.searchDiem();
  }
  searchDiem(){
  let id = this.route.snapshot.params['id'];
  let kt = this.route.snapshot.params['kt'];
  if(kt == "KHTN"){
    this.khoithi=true;
  }
  else{
  this.khoithi=false;
  };
    if(id == null)
    {
      id = '';
    }
    let token = "Bearer "+localStorage.getItem("jwt");
    let x={
      page:1,
      size:65,
      keyword:id
    }
    
    this.http.post('https://localhost:44394/'+'api/Diem/search-Diem',x,{
      headers: new HttpHeaders({
        'Authorization':token,
        "Content-Type": "application/json"
      })}).subscribe(result => {
      this.diems = result;
      this.diems = this.diems.data;
      console.log(this.diems)
    },  err => {
      this.isDelete = true;
    } );
  }
  p: number = 1;
  isEdit : boolean = true;
  openModal(isNew,index)
  {
    let id = this.route.snapshot.params['id'];
    if(isNew)
    {
      this.isEdit=false;
      this.diem={
    soBaoDanh:id,
    diemToan:null,
    diemVan:null,
    diemNgoaiNgu:null,
    diemHoa:null,
    diemLy:null,
    diemSinh:null,
    diemDia:null,
    diemSu:null,
    diemGdcd:null,
      }
    }
    else
      {
        this.isEdit= true;
        this.diem = index;
      }
      $('#exampleModal').modal('show');
    }
    res : any ;
    addDiem(){
      var x = this.diem;
      let token = "Bearer "+localStorage.getItem("jwt");
      this.http.post('https://localhost:44394/'+'api/Diem/Create-Diem',x,{
        headers: new HttpHeaders({
          'Authorization':token,
          "Content-Type": "application/json"
        })}).subscribe(result => {
      var res:any = result;
      this.res = res.success;
      if(res.success)
      {
        this.isDelete=false;
      this.isEdit = true;
      this.test =this.res;
      this.searchDiem();
      alert("new Diem have been added successfully");
      }
    }, error => console.error(error));
    this.test = this.res;
  }
    updateDiem(){
      var x = this.diem;
      let token = "Bearer "+localStorage.getItem("jwt");
      this.http.post('https://localhost:44394/'+'api/Diem/Update-Diem',x,{
        headers: new HttpHeaders({
          'Authorization':token,
          "Content-Type": "application/json"
        })}).subscribe(result => {
      var res:any = result;
      this.res = res.success;
      if(res.success)
      {
      this.res = res.success;
      this.isEdit = true;
      this.searchDiem();
      alert("one Diem have been update successfully");
      }
    }, error => console.error(error));
    this.test = this.res;
    }
    deleteDiem(index: string){
      let x = {
        keyword: index
      }
       let token = "Bearer "+localStorage.getItem("jwt");
      if (confirm('Are you sure you want to delete this?')) {
      this.http.post('https://localhost:44394/'+'api/Diem/Delete-Diem',x,{
        headers: new HttpHeaders({
          'Authorization':token,
          "Content-Type": "application/json"
        })}).subscribe(result => {  
      var res:any = result;
      if(res.success)
      {
      this.isEdit = true;
      this.searchDiem();
      alert("one Diem have been delete successfully");
      }
    }, error => console.error(error));
  }
  else
  {
    this.searchDiem();
  }
    }
    
    
}


