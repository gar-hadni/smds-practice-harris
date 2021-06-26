import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
  emp = this.httpClient.get('https://localhost:44388/api/Employees')

  constructor( private httpClient: HttpClient ) { 
    
  }

  ngOnInit() {
    
  }

  testGet(){
    // window.alert("testGet")
    // var testemp = this.httpClient.get<{emp_ID: number, emp_FirstName: string, emp_LastName: string, emp_Age: number, emp_Building_ID: number}[]>('https://localhost:44388/api/Employees', );

    // var testemp = this.httpClient.get('https://localhost:44388/api/Employees', );

    var testemp = this.httpClient.get('https://localhost:44388/api/Employees').subscribe(responseData => console.log(responseData))

    // this._httpClient.post(window.location.protocol + '//' + window.location.hostname + ':3000/' + 'users/login', user)

    // console.log(this.httpClient)
    // console.log(testemp[0].Emp_ID)
    // console.log('response: ' + JSON.stringify(this.httpClient.get('https://localhost:44388/api/Employees')))
    console.log(JSON.stringify({
      id: 1,
      name: "test_name"
    }))
    console.log(testemp)
    console.log(testemp[0])
  }

  onSubmit(): void {
    // this.testGet()
    window.alert("test")
  }
}
