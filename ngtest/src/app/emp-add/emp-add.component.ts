import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-emp-add',
  templateUrl: './emp-add.component.html',
  styleUrls: ['./emp-add.component.css']
})
export class EmpAddComponent implements OnInit {

  addForm = this.formBuilder.group({
    emp_FirstName: '',
    emp_LastName: '',
    emp_Age: '',
    emp_Building_ID: ''
  });

  constructor( 
    private formBuilder: FormBuilder,
    private httpClient: HttpClient 
  ) { }

  ngOnInit() {
  }

  onSubmit(data): void {

    var post_response = this.httpClient.post(
      'https://localhost:44388/api/Employees',
      {
        emp_FirstName: data.value.emp_FirstName,
        emp_LastName: data.value.emp_LastName,
        emp_Age: data.value.emp_Age,
        emp_Building_ID: data.value.emp_Building_ID,
      }).subscribe()

    console.log(post_response)
    console.log(data.value)

    this.addForm.reset();
  }

}
