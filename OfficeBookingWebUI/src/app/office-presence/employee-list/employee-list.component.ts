import { Component, OnInit } from '@angular/core';
import { OfficePresenceService } from '../../shared/office-presence.service';

@Component({
  selector: 'app-employee-list',
  standalone: false,
  
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent implements OnInit {
  employeeCars: any[] = []

  constructor(private officePresenceService: OfficePresenceService) {

  }


  ngOnInit(): void {
    this.getEmployeeWithCars()
  }
  getEmployeeWithCars(): void {
    this.officePresenceService.getEmployeesWithCars().subscribe({
      next: (data: any) => {
        this.employeeCars = data;
      },
      error: (err: any) => {
        console.error('Error fetching employee data', err);
      }
    });
  }
}
