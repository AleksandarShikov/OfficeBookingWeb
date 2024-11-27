import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment';
import { OfficePresence } from './office-presence-view.model';

@Injectable({
  providedIn: 'root'
})
export class OfficePresenceService {

  constructor(private http: HttpClient) { }
  list: OfficePresence[] = []
  FormData: OfficePresence = new OfficePresence();

  url: string = environment.apiBaseUrl + '/OfficePresence/GetAllOfficePresences'
  refreshList() {
    this.http.get(this.url)
      .subscribe({
        next: res => {
          this.list = res as OfficePresence[]
      },
        error: err => { console.log(err); }
      })
  }
}
