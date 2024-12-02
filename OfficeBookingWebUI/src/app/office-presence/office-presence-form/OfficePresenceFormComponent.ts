import { Component, Input, OnInit } from "@angular/core";
import { OfficePresenceService } from "../../shared/office-presence.service";
import { Employee } from "../../shared/employee.model";
import { OfficePresence } from "../../shared/office-presence.model";
import { OfficeRoom } from "../../shared/office-room.model";
import { ParkingReservation } from "../../shared/parking-reservation.model";
import { ParkingSpot } from "../../shared/parking-spot.model";
import { OfficePresenceWithReservation } from "../../shared/office-presence-with-reservation.model";



@Component({
  selector: 'app-office-presence-form',
  standalone: false,

  templateUrl: './office-presence-form.component.html',
  styleUrl: './office-presence-form.component.css'
})
export class OfficePresenceFormComponent implements OnInit {
  formData: OfficePresenceWithReservation = new OfficePresenceWithReservation
  employees: Employee[] = []
  officeRooms: OfficeRoom[] = []
  parkingSpots: ParkingSpot[] = []


  constructor(private officePresenceService: OfficePresenceService) {

  }

  ngOnInit(): void {
    this.loadEmployees();
    this.loadOfficeRooms();
    this.loadParkingSpots();
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

  loadParkingSpots(): void {
    this.officePresenceService.getParkingSpots().subscribe({
      next: (data) => {
        this.parkingSpots = data;
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
    window.location.reload();
  }

  createOfficePresence(): void {
    this.officePresenceService.createOfficePresence(this.formData).subscribe({
      next: (response) => {
        console.log('Office presence created successfully', response);
      },
      error: (err) => {
        console.error('Error creating office presence:', err);
      }
    });
  }




}




