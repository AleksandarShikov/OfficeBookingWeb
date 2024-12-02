import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './office-presence/employee-list/employee-list.component';
import { OfficePresenceFormComponent } from './office-presence/office-presence-form/OfficePresenceFormComponent';
import { OfficePresenceComponent } from './office-presence/office-presence.component';

const routes: Routes = [
  { path: 'employee-list', component: EmployeeListComponent },
  { path: 'office-presence-form', component: OfficePresenceFormComponent },
  { path: 'office-presence', component: OfficePresenceComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
