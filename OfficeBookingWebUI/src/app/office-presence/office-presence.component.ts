import { Component,OnInit } from '@angular/core';
import { OfficePresenceService } from '../shared/office-presence.service';
import { OfficePresenceView } from '../shared/office-presence-view.model';
import { OfficePresence } from '../shared/office-presence.model';

@Component({
  selector: 'app-office-presence',
  standalone: false,

  templateUrl: './office-presence.component.html',
  styleUrl: './office-presence.component.css'
})
export class OfficePresenceComponent implements OnInit {
  list: any[] = []
  
  constructor(private officePresenceService: OfficePresenceService) {

  }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(): void {
    this.officePresenceService.getOfficePresences().subscribe({
      next: (data) => {
        this.list = data;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }
  
}
