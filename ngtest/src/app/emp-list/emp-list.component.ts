import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-emp-list',
  templateUrl: './emp-list.component.html',
  styleUrls: ['./emp-list.component.css']
})
export class EmpListComponent implements OnInit {
  emp  = this.httpClient.get('https://localhost:44388/api/Employees')
  
  displayedColumns: string[] = [ 'position', 'emp_ID', 'emp_FirstName', 'emp_LastName'];

  constructor(public httpClient: HttpClient) { }

  ngOnInit() {
    
  }

}
