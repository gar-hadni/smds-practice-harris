import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { EmpListComponent } from './emp-list/emp-list.component';
import { EmpAddComponent } from './emp-add/emp-add.component';

const routes: Routes = [
  { path: '', component: EmpListComponent },
  { path: 'emp/list', component: EmpListComponent },
  { path: 'emp/add', component: EmpAddComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
