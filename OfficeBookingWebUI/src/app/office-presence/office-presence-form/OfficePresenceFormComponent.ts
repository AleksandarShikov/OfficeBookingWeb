import { Component, OnInit } from "@angular/core";
import { OfficePresenceService } from "../../shared/office-presence.service";
import { Employee } from "../../shared/employee.model";
import { OfficePresence } from "../../shared/office-presence.model";
import { OfficeRoom } from "../../shared/office-room.model";
import { ParkingReservation } from "../../shared/parking-reservation.model";
import { ParkingSpot } from "../../shared/parking-spot.model";


@Component({
  selector: 'app-office-presence-form',
  standalone: false,

  templateUrl: './office-presence-form.component.html',
  styleUrl: './office-presence-form.component.css'
})
export class OfficePresenceFormComponent implements OnInit {

  formData: OfficePresence = new OfficePresence()
  employees: Employee[] = []
  officeRooms: OfficeRoom[] = []
  constructor(private officePresenceService: OfficePresenceService) {

  }

  ngOnInit(): void {
    this.loadEmployees();
    this.loadOfficeRooms();
  }

  loadEmployees(): void {
    this.officePresenceService.getEmployees().subscribe({
      next: (data) => {
        this.employees = data;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }


  loadOfficeRooms(): void {
    this.officePresenceService.getOfficeRooms().subscribe({
      next: (data) => {
        this.officeRooms = data;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  onSubmit(): void {
    this.createOfficePresence();
  }

  

  createOfficePresence(): void {
    this.officePresenceService.createOfficePresence(this.formData).subscribe({
      next: (response) => {
        console.log('Office presence created successfully');
        window.location.reload();
      },
      error: (err) => {
        console.error('Error creating office presence:', err);
      }
    });
  }


}


