import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment';
import { OfficePresence } from '../shared/office-presence.model';
import { Employee } from './employee.model';
import { ParkingReservation } from './parking-reservation.model';
import { ParkingSpot } from './parking-spot.model';
import { FormBuilder } from '@angular/forms';
import { OfficeRoom } from './office-room.model';
import { Observable } from 'rxjs';
import { OfficePresenceView } from './office-presence-view.model';
import { OfficePresenceWithReservation } from './office-presence-with-reservation.model';

@Injectable({
  providedIn: 'root'
})
export class OfficePresenceService {

  constructor(private http: HttpClient, private fb: FormBuilder) { }

  getOfficePresences(): Observable<OfficePresenceView[]> {
    return this.http.get<OfficePresenceView[]>(`${environment.apiBaseUrl}/OfficePresence/GetAllOfficePresences`);
  }
  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${environment.apiBaseUrl}/Employee/GetAllEmployees`);
  }
  getParkingSpots(): Observable<ParkingSpot[]> {
    return this.http.get<ParkingSpot[]>(`${environment.apiBaseUrl}/ParkingSpot/GetAllParkingSpots`);
  }
  getOfficeRooms(): Observable<OfficeRoom[]> {
    return this.http.get<OfficeRoom[]>(`${environment.apiBaseUrl}/OfficeRoom/GetAllOfficeRooms`);
  }
  createOfficePresence(data: OfficePresenceWithReservation): Observable<OfficePresenceWithReservation> {
    return this.http.post<OfficePresenceWithReservation>(`${environment.apiBaseUrl}/OfficeReservation/CreatePresenceWithReservation`, data);
  }
  createParkingReservation(data: ParkingReservation): Observable<ParkingReservation> {
    return this.http.post<ParkingReservation>(`${environment.apiBaseUrl}/ParkingReservation/CreateParkingReservation`, data);
  }
  deleteOfficePresence(presenceId: number): Observable<any> {
    return this.http.delete(`${environment.apiBaseUrl}/OfficePresence/DeleteOfficePresence/${presenceId}`);
  }
  getEmployeesWithCars(): Observable<any[]> {
    return this.http.get<any[]>(`${environment.apiBaseUrl}/Employee/allwithcars`);
  }

}
