import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment';
import { OfficePresence } from '../shared/office-presence-view.model';
import { Employee } from './employee.model';
import { ParkingReservation } from './parking-reservation.model';
import { ParkingSpot } from './parking-spot.model';
import { FormBuilder } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class OfficePresenceService {

  constructor(private http: HttpClient, private fb: FormBuilder) { }

  list: OfficePresence[] = []
  FormData: OfficePresence = new OfficePresence()
  employees: Employee[] = []
  reservations: ParkingReservation[] = []
  parkingSpots: ParkingSpot[] = []

  geturl: string = environment.apiBaseUrl + '/OfficePresence/GetAllOfficePresences'
  refreshList() {
    this.http.get(this.geturl)
      .subscribe({
        next: res => {
          this.list = res as OfficePresence[]
      },
        error: err => { console.log(err); }
      })
  }
  requesturl: string = environment.apiBaseUrl + '/OfficePresence/CreateOfficePresence'

}
